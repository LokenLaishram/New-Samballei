using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;


namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class SectionMST : BasePage
    {

        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                bindgrid(1);
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(ddlsection);
        }
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsection, mstlookup.GetLookupsList(LookupNames.Sectionlist));
            bindgrid(1);
        }

        protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SectionData ObjSate = new SectionData();
                SectionBO objSectionBO = new SectionBO();
                ObjSate.AddedBy = LoginToken.LoginId;
                ObjSate.UserId = LoginToken.UserLoginId;
                ObjSate.ClassID = Convert.ToInt32(ddlclass.SelectedValue);
                ObjSate.SectionID = Convert.ToInt32(ddlsection.SelectedValue);
                ObjSate.CompanyID = LoginToken.CompanyID;
                ObjSate.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    ObjSate.ActionType = EnumActionType.Update;
                    ObjSate.ID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objSectionBO.UpdateSectionDetails(ObjSate);
                if (result == 1 || result == 2)
                {
                    //clearall();
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    clearall();
                    GvSectionDetails.DataSource = GetSectiondetails(0);
                    GvSectionDetails.DataBind();
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
        protected void GvSectionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    SectionData ObjSate = new SectionData();
                    SectionBO objSectionBO = new SectionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSectionDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    ObjSate.ID = Convert.ToInt32(ID.Text);
                    ObjSate.ActionType = EnumActionType.Select;
                    List<SectionData> GetResult = objSectionBO.GetSectionDetailsByID(ObjSate);
                    if (GetResult.Count > 0)
                    {
                        ddlclass.SelectedValue = GetResult[0].ClassID.ToString();
                        ddlsection.SelectedValue = GetResult[0].SectionID.ToString();
                        ViewState["ID"] = GetResult[0].ID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    SectionData ObjSate = new SectionData();
                    SectionBO objSectionBO = new SectionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSectionDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    ObjSate.ID = Convert.ToInt16(ID.Text);
                    ObjSate.ActionType = EnumActionType.Delete;
                    int Result = objSectionBO.DeleteSectionDetailsByID(ObjSate);
                    if (Result == 1)
                    {
                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        //GvSectionDetails.DataSource = GetSectiondetails(0);
                        //GvSectionDetails.DataBind();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
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
            //divsearch.Visible = true;
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SectionData> lstsection = GetSectiondetails(index, pagesize);
            if (lstsection.Count > 0)
            {
                GvSectionDetails.PageSize = pagesize;
                string record = lstsection[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstsection[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstsection[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvSectionDetails.VirtualItemCount = lstsection[0].MaximumRows;//total item is required for custom paging
                GvSectionDetails.PageIndex = index - 1;
                GvSectionDetails.DataSource = lstsection;
                GvSectionDetails.DataBind();
                ds = ConvertToDataSet(lstsection);
                TableCell tableCell = GvSectionDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvSectionDetails.DataSource = null;
                GvSectionDetails.DataBind();
                divsearch.Visible = true;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvSectionDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvSectionDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSectionDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvSectionDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSectionDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvSectionDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";

            //GvSectionDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvSectionDetails.UseAccessibleHeader = true;
            GvSectionDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        public List<SectionData> GetSectiondetails(int curIndex, int pagesize)
        {
            SectionData objsection = new SectionData();
            SectionBO objsectionBO = new SectionBO();
            objsection.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objsection.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
            objsection.ActionType = EnumActionType.Select;
            objsection.PageSize = pagesize;
            objsection.CurrentIndex = curIndex;
            return objsectionBO.SearchSectionDetails(objsection);
        }
        private void clearall()
        {
            ddlclass.SelectedIndex = 0;
            ddlsection.SelectedIndex = 0;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
            bindgrid(1);
        }
        private object GetSectiondetails(int newPageIndex)
        {
            throw new NotImplementedException();
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
                Response.AddHeader("content-disposition", "attachment;filename= SectionList for" + ddlclass.SelectedValue == "" ? "All" : ddlclass.SelectedItem.Text + ".xlsx");
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
            List<SectionData> SectionDetail = GetSectiondetails(1, size);
            List<SectionDatatoExcel> sectiontoexcel = new List<SectionDatatoExcel>();
            int i = 0;
            foreach (SectionData row in SectionDetail)
            {

                SectionDatatoExcel EcxeclStd = new SectionDatatoExcel();
                EcxeclStd.Class = SectionDetail[i].ClassName;
                EcxeclStd.Section = SectionDetail[i].SectionName;
                sectiontoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(sectiontoexcel);
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
        protected void GvSectionDetails_Sorting1(object sender, GridViewSortEventArgs e)
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
                    GvSectionDetails.DataSource = sortedView;
                    GvSectionDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvSectionDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void GvSectionDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSectionDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
    }

}