using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.BussinessProcess.EduInventory;
using System.Globalization;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class ItemCondemnationRecord : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("ItemCondemnList");
                txtCondemnNo.Attributes["disabled"] = "disabled";
                btnSave.Attributes["disabled"] = "disabled";
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemNameStockNo(string prefixText)
        {
            ItemCondemnationData objData = new ItemCondemnationData();
            ItemCondemnationBO objBO = new ItemCondemnationBO();
            List<ItemCondemnationData> getResult = new List<ItemCondemnationData>();
            objData.ItemName = prefixText;
            getResult = objBO.GetItemNameWithStockNo(objData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemName.ToString());
            }
            return list;
        }
        protected void txt_ItemName_TextChanged(object sender, EventArgs e)
        {
            string StockNo;
            var source = txt_ItemName.Text.ToString();
            if (source.Contains(":"))
            {
                StockNo = source.Substring(source.LastIndexOf(':') + 1);
                ItemCondemnationData objData = new ItemCondemnationData();
                ItemCondemnationBO objBO = new ItemCondemnationBO();
                List<ItemCondemnationData> getResult = new List<ItemCondemnationData>();
                objData.StockNo = StockNo;
                getResult = objBO.GetItemDetailsByStockNo(objData);
                if (getResult.Count > 0)
                {
                    lbl_StockNo.Text = getResult[0].StockNo;
                    //lbl_VendorID.Text = getResult[0].VendorID.ToString();
                    lbl_GetItemName.Text = getResult[0].ItemName;
                    lbl_ItemID.Text = getResult[0].ItemID.ToString();
                    lbl_GetUnitID.Text = getResult[0].UnitID.ToString();
                    txt_Unit.Text = getResult[0].UnitName.ToString();
                    txt_Price.Text = getResult[0].Price.ToString();
                    txt_RecievedQty.Text = getResult[0].NetRecievedQty.ToString();
                    txt_AvailableQty.Text = getResult[0].NetBalanceQty.ToString();
                }
            }
            else
            {
                txt_ItemName.Text = "";
                txt_ItemName.Focus();
                return;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlCondemnTypeID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Condemn Type") + "')", true);
                ddlCondemnTypeID.Focus();
                return;
            }
            if (txt_ItemName.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Item Name") + "')", true);
                txt_ItemName.Focus();
                return;
            }

            if (txt_Unit.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Unit  cannot be blank") + "')", true);
                txt_Unit.Focus();
                return;
            }
            if (txt_Price.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Price cannot be blank") + "')", true);
                return;
            }
            if (txt_RecievedQty.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Recieved Quantity shouldn't be blank") + "')", true);
                txt_RecievedQty.Focus();
                return;
            }
            if (txt_AvailableQty.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Available Quanitity shouldn't be blank") + "')", true);
                txt_AvailableQty.Focus();
                return;
            }
            if (txtCondemnRemark.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter condem details") + "')", true);
                txtCondemnRemark.Focus();
                return;
            }
            if (txt_CondemnQty.Text == "" || txt_CondemnQty.Text == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Enter Condemn Quantity") + "')", true);
                txt_CondemnQty.Focus();
                return;
            }
            if (Convert.ToInt32(txt_AvailableQty.Text) < Convert.ToInt32(txt_CondemnQty.Text))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Condemn Quantity shouldn't be greater than Available Quantity") + "')", true);
                txt_CondemnQty.Focus();
                return;
            }

            string No;
            var source = txt_ItemName.Text.ToString();
            if (source.Contains(":"))
            {
                No = source.Substring(source.LastIndexOf(':') + 1);
                btnSave.Attributes.Remove("disabed");
                // Check Duplicate data 
                foreach (GridViewRow row in Gv_ItemComnationRecord.Rows)
                {
                    Label StockNo = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblGv_StockNo");
                    if ((StockNo.Text == "" ? "0" : StockNo.Text) == (No == "" || No == null ? "0" : No))
                    {
                        txt_ItemName.Text = "";
                        txt_Unit.Text = "";
                        txt_Price.Text = "";
                        txt_RecievedQty.Text = "";
                        txt_AvailableQty.Text = "";
                        txt_CondemnQty.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Already added to the list.") + "')", true);
                        txt_ItemName.Focus();
                        return;
                    }
                }
            }
            else
            {
                txt_ItemName.Text = "";
                txt_Unit.Text = "";
                txt_Price.Text = "";
                txt_RecievedQty.Text = "";
                txt_AvailableQty.Text = "";
                txt_CondemnQty.Text = "";
                return;
            }

            List<ItemCondemnationData> ItemCondemnList = Session["ItemCondemnList"] == null ? new List<ItemCondemnationData>() : (List<ItemCondemnationData>)Session["ItemCondemnList"];
            ItemCondemnationData ObjItemData = new ItemCondemnationData();
            ObjItemData.StockNo = (No == "" || No == null ? "0" : No);
            ObjItemData.CondemnTypeID = Convert.ToInt32(ddlCondemnTypeID.SelectedValue == "" ? "0" : ddlCondemnTypeID.SelectedValue);
            ObjItemData.CondemnType = ddlCondemnTypeID.Text == "" ? "0" : ddlCondemnTypeID.Text;
            ObjItemData.ItemID = Convert.ToInt32(lbl_ItemID.Text == "" ? "0" : lbl_ItemID.Text);
            ObjItemData.ItemName = lbl_GetItemName.Text.Trim();
            ObjItemData.UnitID = Convert.ToInt32(lbl_GetUnitID.Text == "" ? "0" : lbl_GetUnitID.Text);
            ObjItemData.UnitName = txt_Unit.Text.Trim();
            ObjItemData.Price = Convert.ToDecimal(txt_Price.Text == "" ? "0" : txt_Price.Text);
            ObjItemData.NetRecievedQty = float.Parse(txt_RecievedQty.Text, CultureInfo.InvariantCulture.NumberFormat);
            ObjItemData.NetBalanceQty = float.Parse(txt_AvailableQty.Text, CultureInfo.InvariantCulture.NumberFormat);
            ObjItemData.CondemnQty = float.Parse(txt_CondemnQty.Text, CultureInfo.InvariantCulture.NumberFormat);
            ObjItemData.CondemnRemark = txtCondemnRemark.Text == "" ? "" : txtCondemnRemark.Text;
            ItemCondemnList.Add(ObjItemData);
            if (ItemCondemnList.Count > 0)
            {
                Gv_ItemComnationRecord.DataSource = ItemCondemnList;
                Gv_ItemComnationRecord.DataBind();
                Gv_ItemComnationRecord.Visible = true;
                Session["ItemCondemnList"] = ItemCondemnList;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                txtCondemnNo.Visible = true;
            }
        }

        protected void bindresponsive()
        {
            //Responsive 
            Gv_ItemComnationRecord.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_ItemComnationRecord.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_ItemComnationRecord.UseAccessibleHeader = true;
            Gv_ItemComnationRecord.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void Gv_ItemComnationRecord_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_ItemComnationRecord.Rows[i];
                    List<ItemCondemnationData> ItemCondemnList = Session["ItemCondemnList"] == null ? new List<ItemCondemnationData>() : (List<ItemCondemnationData>)Session["ItemCondemnList"];
                    ItemCondemnList.RemoveAt(i);
                    Session["ItemCondemnList"] = ItemCondemnList;
                    Gv_ItemComnationRecord.DataSource = ItemCondemnList;
                    Gv_ItemComnationRecord.DataBind();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ItemCondemnationData> list = new List<ItemCondemnationData>();
                ItemCondemnationBO objBO = new ItemCondemnationBO();
                ItemCondemnationData obj = new ItemCondemnationData();
                foreach (GridViewRow row in Gv_ItemComnationRecord.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label StockNo = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblGv_StockNo");
                    Label VendorID = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblGv_VendorID");
                    Label ItemID = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblGv_ItemID");
                    Label UnitID = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblGv_UnitID");
                    Label Price = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblPrice");
                    Label RecievedQty = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblRecQty");
                    Label AvailableQty = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblAvailQty");
                    Label CondemnQty = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblCondemnQty");
                    Label CondemnTypeID = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblcondemnTypeID");
                    Label CondemnType = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblcondemnType");
                    Label CondemnRemark = (Label)Gv_ItemComnationRecord.Rows[row.RowIndex].Cells[0].FindControl("lblCondemnRemark");

                    ItemCondemnationData ObjDetails = new ItemCondemnationData();
                    ObjDetails.StockNo = StockNo.Text == "" ? "0" : StockNo.Text.Trim();
                    ObjDetails.VendorID = Convert.ToInt32(VendorID.Text == "" ? "0" : VendorID.Text);
                    ObjDetails.ItemID = Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text);
                    ObjDetails.UnitID = Convert.ToInt32(UnitID.Text == "" ? "0" : UnitID.Text);
                    ObjDetails.Price = Convert.ToDecimal(Price.Text == "" ? "0" : Price.Text);
                    ObjDetails.NetRecievedQty = Convert.ToInt32(RecievedQty.Text == "" ? "0" : RecievedQty.Text);
                    ObjDetails.NetBalanceQty = Convert.ToInt32(AvailableQty.Text == "" ? "0" : AvailableQty.Text);
                    ObjDetails.CondemnQty = Convert.ToInt32(CondemnQty.Text == "" ? "0" : CondemnQty.Text);
                    ObjDetails.CondemnTypeID = Convert.ToInt32(CondemnTypeID.Text == "" ? "0" : CondemnTypeID.Text);
                    ObjDetails.CondemnType = CondemnType.Text;
                    ObjDetails.CondemnRemark = CondemnRemark.Text;
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.ItemCondemListXML(list).ToString();
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                List<ItemCondemnationData> Result = objBO.SaveItemCondemn(obj);
                if (Result.Count > 0)
                {
                    if (Result[0].Output == 1)
                    {
                        txtCondemnNo.Text = Result[0].CondemnNo;
                        btnSave.Attributes["disabled"] = "disabled";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            Clear();
        }
        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            Clear();
            btnSave.Visible = false;
            btnCancel.Visible = false;
            Gv_ItemComnationRecord.DataSource = null;
            Gv_ItemComnationRecord.DataBind();
            Gv_ItemComnationRecord.Visible = false;
            txtCondemnNo.Visible = false;
        }
        protected void Clear()
        {
            ddlCondemnTypeID.SelectedIndex = 0;
            txt_ItemName.Text = "";
            lbl_StockNo.Text = "";
            lbl_ItemID.Text = "";
            txt_Unit.Text = "";
            txt_Price.Text = "";
            txt_RecievedQty.Text = "";
            txt_AvailableQty.Text = "";
            txtCondemnRemark.Text = "";
            txt_CondemnQty.Text = "";
            Session.Remove("ItemCondemnList");
            txtCondemnNo.Text = "";
        }

    }
}