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
    public partial class StockStatus : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_VendorName, mstlookup.GetLookupsList(LookupNames.VendorName));
            Commonfunction.PopulateDdl(ddlSubGroupID, mstlookup.GetLookupsList(LookupNames.SubGroup));
            txtItemName.Attributes["disabled"] = "disabled";
            Commonfunction.PopulateDdl(ddl2VendorNameID, mstlookup.GetLookupsList(LookupNames.VendorName));
            Commonfunction.PopulateDdl(ddl2SubGroupID, mstlookup.GetLookupsList(LookupNames.SubGroup));
            txt2ItemName.Attributes["disabled"] = "disabled";
            hdnuserlogin.Value = LoginToken.EmployeeID.ToString();
        }
        protected void ddlSubGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubGroupID.SelectedIndex > 0)
            {
                txtItemName.Text = "";
                txtItemName.Attributes.Remove("disabled");
                AutoCompleteExtender2.ContextKey = ddlSubGroupID.SelectedValue == "" ? "0" : ddlSubGroupID.SelectedValue;
            }
            else
            {
                txtItemName.Text = "";
                txtItemName.Attributes["disabled"] = "disabled";
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
        protected void txtItemName_OnTextChanged(object sender, EventArgs e)
        {
            if (txtItemName.Text != "")
            {
                WorkOrderData objdata = new WorkOrderData();
                WorkOrderBO ObjBO = new WorkOrderBO();
                var source = txtItemName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.ItemID = Convert.ToInt32(ID == "" ? "0" : ID);
                    hdnitemid1.Value = ID == "" ? "0" : ID;
                }
            }
         bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StockStatusData> StockList = GetStockStatus(index, pagesize);
            if (StockList.Count > 0)
            {
                Gv_StockStatus.PageSize = pagesize;
                string record = StockList[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + StockList[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = StockList[0].MaximumRows.ToString();
                txtGdReceivedQty.Text = StockList[0].GdRecievedQty.ToString();
                txtGdIssuedQty.Text = StockList[0].GdIssuedQty.ToString();
                txtGdReturnQty.Text = StockList[0].GdReturnQty.ToString();
                txtGdCondemnQty.Text = StockList[0].GdCondemnQty.ToString();
                txtGdBalanceQty.Text = StockList[0].GdBalanceQty.ToString();
                txtGdIndentQty.Text = StockList[0].GdIndentQty.ToString();
                lblresult.Visible = true;
                Gv_StockStatus.VirtualItemCount = StockList[0].MaximumRows;//total item is required for custom paging
                Gv_StockStatus.PageIndex = index - 1;
                Gv_StockStatus.DataSource = StockList;
                Gv_StockStatus.DataBind();
                ds = ConvertToDataSet(StockList);
                TableCell tableCell = Gv_StockStatus.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gv_StockStatus.DataSource = null;
                Gv_StockStatus.DataBind();
            }
        }
        public List<StockStatusData> GetStockStatus(int curIndex, int pagesize)
        {
            StockStatusData objData = new StockStatusData();
            StockStatusBO objBO = new StockStatusBO();
            objData.VendorID = Convert.ToInt32(ddl_VendorName.SelectedValue == "" ? "0" : ddl_VendorName.SelectedValue);
            //objData.ItemID = Commonfunction.SemicolonSeparation_String_64(txtItemName.Text.Trim());
            objData.ItemID = Convert.ToInt32(hdnitemid1.Value == "" ? "0" : hdnitemid1.Value.ToString());
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txt_DateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_DateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime to = txt_DateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_DateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objData.Datefrom = from;
            objData.Dateto = to;
            objData.StockStatusID = Convert.ToInt32(ddlStockStatus.SelectedValue == "" ? "0" : ddlStockStatus.SelectedValue);
            objData.PageSize = pagesize;
            objData.CurrentIndex = curIndex;
            return objBO.GetStockStatus(objData);
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
            //Responsive 
            Gv_StockStatus.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Gv_StockStatus.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_StockStatus.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_StockStatus.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_StockStatus.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //  Adds THEAD and TBODY to GridView.
            Gv_StockStatus.UseAccessibleHeader = true;
            Gv_StockStatus.HeaderRow.TableSection = TableRowSection.TableHeader;

        }      
        protected void Gv_StockStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_StockStatus.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtGdReceivedQty.Text = "";
            txtGdIssuedQty.Text = "";
            txtGdReturnQty.Text = "";
            txtGdCondemnQty.Text = "";
            txtGdBalanceQty.Text = "";
            txtGdIndentQty.Text = "";
        }
        protected void Gv_StockStatus_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_StockStatus.DataSource = sortedView;
                    Gv_StockStatus.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_StockStatus.HeaderRow.Cells[ColumnIndex];
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

        //-----Tab Itemwise Status-------//
        protected void ddl2SubGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl2SubGroupID.SelectedIndex > 0)
            {
                txt2ItemName.Text = "";
                txt2ItemName.Attributes.Remove("disabled");
                AutoCompleteExtender1.ContextKey = ddl2SubGroupID.SelectedValue == "" ? "0" : ddl2SubGroupID.SelectedValue;
                bindgridItemwise(1);
            }
            else
            {
                txt2ItemName.Text = "";
                txt2ItemName.Attributes["disabled"] = "disabled";
            }
        }
        protected void btn2Search_OnClick(object sender, EventArgs e)
        {
            bindgridItemwise(1);
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemNametab2(string prefixText)
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
            if (txt2ItemName.Text != "")
            {
                WorkOrderData objdata = new WorkOrderData();
                WorkOrderBO ObjBO = new WorkOrderBO();
                var source = txt2ItemName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.ItemID = Convert.ToInt32(ID == "" ? "0" : ID);
                    hdnitemid2.Value = ID == "" ? "0" : ID;
                }
            }
            bindgridItemwise(1);
        }
        private void bindgridItemwise(int index)
        {
            int pagesize = 10000;// Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl2totalrecords.Text : ddl_show.SelectedValue);
            List<StockStatusData> ItemwiseList = GetItemWiseStatus(index, pagesize);
            if (ItemwiseList.Count > 0)
            {
                GvItemwiseStatus.PageSize = pagesize;
                string record = ItemwiseList[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lbl2result.Text = "Total : " + ItemwiseList[0].MaximumRows.ToString() + " " + record;
                lbl2result.Visible = true;
                lbl2totalrecords.Text = ItemwiseList[0].MaximumRows.ToString();
                txt2GdReceivedQty.Text = ItemwiseList[0].GdRecievedQty.ToString();
                txt2GdIssuedQty.Text = ItemwiseList[0].GdIssuedQty.ToString();
                txt2GdReturnQty.Text = ItemwiseList[0].GdReturnQty.ToString();
                txt2GdCondemnQty.Text = ItemwiseList[0].GdCondemnQty.ToString();
                txt2GdBalanceQty.Text = ItemwiseList[0].GdBalanceQty.ToString();
                txt2GdIndentQty.Text = ItemwiseList[0].GdIndentQty.ToString();

                GvItemwiseStatus.VirtualItemCount = ItemwiseList[0].MaximumRows; //total item is required for custom paging
                GvItemwiseStatus.PageIndex = index - 1;
                GvItemwiseStatus.DataSource = ItemwiseList;
                GvItemwiseStatus.DataBind();           
              
            }
            else
            {
                GvItemwiseStatus.DataSource = null;
                GvItemwiseStatus.DataBind();
            }
        }
        public List<StockStatusData> GetItemWiseStatus(int curIndex, int pagesize)
        {
            StockStatusData objData = new StockStatusData();
            StockStatusBO objBO = new StockStatusBO();
            objData.VendorID = Convert.ToInt32(ddl2VendorNameID.SelectedValue == "" ? "0" : ddl2VendorNameID.SelectedValue);
            objData.SubGroupID = Convert.ToInt32(ddl2SubGroupID.SelectedValue == "" ? "0" : ddl2SubGroupID.SelectedValue);
            // objData.ItemID = Commonfunction.SemicolonSeparation_String_64(txt2ItemName.Text.Trim());
            objData.ItemID = Convert.ToInt32(hdnitemid2.Value == "" ? "0" : hdnitemid2.Value.ToString());
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txt2FromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt2FromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime to = txt2ToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt2ToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objData.Datefrom = from;
            objData.Dateto = to;
            objData.StockStatusID = Convert.ToInt32(ddl2StockStatusID.SelectedValue == "" ? "0" : ddl2StockStatusID.SelectedValue);
            objData.PageSize = pagesize;
            objData.CurrentIndex = curIndex;
            return objBO.GetItemwiseStockStatus(objData);
        }
        protected void bindresponsive2()
        {
            //Responsive 
            GvItemwiseStatus.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvItemwiseStatus.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvItemwiseStatus.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvItemwiseStatus.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvItemwiseStatus.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //  Adds THEAD and TBODY to GridView.
            GvItemwiseStatus.UseAccessibleHeader = true;
            GvItemwiseStatus.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void GvItemwiseStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvItemwiseStatus.PageIndex = e.NewPageIndex;
            bindgridItemwise(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btn2Reset_Click(object sender, EventArgs e)
        {
            txt2GdReceivedQty.Text = "";
            txt2GdIssuedQty.Text = "";
            txt2GdReturnQty.Text = "";
            txt2GdCondemnQty.Text = "";
            txt2GdBalanceQty.Text = "";
            txt2GdIndentQty.Text = "";
            GvItemwiseStatus.DataSource = null;
            GvItemwiseStatus.DataBind();
            lbl2result.Visible = false;
            lbl2totalrecords.Text = "";
        }
        protected void btn2Print_OnClick(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    bindresponsive();
            //    return;
            //}
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime Datefrom = txt2FromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt2FromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime Dateto = txt2ToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt2ToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            string DF = Datefrom.ToString("dd/MM/yyyy");
            string DT = Dateto.ToString("dd/MM/yyyy");
            Int64 EmployeeID = LoginToken.EmployeeID;
            string url = "../Stock/Report/Reportviewer.aspx?option=ItemwiseStockStatus&DateFrom=" + DF + "&DateTo=" + DT +"&PrintedBy=" + EmployeeID;
            string fullURL = "window.open('" + url + "', '_blank');";
        
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
    }
}