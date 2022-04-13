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
using Mobimp.Campusoft.Data.EduTransport;
using Mobimp.Campusoft.BussinessProcess.EduTransport;

namespace Mobimp.Edusoft.Web.EduTransport
{
    public partial class TransportMonthlyFeeSetting : BasePage
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
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;           
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {

            List<TransportData> lstdata = new List<TransportData>();
            TransportData ObjData = new TransportData();
            TransportRegistrationBO objtransportBO = new TransportRegistrationBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvTransportMonthlyFeeSetting.Rows)
                {
                    TransportData ObjDetails = new TransportData();
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label lblmonthID = (Label)GvTransportMonthlyFeeSetting.Rows[row.RowIndex].Cells[0].FindControl("lblmonthID");
                    CheckBox chkactivate = (CheckBox)GvTransportMonthlyFeeSetting.Rows[row.RowIndex].Cells[0].FindControl("chkactivate");
                    if (chkactivate.Checked == true)
                    {
                        ObjDetails.Activate = 1;
                    }
                    else
                    {
                        ObjDetails.Activate = 0;
                    }
                    ObjDetails.MonthID = Convert.ToInt32(lblmonthID.Text);
                    lstdata.Add(ObjDetails);
                    index++;
                }
                ObjData.XMLData = XmlConvertor.TransportMonthlyFeeSettingtoXML(lstdata).ToString();
                ObjData.EmployeeID = LoginToken.EmployeeID;
                ObjData.AcademicSessionID = LoginToken.AcademicSessionID;
                int results = objtransportBO.UpdateTransportMonthlyFeeSetting(ObjData);
                if (results == 1)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(results == 1 ? "save" : "update") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvTransportMonthlyFeeSetting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    RouteData objclass = new RouteData();
                    RouteBO objClassBO = new RouteBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvTransportMonthlyFeeSetting.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objclass.RouteID = Convert.ToInt32(ID.Text);
                   List<RouteData> GetResult = objClassBO.GetRouteDetailsByID(objclass);
                    if (GetResult.Count > 0)
                    {
                        //txtcode.Text = GetResult[0].Code;
                        //txtroute.Text = GetResult[0].Descriptions;
                        //ViewState["ID"] = GetResult[0].RouteID;
                        //btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    RouteData objclass = new RouteData();
                    RouteBO objClassBO = new RouteBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvTransportMonthlyFeeSetting.Rows[i];
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
            List<TransportData> lstclass = GetTransportMonthlyFeeSetting();
            if (lstclass.Count > 0)
            {
              
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                GvTransportMonthlyFeeSetting.DataSource = lstclass;
                GvTransportMonthlyFeeSetting.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvTransportMonthlyFeeSetting.HeaderRow.Cells[0];
                //Image img = new Image();
                //img.ImageUrl = "~/app-assets/images/asc.gif";
                //tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                //tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvTransportMonthlyFeeSetting.DataSource = null;
                GvTransportMonthlyFeeSetting.DataBind();
            }
        }
        protected void bindresponsive()
        {
            GvTransportMonthlyFeeSetting.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvTransportMonthlyFeeSetting.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvTransportMonthlyFeeSetting.UseAccessibleHeader = true;
            GvTransportMonthlyFeeSetting.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvTransportMonthlyFeeSetting_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvTransportMonthlyFeeSetting.DataSource = sortedView;
                    GvTransportMonthlyFeeSetting.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvTransportMonthlyFeeSetting.HeaderRow.Cells[ColumnIndex];
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
      
        public List<TransportData> GetTransportMonthlyFeeSetting()
        {
            TransportData objdata = new TransportData();
            TransportRegistrationBO objdataBO = new TransportRegistrationBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0": ddlacademicsession.SelectedValue) ;
            objdata.EmployeeID = LoginToken.EmployeeID;
            return objdataBO.SearchTransportMonthlyFeeSetting(objdata);
        }
       
      
        protected void GvTransportMonthlyFeeSetting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTransportMonthlyFeeSetting.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
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
      
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void GvTransportMonthlyFeeSetting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvTransportMonthlyFeeSetting.Rows)
            {
                try
                {
                    CheckBox chkactivate = (CheckBox)GvTransportMonthlyFeeSetting.Rows[row.RowIndex].Cells[0].FindControl("chkactivate");
                    Label lblActivate = (Label)GvTransportMonthlyFeeSetting.Rows[row.RowIndex].Cells[0].FindControl("lblActivate");
                    if (lblActivate.Text == "1")
                    {
                        chkactivate.Checked = true;
                    }
                    else
                    {
                        chkactivate.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
    }
}