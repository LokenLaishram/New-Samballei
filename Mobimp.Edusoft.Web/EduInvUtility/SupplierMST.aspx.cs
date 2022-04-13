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
    public partial class SupplierMST : BasePage
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
                //    return;
                //}
                SupplierData obj = new SupplierData();
                SupplierBO objBO = new SupplierBO();
                obj.Code = txt_code.Text.Trim() == "" ? null : txt_code.Text.Trim();
                obj.Supplier = txt_supplier.Text.Trim() == "" ? null : txt_supplier.Text.Trim();
                obj.ContactNo = txt_contactno.Text.Trim() == "" ? null : txt_contactno.Text.Trim();
                obj.Type = Convert.ToInt32( ddl_type.SelectedValue.ToString());          
              

                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.IsActive = ddl_status.SelectedValue == "1" ? true : false; ;
                obj.ActionType = EnumActionType.Insert; // insert
                if (ViewState["ID"] != null)
                {
                    obj.ActionType = EnumActionType.Update; // update
                    obj.SupplierID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objBO.SaveSupplier(obj);
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
        protected void Gv_supplier_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    //if (LoginToken.EditEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("editenable") + "')", true);
                    //    return;
                    //}
                    SupplierData objsupplier = new SupplierData();
                    SupplierBO objClassBO = new SupplierBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_supplier.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objsupplier.SupplierID = Convert.ToInt32(ID.Text);
                    List<SupplierData> GetResult = objClassBO.GetsupplierbyID(objsupplier);
                    if (GetResult.Count > 0)
                    {
                        txt_code.Text = GetResult[0].Code;
                        txt_supplier.Text = GetResult[0].Supplier;
                        ddl_type.SelectedValue = GetResult[0].Type.ToString();
                        txt_contactno.Text = GetResult[0].ContactNo; 
                        ddl_status.SelectedValue = GetResult[0].IsActive == true ? "1" : "0";
                        ViewState["ID"] = GetResult[0].SupplierID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    return;
                    //}
                    SupplierData objsupplier = new SupplierData();
                    SupplierBO objClassBO = new SupplierBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_supplier.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objsupplier.SupplierID = Convert.ToInt32(ID.Text);
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
                        objsupplier.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    objsupplier.ActionType = EnumActionType.Delete;
                    int Result = objClassBO.DeletesupplierbyID(objsupplier);
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
                    SupplierData objdata = new SupplierData();
                    SupplierBO objBO = new SupplierBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_supplier.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objdata.SupplierID = Convert.ToInt32(ID.Text);
                    objdata.ActionType = EnumActionType.Activate;
                    int Result = objBO.DeletesupplierbyID(objdata);
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
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    return;
            //}
            Boolean status = ddl_status.SelectedValue == "1" ? true : false;
            string url = "../EduInvUtility/Reports/Reportviewer.aspx?option=SupplierList&SupplierID=" + 0 + "&status=" + status;
            string fullURL = "window.open('" + url + "', '_blank');";

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SupplierData> lstclass = getsupplierlist(index, pagesize);
            if (lstclass.Count > 0)
            {
                if (ddl_status.SelectedValue == "0")
                {
                    Gv_supplier.Columns[9].Visible = true;
                }
                else
                {
                    Gv_supplier.Columns[9].Visible = false;
                }
                Gv_supplier.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lbl_totalrecords.Visible = false;
                lblresult.Visible = true;
                Gv_supplier.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                Gv_supplier.PageIndex = index - 1;
                Gv_supplier.DataSource = lstclass;
                Gv_supplier.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = Gv_supplier.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gv_supplier.DataSource = null;
                Gv_supplier.DataBind();
                lbl_totalrecords.Visible = false;
                lblresult.Visible = false;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_supplier.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_supplier.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_supplier.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_supplier.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_supplier.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_supplier.UseAccessibleHeader = true;
            Gv_supplier.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void Gv_supplier_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_supplier.DataSource = sortedView;
                    Gv_supplier.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_supplier.HeaderRow.Cells[ColumnIndex];
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
        public List<SupplierData> getsupplierlist(int curIndex, int pagesize)
        {
            SupplierData objsupplier = new SupplierData();
            SupplierBO objClassBO = new SupplierBO();
            objsupplier.Code = txt_code.Text == "" ? null : txt_code.Text;
            objsupplier.Supplier = txt_supplier.Text == "" ? null : txt_supplier.Text;
            objsupplier.Type =Convert.ToInt32( ddl_type.SelectedValue.ToString()==""? null : ddl_type.SelectedValue.ToString());
            objsupplier.ContactNo = txt_contactno.Text == "" ? null : txt_contactno.Text;
            objsupplier.PageSize = pagesize;
            objsupplier.CurrentIndex = curIndex;
            objsupplier.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            return objClassBO.Searchsupplier(objsupplier);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txt_code.Text = "";
            txt_supplier.Text = "";
            ddl_type.SelectedValue = "0";
            txt_contactno.Text = "";
            btnsave.Text = "Add";
            bindgrid(1);

        }
        protected void Gv_supplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_supplier.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Supplier List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Supplier.xlsx");
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
            List<SupplierData> Companydetail = getsupplierlist(1, size);
            List<SupplierDatatoXL> classtoexcel = new List<SupplierDatatoXL>();
            int i = 0;
            foreach (SupplierData row in Companydetail)
            {
                SupplierDatatoXL Ecxeclcompany = new SupplierDatatoXL();
                Ecxeclcompany.Code = Companydetail[i].Code;
                Ecxeclcompany.Supplier = Companydetail[i].Supplier;
                Ecxeclcompany.SupplierID = Companydetail[i].SupplierID;
                Ecxeclcompany.ContactNo = Companydetail[i].ContactNo;
                Ecxeclcompany.Type = Companydetail[i].Type;
              
                classtoexcel.Add(Ecxeclcompany);
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