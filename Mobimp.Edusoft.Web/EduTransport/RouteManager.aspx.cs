using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.IO;
using Mobimp.Edusoft.Data.EduTransport;
using Mobimp.Edusoft.BussinessProcess.EduTransport;
using Mobimp.Edusoft.Common;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;

namespace Mobimp.Campusoft.Web.EduTransport
{
    public partial class RouteManager : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            VehicleData objtransport = new VehicleData();
            VehicleBO objtransportBO = new VehicleBO();
            try
            {
                objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                objtransport.RouteCode = txtRouteCode.Text.Trim();
                objtransport.RouteName = txtRouteName.Text.Trim();
                objtransport.Destination = txtDestination.Text.Trim();
                objtransport.ActionType = EnumActionType.Insert;
                objtransport.UserId = LoginToken.UserLoginId;
                objtransport.AddedBy = LoginToken.LoginId;

                if (ViewState["ID"] != null)
                {
                    objtransport.ActionType = EnumActionType.Update;
                    objtransport.RouteID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objtransportBO.UpdateRouteDetails(objtransport);

                if (result == 1 || result == 2)
                {
                    bindgrid(1);
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
            GvRoutes.PageSize = pagesize;
            List<VehicleData> lstvehi = GetRouteDetails(index, pagesize);
            if (lstvehi.Count > 0)
            {
                string record = lstvehi[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstvehi[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstvehi[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvRoutes.VirtualItemCount = lstvehi[0].MaximumRows;//total item is required for custom paging
                GvRoutes.PageIndex = index - 1;
                GvRoutes.DataSource = lstvehi;
                GvRoutes.DataBind();
                ds = ConvertToDataSet(lstvehi);
                TableCell tableCell = GvRoutes.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                btnsave.Text = "Add";
            }
            else
            {
                lblresult.Visible = false;
                GvRoutes.DataSource = null;
                GvRoutes.DataBind();
            }
        }
        public List<VehicleData> GetRouteDetails(int curIndex, int pagesize)
        {
            VehicleData objtransport = new VehicleData();
            VehicleBO objtransportBO = new VehicleBO();
            objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objtransport.RouteCode = Convert.ToString(txtRouteCode.Text.Trim() == "" ? "0" : txtRouteCode.Text.Trim());
            objtransport.RouteName = Convert.ToString(txtRouteName.Text.Trim() == "" ? "0" : txtRouteName.Text.Trim());
            objtransport.Destination = Convert.ToString(txtDestination.Text.Trim() == "" ? "0" : txtDestination.Text.Trim());
            objtransport.PageSize = pagesize;
            objtransport.CurrentIndex = curIndex;
            return objtransportBO.GetRouteDetails(objtransport);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtRouteCode.Text = "";
            txtRouteName.Text = "";
            txtDestination.Text = "";
            bindgrid(1);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvRoutes.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvRoutes.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvRoutes.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvRoutes.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvRoutes.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvRoutes.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvRoutes.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvRoutes.UseAccessibleHeader = true;
            GvRoutes.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GVRoutes_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvRoutes.DataSource = sortedView;
                    GvRoutes.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvRoutes.HeaderRow.Cells[ColumnIndex];
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Vehicle List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Vehicle.xlsx");
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
            List<VehicleData> ClassDetail = GetRouteDetails(1, size);
            List<VehicleDatatoExcel> classtoexcel = new List<VehicleDatatoExcel>();
            int i = 0;
            foreach (VehicleData row in ClassDetail)
            {
                VehicleDatatoExcel EcxeclStd = new VehicleDatatoExcel();
                EcxeclStd.DriverName = ClassDetail[i].DriverName;
                EcxeclStd.Address = ClassDetail[i].Address;
                EcxeclStd.ContactNo = ClassDetail[i].ContactNo;
                EcxeclStd.TransportName = ClassDetail[i].TransportName;
                EcxeclStd.VehicleNo = ClassDetail[i].VehicleNo;
                EcxeclStd.Licence = ClassDetail[i].Licence;
                classtoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(classtoexcel);
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

        protected void ddlacademicsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void GvRoutes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvRoutes.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void GvRoutes_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvRoutes.DataSource = sortedView;
                    GvRoutes.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvRoutes.HeaderRow.Cells[ColumnIndex];
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

        protected void GvRoutes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    VehicleData objfees = new VehicleData();
                    VehicleBO objpayementBO = new VehicleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRoutes.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblIDGV");
                    objfees.RouteID = Convert.ToInt32(ID.Text);

                    List<VehicleData> GetResult = objpayementBO.GetTransportRouteDetailsByID(objfees);
                    if (GetResult.Count > 0)
                    {
                        ddlacademicsession.SelectedValue = GetResult[0].AcademicSessionID.ToString();
                        txtRouteCode.Text = GetResult[0].RouteCode.ToString();
                        txtRouteName.Text = GetResult[0].RouteName.ToString();
                        txtDestination.Text = GetResult[0].Destination.ToString();
                        ViewState["ID"] = GetResult[0].RouteID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                    else
                    {
                        ddlacademicsession.SelectedIndex = 1;
                        txtRouteCode.Text = "";
                        txtRouteName.Text = "";
                        txtDestination.Text = "";
                        ViewState["ID"] = null;
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    VehicleData objfees = new VehicleData();
                    VehicleBO objpayementBO = new VehicleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRoutes.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblIDGV");
                    Label AcademicSessionID = (Label)gr.Cells[0].FindControl("lblAcademicSessionGV");
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
                        objfees.Remarks = txtremarks.Text;
                    }
                    objfees.RouteID = Convert.ToInt32(ID.Text);
                    objfees.AcademicSessionID = Convert.ToInt32(AcademicSessionID.Text);
                    objfees.ActionType = EnumActionType.Delete;
                    int Result = objpayementBO.DeleteTransportRouteDetailsByID(objfees);
                    if (Result == 1)
                    {
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);

                    }
                    else if (Result == 4)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Route cannot be deleted since some students are assigned to this Route") + "')", true);
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
    }
}