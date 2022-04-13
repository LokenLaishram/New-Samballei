using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduFeeUtility;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.EduFeeUtility;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web.EduFeeUtility
{
    public partial class PaymentTypeMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                lblmessage.Visible = true;
                bindgrid(1);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentTypeData objpayemnt = new PaymentTypeData();
                PaymentTypeBO objpayementBO = new PaymentTypeBO();
                objpayemnt.PaymentType = txtdescription.Text;
                objpayemnt.AddedBy = LoginToken.LoginId;
                objpayemnt.UserId = LoginToken.UserLoginId; ;
                objpayemnt.CompanyID = LoginToken.CompanyID;
                objpayemnt.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objpayemnt.ActionType = EnumActionType.Update;
                    objpayemnt.PaymentTypeID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objpayementBO.UpdatePaymentTypeDetails(objpayemnt);
                if (result == 1 || result == 2)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    clearall();
                    GvPaymentdetails.DataSource = GetPaymentTypeDetails(1, 10);
                    GvPaymentdetails.DataBind();
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
       
        protected void GvPaymentdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    PaymentTypeData objpayemnt = new PaymentTypeData();
                    PaymentTypeBO objpayementBO = new PaymentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvPaymentdetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objpayemnt.PaymentTypeID = Convert.ToInt32(ID.Text);
                    objpayemnt.ActionType = EnumActionType.Select;
                    List<PaymentTypeData> GetResult = objpayementBO.GetPaymentTypeDetailsByID(objpayemnt);
                    if (GetResult.Count > 0)
                    {
                        txtdescription.Text = GetResult[0].PaymentType;
                        ViewState["ID"] = GetResult[0].PaymentTypeID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    PaymentTypeData objpayemnt = new PaymentTypeData();
                    PaymentTypeBO objpayementBO = new PaymentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvPaymentdetails.Rows[i];
                    Label PaymentTypeID = (Label)gr.Cells[0].FindControl("lblID");
                    objpayemnt.PaymentTypeID = Convert.ToInt16(PaymentTypeID.Text);
                    objpayemnt.ActionType = EnumActionType.Delete;
                    int Result = objpayementBO.DeletePaymentTypeDetailsByID(objpayemnt);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<PaymentTypeData> lstPay = GetPaymentTypeDetails(index, pagesize);
            if (lstPay.Count > 0)
            {
                GvPaymentdetails.PageSize = pagesize;
                string record = lstPay[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstPay[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstPay[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvPaymentdetails.VirtualItemCount = lstPay[0].MaximumRows;//total item is required for custom paging
                GvPaymentdetails.PageIndex = index - 1;
                GvPaymentdetails.DataSource = lstPay;
                GvPaymentdetails.DataBind();
                ds = ConvertToDataSet(lstPay);
                TableCell tableCell = GvPaymentdetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvPaymentdetails.DataSource = null;
                GvPaymentdetails.DataBind();
                divsearch.Visible = true;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvPaymentdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvPaymentdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvPaymentdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvPaymentdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvPaymentdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //GvPaymentdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvPaymentdetails.UseAccessibleHeader = true;
            GvPaymentdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        public List<PaymentTypeData> GetPaymentTypeDetails(int curIndex, int pagesize)
        {
            PaymentTypeData objpayemnt = new PaymentTypeData();
            PaymentTypeBO objpayementBO = new PaymentTypeBO();
            objpayemnt.PaymentType = txtdescription.Text == "" ? null : txtdescription.Text;
            objpayemnt.ActionType = EnumActionType.Select;
            objpayemnt.PageSize = pagesize;
            objpayemnt.CurrentIndex = curIndex;
            return objpayementBO.SearchPaymentTypeDetails(objpayemnt);

        }
        private void clearall()
        {
            txtdescription.Text = "";
            divsearch.Visible = false;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            bindgrid(1);
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
                wb.Worksheets.Add(dt, "Payment Type Type");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= PaymentTypeDetails.xlsx");
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
            List<PaymentTypeData> PaymentTypeDetail = GetPaymentTypeDetails(1, size);
            List<PaymentTypeDataToExcel> paymenttypetoexcel = new List<PaymentTypeDataToExcel>();
            int i = 0;
            foreach (PaymentTypeData row in PaymentTypeDetail)
            {
                PaymentTypeDataToExcel EcxeclStd = new PaymentTypeDataToExcel();
                EcxeclStd.PaymentTypeID = PaymentTypeDetail[i].PaymentTypeID;
                EcxeclStd.PaymentType = PaymentTypeDetail[i].PaymentType;
                paymenttypetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(paymenttypetoexcel);
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
        protected void GvPaymentdetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvPaymentdetails.DataSource = sortedView;
                    GvPaymentdetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvPaymentdetails.HeaderRow.Cells[ColumnIndex];
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

        protected void GvPaymentdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvPaymentdetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
    }
}