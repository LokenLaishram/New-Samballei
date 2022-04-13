using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.BussinessProcess.EduInventory;
using Mobimp.Edusoft.Common;
using System.Globalization;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class IndentListSales : BasePage
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
            }

        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(ddlVendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(ddlVendorType3ID, mstlookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(ddl_PaymentMode, mstlookup.GetLookupsList(LookupNames.PaymentMode));
            ddl_PaymentMode.SelectedValue = "4";
            Commonfunction.PopulateDdl(ddlBankID, mstlookup.GetLookupsList(LookupNames.BankName));
            Commonfunction.PopulateDdl(ddlFinancialYearID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlFinancialYearID.SelectedIndex = 1;
            ddl_ApprovedStatus.SelectedIndex = 1;

            //txt_DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            //txt_DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_FromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_ToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddlBankID.Attributes["disabled"] = "disabled";
            txt_InvoiceNo.ReadOnly = true;
            if (ddl_PaymentMode.SelectedValue == "4")
            {
                txt_ChequeNo.ReadOnly = false;
                ddlBankID.Attributes["disabled"] = "disabled";
            }
            else
            {
                txt_ChequeNo.ReadOnly = true;

                ddlBankID.Attributes.Remove("disabled");
            }
            if (LoginToken.RoleID == 1)
            {
                txtPaidAmt.Attributes.Remove("disabled");
            }
            else
            {
                txtPaidAmt.Attributes["disabled"] = "disabled";
            }
            txt_VendorName.Attributes["disabled"] = "disabled";
            //--Tab-2--//
            ddlVendorTypeID.Attributes["disabled"] = "disabled";
            txtVendorName.Attributes["disabled"] = "disabled";
            txtIndentNo.Attributes["disabled"] = "disabled";
            btnPay.Attributes["disabled"] = "disabled";
            btnPrint.Attributes["disabled"] = "disabled";
            txtinvoiceno.Attributes["disabled"] = "disabled";
            txtTotalIssueQty.Attributes["disabled"] = "disabled";
            txtTotalAmount.Attributes["disabled"] = "disabled";
            txt2DisPercent.Attributes["disabled"] = "disabled";
            txtTotalDiscount.Attributes["disabled"] = "disabled";
            txtNetAmount.Attributes["disabled"] = "disabled";
            txtPayableAmt.Attributes["disabled"] = "disabled";
            
            txtDueAmt.Attributes["disabled"] = "disabled";
            lblpopMessage.Visible = false;
            btnRelease.Attributes["disabled"] = "disabled";
            //--Tab-3--//
            txtVendoName3.Attributes["disabled"] = "disabled";
            //--RELEASE POP UP--//
            ddl2VendorTypeID.Attributes["disabled"] = "disabled";
            txt2VendorName.Attributes["disabled"] = "disabled";
            txtRIndentNo.Attributes["disabled"] = "disabled";
            txt2billno.Attributes["disabled"] = "disabled";
            txt2TotalAvailStk.Attributes["disabled"] = "disabled";
            txtGdTotalApprovedQty.Attributes["disabled"] = "disabled";
            txtGdTotalReleasedQty.Attributes["disabled"] = "disabled";
            txtGdTotalReleasedNowQty.Attributes["disabled"] = "disabled";
            txtRNo.Attributes["disabled"] = "disabled";
        }
        protected void tab1_Click(object sender, EventArgs e)
        {
            tap1();
        }
        protected void tap1()
        {
            //--tab1--//
            //  tab1.Attributes.Remove("class");
            //   tab1.Attributes.Add("class", "active");
            //tabIndentListSales.Attributes.Remove("class");
            //tabIndentListSales.Attributes.Add("class", "product-tab-list tab-pane fade active in");
            //--tab2--//
            //   tab2.Attributes.Remove("class");
            //    tabIndentSaleDetails.Attributes.Remove("class");
            //    tabIndentSaleDetails.Attributes.Add("class", "product-tab-list tab-pane fade");
            //    //--tab3--//
            // //   tab3.Attributes.Remove("class");
            //    tabSaleList.Attributes.Remove("class");
            //    tabSaleList.Attributes.Add("class", "product-tab-list tab-pane fade");
        }
        protected void tab2_Click(object sender, EventArgs e)
        {
            tap2();
        }
        protected void tap2()
        {
            //--tab1--//
            // //  tab1.Attributes.Remove("class");
            //   tabIndentListSales.Attributes.Remove("class");
            //   tabIndentListSales.Attributes.Add("class", "product-tab-list tab-pane fade ");
            //   //--tab2--//
            // //  tab2.Attributes.Remove("class");
            ////   tab2.Attributes.Add("class", "active");
            //   tabIndentSaleDetails.Attributes.Remove("class");
            //   tabIndentSaleDetails.Attributes.Add("class", "product-tab-list tab-pane fade active in");
            //   //--tab3--//
            //  // tab3.Attributes.Remove("class");
            //   tabSaleList.Attributes.Remove("class");
            //   tabSaleList.Attributes.Add("class", "product-tab-list tab-pane fade ");
        }
        protected void tab3_Click(object sender, EventArgs e)
        {
            tap3();
        }
        protected void tap3()
        {
            ////--tab1--//
            //tab1.Attributes.Remove("class");
            //tabIndentListSales.Attributes.Remove("class");
            //tabIndentListSales.Attributes.Add("class", "product-tab-list tab-pane fade in");
            ////--tab2--//
            //tab2.Attributes.Remove("class");
            //tabIndentSaleDetails.Attributes.Remove("class");
            //tabIndentSaleDetails.Attributes.Add("class", "product-tab-list tab-pane fade in");
            ////--tab3--//
            //tab3.Attributes.Remove("class");
            //tab3.Attributes.Add("class", "active");
            //tabSaleList.Attributes.Remove("class");
            //tabSaleList.Attributes.Add("class", "product-tab-list tab-pane fade in active");
        }
        protected void ddl_VendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_VendorTypeID.SelectedIndex > 0)
            {
                txt_VendorName.Text = "";
                txt_VendorName.Attributes.Remove("disabled");
                AutoCompleteExtender1.ContextKey = ddl_VendorTypeID.SelectedValue == "" ? "0" : ddl_VendorTypeID.SelectedValue;
            }
            else
            {
                txt_VendorName.Text = "";
                txt_VendorName.Attributes["disabled"] = "disabled";
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetVendorNameCompletionList(string prefixText, int count, string contextKey)
        {
            StockEntryWithoutPOData ObjData = new StockEntryWithoutPOData();
            StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
            List<StockEntryWithoutPOData> getResult = new List<StockEntryWithoutPOData>();
            ObjData.VendorDetails = prefixText;
            ObjData.VendorTypeID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoVendorName(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].VendorDetails.ToString());
            }
            return list;
        }
        protected void txt_VendorName_TextChanged(object sender, EventArgs e)
        {
            txt_IndentNo.Focus();
        }
        //----END OF COMMON AUTO COMPLETE FOR PULL VENDOR NAME -----//
        protected void ddl_ApprovedStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<IndentSaleData> lstindent = getindentlist(index, pagesize);
            if (lstindent.Count > 0)
            {
                Gv_IndentListSales.PageSize = pagesize;
                string record = lstindent[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstindent[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstindent[0].MaximumRows.ToString();
                lblresult.Visible = true;
                Gv_IndentListSales.VirtualItemCount = lstindent[0].MaximumRows;//total item is required for custom paging
                Gv_IndentListSales.PageIndex = index - 1;
                Gv_IndentListSales.DataSource = lstindent;
                Gv_IndentListSales.DataBind();
                Gv_IndentListSales.Visible = true;
                ds = ConvertToDataSet(lstindent);
                TableCell tableCell = Gv_IndentListSales.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);

                bindresponsive();
            }
            else
            {
                Gv_IndentListSales.DataSource = null;
                Gv_IndentListSales.DataBind();
                lblresult.Visible = false;
                lbl_totalrecords.Visible = false;
            }
        }
        public List<IndentSaleData> getindentlist(int curIndex, int pagesize)
        {
            IndentSaleData objind = new IndentSaleData();
            IndentSaleBO objBO = new IndentSaleBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt_DateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_DateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt_DateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_DateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objind.Datefrom = DateFrom;
            objind.Dateto = DateTo;
            objind.VendorTypeID = Convert.ToInt32(ddl_VendorTypeID.Text == "" ? "0" : ddl_VendorTypeID.Text);
            var Vendor = txt_VendorName.Text.ToString();
            if (Vendor.Contains(":"))
            {
                string VID = Vendor.Substring(Vendor.LastIndexOf(':') + 1);
                objind.VendorID = Convert.ToInt32(VID == "" ? "0" : VID);
            }
            else
            {
                txt_VendorName.Text = "";
                objind.VendorID = 0;
                txt_VendorName.Focus();
            }
            objind.IndentNo = txt_IndentNo.Text == "" ? "0" : txt_IndentNo.Text;
            objind.PageSize = pagesize;
            objind.CurrentIndex = curIndex;
            objind.IsApproved = Convert.ToInt32(ddl_ApprovedStatus.SelectedValue == "" ? "0" : ddl_ApprovedStatus.SelectedValue);

            return objBO.SearchIndentDetailsList(objind);
        }
        protected void Gv_IndentListSales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in Gv_IndentListSales.Rows)
            {
                try
                {
                    Label IsApproved = (Label)Gv_IndentListSales.Rows[row.RowIndex].Cells[0].FindControl("lblIsApproved");
                    Button btn_SalesAppd = (Button)Gv_IndentListSales.Rows[row.RowIndex].Cells[0].FindControl("btn_SalesAppd");
                    Button btn_Sales = (Button)Gv_IndentListSales.Rows[row.RowIndex].Cells[0].FindControl("btn_Sales");
                    Label lblReleaseDone = (Label)Gv_IndentListSales.Rows[row.RowIndex].Cells[0].FindControl("lblReleaseDone");
                    Button btn_release = (Button)Gv_IndentListSales.Rows[row.RowIndex].Cells[0].FindControl("btn_release");
                    Label lblIsReleasedClose = (Label)Gv_IndentListSales.Rows[row.RowIndex].Cells[0].FindControl("lblIsReleasedClose");
                    Button btnReleasedClosed = (Button)Gv_IndentListSales.Rows[row.RowIndex].Cells[0].FindControl("btnReleasedClosed");
                    if (IsApproved.Text == "2") // 1=Not paid ,2= paid
                    {
                        btn_Sales.Visible = false;
                        btn_Sales.Enabled = false;
                        btn_SalesAppd.Visible = true;
                        btn_release.Attributes.Remove("disabled");
                        lblReleaseDone.Visible = false;
                        if(lblIsReleasedClose.Text=="1") // 0=Not Closed ,1= Closed
                        {
                            btn_release.Visible = false;
                            btnReleasedClosed.Visible = true;
                        }
                        else
                        {
                            btn_release.Visible = true;
                            btnReleasedClosed.Visible = false;
                        }
                       
                    }
                    else
                    {
                        btn_Sales.Visible = true;
                        btn_Sales.Enabled = true;
                        btn_SalesAppd.Visible = false;
                        btn_release.Attributes["disabled"] = "disabled";
                        lblReleaseDone.Visible = true;
                        btn_release.Visible = false;
                        btnReleasedClosed.Visible = false;
                    }
                }
                catch (Exception ex) //Exception in agent layer itself
                {
                    PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

                }
            }
        }
        protected void Gv_IndentListSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_IndentListSales.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            if (LoginToken.PrintEnable == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("exportenable") + "')", true);
                return;
            }
            else
            {
                ExportoExcel();
            }
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Company List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Company.xlsx");
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
            List<IndentSaleData> Indentdetail = getindentlist(1, size);
            List<IndentDatatoXL> indenttoexcel = new List<IndentDatatoXL>();
            int i = 0;
            foreach (IndentSaleData row in Indentdetail)
            {
                IndentDatatoXL EcxeclIndent = new IndentDatatoXL();
                EcxeclIndent.ItemID = Indentdetail[i].ItemID;
                EcxeclIndent.ItemCode = Indentdetail[i].ItemCode;
                EcxeclIndent.ItemName = Indentdetail[i].ItemName;
                EcxeclIndent.IndentQty = Indentdetail[i].IndentQty;
                EcxeclIndent.Price = Indentdetail[i].Price;
                EcxeclIndent.TotalPrice = Indentdetail[i].TotalPrice;
                indenttoexcel.Add(EcxeclIndent);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(indenttoexcel);
            return dt;

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
        protected void Gv_IndentListSales_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_IndentListSales.DataSource = sortedView;
                    Gv_IndentListSales.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_IndentListSales.HeaderRow.Cells[ColumnIndex];
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

        protected void Gv_IndentListSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Print")
                {
                    //if (LoginToken.PrintEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                    //    return;
                    //}
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_IndentListSales.Rows[i];
                    Label IndentNo = (Label)gr.Cells[0].FindControl("lblIndentNo");
                    DropDownList CopyTO = (DropDownList)gr.Cells[0].FindControl("GvddlPrintCopy");

                    string IndentNo2 = IndentNo.Text.Trim() == "" ? null : IndentNo.Text.Trim();
                    string PCopy = CopyTO.SelectedItem.Text;
                    string url = "../Indent/Report/Reportviewer.aspx?option=IndentGeneration&IndentNo=" + IndentNo2 + "&PrintCopy=" + PCopy;
                    string fullURL = "window.open('" + url + "', '_blank');";
                    bindresponsive();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
                }

                if (e.CommandName == "Sales")
                {
                    IndentSaleData objdata = new IndentSaleData();
                    IndentSaleBO objbo = new IndentSaleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_IndentListSales.Rows[i];
                    Label lblIndentNo = (Label)gr.Cells[0].FindControl("lblIndentNo");
                    objdata.IndentNo = lblIndentNo.Text.Trim();
                    List<IndentSaleData> lstdataresult = new List<IndentSaleData>();
                    lstdataresult = objbo.GetItemDetailsByIndentNo(objdata);
                    if (lstdataresult.Count > 0)
                    {
                        Gv_IndentSaleList.DataSource = lstdataresult;
                        Gv_IndentSaleList.DataBind();
                        Gv_IndentSaleList.Visible = true;
                        tab2bindresponsive();
                        MasterLookupBO mstlookup = new MasterLookupBO();
                        Commonfunction.PopulateDdl(ddlVendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
                        Commonfunction.PopulateDdl(ddl_PaymentMode, mstlookup.GetLookupsList(LookupNames.PaymentMode));
                        ddl_PaymentMode.SelectedIndex = 1;
                        ddlVendorTypeID.SelectedValue = lstdataresult[0].VendorTypeID.ToString();
                        hdn_VendorID.Value = lstdataresult[0].VendorID.ToString();
                        txtVendorName.Text = lstdataresult[0].VendorName.ToString();
                        txtIndentNo.Text = lstdataresult[0].IndentNo.ToString();
                        txtTotalAmount.Text = lstdataresult[0].GdTotalPrice.ToString();
                        txt2DisPercent.Text = lstdataresult[0].GdDiscount.ToString();
                        txtTotalDiscount.Text = lstdataresult[0].GdDiscountValue.ToString();
                        txtNetAmount.Text = lstdataresult[0].GdNetAmount.ToString();
                        txtPayableAmt.Text = lstdataresult[0].GdNetAmount.ToString();
                        txtDueAmt.Text = lstdataresult[0].GdNetAmount.ToString();
                        if (lstdataresult[0].IsApproved == 1)
                        {
                            btnPay.Attributes.Remove("disabled");
                        }
                        else
                        {
                            btnPay.Attributes["disabled"] = "disabled";
                        }
                        TotalCalculate();

                        if (ddl_PaymentMode.SelectedValue == "4")
                        {
                            txt_ChequeNo.ReadOnly = false;
                            // txt_BankName.ReadOnly = false;
                            ddlBankID.Attributes.Remove("disabled");
                        }
                        else
                        {
                            txt_ChequeNo.ReadOnly = true;

                            ddlBankID.Attributes.Remove("disabled");
                        }
                        tap2();
                        this.ModalPopupExtender4.Show();
                    }
                    else
                    {
                        Gv_IndentSaleList.DataSource = null;
                        Gv_IndentSaleList.DataBind();
                        Gv_IndentSaleList.Visible = false;
                    }
                }
                if (e.CommandName == "Release")
                {

                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_IndentListSales.Rows[i];
                    Label lblSaleBillNo = (Label)gr.Cells[0].FindControl("lblSaleBillNo");

                    if (lblSaleBillNo.Text == "")
                    {
                        lblpopMessage.Text = "Bill No. cannot be blank.";
                        lblpopMessage.Visible = true;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Bill No.cannot be blank.") + "')", true);
                        return;

                    }
                    else
                    {
                        lblRpopMessage.Visible = false;
                        string billno = lblSaleBillNo.Text.Trim();
                        this.ModalPopupExtender4.Hide();
                        GetPaymentDetails(billno);
                        this.ModalPopupExtender1.Show();
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
        protected void ddlpaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_PaymentMode.SelectedIndex > 0)
            {
                if (ddl_PaymentMode.SelectedValue == "1")
                {
                    //txt_BankName.Text = "";
                    //txt_BankName.ReadOnly = true;
                    ddlBankID.SelectedIndex = 0;
                    ddlBankID.Attributes["disabled"] = "disabled";
                    txt_ChequeNo.ReadOnly = true;
                    txt_InvoiceNo.ReadOnly = true;
                }
                else if (ddl_PaymentMode.SelectedValue == "2")
                {
                    //  GetBankName(Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue));
                    //txt_BankName.ReadOnly = true;
                    ddlBankID.Attributes["disabled"] = "disabled";
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = false;
                }
                else if (ddl_PaymentMode.SelectedValue == "3")
                {
                    // GetBankName(Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue));
                    // txt_BankName.ReadOnly = true;
                    ddlBankID.Attributes["disabled"] = "disabled";
                    txt_InvoiceNo.Text = "";
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = true;
                }
                else if (ddl_PaymentMode.SelectedValue == "4")
                {
                    // txt_BankName.Text = "";
                    //txt_BankName.ReadOnly = false;
                    ddlBankID.SelectedIndex = 0;
                    ddlBankID.Attributes.Remove("disabled");
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = true;
                }
            }
            else
            {
                //txt_BankName.Text = "";
                //txt_BankName.ReadOnly = true;
                ddlBankID.SelectedIndex = 0;
                ddlBankID.Attributes["disabled"] = "disabled";
                txt_ChequeNo.ReadOnly = true;
                txt_InvoiceNo.ReadOnly = true;
            }
        }
        protected void txt_IssueQty_TextChanged(Object sender, EventArgs e)
        {
            TotalCalculate();
        }
        public void TotalCalculate()
        {
            int TotalQty = 0;
            decimal TotalAmount = 0;
            foreach (GridViewRow row in Gv_IndentSaleList.Rows)
            {
                Label AvailQty = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblAvailableQty");
                Label lblprice = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblPrice");
                TextBox IssueQty = (TextBox)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("txt_IssueQty");
                Label lblTotalPrice = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblTotalPrice");
                //if (Convert.ToInt32(AvailQty.Text ==""?"0": AvailQty.Text) >= Convert.ToInt32(IssueQty.Text == "" ? "0" : IssueQty.Text))
                //{
                lblTotalPrice.Text = (Convert.ToDecimal(lblprice.Text == "" ? "0" : lblprice.Text) * Convert.ToDecimal(IssueQty.Text == "" ? "0" : IssueQty.Text)).ToString("N");
                TotalQty = TotalQty + (Convert.ToInt32(IssueQty.Text == "" ? "0" : IssueQty.Text));
                TotalAmount = TotalAmount + (Convert.ToDecimal(lblTotalPrice.Text == "" ? "0" : lblTotalPrice.Text));

                //}
                //else
                //{
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Issue quantity is greater than available quantity.") + "')", true);
                //return;
                //}
            }

            txtTotalIssueQty.Text = Commonfunction.Getrounding(TotalQty.ToString());
            txtTotalAmount.Text = Commonfunction.Getrounding(TotalAmount.ToString());
            decimal DisValue = Convert.ToDecimal(txtTotalDiscount.Text == "" ? "0" : txtTotalDiscount.Text);
            decimal NetAmt = (TotalAmount - DisValue);
            txtNetAmount.Text = Commonfunction.Getrounding(NetAmt.ToString());
            txtTax.Text = "";
            txtPayableAmt.Text = Commonfunction.Getrounding(NetAmt.ToString());
            txtPaidAmt.Text = Commonfunction.Getrounding(NetAmt.ToString());
            txtDueAmt.Text = "0";
            tab2bindresponsive();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                //if (LoginToken.UpdateEnable == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("updateenable") + "')", true);
                //    return;
                //}
                if (txtBankDate.Text == "")
                {
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Chalan date.") + "')", true);
                    lblpopMessage.Text = "Please enter chalan date.";
                    lblpopMessage.Visible = true;
                    txtBankDate.Focus();
                    return;
                }
                else
                {
                    if (Commonfunction.isValidDate(txtBankDate.Text) == true)
                    {
                        // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Chalan date you select is future date. Please select valid date.") + "')", true);
                        //lblpopMessage.Text = "Please enter valid date.";
                        //lblpopMessage.Visible = true;
                        //txtBankDate.Focus();
                        //return;
                    }
                }
                if (ddl_PaymentMode.SelectedValue == "2")
                {
                    if (txt_ChequeNo.Text == "")
                    {
                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter name of the bank") + "')", true);
                        lblpopMessage.Text = "Please enter payment mode.";
                        lblpopMessage.Visible = true;
                        txt_ChequeNo.Focus();
                        return;
                    }
                    if (txt_InvoiceNo.Text == "")
                    {
                        // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter payment invoice number.") + "')", true);
                        lblpopMessage.Text = "Please enter payment invoice number.";
                        txt_InvoiceNo.Focus();
                        return;
                    }
                }
                if (ddl_PaymentMode.SelectedValue == "3")
                {
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter payment chalan no. / Cheque no") + "')", true);
                    lblpopMessage.Text = "Please enter payment mode.";
                    lblpopMessage.Visible = true;
                    txt_ChequeNo.Focus();
                    return;
                }
                if (ddl_PaymentMode.SelectedValue == "4")
                {
                    if (ddlBankID.SelectedIndex == 0)
                    {
                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter name of the bank") + "')", true);
                        lblpopMessage.Text = "Please enter name of the bank.";
                        lblpopMessage.Visible = true;
                        ddlBankID.Focus();
                        return;
                    }
                    if (txt_ChequeNo.Text == "")
                    {
                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter payment chalan no. / Cheque no") + "')", true);
                        lblpopMessage.Text = "Please enter payment chalan no. / Cheque no.";
                        lblpopMessage.Visible = true;
                        txt_ChequeNo.Focus();
                        return;
                    }
                }

                List<IndentSaleData> list = new List<IndentSaleData>();
                IndentSaleBO saleBO = new IndentSaleBO();
                IndentSaleData obj = new IndentSaleData();
                List<IndentSaleData> Resultlist = new List<IndentSaleData>();
                foreach (GridViewRow row in Gv_IndentSaleList.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label lblItemID = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblItemID");
                    Label lblPrice = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblPrice");
                    Label lblAvailableQty = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblAvailableQty");
                    TextBox lblIssueQty = (TextBox)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("txt_IssueQty");
                    Label lblTotalPrice = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblTotalPrice");
                    Label lblStkNo2 = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lblStkNo2");
                    Label lbl2BatchYearID = (Label)Gv_IndentSaleList.Rows[row.RowIndex].Cells[0].FindControl("lbl2BatchYearID");

                    IndentSaleData ObjDetails = new IndentSaleData();
                    ObjDetails.ItemID = Convert.ToInt32(lblItemID.Text == "" ? "0" : lblItemID.Text);
                    ObjDetails.Price = Convert.ToDecimal(lblPrice.Text == "" ? "0" : lblPrice.Text);
                    ObjDetails.AvailableQty = Convert.ToInt32(lblAvailableQty.Text == "" ? "0" : lblAvailableQty.Text);
                    ObjDetails.IssueQty = Convert.ToInt32(lblIssueQty.Text == "" ? "0" : lblIssueQty.Text);
                    ObjDetails.TotalPrice = Convert.ToDecimal(lblTotalPrice.Text == "" ? "0" : lblTotalPrice.Text);
                    ObjDetails.StockNo = lblStkNo2.Text == "" ? "0" : lblStkNo2.Text;
                    ObjDetails.BatchYearID = Convert.ToInt32(lbl2BatchYearID.Text == "" ? "0" : lbl2BatchYearID.Text);
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.IndentSaleListtoXML(list).ToString();
                obj.VendorTypeID = Convert.ToInt32(ddlVendorTypeID.SelectedValue == "" ? "0" : ddlVendorTypeID.SelectedValue);

                int Vendor = Convert.ToInt32(hdn_VendorID.Value == "" ? "0" : hdn_VendorID.Value);
                if (ddlVendorTypeID.SelectedValue == "3")
                {
                    obj.VendorID = 0;
                    obj.VendorName = txtVendorName.Text == "" ? "" : txtVendorName.Text;
                }
                else
                {
                    if (Vendor == 0)
                    {
                        txtVendorName.Text = "";
                        txtVendorName.Focus();
                        lblpopMessage.Text = "Please select vendor name cannot be empty.";
                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor name cannot be empty.") + "')", true);
                        return;
                    }
                    else
                    {
                        obj.VendorID = Convert.ToInt32(hdn_VendorID.Value == "" ? "0" : hdn_VendorID.Value);
                        obj.VendorName = txtVendorName.Text == "" ? "" : txtVendorName.Text;
                    }
                }
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime DateTo = txtBankDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtBankDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                obj.BankPaymentDate = DateTo;
                obj.IndentNo = txtIndentNo.Text == "" ? "0" : txtIndentNo.Text;
                obj.TotalIssueQty = Convert.ToInt32(txtTotalIssueQty.Text == "" ? "0" : txtTotalIssueQty.Text);
                obj.GdTotalAmount = Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text);
                obj.GdDiscount = Convert.ToDecimal(txt2DisPercent.Text == "" ? "0" : txt2DisPercent.Text);
                obj.GdDiscountValue = Convert.ToDecimal(txtTotalDiscount.Text == "" ? "0" : txtTotalDiscount.Text);
                obj.GdNetAmount = Convert.ToDecimal(txtNetAmount.Text == "" ? "0" : txtNetAmount.Text);
                obj.Gdtax = Convert.ToDecimal(txtTax.Text == "" ? "0" : txtTax.Text);
                obj.GdPayable = Convert.ToDecimal(txtPayableAmt.Text == "" ? "0" : txtPayableAmt.Text);
                obj.GdPaid = Convert.ToDecimal(txtPaidAmt.Text == "" ? "0" : txtPaidAmt.Text);
                obj.GdDue = Convert.ToDecimal(txtDueAmt.Text == "" ? "0" : txtDueAmt.Text);
                obj.PaymentModeID = Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue);
                obj.BankID = Convert.ToInt32(ddlBankID.SelectedValue == "" ? "0" : ddlBankID.SelectedValue);
                obj.BankName = ddlBankID.SelectedItem.ToString();
                obj.Invoice = txt_InvoiceNo.Text == "" ? "" : txt_InvoiceNo.Text;
                obj.ChequeNo = txt_ChequeNo.Text == "" ? "" : txt_ChequeNo.Text;
                obj.Remark = txtRemark.Text == "" ? "" : txtRemark.Text;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                Resultlist = saleBO.SaveIndentSalePayment(obj);
                if (Resultlist.Count > 0)
                {
                    txtinvoiceno.Text = Resultlist[0].SaleNo.ToString();
                    btnPay.Attributes["disabled"] = "disabled";
                    btn_Print.Attributes.Remove("disabled");
                    Session["TransactionList"] = null;
                    lblpopMessage.Text = "Save sucessfully.";
                    btnRelease.Attributes.Remove("disabled");
                    // this.ModalPopupExtender1.Show();
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnPay.Attributes.Remove("disabled");
                    btn_Print.Attributes["disabled"] = "disabled";
                    lblpopMessage.Text = "System Error.";
                    this.ModalPopupExtender4.Show();
                    btnRelease.Attributes["disabled"] = "disabled";
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("System Error.") + "')", true);
                }
            }
            catch (Exception ex)

            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblpopMessage.Text = "System Error.";
                // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void Print_OnClick(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    lblpopMessage.Text = "You don't have right to print.";
            //    bindresponsive();
            //    return;
            //}
            string InvoiceNo = HttpUtility.UrlEncode(UrlEncryptDecrypt.Encrypt(txtinvoiceno.Text.Trim()));
            string url = "../Sales/Reports/Reportviewer.aspx?option=PaymentReceipt&InvoiceNo=" + InvoiceNo;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetVendorNameCompletionList2(string prefixText, int count, string contextKey)
        {
            StockEntryWithoutPOData ObjData = new StockEntryWithoutPOData();
            StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
            List<StockEntryWithoutPOData> getResult = new List<StockEntryWithoutPOData>();
            ObjData.VendorDetails = prefixText;
            ObjData.VendorTypeID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoVendorName(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].VendorDetails.ToString());
            }
            return list;
        }
        protected void btn3Print_OnClick(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    bindresponsive();
            //    return;
            //}
            var Vendor = txtVendoName3.Text.ToString();
            int VdorID = 0;
            if (Vendor.Contains(":"))
            {
                string VdID = Vendor.Substring(Vendor.LastIndexOf(':') + 1);
                VdorID = Convert.ToInt32(VdID == "" ? "0" : VdID);
            }

            int FYearID = Convert.ToInt32(ddlFinancialYearID.SelectedValue == "" ? "0" : ddlFinancialYearID.SelectedValue);
            int VendorTypeID = Convert.ToInt32(ddlVendorType3ID.SelectedValue == "" ? "0" : ddlVendorType3ID.SelectedValue);

            string BillNo = txtBillNo.Text.Trim() == "" ? null : txtBillNo.Text.Trim();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            //DateTime pDateFrom = txt_FromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_FromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //DateTime pDateTo = txt_ToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_ToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            string pDateFrom = txt_FromDate.Text;
            string pDateTo = txt_ToDate.Text;

            Boolean Status = ddlStatus.SelectedValue == "1" ? true : false;
            string url = "../EduInventory/Reports/Reportviewer.aspx?option=PaymentList&FYearID=" + FYearID + "&VendorTypeID=" + VendorTypeID + "&VendorID=" + VdorID + "&FromDate=" + pDateFrom + "&ToDate=" + pDateTo + "&BillNo=" + BillNo + "&Status=" + Status;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        protected void Reset()
        {
            ddl_VendorTypeID.SelectedIndex = 0;
            hdn_VendorID.Value = "";
            txt_VendorName.Text = "";
            txt_IndentNo.Text = "";
            txt_DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddl_ApprovedStatus.SelectedIndex = 0;
            Gv_IndentListSales.DataSource = null;
            Gv_IndentListSales.DataBind();
            Gv_IndentListSales.Visible = false;

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            Reset2();
        }
        protected void Reset2()
        {
            ddlVendorTypeID.SelectedIndex = 0;
            hdn_VendorID.Value = "";
            txtVendorName.Text = "";
            txtIndentNo.Text = "";
            Gv_IndentSaleList.DataSource = null;
            Gv_IndentSaleList.DataBind();
            Gv_IndentSaleList.Visible = false;
            txtTotalAmount.Text = "";
            txt2DisPercent.Text = "";
            txtTotalDiscount.Text = "";
            txtNetAmount.Text = "";
            txtTax.Text = "";
            txtPayableAmt.Text = "";
            txtPaidAmt.Text = "";
            txtDueAmt.Text = "";
            ddl_PaymentMode.SelectedIndex = 0;
            ddlBankID.SelectedIndex = 0;
            txt_InvoiceNo.Text = "";
            txt_ChequeNo.Text = "";
            txtRemark.Text = "";
            txtinvoiceno.Text = "";
            // Response.Redirect("IndentListSales.aspx", false);
        }
        //--TAB3--//
        protected void ddlVendorType3ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVendorType3ID.SelectedIndex > 0)
            {
                txtVendoName3.Attributes.Remove("disabled");
                AutoCompleteExtender3.ContextKey = ddlVendorType3ID.SelectedValue == "" ? "0" : ddlVendorType3ID.SelectedValue;
            }
            else
            {
                txtVendoName3.Attributes["disabled"] = "disabled";
            }
        }
        protected void btnSearch3_Click(object sender, EventArgs e)
        {
            bindgrid3(1);
        }
        private void bindgrid3(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<IndentSaleData> lstsale = getSalelist(index, pagesize);
            if (lstsale.Count > 0)
            {
                Gv_SaleLists.PageSize = pagesize;
                string record = lstsale[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstsale[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstsale[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gv_SaleLists.VirtualItemCount = lstsale[0].MaximumRows;//total item is required for custom paging
                Gv_SaleLists.PageIndex = index - 1;
                Gv_SaleLists.DataSource = lstsale;
                Gv_SaleLists.DataBind();
                tab3bindresponsive();
            }
            else
            {
                Gv_SaleLists.DataSource = null;
                Gv_SaleLists.DataBind();
            }
        }
        public List<IndentSaleData> getSalelist(int curIndex, int pagesize)
        {
            IndentSaleData objind = new IndentSaleData();
            IndentSaleBO objBO = new IndentSaleBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt_FromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_FromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt_ToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_ToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objind.Datefrom = DateFrom;
            objind.Dateto = DateTo;
            objind.AcademicSessionID = Convert.ToInt32(ddlFinancialYearID.Text == "" ? "0" : ddlFinancialYearID.Text);
            objind.VendorTypeID = Convert.ToInt32(ddlVendorType3ID.Text == "" ? "0" : ddlVendorType3ID.Text);
            var Vendor = txtVendoName3.Text.ToString();
            if (Vendor.Contains(":"))
            {
                string VID = Vendor.Substring(Vendor.LastIndexOf(':') + 1);
                objind.VendorID = Convert.ToInt32(VID == "" ? "0" : VID);
            }
            else
            {
                txtVendoName3.Text = "";
                objind.VendorID = 0;
                txtVendoName3.Focus();
            }
            objind.BillNo = txtBillNo.Text == "" ? "0" : txtBillNo.Text;
            objind.PageSize = pagesize;
            objind.CurrentIndex = curIndex;
            objind.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            return objBO.SearchSaleDetailsList(objind);
        }
        protected void GVSaleList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    IndentSaleData objdata = new IndentSaleData();
                    IndentSaleBO objbo = new IndentSaleBO();
                    Label lblBillNo = (Label)e.Row.FindControl("lblBillNo");
                    objdata.BillNo = lblBillNo.Text.Trim();
                    List<IndentSaleData> GetResult = objbo.SearchChildBillDetails(objdata);
                    if (GetResult.Count > 0)
                    {
                        GridView SC = (GridView)e.Row.FindControl("GridChildIndent");
                        SC.DataSource = GetResult;
                        SC.DataBind();
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
        protected void Gv_SaleLists_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Print")
                {
                    if (LoginToken.PrintEnable == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                        tab3bindresponsive();
                        return;
                    }
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_SaleLists.Rows[i];
                    Label lblBillNo = (Label)gr.Cells[0].FindControl("lblBillNo");

                    //string InvoiceNo = lblBillNo.Text.Trim() == "" ? null : lblBillNo.Text.Trim();
                    string InvoiceNo = HttpUtility.UrlEncode(UrlEncryptDecrypt.Encrypt(lblBillNo.Text.Trim()));
                    string url = "../Sales/Reports/Reportviewer.aspx?option=PaymentReceipt&InvoiceNo=" + InvoiceNo;
                    string fullURL = "window.open('" + url + "', '_blank');";
                    tab3bindresponsive();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
                }

                if (e.CommandName == "Deletes")
                {
                    if (LoginToken.DeleteEnable == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                        return;
                    }
                    IndentSaleData obj = new IndentSaleData();
                    IndentSaleBO objBO = new IndentSaleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_SaleLists.Rows[i];
                    Label lblBillNo = (Label)gr.Cells[0].FindControl("lblBillNo");
                    obj.BillNo = lblBillNo.Text.Trim();
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        obj.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    obj.EmployeeID = LoginToken.EmployeeID;
                    int Result = objBO.DeleteSaleByBillNo(obj);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid3(1);
                    }
                    else if (Result == 2)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("The bill no. cannot be delete, the stock have already released.") + "')", true);
                        bindgrid3(1);
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
        protected void Gv_IndentGen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_SaleLists.PageIndex = e.NewPageIndex;
            bindgrid3(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btn3reset_Click(object sender, EventArgs e)
        {
            Reset3();
        }
        protected void Reset3()
        {
            ddlFinancialYearID.SelectedIndex = 0;
            ddlVendorType3ID.SelectedIndex = 0;
            txtVendoName3.Text = "";
            txtBillNo.Text = "";
            //txt_FromDate.Text = "";
            //txt_ToDate.Text = "";
            Gv_SaleLists.DataSource = null;
            Gv_SaleLists.DataBind();
            Gv_SaleLists.Visible = false;

        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_IndentListSales.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_IndentListSales.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_IndentListSales.UseAccessibleHeader = true;
            Gv_IndentListSales.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void tab2bindresponsive()
        {
            //Responsive 
            Gv_IndentSaleList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_IndentSaleList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_IndentSaleList.UseAccessibleHeader = true;
            Gv_IndentSaleList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void tab3bindresponsive()
        {
            //Responsive 
            Gv_SaleLists.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_SaleLists.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_SaleLists.UseAccessibleHeader = true;
            Gv_SaleLists.HeaderRow.TableSection = TableRowSection.TableHeader;
        }


        //---------------STOCK RELEASED---------//
        protected void btnSaleClose_OnClick(object sender, EventArgs e)
        {
            this.ModalPopupExtender4.Hide();
        }
        protected void btnRClose_OnClick(object sender, EventArgs e)
        {
            this.ModalPopupExtender1.Hide();
        }

        protected void btnShowReleasedWindow(object sender, EventArgs e)
        {
            ShowReleasedPopUpWindow();
        }
        protected void ShowReleasedPopUpWindow()
        {
            if (txtinvoiceno.Text == "")
            {
                lblpopMessage.Text = "Bill No. cannot be blank.";
                lblpopMessage.Visible = true;
            }
            else
            {
                lblRpopMessage.Visible = false;
                string billno = txtinvoiceno.Text.Trim();
                this.ModalPopupExtender4.Hide();
                GetPaymentDetails(billno);
                this.ModalPopupExtender1.Show();
            }
        }
        protected void GetPaymentDetails(string billno)
        {
            IndentSaleData objdata = new IndentSaleData();
            StockReleasedBO objbo = new StockReleasedBO();

            objdata.BillNo = billno.Trim();
            txtRNo.Text = "";
            List<IndentSaleData> lstdataresult = new List<IndentSaleData>();
            lstdataresult = objbo.GetItemDetailsByBillNo(objdata);
            if (lstdataresult.Count > 0)
            {
                this.ModalPopupExtender4.Hide();
                Gv_StockReleasedList.DataSource = lstdataresult;
                Gv_StockReleasedList.DataBind();
                Gv_StockReleasedList.Visible = true;
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl2VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));

                ddl2VendorTypeID.SelectedValue = lstdataresult[0].VendorTypeID.ToString();
                hdn2VendorID.Value = lstdataresult[0].VendorID.ToString();
                txt2VendorName.Text = lstdataresult[0].VendorName.ToString();
                txtRIndentNo.Text = lstdataresult[0].IndentNo.ToString();
                txt2billno.Text = lstdataresult[0].BillNo.ToString();
                txtGdTotalApprovedQty.Text = lstdataresult[0].NetApprovedQty.ToString();
                txtGdTotalReleasedQty.Text = lstdataresult[0].NetReleasedQty.ToString();
                txtGdTotalReleasedNowQty.Text = lstdataresult[0].NetDueRelease.ToString();

                if (lstdataresult[0].IsReleasedClosed == 1)
                {
                    btnReleased.Attributes["disabled"] = "disabled";
                }
                else
                {
                    btnReleased.Attributes.Remove("disabled");
                }
                ReleasedTotalCalculate();
                // tabReleasedbindresponsive();

                // this.ModalPopupExtender1.Show();
            }
            else
            {
                Gv_StockReleasedList.DataSource = null;
                Gv_StockReleasedList.DataBind();
                Gv_StockReleasedList.Visible = false;

            }
            //this.ModalPopupExtender1.Show();
        }
        protected void OnQty_TextChanged(object sender, EventArgs e)
        {
            ReleasedTotalCalculate();
            this.ModalPopupExtender4.Hide();
            this.ModalPopupExtender1.Show();
        }
        public void ReleasedTotalCalculate()
        {
            int RTotalQty = 0;
            int TotAvailStk = 0;
            foreach (GridViewRow row in Gv_StockReleasedList.Rows)
            {
                Label lblAvailableQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRAvailableQty");
                Label lblDueRQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRDueRQty");
                TextBox txtDueQty = (TextBox)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("txtRDueQty");
                Label lblitemStatusID = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRitemStatusID");
                Label lblitemStatusName = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRitemStatusName");

                TotAvailStk = TotAvailStk + Convert.ToInt32(lblAvailableQty.Text == "" ? "0" : lblAvailableQty.Text);
                int lblQty = Convert.ToInt32(lblDueRQty.Text == "" ? "0" : lblDueRQty.Text);
                int txtQty = Convert.ToInt32(txtDueQty.Text == "" ? "0" : txtDueQty.Text);
                if (lblQty >= txtQty)
                {
                    RTotalQty = RTotalQty + (Convert.ToInt32(txtDueQty.Text == "" ? "0" : txtDueQty.Text));
                }
                else
                {
                    RTotalQty = RTotalQty + (Convert.ToInt32(lblDueRQty.Text == "" ? "0" : lblDueRQty.Text));
                    txtDueQty.Text = lblQty.ToString();
                    txtDueQty.Focus();
                    lblRpopMessage.Text = "Enter quantity is greater than approved quantity.";
                    lblRpopMessage.Visible = true;
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Enter quantity is greater than approved quantity.") + "')", true);
                }
                if (Convert.ToInt32(lblitemStatusID.Text == "" ? "0" : lblitemStatusID.Text) == 1)
                {
                    // lblitemStatusName.ForeColor = Color.Red;
                    txtDueQty.Attributes["disabled"] = "disabled";
                }
                else
                {
                    // lblitemStatusName.ForeColor = Color.Green;
                    txtDueQty.Attributes.Remove("disables");
                }

            }
            txt2TotalAvailStk.Text = Commonfunction.Getrounding(TotAvailStk.ToString());
            txtGdTotalReleasedNowQty.Text = Commonfunction.Getrounding(RTotalQty.ToString());

            //this.ModalPopupExtender4.Hide();
            //this.ModalPopupExtender1.Show();
        }
        protected void btnReleased_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (LoginToken.UpdateEnable == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("updateenable") + "')", true);
                    return;
                }
                List<IndentSaleData> list = new List<IndentSaleData>();
                StockReleasedBO objBO = new StockReleasedBO();
                IndentSaleData obj = new IndentSaleData();
                List<IndentSaleData> Resultlist = new List<IndentSaleData>();
                foreach (GridViewRow row in Gv_StockReleasedList.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ItemID = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRItemID");
                    Label AvailableQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRAvailableQty");
                    Label ApprovedQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRApprovedQty");
                    Label TotalReleasedQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblRTotalReleasedQty");
                    TextBox DueReleasedQty = (TextBox)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("txtRDueQty");
                    Label StockNo = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lbl2RStockNo");
                    Label BatchYearID = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lbl2RBatchYearID");


                    IndentSaleData ObjDetails = new IndentSaleData();
                    ObjDetails.ItemID = Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text);
                    ObjDetails.AvailableQty = Convert.ToInt32(AvailableQty.Text == "" ? "0" : AvailableQty.Text);
                    ObjDetails.NetApprovedQty = Convert.ToInt32(ApprovedQty.Text == "" ? "0" : ApprovedQty.Text);
                    ObjDetails.TotalReleasedQty = Convert.ToInt32(TotalReleasedQty.Text == "" ? "0" : TotalReleasedQty.Text);
                    ObjDetails.NetDueRelease = Convert.ToInt32(DueReleasedQty.Text == "" ? "0" : DueReleasedQty.Text);
                    ObjDetails.StockNo = StockNo.Text == "" ? "0" : StockNo.Text;
                    ObjDetails.BatchYearID = Convert.ToInt32(BatchYearID.Text == "" ? "0" : BatchYearID.Text);
                    list.Add(ObjDetails);
                }
                obj.VendorTypeID = Convert.ToInt32(ddl2VendorTypeID.SelectedValue == "" ? "0" : ddl2VendorTypeID.SelectedValue);
                int Vendor = Convert.ToInt32(hdn2VendorID.Value == "" ? "0" : hdn2VendorID.Value);

                if (ddl2VendorTypeID.SelectedValue == "3")
                {
                    obj.VendorID = 0;
                    obj.VendorName = txt2VendorName.Text == "" ? "" : txt2VendorName.Text;
                }
                else
                {
                    if (Vendor == 0)
                    {
                        txtVendorName.Text = "";
                        txtVendorName.Focus();
                        lblRpopMessage.Text = "Book Store name cannot be blank.";
                        lblRpopMessage.Visible = true;
                        // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor name cannot be empty.") + "')", true);
                        return;
                    }
                    else
                    {
                        obj.VendorID = Convert.ToInt32(hdn2VendorID.Value == "" ? "0" : hdn2VendorID.Value);
                        obj.VendorName = txt2VendorName.Text == "" ? "" : txt2VendorName.Text;
                    }
                }
                obj.IndentNo = txtIndentNo.Text == "" ? "0" : txtIndentNo.Text;
                obj.BillNo = txt2billno.Text == "" ? "0" : txt2billno.Text;
                obj.GdTotalApprovedQty = Convert.ToInt32(txtGdTotalApprovedQty.Text == "" ? "0" : txtGdTotalApprovedQty.Text);
                obj.GdTotalReleasedQty = Convert.ToInt32(txtGdTotalReleasedQty.Text == "" ? "0" : txtGdTotalReleasedQty.Text);
                obj.GdTotalReleasedNow = Convert.ToInt32(txtGdTotalReleasedNowQty.Text == "" ? "0" : txtGdTotalReleasedNowQty.Text);
                if (Convert.ToInt32(txtGdTotalReleasedNowQty.Text == "" ? "0" : txtGdTotalReleasedNowQty.Text) > Convert.ToInt32(txt2TotalAvailStk.Text == "" ? "0" : txt2TotalAvailStk.Text))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Total Indent quantity is greatrer than available stock. Please check the enter quantity.") + "')", true);
                    lblRpopMessage.Text = "Total Indent quantity is greatrer than available stock. Please check the enter quantity.";
                    lblRpopMessage.Visible = true;
                    return;
                }
                if (Convert.ToInt32(txtGdTotalReleasedNowQty.Text == "" ? "0" : txtGdTotalReleasedNowQty.Text) > Convert.ToInt32(txtGdTotalApprovedQty.Text == "" ? "0" : txtGdTotalApprovedQty.Text))
                {
                    lblRpopMessage.Text = "Approved quantity is greatrer than approved quantity.Please check the enter quantity.";
                    lblRpopMessage.Visible = true;
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Approved quantity is greatrer than approved quantity.Please check the enter quantity.") + "')", true);
                    return;
                }

                obj.Remark = ""; //txtRemark.Text == "" ? "" : txtRemark.Text;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                Resultlist = objBO.SaveStockReleasedDetails(obj);
                if (Resultlist.Count > 0)
                {
                    txtRNo.Text = Resultlist[0].ReleasedNo.ToString();
                    btnReleased.Attributes["disabled"] = "disabled";
                    btn_Print.Attributes.Remove("disabled");
                    lblRpopMessage.Text = "Save Successfully.";
                    lblRpopMessage.Visible = true;
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnReleased.Attributes.Remove("disabled");
                    btn_Print.Attributes["disabled"] = "disabled";
                    btn_Print.Attributes.Remove("disabled");
                    lblRpopMessage.Text = "System Error.";
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("System Error.") + "')", true);
                }
            }
            catch (Exception ex)

            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btn2print_OnClick(object sender, EventArgs e)
        {

            if (LoginToken.PrintEnable == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                tabReleasedbindresponsive();
                return;
            }

            string RNo = txtRNo.Text.Trim() == "" ? null : txtRNo.Text.Trim();
            string ReleasedNo = HttpUtility.UrlEncode(UrlEncryptDecrypt.Encrypt(RNo.Trim()));
            string url = "../Sales/Reports/Reportviewer.aspx?option=StockReleasedReceipt&ReleasedNo=" + ReleasedNo;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            tabReleasedbindresponsive();
        }
        protected void tabReleasedbindresponsive()
        {
            //Responsive 
            Gv_StockReleasedList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_StockReleasedList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_StockReleasedList.UseAccessibleHeader = true;
            Gv_StockReleasedList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}