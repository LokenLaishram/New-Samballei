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
using Mobimp.Edusoft.Data.EduInvUtility;
using Mobimp.Edusoft.BussinessProcess.EduInvUtility;

namespace Mobimp.Edusoft.Web.EduInvUtility
{
    public partial class ItempriceMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bindgrid(1);
                bindddl();
                txt_item.Attributes["disabled"] = "disabled";
            }
        }
        public void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.Group));
            //Commonfunction.PopulateDdl(ddl_unit, mstlookup.GetLookupsList(LookupNames.Units));
            Commonfunction.PopulateDdl(ddl_Year, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.Insertzeroitemindex(ddl_subgroup);
            divivitem.Visible = false;
        }
        protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_group.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_subgroup, mstlookup.GetInvSubGroupByID(Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
                bindgrid(1);
            }
            else
            {
            }
        }
        protected void ddl_subgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_subgroup.SelectedIndex > 0)
            {
                txt_item.Text = "";
                txt_item.Attributes.Remove("disabled");
                AutoCompleteExtender2.ContextKey = ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue;
                bindgrid(1);
                bindresponsive();
            }
            else
            {
                txt_item.Text = "";
                txt_item.Attributes["disabled"] = "disabled";
            }
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
            bindresponsive();
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemNameAuto(string prefixText, int count, string contextKey)
        {
            ItemPriceData objitem = new ItemPriceData();
            ItemBO objBO = new ItemBO();
            List<ItemPriceData> getResult = new List<ItemPriceData>();
            objitem.ItemDetails = prefixText;
            objitem.Subgroupid = Convert.ToInt32(contextKey);
            getResult = objBO.GetAutoItemDetails(objitem);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemDetails.ToString());
            }

            return list;
        }
        protected void txt_item_TextChanged(object sender, EventArgs e)
        {
            if (txt_item.Text != "")
            {
                ItemPriceData objdata = new ItemPriceData();
                ItemBO objBO = new ItemBO();
                var source = txt_item.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.Itemid = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                    hdnitemid.Value = (ID == "" ? "0" : ID);
                    hdnacademic.Value = LoginToken.AcademicSessionID.ToString();
                }
                else
                {
                    txt_item.Text = "";
                }
            }
            bindgrid(1);
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    bindresponsive();
            //    return;
            //}
            Boolean status = ddl_status.SelectedValue == "1" ? true : false;
            int groupid = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            int subgroupid = Convert.ToInt32(ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue);
            int yearid = Convert.ToInt32(ddl_Year.SelectedValue == "" ? "0" : ddl_Year.SelectedValue);
            Int64 itemid = Commonfunction.SemicolonSeparation_String_64(txt_item.Text.Trim());
            string url = "../EduInvUtility/Reports/Reportviewer.aspx?option=ItemPriceList&AcademicSessionID=" + LoginToken.AcademicSessionID + "&GroupID=" + groupid + "&SubgroupID=" + subgroupid + "&ItemID=" + itemid + "&status=" + status + "&yearid=" + yearid;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            //bindgrid(1);
            //bindresponsive();
           
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            if (ddl_Year.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select batch year.") + "')", true);
                return;
            }

            List<ItemPriceData> lstclass = getitemlist(index, 0);
            if (lstclass.Count > 0)
            {
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass.Count.ToString(); ;
                lbl_totalrecords.Visible = true;
                lblresult.Visible = true;
                Gv_Item.DataSource = lstclass;
                Gv_Item.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = Gv_Item.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                divivitem.Visible = true;
                bindresponsive();
            }
            else
            {
                Gv_Item.DataSource = null;
                Gv_Item.DataBind();
                lbl_totalrecords.Visible = false;
                lblresult.Visible = false;
            }
        }
        public List<ItemPriceData> getitemlist(int curIndex, int pagesize)
        {
            ItemPriceData objitem = new ItemPriceData();
            ItemBO objitemBO = new ItemBO();
            objitem.YearID = Convert.ToInt32(ddl_Year.SelectedValue == "" ? "0" : ddl_Year.SelectedValue);
            objitem.YearName = ddl_Year.SelectedItem.Text == "" ? "" : ddl_Year.SelectedItem.Text;
            objitem.Groupid = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objitem.Subgroupid = Convert.ToInt32(ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue);
            objitem.Itemid = Commonfunction.SemicolonSeparation_String_64(txt_item.Text.Trim());
            objitem.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            objitem.AcademicSessionID = LoginToken.AcademicSessionID;
            objitem.EmployeeID = LoginToken.EmployeeID;
            return objitemBO.SearchItempricelist(objitem);
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_Item.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_Item.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_Item.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_Item.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_Item.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_Item.UseAccessibleHeader = true;
            Gv_Item.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void Gv_Item_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_Item.DataSource = sortedView;
                    Gv_Item.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_Item.HeaderRow.Cells[ColumnIndex];
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
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            ddl_Year.SelectedIndex = 0;
            ddl_group.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddl_subgroup);
            txt_item.Text = "";
            ddl_status.SelectedIndex = 0;
            divivitem.Visible = false;
        }
        protected void Gv_Item_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_Item.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Item Price List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= ItemPrice.xlsx");
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
            List<ItemPriceData> Itemdetail = getitemlist(1, 0);
            List<ItemPriceDatatoXL> Itemtoexcel = new List<ItemPriceDatatoXL>();
            int i = 0;
            foreach (ItemPriceData row in Itemdetail)
            {
                ItemPriceDatatoXL Ecxeclitem = new ItemPriceDatatoXL();
                Ecxeclitem.Groupname = Itemdetail[i].Groupname;
                Ecxeclitem.Subgroupname = Itemdetail[i].Subgroupname;
                Ecxeclitem.Itemname = Itemdetail[i].Itemname;
                Ecxeclitem.UnitName = Itemdetail[i].UnitName;
                Ecxeclitem.Price = Itemdetail[i].Price;
                Itemtoexcel.Add(Ecxeclitem);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(Itemtoexcel);
            return dt;
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
       
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<ItemPriceData> list = new List<ItemPriceData>();
                ItemBO objBO = new ItemBO();
                ItemPriceData obj = new ItemPriceData();
                foreach (GridViewRow row in Gv_Item.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ID = (Label)Gv_Item.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    Label itemID = (Label)Gv_Item.Rows[row.RowIndex].Cells[0].FindControl("lbl_itemid");
                    TextBox txt_price = (TextBox)Gv_Item.Rows[row.RowIndex].Cells[0].FindControl("txt_price");

                    ItemPriceData ObjDetails = new ItemPriceData();
                    ObjDetails.ItemPriceID = Convert.ToInt64(ID.Text == "" ? "0" : ID.Text);
                    ObjDetails.Itemid = Convert.ToInt64(itemID.Text == "" ? "0" : itemID.Text);
                    ObjDetails.Price = Convert.ToDecimal(txt_price.Text == "" ? "0" : txt_price.Text);
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.ItemPriceListtoXML(list).ToString();
                obj.YearID = Convert.ToInt32(ddl_Year.SelectedValue == "" ? "0" : ddl_Year.SelectedValue);
                obj.YearName = ddl_Year.SelectedItem.Text == "" ? "" : ddl_Year.SelectedItem.Text;
                obj.Groupid = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
                obj.Subgroupid = Convert.ToInt32(ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue);
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.EmployeeID = LoginToken.EmployeeID;

                int status = objBO.Updateitemprice(obj);
                if (status == 1)
                {
                    bindgrid(1);
                    bindresponsive();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
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