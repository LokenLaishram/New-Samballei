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
    public partial class SubgroupMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                BindDlls();
                bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.Group));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (LoginToken.SaveEnable == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("saveenable") + "')", true);
                //    bindresponsive();
                //    return;
                //}
                SubgroupData obj = new SubgroupData();
                SubgroupBO objBO = new SubgroupBO();
                obj.Groupid = Convert.ToInt32(ddl_group.SelectedValue == "0" ? "0" : ddl_group.SelectedValue);
                obj.Subgroupname = txt_Subgroup.Text.Trim() == "" ? null : txt_Subgroup.Text.Trim();
                obj.IsActive = ddl_status.SelectedValue == "1" ? true : false; ;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.CompanyID = LoginToken.CompanyID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.ActionType = EnumActionType.Insert; // insert
                if (ViewState["ID"] != null)
                {
                    obj.ActionType = EnumActionType.Update; // update
                    obj.Subgroupid = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objBO.SaveGroup(obj);
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
        protected void Gv_subgroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    //if (LoginToken.EditEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("editenable") + "')", true);
                    //    return;
                    //}
                    SubgroupData objGroup = new SubgroupData();
                    SubgroupBO objGroupBO = new SubgroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_subgroup.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objGroup.Subgroupid = Convert.ToInt32(ID.Text);
                    ViewState["ID"] = objGroup.Subgroupid;
                    List<SubgroupData> GetResult = objGroupBO.GetSubGroupbyID(objGroup);
                    if (GetResult.Count > 0)
                    {
                        ddl_group.SelectedValue = GetResult[0].Groupid.ToString();
                        txt_Subgroup.Text = GetResult[0].Subgroupname;
                        ddl_status.SelectedValue = GetResult[0].IsActive == true ? "1" : "0";
                        ViewState["ID"] = GetResult[0].Subgroupid;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    return;
                    //}
                    SubgroupData objGroup = new SubgroupData();
                    SubgroupBO objGroupBO = new SubgroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_subgroup.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objGroup.Subgroupid = Convert.ToInt32(ID.Text);
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
                        objGroup.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    objGroup.ActionType = EnumActionType.Delete;
                    int Result = objGroupBO.DeleteSubGroupbyID(objGroup);
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
                    SubgroupData objgrp = new SubgroupData();
                    SubgroupBO objgrpBO = new SubgroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_subgroup.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrp.Subgroupid = Convert.ToInt32(ID.Text);
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
            //    return;
            //}
            Boolean status = ddl_status.SelectedValue == "1" ? true : false;
            string url = "../Utility/Reports/Reportviewer.aspx?option=GroupList&GroupID=" + 0 + "&status=" + status;
            string fullURL = "window.open('" + url + "', '_blank');";

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SubgroupData> lstclass = getSubGrouplist(index, pagesize);
            if (lstclass.Count > 0)
            {
                if (ddl_status.SelectedValue == "0")
                {
                    Gv_subgroup.Columns[7].Visible = true;
                }
                else
                {
                    Gv_subgroup.Columns[7].Visible = false;
                }
                Gv_subgroup.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lbl_totalrecords.Visible = false;
                lblresult.Visible = true;
                Gv_subgroup.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                Gv_subgroup.PageIndex = index - 1;
                Gv_subgroup.DataSource = lstclass;
                Gv_subgroup.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = Gv_subgroup.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gv_subgroup.DataSource = null;
                Gv_subgroup.DataBind();
                lbl_totalrecords.Visible = false;
                lblresult.Visible = false;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_subgroup.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_subgroup.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_subgroup.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_subgroup.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //Gv_subgroup.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_subgroup.UseAccessibleHeader = true;
            Gv_subgroup.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void Gv_subgroup_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_subgroup.DataSource = sortedView;
                    Gv_subgroup.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_subgroup.HeaderRow.Cells[ColumnIndex];
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
        public List<SubgroupData> getSubGrouplist(int curIndex, int pagesize)
        {
            SubgroupData objGroup = new SubgroupData();
            SubgroupBO objGroupBO = new SubgroupBO();
            objGroup.Groupid = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objGroup.Subgroupname = txt_Subgroup.Text == "" ? null : txt_Subgroup.Text;
            objGroup.PageSize = pagesize;
            objGroup.CurrentIndex = curIndex;
            objGroup.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            return objGroupBO.SearchSubGroup(objGroup);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.Group));
            ddl_group.SelectedIndex = 0;
            txt_Subgroup.Text = "";
            btnprint.Visible = false;
            bindgrid(1);
            btnsave.Text = "Add";

        }
        protected void Gv_subgroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_subgroup.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "SubGroup List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= SubGroup.xlsx");
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
            List<SubgroupData> Groupdetail = getSubGrouplist(1, size);
            List<SubgroupDatatoXL> grouptoexcel = new List<SubgroupDatatoXL>();
            int i = 0;
            foreach (SubgroupData row in Groupdetail)
            {
                SubgroupDatatoXL EcxeclGroup = new SubgroupDatatoXL();
                EcxeclGroup.Group = Groupdetail[i].Groupname;
                EcxeclGroup.Subgroupname = Groupdetail[i].Subgroupname;
                grouptoexcel.Add(EcxeclGroup);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(grouptoexcel);
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
    }
}