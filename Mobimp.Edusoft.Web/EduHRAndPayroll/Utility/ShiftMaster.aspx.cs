using ClosedXML.Excel;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility;
using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
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

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.Utility
{
    public partial class ShiftMaster : BasePage
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
            Commonfunction.PopulateDdl(ddl_starttime, mstlookup.GetLookupsList(LookupNames.Timer));
            Commonfunction.PopulateDdl(ddl_endtime, mstlookup.GetLookupsList(LookupNames.Timer));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_shift.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter shift.") + "')", true);
                    return;
                }
                if (ddl_starttime.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter start time.") + "')", true);
                    return;
                }
                if (ddl_endtime.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter end time.") + "')", true);
                    return;
                }
                if (ddl_starttime.SelectedValue == ddl_endtime.SelectedValue)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter correct start and end time.") + "')", true);
                    return;
                }

                ShiftData objShift = new ShiftData();
                ShiftTypeBO objShiftBO = new ShiftTypeBO();
                objShift.Shift = txt_shift.Text;
                objShift.StartTime = Convert.ToInt32(ddl_starttime.SelectedValue == "" ? "0" : ddl_starttime.SelectedValue);
                objShift.EndTime = Convert.ToInt32(ddl_endtime.SelectedValue == "" ? "0" : ddl_endtime.SelectedValue);
                objShift.UserId = LoginToken.UserLoginId;
                objShift.AddedBy = LoginToken.LoginId;
                objShift.CompanyID = LoginToken.CompanyID;
                objShift.IsActive = ddlstatus.SelectedValue == "1" ? true : false; ;
                objShift.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objShift.ActionType = EnumActionType.Update;
                    objShift.ID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objShiftBO.UpdateShiftType(objShift);
                if (result == 1 || result == 2)
                {
                    clearall();
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);

                }

            }
            catch (Exception ex) //Exception in agent layer itself
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
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ShiftData> lstLoanType = GetShifttypedetails(index, pagesize);
            if (lstLoanType.Count > 0)
            {
                GvShift.PageSize = pagesize;
                string record = lstLoanType[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstLoanType[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstLoanType[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvShift.VirtualItemCount = lstLoanType[0].MaximumRows;//total item is required for custom paging
                GvShift.PageIndex = index - 1;
                GvShift.DataSource = lstLoanType;
                GvShift.DataBind();
                ds = ConvertToDataSet(lstLoanType);
                TableCell tableCell = GvShift.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvShift.DataSource = null;
                GvShift.DataBind();
            }
        }
        public List<ShiftData> GetShifttypedetails(int curIndex, int pagesize)
        {
            ShiftData objShift = new ShiftData();
            ShiftTypeBO objShiftBO = new ShiftTypeBO();
            objShift.Shift = txt_shift.Text == "" ? null : txt_shift.Text;
           
            objShift.ActionType = EnumActionType.Select;
            objShift.PageSize = pagesize;
            objShift.CurrentIndex = curIndex;
            objShift.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            return objShiftBO.Searchshifts(objShift);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvShift.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvShift.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvShift.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvShift.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvShift.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            ////GvShift.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvShift.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            ////  Adds THEAD and TBODY to GridView.
            GvShift.UseAccessibleHeader = true;
            GvShift.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvShift_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvShift.DataSource = sortedView;
                    GvShift.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvShift.HeaderRow.Cells[ColumnIndex];
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
        protected void GvShift_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ShiftData objShift = new ShiftData();
                    ShiftTypeBO objShiftBO = new ShiftTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvShift.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objShift.ID = Convert.ToInt32(ID.Text);
                    List<ShiftData> GetResult = objShiftBO.GetShiftByID(objShift);
                    if (GetResult.Count > 0)
                    {
                        txt_shift.Text = GetResult[0].Shift;
                        ddl_starttime.SelectedValue = GetResult[0].StartTime.ToString();
                        ddl_endtime.SelectedValue = GetResult[0].EndTime.ToString();
                        ViewState["ID"] = GetResult[0].ID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ShiftData objShift = new ShiftData();
                    ShiftTypeBO objShiftBO = new ShiftTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvShift.Rows[i];
                    TextBox remark = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (remark.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        remark.Focus();
                        return;
                    }
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objShift.ID = Convert.ToInt32(ID.Text);
                    objShift.UserId = LoginToken.EmployeeID;
                    int Result = objShiftBO.DeleteShiftByID(objShift);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        private void clearall()
        {
            txt_shift.Text = "";
            ddl_starttime.SelectedIndex = 0;
            ddl_endtime.SelectedIndex = 0;
            ddlstatus.SelectedIndex = 0;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            btnsave.Text = "Add";
            bindgrid(1);
        }
        protected void GvShift_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvShift.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Shift Type List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Shift.xlsx");
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
            List<ShiftData> LoanTypeDetail = GetShifttypedetails(1, size);
            List<ShiftDatatoExcel> LoanTypetoexcel = new List<ShiftDatatoExcel>();
            int i = 0;
            foreach (ShiftData row in LoanTypeDetail)
            {
                ShiftDatatoExcel EcxeclStd = new ShiftDatatoExcel();
                EcxeclStd.ID = LoanTypeDetail[i].ID;
                EcxeclStd.Shift = LoanTypeDetail[i].Shift;
                EcxeclStd.StartFrom = LoanTypeDetail[i].StartFrom;
                EcxeclStd.EndTo = LoanTypeDetail[i].EndTo;
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
    }
}