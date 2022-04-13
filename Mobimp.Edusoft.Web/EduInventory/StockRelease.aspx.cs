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
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.BussinessProcess.EduInventory;
using Mobimp.Edusoft.Common;
using System.Drawing;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class StockRelease : BasePage
    {
        int SumTotalApproved = 0, SumTotReleased = 0, SumTotDueReleased = 0;
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
            Commonfunction.PopulateDdl(ddlVendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));

            Commonfunction.PopulateDdl(ddl3VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(ddlFYearID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlFYearID.SelectedIndex = 1;
            txtDateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtDateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtVendorName.Attributes["disabled"] = "disabled";
            txtNetApprovedQty.Attributes["disabled"] = "disabled";
            txtNetReleasedQty.Attributes["disabled"] = "disabled";
            txtNetDueReleaseQty.Attributes["disabled"] = "disabled";
            //--Tab-2--//
            Commonfunction.PopulateDdl(ddl2VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
            ddl2VendorTypeID.Attributes["disabled"] = "disabled";
            txt2VendorName.Attributes["disabled"] = "disabled";
            txtIndentNo.Attributes["disabled"] = "disabled";
            txt2billno.Attributes["disabled"] = "disabled";
            txtRNo.Attributes["disabled"] = "disabled";
            txtGdTotalApprovedQty.Attributes["disabled"] = "disabled";
            txtGdTotalReleasedQty.Attributes["disabled"] = "disabled";
            txtGdTotalReleasedNowQty.Attributes["disabled"] = "disabled";
            btnReleased.Attributes["disabled"] = "disabled";
            btn_Print.Attributes["disabled"] = "disabled";

            //--Tab-3--//
            Commonfunction.PopulateDdl(ddl3FYearID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddl3FYearID.SelectedIndex = 1;
            txt3FromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt3ToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt3VendoName.Attributes["disabled"] = "disabled";
            txt2TotalAvailStk.Attributes["disabled"] = "disabled";

        }
        protected void ddlVendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVendorTypeID.SelectedIndex > 0)
            {
                txtVendorName.Text = "";
                txtVendorName.Attributes.Remove("disabled");
                AutoCompleteExtender1.ContextKey = ddlVendorTypeID.SelectedValue == "" ? "0" : ddlVendorTypeID.SelectedValue;
            }
            else
            {
                txtVendorName.Text = "";
                txtVendorName.Attributes["disabled"] = "disabled";
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
            int pagesize = 10000;// Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<IndentSaleData> lstindent = getpaymentlist(index, pagesize);
            if (lstindent.Count > 0)
            {
                Gv_PaymentListSales.PageSize = pagesize;
                string record = lstindent[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstindent[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstindent[0].MaximumRows.ToString();
                lblresult.Visible = true;
                SumTotalApproved = Convert.ToInt32(lstindent[0].NetApprovedQty.ToString());
                SumTotReleased = Convert.ToInt32(lstindent[0].NetReleasedQty.ToString());
                SumTotDueReleased = Convert.ToInt32(lstindent[0].NetDueRelease.ToString());
                txtNetApprovedQty.Text = lstindent[0].NetApprovedQty.ToString();
                txtNetReleasedQty.Text = lstindent[0].NetReleasedQty.ToString();
                txtNetDueReleaseQty.Text = lstindent[0].NetDueRelease.ToString();
                Gv_PaymentListSales.VirtualItemCount = lstindent[0].MaximumRows;//total item is required for custom paging
                Gv_PaymentListSales.PageIndex = index - 1;
                Gv_PaymentListSales.DataSource = lstindent;
                Gv_PaymentListSales.DataBind();
                Gv_PaymentListSales.Visible = true;
                bindresponsive();
            }
            else
            {
                Gv_PaymentListSales.DataSource = null;
                Gv_PaymentListSales.DataBind();
               // Gv_PaymentListSales.Visible = false;
                lblresult.Visible = false;
                txtNetApprovedQty.Text = "";
                txtNetReleasedQty.Text = "";
                txtNetDueReleaseQty.Text = "";
            }
        }
        public List<IndentSaleData> getpaymentlist(int curIndex, int pagesize)
        {
            IndentSaleData objind = new IndentSaleData();
            StockReleasedBO objBO = new StockReleasedBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txtDateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txtDateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtDateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objind.Datefrom = DateFrom;
            objind.Dateto = DateTo;
            objind.AcademicSessionID = Convert.ToInt32(ddlFYearID.SelectedValue == "" ? "0" : ddlFYearID.SelectedValue);
            objind.VendorTypeID = Convert.ToInt32(ddlVendorTypeID.Text == "" ? "0" : ddlVendorTypeID.Text);
            var Vendor = txtVendorName.Text.ToString();
            if (Vendor.Contains(":"))
            {
                string VID = Vendor.Substring(Vendor.LastIndexOf(':') + 1);
                objind.VendorID = Convert.ToInt32(VID == "" ? "0" : VID);
            }
            else
            {
                txtVendorName.Text = "";
                objind.VendorID = 0;
                txtVendorName.Focus();
            }
            objind.BillNo = txtBillNo.Text == "" ? "0" : txtBillNo.Text;
            objind.ReleasedStatusID = Convert.ToInt32(ddlRStatusID.SelectedValue == "" ? "0" : ddlRStatusID.SelectedValue);
            objind.PageSize = pagesize;
            objind.CurrentIndex = curIndex;

            return objBO.SearchPaidIndentDetailsList(objind);
        }
        protected void Gv_PaymentList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow row in Gv_PaymentListSales.Rows)
                {
                    Label IsFullReleased = (Label)Gv_PaymentListSales.Rows[row.RowIndex].Cells[0].FindControl("lblRStatusID");
                    Button btn_RDone = (Button)Gv_PaymentListSales.Rows[row.RowIndex].Cells[0].FindControl("btn_RDone");
                    Button btn_RNow = (Button)Gv_PaymentListSales.Rows[row.RowIndex].Cells[0].FindControl("btn_RNow");
                    if (IsFullReleased.Text == "1") // 1=Not paid ,2= paid
                    {
                        btn_RNow.Visible = false;
                        btn_RNow.Enabled = false;
                        btn_RDone.Visible = true;
                    }
                    else
                    {
                        btn_RNow.Visible = true;
                        btn_RNow.Enabled = true;
                        btn_RDone.Visible = false;
                    }
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblFtTotApp = (Label)e.Row.FindControl("lblFtTotApp");
                    Label lblFtTotRel = (Label)e.Row.FindControl("lblFtTotRel");
                    Label lblFtTotDueRel = (Label)e.Row.FindControl("lblFtTotDueRel");
                    lblFtTotApp.Text = SumTotalApproved.ToString();
                    lblFtTotRel.Text = SumTotReleased.ToString();
                    lblFtTotDueRel.Text = SumTotDueReleased.ToString();

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }
        }

        protected void Gv_IndentListSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_PaymentListSales.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            Reset1();
        }
        protected void Reset1()
        {
            ddlVendorTypeID.SelectedIndex = 1;
            txtVendorName.Text = "";
            txtVendorName.Attributes["disabled"] = "disabled";
            txtBillNo.Text = "";
            txtDateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtDateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddlRStatusID.SelectedIndex = 1;
            txtNetApprovedQty.Text = "";
            txtNetReleasedQty.Text = "";
            txtNetDueReleaseQty.Text = "";
            Gv_PaymentListSales.DataSource = null;
            Gv_PaymentListSales.DataBind();
            Gv_PaymentListSales.Visible = false;
            lblresult.Visible = false;
            Reset2();
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_PaymentListSales.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_PaymentListSales.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_PaymentListSales.UseAccessibleHeader = true;
            Gv_PaymentListSales.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //---TAB2----//
        protected void btnRClose_OnClick(object sender, EventArgs e)
        {
            this.ModalPopupExtender4.Hide();
        }
        protected void Gv_PaymentListSales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Print")
                {
                    if (LoginToken.PrintEnable == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                        bindresponsive();
                        return;
                    }
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_PaymentListSales.Rows[i];
                    Label lbl2BillNo = (Label)gr.Cells[0].FindControl("lbl2BillNo");

                    string lblBillNo = lbl2BillNo.Text.Trim() == "" ? null : lbl2BillNo.Text.Trim();
                    string BillNo = HttpUtility.UrlEncode(UrlEncryptDecrypt.Encrypt(lblBillNo.Trim()));
                    string url = "../Sales/Reports/Reportviewer.aspx?option=StockReleasedDetails&BillNo=" + BillNo;
                    string fullURL = "window.open('" + url + "', '_blank');";
                    bindresponsive();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
                }

                if (e.CommandName == "Released")
                {
                    IndentSaleData objdata = new IndentSaleData();
                    StockReleasedBO objbo = new StockReleasedBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_PaymentListSales.Rows[i];
                    Label lblbillno = (Label)gr.Cells[0].FindControl("lbl2BillNo");
                    objdata.BillNo = lblbillno.Text.Trim();
                    txtRNo.Text = "";
                    List<IndentSaleData> lstdataresult = new List<IndentSaleData>();
                    lstdataresult = objbo.GetItemDetailsByBillNo(objdata);
                    if (lstdataresult.Count > 0)
                    {

                        Gv_StockReleasedList.DataSource = lstdataresult;
                        Gv_StockReleasedList.DataBind();
                        Gv_StockReleasedList.Visible = true;
                        MasterLookupBO mstlookup = new MasterLookupBO();
                        Commonfunction.PopulateDdl(ddl2VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));

                        ddl2VendorTypeID.SelectedValue = lstdataresult[0].VendorTypeID.ToString();
                        hdn2VendorID.Value = lstdataresult[0].VendorID.ToString();
                        txt2VendorName.Text = lstdataresult[0].VendorName.ToString();
                        txtIndentNo.Text = lstdataresult[0].IndentNo.ToString();
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
                        TotalCalculate();
                      
                        this.ModalPopupExtender4.Show();
                    }
                    else
                    {
                        Gv_StockReleasedList.DataSource = null;
                        Gv_StockReleasedList.DataBind();
                        Gv_StockReleasedList.Visible = false;
                        this.ModalPopupExtender4.Show();
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
        protected void OnQty_TextChanged(object sender, EventArgs e)
        {
            TotalCalculate();
        }
        public void TotalCalculate()
        {
            int TotalQty = 0;
            int TotAvailStk = 0;
            foreach (GridViewRow row in Gv_StockReleasedList.Rows)
            {
                Label lblAvailableQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblAvailableQty");
                Label lblDueRQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblDueRQty");
                TextBox txtDueQty = (TextBox)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("txtDueQty");
                Label lblitemStatusID = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblitemStatusID");
                Label lblitemStatusName = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblitemStatusName");

                TotAvailStk = TotAvailStk + Convert.ToInt32(lblAvailableQty.Text == "" ? "0" : lblAvailableQty.Text);
                int lblQty = Convert.ToInt32(lblDueRQty.Text == "" ? "0" : lblDueRQty.Text);
                int txtQty = Convert.ToInt32(txtDueQty.Text == "" ? "0" : txtDueQty.Text);
                if (lblQty >= txtQty)
                {
                    TotalQty = TotalQty + (Convert.ToInt32(txtDueQty.Text == "" ? "0" : txtDueQty.Text));
                }
                else
                {
                    TotalQty = TotalQty + (Convert.ToInt32(lblDueRQty.Text == "" ? "0" : lblDueRQty.Text));
                    txtDueQty.Text = lblQty.ToString();
                    txtDueQty.Focus();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Enter quantity is greater than approved quantity.") + "')", true);
                }
                if (Convert.ToInt32(lblitemStatusID.Text == "" ? "0" : lblitemStatusID.Text) == 1)
                {
                    lblitemStatusName.ForeColor = Color.Red;
                    txtDueQty.Attributes["disabled"] = "disabled";
                }
                else
                {
                    lblitemStatusName.ForeColor = Color.Green;
                    txtDueQty.Attributes.Remove("disables");
                }

            }
            txt2TotalAvailStk.Text = Commonfunction.Getrounding(TotAvailStk.ToString());
            txtGdTotalReleasedNowQty.Text = Commonfunction.Getrounding(TotalQty.ToString());
            bindresponsive();
            bindresponsive2();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<IndentSaleData> list = new List<IndentSaleData>();
                StockReleasedBO objBO = new StockReleasedBO();
                IndentSaleData obj = new IndentSaleData();
                List<IndentSaleData> Resultlist = new List<IndentSaleData>();
                foreach (GridViewRow row in Gv_StockReleasedList.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ItemID = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblItemID");
                    Label AvailableQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblAvailableQty");
                    Label ApprovedQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblApprovedQty");
                    Label TotalReleasedQty = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lblTotalReleasedQty");
                    TextBox DueReleasedQty = (TextBox)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("txtDueQty");
                    Label StockNo = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lbl2StockNo");
                    Label BatchYearID = (Label)Gv_StockReleasedList.Rows[row.RowIndex].Cells[0].FindControl("lbl2BatchYearID");


                    IndentSaleData ObjDetails = new IndentSaleData();
                    ObjDetails.ItemID = Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text);
                    ObjDetails.AvailableQty = Convert.ToInt32(AvailableQty.Text == "" ? "0" : AvailableQty.Text);
                    ObjDetails.NetApprovedQty = Convert.ToInt32(ApprovedQty.Text == "" ? "0" : ApprovedQty.Text);
                    ObjDetails.GdTotalReleasedQty = Convert.ToInt32(TotalReleasedQty.Text == "" ? "0" : TotalReleasedQty.Text);
                    ObjDetails.NetDueRelease = Convert.ToInt32(DueReleasedQty.Text == "" ? "0" : DueReleasedQty.Text);
                    ObjDetails.StockNo = StockNo.Text == "" ? "0" : StockNo.Text;
                    ObjDetails.BatchYearID = Convert.ToInt32(BatchYearID.Text == "" ? "0" : BatchYearID.Text);
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.StockReleaseListtoXML(list).ToString();
                obj.VendorTypeID = Convert.ToInt32(ddl2VendorTypeID.SelectedValue == "" ? "0" : ddl2VendorTypeID.SelectedValue);

                int Vendor = Convert.ToInt32(hdn2VendorID.Value == "" ? "0" : hdn2VendorID.Value);
                if (Vendor == 0)
                {
                    txtVendorName.Text = "";
                    txtVendorName.Focus();
                    lblpopMessage.Text = "Please select vendor name cannot be empty.";
                    lblpopMessage.Visible = true;
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor name cannot be empty.") + "')", true);
                    this.ModalPopupExtender4.Show();
                    return;
                }
                else
                {
                    obj.VendorID = Convert.ToInt32(hdn2VendorID.Value == "" ? "0" : hdn2VendorID.Value);
                    obj.VendorName = txt2VendorName.Text == "" ? "" : txt2VendorName.Text;
                }
                obj.IndentNo = txtIndentNo.Text == "" ? "0" : txtIndentNo.Text;
                obj.BillNo = txt2billno.Text == "" ? "0" : txt2billno.Text;
                obj.GdTotalApprovedQty = Convert.ToInt32(txtGdTotalApprovedQty.Text == "" ? "0" : txtGdTotalApprovedQty.Text);
                obj.GdTotalReleasedQty = Convert.ToInt32(txtGdTotalReleasedQty.Text == "" ? "0" : txtGdTotalReleasedQty.Text);
                obj.GdTotalReleasedNow = Convert.ToInt32(txtGdTotalReleasedNowQty.Text == "" ? "0" : txtGdTotalReleasedNowQty.Text);
                if (Convert.ToInt32(txtGdTotalReleasedNowQty.Text == "" ? "0" : txtGdTotalReleasedNowQty.Text) > Convert.ToInt32(txt2TotalAvailStk.Text == "" ? "0" : txt2TotalAvailStk.Text))
                {
                   // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Total Indent quantity is greatrer than available stock. Please check the enter quantity.") + "')", true);
                    lblpopMessage.Text = "Total Indent quantity is greatrer than available stock. Please check the enter quantity.";
                    lblpopMessage.Visible = true;
                    this.ModalPopupExtender4.Show();
                    return;
                }
                if (Convert.ToInt32(txtGdTotalReleasedNowQty.Text == "" ? "0" : txtGdTotalReleasedNowQty.Text) > Convert.ToInt32(txtGdTotalApprovedQty.Text == "" ? "0" : txtGdTotalApprovedQty.Text))
                {
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Approved quantity is greatrer than approved quantity.Please check the enter quantity.") + "')", true);
                    lblpopMessage.Text = "Release quantity is greatrer than quantity.Please check the enter quantity.";
                    lblpopMessage.Visible = true;
                    this.ModalPopupExtender4.Show();
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
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    lblpopMessage.Text = "Release Successfully.";
                    lblpopMessage.Visible = true;
                    this.ModalPopupExtender4.Show();
                }
                else
                {
                    btnReleased.Attributes.Remove("disabled");
                    btn_Print.Attributes["disabled"] = "disabled";
                    // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("System Error.") + "')", true);
                    lblpopMessage.Text = "System Error.";
                    lblpopMessage.Visible = true;
                    this.ModalPopupExtender4.Show();
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
                this.ModalPopupExtender4.Show();
                return;
            }

            string RNo = txtRNo.Text.Trim() == "" ? null : txtRNo.Text.Trim();
            string ReleasedNo = HttpUtility.UrlEncode(UrlEncryptDecrypt.Encrypt(RNo.Trim()));
            string url = "../Sales/Reports/Reportviewer.aspx?option=StockReleasedReceipt&ReleasedNo=" + ReleasedNo;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            this.ModalPopupExtender4.Show();
        }
        protected void btn2Reset_OnClick(object sender, EventArgs e)
        {
            Reset2();
        }
        protected void Reset2()
        {
            ddl2VendorTypeID.SelectedIndex = 0;
            txt2VendorName.Text = "";
            txt2VendorName.Text = "";
            txtIndentNo.Text = "";
            txt2billno.Text = "";
            txtRNo.Text = "";
            txt2TotalAvailStk.Text = "";
            Gv_StockReleasedList.DataSource = null;
            Gv_StockReleasedList.DataBind();
            Gv_StockReleasedList.Visible = false;
            btnReleased.Attributes["disabled"] = "disabled";
            btn_Print.Attributes["disabled"] = "disabled";
            this.ModalPopupExtender4.Show();
        }
        protected void bindresponsive2()
        {
            //Responsive 
            Gv_StockReleasedList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_StockReleasedList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_StockReleasedList.UseAccessibleHeader = true;
            Gv_StockReleasedList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        //---TAB3---//
        protected void ddlVendorType3ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl3VendorTypeID.SelectedIndex > 0)
            {
                txt3VendoName.Attributes.Remove("disabled");
                AutoCompleteExtender1.ContextKey = ddl3VendorTypeID.SelectedValue == "" ? "0" : ddl3VendorTypeID.SelectedValue;
            }
            else
            {
                txt3VendoName.Attributes["disabled"] = "disabled";
            }
        }
        protected void btnSearch3_OnClick(object sender, EventArgs e)
        {
            bindgrid3(1);
        }
        private void bindgrid3(int index)
        {
            int pagesize = 10000; // Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<IndentSaleData> lstsale = getReleasedlist(index, pagesize);
            if (lstsale.Count > 0)
            {
                Gv_StockReleasedLists.PageSize = pagesize;
                string record = lstsale[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstsale[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstsale[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gv_StockReleasedLists.VirtualItemCount = lstsale[0].MaximumRows;//total item is required for custom paging
                Gv_StockReleasedLists.PageIndex = index - 1;
                Gv_StockReleasedLists.DataSource = lstsale;
                Gv_StockReleasedLists.DataBind();
                tab3bindresponsive();
            }
            else
            {
                Gv_StockReleasedLists.DataSource = null;
                Gv_StockReleasedLists.DataBind();
            }
        }
        public List<IndentSaleData> getReleasedlist(int curIndex, int pagesize)
        {
            IndentSaleData objdata = new IndentSaleData();
            StockReleasedBO objBO = new StockReleasedBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt3FromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt3FromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt3ToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt3ToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.Datefrom = DateFrom;
            objdata.Dateto = DateTo;
            objdata.AcademicSessionID = Convert.ToInt32(ddl3FYearID.Text == "" ? "0" : ddl3FYearID.Text);
            objdata.VendorTypeID = Convert.ToInt32(ddl3VendorTypeID.Text == "" ? "0" : ddl3VendorTypeID.Text);
            var Vendor = txt3VendoName.Text.ToString();
            if (Vendor.Contains(":"))
            {
                string VID = Vendor.Substring(Vendor.LastIndexOf(':') + 1);
                objdata.VendorID = Convert.ToInt32(VID == "" ? "0" : VID);
            }
            else
            {
                txt3VendoName.Text = "";
                objdata.VendorID = 0;
                txt3VendoName.Focus();
            }
            objdata.ReleasedNo = txt3RNo.Text == "" ? "0" : txt3RNo.Text;
            objdata.IsReleasedClosed = Convert.ToInt32(ddlReleasedStatusID.SelectedValue == "" ? "3" : ddlReleasedStatusID.SelectedValue);
            objdata.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;

            return objBO.SearchStockReleasedDetailsList(objdata);
        }
        protected void Gv3StockReleased_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    IndentSaleData objdata = new IndentSaleData();
                    StockReleasedBO objbo = new StockReleasedBO();
                    Label lblRNo = (Label)e.Row.FindControl("lbl3ReleasedNo");
                    objdata.ReleasedNo = lblRNo.Text.Trim();
                    List<IndentSaleData> GetResult = objbo.SearchChildStockReleasedDetails(objdata);
                    if (GetResult.Count > 0)
                    {
                        GridView SC = (GridView)e.Row.FindControl("GridChildReleased");
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
        protected void Gv3StockReleased_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    GridViewRow gr = Gv_StockReleasedLists.Rows[i];
                    Label lblRNo = (Label)gr.Cells[0].FindControl("lbl3ReleasedNo");
                    string ReleasedNo = HttpUtility.UrlEncode(UrlEncryptDecrypt.Encrypt(lblRNo.Text.Trim()));
                    string url = "../Sales/Reports/Reportviewer.aspx?option=StockReleasedReceipt&ReleasedNo=" + ReleasedNo;
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
                    StockReleasedBO objBO = new StockReleasedBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_StockReleasedLists.Rows[i];
                    Label lblRNo = (Label)gr.Cells[0].FindControl("lbl3ReleasedNo");
                    obj.ReleasedNo = lblRNo.Text.Trim();
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        tab3bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        obj.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    obj.EmployeeID = LoginToken.EmployeeID;
                    int Result = objBO.DeleteStockReleasedByRNo(obj);
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
        protected void Gv3StockReleased_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_StockReleasedLists.PageIndex = e.NewPageIndex;
            bindgrid3(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btnReset3_OnClick(object sender, EventArgs e)
        {
            Reset2();
            Reset3();
        }
        protected void Reset3()
        {
            ddl3FYearID.SelectedIndex = 1;
            ddl3VendorTypeID.SelectedIndex = 1;
            txt3VendoName.Text = "";
            txt3VendoName.Attributes["disabled"] = "disabled";
            txt3RNo.Text = "";
            txt3FromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt3ToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddlReleasedStatusID.SelectedIndex = 1;
            ddlStatus.SelectedIndex = 1;
        }
        protected void tab3bindresponsive()
        {
            //Responsive 
            Gv_StockReleasedLists.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_StockReleasedLists.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_StockReleasedLists.UseAccessibleHeader = true;
            Gv_StockReleasedLists.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}