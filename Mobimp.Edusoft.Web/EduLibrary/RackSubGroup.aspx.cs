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
using Mobimp.Edusoft.Data.EduLibrary;
using Mobimp.Edusoft.BussinessProcess.EduLibrary;

namespace Mobimp.Edusoft.Web.EduLibrary
{
    public partial class RackSubGroup : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                bindgrid(1);
                bindddl();
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlgroup, mstlookup.GetLookupsList(LookupNames.RackGroup));
            //Commonfunction.Insertzeroitemindex(ddlgroup);
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                RackSubGroupData objgrp = new RackSubGroupData();
                RackSubGroupBO objgrpBO = new RackSubGroupBO();
                objgrp.GroupID = Convert.ToInt32(ddlgroup.SelectedValue == "" ? "0" : ddlgroup.SelectedValue);
                objgrp.SubGroupName = txtsubgroup.Text;
                objgrp.IsActive = ddlstatus.SelectedValue == "1" ? true : false; ;
                objgrp.UserId = LoginToken.UserLoginId;
                objgrp.AddedBy = LoginToken.LoginId;
                objgrp.CompanyID = LoginToken.CompanyID;
                objgrp.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objgrp.ActionType = EnumActionType.Update;
                    objgrp.SubGroupID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objgrpBO.UpdateRackSubGroupDetails(objgrp);
                if (result == 1 || result == 2)
                {
                    clearall();
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
        protected void GvRackSubGroupDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    RackSubGroupData objgrp = new RackSubGroupData();
                    RackSubGroupBO objgrpBO = new RackSubGroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRackSubGroupDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrp.SubGroupID = Convert.ToInt32(ID.Text);
                    List<RackSubGroupData> GetResult = objgrpBO.GetRackSubGroupDetailsByID(objgrp);
                    if (GetResult.Count > 0)
                    {
                        ddlgroup.SelectedValue = GetResult[0].GroupID.ToString();
                        txtsubgroup.Text = GetResult[0].SubGroupName;
                        ViewState["ID"] = GetResult[0].SubGroupID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    RackSubGroupData objgrp = new RackSubGroupData();
                    RackSubGroupBO objgrpBO = new RackSubGroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRackSubGroupDetails.Rows[i];
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrp.SubGroupID = Convert.ToInt32(ID.Text);
                    objgrp.ActionType = EnumActionType.Delete;
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + "Please write remarks" + "')", true);
                        txtremarks.Focus();
                        return;
                    }
                    objgrp.Remarks = txtremarks.Text;
                    int Result = objgrpBO.DeleteRackSubGroupDetailsByID(objgrp);
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
                    RackSubGroupData objgrp = new RackSubGroupData();
                    RackSubGroupBO objgrpBO = new RackSubGroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRackSubGroupDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrp.SubGroupID = Convert.ToInt32(ID.Text);
                    int Result = objgrpBO.Activate(objgrp);
                    if (Result == 1)
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<RackSubGroupData> lstgroup = GetRackSubGroupdetails(index, pagesize);
            if (lstgroup.Count > 0)
            {
                if (ddlstatus.SelectedValue == "0")
                {
                    GvRackSubGroupDetails.Columns[6].Visible = true;
                }
                else
                {
                    GvRackSubGroupDetails.Columns[6].Visible = false;
                }
                GvRackSubGroupDetails.PageSize = pagesize;
                string record = lstgroup[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstgroup[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstgroup[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvRackSubGroupDetails.VirtualItemCount = lstgroup[0].MaximumRows;//total item is required for custom paging
                GvRackSubGroupDetails.PageIndex = index - 1;
                GvRackSubGroupDetails.DataSource = lstgroup;
                GvRackSubGroupDetails.DataBind();
                ds = ConvertToDataSet(lstgroup);
                TableCell tableCell = GvRackSubGroupDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvRackSubGroupDetails.DataSource = null;
                GvRackSubGroupDetails.DataBind();
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvRackSubGroupDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvRackSubGroupDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvRackSubGroupDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvRackSubGroupDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvRackSubGroupDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvRackSubGroupDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvRackSubGroupDetails.UseAccessibleHeader = true;
            GvRackSubGroupDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvRackSubGroupDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvRackSubGroupDetails.DataSource = sortedView;
                    GvRackSubGroupDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvRackSubGroupDetails.HeaderRow.Cells[ColumnIndex];
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
        //protected void btnactivate_Click(object sender, EventArgs e)
        //{
        //    List<RackSubGroupData> lstclasslist = new List<RackSubGroupData>();
        //    RackSubGroupData objgrp = new RackSubGroupData();
        //    RackSubGroupBO objgrpBO = new RackSubGroupBO();
        //    int index = 0;
        //    int count = 0;
        //    try
        //    {                // get all the record from the gridview
        //        foreach (GridViewRow row in GvRackSubGroupDetails.Rows)
        //        {
        //            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
        //            Label GroupID = (Label)GvRackSubGroupDetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
        //            CheckBox chk = (CheckBox)GvRackSubGroupDetails.Rows[row.RowIndex].Cells[0].FindControl("chekboxselect");
        //            RackSubGroupData ObjDetails = new RackSubGroupData();
        //            if (chk.Checked)
        //            {
        //                ObjDetails.GroupID = Convert.ToInt32(GroupID.Text);
        //                count = count + 1;
        //                // ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
        //                lstclasslist.Add(ObjDetails);
        //                index++;
        //            }
        //        }
        //        objgrp.Xmlclasslist = XmlConvertor.ActivatedclasstoXML(lstclasslist).ToString();
        //        if (count == 0)
        //        {
        //            Messagealert_.ShowMessage(lblresult, "Please select atleast one Class", 0);
        //            return;
        //        }
        //        int results = objgrpBO.Activate(objgrp);
        //        if (results == 1)
        //        {
        //            bindgrid();
        //            Messagealert_.ShowMessage(lblresult, "Successfully activated", 1);
        //        }
        //        else
        //        {
        //            Messagealert_.ShowMessage(lblresult, "Error", 0);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        lblresult.Text = ExceptionMessage.GetMessage(ex);
        //        lblresult.Visible = true;
        //        lblresult.CssClass = "Message";
        //    }
        //}
        public List<RackSubGroupData> GetRackSubGroupdetails(int curIndex, int pagesize)
        {
            RackSubGroupData objgrp = new RackSubGroupData();
            RackSubGroupBO objgrpBO = new RackSubGroupBO();
            objgrp.GroupID = Convert.ToInt32(ddlgroup.SelectedValue == "" ? "0" : ddlgroup.SelectedValue);
            objgrp.SubGroupName = txtsubgroup.Text == "" ? null : txtsubgroup.Text;
            objgrp.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objgrp.ActionType = EnumActionType.Select;
            objgrp.PageSize = pagesize;
            objgrp.CurrentIndex = curIndex;
            return objgrpBO.SearchRackSubGroupDetails(objgrp);
        }
        private void clearall()
        {
            txtsubgroup.Text = "";
            ddlgroup.SelectedIndex = 0;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtsubgroup.Text = "";
            ddlgroup.SelectedIndex = 0;
            bindgrid(1);

        }
        protected void GvRackSubGroupDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvRackSubGroupDetails.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Class List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= RackGroup.xlsx");
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
            List<RackSubGroupData> grpDetail = GetRackSubGroupdetails(1, size);
            List<RackSubGroupDatatoExcel> grptoexcel = new List<RackSubGroupDatatoExcel>();
            int i = 0;
            foreach (RackSubGroupData row in grpDetail)
            {
                RackSubGroupDatatoExcel EcxeclStd = new RackSubGroupDatatoExcel();
                EcxeclStd.GroupName = grpDetail[i].GroupName;
                EcxeclStd.SubGroupName = grpDetail[i].SubGroupName;
                grptoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(grptoexcel);
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
            ExportoExcel();
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}