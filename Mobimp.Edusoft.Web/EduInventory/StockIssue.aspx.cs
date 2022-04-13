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
    public partial class StockIssue : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                Session.Remove("StockIssueList");
                btnSave.Attributes["disabled"] = "disabled";
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstLookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_VendorType, mstLookup.GetLookupsList(LookupNames.VendorType));
            Commonfunction.PopulateDdl(ddltab2_VendorType, mstLookup.GetLookupsList(LookupNames.VendorType));
        }

        protected void ddl_VendorType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddl_VendorType.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_VendorName, mstlookup.GetVendorByID(Convert.ToInt32(ddl_VendorType.SelectedValue == "" ? "0" : ddl_VendorType.SelectedValue)));
                bindresponsive();
            }
            else
            {
                ddl_VendorType.SelectedIndex = 0;
                bindresponsive();
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemDetails(string prefixText, int count, string contextKey)
        {
            StockIssueData ObjData = new StockIssueData();
            StockIssueBO ObjBO = new StockIssueBO();
            List<StockIssueData> getResult = new List<StockIssueData>();
            ObjData.ItemName = prefixText;
            ObjData.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoItemStockDetails(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemName.ToString());
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
                StockIssueData objdata = new StockIssueData();
                StockIssueBO objBO = new StockIssueBO();
                List<StockIssueData> getResult = new List<StockIssueData>();
                objdata.StockNo = ID;
                getResult = objBO.GetItemDetailsByStockNo(objdata);
                if (getResult.Count > 0)
                {
                    lbl_StockNo.Text = getResult[0].StockNo;
                    lbl_GetItemName.Text = getResult[0].ItemName;
                    lbl_ItemID.Text = getResult[0].ItemID.ToString();
                    lbl_UnitID.Text = getResult[0].UnitID.ToString();
                    lbl_UnitName.Text = getResult[0].UnitName.ToString();
                    lbl_ExpiryDate.Text = getResult[0].ExpiryDate.ToString();
                    txt_AvailableQty.Text = getResult[0].TotalAvailableQty.ToString();
                    lblmessage.Text = "";
                    lblmessage.Visible = false;
                    txt_IssueQty.Focus();
                    bindresponsive();
                }
                else
                {
                    lblmessage.Text = "Item is not available in stock";
                    lblmessage.ForeColor = System.Drawing.Color.Red;
                    lblmessage.Visible = true;
                    txt_ItemName.Text = "";
                    txt_ItemName.Focus();
                    bindresponsive();
                    return;
                }
            }
        }
        protected void txt_IssueQty_TextChanged(object sender, EventArgs e)
        {
            double AvailableQty = Convert.ToDouble(txt_AvailableQty.Text);
            double IssueQty = Convert.ToDouble(txt_IssueQty.Text);
            if (AvailableQty < IssueQty)
            {
                lblmessage.Text = "Issue Quantity is greater than Available Quantity";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                txt_IssueQty.Focus();
                return;
            }
            else
            {
                lblmessage.Text = "";
                lblmessage.Visible = false;
                btnAdd.Focus();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (ddl_VendorType.SelectedIndex == 0)
            {
                lblmessage.Text = "Please Select Vendor Type";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                ddl_VendorType.Focus();
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            if (ddl_VendorName.SelectedIndex == 0)
            {
                lblmessage.Text = "Please Select Vendor Name";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                ddl_VendorName.Focus();
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            if (txt_ItemName.Text == "")
            {
                lblmessage.Text = "Please Enter Item Name";
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
            if (txt_AvailableQty.Text == "")
            {
                lblmessage.Text = "Available Quantity shouldn't be blank";
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
            if (txt_IssueQty.Text == "")
            {
                lblmessage.Text = "Please Enter Issue Quantity";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                txt_IssueQty.Focus();
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }

            string ID;
            var source = txt_ItemName.Text.ToString();
            if (source.Contains(":"))
            {
                ID = source.Substring(source.LastIndexOf(':') + 1);
                // Check Duplicate data 
                foreach (GridViewRow row in Gv_StockIssue.Rows)
                {
                    Label No = (Label)Gv_StockIssue.Rows[row.RowIndex].Cells[0].FindControl("lblGv_StockNo");
                    string StockNo = No.ToString();
                    if ((StockNo == "" ? "0" : StockNo) == (ID == "" || ID == "" ? "0" : ID))
                    {
                        txt_ItemName.Text = "";
                        txt_AvailableQty.Text = "";
                        txt_IssueQty.Text = "";
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
                txt_AvailableQty.Text = "";
                txt_IssueQty.Text = "";
                return;
            }

            List<StockIssueData> StockIssueList = Session["StockIssueList"] == null ? new List<StockIssueData>() : (List<StockIssueData>)Session["StockIssueList"];
            StockIssueData ObjStockData = new StockIssueData();
            ObjStockData.VendorTypeID = Convert.ToInt32(ddl_VendorType.SelectedValue == "" ? "0" : ddl_VendorType.SelectedValue);
            ObjStockData.VendorTypeName = ddl_VendorType.SelectedItem.Text == "" ? "" : ddl_VendorType.SelectedItem.Text;
            ObjStockData.VendorID = Convert.ToInt32(ddl_VendorName.SelectedValue == "" ? "0" : ddl_VendorName.SelectedValue);
            ObjStockData.VendorName = ddl_VendorName.SelectedItem.Text == "" ? "" : ddl_VendorName.SelectedItem.Text;
            ObjStockData.ItemID = Convert.ToInt32(lbl_ItemID.Text == "" || lbl_ItemID.Text == null ? "0" : lbl_ItemID.Text);
            ObjStockData.ItemName = lbl_GetItemName.Text.Trim();
            ObjStockData.UnitID = Convert.ToInt32(lbl_UnitID.Text == null ? "0" : lbl_UnitID.Text);
            ObjStockData.UnitName = lbl_UnitName.Text == null ? "" : lbl_UnitName.Text;
            ObjStockData.TotalAvailableQty = Convert.ToDouble(txt_AvailableQty.Text == "" ? "0" : txt_AvailableQty.Text);
            //ObjStockData.IssueQty = float.Parse(txt_IssueQty.Text, CultureInfo.InvariantCulture.NumberFormat);
            ObjStockData.IssueQty = Convert.ToDouble(txt_IssueQty.Text == "" ? "0" : txt_IssueQty.Text);
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime ExpDate = lbl_ExpiryDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(lbl_ExpiryDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            ObjStockData.ExpiryDate = ExpDate;
            ObjStockData.StockNo = lbl_StockNo.Text == "" ? "0" : lbl_StockNo.Text.Trim();

            StockIssueList.Add(ObjStockData);
            if (StockIssueList.Count > 0)
            {
                Gv_StockIssue.DataSource = StockIssueList;
                Gv_StockIssue.DataBind();
                Gv_StockIssue.Visible = true;
                Session["StockIssueList"] = StockIssueList;
                txt_ItemName.Focus();
                btnSave.Attributes.Remove("disabled");
                bindresponsive();
                Clear();
            }
        }
        private void Clear()
        {
            lblmessage.Text = "";
            txt_ItemName.Text = "";
            txt_AvailableQty.Text = "";
            txt_IssueQty.Text = "";
            lbl_StockNo.Text = "";
            lbl_GetItemName.Text = "";
            lbl_ItemID.Text = "";
            lbl_UnitID.Text = "";
            lbl_UnitName.Text = "";
            lbl_ExpiryDate.Text = "";
        }
        protected void bindresponsive()
        {
            if (Gv_StockIssue.Rows.Count != 0)
            {
                //Responsive 
                Gv_StockIssue.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                Gv_StockIssue.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                //  Adds THEAD and TBODY to GridView.
                Gv_StockIssue.UseAccessibleHeader = true;
                Gv_StockIssue.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void Gv_StockIssue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_StockIssue.Rows[i];
                    List<StockIssueData> IssueList = Session["StockIssueList"] == null ? new List<StockIssueData>() : (List<StockIssueData>)Session["StockIssueList"];
                    IssueList.RemoveAt(i);
                    Session["StockIssueList"] = IssueList;
                    Gv_StockIssue.DataSource = IssueList;
                    Gv_StockIssue.DataBind();
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
                List<StockIssueData> list = new List<StockIssueData>();
                StockIssueBO objBO = new StockIssueBO();
                StockIssueData obj = new StockIssueData();
                foreach (GridViewRow row in Gv_StockIssue.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label VendorTypeID = (Label)Gv_StockIssue.Rows[row.RowIndex].Cells[0].FindControl("lblGv_VendorTypeID");
                    Label VendorID = (Label)Gv_StockIssue.Rows[row.RowIndex].Cells[0].FindControl("lblGv_VendorID");
                    Label ItemID = (Label)Gv_StockIssue.Rows[row.RowIndex].Cells[0].FindControl("lblGv_ItemID");
                    Label UnitID = (Label)Gv_StockIssue.Rows[row.RowIndex].Cells[0].FindControl("lblGv_UnitID");
                    float AvailableQty = float.Parse(row.Cells[5].Text, CultureInfo.InvariantCulture.NumberFormat);
                    float IssueQty = float.Parse(row.Cells[6].Text, CultureInfo.InvariantCulture.NumberFormat);
                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    //DateTime ExpiryDate = row.Cells[7].Text == "" ? System.DateTime.Now : DateTime.Parse(row.Cells[7].Text, option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    string ExpiryDate = row.Cells[7].Text.Trim();
                    Label StockNo = (Label)Gv_StockIssue.Rows[row.RowIndex].Cells[0].FindControl("lblGv_StockNo");

                    StockIssueData ObjDetails = new StockIssueData();
                    ObjDetails.VendorTypeID = Convert.ToInt32(VendorTypeID.Text == "" ? "0" : VendorTypeID.Text);
                    ObjDetails.VendorID = Convert.ToInt32(VendorID.Text == "" ? "0" : VendorID.Text);
                    ObjDetails.ItemID = Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text);
                    ObjDetails.UnitID = Convert.ToInt32(UnitID.Text == "" ? "0" : UnitID.Text);
                    ObjDetails.AvailableQty = AvailableQty;
                    ObjDetails.IssueQty = IssueQty;
                    ObjDetails.ExpiryDates = ExpiryDate;
                    ObjDetails.StockNo = StockNo.Text;
                    list.Add(ObjDetails);

                }
                obj.XMLData = XmlConvertor.StockIssueListtoXML(list).ToString();
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                int status = objBO.SaveStockIssueList(obj);
                if (status == 1)
                {
                    //Session["StockIssueList"] = null;
                    ClearAll();
                    btnSave.Attributes["disabled"] = "disable";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
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
            ddl_VendorType.SelectedIndex = 0;
            ddl_VendorName.SelectedIndex = 0;
            txt_ItemName.Text = "";
            txt_AvailableQty.Text = "";
            txt_IssueQty.Text = "";
            lbl_StockNo.Text = "";
            lbl_GetItemName.Text = "";
            lbl_ItemID.Text = "";
            lbl_UnitID.Text = "";
            lbl_UnitName.Text = "";
            lbl_ExpiryDate.Text = "";
            Gv_StockIssue.DataSource = null;
            Gv_StockIssue.DataBind();
            Gv_StockIssue.Visible = false;
            Session.Remove("StockIssueList");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnSave.Attributes["disabled"] = "disable";
        }

        //-------------------Start Second Tab-----------------------
        protected void ddltab2_VendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltab2_VendorType.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddltab2_VendorName, mstlookup.GetVendorByID(Convert.ToInt32(ddltab2_VendorType.SelectedValue == "" ? "0" : ddltab2_VendorType.SelectedValue)));
                //bindresponsive();
            }
            else
            {
                ddltab2_VendorType.SelectedIndex = 0;
                //bindresponsive();
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemNameStockIssueAutoTab2(string prefixText, int count, string contextKey)
        {
            StockIssueData ObjData = new StockIssueData();
            StockIssueBO ObjBO = new StockIssueBO();
            List<StockIssueData> getResult = new List<StockIssueData>();
            ObjData.ItemName = prefixText;
            ObjData.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = ObjBO.GetAutoItemStockDetails(ObjData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemName.ToString());
            }
            return list;
        }
        protected void btntab2_Search_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddltab2_show.SelectedValue == "10000" ? lbltab2_totalrecords.Text : ddltab2_show.SelectedValue);
            List<StockIssueData> StockIssueList = GetStockIssueDetails(index, pagesize);
            if (StockIssueList.Count > 0)
            {
                Gv_StockIssueDetails.PageSize = pagesize;
                string record = StockIssueList[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lbltab2_result.Text = "Total : " + StockIssueList[0].MaximumRows.ToString() + " " + record;
                lbltab2_totalrecords.Text = StockIssueList[0].MaximumRows.ToString(); ;
                lbltab2_result.Visible = true;
                Gv_StockIssueDetails.VirtualItemCount = StockIssueList[0].MaximumRows;//total item is required for custom paging
                Gv_StockIssueDetails.PageIndex = index - 1;
                Gv_StockIssueDetails.DataSource = StockIssueList;
                Gv_StockIssueDetails.DataBind();
                ds = ConvertToDataSet(StockIssueList);
                TableCell tableCell = Gv_StockIssueDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsivetab2();
            }
            else
            {
                Gv_StockIssueDetails.DataSource = null;
                Gv_StockIssueDetails.DataBind();
            }
        }
        public List<StockIssueData> GetStockIssueDetails(int curIndex, int pagesize)
        {
            StockIssueData objData = new StockIssueData();
            StockIssueBO objBO = new StockIssueBO();
            objData.VendorTypeID = Convert.ToInt32(ddltab2_VendorType.SelectedValue == "" ? "0" : ddltab2_VendorType.SelectedValue);
            objData.VendorID = Convert.ToInt32(ddltab2_VendorName.SelectedValue == "" ? "0" : ddltab2_VendorName.SelectedValue);
            //objData.ItemID = Convert.ToInt32(txttab2_ItemName.SelectedValue == "" ? "0" : ddl_ItemName.SelectedValue);
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txttab2_DateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txttab2_DateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime to = txttab2_DateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txttab2_DateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objData.Datefrom = from;
            objData.Dateto = to;
            objData.IsActive = ddltab2_Status.SelectedValue == "1" ? true : false;
            objData.PageSize = pagesize;
            objData.CurrentIndex = curIndex;
            return objBO.GetStockIssueDetails(objData);
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

        protected void bindresponsivetab2()
        {
            if (Gv_StockIssueDetails.Rows.Count != 0)
            {
                //Responsive 
                Gv_StockIssueDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                Gv_StockIssueDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                //  Adds THEAD and TBODY to GridView.
                Gv_StockIssueDetails.UseAccessibleHeader = true;
                Gv_StockIssueDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Gv_StockIssueDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_StockIssueDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void Gv_StockIssueDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_StockIssueDetails.DataSource = sortedView;
                    Gv_StockIssueDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_StockIssueDetails.HeaderRow.Cells[ColumnIndex];
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

        protected void Gv_StockIssueDetails_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    StockIssueData objData = new StockIssueData();
                    StockIssueBO objdBO = new StockIssueBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_StockIssueDetails.Rows[i];
                    Label IssueID = (Label)gr.Cells[0].FindControl("lblGvTab2_IssueID");
                    Label IssueNo = (Label)gr.Cells[0].FindControl("lblGvTab2_IssueNo");
                    Label StockNo = (Label)gr.Cells[0].FindControl("lblGvTab2_StockNo");
                    float IssueQty = float.Parse(gr.Cells[6].Text, CultureInfo.InvariantCulture.NumberFormat);

                    objData.IssueID = Convert.ToInt64(IssueID.Text == "" ? "0" : IssueID.Text);
                    objData.IssueNo = IssueNo.Text == "" ? "0" : IssueNo.Text;
                    objData.StockNo = StockNo.Text == "" ? "0" : StockNo.Text;
                    objData.IssueQty = IssueQty;
                    objData.EmployeeID = LoginToken.EmployeeID;
                    objData.AcademicSessionID = LoginToken.AcademicSessionID;
                    objData.CompanyID = LoginToken.CompanyID;
                    int Result = objdBO.DeleteStockIssueByIssueID(objData);

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
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
    }
}