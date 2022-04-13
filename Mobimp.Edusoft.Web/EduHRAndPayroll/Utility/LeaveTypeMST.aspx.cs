using ClosedXML.Excel;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility;
using Mobimp.Campusoft.Data.EduUtility;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.Utility;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
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
    public partial class LeaveTypeMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                divsearch.Visible = false;
                bindddl();
                bindgrid(1);
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_applicablefor, mstlookup.GetLookupsList(LookupNames.ApplicableDays));
        }
        public void btnadd(object sender, EventArgs e)
        {
            try
            {
                if (txtcode.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter code") + "')", true);
                    return;
                }
                if (txtleavetype.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter leave type") + "')", true);
                    return;
                }
                if (txt_nodays.Text.Trim() == "" || txt_nodays.Text.Trim() == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter number of days") + "')", true);
                    return;
                }
                if (ddl_applicablefor.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select applicable for") + "')", true);
                    return;
                }
                LeaveTypeData objLeaveType = new LeaveTypeData();
                LeaveTypeBO objLeaveTypeBO = new LeaveTypeBO();
                objLeaveType.code = txtcode.Text;
                objLeaveType.leavetype = txtleavetype.Text;
                objLeaveType.Nodays = Convert.ToInt32(txt_nodays.Text == "" ? "0" : txt_nodays.Text);
                objLeaveType.Applicablefor = Convert.ToInt32(ddl_applicablefor.SelectedValue == "" ? "0" : ddl_applicablefor.SelectedValue);
                objLeaveType.UserId = LoginToken.UserLoginId;
                objLeaveType.AddedBy = LoginToken.LoginId;
                objLeaveType.CompanyID = LoginToken.CompanyID;
                objLeaveType.IsActive = ddl_isactive.SelectedValue == "1" ? true : false;
                objLeaveType.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objLeaveType.ActionType = EnumActionType.Update;
                    objLeaveType.LeaveID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objLeaveTypeBO.UpdateLeaveTypeDetails(objLeaveType);
                if (result == 1 || result == 2)
                {
                    clearall();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnAdd.Text = "Add";
                }
                if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
                bindgrid(1);
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

        private void clearall()
        {
            txtcode.Text = "";
            txtleavetype.Text = "";
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedIndex == 10000 ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<LeaveTypeData> lstLeaveType = GetLeaveTypeDetails(index, pagesize);
            if (lstLeaveType.Count > 0)
            {
                GvLeaveType.PageSize = pagesize;
                string record = lstLeaveType[0].MaximumRows.ToString() == "1" ? " records found. " : " records found. ";
                lblresult.Text = "Total :" + lstLeaveType[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstLeaveType[0].MaximumRows.ToString();
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvLeaveType.VirtualItemCount = lstLeaveType[0].MaximumRows;
                GvLeaveType.PageIndex = index - 1;
                GvLeaveType.DataSource = lstLeaveType;
                GvLeaveType.DataBind();
                ds = ConvertToDataSet(lstLeaveType);
                TableCell tableCell = GvLeaveType.HeaderRow.Cells[0];
                Image image = new Image();
                image.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(image);
                bindresponsive();
            }
            else
            {
                lblresult.Visible = false;
                GvLeaveType.DataSource = null;
                GvLeaveType.DataBind();
            }
        }
        protected void bindresponsive()
        {
            GvLeaveType.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvLeaveType.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvLeaveType.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvLeaveType.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvLeaveType.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvLeaveType.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvLeaveType.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvLeaveType.UseAccessibleHeader = true;
            GvLeaveType.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        public List<LeaveTypeData> GetLeaveTypeDetails(int curIndex, int pagesize)
        {
            LeaveTypeData objLeaveType = new LeaveTypeData();
            LeaveTypeBO objLeaveTypeBO = new LeaveTypeBO();
            objLeaveType.code = txtcode.Text == "" ? null : txtcode.Text;
            objLeaveType.leavetype = txtleavetype.Text == "" ? null : txtleavetype.Text;
            objLeaveType.ActionType = EnumActionType.Select;
            objLeaveType.PageSize = pagesize;
            objLeaveType.CurrentIndex = curIndex;
            objLeaveType.IsActive = ddl_isactive.SelectedValue == "1" ? true : false;
            return objLeaveTypeBO.SearchLeaveTypeDetails(objLeaveType);
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
        protected void GvLeaveType_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvLeaveType.DataSource = sortedView;
                    GvLeaveType.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvLeaveType.HeaderRow.Cells[ColumnIndex];
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
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtcode.Text = "";
            txtleavetype.Text = "";
            txt_nodays.Text = "";
            btnAdd.Text = "Add";
            ddl_applicablefor.SelectedIndex = 0;
            ddl_isactive.SelectedIndex = 0;
            bindgrid(1);
        }
        protected void GvLeaveTypeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLeaveType.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
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
                wb.Worksheets.Add(dt, "LeaveType List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= LeaveType.xlsx");
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
            List<LeaveTypeData> LeaveTypeDetail = GetLeaveTypeDetails(1, size);
            List<LeaveTypeDatatoExcel> LoanTypetoexcel = new List<LeaveTypeDatatoExcel>();
            int i = 0;
            foreach (LeaveTypeData row in LeaveTypeDetail)
            {
                LeaveTypeDatatoExcel EcxeclStd = new LeaveTypeDatatoExcel();
                EcxeclStd.LeaveID = LeaveTypeDetail[i].LeaveID;
                EcxeclStd.code = LeaveTypeDetail[i].code;
                EcxeclStd.leavetype = LeaveTypeDetail[i].leavetype;
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

        protected void GvLeaveType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    LeaveTypeData objLeaveType = new LeaveTypeData();
                    LeaveTypeBO objLoanBO = new LeaveTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvLeaveType.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objLeaveType.LeaveID = Convert.ToInt32(ID.Text);
                    List<LeaveTypeData> GetResult = objLoanBO.GetLeaveTypeDetailsByID(objLeaveType);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].code;
                        txtleavetype.Text = GetResult[0].leavetype;
                        txt_nodays.Text = GetResult[0].Nodays.ToString();
                        ddl_applicablefor.SelectedValue = GetResult[0].Applicablefor.ToString();
                        ViewState["ID"] = GetResult[0].LeaveID;
                        btnAdd.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    LeaveTypeData objLeaveType = new LeaveTypeData();
                    LeaveTypeBO objLoanBO = new LeaveTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvLeaveType.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objLeaveType.Remarks = txtremarks.Text;
                    }
                    objLeaveType.LeaveID = Convert.ToInt32(ID.Text);
                    objLeaveType.ActionType = EnumActionType.Delete;
                    int Result = objLoanBO.DeleteLeaveTypeDetailsByID(objLeaveType);
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

        protected void ddl_isactive_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}