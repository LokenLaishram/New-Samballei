using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.EduAdmin;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;

namespace Mobimp.Edusoft.Web.EduAdmin
{
    public partial class UsersManager : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                bindgrid(1);
                lblmessage.Visible = true;
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlemp, mstlookup.GetLookupsList(LookupNames.Employee));
            Commonfunction.PopulateDdl(ddlrole, mstlookup.GetLookupsList(LookupNames.Roles));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                AddUsersData objusers = new AddUsersData();
                AddUsersBO objAddUsersBO = new AddUsersBO();
                objusers.RoleID = Convert.ToInt32(ddlrole.SelectedValue == "" ? "0" : ddlrole.SelectedValue);
                objusers.EmployeeID = Convert.ToInt64(ddlemp.SelectedValue == "" ? "0" : ddlemp.SelectedValue);
                Commonfunction comfunc = new Commonfunction();
                objusers.UserPassword = comfunc.Encrypt(txtcpassword.Text);
                objusers.UserName = txtusername.Text;
                objusers.AcademicSessionID = LoginToken.AcademicSessionID;
                objusers.AddedBy = LoginToken.LoginId;
                objusers.UserId = LoginToken.UserLoginId; ;
                objusers.CompanyID = LoginToken.CompanyID;

                objusers.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objusers.ActionType = EnumActionType.Update;
                    objusers.RoleID = Convert.ToInt32(ddlrole.SelectedValue);
                }
                int result = objAddUsersBO.UpdateUserDetails(objusers);
                if (result == 1 || result == 2)
                {
                    clearall();
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    clearall();
                    bindgrid(1);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvUserdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    AddUsersData objusers = new AddUsersData();
                    AddUsersBO objAddUsersBO = new AddUsersBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvUserdetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objusers.LoginID = Convert.ToInt32(ID.Text);
                    objusers.ActionType = EnumActionType.Select;

                    List<AddUsersData> GetResult = objAddUsersBO.GetUserDetailsByID(objusers);
                    if (GetResult.Count > 0)
                    {
                        txtusername.Text = GetResult[0].UserName;
                        //txtpassword.Text = GetResult[0].UserPassword;
                        ddlemp.SelectedValue = GetResult[0].EmployeeID.ToString();
                        ddlrole.SelectedValue = GetResult[0].RoleID.ToString();
                        ViewState["ID"] = GetResult[0].LoginID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    AddUsersData objusers = new AddUsersData();
                    AddUsersBO objAddUsersBO = new AddUsersBO();
                    objusers.LoginID = Convert.ToInt16(e.CommandArgument.ToString());
                    objusers.ActionType = EnumActionType.Delete;
                    int Result = objAddUsersBO.DeleteUserDetailsByID(objusers);
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
            List<AddUsersData> lstemp = GetUserDetails(index, pagesize);
            if (lstemp.Count > 0)
            {
                GvUserdetails.PageSize = pagesize;
                string record = lstemp[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstemp[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstemp[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvUserdetails.VirtualItemCount = lstemp[0].MaximumRows;//total item is required for custom paging
                GvUserdetails.PageIndex = index - 1;
                GvUserdetails.DataSource = lstemp;
                GvUserdetails.DataBind();
                ds = ConvertToDataSet(lstemp);
                TableCell tableCell = GvUserdetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvUserdetails.DataSource = null;
                GvUserdetails.DataBind();
            }
        }
        public List<AddUsersData> GetUserDetails(int curIndex, int pagesize)
        {
            AddUsersData objusers = new AddUsersData();
            AddUsersBO objAddUsersBO = new AddUsersBO();
            objusers.UserName = txtusername.Text == "" ? null : txtusername.Text;
            objusers.RoleID = Convert.ToInt32(ddlrole.SelectedValue == "" ? "0" : ddlrole.SelectedValue);
            objusers.EmployeeID = Convert.ToInt32(ddlemp.SelectedValue == "" ? "0" : ddlemp.SelectedValue);
            objusers.ActionType = EnumActionType.Select;
            objusers.PageSize = pagesize;
            objusers.CurrentIndex = curIndex;
            return objAddUsersBO.SearchUserDetails(objusers);
        }
        private void clearall()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtcpassword.Text = "";
            ddlemp.SelectedIndex = 0;
            ddlrole.SelectedIndex = 0;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            ddlemp.SelectedIndex = 0;
            txtusername.Text = "";
            txtcpassword.Text = "";
            txtpassword.Text = "";
            ddlrole.SelectedIndex = 0;
            btnsave.Text = "Add";
            bindgrid(1);
        }
        protected void GvUserdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblpassword = e.Row.FindControl("lblpassword") as Label;
                    Commonfunction comfunc = new Commonfunction();
                    lblpassword.Text = comfunc.Decrypt(lblpassword.Text.ToString());
                }
            }
        }
        protected void GvUserdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUserdetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvUserdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvUserdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvUserdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvUserdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvUserdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvUserdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvUserdetails.UseAccessibleHeader = true;
            GvUserdetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvUserdetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvUserdetails.DataSource = sortedView;
                    GvUserdetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvUserdetails.HeaderRow.Cells[ColumnIndex];
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
    }
}