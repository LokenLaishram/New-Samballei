using ClosedXML.Excel;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mobimp.Campusoft.Data.HRAndPayroll.Utility.Roster;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.Utility
{
    public partial class Roster : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddropdownlist();
                bindgrid(1);
            }
        }
        protected void binddropdownlist()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlMonth, mstlookup.GetLookupsList(LookupNames.Months));
            Commonfunction.PopulateDdl(ddl_employee, mstlookup.GetLookupsList(LookupNames.Employee));
            Commonfunction.PopulateDdl(ddl_shift, mstlookup.GetLookupsList(LookupNames.Shift));
            divserach.Visible = false;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            List<RosterData> listemployee = new List<RosterData>();
            RosterData objroster = new RosterData();
            RosterBO objBO = new RosterBO();
            // int index = 0;
            bindresponsive();
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in Gvroster.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label EmployeeID = (Label)Gvroster.Rows[row.RowIndex].FindControl("lbl_empID");
                    DropDownList ddl_shift = (DropDownList)Gvroster.Rows[row.RowIndex].FindControl("ddl_shift");

                    RosterData ObjDetails = new RosterData();
                    ObjDetails.EmployeeID = Convert.ToInt32(EmployeeID.Text);
                    ObjDetails.ShiftID = Convert.ToInt32(ddl_shift.SelectedValue == "" ? "0" : ddl_shift.SelectedValue);
                    ObjDetails.MonthID = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "0" : ddlMonth.SelectedValue);
                    ObjDetails.AddedBy = LoginToken.LoginId;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                    listemployee.Add(ObjDetails);
                }
                objroster.XMLData = XmlConvertor.RostertoXML(listemployee).ToString();
                int results = objBO.UpdateRoster(objroster);
                if (results == 1)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Error") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {

            if (ddlSession.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select session.')", true);
                return;
            }
            if (ddlMonth.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select month.')", true);
                return;
            }

            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<RosterData> lstLoanType = Getrosters(index, pagesize);
            if (lstLoanType.Count > 0)
            {
                Gvroster.PageSize = pagesize;
                string record = lstLoanType[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstLoanType[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstLoanType[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gvroster.VirtualItemCount = lstLoanType[0].MaximumRows;//total item is required for custom paging
                Gvroster.PageIndex = index - 1;
                Gvroster.DataSource = lstLoanType;
                Gvroster.DataBind();
                Gvroster.Visible = true;
                ds = ConvertToDataSet(lstLoanType);
                TableCell tableCell = Gvroster.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                btn_update.Visible = true;
                divserach.Visible = true;
                btnPrint.Visible = true;
            }
            else
            {
                Gvroster.DataSource = null;
                Gvroster.DataBind();
                btn_update.Visible = false;
                divserach.Visible = false;
                btnPrint.Visible = false;
            }
        }
        public List<RosterData> Getrosters(int curIndex, int pagesize)
        {
            RosterData objroster = new RosterData();
            RosterBO objBO = new RosterBO();
            objroster.AcademicSessionID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            objroster.MonthID = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "0" : ddlMonth.SelectedValue);
            objroster.EmployeeID = Convert.ToInt32(ddl_employee.SelectedValue == "" ? "0" : ddl_employee.SelectedValue);
            objroster.ShiftID = Convert.ToInt32(ddl_shift.SelectedValue == "" ? "0" : ddl_shift.SelectedValue);
            objroster.PageSize = pagesize;
            objroster.CurrentIndex = curIndex;

            return objBO.Searchroster(objroster);
        }
        protected void Gvroster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in Gvroster.Rows)
            {
                try
                {
                    DropDownList ddl_shift = (DropDownList)Gvroster.Rows[row.RowIndex].FindControl("ddl_shift");

                    MasterLookupBO objmstlookupBO = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddl_shift, objmstlookupBO.GetLookupsList(LookupNames.Shift));
                    Label shiftID = (Label)Gvroster.Rows[row.RowIndex].FindControl("lbl_shiftID");
                    if (shiftID.Text != "0")
                    {
                        ddl_shift.Items.FindByValue(shiftID.Text).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gvroster.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gvroster.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gvroster.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";

            ////  Adds THEAD and TBODY to GridView.
            Gvroster.UseAccessibleHeader = true;
            Gvroster.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }
        protected void Gvroster_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                bindgrid(1);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                {
                    string SortDir = string.Empty;
                    if (dir == SortDirection.Ascending)
                    {
                        dir = SortDirection.Descending;
                        SortDir = "Desc";
                    }
                    else
                    {
                        dir = SortDirection.Ascending;
                        SortDir = "Asc";
                    }
                    DataView sortedView = new DataView(dt);
                    sortedView.Sort = e.SortExpression + " " + SortDir;
                    Gvroster.DataSource = sortedView;
                    Gvroster.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gvroster.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }
        }
        static public int GetColumnIndexByDBName(GridView aGridView, String ColumnText)
        {
            System.Web.UI.WebControls.BoundField DataColumn;
            for (int Index = 0; Index < aGridView.Columns.Count; Index++)
            {
                DataColumn = aGridView.Columns[Index] as System.Web.UI.WebControls.BoundField;
                if (DataColumn != null)
                {
                    if (DataColumn.DataField == ColumnText)
                        return Index;
                }
            }
            return -1;
        }
        protected void Gvroster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvroster.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Roster");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= 'Roster.xlsx");
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
            List<RosterData> LoanTypeDetail = Getrosters(1, size);
            List<RosterDatatoExcel> LoanTypetoexcel = new List<RosterDatatoExcel>();
            int i = 0;
            foreach (RosterData row in LoanTypeDetail)
            {
                RosterDatatoExcel EcxeclStd = new RosterDatatoExcel();
                EcxeclStd.ID = LoanTypeDetail[i].ID;
                EcxeclStd.EmployeeName = LoanTypeDetail[i].EmpName;
                EcxeclStd.Shift = LoanTypeDetail[i].Shift;
                EcxeclStd.ShifTime = LoanTypeDetail[i].ShifTime;
                LoanTypetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(LoanTypetoexcel);
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
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ddlSession.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddl_employee.SelectedIndex = 0;
            Gvroster.DataSource = null;
            Gvroster.DataBind();
            Gvroster.Visible = false;
            btn_update.Visible = false;
            divserach.Visible = false;
            btnPrint.Visible = false;
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string baseurl = Request.Url.GetLeftPart(UriPartial.Authority);
            int year = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            int month = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "0" : ddlMonth.SelectedValue);
            int employee = Convert.ToInt32(ddl_employee.SelectedValue == "" ? "0" : ddl_employee.SelectedValue);
            int Shift = Convert.ToInt32(ddl_shift.SelectedValue == "" ? "0" : ddl_shift.SelectedValue);

            string url = baseurl + '/'+"../EduHRAndPayroll/Utility/Reports/ReportViewer.aspx?option=Roster&SessionID=" + year + "&MonthID=" + month + "&EmployeeID=" + employee + "&ShiftID=" + Shift;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
    }
}