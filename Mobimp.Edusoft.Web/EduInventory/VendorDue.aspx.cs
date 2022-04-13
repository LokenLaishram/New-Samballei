using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.BussinessProcess.EduInventory;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class VendorDue : BasePage
    {
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
            Commonfunction.PopulateDdl(ddl_FinancialYearID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddl_FinancialYearID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddl_VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(ddl3FinancialYear, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddl3FinancialYear.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlvendortype3ID, mstlookup.GetLookupsList(LookupNames.VendorType));
            txt_DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt3DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt3DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_VendorName.Attributes["disabled"] = "disabled";
            txtTotalBill.Attributes["disabled"] = "disabled";
            txtDiscount.Attributes["disabled"] = "disabled";
            txtNetAmount.Attributes["disabled"] = "disabled";
            txtpayable.Attributes["disabled"] = "disabled";
            txtTotalpaid.Attributes["disabled"] = "disabled";
            txtTotalDue.Attributes["disabled"] = "disabled";
            //---TAB2---//
            ddlVendorType2.Attributes["disabled"] = "disabled";
            txtVendorName2.Attributes["disabled"] = "disabled";
            txtBillNo2.Attributes["disabled"] = "disabled";
            txtTotalDuePaid.Attributes["disabled"] = "disabled";
            txtDueBalance.Attributes["disabled"] = "disabled";
            txtDuePayable.Attributes["disabled"] = "disabled";
            DueBalance.Attributes["disabled"] = "disabled";
            txtDuePayable.Attributes["disabled"] = "disabled";
            txt_BankName.ReadOnly = true;
            txt_BankName.ReadOnly = true;
            txt_ChequeNo.ReadOnly = true;
            txt_InvoiceNo.ReadOnly = true;
            //---TAB3---//
            txt3VendorName.Attributes["disabled"] = "disabled";
        }
        //--TAB1--//
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<VendorDueData> lstsale = getSalelist(index, pagesize);
            if (lstsale.Count > 0)
            {
                Gv_DueList.PageSize = pagesize;
                string record = lstsale[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstsale[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstsale[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gv_DueList.VirtualItemCount = lstsale[0].MaximumRows;//total item is required for custom paging
                Gv_DueList.PageIndex = index - 1;
                Gv_DueList.DataSource = lstsale;
                Gv_DueList.DataBind();
                Gv_DueList.Visible = true;
                bindresponsive();
            }
            else
            {
                Gv_DueList.DataSource = null;
                Gv_DueList.DataBind();
            }
        }
        public List<VendorDueData> getSalelist(int curIndex, int pagesize)
        {
            VendorDueData objind = new VendorDueData();
            VendorDueBO objBO = new VendorDueBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt_DateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_DateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt_DateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_DateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objind.Datefrom = DateFrom;
            objind.Dateto = DateTo;
            objind.AcademicSessionID = Convert.ToInt32(ddl_FinancialYearID.Text == "" ? "0" : ddl_FinancialYearID.Text);
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
            objind.BillNo = txt_BillNo.Text == "" ? "0" : txt_BillNo.Text;
            objind.PageSize = pagesize;
            objind.CurrentIndex = curIndex;
            objind.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            return objBO.SearchSaleDetailsList(objind);
        }
        protected void Gv_DueList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    VendorDueData objdata = new VendorDueData();
                    VendorDueBO objbo = new VendorDueBO();
                    Label lblBillNo = (Label)e.Row.FindControl("lblBillNo");
                    objdata.BillNo = lblBillNo.Text.Trim();
                    List<VendorDueData> GetResult = objbo.SearchChildBillDetails(objdata);
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
        protected void Gv_IndentGen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_DueList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btn1reset_Click(object sender, EventArgs e)
        {
            Reset1();
        }
        protected void Reset1()
        {
            ddl_FinancialYearID.SelectedIndex = 0;
            ddl_VendorTypeID.SelectedIndex = 0;
            txt_VendorName.Text = "";
            txt_BillNo.Text = "";
            txt_DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            Gv_DueList.DataSource = null;
            Gv_DueList.DataBind();
            Gv_DueList.Visible = false;

        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_DueList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_DueList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_DueList.UseAccessibleHeader = true;
            Gv_DueList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        //---TAB-2----//

        protected void Gv_VendorDue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "PayDue")
                {
                    VendorDueData objdata = new VendorDueData();
                    VendorDueBO objbo = new VendorDueBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_DueList.Rows[i];
                    Label lblBillNo = (Label)gr.Cells[0].FindControl("lblBillNo");
                    objdata.BillNo = lblBillNo.Text.Trim();

                    List<VendorDueData> lstdataresult = new List<VendorDueData>();
                    lstdataresult = objbo.GetPaymentDetailsByBillNo(objdata);
                    if (lstdataresult.Count > 0)
                    {

                        bindresponsive();
                        MasterLookupBO mstlookup = new MasterLookupBO();
                        Commonfunction.PopulateDdl(ddlVendorType2, mstlookup.GetLookupsList(LookupNames.VendorType));
                        Commonfunction.PopulateDdl(ddl_PaymentMode, mstlookup.GetLookupsList(LookupNames.PaymentMode));
                        ddl_PaymentMode.SelectedIndex = 1;
                        ddlVendorType2.SelectedValue = lstdataresult[0].VendorTypeID.ToString();
                        hdnVendotID.Value = lstdataresult[0].VendorID.ToString();
                        txtVendorName2.Text = lstdataresult[0].VendorName.ToString();
                        txtBillNo2.Text = lstdataresult[0].BillNo.ToString();
                        txtTotalDuePaid.Text = lstdataresult[0].TotalDuePaid.ToString();
                        txtDueBalance.Text = lstdataresult[0].DueBalance.ToString();
                        txtDuePayable.Text = lstdataresult[0].DueBalance.ToString();
                        DueBalance.Text = lstdataresult[0].DueBalance.ToString();
                        if (lstdataresult[0].DueBalance > 0)
                        {
                            btnPay.Attributes.Remove("disabled");
                        }
                        else
                        {
                            btnPay.Attributes["disabled"] = "disabled";
                        }
                    }
                    else
                    {

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
                    txt_BankName.Text = "";
                    txt_BankName.ReadOnly = true;
                    txt_ChequeNo.ReadOnly = true;
                    txt_InvoiceNo.ReadOnly = true;
                }
                else if (ddl_PaymentMode.SelectedValue == "2")
                {
                    //  GetBankName(Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue));
                    txt_BankName.ReadOnly = true;
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = false;
                }
                else if (ddl_PaymentMode.SelectedValue == "3")
                {
                    // GetBankName(Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue));
                    txt_BankName.ReadOnly = true;
                    txt_InvoiceNo.Text = "";
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = true;
                }
                else if (ddl_PaymentMode.SelectedValue == "4")
                {
                    txt_BankName.Text = "";
                    txt_BankName.ReadOnly = false;
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = true;
                }
            }
            else
            {
                txt_BankName.Text = "";
                txt_BankName.ReadOnly = true;
                txt_ChequeNo.ReadOnly = true;
                txt_InvoiceNo.ReadOnly = true;
            }
        }
        protected void DuePay_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (ddl_PaymentMode.SelectedIndex > 1)
                {
                    if (ddl_PaymentMode.SelectedValue == "2")
                    {
                        if (txt_InvoiceNo.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Please Enter Invoice Number.") + "')", true);
                            txt_InvoiceNo.Focus();
                            return;
                        }
                    }
                    if (ddl_PaymentMode.SelectedValue == "3")
                    {
                        if (txt_ChequeNo.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Please Enter Cheque Number.") + "')", true);
                            txt_ChequeNo.Focus();
                            return;
                        }
                    }
                    if (ddl_PaymentMode.SelectedValue == "4")
                    {
                        if (txt_BankName.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Please Enter Bank Name.") + "')", true);
                            txt_BankName.Focus();
                            return;
                        }
                        if (txt_ChequeNo.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Please Enter Cheque No.") + "')", true);
                            txt_ChequeNo.Focus();
                            return;
                        }
                    }
                }
                else
                {

                }

                List<VendorDueData> Resultlist = new List<VendorDueData>();
                VendorDueBO saleBO = new VendorDueBO();
                VendorDueData obj = new VendorDueData();
                int Vendor = Convert.ToInt32(hdnVendotID.Value == "" ? "0" : hdnVendotID.Value);
                if (Vendor == 0)
                {
                    txtVendorName2.Text = "";
                    txtVendorName2.Focus();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor name cannot be empty.") + "')", true);
                    return;
                }
                else
                {
                    obj.VendorID = Convert.ToInt32(hdnVendotID.Value == "" ? "0" : hdnVendotID.Value);
                }
                obj.BillNo = txtBillNo2.Text == "" ? "0" : txtBillNo2.Text;
                obj.GdTotalAmount = Convert.ToDecimal(txtDueBalance.Text == "" ? "0" : txtDueBalance.Text);
                obj.GdDiscount = Convert.ToDecimal(txtDiscount2.Text == "" ? "0" : txtDiscount2.Text);
                obj.GdPayable = Convert.ToDecimal(txtDuePayable.Text == "" ? "0" : txtDuePayable.Text);
                obj.GdPaid = Convert.ToDecimal(txtDuePaidAmount.Text == "" ? "0" : txtDuePaidAmount.Text);
                obj.GdDue = Convert.ToDecimal(DueBalance.Text == "" ? "0" : DueBalance.Text);
                obj.PaymentModeID = Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue);
                obj.BankName = txt_BankName.Text == "" ? "" : txt_BankName.Text;
                obj.Invoice = txt_InvoiceNo.Text == "" ? "" : txt_InvoiceNo.Text;
                obj.ChequeNo = txt_ChequeNo.Text == "" ? "" : txt_ChequeNo.Text;
                obj.Remark = txtDueRemark.Text == "" ? "" : txtDueRemark.Text;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                Resultlist = saleBO.SaveDuePayment(obj);
                if (Resultlist.Count > 0)
                {
                    txtDueBillNo.Text = Resultlist[0].DueBillNo.ToString();
                    btnPay.Attributes["disabled"] = "disabled";
                    btn2Print.Attributes.Remove("disabled");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnPay.Attributes.Remove("disabled");
                    btn2Print.Attributes["disabled"] = "disabled";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("System Error.") + "')", true);
                }
            }
            catch (Exception ex)

            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btn2Cancel_OnClick(object sender, EventArgs e)
        {
            Reset2();
        }
        protected void Reset2()
        {
            ddlVendorType2.SelectedIndex = 0;
            hdnVendotID.Value = "";
            txtVendorName2.Text = "";
            txtBillNo2.Text = "";
            txtTotalDuePaid.Text = "";
            txtDueBalance.Text = "";
            txtDiscount2.Text = "";
            txtDuePayable.Text = "";
            txtDuePaidAmount.Text = "";
            DueBalance.Text = "";
            ddl_PaymentMode.SelectedIndex = 0;
            txt_BankName.Text = "";
            txt_InvoiceNo.Text = "";
            txt_ChequeNo.Text = "";
            txtDueRemark.Text = "";
            txtDueBillNo.Text = "";



        }
        //----TAB 3 DUE COLLECTION LIST----//
        protected void ddlvendortype3ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlvendortype3ID.SelectedIndex > 0)
            {
                txt3VendorName.Text = "";
                txt3VendorName.Attributes.Remove("disabled");
                AutoCompleteExtender3.ContextKey = ddlvendortype3ID.SelectedValue == "" ? "0" : ddlvendortype3ID.SelectedValue;
            }
            else
            {
                txt3VendorName.Text = "";
                txt3VendorName.Attributes["disabled"] = "disabled";
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetVendorNameCompletionList3(string prefixText, int count, string contextKey)
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
        protected void btn3Search_Click(object sender, EventArgs e)
        {
            bindgrid3(1);
        }
        private void bindgrid3(int index)
        {
            int pagesize = Convert.ToInt32(ddl3show.SelectedValue == "10000" ? lbl3totalrecords.Text : ddl3show.SelectedValue);
            List<VendorDueData> lstsale = getDueCollectionlist(index, pagesize);
            if (lstsale.Count > 0)
            {
                Gv_DuePaymentList.PageSize = pagesize;
                string record = lstsale[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lbl3result.Text = "Total : " + lstsale[0].MaximumRows.ToString() + " " + record;
                lbl3totalrecords.Text = lstsale[0].MaximumRows.ToString(); ;
                lbl3result.Visible = true;
                Gv_DuePaymentList.VirtualItemCount = lstsale[0].MaximumRows;//total item is required for custom paging
                Gv_DuePaymentList.PageIndex = index - 1;
                Gv_DuePaymentList.DataSource = lstsale;
                Gv_DuePaymentList.DataBind();
                Gv_DuePaymentList.Visible = true;
                bindresponsive3();
            }
            else
            {
                Gv_DuePaymentList.DataSource = null;
                Gv_DuePaymentList.DataBind();
                Gv_DuePaymentList.Visible = false;
            }
        }
        public List<VendorDueData> getDueCollectionlist(int curIndex, int pagesize)
        {
            VendorDueData objind = new VendorDueData();
            VendorDueBO objBO = new VendorDueBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt3DateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt3DateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt3DateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt3DateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objind.Datefrom = DateFrom;
            objind.Dateto = DateTo;
            objind.AcademicSessionID = Convert.ToInt32(ddl3FinancialYear.Text == "" ? "0" : ddl3FinancialYear.Text);
            objind.VendorTypeID = Convert.ToInt32(ddl_VendorTypeID.Text == "" ? "0" : ddl_VendorTypeID.Text);
            var Vendor3 = txt3VendorName.Text.ToString();
            if (Vendor3.Contains(":"))
            {
                string VID = Vendor3.Substring(Vendor3.LastIndexOf(':') + 1);
                objind.VendorID = Convert.ToInt32(VID == "" ? "0" : VID);
            }
            else
            {
                txt3VendorName.Text = "";
                objind.VendorID = 0;
                txt3VendorName.Focus();
            }
            objind.BillNo = txt3BillNo.Text == "" ? "0" : txt3BillNo.Text;
            objind.PageSize = pagesize;
            objind.CurrentIndex = curIndex;
            objind.IsActive = ddl3Status.SelectedValue == "1" ? true : false;
            return objBO.SearchDueCollectionList(objind);
        }
        protected void Gv_DuePaymentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    if (LoginToken.DeleteEnable == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                        return;
                    }
                    VendorDueData obj = new VendorDueData();
                    VendorDueBO objBO = new VendorDueBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_DuePaymentList.Rows[i];
                    Label lblDueBillNo = (Label)gr.Cells[0].FindControl("lblDueBillNo");
                    obj.DueBillNo = lblDueBillNo.Text.Trim();
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive3();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        obj.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    obj.EmployeeID = LoginToken.EmployeeID;
                    int Result = objBO.DeleteDueCollectionByDueBillNo(obj);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
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
        protected void bindresponsive3()
        {
            //Responsive 
            Gv_DuePaymentList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_DuePaymentList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_DuePaymentList.UseAccessibleHeader = true;
            Gv_DuePaymentList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btn3reset_Click(object sender, EventArgs e)
        {
            Reset3();
        }
        protected void Reset3()
        {
            ddl3FinancialYear.SelectedIndex = 0;
            txt3VendorName.Text = "";
            txt3BillNo.Text = "";
            txt3DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt3DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            Gv_DuePaymentList.DataSource = null;
            Gv_DuePaymentList.DataBind();
            Gv_DuePaymentList.Visible = false;
        }
    }
}