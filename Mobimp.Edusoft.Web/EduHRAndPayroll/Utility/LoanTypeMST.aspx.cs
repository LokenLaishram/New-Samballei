using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.Utility
{
    public partial class LoanTypeMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                divsearch.Visible = false;
                bindgrid(1);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_loantenure.Text == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter correct loan tenure.") + "')", true);
                    return;
                }
                LoanTypeData objLoan = new LoanTypeData();
                LoanTypeBO objLoanBO = new LoanTypeBO();
                objLoan.Code = txtcode.Text;
                objLoan.Descriptions = txtdescription.Text;
                objLoan.LoanTenure = Convert.ToInt32(txt_loantenure.Text == "" ? "0" : txt_loantenure.Text);
                objLoan.InterestRate = Convert.ToDouble(txt_interestrate.Text == "" ? "0" : txt_interestrate.Text);
                objLoan.UserId = LoginToken.UserLoginId;
                objLoan.AddedBy = LoginToken.LoginId;
                objLoan.CompanyID = LoginToken.CompanyID;
                objLoan.IsActive = ddlstatus.SelectedValue == "1" ? true : false; ;
                objLoan.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objLoan.ActionType = EnumActionType.Update;
                    objLoan.LoanID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objLoanBO.UpdateLoanTypeDetails(objLoan);
                if (result == 1 || result == 2)
                {
                    clearall();
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
                bindgrid(1);
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
            List<LoanTypeData> lstLoanType = GetLoanTypedetails(index, pagesize);
            if (lstLoanType.Count > 0)
            {
                GvLoanTypeDetails.PageSize = pagesize;
                string record = lstLoanType[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstLoanType[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstLoanType[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvLoanTypeDetails.VirtualItemCount = lstLoanType[0].MaximumRows;//total item is required for custom paging
                GvLoanTypeDetails.PageIndex = index - 1;
                GvLoanTypeDetails.DataSource = lstLoanType;
                GvLoanTypeDetails.DataBind();
                ds = ConvertToDataSet(lstLoanType);
                TableCell tableCell = GvLoanTypeDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvLoanTypeDetails.DataSource = null;
                GvLoanTypeDetails.DataBind();            }
        }

        public List<LoanTypeData> GetLoanTypedetails(int curIndex, int pagesize)
        {
            LoanTypeData objLoan = new LoanTypeData();
            LoanTypeBO objLoanBO = new LoanTypeBO();
            objLoan.Code = txtcode.Text == "" ? null : txtcode.Text;
            objLoan.Descriptions = txtdescription.Text == "" ? null : txtdescription.Text;
            objLoan.ActionType = EnumActionType.Select;
            objLoan.PageSize = pagesize;
            objLoan.CurrentIndex = curIndex;
            objLoan.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            return objLoanBO.SearchLoanTypeDetails(objLoan);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvLoanTypeDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvLoanTypeDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvLoanTypeDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvLoanTypeDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvLoanTypeDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvLoanTypeDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvLoanTypeDetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvLoanTypeDetails.UseAccessibleHeader = true;
            GvLoanTypeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvLoanTypeDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvLoanTypeDetails.DataSource = sortedView;
                    GvLoanTypeDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvLoanTypeDetails.HeaderRow.Cells[ColumnIndex];
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

        protected void GvLoanTypeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    LoanTypeData objLoan = new LoanTypeData();
                    LoanTypeBO objLoanBO = new LoanTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvLoanTypeDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objLoan.LoanID = Convert.ToInt32(ID.Text);
                    List<LoanTypeData> GetResult = objLoanBO.GetLoanTypeDetailsByID(objLoan);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].Descriptions;
                        txt_loantenure.Text = GetResult[0].LoanTenure.ToString();
                        txt_interestrate.Text = GetResult[0].InterestRate.ToString();
                        ViewState["ID"] = GetResult[0].LoanID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    LoanTypeData objLoan = new LoanTypeData();
                    LoanTypeBO objLoanBO = new LoanTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvLoanTypeDetails.Rows[i];
                    TextBox remark = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (remark.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        remark.Focus();
                        return;
                    }
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objLoan.LoanID = Convert.ToInt32(ID.Text);
                    objLoan.ActionType = EnumActionType.Delete;
                    int Result = objLoanBO.DeleteLoanTypeDetailsByID(objLoan);
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
            txtcode.Text = "";
            txtdescription.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtcode.Text = "";
            txtdescription.Text = "";
            txt_loantenure.Text = "";
            txt_interestrate.Text = "";
            btnsave.Text = "Add";
            bindgrid(1);

        }
        protected void GvLoanTypeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLoanTypeDetails.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "LoanType List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= LoanType.xlsx");
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
            List<LoanTypeData> LoanTypeDetail = GetLoanTypedetails(1, size);
            List<LoanTypeDatatoExcel> LoanTypetoexcel = new List<LoanTypeDatatoExcel>();
            int i = 0;
            foreach (LoanTypeData row in LoanTypeDetail)
            {
                LoanTypeDatatoExcel EcxeclStd = new LoanTypeDatatoExcel();
                EcxeclStd.LoanCode = LoanTypeDetail[i].Code;
                EcxeclStd.LoanName = LoanTypeDetail[i].Descriptions;
                EcxeclStd.LoanTenure = LoanTypeDetail[i].LoanTenure;
                EcxeclStd.InterestRate = LoanTypeDetail[i].InterestRate;
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