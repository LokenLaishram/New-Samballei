using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class ReligionMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                lblmessage.Visible = true;
                bindgrid(1);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ReligionData objdesignation = new ReligionData();
                ReligionBO objReligionBO = new ReligionBO();
                objdesignation.Code = txtcode.Text;
                objdesignation.Descriptions = txtdescription.Text;
                objdesignation.AddedBy = LoginToken.LoginId;
                objdesignation.UserId = LoginToken.UserLoginId; ;
                objdesignation.CompanyID = LoginToken.CompanyID;
                objdesignation.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objdesignation.ActionType = EnumActionType.Update;
                    objdesignation.ReligionID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objReligionBO.UpdateReligionDetails(objdesignation);
                if (result == 1 || result == 2)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    clearall();
                    GvReligiondetails.DataSource = GetReligiondetails(1, 10);
                    GvReligiondetails.DataBind();
                    
                }
                else
                {
                    // Messagealert_.ShowMessage(lblmessage, "system", 0);
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
        protected void GvReligiondetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ReligionData objdesignation = new ReligionData();
                    ReligionBO objReligionBO = new ReligionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvReligiondetails.Rows[i];
                    Label ReligionID = (Label)gr.Cells[0].FindControl("lblID");
                    objdesignation.ReligionID = Convert.ToInt32(ReligionID.Text);
                    objdesignation.ActionType = EnumActionType.Select;

                    List<ReligionData> GetResult = objReligionBO.GetReligionDetailsByID(objdesignation);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].Descriptions;
                        ViewState["ID"] = GetResult[0].ReligionID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ReligionData objdesignation = new ReligionData();
                    ReligionBO objReligionBO = new ReligionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvReligiondetails.Rows[i];
                    Label ReligionID = (Label)gr.Cells[0].FindControl("lblID");
                    objdesignation.ReligionID = Convert.ToInt16(ReligionID.Text);
                    objdesignation.ActionType = EnumActionType.Delete;
                    int Result = objReligionBO.DeleteReligionDetailsByID(objdesignation);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ReligionData> lstreligion = GetReligiondetails(index, pagesize);
            if (lstreligion.Count > 0)
            {
                GvReligiondetails.PageSize = pagesize;
                string record = lstreligion[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstreligion[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstreligion[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvReligiondetails.VirtualItemCount = lstreligion[0].MaximumRows;//total item is required for custom paging
                GvReligiondetails.PageIndex = index - 1;
                GvReligiondetails.DataSource = lstreligion;
                GvReligiondetails.DataBind();
                ds = ConvertToDataSet(lstreligion);
                TableCell tableCell = GvReligiondetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvReligiondetails.DataSource = null;
                GvReligiondetails.DataBind();
                divsearch.Visible = true;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvReligiondetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvReligiondetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvReligiondetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvReligiondetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvReligiondetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //GvReligiondetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvReligiondetails.UseAccessibleHeader = true;
            GvReligiondetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        public List<ReligionData> GetReligiondetails(int curIndex, int pagesize)
        {
            ReligionData objdesignation = new ReligionData();
            ReligionBO objReligionBO = new ReligionBO();
            objdesignation.Code = txtcode.Text == "" ? null : txtcode.Text;
            objdesignation.Descriptions = txtdescription.Text == "" ? null : txtdescription.Text;
            objdesignation.ActionType = EnumActionType.Select;
            objdesignation.PageSize = pagesize;
            objdesignation.CurrentIndex = curIndex;
            return objReligionBO.SearchReligionDetails(objdesignation);

        }
        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
            divsearch.Visible = false;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            bindgrid(1);
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
                wb.Worksheets.Add(dt, "Religion Type");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= ReligionDetails.xlsx");
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
            List<ReligionData> ReligionTypeDetail = GetReligiondetails(1, size);
            List<ReligionTypeDatatoExcel> religiontypetoexcel = new List<ReligionTypeDatatoExcel>();
            int i = 0;
            foreach (ReligionData row in ReligionTypeDetail)
            {
                ReligionTypeDatatoExcel EcxeclStd = new ReligionTypeDatatoExcel();
                EcxeclStd.Code = ReligionTypeDetail[i].Code;
                EcxeclStd.Descriptions = ReligionTypeDetail[i].Descriptions;
                religiontypetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(religiontypetoexcel);
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
        protected void GvReligiondetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvReligiondetails.DataSource = sortedView;
                    GvReligiondetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvReligiondetails.HeaderRow.Cells[ColumnIndex];
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
        protected void GvReligiondetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvReligiondetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }


    }
}