using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduAdmin;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduAdmin
{
    public partial class PageManagerNew : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                //bindresponsive();
                divrapper.Visible = false;
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(drpRole, mstlookup.GetLookupsList(LookupNames.Roles));
            // drpRole.SelectedValue = "1";
            // bindsitemaps();
            Commonfunction.PopulateDdl(ddl_menuheader, mstlookup.GetLookupsList(LookupNames.MenuHeader));
            //Commonfunction.Insertzeroitemindex(ddl_subheader);
        }
        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_menuheader.SelectedIndex = 0;
            //  Commonfunction.Insertzeroitemindex(ddl_subheader);
            // bindsitemaps();
            // bindresponsive();
        }
        protected void ddl_menuheader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRole.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + "Please select role" + "')", true);
                return;
            }
            if (ddl_menuheader.SelectedIndex > 0)
            {
                // MasterLookupBO mstlookup = new MasterLookupBO();
                // Commonfunction.PopulateDdl(ddl_subheader, mstlookup.GetMenuSubheaderByHeaderID(Convert.ToInt32(ddl_menuheader.SelectedValue == "" ? "0" : ddl_menuheader.SelectedValue)));
                bindsitemaps();
                divrapper.Visible = true;
            }
            else
            {
                //  Commonfunction.Insertzeroitemindex(ddl_subheader);
                //bindsitemaps();
                Gvpagemanager.DataSource = null;
                Gvpagemanager.DataBind();
                Gvpagemanager.Visible = false;
                divrapper.Visible = false;
            }

        }
        protected void bindresponsive()
        {
            //Responsive 
            Gvpagemanager.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gvpagemanager.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gvpagemanager.UseAccessibleHeader = true;
            Gvpagemanager.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void ddl_subheader_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsitemaps();
            bindresponsive();
        }
        protected void bindsitemaps()
        {
            RolesData objRole = new RolesData();
            UserAdminBO useradm = new UserAdminBO();
            objRole.RoleID = Convert.ToInt32(drpRole.SelectedValue == "" ? "0" : drpRole.SelectedValue);
            objRole.MenuHeaderID = Convert.ToInt32(ddl_menuheader.SelectedValue == "" ? "0" : ddl_menuheader.SelectedValue);
            //  objRole.PageID = Convert.ToInt32(ddl_subheader.SelectedValue == "" ? "0" : ddl_subheader.SelectedValue);
            List<SiteMapData> lstSitemap = useradm.GetMedPagesbyRoleID(objRole);
            if (lstSitemap.Count > 0)
            {
                Gvpagemanager.DataSource = lstSitemap;
                Gvpagemanager.DataBind();
                Gvpagemanager.Visible = true;
                divrapper.Visible = true;
                bindresponsive();

            }
            else
            {
                Gvpagemanager.DataSource = null;
                Gvpagemanager.DataBind();
                Gvpagemanager.Visible = true;
                divrapper.Visible = false;
            }
        }
        protected void Gvpagemanager_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Status = e.Row.FindControl("lbl_menustatus") as Label;
                Label Menuheader = e.Row.FindControl("lbl_menuHeader") as Label;
                CheckBox Chk = e.Row.FindControl("chkselect") as CheckBox;
                if (Status.Text == "1")
                {
                    Chk.Checked = true;
                }
                else
                {
                    Chk.Checked = false;
                }
                if (Menuheader.Text == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }

            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpRole.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select role.") + "')", true);
                    return;
                }
                if (ddl_menuheader.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select menu header.") + "')", true);
                    return;
                }
                List<RolesData> list = new List<RolesData>();
                UserAdminBO useradm = new UserAdminBO();
                RolesData obj = new RolesData();
                foreach (GridViewRow row in Gvpagemanager.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label PageID = (Label)Gvpagemanager.Rows[row.RowIndex].Cells[0].FindControl("lbl_sitemapID");
                    CheckBox chk = (CheckBox)Gvpagemanager.Rows[row.RowIndex].Cells[0].FindControl("chkselect");
                    RolesData ObjDetails = new RolesData();
                    ObjDetails.PageID = Convert.ToInt32(PageID.Text == "" ? "0" : PageID.Text);
                    ObjDetails.PageStatus = chk.Checked ? 1 : 0;
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.PageDatatoXML(list).ToString();
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.RoleID = Convert.ToInt32(drpRole.SelectedValue == "" ? "0" : drpRole.SelectedValue);

                bool status = useradm.SavePageRole(obj);
                if (status == true)
                {
                    bindsitemaps();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

    }
}