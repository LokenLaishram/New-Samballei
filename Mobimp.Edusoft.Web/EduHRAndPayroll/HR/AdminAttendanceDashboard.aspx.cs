using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.HR
{
    public partial class AdminAttendanceDashboard : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
                // bindgrid(1);
            }
        }
        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            Commonfunction.PopulateDdl(ddlMonth, mstlookup.GetLookupsList(LookupNames.Months));
            Commonfunction.PopulateDdl(ddl_employee, mstlookup.GetLookupsList(LookupNames.Employee));
            divsearch.Visible = false;
        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmployeeName(string prefixText, int count, string contextKey)
        {
            ManualAttendanceData ObjData = new ManualAttendanceData();
            ManualAttendanceBO ObjBO = new ManualAttendanceBO();
            List<ManualAttendanceData> getResult = new List<ManualAttendanceData>();
            ObjData.EmployeeName = prefixText;
            getResult = ObjBO.GetEmployeeName(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeName.ToString());
            }
            return list;
        }
        private void bindgrid(int index)
        {

            if (ddlSession.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select session.") + "')", true);
                divsearch.Visible = false;
                btnPrint.Visible = false;
                GvAttendanceDashboard.DataSource = null;
                GvAttendanceDashboard.DataBind();
                return;
            }
            if (ddlMonth.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select month.") + "')", true);
                divsearch.Visible = false;
                btnPrint.Visible = false;
                GvAttendanceDashboard.DataSource = null;
                GvAttendanceDashboard.DataBind();
                return;
            }
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ManualAttendanceData> lstAttendance = GetPreviewAttendanceDashboard(index, pagesize);
            if (lstAttendance.Count > 0)
            {
                divsearch.Visible = true;
                GvAttendanceDashboard.PageSize = pagesize;
                string record = lstAttendance[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstAttendance[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstAttendance[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvAttendanceDashboard.VirtualItemCount = lstAttendance[0].MaximumRows;//total item is required for custom paging
                GvAttendanceDashboard.PageIndex = index - 1;
                GvAttendanceDashboard.DataSource = lstAttendance;
                GvAttendanceDashboard.DataBind();
                GvAttendanceDashboard.Visible = true;
                btnPrint.Visible = true;
                ds = ConvertToDataSet(lstAttendance);
                TableCell tableCell = GvAttendanceDashboard.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();

                //Calculate Sum and display in Footer Row
                //int total = lstAttendance.AsEnumerable().Sum(row => row.Field<int>("Price"));
                GvAttendanceDashboard.FooterRow.Cells[1].Text = "Total";
                GvAttendanceDashboard.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                GvAttendanceDashboard.FooterRow.Cells[2].Text = lstAttendance[0].TotalEmployeePresent.ToString();
                GvAttendanceDashboard.FooterRow.Cells[3].Text = lstAttendance[0].TotalEmployeeAbsent.ToString();
                GvAttendanceDashboard.FooterRow.Cells[4].Text = lstAttendance[0].TotalEmployeeLeave.ToString();
                GvAttendanceDashboard.FooterRow.Cells[5].Text = lstAttendance[0].TotalEmployeeHalfDay.ToString();

                int chk_year = Convert.ToInt32(lstAttendance[0].YearID.ToString());
                int isleapyear = 0;

                if ((chk_year % 4) == 0)
                {
                    isleapyear = 1; // Laep Year
                }
                else
                {
                    isleapyear = 2; // Not Leap Year
                }
                if (isleapyear == 1 && ddlMonth.SelectedValue == "2")
                {
                    GvAttendanceDashboard.Columns[36].Visible = false;
                    GvAttendanceDashboard.Columns[35].Visible = false;
                }
                else if (isleapyear == 2 && ddlMonth.SelectedValue == "2")
                {
                    GvAttendanceDashboard.Columns[36].Visible = false;
                    GvAttendanceDashboard.Columns[35].Visible = false;
                    GvAttendanceDashboard.Columns[34].Visible = false;
                }
                else if (ddlMonth.SelectedValue == "4" || ddlMonth.SelectedValue == "6" || ddlMonth.SelectedValue == "9" || ddlMonth.SelectedValue == "11")
                {
                    GvAttendanceDashboard.Columns[36].Visible = false;
                }
                else
                {
                    GvAttendanceDashboard.Columns[36].Visible = true;
                    GvAttendanceDashboard.Columns[35].Visible = true;
                    GvAttendanceDashboard.Columns[34].Visible = true;
                }

            }
            else
            {
                GvAttendanceDashboard.DataSource = null;
                GvAttendanceDashboard.DataBind();
                divsearch.Visible = false;
                btnPrint.Visible = false;
            }
        }
        public List<ManualAttendanceData> GetPreviewAttendanceDashboard(int curIndex, int pagesize)
        {
            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(ddlSession.SelectedItem.Text == "" ? "0" : ddlSession.SelectedItem.Text);
            objdata.MonthID = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "0" : ddlMonth.SelectedValue);
            objdata.Month = ddlMonth.SelectedItem.Text == null ? "" : ddlMonth.SelectedItem.Text;
            objdata.EmployeeID = Convert.ToInt32(ddl_employee.Text == "" ? "0" : ddl_employee.Text);
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.AcademicSessionID = LoginToken.AcademicSessionID;
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetPreviewAttendanceDashboard(objdata);
        }
        public DataSet ConvertToDataSet<T>(IList<T> list)
        {
            DataSet dsFromDtStru = new DataSet();
            DataTable table = new DataTable();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            dsFromDtStru.Tables.Add(table);
            return dsFromDtStru;
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvAttendanceDashboard.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvAttendanceDashboard.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.UseAccessibleHeader = true;
            GvAttendanceDashboard.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            ddlSession.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddl_employee.SelectedIndex = 0;
            GvAttendanceDashboard.DataSource = null;
            GvAttendanceDashboard.DataBind();
            lbl_totalrecords.Visible = false;
            divsearch.Visible = false;
        }
        protected void GvAttendanceDashboard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowDropDown1")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status1");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus1");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown2")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status2");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus2");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown3")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status3");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus3");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown4")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status4");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus4");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown5")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status5");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus5");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown6")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status6");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus6");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown7")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status7");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus7");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown8")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status8");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus8");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown9")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status9");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus9");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown10")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status10");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus10");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown11")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status11");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus11");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown12")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status12");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus12");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown13")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status13");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus13");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown14")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status14");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus14");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown15")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status15");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus15");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown16")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status16");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus16");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown17")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status17");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus17");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown18")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status18");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus18");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown19")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status19");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus19");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown20")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status20");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus20");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown21")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status21");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus21");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown22")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status22");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus22");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown23")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status23");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus23");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown24")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status24");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus24");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown25")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status25");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus25");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown26")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status26");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus26");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown27")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status27");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus27");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown28")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status28");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus28");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown29")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status29");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus29");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown30")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status30");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus30");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }

            if (e.CommandName == "ShowDropDown31")
            {

                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAttendanceDashboard.Rows[i];
                DropDownList ddl = (DropDownList)gr.Cells[0].FindControl("ddl_status31");
                Button btn = (Button)gr.Cells[0].FindControl("btnStatus3");
                if (ddl != null)
                {
                    ddl.Visible = true;
                    btn.Visible = false;
                    bindresponsive();
                }
            }
        }
        protected void ddl_status1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay1");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status1");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 1;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay2");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status2");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 2;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay3");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status3");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 3;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay4");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status4");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 4;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay5");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status5");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 5;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status6_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay6");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status6");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 6;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status7_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay7");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status7");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 7;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status8_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay8");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status8");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 8;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status9_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay9");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status9");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 9;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status10_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay10");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status10");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 10;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status11_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay11");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status11");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 11;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status12_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay12");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status12");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 12;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status13_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay13");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status13");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 13;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status14_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay14");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status14");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 14;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status15_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay15");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status15");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 15;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status16_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay16");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status16");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 16;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status17_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay17");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status17");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 17;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status18_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay18");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status18");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 18;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status19_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay19");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status19");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 19;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status20_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay20");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status20");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 20;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status21_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay21");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status21");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 21;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status22_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay22");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status22");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 22;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status23_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay23");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status23");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 23;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status24_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay24");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status24");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 24;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status25_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay25");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status25");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 25;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status26_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay26");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status26");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 26;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status27_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay27");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status27");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 27;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status28_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay28");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status28");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 28;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status29_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay29");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status29");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 29;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status30_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay30");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status30");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void ddl_status31_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label YearID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
            Label MonthID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
            Label EmployeeID = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_EmployeeID");
            Label Day = (Label)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDay31");
            DropDownList AttendanceStatus = (DropDownList)GvAttendanceDashboard.Rows[row.RowIndex].Cells[0].FindControl("ddl_status31");

            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
            objdata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
            objdata.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
            objdata.DateDay = 31;
            objdata.AttendanceStatusID = Convert.ToInt32(AttendanceStatus.SelectedValue == "" ? "0" : AttendanceStatus.SelectedValue);
            objdata.AttendanceStatus = AttendanceStatus.SelectedItem.Text == null ? "" : AttendanceStatus.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            int result = objBO.UpdateAttendance(objdata);
            if (result == 1)
            {
                bindgrid(1);
            }
        }
        protected void GvAttendanceDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button Status1 = (Button)e.Row.FindControl("btnStatus1");
                    Button Status2 = (Button)e.Row.FindControl("btnStatus2");
                    Button Status3 = (Button)e.Row.FindControl("btnStatus3");
                    Button Status4 = (Button)e.Row.FindControl("btnStatus4");
                    Button Status5 = (Button)e.Row.FindControl("btnStatus5");
                    Button Status6 = (Button)e.Row.FindControl("btnStatus6");
                    Button Status7 = (Button)e.Row.FindControl("btnStatus7");
                    Button Status8 = (Button)e.Row.FindControl("btnStatus8");
                    Button Status9 = (Button)e.Row.FindControl("btnStatus9");
                    Button Status10 = (Button)e.Row.FindControl("btnStatus10");
                    Button Status11 = (Button)e.Row.FindControl("btnStatus11");
                    Button Status12 = (Button)e.Row.FindControl("btnStatus12");
                    Button Status13 = (Button)e.Row.FindControl("btnStatus13");
                    Button Status14 = (Button)e.Row.FindControl("btnStatus14");
                    Button Status15 = (Button)e.Row.FindControl("btnStatus15");
                    Button Status16 = (Button)e.Row.FindControl("btnStatus16");
                    Button Status17 = (Button)e.Row.FindControl("btnStatus17");
                    Button Status18 = (Button)e.Row.FindControl("btnStatus18");
                    Button Status19 = (Button)e.Row.FindControl("btnStatus19");
                    Button Status20 = (Button)e.Row.FindControl("btnStatus20");
                    Button Status21 = (Button)e.Row.FindControl("btnStatus21");
                    Button Status22 = (Button)e.Row.FindControl("btnStatus22");
                    Button Status23 = (Button)e.Row.FindControl("btnStatus23");
                    Button Status24 = (Button)e.Row.FindControl("btnStatus24");
                    Button Status25 = (Button)e.Row.FindControl("btnStatus25");
                    Button Status26 = (Button)e.Row.FindControl("btnStatus26");
                    Button Status27 = (Button)e.Row.FindControl("btnStatus27");
                    Button Status28 = (Button)e.Row.FindControl("btnStatus28");
                    Button Status29 = (Button)e.Row.FindControl("btnStatus29");
                    Button Status30 = (Button)e.Row.FindControl("btnStatus30");
                    Button Status31 = (Button)e.Row.FindControl("btnStatus31");

                    if (Status1.Text == "P")
                    {
                        Status1.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status1.Text == "A")
                    {
                        Status1.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status1.Text == "L")
                    {
                        Status1.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status1.Text == "H")
                    {
                        Status1.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status1.Text == "")
                    {
                        Status1.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status2.Text == "P")
                    {
                        Status2.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status2.Text == "A")
                    {
                        Status2.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status2.Text == "L")
                    {
                        Status2.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status2.Text == "H")
                    {
                        Status2.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status2.Text == "")
                    {
                        Status2.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status3.Text == "P")
                    {
                        Status3.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status3.Text == "A")
                    {
                        Status3.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status3.Text == "L")
                    {
                        Status3.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status3.Text == "H")
                    {
                        Status3.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status3.Text == "")
                    {
                        Status3.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status4.Text == "P")
                    {
                        Status4.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status4.Text == "A")
                    {
                        Status4.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status4.Text == "L")
                    {
                        Status4.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status4.Text == "H")
                    {
                        Status4.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status4.Text == "")
                    {
                        Status4.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status5.Text == "P")
                    {
                        Status5.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status5.Text == "A")
                    {
                        Status5.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status5.Text == "L")
                    {
                        Status5.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status5.Text == "H")
                    {
                        Status5.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status5.Text == "")
                    {
                        Status5.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status6.Text == "P")
                    {
                        Status6.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status6.Text == "A")
                    {
                        Status6.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status6.Text == "L")
                    {
                        Status6.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status6.Text == "H")
                    {
                        Status6.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status6.Text == "")
                    {
                        Status6.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status7.Text == "P")
                    {
                        Status7.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status7.Text == "A")
                    {
                        Status7.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status7.Text == "L")
                    {
                        Status7.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status7.Text == "H")
                    {
                        Status7.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status7.Text == "")
                    {
                        Status7.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status8.Text == "P")
                    {
                        Status8.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status8.Text == "A")
                    {
                        Status8.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status8.Text == "L")
                    {
                        Status8.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status8.Text == "H")
                    {
                        Status8.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status8.Text == "")
                    {
                        Status8.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status9.Text == "P")
                    {
                        Status9.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status9.Text == "A")
                    {
                        Status9.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status9.Text == "L")
                    {
                        Status9.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status9.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status9.Text == "H")
                    {
                        Status9.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status9.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status9.Text == "")
                    {
                        Status9.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status10.Text == "P")
                    {
                        Status10.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status10.Text == "A")
                    {
                        Status10.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status10.Text == "L")
                    {
                        Status10.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status10.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status10.Text == "H")
                    {
                        Status10.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status10.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status10.Text == "")
                    {
                        Status10.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status11.Text == "P")
                    {
                        Status11.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status11.Text == "A")
                    {
                        Status11.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status11.Text == "L")
                    {
                        Status11.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status11.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status11.Text == "H")
                    {
                        Status11.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status11.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status11.Text == "")
                    {
                        Status11.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status12.Text == "P")
                    {
                        Status12.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status12.Text == "A")
                    {
                        Status12.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status12.Text == "L")
                    {
                        Status12.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status12.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status12.Text == "H")
                    {
                        Status12.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status12.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status12.Text == "")
                    {
                        Status12.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status13.Text == "P")
                    {
                        Status13.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status13.Text == "A")
                    {
                        Status13.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status13.Text == "L")
                    {
                        Status13.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status13.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status13.Text == "H")
                    {
                        Status13.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status13.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status13.Text == "")
                    {
                        Status13.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status14.Text == "P")
                    {
                        Status14.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status14.Text == "A")
                    {
                        Status14.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status14.Text == "L")
                    {
                        Status14.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status14.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status14.Text == "H")
                    {
                        Status14.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status14.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status14.Text == "")
                    {
                        Status14.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status15.Text == "P")
                    {
                        Status15.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status15.Text == "A")
                    {
                        Status15.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status15.Text == "L")
                    {
                        Status15.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status15.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status15.Text == "H")
                    {
                        Status15.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status15.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status15.Text == "")
                    {
                        Status15.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status16.Text == "P")
                    {
                        Status16.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status16.Text == "A")
                    {
                        Status16.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status16.Text == "L")
                    {
                        Status16.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status16.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status16.Text == "H")
                    {
                        Status16.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status16.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status16.Text == "")
                    {
                        Status16.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status17.Text == "P")
                    {
                        Status17.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status17.Text == "A")
                    {
                        Status17.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status17.Text == "L")
                    {
                        Status17.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status17.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status17.Text == "H")
                    {
                        Status17.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status17.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status17.Text == "")
                    {
                        Status17.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status18.Text == "P")
                    {
                        Status18.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status18.Text == "A")
                    {
                        Status18.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status18.Text == "L")
                    {
                        Status18.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status18.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status18.Text == "H")
                    {
                        Status18.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status18.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status18.Text == "")
                    {
                        Status18.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status19.Text == "P")
                    {
                        Status19.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status19.Text == "A")
                    {
                        Status19.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status19.Text == "L")
                    {
                        Status19.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status19.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status19.Text == "H")
                    {
                        Status19.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status19.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status19.Text == "")
                    {
                        Status19.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status20.Text == "P")
                    {
                        Status20.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status20.Text == "A")
                    {
                        Status20.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status20.Text == "L")
                    {
                        Status20.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status20.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status20.Text == "H")
                    {
                        Status20.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status20.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status20.Text == "")
                    {
                        Status20.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status21.Text == "P")
                    {
                        Status21.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status21.Text == "A")
                    {
                        Status21.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status21.Text == "L")
                    {
                        Status21.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status21.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status21.Text == "H")
                    {
                        Status21.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status21.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status21.Text == "")
                    {
                        Status21.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status22.Text == "P")
                    {
                        Status22.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status22.Text == "A")
                    {
                        Status22.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status22.Text == "L")
                    {
                        Status22.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status22.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status22.Text == "H")
                    {
                        Status22.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status22.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status22.Text == "")
                    {
                        Status22.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status23.Text == "P")
                    {
                        Status23.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status23.Text == "A")
                    {
                        Status23.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status23.Text == "L")
                    {
                        Status23.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status23.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status23.Text == "H")
                    {
                        Status23.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status23.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status23.Text == "")
                    {
                        Status23.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status24.Text == "P")
                    {
                        Status24.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status24.Text == "A")
                    {
                        Status24.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status24.Text == "L")
                    {
                        Status24.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status24.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status24.Text == "H")
                    {
                        Status24.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status24.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status24.Text == "")
                    {
                        Status24.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status25.Text == "P")
                    {
                        Status25.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status25.Text == "A")
                    {
                        Status25.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status25.Text == "L")
                    {
                        Status25.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status25.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status25.Text == "H")
                    {
                        Status25.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status25.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status25.Text == "")
                    {
                        Status25.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status26.Text == "P")
                    {
                        Status26.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status26.Text == "A")
                    {
                        Status26.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status26.Text == "L")
                    {
                        Status26.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status26.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status26.Text == "H")
                    {
                        Status26.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status26.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status26.Text == "")
                    {
                        Status26.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status27.Text == "P")
                    {
                        Status27.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status27.Text == "A")
                    {
                        Status27.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status27.Text == "L")
                    {
                        Status27.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status27.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status27.Text == "H")
                    {
                        Status27.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status27.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status27.Text == "")
                    {
                        Status27.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status28.Text == "P")
                    {
                        Status28.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status28.Text == "A")
                    {
                        Status28.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status28.Text == "L")
                    {
                        Status28.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status28.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status28.Text == "H")
                    {
                        Status28.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status28.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status28.Text == "")
                    {
                        Status28.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status29.Text == "P")
                    {
                        Status29.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status29.Text == "A")
                    {
                        Status29.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status29.Text == "L")
                    {
                        Status29.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status29.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status29.Text == "H")
                    {
                        Status29.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status29.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status29.Text == "")
                    {
                        Status29.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status30.Text == "P")
                    {
                        Status30.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status30.Text == "A")
                    {
                        Status30.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status30.Text == "L")
                    {
                        Status30.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status30.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status30.Text == "H")
                    {
                        Status30.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status30.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status30.Text == "")
                    {
                        Status30.Visible = false;
                    }
                    //-----------------------------------------
                    if (Status31.Text == "P")
                    {
                        Status31.BackColor = System.Drawing.ColorTranslator.FromHtml("#45d733");
                    }
                    if (Status31.Text == "A")
                    {
                        Status31.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff3300");
                    }
                    if (Status31.Text == "L")
                    {
                        Status31.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status31.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status31.Text == "H")
                    {
                        Status31.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffff00");
                        Status31.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d0d0d");
                    }
                    if (Status31.Text == "")
                    {
                        Status31.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void ddl_employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void GvAttendanceDashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAttendanceDashboard.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Monthly Attendance");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= 'Monthly_Attendance.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        protected DataTable GetDatafromDatabase()
        {
            int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ManualAttendanceData> Attendance = GetPreviewAttendanceDashboard(1, size);
            List<AttendanceDashboardDataToExcel> Attendancetoexcel = new List<AttendanceDashboardDataToExcel>();
            int i = 0;
            foreach (ManualAttendanceData row in Attendance)
            {
                AttendanceDashboardDataToExcel Ecxecl = new AttendanceDashboardDataToExcel();
                Ecxecl.ID = Attendance[i].ID;
                Ecxecl.EmployeeName = Attendance[i].EmployeeName;
                Ecxecl.Year = Attendance[i].YearID.ToString();
                Ecxecl.Month = ddlMonth.SelectedItem.Text;
                Ecxecl.TotalPresent = Attendance[i].TotalPresent;
                Ecxecl.TotalAbsent = Attendance[i].TotalAbsent;
                Ecxecl.TotalLeave = Attendance[i].TotalLeave;
                Ecxecl.TotalHalfDay = Attendance[i].TotalHalfDay;
                Ecxecl.Date_1 = Attendance[i].Day1Status;
                Ecxecl.Date_2 = Attendance[i].Day2Status;
                Ecxecl.Date_3 = Attendance[i].Day3Status;
                Ecxecl.Date_4 = Attendance[i].Day4Status;
                Ecxecl.Date_5 = Attendance[i].Day5Status;
                Ecxecl.Date_6 = Attendance[i].Day6Status;
                Ecxecl.Date_7 = Attendance[i].Day7Status;
                Ecxecl.Date_8 = Attendance[i].Day8Status;
                Ecxecl.Date_9 = Attendance[i].Day9Status;
                Ecxecl.Date_10 = Attendance[i].Day10Status;
                Ecxecl.Date_11 = Attendance[i].Day11Status;
                Ecxecl.Date_12 = Attendance[i].Day12Status;
                Ecxecl.Date_13 = Attendance[i].Day13Status;
                Ecxecl.Date_14 = Attendance[i].Day14Status;
                Ecxecl.Date_15 = Attendance[i].Day15Status;
                Ecxecl.Date_16 = Attendance[i].Day16Status;
                Ecxecl.Date_17 = Attendance[i].Day17Status;
                Ecxecl.Date_18 = Attendance[i].Day18Status;
                Ecxecl.Date_19 = Attendance[i].Day19Status;
                Ecxecl.Date_20 = Attendance[i].Day20Status;
                Ecxecl.Date_21 = Attendance[i].Day21Status;
                Ecxecl.Date_22 = Attendance[i].Day22Status;
                Ecxecl.Date_23 = Attendance[i].Day23Status;
                Ecxecl.Date_24 = Attendance[i].Day24Status;
                Ecxecl.Date_25 = Attendance[i].Day25Status;
                Ecxecl.Date_26 = Attendance[i].Day26Status;
                Ecxecl.Date_27 = Attendance[i].Day27Status;
                Ecxecl.Date_28 = Attendance[i].Day28Status;
                Ecxecl.Date_29 = Attendance[i].Day29Status;
                Ecxecl.Date_30 = Attendance[i].Day30Status;
                Ecxecl.Date_31 = Attendance[i].Day31Status;

                Attendancetoexcel.Add(Ecxecl);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(Attendancetoexcel);
            return dt;

        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
        }
    }
}