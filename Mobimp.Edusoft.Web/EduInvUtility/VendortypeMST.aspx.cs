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
    public partial class VendortypeMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid(1);
            }
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
                VendortypeData obj = new VendortypeData();
                VendortypeBO objBO = new VendortypeBO();
                obj.VendorType = txt_vendortype.Text.Trim() == "" ? null : txt_vendortype.Text.Trim();
                obj.IsActive = ddl_status.SelectedValue == "1" ? true : false; ;

                obj.EmployeeID = LoginToken.EmployeeID;
                obj.CompanyID = LoginToken.CompanyID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.ActionType = EnumActionType.Insert; // insert
                if (ViewState["ID"] != null)
                {
                    obj.ActionType = EnumActionType.Update; // update
                    obj.VendorTypeID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objBO.SaveVendortype(obj);
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

                bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void Gv_vendortype_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    //if (LoginToken.EditEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("editenable") + "')", true);
                    //    bindresponsive();
                    //    return;
                    //}
                    VendortypeData objGroup = new VendortypeData();
                    VendortypeBO objVendortypeBO = new VendortypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_vendortype.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objGroup.VendorTypeID = Convert.ToInt32(ID.Text);
                    List<VendortypeData> GetResult = objVendortypeBO.GetVendortypebyID(objGroup);
                    if (GetResult.Count > 0)
                    {
                        txt_vendortype.Text = GetResult[0].VendorType;
                        ddl_status.SelectedValue = GetResult[0].IsActive.ToString() == "true" ? "1" : "0";
                        string var = GetResult[0].IsActive.ToString();
                        ddl_status.SelectedValue = GetResult[0].IsActive == true ? "1" : "0";
                        ViewState["ID"] = GetResult[0].VendorTypeID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    bindresponsive();
                    //    return;
                    //}
                    VendortypeData objdata = new VendortypeData();
                    VendortypeBO objVendortypeBO = new VendortypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_vendortype.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objdata.VendorTypeID = Convert.ToInt32(ID.Text);
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
                        objdata.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    objdata.ActionType = EnumActionType.Delete;
                    int Result = objVendortypeBO.DeleteVendortypeID(objdata);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }

                }
                if (e.CommandName == "activate")
                {
                    VendortypeData objdata = new VendortypeData();
                    VendortypeBO objBO = new VendortypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_vendortype.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objdata.VendorTypeID = Convert.ToInt32(ID.Text);
                    objdata.ActionType = EnumActionType.Activate;
                    int Result = objBO.DeleteVendortypeID(objdata);
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
            if (LoginToken.PrintEnable == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                return;
            }
            Boolean status = ddl_status.SelectedValue == "1" ? true : false;
            string url = "../Utility/Reports/Reportviewer.aspx?option=GroupList&GroupID=" + 0 + "&status=" + status;
            string fullURL = "window.open('" + url + "', '_blank');";

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<VendortypeData> lstclass = Gv_vendortypelist(index, pagesize);
            if (lstclass.Count > 0)
            {
                if (ddl_status.SelectedValue == "0")
                {
                    Gv_vendortype.Columns[6].Visible = true;
                }
                else
                {
                    Gv_vendortype.Columns[6].Visible = false;
                }
                Gv_vendortype.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lbl_totalrecords.Visible = false;
                lblresult.Visible = true;
                Gv_vendortype.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                Gv_vendortype.PageIndex = index - 1;
                Gv_vendortype.DataSource = lstclass;
                Gv_vendortype.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = Gv_vendortype.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gv_vendortype.DataSource = null;
                Gv_vendortype.DataBind();
                lbl_totalrecords.Visible = false;
                lblresult.Visible = false;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_vendortype.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_vendortype.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_vendortype.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_vendortype.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_vendortype.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_vendortype.UseAccessibleHeader = true;
            Gv_vendortype.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void Gv_vendortype_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_vendortype.DataSource = sortedView;
                    Gv_vendortype.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_vendortype.HeaderRow.Cells[ColumnIndex];
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
        public List<VendortypeData> Gv_vendortypelist(int curIndex, int pagesize)
        {
            VendortypeData objGroup = new VendortypeData();
            VendortypeBO objVendortypeBO = new VendortypeBO();
            objGroup.VendorType = txt_vendortype.Text == "" ? null : txt_vendortype.Text;
            objGroup.PageSize = pagesize;
            objGroup.CurrentIndex = curIndex;
            objGroup.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            return objVendortypeBO.SearchVendortype(objGroup);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txt_vendortype.Text = "";
            btnsave.Text = "Add";
            bindgrid(1);

        }
        protected void Gv_vendortype_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_vendortype.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Vendor Type List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Vendortype.xlsx");
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
            List<VendortypeData> Groupdetail = Gv_vendortypelist(1, size);
            List<VendortypeDatatoXL> grouptoexcel = new List<VendortypeDatatoXL>();
            int i = 0;
            foreach (VendortypeData row in Groupdetail)
            {
                VendortypeDatatoXL EcxeclGroup = new VendortypeDatatoXL();
                EcxeclGroup.VendorType = Groupdetail[i].VendorType;
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