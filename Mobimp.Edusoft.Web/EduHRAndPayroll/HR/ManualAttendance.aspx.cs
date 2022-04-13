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
    public partial class ManualAttendance : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
                // ddlSession.Attributes["disabled"] = "disabled";
                btnUpdate.Attributes["disabled"] = "disabled";
                btnPrint.Attributes["disabled"] = "disabled";
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                divsearch.Visible = false;
            }
        }

        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddl_employee, mstlookup.GetLookupsList(LookupNames.Employee));
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            divsearch.Visible = false;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            if (ddlSession.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("AcademicSession") + "')", true);
                ddlSession.Focus();

                GvAttendanceList.DataSource = null;
                GvAttendanceList.DataBind();
                divsearch.Visible = false;
                return;
            }
            if (txtDate.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Date") + "')", true);
                txtDate.Focus();
                GvAttendanceList.DataSource = null;
                GvAttendanceList.DataBind();
                divsearch.Visible = false;
                return;
            }
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime SelectedDate = DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime Today = System.DateTime.Now;
            if ((SelectedDate - Today).Days > 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Future dates are not selectable.") + "')", true);
                txtDate.Focus();
                GvAttendanceList.DataSource = null;
                GvAttendanceList.DataBind();
                divsearch.Visible = false;
                return;
            }
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ManualAttendanceData> lstAttendance = GetAttendanceDetails(index, pagesize);
            if (lstAttendance.Count > 0)
            {
                GvAttendanceList.PageSize = pagesize;
                string record = lstAttendance[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstAttendance[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstAttendance[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvAttendanceList.VirtualItemCount = lstAttendance[0].MaximumRows;//total item is required for custom paging
                GvAttendanceList.PageIndex = index - 1;
                GvAttendanceList.DataSource = lstAttendance;
                GvAttendanceList.DataBind();
                divsearch.Visible = true;

                if (lstAttendance[0].IsUpdated.ToString() == "0")
                {
                    btnPrint.Attributes["disabled"] = "disabled";
                }
                else
                {
                    btnPrint.Attributes.Remove("disabled");
                }

                ds = ConvertToDataSet(lstAttendance);
                TableCell tableCell = GvAttendanceList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                btnUpdate.Attributes.Remove("disabled");
                divsearch.Visible = true;
            }
            else
            {
                GvAttendanceList.DataSource = null;
                GvAttendanceList.DataBind();
                btnUpdate.Attributes["disabled"] = "disabled";
                divsearch.Visible = false;
            }
        }

        public List<ManualAttendanceData> GetAttendanceDetails(int curIndex, int pagesize)
        {
            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            objdata.Year = ddlSession.SelectedItem.Text == "" ? "0" : ddlSession.SelectedItem.Text;
            objdata.EmployeeID = Convert.ToInt32(ddl_employee.SelectedValue == "" ? "0" : ddl_employee.SelectedValue);
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            objdata.Date = txtDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.AcademicSessionID = LoginToken.AcademicSessionID;
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetAttendanceDetails(objdata);
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
            GvAttendanceList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvAttendanceList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceList.UseAccessibleHeader = true;
            GvAttendanceList.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<ManualAttendanceData> ListAttendance = new List<ManualAttendanceData>();
                ManualAttendanceBO objBO = new ManualAttendanceBO();
                ManualAttendanceData objData = new ManualAttendanceData();
                int shiftcount = 0;
                foreach (GridViewRow row in GvAttendanceList.Rows)
                {
                    Label ID = (Label)GvAttendanceList.Rows[row.RowIndex].Cells[0].FindControl("Gv_ID");
                    Label Date = (Label)GvAttendanceList.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblDate");
                    Label shift = (Label)GvAttendanceList.Rows[row.RowIndex].Cells[0].FindControl("lbl_shift");
                    Label Employee = (Label)GvAttendanceList.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblEmployeeID");
                    DropDownList Attendance = (DropDownList)GvAttendanceList.Rows[row.RowIndex].Cells[0].FindControl("Gv_ddlAttendance");
                    TextBox Reason = (TextBox)GvAttendanceList.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtReason");
                    ManualAttendanceData ObjDetails = new ManualAttendanceData();
                    if (shift.Text != "")
                    {
                        if ((Attendance.SelectedValue == "2" || Attendance.SelectedValue == "3" || Attendance.SelectedValue == "4") && Reason.Text == "")
                        {
                            Reason.Focus();
                            Reason.BackColor = System.Drawing.Color.Red;
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter  reason for leave or absent or half day.") + "')", true);
                            return;
                        }
                        ObjDetails.ID = Convert.ToInt64(ID.Text == "" ? "0" : ID.Text);
                        ObjDetails.EmployeeID = Convert.ToInt64(Employee.Text == "" ? "0" : Employee.Text);
                        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                        ObjDetails.Date = Date.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(Date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        ObjDetails.AttendanceStatusID = Convert.ToInt32(Attendance.SelectedValue == "" ? "0" : Attendance.SelectedValue);
                        ObjDetails.AttendanceStatus = (Attendance.SelectedItem.Text == null ? "" : Attendance.SelectedItem.Text);
                        ObjDetails.Reason = Reason.Text == null ? "" : Reason.Text;
                        ListAttendance.Add(ObjDetails);
                    }
                    else
                    {
                        shiftcount = shiftcount + 1;
                        shift.BackColor = System.Drawing.Color.Yellow;
                    }

                }
                objData.XMLData = XmlConvertor.AttendanceListToXml(ListAttendance).ToString();
                objData.AddedBy = LoginToken.LoginId;
                objData.UserId = LoginToken.UserLoginId;
                objData.CompanyID = LoginToken.CompanyID;
                objData.AcademicSessionID = LoginToken.AcademicSessionID;

                if (shiftcount > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please manage employee roster completely.") + "')", true);
                    return;
                }

                int result = objBO.UpdateAttendanceDetails(objData);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    bindgrid(1);
                    return;
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    btnUpdate.Attributes["disabled"] = "disabled";
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void GvAttendanceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAttendanceList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void GvAttendanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label AttendanceID = (Label)e.Row.FindControl("Gv_lblAttendanceID");
                    DropDownList Attendance = (DropDownList)e.Row.FindControl("Gv_ddlAttendance");
                    if (AttendanceID.Text == "1")
                    {
                        Attendance.SelectedValue = "1";
                        Attendance.BackColor = System.Drawing.Color.Green;
                        Attendance.ForeColor = System.Drawing.Color.White;
                    }
                    if (AttendanceID.Text == "2")
                    {
                        Attendance.SelectedValue = "2";
                        Attendance.BackColor = System.Drawing.Color.Red;
                    }
                    if (AttendanceID.Text == "3")
                    {
                        Attendance.SelectedValue = "3";
                        Attendance.BackColor = System.Drawing.Color.Yellow;
                    }
                    if (AttendanceID.Text == "4")
                    {
                        Attendance.SelectedValue = "4";
                        Attendance.BackColor = System.Drawing.Color.Red;
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
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddl_employee.SelectedIndex = 0;
            divsearch.Visible = false;
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Daily Attendance");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= 'Attendnace.xlsx");
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
            List<ManualAttendanceData> Attendance = GetAttendanceDetails(1, size);
            List<AttendanceDataToExcel> Attendancetoexcel = new List<AttendanceDataToExcel>();
            int i = 0;
            foreach (ManualAttendanceData row in Attendance)
            {
                AttendanceDataToExcel Ecxecl = new AttendanceDataToExcel();
                Ecxecl.ID = Attendance[i].ID;
                Ecxecl.EmployeeName = Attendance[i].EmployeeName;
                Ecxecl.Year = Attendance[i].Year;
                Ecxecl.Month = Attendance[i].Month;
                Ecxecl.Day = Attendance[i].Day;
                Ecxecl.ShifTime = Attendance[i].ShifTime;
                Ecxecl.InOutTime = Attendance[i].InOutTime;
                Ecxecl.AttendanceStatus = Attendance[i].AttendanceStatus;
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
    }
}