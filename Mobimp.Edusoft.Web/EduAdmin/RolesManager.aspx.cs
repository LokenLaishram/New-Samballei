using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.BussinessProcess.EduAdmin;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Web.UserControls;
using System.Data;
using System.Reflection;

namespace Mobimp.Edusoft.Web.EduAdmin
{
    public partial class AddRoles : BasePage
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
                RolesData objroles = new RolesData();
                AddRolesBO objAddRolesBO = new AddRolesBO();
                objroles.RoleCode = txtcode.Text;
                objroles.RoleName = txtdescription.Text;
                objroles.AddedBy = LoginToken.LoginId;
                objroles.UserId = LoginToken.UserLoginId; ;
                objroles.CompanyID = LoginToken.CompanyID;
                objroles.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objroles.ActionType = EnumActionType.Update;
                    objroles.RoleID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objAddRolesBO.UpdateRoleDetails(objroles);
                if (result == 1 || result == 2)
                {
                    clearall();
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    clearall();
                    bindgrid(1);
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
        protected void GvRoledetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    RolesData objroles = new RolesData();
                    AddRolesBO objAddRolesBO = new AddRolesBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvRoledetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objroles.RoleID = Convert.ToInt32(ID.Text);
                    objroles.ActionType = EnumActionType.Select;

                    List<RolesData> GetResult = objAddRolesBO.GetRoleDetailsByID(objroles);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].RoleCode;
                        txtdescription.Text = GetResult[0].RoleName;
                        ViewState["ID"] = GetResult[0].RoleID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    RolesData objroles = new RolesData();
                    AddRolesBO objAddRolesBO = new AddRolesBO();
                    objroles.RoleID = Convert.ToInt16(e.CommandArgument.ToString());
                    objroles.ActionType = EnumActionType.Delete;
                    int Result = objAddRolesBO.DeleteRoleDetailsByID(objroles);
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
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        public List<RolesData> GetRoleDetails(int curIndex, int pagesize)
        {
            RolesData objroles = new RolesData();
            AddRolesBO objAddRolesBO = new AddRolesBO();
            objroles.RoleCode = txtcode.Text == "" ? null : txtcode.Text;
            objroles.RoleName = txtdescription.Text == "" ? null : txtdescription.Text;
            objroles.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objroles.ActionType = EnumActionType.Select;
            objroles.PageSize = pagesize;
            objroles.CurrentIndex = curIndex;
            return objAddRolesBO.SearchRoleDetails(objroles);
        }
        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtcode.Text = "";
            txtdescription.Text = "";
            ddlstatus.SelectedIndex = 0;
            btnsave.Text = "Add";
            bindgrid(1);
        }
        protected void GvRoledetails_PageIndexChanging(object sender, GridViewPageEventArgs e)        
        {
            GvRoledetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<RolesData> lstemp = GetRoleDetails(index, pagesize);
            if (lstemp.Count > 0)
            {
                GvRoledetails.PageSize = pagesize;
                string record = lstemp[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstemp[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstemp[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvRoledetails.VirtualItemCount = lstemp[0].MaximumRows;//total item is required for custom paging
                GvRoledetails.PageIndex = index - 1;
                GvRoledetails.DataSource = lstemp;
                GvRoledetails.DataBind();
                ds = ConvertToDataSet(lstemp);
                TableCell tableCell = GvRoledetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                GvRoledetails.DataSource = GetRoleDetails(index, pagesize);
                GvRoledetails.DataBind();
            }
            else
            {
                GvRoledetails.DataSource = null;
                GvRoledetails.DataBind();
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvRoledetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvRoledetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvRoledetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvRoledetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvRoledetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvRoledetails.UseAccessibleHeader = true;
            GvRoledetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvRoleDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvRoledetails.DataSource = sortedView;
                    GvRoledetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvRoledetails.HeaderRow.Cells[ColumnIndex];
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
    }
}