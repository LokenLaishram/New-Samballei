using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class IndentGeneration : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                Session.Remove("IndentList");
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_VendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
           
            Commonfunction.PopulateDdl(ddlVendorTypeID, mstlookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.Group));
            txt_VendorName.Attributes["disabled"] = "disabled";
            txtVendoName.Attributes["disabled"] = "disabled";
            ddl_subgroup.Attributes["disabled"] = "disabled";
            txt_ItemName.Attributes["disabled"] = "disabled";
            txtunit.Attributes["disabled"] = "disabled";
            txtstock.Attributes["disabled"] = "disabled";
            txtTotalIndentQty.Attributes["disabled"] = "disabled";
            txtBalQty.Attributes["disabled"] = "disabled";
            txtqty.Attributes["disabled"] = "disabled";
            txtprice.Attributes["disabled"] = "disabled";
            txt_GdTotalPrice.Attributes["disabled"] = "disabled";
            txt_GdTotalqty.Attributes["disabled"] = "disabled";
            btnupdate.Attributes["disabled"] = "disabled";
            btnprint.Attributes["disabled"] = "disabled";
            txt_IndentNo.Attributes["disabled"] = "disabled";
            txtpayable.Attributes["disabled"] = "disabled";
            txtdiscount.Text = "15";
            txtFormPrice.Text = "20";
            txtDiscountValue.Attributes["disabled"] = "disabled";
            btnprint.Attributes["disabled"] = "disabled";
            if (ddl_VendorTypeID.SelectedIndex > 0)
            {
                AutoCompleteExtender1.ContextKey = ddl_VendorTypeID.SelectedValue == "" ? "0" : ddl_VendorTypeID.SelectedValue;
                txt_VendorName.Text = "";
                txt_VendorName.Attributes.Remove("disabled");
            }
            else
            {
                txt_VendorName.Text = "";
                txt_VendorName.Attributes["disabled"] = "disabled";
            }
            ///tab2///
            if (ddlVendorTypeID.SelectedIndex > 0)
            {
                AutoCompleteExtender3.ContextKey = ddlVendorTypeID.SelectedValue == "" ? "0" : ddlVendorTypeID.SelectedValue;
                txtVendoName.Text = "";
                txtVendoName.Attributes.Remove("disabled");
            }
            else
            {
                txtVendoName.Text = "";
                txtVendoName.Attributes["disabled"] = "disabled";
            }
            txt_FromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_ToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
        }
        protected void ddl_VendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_VendorTypeID.SelectedIndex > 0)
            {
                if (ddl_VendorTypeID.SelectedValue == "3")
                {
                    txt_InvVendorName.Visible = true;
                    txt_VendorName.Visible = false;
                }
                else
                {
                    AutoCompleteExtender1.ContextKey = ddl_VendorTypeID.SelectedValue == "" ? "0" : ddl_VendorTypeID.SelectedValue;
                    txt_VendorName.Text = "";
                    txt_VendorName.Attributes.Remove("disabled");
                    txt_InvVendorName.Visible = false;
                    txt_VendorName.Visible = true;
                }
            }
            else
            {
                txt_VendorName.Text = "";
                txt_VendorName.Attributes["disabled"] = "disabled";
                txt_InvVendorName.Visible = false;
                txt_VendorName.Visible = true;
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
            var Vendor = txt_VendorName.Text.ToString();
            if (Vendor.Contains(":"))
            {
                string VID = Vendor.Substring(Vendor.LastIndexOf(':') + 1);

                IndentGenerationBO ObjBO = new IndentGenerationBO();
                IndentGenerationData ObjData = new IndentGenerationData();
                ObjData.VendorID = Convert.ToInt32(VID == "" ? "0" : VID);
                ObjData.VendorTypeID = Convert.ToInt32(ddl_VendorTypeID.SelectedValue == "" ? "0" : ddl_VendorTypeID.SelectedValue);
                List<IndentGenerationData> result = ObjBO.GetVendorDetailsByID(ObjData);
                if (result.Count > 0)
                {
                    hdnVendorID.Value = result[0].VendorID.ToString();
                    hdnVendorName.Value = result[0].VendorName.ToString();
                    txtstock.Text = result[0].Stock.ToString();
                    ddl_group.Focus();
                }
            }
            else
            {
                txt_VendorName.Text = "";
                txt_VendorName.Focus();
            }
        }
        protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_subgroup, mstlookup.GetInvSubGroupByID(Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            if (ddl_group.SelectedIndex > 0)
            {
                ddl_subgroup.Attributes.Remove("disabled");
                ddl_subgroup.Focus();
            }
            else
            {
                ddl_subgroup.Attributes["disabled"] = "disabled";
            }
        }
        protected void ddl_subgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCompleteExtender2.ContextKey = ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue;
            txt_ItemName.Text = "";
            txt_ItemName.Focus();
            txt_ItemName.Attributes.Remove("disabled");
            txtqty.Text = "";
            txtqty.Attributes["disabled"] = "disabled";
            //AddItem();
        }
        //--- FOR FUTURE USE ---//
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemCompletionList(string prefixText, int count, string contextKey)
        {
            IndentGenerationData ObjData = new IndentGenerationData();
            IndentGenerationBO ObjBO = new IndentGenerationBO();
            List<IndentGenerationData> getResult = new List<IndentGenerationData>();
            ObjData.ItemName = prefixText;
            ObjData.SubGroupID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoItembySubGroupid(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemName.ToString());
            }
            return list;
        }
        protected void txt_ItemName_TextChanged(object sender, EventArgs e)
        {
            var Item = txt_ItemName.Text.ToString();
            if (Item.Contains(":"))
            {
                string stkno = Item.Substring(Item.LastIndexOf(':') + 1);
                //int indexStart = item.LastIndexOf('>');
                //int indexStop = item.LastIndexOf(',');
                //int count = indexStop - (indexStart + 1);
                //String StockNo = item.Substring(indexStart + 1, count);

                IndentGenerationBO ObjBO = new IndentGenerationBO();
                IndentGenerationData ObjData = new IndentGenerationData();
                //ObjData.ItemID = Convert.ToInt32(stkno == "" ? "0" : stkno);
                ObjData.StockNo = stkno == "" ? "0" : stkno;
                List<IndentGenerationData> result = ObjBO.GetItemDetailsByID(ObjData);
                if (result.Count > 0)
                {
                    hdnItemID.Value = result[0].ItemID.ToString();
                    hdnItemCode.Value = result[0].ItemCode.ToString();
                    hdnItemName.Value = result[0].ItemName.ToString();
                    hdnUnintID.Value = result[0].UnitID.ToString();
                    hdnUnintName.Value = result[0].UnitName.ToString();
                    txtunit.Text = result[0].UnitName.ToString();
                    hdnPrice.Value = result[0].Price.ToString();
                    txtprice.Text = result[0].Price.ToString();
                    hdnStockNo.Value = result[0].StockNo.ToString();
                    hdnBatchYearID.Value = result[0].BatchYearID.ToString();
                    hdnYearname.Value = result[0].YearName.ToString();
                    txtstock.Text = result[0].Stock.ToString();
                    txtTotalIndentQty.Text = result[0].GdTotalIndentQty.ToString();
                    txtBalQty.Text = result[0].TotalBalanceStock.ToString();
                    txtqty.Focus();
                    txtqty.Attributes.Remove("disabled");
                }

            }
            else
            {
                txt_ItemName.Text = "";
                txt_ItemName.Attributes.Remove("disabled");
                txt_ItemName.Focus();
            }
        }
        protected void txt_ItemQty_TextChanged(object sender, EventArgs e)
        {
            AddItem();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            AddItem();
        }
        //--- / FOR FUTURE USE ---//
        protected void AddItem()
        {

            if (ddl_VendorTypeID.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor type.") + "')", true);
                return;
            }
            if (ddl_VendorTypeID.SelectedValue == "3")
            {               
                if (txt_InvVendorName.Text == "")
                {                  
                    txt_InvVendorName.Text = "";
                    txt_InvVendorName.Focus();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter vendor name.") + "')", true);
                    return;
                }
            }
            else
            {
                if (txt_VendorName.Text.Contains(":"))
                {                   
                }
                else
                {
                    txt_VendorName.Text = "";
                    txt_VendorName.Focus();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor name.") + "')", true);
                    return;
                }
            }
                       

            if (txt_ItemName.Text == "" || !txt_ItemName.Text.Contains(":"))
            {
                txt_ItemName.Text = "";
                txt_ItemName.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter item name.") + "')", true);
                return;
            }
            if (Convert.ToDouble(txtprice.Text) <= 0.00)
            {
                txtprice.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Item Price not set,Please set the price for this items.") + "')", true);
                return;
            }
            if (txtqty.Text == "")
            {
                txtqty.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter quantity.") + "')", true);
                return;
            }
            else
            {
                if (Convert.ToInt32(txtqty.Text) > Convert.ToInt32(txtBalQty.Text))
                {
                    txtqty.Focus();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Inter Indent Qty is greater than available stock.") + "')", true);
                    return;
                }
            }

            IndentGenerationBO ObjBO = new IndentGenerationBO();
            IndentGenerationData ObjData = new IndentGenerationData();
            ObjData.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            ObjData.SubGroupID = Convert.ToInt32(ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue);
            ObjData.BatchYearID = Convert.ToInt32(hdnBatchYearID.Value == "" ? "0" : hdnBatchYearID.Value);
            ObjData.YearName = hdnYearname.Value == "" ? "0" : hdnYearname.Value;
            ObjData.StockNo = hdnStockNo.Value == "" ? "0" : hdnStockNo.Value;
            ObjData.ItemID = Convert.ToInt32(hdnItemID.Value == "" ? "0" : hdnItemID.Value);
            
            List<IndentGenerationData> result = ObjBO.GetItemDetailsBySubGroup(ObjData);
            if (result.Count > 0)
            {
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    // Check Duplicate data 
                    foreach (GridViewRow row in Gv_IndentGeneration.Rows)
                    {
                        Label lblStkNo = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblStkNo");
                        Label lblItemID = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblItemID");
                        Label lblSubGroupID = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblSubGroupID");

                        //if (Convert.ToInt32(lblSubGroupID.Text == "" ? "0" : lblSubGroupID.Text) == result[i].SubGroupID & Convert.ToInt32(lblItemID.Text == "" ? "0" : lblItemID.Text) == result[i].ItemID)
                        //{
                        if ((lblStkNo.Text == "" ? "" : lblStkNo.Text) == hdnStockNo.Value & Convert.ToInt32(lblItemID.Text == "" ? "0" : lblItemID.Text) == result[i].ItemID)
                        {
                            bindresponsive();
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Item which same stock no. have already added.Please check it.") + "')", true);
                            return;
                        }
                        else
                        {

                        }
                    }
                    List<IndentGenerationData> IndentList = Session["IndentList"] == null ? new List<IndentGenerationData>() : (List<IndentGenerationData>)Session["IndentList"];
                    IndentGenerationData Objdata = new IndentGenerationData();
                    Objdata.VendorID = Convert.ToInt32(hdnVendorID.Value == "" ? "0" : hdnVendorID.Value);
                    Objdata.VendorName = hdnVendorName.Value.ToString();
                    Objdata.GroupID = Convert.ToInt32(result[i].GroupID);
                    Objdata.GroupName = result[i].GroupName.ToString();
                    Objdata.SubGroupID = Convert.ToInt32(result[i].SubGroupID);
                    Objdata.SubGroupName = result[i].SubGroupName.ToString();
                    Objdata.BatchYearID = Convert.ToInt32(hdnBatchYearID.Value);
                    Objdata.YearName = hdnYearname.Value;
                    Objdata.ItemID = Convert.ToInt64(result[i].ItemID);
                    Objdata.ItemCode = result[i].ItemCode.ToString();
                    Objdata.ItemName = result[i].ItemName.ToString();
                    Objdata.UnitID = Convert.ToInt32(result[i].UnitID);
                    Objdata.UnitName = result[i].UnitName.ToString();
                    Objdata.Price = Convert.ToDecimal(txtprice.Text == "" ? "0" : txtprice.Text);
                    Objdata.IndentQty = Convert.ToInt32(txtqty.Text == "" ? "0" : txtqty.Text);
                    Objdata.StockNo = hdnStockNo.Value;

                    IndentList.Add(Objdata);
                    if (IndentList.Count > 0)
                    {
                        Gv_IndentGeneration.DataSource = IndentList;
                        Gv_IndentGeneration.DataBind();
                        Gv_IndentGeneration.Visible = true;
                        Session["IndentList"] = IndentList;
                        btnupdate.Attributes.Remove("disabled");
                        bindresponsive();
                        TotalCalculate();
                        Clear();
                        txt_ItemName.Focus();
                        //btnupdate.Attributes.Remove("disabled");
                    }
                    else
                    {
                        Gv_IndentGeneration.DataSource = null;
                        Gv_IndentGeneration.DataBind();
                        Gv_IndentGeneration.Visible = true;
                        TotalCalculate();
                        Clear();
                        bindresponsive();
                    }
                }
            }
        }
        public void TotalCalculate()
        {
            int TotalQty = 0;
            decimal TotalAmount = 0;
            foreach (GridViewRow row in Gv_IndentGeneration.Rows)
            {
                Label lblprice = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblprice");
                Label lblTotalPrice = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblTotalPrice");
                TextBox IndentQty = (TextBox)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("txt_indentQty");
                lblTotalPrice.Text = (Convert.ToDecimal(lblprice.Text == "" ? "0" : lblprice.Text) * Convert.ToDecimal(IndentQty.Text == "" ? "0" : IndentQty.Text)).ToString("N");
                TotalQty = TotalQty + (Convert.ToInt32(IndentQty.Text == "" ? "0" : IndentQty.Text));
                TotalAmount = TotalAmount + (Convert.ToDecimal(lblTotalPrice.Text == "" ? "0" : lblTotalPrice.Text));
            }
            txt_GdTotalqty.Text = Commonfunction.Getrounding(TotalQty.ToString());
            txt_GdTotalPrice.Text = Commonfunction.Getrounding(TotalAmount.ToString());
            decimal FormPrice = Convert.ToDecimal(txtFormPrice.Text == "" ? "0" : txtFormPrice.Text);
            decimal discount = Convert.ToDecimal(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
            decimal payable = (TotalAmount - (TotalAmount * (discount / 100))) + FormPrice;
            decimal DisValue = TotalAmount * (discount / 100);

            txtDiscountValue.Text = Commonfunction.Getrounding(DisValue.ToString());
            txtpayable.Text = Commonfunction.GetRoundingToNumber(payable.ToString());
            bindresponsive();
        }
        protected void btn_Clear(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txt_ItemName.Text = "";
            txtunit.Text = "";
            txtstock.Text = "";
            txtprice.Text = "";
            txtqty.Text = "";
            hdnItemID.Value = "";
            hdnItemCode.Value = "";
            hdnItemName.Value = "";
            hdnUnintID.Value = "";
            hdnUnintName.Value = "";
            hdnPrice.Value = "";
            txtstock.Text = "";
            txtTotalIndentQty.Text = "";
            txtBalQty.Text = "";
            hdnStockNo.Value = "";
            hdnYearname.Value = "";
            hdnBatchYearID.Value = "";

        }
        protected void txt_indentQty_TextChanged(Object sender, EventArgs e)
        {
            TotalCalculate();
        }
        protected void Gv_IndentGeneration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_IndentGeneration.Rows[i];
                    List<IndentGenerationData> IndentList = Session["IndentList"] == null ? new List<IndentGenerationData>() : (List<IndentGenerationData>)Session["IndentList"];
                    if (IndentList.Count > 0)
                    {
                        Decimal Amt = IndentList[i].Price;
                    }
                    IndentList.RemoveAt(i);
                    Session["IndentList"] = IndentList;
                    Gv_IndentGeneration.DataSource = IndentList;
                    Gv_IndentGeneration.DataBind();
                    TotalCalculate();
                    bindresponsive();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }
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
                if (ddl_VendorTypeID.SelectedValue == "3")
                {
                    if (txt_InvVendorName.Text == "")
                    {
                        txt_InvVendorName.Text = "";
                        txt_InvVendorName.Focus();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter vendor name.") + "')", true);
                        return;
                    }
                }
                else
                {
                    if (txt_VendorName.Text.Contains(":"))
                    {
                    }
                    else
                    {
                        txt_VendorName.Text = "";
                        txt_VendorName.Focus();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor name.") + "')", true);
                        return;
                    }
                }

                List<IndentGenerationData> list = new List<IndentGenerationData>();
                IndentGenerationBO TranBO = new IndentGenerationBO();
                IndentGenerationData obj = new IndentGenerationData();
                List<IndentGenerationData> Resultlist = new List<IndentGenerationData>();
                foreach (GridViewRow row in Gv_IndentGeneration.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label lblStkNo = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblStkNo");
                    Label lblGroupID = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblGroupID");
                    Label lblSubGroupID = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblSubGroupID");
                    Label lblItemID = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblItemID");
                    Label lblUnitID = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblUnitID");
                    TextBox IndentQty = (TextBox)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("txt_indentQty");
                    Label lblprice = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblprice");
                    Label lblTotalPrice = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblTotalPrice");
                    Label lblBatchYearID = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblBatchYearID");
                    Label lblyear = (Label)Gv_IndentGeneration.Rows[row.RowIndex].Cells[0].FindControl("lblyear");

                    IndentGenerationData ObjDetails = new IndentGenerationData();
                    ObjDetails.ItemID = Convert.ToInt32(lblItemID.Text == "" ? "0" : lblItemID.Text);
                    ObjDetails.IndentQty = Convert.ToInt32(IndentQty.Text == "" ? "0" : IndentQty.Text);
                    ObjDetails.Price = Convert.ToDecimal(lblprice.Text == "" ? "0" : lblprice.Text);
                    ObjDetails.TotalPrice = Convert.ToDecimal(lblTotalPrice.Text == "" ? "0" : lblTotalPrice.Text);
                    ObjDetails.StockNo = lblStkNo.Text == "" ? "0" : lblStkNo.Text;
                    ObjDetails.AcademicSessionName = lblyear.Text == "" ? "0" : lblyear.Text;
                    ObjDetails.GroupID = Convert.ToInt32(lblGroupID.Text == "" ? "0" : lblGroupID.Text);
                    ObjDetails.SubGroupID = Convert.ToInt32(lblSubGroupID.Text == "" ? "0" : lblSubGroupID.Text);
                    ObjDetails.BatchYearID = Convert.ToInt32(lblBatchYearID.Text == "" ? "0" : lblBatchYearID.Text);
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.IndentGenerationlisttoXML(list).ToString();
                obj.VendorTypeID = Convert.ToInt32(ddl_VendorTypeID.SelectedValue == "" ? "0" : ddl_VendorTypeID.SelectedValue);
                var Vendor = txt_VendorName.Text.ToString();
                if (ddl_VendorTypeID.SelectedValue == "3")
                {
                    obj.VendorID = 0;
                    obj.VendorName = txt_InvVendorName.Text;
                }
                else
                {
                    if (Vendor.Contains(":"))
                    {
                        //obj.VendorID = Commonfunction.SemicolonSeparation_String_32(txt_VendorName.Text.Trim());
                        //obj.VendorName = txt_VendorName.Text;
                        obj.VendorID = Convert.ToInt32(hdnVendorID.Value == "" ? "0" : hdnVendorID.Value);
                        obj.VendorName = hdnVendorName.Value.ToString();
                    }
                    else
                    {
                        txt_VendorName.Text = "";
                        txt_VendorName.Focus();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select vendor name.") + "')", true);
                        return;
                    }
                }
                obj.GdTotalIndentQty = Convert.ToInt32(txt_GdTotalqty.Text == "" ? "0" : txt_GdTotalqty.Text);
                obj.GdTotalPrice = Convert.ToDecimal(txt_GdTotalPrice.Text == "" ? "0" : txt_GdTotalPrice.Text);
                obj.Discount = Convert.ToDecimal(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                obj.DiscountValue = Convert.ToDecimal(txtDiscountValue.Text == "" ? "0" : txtDiscountValue.Text);
                obj.FormPrice = Convert.ToDecimal(txtFormPrice.Text == "" ? "0" : txtFormPrice.Text);
                obj.Payable = Convert.ToDecimal(txtpayable.Text == "" ? "0" : txtpayable.Text);
                obj.Remark = txt_remarks.Text == "" ? "" : txt_remarks.Text;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                Resultlist = TranBO.SaveIndentGeneration(obj);
                if (Resultlist.Count > 0)
                {
                    txt_IndentNo.Text = Resultlist[0].IndentNo.ToString();
                    btnupdate.Attributes["disabled"] = "disabled";
                    btnprint.Attributes.Remove("disabled");
                    Session.Remove("IndentList");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnupdate.Attributes.Remove("disabled");
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
        public void ClearWhenCondition()
        {
            Session.Remove("IndentList");
            Gv_IndentGeneration.DataSource = null;
            Gv_IndentGeneration.DataBind();
            Gv_IndentGeneration.Visible = false;
        }
        protected void Clear_OnClick(object sender, EventArgs e)
        {
            Reset();
            Resets();
        }
        protected void Resets()
        {
            ddl_VendorTypeID.SelectedIndex = 0;
            txt_VendorName.Text = "";
            txt_InvVendorName.Text = "";
            hdnItemID.Value = "";
            hdnItemCode.Value = "";
            hdnItemName.Value = "";
            hdnUnintID.Value = "";
            hdnUnintName.Value = "";
            hdnPrice.Value = "";
            txtunit.Text = "";
            txtprice.Text = "";
            txtstock.Text = "";
            txtTotalIndentQty.Text = "";
            txtBalQty.Text = "";
            txt_GdTotalPrice.Text = "";
            txt_GdTotalqty.Text = "";
            txt_IndentNo.Text = "";
            btnupdate.Attributes["disabled"] = "disabled";
            btnprint.Attributes["disabled"] = "disabled";
            Session.Remove("IndentList");
            txt_remarks.Text = "";
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_IndentGeneration.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_IndentGeneration.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_IndentGeneration.UseAccessibleHeader = true;
            Gv_IndentGeneration.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    bindresponsive();
            //    return;
            //}

            string IndentNo = txt_IndentNo.Text.Trim() == "" ? null : txt_IndentNo.Text.Trim();
            string PCopy = ddlPrintCopy.SelectedItem.ToString();
            string url = "../EduInventory/Report/Reportviewer.aspx?option=IndentGeneration&IndentNo=" + IndentNo + "&PrintCopy=" + PCopy;
            string fullURL = "window.open('" + url + "', '_blank');";
            bindresponsive();
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
        //-----------TAB 2---------------//
        protected void ddl_VendorType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVendorTypeID.SelectedIndex > 0)
            {
                AutoCompleteExtender3.ContextKey = ddlVendorTypeID.SelectedValue == "" ? "0" : ddlVendorTypeID.SelectedValue;
                txtVendoName.Text = "";
                txtVendoName.Attributes.Remove("disabled");
            }
            else
            {
                txtVendoName.Text = "";
                txtVendoName.Attributes["disabled"] = "disabled";
            }
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
            List<IndentGenerationData> lstindent = getindentlist(index, pagesize);
            if (lstindent.Count > 0)
            {
                Gv_IndentGen.PageSize = pagesize;
                string record = lstindent[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstindent[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstindent[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gv_IndentGen.VirtualItemCount = lstindent[0].MaximumRows;//total item is required for custom paging
                Gv_IndentGen.PageIndex = index - 1;
                Gv_IndentGen.DataSource = lstindent;
                Gv_IndentGen.DataBind();
                Gv_IndentGen.Visible = true;
                lblresult.Visible = true;
                tab2bindresponsive();
            }
            else
            {
                Gv_IndentGen.DataSource = null;
                Gv_IndentGen.DataBind();
                lblresult.Visible = false;
            }
        }
        public List<IndentGenerationData> getindentlist(int curIndex, int pagesize)
        {
            IndentGenerationData objind = new IndentGenerationData();
            IndentGenerationBO objBO = new IndentGenerationBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt_FromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_FromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt_ToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_ToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objind.Datefrom = DateFrom;
            objind.Dateto = DateTo;
            objind.VendorTypeID = Convert.ToInt32(ddlVendorTypeID.Text == "" ? "0" : ddlVendorTypeID.Text);
            var Vendor = txtVendoName.Text.ToString();
            if (Vendor.Contains(":"))
            {
                string VID = Vendor.Substring(Vendor.LastIndexOf(':') + 1);
                objind.VendorID = Convert.ToInt32(VID == "" ? "0" : VID);
            }
            else
            {
                txtVendoName.Text = "";
                objind.VendorID = 0;
                txtVendoName.Focus();
            }
            objind.IndentNo = txtIndentNo.Text == "" ? "0" : txtIndentNo.Text;
            objind.IsApproved = Convert.ToInt32(ddl_ApprovedStatus.SelectedValue == "1" ? "0" : ddl_ApprovedStatus.SelectedValue);
            objind.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            objind.PageSize = pagesize;
            objind.CurrentIndex = curIndex;

            return objBO.SearchIndentDetailsList(objind);
        }
        protected void GVIndentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    IndentGenerationData objdata = new IndentGenerationData();
                    IndentGenerationBO objbo = new IndentGenerationBO();
                    Label lblIndentNo = (Label)e.Row.FindControl("lblindentNo");
                    objdata.IndentNo = lblIndentNo.Text.Trim();
                    List<IndentGenerationData> GetResult = objbo.SearchChildIndentDetails(objdata);
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
        protected void Gv_IndentGen_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Print")
                {
                    //if (LoginToken.PrintEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                    //    bindresponsive();
                    //    return;
                    //}
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_IndentGen.Rows[i];
                    Label IndentNo = (Label)gr.Cells[0].FindControl("lblindentNo");
                    DropDownList CopyTO = (DropDownList)gr.Cells[0].FindControl("GvddlPrintCopy");

                    string IndentNo2 = IndentNo.Text.Trim() == "" ? null : IndentNo.Text.Trim();
                    string PCopy = CopyTO.SelectedItem.Text;
                    string url = "../Indent/Report/Reportviewer.aspx?option=IndentGeneration&IndentNo=" + IndentNo2 + "&PrintCopy=" + PCopy;
                    string fullURL = "window.open('" + url + "', '_blank');";
                    tab2bindresponsive();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
                }

                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    return;
                    //}
                    IndentGenerationData obj = new IndentGenerationData();
                    IndentGenerationBO objBO = new IndentGenerationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_IndentGen.Rows[i];
                    Label IndentNo = (Label)gr.Cells[0].FindControl("lblindentNo");
                    obj.IndentNo = IndentNo.Text.Trim();
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        tab2bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        obj.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    obj.EmployeeID = LoginToken.EmployeeID;
                    int Result = objBO.DeleteIndentGenbyIndentNo(obj);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else if (Result == 2)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Cannot be delete this indent number because payment have done.") + "')", true);
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
        protected void Gv_IndentGen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_IndentGen.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void Reset()
        {
            ddl_VendorTypeID.SelectedIndex = 0;
            txt_VendorName.Text = "";
            ddl_group.SelectedIndex = 0;
            // ddl_subgroup.SelectedIndex = 0;
            txt_VendorName.Attributes["disabled"] = "disabled";
            txtVendoName.Attributes["disabled"] = "disabled";
            ddl_subgroup.Attributes["disabled"] = "disabled";
            txt_ItemName.Text = "";
            txtqty.Text = "";
            hdnItemID.Value = "";
            hdnItemCode.Value = "";
            hdnItemName.Value = "";
            hdnUnintID.Value = "";
            hdnUnintName.Value = "";
            hdnPrice.Value = "";
            Session.Remove("IndentList");
            Gv_IndentGeneration.DataSource = null;
            Gv_IndentGeneration.DataBind();
            Gv_IndentGeneration.Visible = false;
            lblresult.Visible = false;
            txtDiscountValue.Text = "";
            txtpayable.Text = "";
        }
        protected void Clear2_OnClick(object sender, EventArgs e)
        {
            reset2();
        }
        protected void reset2()
        {
            ddlVendorTypeID.SelectedIndex = 0;
            txtVendoName.Text = "";
            txtVendoName.Attributes["disabled"] = "disabled";
            txtIndentNo.Text = "";
            ddl_ApprovedStatus.SelectedIndex = 0;
            txt_FromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_ToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            Gv_IndentGen.DataSource = null;
            Gv_IndentGen.DataBind();
            Gv_IndentGen.Visible = false;
            lblresult.Visible = false;
            Session.Remove("IndentList");
        }
        protected void tab2bindresponsive()
        {
            //Responsive 
            Gv_IndentGen.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_IndentGen.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_IndentGen.UseAccessibleHeader = true;
            Gv_IndentGen.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("exportenable") + "')", true);
            //    return;
            //}
            //else
            //{
                ExportoExcel();
            //}
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
            List<IndentGenerationData> Indentdetail = getindentlist(1, size);
            List<IndentDatatoXL> indenttoexcel = new List<IndentDatatoXL>();
            int i = 0;
            foreach (IndentGenerationData row in Indentdetail)
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
        protected void Gv_IndentGen_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_IndentGen.DataSource = sortedView;
                    Gv_IndentGen.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_IndentGen.HeaderRow.Cells[ColumnIndex];
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

    }
}