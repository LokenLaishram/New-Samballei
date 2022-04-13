using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class SalutationMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                bindgrid(1);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SalutationData objSalutation = new SalutationData();
                SalutationBO objSalutationBO = new SalutationBO();
                objSalutation.Code = txtcode.Text;
                objSalutation.Descriptions = txtdescription.Text;
                objSalutation.UserId = LoginToken.UserLoginId;
                objSalutation.AddedBy = LoginToken.LoginId;
                objSalutation.CompanyID = LoginToken.CompanyID;
                //objclass.IsActive = ddlstatus.SelectedValue == "1" ? true : false; ;
                objSalutation.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objSalutation.ActionType = EnumActionType.Update;
                    objSalutation.SalutationID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objSalutationBO.UpdateSalutationDetails(objSalutation);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SalutationData> lstclass = GetobjSalutationDatas(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvSalutation.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvSalutation.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                GvSalutation.PageIndex = index - 1;
                GvSalutation.DataSource = lstclass;
                GvSalutation.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvSalutation.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvSalutation.DataSource = null;
                GvSalutation.DataBind();
            }
        }
        public List<SalutationData> GetobjSalutationDatas(int curIndex, int pagesize)
        {
            SalutationData objSalutation = new SalutationData();
            SalutationBO objSalutationBO = new SalutationBO();
            objSalutation.Code = txtcode.Text == "" ? null : txtcode.Text;
            objSalutation.Descriptions = txtdescription.Text == "" ? null : txtdescription.Text;
            objSalutation.ActionType = EnumActionType.Select;
            objSalutation.PageSize = pagesize;
            objSalutation.CurrentIndex = curIndex;
            return objSalutationBO.SearchSalutationDetails(objSalutation);
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
            GvSalutation.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvSalutation.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSalutation.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvSalutation.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSalutation.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvSalutation.UseAccessibleHeader = true;
            GvSalutation.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void GvSalutationDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSalutation.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvSalutationDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvSalutation.DataSource = sortedView;
                    GvSalutation.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvSalutation.HeaderRow.Cells[ColumnIndex];
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
        protected void GvSalutationDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    SalutationData objSalutation = new SalutationData();
                    SalutationBO objSalutationBO = new SalutationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSalutation.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objSalutation.SalutationID = Convert.ToInt32(ID.Text);
                    objSalutation.ActionType = EnumActionType.Select;
                    List<SalutationData> GetResult = objSalutationBO.GetSalutationDetailsByID(objSalutation);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].Descriptions;
                        ViewState["ID"] = GetResult[0].SalutationID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    SalutationData objSalutation = new SalutationData();
                    SalutationBO objSalutationBO = new SalutationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSalutation.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objSalutation.SalutationID = Convert.ToInt32(ID.Text);
                    objSalutation.ActionType = EnumActionType.Delete;
                    int Result = objSalutationBO.DeleteSalutationDetailsByID(objSalutation);
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
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            bindgrid(1);
        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
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
                Response.AddHeader("content-disposition", "attachment;filename= SalutationDetails.xlsx");
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
            List<SalutationData> objSalutationData = GetobjSalutationDatas(1, size);
            List<SalutationDataExcel> objSalutationDataExcel = new List<SalutationDataExcel>();
            int i = 0;
            foreach (SalutationData row in objSalutationData)
            {
                SalutationDataExcel EcxeclStd = new SalutationDataExcel();
                EcxeclStd.Code = objSalutationData[i].Code;
                EcxeclStd.Descriptions = objSalutationData[i].Descriptions;
                objSalutationDataExcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(objSalutationDataExcel);
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
    }
}