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

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class TransportRouteManager : BasePage
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
                RouteData objclass = new RouteData();
                RouteBO objClassBO = new RouteBO();
                objclass.Code = txtcode.Text;
                objclass.Descriptions = txtroute.Text;
                objclass.Descriptions = txtroute.Text;
                objclass.UserId = LoginToken.UserLoginId;
                objclass.AddedBy = LoginToken.LoginId;
                objclass.CompanyID = LoginToken.CompanyID;
                objclass.IsActive = ddlstatus.SelectedValue == "1" ? true : false; ;
                objclass.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objclass.ActionType = EnumActionType.Update;
                    objclass.RouteID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objClassBO.UpdateRouteDetails(objclass);
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
        protected void GvRouteDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    RouteData objclass = new RouteData();
                    RouteBO objClassBO = new RouteBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRouteDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objclass.RouteID = Convert.ToInt32(ID.Text);
                   List<RouteData> GetResult = objClassBO.GetRouteDetailsByID(objclass);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtroute.Text = GetResult[0].Descriptions;
                        ViewState["ID"] = GetResult[0].RouteID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    RouteData objclass = new RouteData();
                    RouteBO objClassBO = new RouteBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRouteDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objclass.Remarks = txtremarks.Text;
                    }
                    objclass.RouteID = Convert.ToInt32(ID.Text);
                    objclass.ActionType = EnumActionType.Delete;
                    int Result = objClassBO.DeleteRouteDetailsByID(objclass);
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
            List<RouteData> lstclass = GetRoutedetails(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvRouteDetails.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvRouteDetails.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                GvRouteDetails.PageIndex = index - 1;
                GvRouteDetails.DataSource = lstclass;
                GvRouteDetails.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvRouteDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvRouteDetails.DataSource = null;
                GvRouteDetails.DataBind();
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvRouteDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvRouteDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvRouteDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvRouteDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvRouteDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvRouteDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvRouteDetails.UseAccessibleHeader = true;
            GvRouteDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvRouteDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvRouteDetails.DataSource = sortedView;
                    GvRouteDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvRouteDetails.HeaderRow.Cells[ColumnIndex];
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
        //    List<RouteData> lstRoutelist = new List<RouteData>();
        //    RouteData objclass = new RouteData();
        //    ClassBO objclassBO = new ClassBO();
        //    int index = 0;
        //    int count = 0;
        //    try
        //    {                // get all the record from the gridview
        //        foreach (GridViewRow row in GvClassDetails.Rows)
        //        {
        //            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
        //            Label ClassID = (Label)GvClassDetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
        //            CheckBox chk = (CheckBox)GvClassDetails.Rows[row.RowIndex].Cells[0].FindControl("chekboxselect");
        //            RouteData ObjDetails = new RouteData();
        //            if (chk.Checked)
        //            {
        //                ObjDetails.ClassID = Convert.ToInt32(ClassID.Text);
        //                count = count + 1;
        //                // ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
        //                lstclasslist.Add(ObjDetails);
        //                index++;
        //            }
        //        }
        //        objclass.Xmlclasslist = XmlConvertor.ActivatedclasstoXML(lstclasslist).ToString();
        //        if (count == 0)
        //        {
        //            Messagealert_.ShowMessage(lblresult, "Please select atleast one Class", 0);
        //            return;
        //        }
        //        int results = objclassBO.Activate(objclass);
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
        public List<RouteData> GetRoutedetails(int curIndex, int pagesize)
        {
            RouteData objclass = new RouteData();
            RouteBO objClassBO = new RouteBO();
            objclass.Code = txtcode.Text == "" ? null : txtcode.Text;
            objclass.Descriptions = txtroute.Text == "" ? null : txtroute.Text;
            objclass.ActionType = EnumActionType.Select;
            objclass.PageSize = pagesize;
            objclass.CurrentIndex = curIndex;
            objclass.IsActive = ddlstatus.SelectedValue=="1"?true:false;
            return objClassBO.SearchRouteDetails(objclass);
        }
        private void clearall()
        {
            txtcode.Text = "";
            txtroute.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtcode.Text = "";
            txtroute.Text = "";
            bindgrid(1);

        }
        protected void GvRouteDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvRouteDetails.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Route List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Route.xlsx");
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
            List<RouteData> RouteDetail = GetRoutedetails(1, size);
            List<RouteDatatoExcel> Routetoexcel = new List<RouteDatatoExcel>();
            int i = 0;
            foreach (RouteData row in RouteDetail)
            {
                RouteDatatoExcel EcxeclStd = new RouteDatatoExcel();
                EcxeclStd.Code = RouteDetail[i].Code;
                EcxeclStd.Route = RouteDetail[i].Descriptions;
                Routetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(Routetoexcel);
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