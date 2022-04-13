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
using System.Globalization;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class StockEntryWithoutPO : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                Session["StockEntryList"] = null;
                txt_ItemName.Attributes["disabled"] = "disabled";
                btnSave.Attributes["disabled"] = "disabled";
                btnPrint.Attributes["disabled"] = "disabled";
                ddl_SubGroup.Attributes["disabled"] = "disabled";
                txt_EquivalentQty.Text = "1";
                txt2ItemName.Attributes["disabled"] = "disabled";
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_Group, mstlookup.GetLookupsList(LookupNames.Group));
            Commonfunction.PopulateDdl(ddl_VendorType, mstlookup.GetLookupsList(LookupNames.VendorType));           
            AutoCompleteExtender1.ContextKey = "1";
           Commonfunction.PopulateDdl(ddl_ConvertingUnit, mstlookup.GetLookupsList(LookupNames.Units));
            Commonfunction.PopulateDdl(ddlBatchYearID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlBatchYearID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddl_VendorName, mstlookup.GetLookupsList(LookupNames.VendorName));
            txt_ExpiryDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtStkReceivedDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            //-----Tab2-----//
            Commonfunction.PopulateDdl(ddl2VandorName, mstlookup.GetLookupsList(LookupNames.VendorName));
            Commonfunction.PopulateDdl(ddl2SubGroupID, mstlookup.GetLookupsList(LookupNames.SubGroup));
            txt2DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt2DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
        }
        protected void ddl_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Group.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_SubGroup, mstlookup.GetInvSubGroupByID(Convert.ToInt32(ddl_Group.SelectedValue == "" ? "0" : ddl_Group.SelectedValue)));
                ddl_SubGroup.Attributes.Remove("disabled");
            }
            else
            {
                ddl_SubGroup.SelectedIndex = 0;
                ddl_SubGroup.Attributes["disabled"] = "disabled";
            }
        }
        protected void ddl_VendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PressNameList();
        }
        protected void PressNameList()
        {
            if (ddl_VendorType.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_VendorName, mstlookup.GetVendorByID(Convert.ToInt32(ddl_VendorType.SelectedValue == "" ? "0" : ddl_VendorType.SelectedValue)));
            }
            else
            {
                ddl_VendorType.SelectedIndex = 0;
            }
        }
        protected void ddl_SubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_SubGroup.SelectedIndex > 0)
            {
                txt_ItemName.Text = "";
                txt_ItemName.Attributes.Remove("disabled");
                AutoCompleteExtender1.ContextKey = ddl_SubGroup.SelectedValue == "" ? "0" : ddl_SubGroup.SelectedValue;
                Clear();
            }
            else
            {
                txt_ItemName.Text = "";
                txt_ItemName.Attributes["disabled"] = "disabled";
                Clear();
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemName(string prefixText)
        {
            WorkOrderData ObjData = new WorkOrderData();
            WorkOrderBO ObjBO = new WorkOrderBO();
            List<WorkOrderData> getResult = new List<WorkOrderData>();
            ObjData.ItemDetails = prefixText;
           // ObjData.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoItemDetails(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemDetails.ToString());
            }
            return list;
        }
        protected void txt_ItemName_TextChanged(object sender, EventArgs e)
        {
            string ID;
            var source = txt_ItemName.Text.ToString();
            if (source.Contains(":"))
            {
                ID = source.Substring(source.LastIndexOf(':') + 1);
                StockEntryWithoutPOData objData = new StockEntryWithoutPOData();
                StockEntryWithoutPOBO objBO = new StockEntryWithoutPOBO();
                List<StockEntryWithoutPOData> getResult = new List<StockEntryWithoutPOData>();
                objData.ItemID = Convert.ToInt32(ID);
                objData.YearID = Convert.ToInt32(ddlBatchYearID.SelectedValue == "" ? "0" : ddlBatchYearID.SelectedValue);
                getResult = objBO.GetItemNameWithPrice(objData);
                if (getResult.Count > 0)
                {
                    lbl_GetItemName.Text = getResult[0].ItemName;
                    lbl_ItemID.Text = getResult[0].ItemID.ToString();
                    txtUnit.Text = getResult[0].Unit.ToString();
                    ddl_ConvertingUnit.SelectedValue = getResult[0].UnitID.ToString();
                    txt_Price.Text = getResult[0].Price.ToString();
                    lbl_YearID.Text = getResult[0].YearID.ToString();
                    lbl_YearName.Text = getResult[0].YearName.ToString();
                    txt_Quantity.Focus();
                }
            }
            else
            {
                txt_ItemName.Text = "";
                txt_ItemName.Focus();
                return;
            }
        }
        protected void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_Quantity.Text != "" || txt_Quantity.Text == "0")
            {
                txt_EquivalentQty.Focus();
                txt_EquivalentQty.Text = "1";
            }
            else
            {
                txt_Quantity.Focus();
                txt_EquivalentQty.Text = "1";
                return;
            }
        }
        protected void txt_EquivalentQty_TextChanged(object sender, EventArgs e)
        {
            if (txt_EquivalentQty.Text != "" || txt_EquivalentQty.Text == "0")
            {
                int netqty = Convert.ToInt32(txt_NetQnty.Text == "" ? "0" : txt_NetQnty.Text);
                netqty = Convert.ToInt32(txt_Quantity.Text) * Convert.ToInt32(txt_EquivalentQty.Text);
                txt_NetQnty.Text = netqty.ToString();
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            else
            {
                lblmessage.Text = "Please Enter Equivalent Quantity";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                txt_EquivalentQty.Text = "1";
                txt_EquivalentQty.Focus();
                return;
            }
        }
        protected void btnClear(object sender, EventArgs e)
        {
            Clear();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddl_VendorType.SelectedIndex == 0)
            {
                ddl_VendorType.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Select Vendor Type.") + "')", true);
                return;
            }
            if (ddl_VendorName.SelectedIndex == 0)
            {
                ddl_VendorName.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Select Vendor Name.") + "')", true);
                return;
            }
            if (ddl_Group.SelectedIndex == 0)
            {
                ddl_Group.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Select Group.") + "')", true);
                return;
            }
            if (ddl_SubGroup.SelectedIndex == 0)
            {
                ddl_SubGroup.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Select Sub Group.") + "')", true);
                return;
            }

            if (txt_ItemName.Text == "")
            {
                txt_ItemName.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Item Name.") + "')", true);
                return;
            }
            if (txt_Price.Text == "")
            {
                lblmessage.Visible = true;
                txt_ItemName.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Price shouldn't be blank. Please set the item price in price master page.") + "')", true);
                return;
            }
            if (txt_Quantity.Text == "")
            {
                txt_Quantity.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Quantity.") + "')", true);
                return;
            }
            if (ddl_ConvertingUnit.SelectedIndex == 0)
            {
                ddl_ConvertingUnit.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Select Unit which to be convert.") + "')", true);
                return;
            }
            if (txt_EquivalentQty.Text == "")
            {
                txt_EquivalentQty.Text = "1";
                txt_EquivalentQty.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Equavalent Qty") + "')", true);
                return;
            }
            //if (txt_ExpiryDate.Text == "")
            //{
            //    lblmessage.Text = "Please Enter Expiry Date";
            //    lblmessage.ForeColor = System.Drawing.Color.Red;
            //    txt_ExpiryDate.Focus();
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Expiry Date") + "')", true);
            //    return; 
            //}
            if (txtStkReceivedDate.Text == "")
            {
                lblmessage.Text = "Please Enter Stock Received Date";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                txtStkReceivedDate.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Stock Received Date") + "')", true);
                return; 
            }

            string ID;
            var source = txt_ItemName.Text.ToString();
            if (source.Contains(":"))
            {
                ID = source.Substring(source.LastIndexOf(':') + 1);
                // Check Duplicate data 
                foreach (GridViewRow row in Gv_StockEntryWithoutPO.Rows)
                {
                    Label ItemID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_ItemID");
                    if (Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text) == Convert.ToInt32(ID == "" || ID == null ? "0" : ID))
                    {
                        txt_ItemName.Text = "";
                        txt_Price.Text = "";
                        txt_Quantity.Text = "";
                        ddl_ConvertingUnit.SelectedIndex = 0;
                        txt_NetQnty.Text = "";
                       // txt_ExpiryDate.Text = "";
                        lblmessage.Text = "Already added to the list.";
                        lblmessage.ForeColor = System.Drawing.Color.Red;
                        lblmessage.Visible = true;
                        txt_ItemName.Focus();
                        return;
                    }
                    else
                    {
                        lblmessage.Visible = false;
                        lblmessage.Text = "";
                    }
                }
            }
            else
            {
                txt_ItemName.Text = "";
                txt_Price.Text = "";
                txt_Quantity.Text = "";
                ddl_ConvertingUnit.SelectedIndex = 0;
                txt_NetQnty.Text = "";
               // txt_ExpiryDate.Text = "";
                return;
            }

            List<StockEntryWithoutPOData> StockEntryList = Session["StockEntryList"] == null ? new List<StockEntryWithoutPOData>() : (List<StockEntryWithoutPOData>)Session["StockEntryList"];
            StockEntryWithoutPOData ObjStockData = new StockEntryWithoutPOData();
            //ObjStockData.YearID = Convert.ToInt32(ddl_Year.SelectedValue == "" ? "0" : ddl_Year.SelectedValue);
            //ObjStockData.YearName = ddl_Year.SelectedItem.Text == "" ? "" : ddl_Year.SelectedItem.Text;
            ObjStockData.YearID = Convert.ToInt32(lbl_YearID.Text == "" ? "0" : lbl_YearID.Text);
            ObjStockData.YearName = lbl_YearName.Text == "" ? "" : lbl_YearName.Text;
            ObjStockData.GroupID = Convert.ToInt32(ddl_Group.SelectedValue == "" ? "0" : ddl_Group.SelectedValue);
            ObjStockData.SubGroupID = Convert.ToInt32(ddl_SubGroup.SelectedValue == "" ? "0" : ddl_SubGroup.SelectedValue);
            ObjStockData.VendorTypeID = Convert.ToInt32(ddl_VendorType.SelectedValue == "" ? "0" : ddl_VendorType.SelectedValue);
            ObjStockData.VendorID = Convert.ToInt32(ddl_VendorName.SelectedValue == "" ? "0" : ddl_VendorName.SelectedValue);
            ObjStockData.ItemID = Convert.ToInt32(ID == "" || ID == null ? "0" : ID);
            ObjStockData.ItemName = lbl_GetItemName.Text.Trim();
            ObjStockData.Price = Convert.ToDecimal(txt_Price.Text == "" ? "0" : txt_Price.Text);
            ObjStockData.Quantity = float.Parse(txt_Quantity.Text, CultureInfo.InvariantCulture.NumberFormat);
            ObjStockData.TotalPrice = Convert.ToDecimal(txt_TotalPrice.Text == "" ? "0" : txt_TotalPrice.Text);
            ObjStockData.ConvertingUnitID = Convert.ToInt32(ddl_ConvertingUnit.SelectedValue == "" ? "0" : ddl_ConvertingUnit.SelectedValue);
            ObjStockData.ConvertingUnitName = ddl_ConvertingUnit.SelectedItem.Text.Trim();
            ObjStockData.EquivalentQty = Convert.ToInt32(txt_EquivalentQty.Text == "" ? "0" : txt_EquivalentQty.Text);
            ObjStockData.NetQuantity = Convert.ToInt32(txt_NetQnty.Text == "" ? "0" : txt_NetQnty.Text);
            //IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            //DateTime ExpDate = txt_ExpiryDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_ExpiryDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
           
            //ObjStockData.Expirydate = ExpDate.ToString().Trim();
           

            StockEntryList.Add(ObjStockData);
            if (StockEntryList.Count > 0)
            {
                Gv_StockEntryWithoutPO.DataSource = StockEntryList;
                Gv_StockEntryWithoutPO.DataBind();
                Gv_StockEntryWithoutPO.Visible = true;
                Session["StockEntryList"] = StockEntryList;
                bindresponsive();
                Clear();
                txt_ItemName.Focus();
                btnSave.Attributes.Remove("disabled");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_VendorName.SelectedIndex == 0)
                {
                    ddl_VendorName.Focus();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Select Vendor Name.") + "')", true);
                    return;
                }
                List<StockEntryWithoutPOData> list = new List<StockEntryWithoutPOData>();
                StockEntryWithoutPOBO objBO = new StockEntryWithoutPOBO();
                StockEntryWithoutPOData obj = new StockEntryWithoutPOData();
                List<StockEntryWithoutPOData> result = new List<StockEntryWithoutPOData>();
                foreach (GridViewRow row in Gv_StockEntryWithoutPO.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label YearID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_YearID");
                    Label YearName = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_YearName");
                    Label GroupID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_GroupID");
                    Label SubGroupID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_SubGroupID");
                    Label VendorTypeID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_VendorTypeID");
                    Label VendorID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_VendorID");
                    Label ItemID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_ItemID");
                    Label Price = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGvPrice");
                    Label Quantity = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGvQty");
                    Label TotalPrice = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGvTotalPrice");
                   // Label GvExpiryDate = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGvExpiryDate");

                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    // DateTime ExpiryDate = GvExpiryDate.Text == "" ? System.DateTime.Now : DateTime.Parse(GvExpiryDate.Text, option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    Label ConvertingUnitID = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_CUnitID");
                    Label NetQuantity = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGvNetQuantity");
                    Label EquivalentQty = (Label)Gv_StockEntryWithoutPO.Rows[row.RowIndex].Cells[0].FindControl("lblGv_EquivalentQty");

                    StockEntryWithoutPOData ObjDetails = new StockEntryWithoutPOData();

                    ObjDetails.GroupID = Convert.ToInt32(GroupID.Text == "" ? "0" : GroupID.Text);
                    ObjDetails.SubGroupID = Convert.ToInt32(SubGroupID.Text == "" ? "0" : SubGroupID.Text);
                    ObjDetails.VendorTypeID = Convert.ToInt32(VendorTypeID.Text == "" ? "0" : VendorTypeID.Text);
                    ObjDetails.VendorID = Convert.ToInt32(VendorID.Text == "" ? "0" : VendorID.Text);
                    ObjDetails.ItemID = Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text);
                    ObjDetails.Quantity = Convert.ToInt32(Quantity.Text == "" ? "0" : Quantity.Text);
                    ObjDetails.ConvertingUnitID = Convert.ToInt32(ConvertingUnitID.Text.Trim());
                    ObjDetails.NetQuantity = Convert.ToInt32(NetQuantity.Text.Trim());
                   // ObjDetails.i = GvExpiryDate.Text.Trim();
                    ObjDetails.Price = Convert.ToDecimal(Price.Text == "" ? "0" : Price.Text);
                    ObjDetails.YearID = Convert.ToInt32(YearID.Text);
                    ObjDetails.YearName = YearName.Text.Trim();
                    ObjDetails.EquivalentQty = Convert.ToInt32(EquivalentQty.Text == "" ? "0" : EquivalentQty.Text);
                    ObjDetails.TotalPrice = Convert.ToDecimal(TotalPrice.Text == "" ? "0" : TotalPrice.Text);
                    list.Add(ObjDetails);

                }
                obj.XMLData = XmlConvertor.StockEntryWithoutPOListXML(list).ToString();
                IFormatProvider option2 = new System.Globalization.CultureInfo("en-GB", true);
                DateTime RecvDate = txtStkReceivedDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtStkReceivedDate.Text.Trim(), option2, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                obj.StkReceivedDate = RecvDate;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                result= objBO.SaveStockWithoutPO(obj);
                if (result.Count > 0)
                {
                    txt_ReceiptNo.Text = result[0].StockStatus.ToString(); ;
                    Session["StockEntryList"] = null;
                    btnSave.Attributes["disabled"] = "disabled";
                    btnPrint.Attributes.Remove("disabled");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_StockEntryWithoutPO.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_StockEntryWithoutPO.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_StockEntryWithoutPO.UseAccessibleHeader = true;
            Gv_StockEntryWithoutPO.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            lblmessage.Text = "";
            ddl_Group.SelectedIndex = 0;
            ddl_SubGroup.SelectedIndex = 0;
            ddl_VendorType.SelectedIndex = 0;
            ddl_VendorName.SelectedIndex = 0;
            txt_ItemName.Text = "";
            txt_Quantity.Text = "";
            ddl_ConvertingUnit.SelectedIndex = 0;
            txt_NetQnty.Text = "";
            txt_ExpiryDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtStkReceivedDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_EquivalentQty.Text = "1";
            txt_TotalPrice.Text = "";
            txt_ItemName.Attributes["disabled"] = "disabled";
            btnSave.Attributes["disabled"] = "disabled";
            btnPrint.Attributes["disabled"] = "disabled";
            Gv_StockEntryWithoutPO.DataSource = null;
            Gv_StockEntryWithoutPO.DataBind();
            Gv_StockEntryWithoutPO.Visible = false;
            txt_ReceiptNo.Text = "";
            txtRemark.Text = "";           
            Clear();
        }
        private void Clear()
        {
            lblmessage.Text = "";
            txt_ItemName.Text = "";
            txtUnit.Text = "";
            txt_Price.Text = "";
            txt_Quantity.Text = "";
            ddl_ConvertingUnit.SelectedIndex = 0;
            txt_NetQnty.Text = "";
           // txt_ExpiryDate.Text = "";
            txt_TotalPrice.Text = "";
            txt_EquivalentQty.Text = "1";
        }
        protected void Gv_StockEntryWithoutPO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_StockEntryWithoutPO.Rows[i];
                    List<StockEntryWithoutPOData> StockList = Session["StockEntryList"] == null ? new List<StockEntryWithoutPOData>() : (List<StockEntryWithoutPOData>)Session["StockEntryList"];
                    StockList.RemoveAt(i);
                    Session["StockEntryList"] = StockList;
                    Gv_StockEntryWithoutPO.DataSource = StockList;
                    Gv_StockEntryWithoutPO.DataBind();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    bindresponsive();
            //    return;
            //}
            string ReceiptNo = HttpUtility.UrlEncode(UrlEncryptDecrypt.Encrypt(txt_ReceiptNo.Text.Trim()));
            string url = "../Stock/Report/Reportviewer.aspx?option=StockEntryWPOList&ReceiptNo=" + ReceiptNo;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }


        //----TAB2----//
        protected void ddl2SubGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl2SubGroupID.SelectedIndex > 0)
            {
                txt2ItemName.Text = "";
                txt2ItemName.Attributes.Remove("disabled");
                AutoCompleteExtender2.ContextKey = ddl2SubGroupID.SelectedValue == "" ? "0" : ddl2SubGroupID.SelectedValue;
               
            }
            else
            {
                txt2ItemName.Text = "";
                txt2ItemName.Attributes["disabled"] = "disabled";
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemNameAuto(string prefixText)
        {
            WorkOrderData ObjData = new WorkOrderData();
            WorkOrderBO ObjBO = new WorkOrderBO();
            List<WorkOrderData> getResult = new List<WorkOrderData>();
            ObjData.ItemDetails = prefixText;
            // ObjData.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoItemDetails(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemDetails.ToString());
            }
            return list;
        }
        protected void txt2ItemName_OnTextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btn2Search_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = 100000; //Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StockEntryWithoutPOData> StockList = GetStockStatus(index, pagesize);
            if (StockList.Count > 0)
            {
                Gv_GRNote.PageSize = pagesize;
                string record = StockList[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + StockList[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = StockList[0].MaximumRows.ToString();
                lbl2TotalReceivedQty.Text = StockList[0].NetRecievedQty.ToString();
                lblresult.Visible = true;
                Gv_GRNote.VirtualItemCount = StockList[0].MaximumRows;//total item is required for custom paging
                Gv_GRNote.PageIndex = index - 1;
                Gv_GRNote.DataSource = StockList;
                Gv_GRNote.DataBind();
                bindresponsive2();
            }
            else
            {
                Gv_GRNote.DataSource = null;
                Gv_GRNote.DataBind();
                lblresult.Text = "";
                lbl_totalrecords.Text = "";
                lbl2TotalReceivedQty.Text = "";
            }
        }
        public List<StockEntryWithoutPOData> GetStockStatus(int curIndex, int pagesize)
        {
            if (txt2ItemName.Text != "")
            {
                WorkOrderData objdata = new WorkOrderData();
                WorkOrderBO ObjBO = new WorkOrderBO();
                var source = txt2ItemName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.ItemID = Convert.ToInt32(ID == "" ? "0" : ID);
                }
            }
            StockEntryWithoutPOData objData = new StockEntryWithoutPOData();
            StockEntryWithoutPOBO objBO = new StockEntryWithoutPOBO();
            objData.VendorID = Convert.ToInt32(ddl_VendorName.SelectedValue == "" ? "0" : ddl_VendorName.SelectedValue);
            objData.SubGroupID = Convert.ToInt32(ddl2SubGroupID.SelectedValue == "" ? "0" : ddl2SubGroupID.SelectedValue);
            objData.ReceiptNo = txtReceivedNo.Text == "" ? "0" : txtReceivedNo.Text;            
            objData.ItemID = Commonfunction.SemicolonSeparation_String_64(txt2ItemName.Text.Trim());
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txt2DateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt2DateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime to = txt2DateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt2DateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objData.Datefrom = from;
            objData.Dateto = to;
            objData.IsActive = ddl2Status.SelectedValue == "1" ? true : false;
            objData.PageSize = pagesize;
            objData.CurrentIndex = curIndex;
            return objBO.GetGRNWithoutPOList(objData);
        }

        protected void Gv_GRNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_GRNote.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void Gv_GRNote_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    return;
                    //}
                    StockEntryWithoutPOData obj = new StockEntryWithoutPOData();
                    StockEntryWithoutPOBO objBO = new StockEntryWithoutPOBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_GRNote.Rows[i];
                    Label ReceiptNo = (Label)gr.Cells[0].FindControl("lb2ReceiptNo");
                    Label StockID = (Label)gr.Cells[0].FindControl("lblGv_StockID");
                    Label StockNo = (Label)gr.Cells[0].FindControl("lblGv_StockNo");                   
                    obj.ReceiptNo = ReceiptNo.Text.Trim();
                    obj.StockID = Convert.ToInt64(StockID.Text.Trim());
                    obj.StockNo = StockNo.Text.Trim();
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive2();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        obj.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    obj.EmployeeID = LoginToken.EmployeeID;
                    int Result = objBO.DeleteGRNoteByStockNo(obj);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else if (Result == 2)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Cannot be delete this stock number because indent have generated.") + "')", true);
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
        protected void btn2Reset_OnClick(object sender, EventArgs e)
        {
            Reset();
        }
        protected void Reset()
        {
            ddl2VandorName.SelectedIndex = 0;
            ddl2SubGroupID.SelectedIndex = 0;
            txt2ItemName.Text = "";
            txtReceivedNo.Text = "";
            txt2DateFrom.Text = "";
            txt2DateTo.Text = "";
            Gv_GRNote.DataSource = null;
            Gv_GRNote.DataBind();
            lblresult.Text = "";
            lbl_totalrecords.Text = "";
            lbl2TotalReceivedQty.Text = "";
            txt2DateFrom.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt2DateTo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
        }
        protected void bindresponsive2()
        {
            //Responsive 
            Gv_GRNote.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Gv_GRNote.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_GRNote.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_GRNote.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_GRNote.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //  Adds THEAD and TBODY to GridView.
            Gv_GRNote.UseAccessibleHeader = true;
            Gv_GRNote.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
    }
}