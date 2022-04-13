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
    public partial class ItemMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid(1);
                bindddl();
            }
        }
        public void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.Group));
            // Commonfunction.PopulateDdl(ddl_subgroup, mstlookup.GetLookupsList(LookupNames.SubGroup));
            Commonfunction.PopulateDdl(ddl_unit, mstlookup.GetLookupsList(LookupNames.Units));
            Commonfunction.Insertzeroitemindex(ddl_subgroup);
        }
        protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_subgroup, mstlookup.GetInvSubGroupByID(Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            bindgrid(1);
            //bindresponsive();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (LoginToken.SaveEnable == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("saveenable") + "')", true);
                //    return;
                //}
                ItemData obj = new ItemData();
                ItemBO objBO = new ItemBO();
                obj.Groupid = Convert.ToInt32(ddl_group.SelectedItem.Value == "" ? "0" : ddl_group.SelectedItem.Value);
                obj.Subgroupid = Convert.ToInt32(ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue);
                obj.Itemname = txt_item.Text.Trim() == "" ? "" : txt_item.Text.Trim();
                obj.IsActive = ddl_status.SelectedValue == "1" ? true : false;
                obj.UnitID = Convert.ToInt32(ddl_unit.SelectedValue == "" ? "0" : ddl_unit.SelectedValue);
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.CompanyID = LoginToken.CompanyID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.ActionType = EnumActionType.Insert; 
                if (ViewState["ID"] != null)
                {
                    obj.ActionType = EnumActionType.Update; 
                    obj.Itemid = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objBO.SaveItemData(obj);
                if (result == 1 || result == 2)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);

                }
                bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void Gv_Item_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    //if (LoginToken.EditEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("editenable") + "')", true);
                    //    bindresponsive();
                    //    return;
                    //}
                    ItemData objitem = new ItemData();
                    ItemBO objitemBO = new ItemBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_Item.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objitem.Itemid = Convert.ToInt32(ID.Text);
                    List<ItemData> GetResult = objitemBO.GetItembyID(objitem);
                    if (GetResult.Count > 0)
                    {
                        ddl_group.SelectedValue = GetResult[0].Groupid.ToString();
                        MasterLookupBO mstlookup = new MasterLookupBO();
                        Commonfunction.PopulateDdl(ddl_subgroup, mstlookup.GetInvSubGroupByID(Convert.ToInt32(GetResult[0].Groupid)));
                        ddl_subgroup.SelectedValue = GetResult[0].Subgroupid.ToString();
                        txt_item.Text = GetResult[0].Itemname;
                        ddl_status.SelectedValue = GetResult[0].IsActive == true ? "1" : "0";
                        ddl_unit.SelectedValue = GetResult[0].UnitID.ToString();
                        ViewState["ID"] = GetResult[0].Itemid;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    bindresponsive();
                    //    return;
                    //}
                    ItemData objitem = new ItemData();
                    ItemBO objItemBO = new ItemBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_Item.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objitem.Itemid = Convert.ToInt32(ID.Text);
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objitem.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    objitem.ActionType = EnumActionType.Delete;
                    int Result = objItemBO.DeleteItembyID(objitem);
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
                if (e.CommandName == "activate")
                {
                    ItemData objgrp = new ItemData();
                    ItemBO objgrpBO = new ItemBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_Item.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrp.Itemid = Convert.ToInt32(ID.Text);
                    objgrp.ActionType = EnumActionType.Activate;
                    int Result = objgrpBO.Activate(objgrp);
                    if (Result == 2)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + "Activate successfully" + "')", true);
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
            string itemname = txt_item.Text.Trim() == "" ? null : txt_item.Text.Trim();
            string url = "../EduInvUtility/Reports/Reportviewer.aspx?option=ItemList&groupid=" + groupid + "&subgroupid=" + subgroupid + "&itemname=" + itemname + "&status=" + status;
            string fullURL = "window.open('" + url + "', '_blank');";
            bindresponsive();
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ItemData> lstclass = getitemlist(index, pagesize);
            if (lstclass.Count > 0)
            {
                if (ddl_status.SelectedValue == "0")
                {
                    Gv_Item.Columns[9].Visible = true;
                }
                else
                {
                    Gv_Item.Columns[9].Visible = false;
                }
                Gv_Item.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lblresult.Visible = true;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString();
                lbl_totalrecords.Visible = false;               
                Gv_Item.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                Gv_Item.PageIndex = index - 1;
                Gv_Item.DataSource = lstclass;
                Gv_Item.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = Gv_Item.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                btnprint.Visible = true;
            }
            else
            {
                Gv_Item.DataSource = null;
                Gv_Item.DataBind();
                btnprint.Visible = false;
                lbl_totalrecords.Visible = false;
            }
        }
        public List<ItemData> getitemlist(int curIndex, int pagesize)
        {
            ItemData objitem = new ItemData();
            ItemBO objitemBO = new ItemBO();
            objitem.Groupid = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objitem.Subgroupid = Convert.ToInt32(ddl_subgroup.SelectedValue == "" ? "0" : ddl_subgroup.SelectedValue);
            objitem.Itemname = txt_item.Text.Trim() == "" ? "" : txt_item.Text.Trim();
            objitem.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            objitem.UnitID = Convert.ToInt32(ddl_unit.SelectedValue == "" ? "0" : ddl_unit.SelectedValue);
            objitem.PageSize = pagesize;
            objitem.CurrentIndex = curIndex;
            return objitemBO.SearchItem(objitem);
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
            ddl_group.SelectedIndex = 0;
            ddl_subgroup.SelectedIndex = 0;
            txt_item.Text = "";
            ddl_status.SelectedIndex = 0;
            ddl_unit.SelectedIndex=0;
            btnsave.Text = "Add";
            bindgrid(1);
         

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
                wb.Worksheets.Add(dt, "Item List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Item.xlsx");
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
            List<ItemData> Itemdetail = getitemlist(1, size);
            List<ItemDatatoXL> Itemtoexcel = new List<ItemDatatoXL>();
            int i = 0;
            foreach (ItemData row in Itemdetail)
            {
                ItemDatatoXL Ecxeclitem = new ItemDatatoXL();
                Ecxeclitem.Groupname = Itemdetail[i].Groupname;
                Ecxeclitem.Subgroupname = Itemdetail[i].Subgroupname;
                Ecxeclitem.Itemname = Itemdetail[i].Itemname;
                Ecxeclitem.UnitName = Itemdetail[i].UnitName;
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
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddl_subgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
           
        }
    }
}