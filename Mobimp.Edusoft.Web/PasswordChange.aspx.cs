using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduAdmin;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.Web
{
    public partial class PasswordChange : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binduserdetails();
                txtempnames.Attributes["disabled"] = "disabled";
            }
        }
        protected void binduserdetails()
        {
            userdetails objemp = new userdetails();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.UserId = LoginToken.UserLoginId;
            List<userdetails> result = objempBO.GetEmployeeDetailsLoginDetails(objemp);
            if (result.Count > 0)
            {
                txtempnames.Text = result[0].EmpName.ToString();
                lbloldpassword.Text = result[0].UserPassword.ToString();
                txtusername.Text = result[0].UserName.ToString();
                txtempnames.Text = result[0].EmpName.ToString();
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Commonfunction comfunc = new Commonfunction();
                userdetails objusers = new userdetails();
                AddUsersBO objAddUsersBO = new AddUsersBO();
                if (comfunc.Encrypt(txtpassword.Text) != lbloldpassword.Text)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Old password is not correct") + "')", true);

                    return;
                }
                objusers.EmployeeID = LoginToken.EmployeeID;
                objusers.UserPassword = comfunc.Encrypt(txtcpassword.Text);
                objusers.RealPassword = txtcpassword.Text.Trim();
                objusers.UserId = LoginToken.UserLoginId;
                objusers.UserName = txtusername.Text;
                int result = objAddUsersBO.UpdateChangepassword(objusers);
                if (result == 1)
                {
                    txtpassword.Text = "";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
        }
    }
}