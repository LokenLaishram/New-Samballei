using System;
using System.Collections.Generic;
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
using DocumentFormat.OpenXml.Wordprocessing;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class WorkOrder : BasePage
    {
        decimal SumCopies = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                txtSysGenOrderNo.Attributes["disabled"] = "disabled";
                txtTotalCopies.Attributes["disabled"] = "disabled";
                //--TAB-2--//                              
                CKEditorHeader.config.height = "98px";
                CKEditorFooter.config.height = "120px";
                //AddItem();
                Session.Remove("Itemlist");
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlOrderType, mstlookup.GetLookupsList(LookupNames.OrderType));
            //---TAB-2---//
            Commonfunction.PopulateDdl(ddl2OrderType, mstlookup.GetLookupsList(LookupNames.OrderType));
            AutoCompleteExtender1.ContextKey = Convert.ToInt32(LoginToken.AcademicSessionID).ToString();
            AutoCompleteExtender3.ContextKey = Convert.ToInt32(LoginToken.AcademicSessionID).ToString();
        }

        protected void btntab1_Onclick(object sender, EventArgs e)
        {
            tabWorkOrder.Visible = true;
            tabWorkOrderlist.Visible = false;
        }
        protected void btntab2_Onclick(object sender, EventArgs e)
        {
            tabWorkOrder.Visible = false;
            tabWorkOrderlist.Visible = true;
        }
        protected void ddlOrderType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            bindTemplate(1);
        }
        protected void ddlOrderTemplateID_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            bindTemplate(1);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindTemplate(1);
        }
        private void bindTemplate(int index)
        {
            if (ddlOrderType.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select order type.") + "')", true);
                return;
            }

            WorkOrderData objdata = new WorkOrderData();
            WorkOrderBO objOrderTypeBO = new WorkOrderBO();
            objdata.OrderTypeID = Convert.ToInt32(ddlOrderType.Text == "" ? "0" : ddlOrderType.Text);
            objdata.OrderTemplateID = Convert.ToInt32(ddlOrderTemplateID.Text == "" ? "0" : ddlOrderTemplateID.Text);

            List<WorkOrderData> Result = objOrderTypeBO.SearchOrderTemplate(objdata);
            if (Result.Count > 0)
            {
                CKEditorHeader.Text = "";
                CKEditorFooter.Text = "";
                CKEditorHeader.Text = Result[0].TemplateHeader;
                CKEditorFooter.Text = Result[0].TemplateFooter;
            }
            else
            {
                CKEditorHeader.Text = "";
                CKEditorFooter.Text = "";
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetVendorDetails(string prefixText, int count, string contextKey)
        {
            WorkOrderData objdata = new WorkOrderData();
            WorkOrderBO objBO = new WorkOrderBO();
            List<WorkOrderData> getResult = new List<WorkOrderData>();
            objdata.VendorDetail = prefixText;
            objdata.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = objBO.GetAutoVendorDetails(objdata);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].VendorDetail.ToString());
            }
            return list;
        }
        protected void txtVendorName_OnTextChanged(object sender, EventArgs e)
        {
            if (txtVendorName.Text != "")
            {
                WorkOrderData objdata = new WorkOrderData();
                WorkOrderBO objBO = new WorkOrderBO();
                var source = txtVendorName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.VendorID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                    hdnvendorid.Value = ID ;
                }
                else
                {
                    txtVendorName.Text = "";
                    return;
                }
                //List<WorkOrderData> result = objBO.GetVendorDetailByID(objdata);
                //if (result.Count > 0)
                //{
                //    hdnvendorid.Value = result[0].VendorID.ToString();
                //}
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemDetails(string prefixText, int count, string contextKey)
        {
            WorkOrderData ObjData = new WorkOrderData();
            WorkOrderBO ObjBO = new WorkOrderBO();
            List<WorkOrderData> getResult = new List<WorkOrderData>();
            ObjData.ItemDetails = prefixText;
            ObjData.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoItemDetails(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemDetails.ToString());
            }
            return list;
        }
        protected void txtitemdetail_OnTextChanged(object sender, EventArgs e)
        {
            if (txtitemdetail.Text != "")
            {
                WorkOrderData objdata = new WorkOrderData();
                WorkOrderBO ObjBO = new WorkOrderBO();
                var source = txtitemdetail.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.ItemID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                }
                else
                {
                    txtitemdetail.Text = "";
                }
                List<WorkOrderData> result = ObjBO.GetItemDetailByID(objdata);
                if (result.Count > 0)
                {
                    hdnItemName.Value = result[0].ItemName.ToString();
                    hdnsubgroupid.Value = result[0].SubGroupID.ToString();
                    hdnitemid.Value = result[0].ItemID.ToString();
                }
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            AddItem();            
        }

        protected void AddItem()
        {
            WorkOrderData objdata = new WorkOrderData();
            WorkOrderBO ObjBO = new WorkOrderBO();

            var source = txtitemdetail.Text.ToString();
            if (txtitemdetail.Text != "")
            {
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                List<WorkOrderData> Itemlist = Session["Itemlist"] == null ? new List<WorkOrderData>() : (List<WorkOrderData>)Session["Itemlist"];
                WorkOrderData objItem = new WorkOrderData();
                
                objItem.ItemID = Convert.ToInt32(hdnitemid.Value == "" ? "0" : hdnitemid.Value);
                objItem.SubGroupID = Convert.ToInt32(hdnsubgroupid.Value == "" ? "0" : hdnsubgroupid.Value);
                objItem.Size = txtsize.Text.Trim();
                objItem.NoOfPage = Convert.ToInt32(txtnoofpage.Text.Trim() == "" ? "0" : txtnoofpage.Text.Trim());
                objItem.NoOfCopies = Convert.ToInt32(txtnoofcopy.Text.Trim() == "" ? "0" : txtnoofcopy.Text.Trim());
                objItem.NoOfIssuePaper = txtnoissuepaper.Text.Trim();
                objItem.ItemName = hdnItemName.Value.ToString();

                Itemlist.Add(objItem);

                if (Itemlist.Count > 0)
                {
                    GvWorkOrder.DataSource = Itemlist;
                    GvWorkOrder.DataBind();
                    GvWorkOrder.Visible = true;
                    Session["Itemlist"] = Itemlist;
                    btnsave.Attributes.Remove("disabled");
                    txtsize.Text = "";
                    txtnoofpage.Text = "";
                    txtnoofcopy.Text = "";
                    txtnoissuepaper.Text = "";
                    txtitemdetail.Text = "";
                    txtitemdetail.Focus();
                    TotalCalculate();
                    GvWorkOrder.Visible = true;
                }
                else
                {
                    GvWorkOrder.DataSource = null;
                    GvWorkOrder.DataBind();
                    GvWorkOrder.Visible = true;
                    btnsave.Attributes["disabled"] = "disable";
                    GvWorkOrder.Visible = false;
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
        }

        public void TotalCalculate()
        {
            int TotalCopies = 0;
            foreach (GridViewRow row in GvWorkOrder.Rows)
            {
                Label lblItemid = (Label)row.Cells[0].FindControl("lblItemid");
                Label lblNoOfCopies = (Label)row.Cells[0].FindControl("lblNoOfCopies");
                //TextBox Copies = (TextBox)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("txtgvNoOfCopies");
                TotalCopies = TotalCopies + Convert.ToInt32(lblNoOfCopies.Text);
            }
            SumCopies = TotalCopies;
            txtTotalCopies.Text = TotalCopies.ToString();
        }
        protected void GvWorkOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    if (i > 0)
                    {
                        GridViewRow gr = GvWorkOrder.Rows[i];
                        List<WorkOrderData> ItemList = Session["Itemlist"] == null ? new List<WorkOrderData>() : (List<WorkOrderData>)Session["Itemlist"];
                        ItemList.RemoveAt(i);
                        Session["Itemlist"] = ItemList;
                        GvWorkOrder.DataSource = ItemList;
                        GvWorkOrder.DataBind();
                        TotalCalculate();
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
        protected void Copies_OnTextChanged(object sender, EventArgs e)
        {
            TotalCalculate();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                //if (LoginToken.SaveEnable == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("saveenable") + "')", true);
                //    return;
                //}
                if (ddlOrderType.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select order type.") + "')", true);
                    return;
                }
                if (txtOrderNo.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter order number.") + "')", true);
                    return;
                }
                if (txtOrderDate.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select order date.") + "')", true);
                    return;
                }
                if (txtAddressTitle.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter address title.") + "')", true);
                    return;
                }
                if (txtVendorName.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter vendor name.") + "')", true);
                    return;
                }
                if (txtSubject.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter subject.") + "')", true);
                    return;
                }
                if (txt_DeliveryDate.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select dilevery date.") + "')", true);
                    return;
                }
                if (ddlPrintModeID.SelectedValue == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select printing mode.") + "')", true);
                    return;
                }
                int index = 0;
                List<WorkOrderData> list = new List<WorkOrderData>();
                WorkOrderBO ObjBO = new WorkOrderBO();
                WorkOrderData ObjData = new WorkOrderData();
                List<WorkOrderData> Resultlist = new List<WorkOrderData>();
                foreach (GridViewRow row in GvWorkOrder.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label lblItemid = (Label)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("lblItemid");
                    Label lblItemname = (Label)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("lblItemname");
                    Label lblSize = (Label)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("lblSize");
                    Label lblNoOfPage = (Label)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("lblNoOfPage");
                    Label lblNoOfCopies = (Label)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("lblNoOfCopies");
                    Label lblNoOfIssuePaper = (Label)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("lblNoOfIssuePaper");
                    Label lblsubgroupid = (Label)GvWorkOrder.Rows[row.RowIndex].Cells[0].FindControl("lblsubgroupid");

                    WorkOrderData ObjDetails = new WorkOrderData();
                    ObjDetails.ItemID = Convert.ToInt32(lblItemid.Text == "" ? "0" : lblItemid.Text);
                    ObjDetails.Size = lblSize.Text == "" ? "0" : lblSize.Text;
                    ObjDetails.NoOfPage = Convert.ToInt32(lblNoOfPage.Text.Trim() == "" ? "0" : lblNoOfPage.Text.Trim());
                    ObjDetails.NoOfCopies = Convert.ToInt32(lblNoOfCopies.Text.Trim() == "" ? "0" : lblNoOfCopies.Text.Trim());
                    ObjDetails.NoOfIssuePaper = lblNoOfIssuePaper.Text == "" ? "0" : lblNoOfIssuePaper.Text;
                    ObjDetails.SubGroupID = Convert.ToInt32(lblsubgroupid.Text.Trim() == "" ? "0" : lblsubgroupid.Text.Trim());

                    list.Add(ObjDetails);
                    index++;
                }
                ObjData.XMLData = XmlConvertor.WorkOrderItemListXML(list).ToString();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime OrderDate = txtOrderDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtOrderDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                DateTime DeliveryDate = txt_DeliveryDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_DeliveryDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                ObjData.OrderDate = OrderDate;
                ObjData.DeliverDate = DeliveryDate;
                ObjData.OrderTypeID = Convert.ToInt32(ddlOrderType.SelectedValue == "" ? "0" : ddlOrderType.SelectedValue);
                ObjData.WorkOrderNo = txtOrderNo.Text == "" ? "0" : txtOrderNo.Text;
                ObjData.OrderTemplateID = Convert.ToInt32(ddlOrderTemplateID.SelectedValue == "" ? "0" : ddlOrderTemplateID.SelectedValue);
                ObjData.AddressTitle = txtAddressTitle.Text == "" ? "0" : txtAddressTitle.Text;
                ObjData.Subject = txtSubject.Text == "" ? "0" : txtSubject.Text;
                ObjData.VendorID = Convert.ToInt32(hdnvendorid.Value == "" ? "0" : hdnvendorid.Value);
                ObjData.TemplateHeader = CKEditorHeader.Text == "" ? "0" : CKEditorHeader.Text;
                ObjData.TemplateFooter = CKEditorFooter.Text == "" ? "0" : CKEditorFooter.Text;
                ObjData.TotalCopies = Convert.ToInt32(txtTotalCopies.Text == "" ? "0" : txtTotalCopies.Text);
                ObjData.PrintModeID = Convert.ToInt32(ddlPrintModeID.Text == "" ? "0" : ddlPrintModeID.Text);
                ObjData.OrderDescription = txtDescription.Text == "" ? "0" : txtDescription.Text;

                ObjData.EmployeeID = LoginToken.EmployeeID;
                ObjData.AcademicSessionID = LoginToken.AcademicSessionID;
                ObjData.CompanyID = LoginToken.CompanyID;
                ObjData.ActionType = EnumActionType.Insert;
                if (ViewState["SWONo"] != null)
                {
                    ObjData.ActionType = EnumActionType.Update;
                    ObjData.SysGenWorkOrderNo = ViewState["SWONo"].ToString();
                }
                else
                {
                    ObjData.SysGenWorkOrderNo = "0";
                }
                Resultlist = ObjBO.SaveWorkOrderGeneration(ObjData);
                if (Resultlist.Count > 0)
                {
                    txtSysGenOrderNo.Text = Resultlist[0].SysGenWorkOrderNo.ToString();
                    btnsave.Attributes["disabled"] = "disabled";
                    btnprint.Attributes.Remove("disabled");
                    Session["OrderItemList"] = null;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnsave.Attributes.Remove("disabled");
                    btnprint.Attributes["disabled"] = "disabled";
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
        protected void btn_Clear(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            Session["ItemList"] = null;
            GvWorkOrder.DataSource = null;
            GvWorkOrder.DataBind();
        }
        protected void btn_Reset(object sender, EventArgs e)
        {
            Clear();
            ddlOrderType.SelectedIndex = 0;
            txtAddressTitle.Text = "";
            txtSubject.Text = "";
            txtOrderNo.Text = "";
            txtVendorName.Text = "";
            txtOrderDate.Text = "";
            ddlPrintModeID.SelectedIndex = 0;
            txt_DeliveryDate.Text = "";
            txtDescription.Text = "";
            txtSysGenOrderNo.Text = "";
            txtTotalCopies.Text = "";
            GvWorkOrder.Visible = false;
            ViewState["SWONo"] = null;
            btnsave.Text = "Save";
        }

        //--TAB-2--

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btn2Search_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(dll2Show.SelectedValue == "10000" ? lbl2totalrecords.Text : dll2Show.SelectedValue);
            List<WorkOrderData> lstindent = getWorkOrderList(index, pagesize);
            if (lstindent.Count > 0)
            {
                GvWorkOrderlist.PageSize = pagesize;
                string record = lstindent[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";               
                lbl2totalrecords.Text = lstindent[0].MaximumRows.ToString();
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
            WorkOrderBO ObjBO = new WorkOrderBO();
            WorkOrderData ObjData = new WorkOrderData();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt2DateForm.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt2DateForm.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt2DateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt2DateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            ObjData.Datefrom = DateFrom;
            ObjData.Dateto = DateTo;
            ObjData.OrderTypeID = Convert.ToInt32(ddl2OrderType.SelectedValue == "" ? "0" : ddl2OrderType.SelectedValue);
            ObjData.VendorID = Commonfunction.SemicolonSeparation_String_32(txt2VendorName.Text == "" ? "0" : txt2VendorName.Text);
            ObjData.WorkOrderNo = txt2OrderNo.Text == "" ? "0" : txt2OrderNo.Text;
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
                if (e.CommandName == "lnkEdit")
                {
                    //if (LoginToken.EditEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("editenable") + "')", true);
                    //    return;
                    //}
                    WorkOrderData objdata = new WorkOrderData();
                    WorkOrderBO objBO = new WorkOrderBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvWorkOrderlist.Rows[i];
                    Label lblOrderNo = (Label)gr.Cells[0].FindControl("lbl2GvSysGenOrderNo");

                    List<WorkOrderData> dataList = new List<WorkOrderData>();
                    List<WorkOrderData> EditWOItemList = Session["ItemList"] == null ? new List<WorkOrderData>() : (List<WorkOrderData>)Session["ItemList"];
                    objdata.SysGenWorkOrderNo = lblOrderNo.Text.Trim() == "" ? null : lblOrderNo.Text.Trim();
                    dataList = objBO.GetWorkOrderDetailsByWONo(objdata);
                    if (dataList.Count > 0)
                    {
                        //if (dataList[0].Output == 1)  // can be edit or delete
                        //{
                            ddlOrderType.SelectedValue = dataList[0].OrderTypeID.ToString();
                            ddlOrderTemplateID.SelectedValue = dataList[0].OrderTemplateID.ToString();
                            txtOrderNo.Text = dataList[0].WorkOrderNo;
                            txtOrderDate.Text = dataList[0].OrderDate.ToString();
                            txtAddressTitle.Text = dataList[0].AddressTitle;
                            txtVendorName.Text = dataList[0].VendorName;
                            txtSubject.Text = dataList[0].Subject;
                            CKEditorHeader.Text = dataList[0].TemplateHeader;
                            CKEditorFooter.Text = dataList[0].TemplateHeader;
                            txt_DeliveryDate.Text = dataList[0].DeliverDate.ToString();
                            ddlPrintModeID.SelectedValue = dataList[0].PrintModeID.ToString();
                            txtSysGenOrderNo.Text = dataList[0].SysGenWorkOrderNo.ToString();
                            txtDescription.Text = dataList[0].OrderDescription.ToString();

                            GvWorkOrder.DataSource = dataList;
                            GvWorkOrder.DataBind();
                            GvWorkOrder.Visible = true;
                            Session["ItemList"] = dataList;
                            btnsave.Attributes.Remove("disabled");
                            btnsave.Text = "Update";
                            TotalCalculate();
                            ViewState["SWONo"] = dataList[0].SysGenWorkOrderNo;
                            tabWorkOrder.Visible = true;
                            tabWorkOrderlist.Visible = false;
                        //}
                        //else if (dataList[0].Output == 2) // The particular work order have already process, cannot be edit or delete
                        //{
                        //    tabWorkOrder.Visible = false;
                        //    tabWorkOrderlist.Visible = true;
                        //    bindgrid(1);
                        //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Work Order cannot be modified, it have already proceed") + "')", true);
                        //    return;
                        //}
                    }
                    else
                    {
                        GvWorkOrder.DataSource = null;
                        GvWorkOrder.DataBind();
                        GvWorkOrder.Visible = false;
                    }
                }
                if (e.CommandName == "Print")
                {
                    //if (LoginToken.PrintEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                    //    return;
                    //}
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvWorkOrderlist.Rows[i];
                    Label lblOrderNo = (Label)gr.Cells[0].FindControl("lbl2GvSysGenOrderNo");

                    string ONo = lblOrderNo.Text.Trim() == "" ? null : lblOrderNo.Text.Trim();
                    PrintWorkOrder(ONo);
                }

                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    return;
                    //}
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvWorkOrderlist.Rows[i];
                    Label OrderNo = (Label)gr.Cells[0].FindControl("lbl2GvSysGenOrderNo");
                    txtPopWONo.Text = OrderNo.Text.Trim() == "" ? "0" : OrderNo.Text.Trim();
                    lblpopMessage.Visible = false;
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
        protected void BtnPopDelete_OnClick(object sender, EventArgs e)
        {
            WorkOrderData obj = new WorkOrderData();
            WorkOrderBO objBO = new WorkOrderBO();
            obj.SysGenWorkOrderNo = txtPopWONo.Text.Trim() == "" ? "0" : txtPopWONo.Text.Trim();
            string txtremarks = txtpopRemark.Text == "" ? "0" : txtpopRemark.Text;
            if (txtremarks.Trim() == "")
            {
                lblpopMessage.Text = "Please enter remark";
                lblpopMessage.Visible = true;
                txtpopRemark.Focus();

                return;
            }
            else
            {
                obj.Remark = txtpopRemark.Text == "" ? "0" : txtpopRemark.Text;
                lblpopMessage.Visible = false;
            }
            obj.EmployeeID = LoginToken.EmployeeID;
            int Result = objBO.DeleteWorkOrdeByWONo(obj);
            if (Result == 1)
            {
                lblpopMessage.Text = "Successfully deleted";
                lblpopMessage.Visible = true;
                bindgrid(1);
                this.DeletePopup.Show();
            }
            else if (Result == 2)
            {
                lblpopMessage.Text = "This work order cannot be deleted, it have already approved.";
                lblpopMessage.Visible = true;
                bindgrid(1);
                this.DeletePopup.Show();
            }
            else
            {
                lblpopMessage.Text = "System Error";
                lblpopMessage.Visible = true;
                this.DeletePopup.Show();
            }
        }

        protected void btnDeletePopClose(object sender, EventArgs e)
        {
            this.DeletePopup.Hide();
        }
        protected void BtnPrint_OnClick(object sender, EventArgs e)
        {
            string ONo = txtSysGenOrderNo.Text.Trim() == "" ? "0" : txtSysGenOrderNo.Text.Trim();
            PrintWorkOrder(ONo);
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
        protected void btn2Reset_OnClick(object sender, EventArgs e)
        {
            ddl2OrderType.SelectedIndex = 0;
            txt2OrderNo.Text = "";
            txt2VendorName.Text = "";
            ddlStatus.SelectedIndex = 0;
            txt2DateForm.Text = "";
            txt2DateTo.Text = "";
            txtPopWONo.Text = "";
            txtpopRemark.Text = "";
            lblpopMessage.Text = "";
            GvWorkOrderlist.DataSource = null;
            GvWorkOrderlist.DataBind();
            GvWorkOrderlist.Visible = false;
            ViewState["SWONo"] = null;
            btnsave.Text = "Save";
        }
    }
}