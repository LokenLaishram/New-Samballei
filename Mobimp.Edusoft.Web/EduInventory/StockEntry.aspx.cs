using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
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

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class StockEntry : BasePage
    {
        int SumTotalQty = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlOrderType, mstlookup.GetLookupsList(LookupNames.OrderType));
            Commonfunction.PopulateDdl(ddlVendorType, mstlookup.GetLookupsList(LookupNames.VendorType));
            //---TAB-2---//
            Commonfunction.PopulateDdl(ddl2OrderType, mstlookup.GetLookupsList(LookupNames.OrderType));
            Commonfunction.PopulateDdl(ddl2VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
            ddl2VendorTypeID.SelectedValue = "2";
            Commonfunction.PopulateDdl(ddl2ReceivedBy, mstlookup.GetLookupsList(LookupNames.Employee));

            //---POPUP---//
            lblpopOrderTypeID.Attributes["disabled"] = "disabled";
            txtOrderType.Attributes["disabled"] = "disabled";
            txtOrdeNo.Attributes["disabled"] = "disabled";
            lblPopPrintModeID.Attributes["disabled"] = "disabled";
            txtPrintMode.Attributes["disabled"] = "disabled";
            lblpopVendorID.Attributes["disabled"] = "disabled";
            txtPopVendorName.Attributes["disabled"] = "disabled";
            txtReceivedNo.Attributes["disabled"] = "disabled";
            txtgdTotalCopies.Attributes["disabled"] = "disabled";
            txtgdPreTotalReceived.Attributes["disabled"] = "disabled";
            txtgdDueToReceived.Attributes["disabled"] = "disabled";
            txtgdNowReceived.Attributes["disabled"] = "disabled";
            AutoCompleteExtender2.ContextKey = "2";
            //---POPUP2---//
            txt3popRecNo.Attributes["disabled"] = "disabled";
            txt3popOrderType.Attributes["disabled"] = "disabled";
            lbl3SysgenOrderNo.Attributes["disabled"] = "disabled";
            txt3popOrderNo.Attributes["disabled"] = "disabled";
            txt3popVendorName.Attributes["disabled"] = "disabled";
            txt3popRecBy.Attributes["disabled"] = "disabled";
            txt3popRecDate.Attributes["disabled"] = "disabled";
        }
        protected void ddlVendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCompleteExtender1.ContextKey = ddlVendorType.SelectedValue == "" ? "0" : ddlVendorType.SelectedValue;
        }
        protected void ddl2VendorTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCompleteExtender2.ContextKey = ddl2VendorTypeID.SelectedValue == "" ? "0" : ddl2VendorTypeID.SelectedValue;
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetVendorDetail(string prefixText, int count, string contextKey)
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
        protected void txtVendorName_OnTextChanged(object sender, EventArgs e)
        {
            if (txtvendordetail.Text != "")
            {
                WorkOrderData objdata = new WorkOrderData();
                WorkOrderBO ObjBO = new WorkOrderBO();
                var source = txtvendordetail.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.VendorID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                    hdnvendorid.Value = ID;
                }
                else
                {
                    txtvendordetail.Text = "";
                }
                //List<WorkOrderData> result = ObjBO.GetItemDetailByID(objdata);
                //if (result.Count > 0)
                //{
                //    hdnvendorid.Value = result[0].ItemName.ToString();
                //    hdnsubgroupid.Value = result[0].SubGroupID.ToString();
                //    hdnitemid.Value = result[0].ItemID.ToString();
                //}
            }
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
            int pagesize = Convert.ToInt32(ddlShow.SelectedValue == "10000" ? lbltotalrecords.Text : ddlShow.SelectedValue);
            List<WorkOrderData> lstindent = getWorkOrderList(index, pagesize);
            if (lstindent.Count > 0)
            {
                GvWorkOrderlist.PageSize = pagesize;
                string record = lstindent[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lbltotalrecords.Text = lstindent[0].MaximumRows.ToString();
                GvWorkOrderlist.VirtualItemCount = lstindent[0].MaximumRows; //total item is required for custom paging
                GvWorkOrderlist.PageIndex = index - 1;
                GvWorkOrderlist.DataSource = lstindent;
                GvWorkOrderlist.DataBind();
                GvWorkOrderlist.Visible = true;
            }
            else
            {
                GvWorkOrderlist.DataSource = null;
                GvWorkOrderlist.DataBind();
                GvWorkOrderlist.Visible = false;
            }
        }
        public List<WorkOrderData> getWorkOrderList(int curIndex, int pagesize)
        {
            StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
            WorkOrderData ObjData = new WorkOrderData();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txtDateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txtDateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtDateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            ObjData.Datefrom = DateFrom;
            ObjData.Dateto = DateTo;
            ObjData.OrderTypeID = Convert.ToInt32(ddlOrderType.SelectedValue == "" ? "0" : ddlOrderType.SelectedValue);
            ObjData.VendorID = Convert.ToInt32(hdnvendorid.Value == "" ? "0" : hdnvendorid.Value);
            ObjData.WorkOrderNo = txtOrderNo.Text == "" ? "0" : txtOrderNo.Text;
            ObjData.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            ObjData.PageSize = pagesize;
            ObjData.CurrentIndex = curIndex;
            return ObjBO.SearchWorkOrderList(ObjData);
        }
        protected void GvWorkOrderlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvWorkOrderlist.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvWorkOrderlist_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    GridViewRow gr = GvWorkOrderlist.Rows[i];
                    Label lblOrderNo = (Label)gr.Cells[0].FindControl("lblGvSysGenOrderNo");

                    string ONo = lblOrderNo.Text.Trim() == "" ? null : lblOrderNo.Text.Trim();
                    PrintWorkOrder(ONo);
                }
                if (e.CommandName == "StockEntry")
                {
                    StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
                    WorkOrderData ObjData = new WorkOrderData();
                    List<WorkOrderData> ItemList = new List<WorkOrderData>();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvWorkOrderlist.Rows[i];
                    Label lblOrderNo = (Label)gr.Cells[0].FindControl("lblGvSysGenOrderNo");
                    ObjData.SysGenWorkOrderNo = lblOrderNo.Text.Trim() == "" ? null : lblOrderNo.Text.Trim();
                    ItemList = ObjBO.GetItemDetailsByWorkOrder(ObjData);
                    clear();
                    if (ItemList.Count > 0)
                    {
                        lblpopSysgenOrderNo.Text = ItemList[0].SysGenWorkOrderNo.ToString();
                        lblpopOrderTypeID.Text = ItemList[0].OrderTypeID.ToString();
                        txtOrderType.Text = ItemList[0].OrderTypeName.ToString();
                        txtOrdeNo.Text = ItemList[0].WorkOrderNo.ToString();
                        lblPopPrintModeID.Text = ItemList[0].PrintModeID.ToString();
                        txtPrintMode.Text = ItemList[0].PrintingMode.ToString();
                        lblpopVendorID.Text = ItemList[0].VendorID.ToString();
                        txtPopVendorName.Text = ItemList[0].VendorName.ToString();

                        GvpopWorkOrderItemList.DataSource = ItemList;
                        GvpopWorkOrderItemList.DataBind();
                        GvpopWorkOrderItemList.Visible = true;

                        ReceivedTotalCalculate();
                        this.WorkOrderPopup.Show();
                    }
                    else
                    {
                        GvpopWorkOrderItemList.DataSource = null;
                        GvpopWorkOrderItemList.DataBind();
                        GvpopWorkOrderItemList.Visible = false;
                        this.WorkOrderPopup.Show();
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
            ReceivedTotalCalculate();
            this.WorkOrderPopup.Show();
        }
        public void ReceivedTotalCalculate()
        {
            int TotalCopies = 0;
            int PreTotalReceivecd = 0;
            int TotalDue = 0;
            int TotalNowReceived = 0;
            foreach (GridViewRow row in GvpopWorkOrderItemList.Rows)
            {
                Label lblgvCopies = (Label)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("lblgvCopies");
                Label lblgvTotalReceived = (Label)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("lblgvTotalReceived");
                Label lblgvDueToReceived = (Label)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("lblgvDueToReceived");
                TextBox txtgvNowReceived = (TextBox)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("txtgvNowReceived");
                Label lblgvIsFullReceived = (Label)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("lblgvIsFullReceived");

                TotalCopies = TotalCopies + Convert.ToInt32(lblgvCopies.Text == "" ? "0" : lblgvCopies.Text);
                PreTotalReceivecd = PreTotalReceivecd + Convert.ToInt32(lblgvTotalReceived.Text == "" ? "0" : lblgvTotalReceived.Text);
                TotalDue = TotalDue + Convert.ToInt32(lblgvDueToReceived.Text == "" ? "0" : lblgvDueToReceived.Text);


                int txtDueQty = Convert.ToInt32(lblgvDueToReceived.Text == "" ? "0" : lblgvDueToReceived.Text);
                int txtNowQty = Convert.ToInt32(txtgvNowReceived.Text == "" ? "0" : txtgvNowReceived.Text);
                if (txtDueQty >= txtNowQty)
                {
                    TotalNowReceived = TotalNowReceived + Convert.ToInt32(txtgvNowReceived.Text == "" ? "0" : txtgvNowReceived.Text);
                }
                else
                {

                    TotalNowReceived = TotalNowReceived + Convert.ToInt32(lblgvDueToReceived.Text == "" ? "0" : lblgvDueToReceived.Text);
                    txtgvNowReceived.Text = txtDueQty.ToString();
                    txtgvNowReceived.Focus();
                    lblpopMessage.Text = "Enter quantity is greater than due quantity.";
                    lblpopMessage.Visible = true;
                }
                if (Convert.ToInt32(lblgvIsFullReceived.Text == "" ? "0" : lblgvIsFullReceived.Text) == 1)
                {
                    // lblitemStatusName.ForeColor = Color.Red;
                    txtgvNowReceived.Attributes["disabled"] = "disabled";
                }
                else
                {
                    // lblitemStatusName.ForeColor = Color.Green;
                    txtgvNowReceived.Attributes.Remove("disables");
                }

            }
            txtgdTotalCopies.Text = Commonfunction.Getrounding(TotalCopies.ToString());
            txtgdPreTotalReceived.Text = Commonfunction.Getrounding(PreTotalReceivecd.ToString());
            txtgdDueToReceived.Text = Commonfunction.Getrounding(TotalDue.ToString());
            txtgdNowReceived.Text = Commonfunction.Getrounding(TotalNowReceived.ToString());

        }

        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                //if (LoginToken.UpdateEnable == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("updateenable") + "')", true);
                //    return;
                //}

                List<WorkOrderData> list = new List<WorkOrderData>();
                StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
                WorkOrderData obj = new WorkOrderData();
                List<WorkOrderData> Resultlist = new List<WorkOrderData>();
                foreach (GridViewRow row in GvpopWorkOrderItemList.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label lblItemID = (Label)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("lblgvItemID");
                    Label lblgvPreTotalReceived = (Label)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("lblgvTotalReceived");
                    TextBox txtgvNowReceived = (TextBox)GvpopWorkOrderItemList.Rows[row.RowIndex].Cells[0].FindControl("txtgvNowReceived");

                    WorkOrderData ObjDetails = new WorkOrderData();
                    ObjDetails.ItemID = Convert.ToInt32(lblItemID.Text == "" ? "0" : lblItemID.Text);
                    ObjDetails.PreTotalReceived = Convert.ToInt32(lblgvPreTotalReceived.Text == "" ? "0" : lblgvPreTotalReceived.Text);
                    ObjDetails.NowReceived = Convert.ToInt32(txtgvNowReceived.Text == "" ? "0" : txtgvNowReceived.Text);
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.StockEntryListXML(list).ToString();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime DateTo = txtReceivedDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtReceivedDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                obj.ReceivedDate = DateTo;
                obj.SysGenWorkOrderNo = lblpopSysgenOrderNo.Text == "" ? "0" : lblpopSysgenOrderNo.Text;
                obj.WorkOrderNo = txtOrdeNo.Text == "" ? "0" : txtOrdeNo.Text;
                obj.OrderTypeID = Convert.ToInt32(lblpopOrderTypeID.Text == "" ? "0" : lblpopOrderTypeID.Text);
                obj.VendorTypeID = Convert.ToInt32(lblPopVendorTypeID.Text == "" ? "0" : lblPopVendorTypeID.Text);
                obj.VendorID = Convert.ToInt32(lblpopVendorID.Text == "" ? "0" : lblpopVendorID.Text);
                obj.TotalCopies = Convert.ToInt32(txtgdTotalCopies.Text == "" ? "0" : txtgdTotalCopies.Text);
                obj.TotalReceived = Convert.ToInt32(txtgdPreTotalReceived.Text == "" ? "0" : txtgdPreTotalReceived.Text);
                obj.TotalNowReceived = Convert.ToInt32(txtgdNowReceived.Text == "" ? "0" : txtgdNowReceived.Text);

                obj.Remark = txtRemark.Text == "" ? "" : txtRemark.Text;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                Resultlist = ObjBO.UpdateStockReceived(obj);
                if (Resultlist.Count > 0)
                {
                    txtReceivedNo.Text = Resultlist[0].ReceivedNo.ToString();
                    btnPopSave.Attributes["disabled"] = "disabled";
                    btnPopPrint.Attributes.Remove("disabled");
                    lblpopMessage.Text = "Save sucessfully.";
                    this.WorkOrderPopup.Show();
                }
                else
                {
                    btnPopSave.Attributes.Remove("disabled");
                    btnPopPrint.Attributes["disabled"] = "disabled";
                    lblpopMessage.Text = "System Error.";
                    this.WorkOrderPopup.Show();
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

        protected void PrintWorkOrder(string WOrderNo)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    return;
            //}
            string OrderNo = WOrderNo;
            string url = "../EduInventory/WorkOrderPreview.aspx?OrderNo=" + OrderNo;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
        protected void clear()
        {
            lblpopOrderTypeID.Text = "";
            txtOrderType.Text = "";
            txtOrdeNo.Text = "";
            lblPopPrintModeID.Text = "";
            txtPrintMode.Text = "";
            lblpopVendorID.Text = "";
            txtPopVendorName.Text = "";
            txtReceivedNo.Text = "";
            txtgdTotalCopies.Text = "";
            txtgdPreTotalReceived.Text = "";
            txtgdDueToReceived.Text = "";
            txtgdNowReceived.Text = "";
            GvpopWorkOrderItemList.DataSource = null;
            GvpopWorkOrderItemList.DataBind();
            GvpopWorkOrderItemList.Visible = false;
            btnPopSave.Attributes.Remove("disabled");
            btnPopPrint.Attributes["disabled"] = "disabled";
        }
        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            clear();
            ddlOrderType.SelectedIndex = 0;
            txtOrderNo.Text = "";
            txtvendordetail.Text = "";
            ddlStatus.SelectedIndex = 0;
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            GvWorkOrderlist.DataSource = null;
            GvWorkOrderlist.DataBind();
            GvWorkOrderlist.Visible = false;

        }
        //----TAB-2-----//
        protected void btn2Search_Click(object sender, EventArgs e)
        {
            bindgridList(1);
        }
        private void bindgridList(int index)
        {
            int pagesize = Convert.ToInt32(ddl2_show.SelectedValue == "10000" ? lbl2totalrecords.Text : ddl2_show.SelectedValue);
            List<WorkOrderData> StkRecList = getStockReceivedList(index, pagesize);
            if (StkRecList.Count > 0)
            {
                Gv_StockReceivedList.PageSize = pagesize;
                string record = StkRecList[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lbl2result.Text = "Total " + StkRecList[0].MaximumRows.ToString() + " record found.";
                lbl2totalrecords.Text = StkRecList[0].MaximumRows.ToString();
                SumTotalQty = Convert.ToInt32(StkRecList[0].TotalNowReceived);
                Gv_StockReceivedList.VirtualItemCount = StkRecList[0].MaximumRows; //total item is required for custom paging
                Gv_StockReceivedList.PageIndex = index - 1;
                Gv_StockReceivedList.DataSource = StkRecList;
                Gv_StockReceivedList.DataBind();
                Gv_StockReceivedList.Visible = true;
            }
            else
            {
                Gv_StockReceivedList.DataSource = null;
                Gv_StockReceivedList.DataBind();
                Gv_StockReceivedList.Visible = false;
                lbl2result.Text = "";
            }
        }
        public List<WorkOrderData> getStockReceivedList(int curIndex, int pagesize)
        {
            StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
            WorkOrderData ObjData = new WorkOrderData();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt2ReceivedDateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt2ReceivedDateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt2ReceivedDateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt2ReceivedDateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            ObjData.Datefrom = DateFrom;
            ObjData.Dateto = DateTo;
            ObjData.OrderTypeID = Convert.ToInt32(ddl2OrderType.SelectedValue == "" ? "0" : ddl2OrderType.SelectedValue);
            ObjData.VendorTypeID = Convert.ToInt32(ddl2VendorTypeID.SelectedValue == "" ? "0" : ddl2VendorTypeID.SelectedValue);
            ObjData.VendorID = Commonfunction.SemicolonSeparation_String_32(txt2VendorName.Text == "" ? "0" : txt2VendorName.Text);
            ObjData.WorkOrderNo = txt2OrderNo.Text == "" ? "0" : txt2OrderNo.Text;
            ObjData.ReceivedByID = Convert.ToInt32(ddl2ReceivedBy.SelectedValue == "" ? "0" : ddl2ReceivedBy.SelectedValue);
            ObjData.ReceivedNo = txt2ReceivedNo.Text == "" ? "0" : txt2ReceivedNo.Text;
            ObjData.IsActive = ddlStatusID.SelectedValue == "1" ? true : false;
            ObjData.PageSize = pagesize;
            ObjData.CurrentIndex = curIndex;
            return ObjBO.SearchStockReceivedList(ObjData);
        }
        protected void GvStockReceivedlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_StockReceivedList.PageIndex = e.NewPageIndex;
            bindgridList(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void GvReceivedList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label CollAmt = (Label)e.Row.FindControl("lblgv2CollectionAmount");
                //SumCollAmt = Convert.ToDecimal(lblSumDisbAmt.Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label GvlblTotalRecQty = (Label)e.Row.FindControl("GvlblTotalRecQty");
                GvlblTotalRecQty.Text = SumTotalQty.ToString();
            }
        }

        protected void GvReceivedList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EDetails")
                {

                    StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
                    WorkOrderData ObjData = new WorkOrderData();
                    List<WorkOrderData> EntryItemList = new List<WorkOrderData>();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_StockReceivedList.Rows[i];
                    Label lblRecNo = (Label)gr.Cells[0].FindControl("GvlblRecNo");
                    Label lblOrderNo = (Label)gr.Cells[0].FindControl("GvlblOrderNo");
                    ObjData.ReceivedNo = lblRecNo.Text.Trim() == "" ? "0" : lblRecNo.Text.Trim();
                    ObjData.SysGenWorkOrderNo = lblOrderNo.Text.Trim() == "" ? "0" : lblOrderNo.Text.Trim();
                    EntryItemList = ObjBO.GetItemDetailsByRecNo(ObjData);
                    clear();
                    if (EntryItemList.Count > 0)
                    {
                        txt3popRecNo.Text = EntryItemList[0].ReceivedNo.ToString();                       
                        txt3popOrderType.Text = EntryItemList[0].OrderTypeName.ToString();
                        lbl3SysgenOrderNo.Text = EntryItemList[0].SysGenWorkOrderNo.ToString();
                        txt3popOrderNo.Text = EntryItemList[0].WorkOrderNo.ToString();
                        txt3popVendorName.Text = EntryItemList[0].VendorName.ToString();
                        txt3popRecDate.Text = EntryItemList[0].ReceivedDate.ToString();
                        txt3popRecBy.Text = EntryItemList[0].ReceivedBy.ToString();
                        Gv3popEntryDetails.DataSource = EntryItemList;
                        Gv3popEntryDetails.DataBind();
                        Gv3popEntryDetails.Visible = true;
                        this.PopupEntryDetails.Show();
                    }
                    else
                    {
                        Gv3popEntryDetails.DataSource = null;
                        Gv3popEntryDetails.DataBind();
                        Gv3popEntryDetails.Visible = false;
                        this.PopupEntryDetails.Show();
                    }

                }

                if (e.CommandName == "EDelete")
                {

                    //if (LoginToken.PrintEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                    //    return;
                    //}

                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_StockReceivedList.Rows[i];
                    Label GvlblRecNo = (Label)gr.Cells[0].FindControl("GvlblRecNo");
                    txtPopRNo.Text = GvlblRecNo.Text.Trim();
                    this.DeletePopup.Show();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnEDetailsPopClose(object sender, EventArgs e)
        {
            this.PopupEntryDetails.Hide();
        } 
        protected void BtnPopDelete_OnClick(object sender, EventArgs e)
        {
            StockEntryWithOrderBO ObjBO = new StockEntryWithOrderBO();
            WorkOrderData ObjData = new WorkOrderData();
            List<WorkOrderData> ItemList = new List<WorkOrderData>();

            ObjData.ReceivedNo = txtPopRNo.Text.Trim() == "" ? "0" : txtPopRNo.Text.Trim();
            if (txtpopRemark.Text == "")
            {
                lblDeletePopMessage.Text = "Please enter remark";
                lblDeletePopMessage.Visible = true;
                txtpopRemark.Focus();
                this.DeletePopup.Show();
                return;
            }
            else
            {
                ObjData.Remark = txtpopRemark.Text == "" ? "0" : txtpopRemark.Text;
                lblDeletePopMessage.Visible = false;
            }
            ObjData.EmployeeID = LoginToken.EmployeeID;
            int Result = ObjBO.DeleteStockReceivedNo(ObjData);
            if (Result == 1)
            {
                lblDeletePopMessage.Text = "Successfully deleted";
                lblDeletePopMessage.Visible = true;
                bindgridList(1);
                this.DeletePopup.Show();
            }
            else if (Result == 2)
            {
                lblDeletePopMessage.Text = "This stock received number cannot be deleted, it have already indent/issued stock.";
                lblDeletePopMessage.Visible = true;
                bindgridList(1);
                this.DeletePopup.Show();
            }
            else
            {
                lblDeletePopMessage.Text = "System Error";
                lblDeletePopMessage.Visible = true;
                this.DeletePopup.Show();
            }
        }
        protected void btnDeletePopClose(object sender, EventArgs e)
        {
            this.DeletePopup.Hide();
        }
        
        protected void btn2Print_Onclick(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    return;
            //}
            int OrderTypeID = Convert.ToInt32(ddl2OrderType.SelectedValue == "" ? "0" : ddl2OrderType.SelectedValue);
            string WorkOrderNo = txt2OrderNo.Text == "" ? "0" : txt2OrderNo.Text;
            int VendorTypeID = Convert.ToInt32(ddl2VendorTypeID.SelectedValue == "" ? "0" : ddl2VendorTypeID.SelectedValue);
            int VendorID = Commonfunction.SemicolonSeparation_String_32(txt2VendorName.Text == "" ? "0" : txt2VendorName.Text);
       
            int ReceivedByID = Convert.ToInt32(ddl2ReceivedBy.SelectedValue == "" ? "0" : ddl2ReceivedBy.SelectedValue);
            string ReceivedNo = txt2ReceivedNo.Text == "" ? "0" : txt2ReceivedNo.Text;
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            //DateTime Datefrom = txt2ReceivedDateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt2ReceivedDateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //DateTime Dateto = txt2ReceivedDateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt2ReceivedDateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            string DF = txt2ReceivedDateFrom.Text==""?"0": txt2ReceivedDateFrom.Text;
            string DT = txt2ReceivedDateTo.Text == "" ? "0" : txt2ReceivedDateTo.Text;

            string url = "../Stock/Report/Reportviewer.aspx?option=StockEntryReceipt&OrderTypeID=" + OrderTypeID + "&WorkOrderNo=" + WorkOrderNo + "&VendorTypeID=" + VendorTypeID + "&VendorID=" + VendorID + "&ReceivedByID=" + ReceivedByID + "&ReceivedNo=" + ReceivedNo + "&DateFrom=" + DF + "&DateTo=" + DT ;
            string fullURL = "window.open('" + url + "', '_blank');";           
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
        protected void btn2Reset_OnClick(object sender, EventArgs e)
        {
            ddl2OrderType.SelectedIndex = 0;
            txt2OrderNo.Text = "";
            ddl2VendorTypeID.SelectedIndex = 0;
            txt2VendorName.Text = "";
            txt2ReceivedDateFrom.Text = "";
            txt2ReceivedDateTo.Text = "";
            ddlStatusID.SelectedIndex = 0;
            ddl2ReceivedBy.SelectedIndex = 0;
            txt2ReceivedNo.Text = "";
            lbl2result.Text = "";
            lbl2totalrecords.Text = "";
            ddl2_show.SelectedIndex = 0;
            Gv_StockReceivedList.DataSource = null;
            Gv_StockReceivedList.DataBind();
            Gv_StockReceivedList.Visible = false;
        }
    }
}