using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.Web.AppCode
{
    public class BasePage : System.Web.UI.Page
    {
        #region Private Variables Declaration

        string m_CurrentPage = String.Empty;
        bool isValid = false;
        private static int intCounter = 0;

        #endregion

        #region Public Properties

        protected LoginToken LoginToken
        {
            get;
            set;
        }

        #endregion

        #region Constructor
        public BasePage()
        {
            this.PreInit += new EventHandler(BasePage_PreInit);
            this.Load += new EventHandler(BasePage_Load);
            this.Init += new EventHandler(BasePage_Init);
            this.LoadComplete += new EventHandler(BasePage_LoadComplete);
        }

        #endregion

        #region Page level event

        protected void BasePage_PreInit(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["LoginToken"] != null)
            {
                LoginToken = (LoginToken)HttpContext.Current.Session["LoginToken"];
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
        }
        protected void BasePage_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["LoginToken"] != null)
            {
                LoginToken = (LoginToken)HttpContext.Current.Session["LoginToken"];

            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
        }
        protected void BasePage_Load(object sender, EventArgs e)
        {
            //get the login token        
            if (LoginToken != null)
            {
                #region Check Authorization -

                try
                {
                    if (Request.Url.AbsolutePath != null)
                    {
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "loading_icon_start();", true);
                        m_CurrentPage = Request.Url.AbsolutePath.ToString().Trim();

                        if (m_CurrentPage.IndexOf("/") == 0)
                        {
                            m_CurrentPage = m_CurrentPage.Substring(m_CurrentPage.LastIndexOf('/') + 1);
                        }

                        if (!String.IsNullOrEmpty(m_CurrentPage))
                        {
                            if (Session["LoginToken"] != null)
                            {
                                isValid = IsAuthroize(m_CurrentPage);
                                //if (!isValid && m_CurrentPage != "ReportViewer.aspx")
                                //{
                                //    Response.Redirect("~/Login.aspx", false);
                                //}

                            }
                            else
                            {
                                if (m_CurrentPage != "~/Login.aspx")
                                {
                                    Response.Redirect("~/Login.aspx", false);
                                }
                            }
                        }
                    }
                }

                catch (Exception exm)
                {
                    PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, exm, "110001");
                    LogManager.UpdateCmsErrorDetails(exm);
                    DisplayClientMessage(ExceptionMessage.GetMessage("110001"));
                }

                #endregion
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }

        #endregion
        protected void BasePage_LoadComplete(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "loading_icon_end();", true);
        }
        #region Protected Methods
        /// <summary>
        /// This is used to Display Client Message
        /// </summary>
        /// <param name="Message"></param>
        protected void DisplayClientMessage(string Message)
        {
            if ((Message != null) && Message.Length > 0)
            {
                string script = "<script language=\"javascript\">";
                script += "alert(\"" + Message + "\");";
                script += "</script>";
                intCounter += 1;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "msg" + this.ID + intCounter.ToString(), script);
            }
        }

        /// <summary>
        /// This is used to Set Page Title
        /// </summary>
        /// <param name="titleText"></param>
        protected void SetPageTitle(string titleText)
        {
            //set page title            
            string script = "<script language='javascript'> ";
            script += " document.title = ('" + titleText + "');";
            script += " </script> ";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "setPageTitle", script);
        }
        /// <summary>
        /// Finds a Control recursively. Note finds the first match and exists
        /// </summary>
        /// <param name="Root"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        protected Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;
            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }
            return null;
        }

        #endregion

        #region Private Methods

        private bool IsAuthroize(string PagePath)
        {
            bool isValid = false;

            LoginToken objLoginToken = (LoginToken)HttpContext.Current.Session["LoginToken"];

            List<SiteMapData> list = (List<SiteMapData>)Session["SiteMap"];

            if (objLoginToken != null)
            {
                // Verify Sitemap files
                foreach (SiteMapData objSiteMap in list)
                {
                    if (objSiteMap.Url.Contains("/"))
                    {
                        objSiteMap.Url = objSiteMap.Url.Substring(objSiteMap.Url.LastIndexOf('/') + 1);

                    }
                    if (PagePath.Contains(".aspx"))
                    {
                    }
                    else
                    {
                        PagePath = PagePath + ".aspx";
                    }
                    if (String.Compare(PagePath, objSiteMap.Url, true) == 0)
                    {
                        isValid = true;
                        break;
                    }

                }
            }
            return (isValid);
        }

        #endregion
    }
}