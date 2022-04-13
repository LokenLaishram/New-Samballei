using Mobimp.Edusoft.Data.Common;
using System.Data;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Web.Security;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.BussinessProcess.EduAdmin;
using System;
using System.Web;

namespace Mobimp.Campusoft.Web
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                lblmessage.Visible = false;
                lbl_softwarerights.Text = "© " + DateTime.Now.Year.ToString() + ", Sambalei Sekpil, Kumbi | All Rights Reserved";
                schoolDetails();
                getexpiry();
            }
        }
        private void bindddl()
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtusername.Text = Request.Cookies["UserName"].Value;
                txtpassword.Attributes["value"] = Request.Cookies["Password"].Value;
                myCheckbox.Checked = true;
            }
            else
            {
                Response.Cookies["UserName"].Value = "";
                Response.Cookies["Password"].Value = "";
                txtusername.Text = "";
                txtpassword.Text = "";
                myCheckbox.Checked = false;
            }
        }
        protected void schoolDetails()
        {


        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                CreateUser objCreateUser = new CreateUser();
                CreateUserBO objCreateUserBO = new CreateUserBO();
                if (txtusername.Text.Trim() == "")
                {
                    txtusername.Focus();
                    lblmessage.InnerText = "Please enter username.";
                    lblmessage.Visible = true;
                    return;
                }
                if (txtpassword.Text.Trim() == "")
                {
                    txtpassword.Focus();
                    lblmessage.InnerText = "Please enter password.";
                    lblmessage.Visible = true;
                    return;
                }
                if (txtusername.Text.Trim() != "" && txtpassword.Text.Trim() != "")
                {
                    Commonfunction comfunc = new Commonfunction();
                    objCreateUser.UserName = txtusername.Text.Trim();
                    objCreateUser.UserPassword = comfunc.Encrypt(txtpassword.Text);
                    objCreateUser.ActionType = EnumActionType.Insert;
                    UserCE result = new UserCE();
                    DateTime Today = DateTime.Today;
                    DateTime ExpiryDate = Convert.ToDateTime("02/02/2023");
                    if ((ExpiryDate - Today).TotalDays <= 0)
                    {
                        lblmessage.Visible = true;
                        lblmessage.InnerText = "Campusoft has expired !. Please call 9774592512 for liscence renewal.";
                        return;
                    }
                    result = objCreateUserBO.getCreateUser(objCreateUser);
                    if (result != null)
                    {
                        CreateAuthenticationTicket(result);
                        if (myCheckbox.Checked)
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        }
                        else
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        }
                        Response.Cookies["UserName"].Value = txtusername.Text.Trim();
                        Response.Cookies["Password"].Value = txtpassword.Text.Trim();

                        Response.Redirect("~/HomeDashboard.aspx", false);
                    }
                    else
                    {
                        lblmessage.InnerText = "Incorrect Username or Password";
                        lblmessage.Visible = true;
                    }
                }
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
            }
        }
        private void getexpiry()
        {

            DateTime Today = DateTime.Today;
            DateTime ExpiryDate = Convert.ToDateTime("02/02/2023");
            if ((ExpiryDate - Today).TotalDays <= 15)
            {
                lblmessage.Visible = true;
                lblmessage.InnerText = "Campusoft Licence only: " + (ExpiryDate - Today).TotalDays + " days remaining";
                return;
            }
        }
        private void CreateAuthenticationTicket(UserCE objUSerCE)
        {
            string RolesAssigntoUser = "";
            foreach (Role objUGrp in objUSerCE.RoleList)
            {
                if (RolesAssigntoUser.Trim() != "")
                {
                    RolesAssigntoUser = RolesAssigntoUser + "," + Convert.ToString(objUGrp.RoleName);
                }
                else
                {
                    RolesAssigntoUser = Convert.ToString(objUGrp.RoleName);
                }
            }
            bool isPersistentLogin = false;
            // Create forms authentication ticket
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1, // Ticket version
            objUSerCE.objCreateUser.UserName,// Username to be associated with this ticket
            DateTime.Now, // Date/time ticket was issued
            DateTime.Now.AddMinutes(50), // Date and time the cookie will expire
            isPersistentLogin, // if user has chcked rememebr me then create persistent cookie
            RolesAssigntoUser, // store the user data, in this case roles of the user
            FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.
            // To give more security it is suggested to hash it
            string hashCookies = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket
            // Add the cookie to the response, user browser
            Response.Cookies.Add(cookie);
            //Set login token in context session as key name/id - LoginToken
            SetLoginToken(objUSerCE);
        }
        private void ScheduleLogin()
        {
            CreateUser objUser = new CreateUser();
            CreateUserBO objCreateUserBO = new CreateUserBO();
            objUser.LoginDate = DateTime.Now.ToShortDateString();
            objUser.LoginTime = DateTime.Now.ToShortTimeString();
            objUser.LoginID = Convert.ToInt16(Session["UserID"]);
            objUser.ActionType = EnumActionType.Insert;
            CreateUser objCreateUser = objCreateUserBO.ScheduleLogin(objUser);
            Session["ScheduleId"] = objCreateUser.scheduleID;
        }
        private void SetLoginToken(UserCE objUser)
        {
            try
            {
                LoginToken objLoginToken = new LoginToken();
                objLoginToken.UserLoginId = objUser.objCreateUser.LoginID;
                objLoginToken.LoginId = objUser.objCreateUser.UserName;
                objLoginToken.RoleID = objUser.objCreateUser.RoleID;
                objLoginToken.CompanyID = objUser.objCreateUser.CompanyID;
                objLoginToken.AcademicSessionID = objUser.objCreateUser.AcademicSessionID;
                objLoginToken.AcademicSessionName = objUser.objCreateUser.AcademicSessionName;
                objLoginToken.EmployeeID = objUser.objCreateUser.EmployeeID;
                objLoginToken.AmountEnable = objUser.objCreateUser.AmountEnable;
                objLoginToken.SaveEnable = objUser.objCreateUser.SaveEnable;
                objLoginToken.UpdateEnable = objUser.objCreateUser.UpdateEnable;
                objLoginToken.SearchEnable = objUser.objCreateUser.SearchEnable;
                objLoginToken.EditEnable = objUser.objCreateUser.EditEnable;
                objLoginToken.DeleteEnable = objUser.objCreateUser.DeleteEnable;
                objLoginToken.PrintEnable = objUser.objCreateUser.PrintEnable;
                objLoginToken.ExportEnable = objUser.objCreateUser.ExportEnable;
                objLoginToken.AmountEnable = objUser.objCreateUser.AmountEnable;
                objLoginToken.EnableMultiLogin = objLoginToken.EnableMultiLogin;
                objLoginToken.IsActiveLogin = objLoginToken.IsActiveLogin;
                objLoginToken.DesignationID = objLoginToken.DesignationID;
                objLoginToken.DepartmentID = objLoginToken.DepartmentID;
                Session["LoginToken"] = objLoginToken;

            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
            }
        }
        protected void btnforgotpassword_Click(object sender, EventArgs e)
        {
            //lblMessage.Visible = true;
            //lblMessage.Text = "Please contact system administrator.";
            //lblMessage.CssClass = "MessageFailed";
            //divmsg.Visible = true;
        }
    }
}