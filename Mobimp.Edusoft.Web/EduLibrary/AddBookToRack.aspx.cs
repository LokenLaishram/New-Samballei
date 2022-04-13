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
    public partial class AddBookToRack : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                bindgrid(1);
                bindddl();
                txtdescription.Attributes["disabled"] = "disabled";
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlgroup, mstlookup.GetLookupsList(LookupNames.RackGroup));
            Commonfunction.PopulateDdl(ddlsubgroup, mstlookup.GetLookupsList(LookupNames.RackSubGroup));
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
            if (ddlstatus.SelectedValue == "0")
            {
                GvAddBookDetails.Columns[7].Visible = true;
            }
            else
            {
                GvAddBookDetails.Columns[7].Visible = false;
            }
        }
        protected void ddlgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlgroup.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlsubgroup, mstlookup.GetSubGroupByGroupID(Convert.ToInt32(ddlgroup.SelectedValue == "" ? "0" : ddlgroup.SelectedValue)));
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlsubgroup);
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetBooksDetails(string prefixText, int count, string contextKey)
        {
            AddBookToRackData objitem = new AddBookToRackData();
            AddBookToRackBO objitemBO = new AddBookToRackBO();
            List<AddBookToRackData> getResult = new List<AddBookToRackData>();
            objitem.BookDetails = prefixText;
            objitem.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = objitemBO.GetAutoBookDetails(objitem);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].BookDetails.ToString());
            }

            return list;
        }
        protected void bookdetail_OnTextChanged(object sender, EventArgs e)
        {
            if (txtbook.Text != "")
            {
                AddBookToRackData objdata = new AddBookToRackData();
                AddBookToRackBO objitemBO = new AddBookToRackBO();
                var source = txtbook.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.BooksID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                }
                else
                {
                    txtbook.Text = "";
                }
                List<AddBookToRackData> result = objitemBO.GetBookDetailByID(objdata);
                if (result.Count > 0)
                {
                    txtdescription.Text = result[0].Description.ToString();
                    hdnbookid.Value = result[0].BooksID.ToString();
                    txtdescription.Attributes["disabled"] = "disabled";
                    bindgrid(1);
                }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                AddBookToRackData objgrp = new AddBookToRackData();
                AddBookToRackBO objgrpBO = new AddBookToRackBO();
                objgrp.GroupID = Convert.ToInt32(ddlgroup.SelectedValue == "" ? "0" : ddlgroup.SelectedValue);
                objgrp.SubGroupID = Convert.ToInt32(ddlsubgroup.SelectedValue == "" ? "0" : ddlsubgroup.SelectedValue);
                objgrp.Books = txtbook.Text;
                objgrp.Description = txtdescription.Text;
                objgrp.Qty = Convert.ToInt32(txtqty.Text == "" ? "0" : txtqty.Text);
                objgrp.BooksID = Convert.ToInt32(hdnbookid.Value == "" ? "0" : hdnbookid.Value);
                objgrp.IsActive = ddlstatus.SelectedValue == "1" ? true : false; 
                objgrp.UserId = LoginToken.UserLoginId;
                objgrp.AddedBy = LoginToken.LoginId;
                objgrp.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objgrp.ActionType = EnumActionType.Update;
                    objgrp.RackID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objgrpBO.UpdateAddBookToRack(objgrp);
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
        protected void GvAddBookDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    AddBookToRackData objgrp = new AddBookToRackData();
                    AddBookToRackBO objgrpBO = new AddBookToRackBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvAddBookDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrp.RackID = Convert.ToInt32(ID.Text);
                    List<AddBookToRackData> GetResult = objgrpBO.GetAddBookToRackByID(objgrp);
                    if (GetResult.Count > 0)
                    {
                        ddlgroup.SelectedValue = GetResult[0].GroupID.ToString();
                        ddlsubgroup.SelectedValue = GetResult[0].SubGroupID.ToString();
                        txtbook.Text = GetResult[0].BookDetails;
                        txtdescription.Text = GetResult[0].Description;
                        txtqty.Text = GetResult[0].Qty.ToString();
                        ViewState["ID"] = GetResult[0].RackID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    AddBookToRackData objgrp = new AddBookToRackData();
                    AddBookToRackBO objgrpBO = new AddBookToRackBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvAddBookDetails.Rows[i];
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Label groupID = (Label)gr.Cells[0].FindControl("lblgroupid");
                    Label subgroupID = (Label)gr.Cells[0].FindControl("lblsubgroupid");
                    Label booksID = (Label)gr.Cells[0].FindControl("lblbooksid");
                    Label lblqty = (Label)gr.Cells[0].FindControl("lblqty");
                    objgrp.RackID = Convert.ToInt32(ID.Text);
                    objgrp.GroupID = Convert.ToInt32(groupID.Text);
                    objgrp.SubGroupID = Convert.ToInt32(subgroupID.Text);
                    objgrp.BooksID = Convert.ToInt32(booksID.Text);
                    objgrp.Qty = Convert.ToInt32(lblqty.Text);
                    objgrp.ActionType = EnumActionType.Delete;
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + "Please write remarks" + "')", true);
                        txtremarks.Focus();
                        return;
                    }
                    objgrp.Remarks = txtremarks.Text;
                    int Result = objgrpBO.DeleteAddBookToRackByID(objgrp);
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
                    AddBookToRackData objgrp = new AddBookToRackData();
                    AddBookToRackBO objgrpBO = new AddBookToRackBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvAddBookDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrp.RackID = Convert.ToInt32(ID.Text);
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
            List<AddBookToRackData> lstgroup = GetRackSubGroupdetails(index, pagesize);
            if (lstgroup.Count > 0)
            {                
                GvAddBookDetails.PageSize = pagesize;
                string record = lstgroup[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstgroup[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstgroup[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvAddBookDetails.VirtualItemCount = lstgroup[0].MaximumRows;//total item is required for custom paging
                GvAddBookDetails.PageIndex = index - 1;
                GvAddBookDetails.DataSource = lstgroup;
                GvAddBookDetails.DataBind();
                ds = ConvertToDataSet(lstgroup);
                TableCell tableCell = GvAddBookDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvAddBookDetails.DataSource = null;
                GvAddBookDetails.DataBind();
            }
        }

        public List<AddBookToRackData> GetRackSubGroupdetails(int curIndex, int pagesize)
        {
            AddBookToRackData objgrp = new AddBookToRackData();
            AddBookToRackBO objgrpBO = new AddBookToRackBO();
            objgrp.GroupID = Convert.ToInt32(ddlgroup.SelectedValue == "" ? "0" : ddlgroup.SelectedValue);
            objgrp.SubGroupID = Convert.ToInt32(ddlsubgroup.SelectedValue == "" ? "0" : ddlsubgroup.SelectedValue);
            objgrp.Books = txtbook.Text;
            objgrp.Description = txtdescription.Text;
            objgrp.Qty = Convert.ToInt32(txtqty.Text == "" ? "0" : txtqty.Text);
            objgrp.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objgrp.ActionType = EnumActionType.Select;
            objgrp.PageSize = pagesize;
            objgrp.CurrentIndex = curIndex;
            return objgrpBO.SearchAddBookToRack(objgrp);
        }
        
        private void clearall()
        {
            ddlsubgroup.SelectedIndex = 0;
            ddlgroup.SelectedIndex = 0;
            txtbook.Text = "";
            txtdescription.Text = "";
            txtqty.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            ddlsubgroup.SelectedIndex = 0;
            ddlgroup.SelectedIndex = 0;
            bindgrid(1);

        }
        protected void bindresponsive()
        {
            //Responsive 
            GvAddBookDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvAddBookDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvAddBookDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvAddBookDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvAddBookDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvAddBookDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvAddBookDetails.UseAccessibleHeader = true;
            GvAddBookDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvAddBookDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvAddBookDetails.DataSource = sortedView;
                    GvAddBookDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvAddBookDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void GvAddBookDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAddBookDetails.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Book List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= AddBooklist.xlsx");
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
            List<AddBookToRackData> grpDetail = GetRackSubGroupdetails(1, size);
            List<AddBookToRackDatatoExcel> grptoexcel = new List<AddBookToRackDatatoExcel>();
            int i = 0;
            foreach (AddBookToRackData row in grpDetail)
            {
                AddBookToRackDatatoExcel EcxeclStd = new AddBookToRackDatatoExcel();
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
    }
}