using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Data.EduAccount;
using Mobimp.Edusoft.BussinessProcess.EduAccount;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduAccount
{
    public partial class AccountGroup : BasePage
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
            Commonfunction.PopulateDdl(ddl_UnderGroupID, mstlookup.GetLookupsList(LookupNames.AccountGroup));
            Commonfunction.PopulateDdl(ddl_NatureOfGroupID, mstlookup.GetLookupsList(LookupNames.NatureGroup));         
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
                AccountGroupData obj = new AccountGroupData();
                AccountGroupBO objBO = new AccountGroupBO();
                obj.UnderGroupID = Convert.ToInt32(ddl_UnderGroupID.SelectedValue == "" ? "0" : ddl_UnderGroupID.SelectedValue);
                obj.AccountGroupName = txt_GroupName.Text.Trim() == "" ? null : txt_GroupName.Text.Trim();
                obj.AccountNatureID = Convert.ToInt32(ddl_NatureOfGroupID.SelectedValue == "" ? "0" : ddl_NatureOfGroupID.SelectedValue);
                obj.IsActive = ddl_status.SelectedValue == "1" ? true : false; ;
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.CompanyID = LoginToken.CompanyID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    obj.ActionType = EnumActionType.Update;
                    obj.AccountGroupID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objBO.UpdateAccountGroupDetails(obj);
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
        protected void Gv_AccountGroup_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    AccountGroupData objUnit = new AccountGroupData();
                    AccountGroupBO objClassBO = new AccountGroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_AccountGroup.Rows[i];
                    Label ACID = (Label)gr.Cells[0].FindControl("lbl_AccountGroupID");
                    objUnit.AccountGroupID = Convert.ToInt32(ACID.Text);
                    List<AccountGroupData> GetResult = objClassBO.GetAccountGroupDetailsByID(objUnit);
                    if (GetResult.Count > 0)
                    {
                        ddl_UnderGroupID.SelectedValue = GetResult[0].UnderGroupID.ToString();
                        txt_GroupName.Text = GetResult[0].AccountGroupName;
                        ddl_NatureOfGroupID.SelectedValue = GetResult[0].AccountNatureID.ToString();
                        ViewState["ID"] = GetResult[0].AccountGroupID;
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
                    AccountGroupData objUnit = new AccountGroupData();
                    AccountGroupBO objClassBO = new AccountGroupBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_AccountGroup.Rows[i];
                    Label ACID = (Label)gr.Cells[0].FindControl("lbl_AccountGroupID");
                    objUnit.AccountGroupID = Convert.ToInt32(ACID.Text);
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
                        objUnit.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    objUnit.ActionType = EnumActionType.Delete;
                    int Result = objClassBO.DeleteAccountGroupDetailsByID(objUnit);
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
        protected void btnprint_Click(object sender, EventArgs e)
        {
            //if (LoginToken.PrintEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
            //    return;
            //}
            Boolean status = ddl_status.SelectedValue == "1" ? true : false;
            string url = "../EduAccount/Reports/Reportviewer.aspx?option=AccountGroupList&status=" + status;
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
            List<AccountGroupData> lstclass = getgrouplist(index, pagesize);
            if (lstclass.Count > 0)
            {
                Gv_AccountGroup.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gv_AccountGroup.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                Gv_AccountGroup.PageIndex = index - 1;
                Gv_AccountGroup.DataSource = lstclass;
                Gv_AccountGroup.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = Gv_AccountGroup.HeaderRow.Cells[0];

                bindresponsive();
            }
            else
            {
                Gv_AccountGroup.DataSource = null;
                Gv_AccountGroup.DataBind();
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_AccountGroup.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_AccountGroup.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_AccountGroup.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_AccountGroup.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_AccountGroup.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_AccountGroup.UseAccessibleHeader = true;
            Gv_AccountGroup.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void Gv_AccountGroup_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_AccountGroup.DataSource = sortedView;
                    Gv_AccountGroup.DataBind();
                    bindresponsive();

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
        public List<AccountGroupData> getgrouplist(int curIndex, int pagesize)
        {
            AccountGroupData objdata = new AccountGroupData();
            AccountGroupBO objClassBO = new AccountGroupBO();
            objdata.UnderGroupID = Convert.ToInt32(ddl_UnderGroupID.SelectedValue == "" ? "0" : ddl_UnderGroupID.SelectedValue);
            objdata.AccountGroupName = txt_GroupName.Text == "" ? "" : txt_GroupName.Text;
            objdata.AccountNatureID = Convert.ToInt32(ddl_NatureOfGroupID.SelectedValue == "" ? "0" : ddl_NatureOfGroupID.SelectedValue);
            objdata.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;          
            return objClassBO.SearchAccountGroupDetails(objdata);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            ddl_UnderGroupID.SelectedIndex = 0;
            txt_GroupName.Text = "";
            ddl_NatureOfGroupID.SelectedIndex = 0;
            btnsave.Text = "Add";
            bindgrid(1);

        }
        protected void Gv_AccountGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_AccountGroup.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Unit List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Unit.xlsx");
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
            List<AccountGroupData> Unitdetail = getgrouplist(1, size);
            List<AccountGroupDatatoXL> classtoexcel = new List<AccountGroupDatatoXL>();
            int i = 0;
            foreach (AccountGroupData row in Unitdetail)
            {
                AccountGroupDatatoXL EcxeclUnit = new AccountGroupDatatoXL();
                EcxeclUnit.AccountGroupName = Unitdetail[i].AccountGroupName;
                EcxeclUnit.UnderGroupName = Unitdetail[i].UnderGroupName;
                EcxeclUnit.AccountNatureName = Unitdetail[i].AccountNatureName;
                EcxeclUnit.GroupTypeName = Unitdetail[i].GroupTypeName;

                classtoexcel.Add(EcxeclUnit);
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
            if (LoginToken.PrintEnable == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("exportenable") + "')", true);
                return;
            }
            else
            {
                ExportoExcel();
            }
        }
        
    }
}