using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using static Mobimp.Campusoft.Web.EduAnalytics.PerformanceChart;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class DistrictMST : BasePage
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
            Commonfunction.PopulateDdl(ddlcountry, mstlookup.GetLookupsList(LookupNames.Country));
            Commonfunction.PopulateDdl(ddlstate, mstlookup.GetLookupsList(LookupNames.State));
        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictBO objDistrictBO = new DistrictBO();
            Commonfunction.PopulateDdl(ddlstate, objDistrictBO.GetStatelistByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DistrictData ObjSate = new DistrictData();
                DistrictBO objDistrictBO = new DistrictBO();
                ObjSate.Code = txtcode.Text;
                ObjSate.Descriptions = txtdescription.Text;
                ObjSate.AddedBy = LoginToken.LoginId;
                ObjSate.UserId = LoginToken.UserLoginId;
                ObjSate.CountryID = Convert.ToInt32(ddlcountry.SelectedValue);
                ObjSate.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                ObjSate.CompanyID = LoginToken.CompanyID;
                ObjSate.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    ObjSate.ActionType = EnumActionType.Update;
                    ObjSate.DistrictID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objDistrictBO.UpdateDistrictDetails(ObjSate);
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
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "MessageFailed";
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
            List<DistrictData> lstclass = GetDistrictdetails(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvDistrict.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvDistrict.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                GvDistrict.PageIndex = index - 1;
                GvDistrict.DataSource = lstclass;
                GvDistrict.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvDistrict.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvDistrict.DataSource = null;
                GvDistrict.DataBind();
            }
        }
        public List<DistrictData> GetDistrictdetails(int curIndex, int pagesize)
        {
            DistrictData ObjSate = new DistrictData();
            DistrictBO objDistrictBO = new DistrictBO();
            ObjSate.Code = txtcode.Text == "" ? null : txtcode.Text;
            ObjSate.Descriptions = txtdescription.Text == "" ? null : txtdescription.Text;
            ObjSate.ActionType = EnumActionType.Select;
            ObjSate.PageSize = pagesize;
            ObjSate.CurrentIndex = curIndex;
            return objDistrictBO.SearchDistrictDetails(ObjSate);
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
            GvDistrict.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvDistrict.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvDistrict.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvDistrict.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvDistrict.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvDistrict.UseAccessibleHeader = true;
            GvDistrict.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void GvDistrictDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDistrict.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvDistrictDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvDistrict.DataSource = sortedView;
                    GvDistrict.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvDistrict.HeaderRow.Cells[ColumnIndex];
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
        protected void GvDistrictDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {             
                if (e.CommandName == "Edits")
                {
                    DistrictData ObjSate = new DistrictData();
                    DistrictBO objDistrictBO = new DistrictBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvDistrict.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    ObjSate.DistrictID = Convert.ToInt32(ID.Text);
                    ObjSate.ActionType = EnumActionType.Select;
                    List<DistrictData> GetResult = objDistrictBO.GetDistrictDetailsByID(ObjSate);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].Descriptions;
                        ddlcountry.SelectedValue = GetResult[0].CountryID.ToString();
                        ddlstate.SelectedValue = GetResult[0].StateID.ToString();
                        ViewState["ID"] = GetResult[0].DistrictID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    DistrictData ObjSate = new DistrictData();
                    DistrictBO objDistrictBO = new DistrictBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvDistrict.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    ObjSate.DistrictID = Convert.ToInt32(ID.Text);
                    ObjSate.ActionType = EnumActionType.Delete;
                    int Result = objDistrictBO.DeleteDistrictDetailsByID(ObjSate);
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
                Response.AddHeader("content-disposition", "attachment;filename= DistrictDetails.xlsx");
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
            List<DistrictData> DistrictDetail = GetDistrictdetails(1, size);
            List<DistrictDatatoExcel> Districttoexcel = new List<DistrictDatatoExcel>();
            int i = 0;
            foreach (DistrictData row in DistrictDetail)
            {
                DistrictDatatoExcel EcxeclStd = new DistrictDatatoExcel();
                EcxeclStd.Code = DistrictDetail[i].Code;
                EcxeclStd.Details = DistrictDetail[i].Descriptions;
                Districttoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(Districttoexcel);
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