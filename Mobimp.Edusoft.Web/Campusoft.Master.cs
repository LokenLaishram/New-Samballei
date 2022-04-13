using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mediqura.BOL.CommonBO;
using Mobimp.Campusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.EduAdmin;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Web.AppCode;

namespace Mobimp.Campusoft.Web
{
    public partial class Campusoft : BaseMasterPage
    {
        LoginToken objLoginToken;
        DataTable Menus = new DataTable();
        string baseurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Header.DataBind();
                objLoginToken = (LoginToken)Session["LoginToken"];
                if (objLoginToken != null)
                {
                    lbl_loginame.Text = objLoginToken.LoginId;
                    baseurl = Request.Url.GetLeftPart(UriPartial.Authority);
                    BindMenu();
                    //GetControll_Enable();
                    AutoCompleteExtender1.ContextKey = objLoginToken.RoleID.ToString();
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex);
            }
        }
        protected void rptMenu_OnItemBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (Menus != null)
                    {
                        DataRowView drv = e.Item.DataItem as DataRowView;
                        string ID = drv["SiteMapID"].ToString();
                        string Title = drv["Title"].ToString();

                        DataRow[] rows = Menus.Select("ParentID=" + ID);
                        if (rows.Length > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<ul class='menu-content'>");
                            foreach (var item in rows)
                            {
                                string parentId = item["SiteMapID"].ToString();
                                string cssfont = item["CssFont"].ToString();
                                string parentTitle = item["Title"].ToString();
                                string url = item["Url"].ToString();
                                DataRow[] parentRow = Menus.Select("ParentID=" + parentId);

                                if (parentRow.Count() > 0)
                                {
                                    sb.Append("<li><a class='menu-item' data-i18n='nav.menu_levels.second_level' href='" + url + "'><i  class='" + cssfont + "'></i><span data-i18n='nav.dash.main' class='menu - title'> " + parentTitle + " </ span ></a>");
                                    sb.Append("</li>");
                                }
                                else
                                {
                                    sb.Append("<li><a class='menu-item'  href='" + url + "'><i class='" + cssfont + "' ></i><span data-i18n='nav.dash.main' class='menu - title'> " + parentTitle + " </ span ></a>");
                                    sb.Append("</li>");
                                }
                                sb = CreateChild(sb, parentId, parentTitle, parentRow);
                            }
                            sb.Append("</ul>");
                            (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                        }
                    }
                }
            }
        }
        private StringBuilder CreateChild(StringBuilder sb, string parentId, string parentTitle, DataRow[] parentRows)
        {
            if (parentRows.Length > 0)
            {
                sb.Append("<ul class='menu-content'>");
                foreach (var item in parentRows)
                {
                    string childId = item["SiteMapID"].ToString();
                    string cssfont = item["CssFont"].ToString();
                    string childTitle = item["Title"].ToString();
                    string childUrl = item["Url"].ToString();
                    DataRow[] childRow = Menus.Select("ParentID=" + childId);
                    if (childRow.Count() > 0)
                    {
                        sb.Append("<li><a class='menu-item' data-i18n='nav.menu_levels.second_level' href='" + childUrl + "'><i style='font-size: xx-small;' class='" + cssfont + "'></i>" + childTitle + "</a>");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("<li class='menu-item' ><a href='" + childUrl + "'><i style='font-size: xx-small;' class='" + cssfont + "'></i>" + childTitle + "</a>");
                        sb.Append("</li>");
                    }
                    CreateChild(sb, childId, childTitle, childRow);
                }
                sb.Append("</ul>");
            }
            return sb;
        }
        private void BindMenu()
        {
            Menus = GetData();

            List<SiteMapData> objSiteMap = ORHelper<SiteMapData>.FromDataTableToList(Menus);

            DataView view = new DataView(Menus);
            view.RowFilter = "ParentID=0";

            this.rptCategories.DataSource = view;
            this.rptCategories.DataBind();

            List<SiteMapData> List = new List<SiteMapData>();
            List = objSiteMap;
            Session["SiteMap"] = List;
        }
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_CMS_Adm_GetAllSiteMaps";
                        cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = objLoginToken.RoleID;
                        cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = objLoginToken.EmployeeID;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);

                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    row[3] = baseurl + '/' + row[3].ToString();
                }
                return dt;
            }
        }
        private void GetControll_Enable()
        {
            PageControlsData objcontrols = new PageControlsData();
            PageControlBO objcontrolBO = new PageControlBO();
            List<PageControlsData> controllist = new List<PageControlsData>();
            objcontrols.RoleID = objLoginToken.RoleID;
            objcontrols.EmployeeID = objLoginToken.EmployeeID;
            objcontrols.url = Request.Url.AbsolutePath.Remove(0, 1).Trim();
            controllist = objcontrolBO.GetControlEnabledetails(objcontrols);
            if (controllist.Count > 0)
            {
                LoginToken LoginToken = new LoginToken();
                LoginToken.AcademicSessionID = objLoginToken.AcademicSessionID;
                LoginToken.AcademicSessionName = objLoginToken.AcademicSessionName;
                LoginToken.RoleID = objLoginToken.RoleID;
                LoginToken.RoleNames = objLoginToken.RoleNames;
                LoginToken.CompanyID = objLoginToken.CompanyID;
                LoginToken.SaveEnable = Convert.ToInt32(controllist[0].SaveEnable);
                LoginToken.UpdateEnable = Convert.ToInt32(controllist[0].UpdateEnable);
                LoginToken.SearchEnable = Convert.ToInt32(controllist[0].SearchEnable);
                LoginToken.EditEnable = Convert.ToInt32(controllist[0].EditEnable);
                LoginToken.DeleteEnable = Convert.ToInt32(controllist[0].DeleteEnable);
                LoginToken.PrintEnable = Convert.ToInt32(controllist[0].PrintEnable);
                LoginToken.ExportEnable = Convert.ToInt32(controllist[0].ExportEnable);
                LoginToken.AmountEnable = Convert.ToInt32(controllist[0].AmountEnable);
                LoginToken.EnableMultiLogin = objLoginToken.EnableMultiLogin;
                LoginToken.IsActiveLogin = objLoginToken.IsActiveLogin;
                LoginToken.DesignationID = objLoginToken.DesignationID;
                LoginToken.DepartmentID = objLoginToken.DepartmentID;
                Session["LoginToken"] = LoginToken;
            }
            else
            {
                LoginToken LoginToken = new LoginToken();
                LoginToken.AcademicSessionID = objLoginToken.AcademicSessionID;
                LoginToken.AcademicSessionName = objLoginToken.AcademicSessionName;
                LoginToken.RoleID = objLoginToken.RoleID;
                LoginToken.RoleNames = objLoginToken.RoleNames;
                LoginToken.CompanyID = objLoginToken.CompanyID;
                LoginToken.EnableMultiLogin = objLoginToken.EnableMultiLogin;
                LoginToken.IsActiveLogin = objLoginToken.IsActiveLogin;
                LoginToken.SaveEnable = 1;
                LoginToken.UpdateEnable = 1;
                LoginToken.SearchEnable = 1;
                LoginToken.EditEnable = 1;
                LoginToken.DeleteEnable = 1;
                LoginToken.PrintEnable = 1;
                LoginToken.AmountEnable = 1;
                LoginToken.DesignationID = objLoginToken.DesignationID;
                LoginToken.DepartmentID = objLoginToken.DepartmentID;
                LoginToken.IPaddress = objLoginToken.IPaddress;
                Session["LoginToken"] = LoginToken;

            }
        }
        protected void lnkdashboard_Click(object sender, EventArgs e)
        {

        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            try
            {


                ScheduleLogOut();
                Session.Abandon();
                Response.ExpiresAbsolute = DateTime.Now;
                Response.Expires = 0;
                Response.CacheControl = "no-cache";
                Session["SiteMap"] = null;
                Session["LoginToken"] = null;
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                FormsAuthentication.SignOut();
                Response.Redirect("~/Login.aspx", false);

            }
            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx", false);

            }
        }
        private void ScheduleLogOut()
        {
            CreateUser objUser = new CreateUser();
            CreateUserBO objCreateUserBO = new CreateUserBO();
            objUser.ActionType = EnumActionType.Update;
            objUser.LogOutDate = DateTime.Now.ToShortDateString();
            objUser.LogOutTime = DateTime.Now.ToShortTimeString();
            objUser.scheduleID = Convert.ToInt16(Session["ScheduleId"]);
            objCreateUserBO.ScheduleLogOut(objUser);
        }
        protected void link_pswd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PasswordChange.aspx");
        }
        protected void btnChatSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", false);
        }
        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            PageControlsData objcontrols = new PageControlsData();
            PageControlBO objcontrolBO = new PageControlBO();
            List<PageControlsData> controllist = new List<PageControlsData>();
            objcontrols.RoleID = objLoginToken.RoleID;

            bool isnumeric = txt_search.Text.All(char.IsDigit);
            if (isnumeric == false)
            {
                if (txt_search.Text.Contains(":"))
                {
                    objcontrols.PageID = Commonfunction.SemicolonSeparation_String_32(txt_search.Text);
                }
                else
                {
                    txt_search.Text = "";
                    txt_search.Focus();
                }
            }
            else
            {
                objcontrols.PageID = 0;
            }
            controllist = objcontrolBO.GetPageurls(objcontrols);
            if (controllist.Count > 0)
            {
                Response.Redirect("~/" + controllist[0].url, false);
            }
            else
            {
                txt_search.Text = "";
            }
        }

        protected void lbtn_dashboard_Click(object sender, EventArgs e)
        {
            if (objLoginToken.RoleID == 9)
            {
                Response.Redirect("~/StdudentPortal/Fees/OnlineFeepayment.aspx", false);
            }
            {
                Response.Redirect("~/HomeDashboard.aspx");
            }
        }
    }
}