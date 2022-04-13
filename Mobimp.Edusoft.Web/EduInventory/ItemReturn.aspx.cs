using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.BussinessProcess.EduInventory;
using Mobimp.Edusoft.Common;
using System.Globalization;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class ItemReturn : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                btnSave.Attributes["disabled"] = "disabled";
                btnPrint.Attributes["disabled"] = "disabled";
            }
        }

        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(tab2_ddlVendorType, mstlookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(tab2_ddlVendorName, mstlookup.GetLookupsList(LookupNames.VendorName));
        }

        protected void txt_IssueNo_TextChanged(object sender, EventArgs e)
        {
            GetItemDetails();
        }

        protected void GetItemDetails()
        {
            string IssueNo = txt_IssueNo.Text.ToString();

            ItemReturnData objdata = new ItemReturnData();
            ItemReturnBO objBO = new ItemReturnBO();
            List<ItemReturnData> getResult = new List<ItemReturnData>();
            objdata.IssueNo = IssueNo;
            getResult = objBO.GetItemDetailsByIssueNo(objdata);
            if (getResult.Count > 0)
            {
                txt_VendorType.Text = getResult[0].VendorTypeName;
                txt_VendorName.Text = getResult[0].VendorName;
                txt_IssueDate.Text = getResult[0].IssueDate.ToString();
                txt_TotalIssueQty.Text = getResult[0].TotalIssueQty.ToString();

                Gv_ItemReturn.DataSource = getResult;
                Gv_ItemReturn.DataBind();
                Gv_ItemReturn.Visible = true;
                Session["ReturnList"] = getResult;
                ds = ConvertToDataSet(getResult);
                TableCell tableCell = Gv_ItemReturn.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);

                btnSave.Attributes.Remove("disabled");
                lblmessage.Text = "";
                lblmessage.Visible = false;
                btnSearch.Focus();
                bindresponsive();
            }
            else
            {
                lblmessage.Text = "Issue Number is not valid";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                txt_IssueNo.Text = "";
                txt_VendorType.Text = "";
                txt_VendorName.Text = "";
                txt_IssueDate.Text = "";
                Gv_ItemReturn.DataSource = null;
                Gv_ItemReturn.DataBind();
                Gv_ItemReturn.Visible = false;
                txt_IssueNo.Focus();
                bindresponsive();
                return;
            }
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

        protected void bindresponsive()
        {
            if (Gv_ItemReturn.Rows.Count != 0)
            {
                //Responsive 
                Gv_ItemReturn.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                Gv_ItemReturn.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                //  Adds THEAD and TBODY to GridView.
                Gv_ItemReturn.UseAccessibleHeader = true;
                Gv_ItemReturn.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetItemDetails();
        }

        protected void Gvtxt_ReturnQty_TextChanged(object sender, EventArgs e)
        {
            int TotalReturnQty = 0;
            foreach (GridViewRow row in Gv_ItemReturn.Rows)
            {
                Label IssueQty = (Label)Gv_ItemReturn.Rows[row.RowIndex].Cells[0].FindControl("Gvlbl_IssueQty");
                TextBox ReturnQty = (TextBox)Gv_ItemReturn.Rows[row.RowIndex].Cells[0].FindControl("Gvtxt_ReturnQty");

                if (Convert.ToInt32(ReturnQty.Text == "" ? "0" : ReturnQty.Text) > Convert.ToInt32(IssueQty.Text == "" ? "0" : IssueQty.Text))
                {
                    lblmessage.Text = "Return quantity is greater than issue quantity.";
                    lblmessage.ForeColor = System.Drawing.Color.Red;
                    lblmessage.Visible = true;
                    ReturnQty.Text = "";
                    ReturnQty.Focus();
                }
                else
                {
                    TotalReturnQty = TotalReturnQty + (Convert.ToInt32(ReturnQty.Text == "" ? "0" : ReturnQty.Text));
                }
            }
            txt_TotalReturnQty.Text = Commonfunction.Getrounding(TotalReturnQty.ToString());
            lblhdn_IssueNo.Text = txt_IssueNo.Text;
            //if (Convert.ToInt32(txt_TotalReturnQty.Text == "" ? "0" : txt_TotalReturnQty.Text) > 0)
            //{
            //    btnSave.Attributes.Remove("disabled");
            //}
            //else
            //{
            //    btnSave.Attributes["disabled"] = "disabled";
            //}
            bindresponsive();
        }

        protected void Gv_ItemReturn_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_ItemReturn.Rows[i];
                    List<ItemReturnData> ReturnList = Session["ReturnList"] == null ? new List<ItemReturnData>() : (List<ItemReturnData>)Session["ReturnList"];
                    if (ReturnList.Count > 0)
                    {
                        ReturnList.RemoveAt(i);
                        Session["ReturnList"] = ReturnList;
                        Gv_ItemReturn.DataSource = ReturnList;
                        Gv_ItemReturn.DataBind();
                        bindresponsive();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ItemReturnData> list = new List<ItemReturnData>();
                ItemReturnBO objBO = new ItemReturnBO();
                ItemReturnData obj = new ItemReturnData();
                foreach (GridViewRow row in Gv_ItemReturn.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    string IssueNo = row.Cells[1].Text.Trim();
                    string StockNo = row.Cells[2].Text.Trim();
                    Label VendorTypeID = (Label)Gv_ItemReturn.Rows[row.RowIndex].Cells[0].FindControl("lblGv_VendorTypeID");
                    Label VendorID = (Label)Gv_ItemReturn.Rows[row.RowIndex].Cells[0].FindControl("lblGv_VendorID");
                    Label ItemID = (Label)Gv_ItemReturn.Rows[row.RowIndex].Cells[0].FindControl("lblGv_ItemID");
                    Label UnitID = (Label)Gv_ItemReturn.Rows[row.RowIndex].Cells[0].FindControl("lblGv_UnitID");
                    TextBox ReturnQty = (TextBox)Gv_ItemReturn.Rows[row.RowIndex].Cells[0].FindControl("Gvtxt_ReturnQty");
                    // float ReturnQty = float.Parse(row.Cells[5].Text, CultureInfo.InvariantCulture.NumberFormat);
                    string ExpiryDate = row.Cells[8].Text.Trim();

                    ItemReturnData ObjDetails = new ItemReturnData();
                    ObjDetails.IssueNo = IssueNo == "" ? "0" : IssueNo.ToString();
                    ObjDetails.StockNo = StockNo == "" ? "0" : StockNo.ToString();
                    ObjDetails.VendorTypeID = Convert.ToInt32(VendorTypeID.Text == "" ? "0" : VendorTypeID.Text);
                    ObjDetails.VendorID = Convert.ToInt32(VendorID.Text == "" ? "0" : VendorID.Text);
                    ObjDetails.ItemID = Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text);
                    ObjDetails.UnitID = Convert.ToInt32(UnitID.Text == "" ? "0" : UnitID.Text);
                    ObjDetails.ReturnQty = float.Parse(ReturnQty.Text == "" ? "0" : ReturnQty.Text, CultureInfo.InvariantCulture.NumberFormat);
                    ObjDetails.ExpiryDates = ExpiryDate;
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.ItemReturnListtoXML(list).ToString();
                obj.IssueNo = lblhdn_IssueNo.Text.Trim();
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                List<ItemReturnData> getResult = new List<ItemReturnData>();
                getResult = objBO.SaveReturnItemList(obj);
                if (getResult.Count > 0)
                {
                    txt_ReturnNo.Text = getResult[0].ReturnNo;
                    Gv_ItemReturn.DataSource = null;
                    Gv_ItemReturn.DataBind();
                    Gv_ItemReturn.Visible = false;
                    Session.Remove("ReturnList");
                    btnSave.Attributes["disabled"] = "disabled";
                    btnPrint.Attributes.Remove("disabled");
                    ClearAll();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnSave.Attributes.Remove("disabled");
                    btnPrint.Attributes["disabled"] = "disabled";
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

        private void ClearAll()
        {
            lblmessage.Text = "";
            txt_IssueNo.Text = "";
            txt_VendorType.Text = "";
            txt_VendorName.Text = "";
            txt_IssueDate.Text = "";
            txt_ReturnNo.Text = "";
            txtRemark.Text = "";
            txt_TotalReturnQty.Text = "";
            Gv_ItemReturn.DataSource = null;
            Gv_ItemReturn.DataBind();
            Gv_ItemReturn.Visible = false;
            Session["ReturnList"] = null;
            btnSave.Attributes["disabled"] = "disabled";
            btnPrint.Attributes["disabled"] = "disabled";
            txt_TotalIssueQty.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        //---------------------------- End Tab1-------------------------

        //-----------------------------Start Tab2--------------------------

        protected void tab2_btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(tab2_ddl_show.SelectedValue == "10000" ? tab2_lbl_totalrecords.Text : tab2_ddl_show.SelectedValue);
            List<ItemReturnData> ReturnList = GetItemReturnList(index, pagesize);
            if (ReturnList.Count > 0)
            {
                Gv_ItemReturnDetails.PageSize = pagesize;
                string record = ReturnList[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                tab2_lblresult.Text = "Total : " + ReturnList[0].MaximumRows.ToString() + " " + record;
                tab2_lbl_totalrecords.Text = ReturnList[0].MaximumRows.ToString(); ;
                tab2_lblresult.Visible = true;
                Gv_ItemReturnDetails.VirtualItemCount = ReturnList[0].MaximumRows;//total item is required for custom paging
                Gv_ItemReturnDetails.PageIndex = index - 1;
                Gv_ItemReturnDetails.DataSource = ReturnList;
                Gv_ItemReturnDetails.DataBind();
                ds = tab2ConvertToDataSet(ReturnList);
                TableCell tableCell = Gv_ItemReturnDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gv_ItemReturnDetails.DataSource = null;
                Gv_ItemReturnDetails.DataBind();
            }
        }

        public List<ItemReturnData> GetItemReturnList(int curIndex, int pagesize)
        {
            ItemReturnData objData = new ItemReturnData();
            ItemReturnBO objBO = new ItemReturnBO();
            objData.VendorTypeID = Convert.ToInt32(tab2_ddlVendorType.SelectedValue == "" ? "0" : tab2_ddlVendorType.SelectedValue);
            objData.VendorID = Convert.ToInt32(tab2_ddlVendorName.SelectedValue == "" ? "0" : tab2_ddlVendorName.SelectedValue);
            objData.ReturnNo = tab2_txtReturnNo.Text == "" ? "0" : tab2_txtReturnNo.Text.Trim();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = tab2_txtDateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(tab2_txtDateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime to = tab2_txtDateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(tab2_txtDateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objData.Datefrom = from;
            objData.Dateto = to;
            objData.IsActive = tab2_ddlStatus.SelectedValue == "1" ? true : false;
            objData.PageSize = pagesize;
            objData.CurrentIndex = curIndex;
            return objBO.GetItemReturnList(objData);
        }

        public DataSet tab2ConvertToDataSet<T>(IList<T> list)
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


    }
}