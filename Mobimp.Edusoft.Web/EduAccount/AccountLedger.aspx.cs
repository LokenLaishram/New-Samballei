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
    public partial class AccountLedger : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                BindDlls();
              //  bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_AccountGroupID, mstlookup.GetLookupsList(LookupNames.AccountGroup));
            Commonfunction.PopulateDdl(ddl_NatureOfGroupID, mstlookup.GetLookupsList(LookupNames.NatureGroup));
            Commonfunction.PopulateDdl(ddlfeetype, mstlookup.GetLookupsList(LookupNames.StudentFeeTypes));
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
                AccountLedgerData obj = new AccountLedgerData();
                AccountLedgerBO objBO = new AccountLedgerBO();
                obj.AccountGroupID = Convert.ToInt32(ddl_AccountGroupID.SelectedValue == "" ? "0" : ddl_AccountGroupID.SelectedValue);
                obj.AccountLedgerName = txt_LedgerName.Text.Trim() == "" ? null : txt_LedgerName.Text.Trim();
                obj.AccountNatureID = Convert.ToInt32(ddl_NatureOfGroupID.SelectedValue == "" ? "0" : ddl_NatureOfGroupID.SelectedValue);
                obj.OpeningBalance = Convert.ToDecimal(txt_OpeningBalance.Text.Trim() == "" ? "0" : txt_OpeningBalance.Text.Trim());
                obj.IsActive = ddl_status.SelectedValue == "1" ? true : false; ;
                obj.Feetypeid = Convert.ToInt32(ddlfeetype.SelectedValue == "" ? "0" : ddlfeetype.SelectedValue);
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.CompanyID = LoginToken.CompanyID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    obj.ActionType = EnumActionType.Update;
                    obj.AccountLedgerID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objBO.UpdateAccountLedgerDetails(obj);
                if (result == 1 || result == 2)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                if (result == 3)
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
        protected void Gv_Ledger_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    if (LoginToken.EditEnable == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("editenable") + "')", true);
                        return;
                    }
                    AccountLedgerData objUnit = new AccountLedgerData();
                    AccountLedgerBO objClassBO = new AccountLedgerBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_Ledger.Rows[i];
                    Label ALID = (Label)gr.Cells[0].FindControl("lbl_AccountLedgerID");
                    objUnit.AccountLedgerID = Convert.ToInt32(ALID.Text);
                    List<AccountLedgerData> GetResult = objClassBO.GetAccountLedgerDetailsByID(objUnit);
                    if (GetResult.Count > 0)
                    {
                        ddl_AccountGroupID.SelectedValue = GetResult[0].AccountGroupID.ToString();
                        txt_LedgerName.Text = GetResult[0].AccountLedgerName;
                        ddl_NatureOfGroupID.SelectedValue = GetResult[0].AccountNatureID.ToString();
                        txt_OpeningBalance.Text = GetResult[0].OpeningBalance.ToString();
                        ViewState["ID"] = GetResult[0].AccountLedgerID;
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
                    AccountLedgerData objUnit = new AccountLedgerData();
                    AccountLedgerBO objClassBO = new AccountLedgerBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_Ledger.Rows[i];
                    Label LedgerID = (Label)gr.Cells[0].FindControl("lbl_AccountLedgerID");
                    objUnit.AccountLedgerID = Convert.ToInt32(LedgerID.Text);
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
                    objUnit.EmployeeID = LoginToken.EmployeeID;
                    objUnit.ActionType = EnumActionType.Delete;
                    int Result = objClassBO.DeleteAccountLedgerDetailsByID(objUnit);
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
            if (LoginToken.PrintEnable == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("printenable") + "')", true);
                return;
            }
            Boolean status = ddl_status.SelectedValue == "1" ? true : false;
            string url = "../Utility/Reports/Reportviewer.aspx?option=UnitList&UnitID=" + 0 + "&status=" + status;
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
            List<AccountLedgerData> lstclass = getgrouplist(index, pagesize);
            if (lstclass.Count > 0)
            {
                Gv_Ledger.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gv_Ledger.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                Gv_Ledger.PageIndex = index - 1;
                Gv_Ledger.DataSource = lstclass;
                Gv_Ledger.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = Gv_Ledger.HeaderRow.Cells[0];

                bindresponsive();
            }
            else
            {
                Gv_Ledger.DataSource = null;
                Gv_Ledger.DataBind();
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_Ledger.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_Ledger.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_Ledger.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_Ledger.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_Ledger.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_Ledger.UseAccessibleHeader = true;
            Gv_Ledger.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void Gv_Ledger_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_Ledger.DataSource = sortedView;
                    Gv_Ledger.DataBind();
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
        public List<AccountLedgerData> getgrouplist(int curIndex, int pagesize)
        {
            AccountLedgerData objdata = new AccountLedgerData();
            AccountLedgerBO objClassBO = new AccountLedgerBO();
            objdata.AccountGroupID = Convert.ToInt32(ddl_AccountGroupID.SelectedValue == "" ? "0" : ddl_AccountGroupID.SelectedValue);
            objdata.AccountLedgerName = txt_LedgerName.Text == "" ? "" : txt_LedgerName.Text;
            objdata.AccountNatureID = Convert.ToInt32(ddl_NatureOfGroupID.SelectedValue == "" ? "0" : ddl_NatureOfGroupID.SelectedValue);
            objdata.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;
            return objClassBO.SearchAccountLedgerDetails(objdata);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            ddl_AccountGroupID.SelectedIndex = 0;
            txt_LedgerName.Text = "";
            txt_OpeningBalance.Text= "";
            ddl_NatureOfGroupID.SelectedIndex = 0;
            btnsave.Text = "Add";
            bindgrid(1);

        }
        protected void Gv_Ledger_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_Ledger.PageIndex = e.NewPageIndex;
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
            List<AccountLedgerData> ledgerdetail = getgrouplist(1, size);
            List<AccountLedgerDatatoXL> classtoexcel = new List<AccountLedgerDatatoXL>();
            int i = 0;
            foreach (AccountLedgerData row in ledgerdetail)
            {
                AccountLedgerDatatoXL ExcelLedger = new AccountLedgerDatatoXL();
                ExcelLedger.AccountGroupName = ledgerdetail[i].AccountGroupName;
                ExcelLedger.LedgerName = ledgerdetail[i].AccountLedgerName;
                ExcelLedger.AccountNatureName = ledgerdetail[i].AccountNatureName;
                ExcelLedger.GroupTypeName = ledgerdetail[i].GroupTypeName;

                classtoexcel.Add(ExcelLedger);
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