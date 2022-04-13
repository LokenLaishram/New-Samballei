using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduEmployee
{
    public partial class EmployeesAttendance : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddls();
                GetDatedetails();
            }
        }
        protected void bindddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlsessions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlsessions.SelectedIndex = 1;
        }
        protected void GetDatedetails()
        {
            GetTodaysDateDetails objstd = new GetTodaysDateDetails();
            AddstudentBO objstdBO = new AddstudentBO();
            List<GetTodaysDateDetails> result = objstdBO.GetdateDetails(objstd);
            if (result.Count > 0)
            {
                txtday.Text = result[0].DaysName.ToString() + ", " + result[0].TodayDate.ToString("dd/MM/yyyy");
                if (result[0].DaysName.ToString() == "Sunday")
                {
                    btnsearch.Enabled = false;
                }
                else
                {
                    btnsearch.Enabled = true;
                }
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Getempattendancelist();
        }
        protected void Getempattendancelist()
        {
            EmployeeAttendanceData objemp = new EmployeeAttendanceData();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeNo = txtemployeedID.Text == "" ? null : txtemployeedID.Text;
            objemp.EmpName = txtempnames.Text == "" ? null : txtempnames.Text;
            objemp.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objemp.UserId = LoginToken.UserLoginId;
            List<EmployeeAttendanceData> result = objempBO.GetEmployeeRegister(objemp);
            if (result.Count > 0)
            {
                Gvemployeeattendance.DataSource = result;
                Gvemployeeattendance.DataBind();
                Gvemployeeattendance.Visible = true;
                lbltotpresent.Text = result[0].TotalPresent.ToString();
                lbltotabsent.Text = result[0].TotalAbsent.ToString();
                lbltotleave.Text = result[0].TotalOnleave.ToString();
                lblattendanelist.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lblattendanelist.CssClass = "MsgSuccess";
                lblattendanelist.Visible = true;
            }
            else
            {
                Gvemployeeattendance.DataSource = null;
                Gvemployeeattendance.DataBind();
                Gvemployeeattendance.Visible = true;
                lbltotpresent.Text = "0";
                lbltotabsent.Text = "0";
                lbltotleave.Text = "0";
                lblattendanelist.Text = "Total :No record found. ";
                lblattendanelist.CssClass = "Message";
                lblattendanelist.Visible = true;
            }

        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmpNo(string prefixText, int count, string contextKey)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();
            List<EmployeeData> getResult = new List<EmployeeData>();
            objemp.EmployeeNo = prefixText;
            getResult = objempBO.GetEmpNo(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeNo.ToString());
            }
            return list;
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            txtemployeedID.Text = "";
            txtempnames.Text = "";
            lbltotpresent.Text = "0";
            lbltotabsent.Text = "0";
            lbltotleave.Text = "0";
            Gvemployeeattendance.DataSource = null;
            Gvemployeeattendance.DataBind();
            Gvemployeeattendance.Visible = false;
            lblattendanelist.Visible = false;

        }

        protected void Gvemployeeattendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Login")
                {
                    EmployeeAttendanceData objemp = new EmployeeAttendanceData();
                    EmployeeBO objempBO = new EmployeeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvemployeeattendance.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox pasword = (TextBox)gr.Cells[2].FindControl("txtpassword");
                    Button btnlogin = (Button)gr.Cells[3].FindControl("btnlogin");
                    Button btnlogout = (Button)gr.Cells[3].FindControl("btnlogout");
                    if (pasword.Text == "")
                    {
                        Messagealert_.ShowMessage(lblmessage, "Please enter password to login", 0);
                        return;
                    }
                    objemp.EmployeeID = Convert.ToInt32(ID.Text);
                    objemp.UserPassword = pasword.Text;
                    objemp.ActionType = EnumActionType.Insert;
                    int Result = objempBO.UpdateLogin(objemp);
                    if (Result == 1)
                    {
                        btnlogin.Enabled = false;
                        btnlogout.Enabled = true;
                        Messagealert_.ShowMessage(lblmessage, "Login Successfully", 1);
                        Getempattendancelist();

                    }
                    if (Result == 11)
                    {
                        Messagealert_.ShowMessage(lblmessage, "Please enter correct password.", 0);

                    }

                }
                if (e.CommandName == "Logout")
                {
                    EmployeeAttendanceData objemp = new EmployeeAttendanceData();
                    EmployeeBO objempBO = new EmployeeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvemployeeattendance.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox pasword = (TextBox)gr.Cells[2].FindControl("txtpassword");
                    TextBox Remarks = (TextBox)gr.Cells[4].FindControl("txtremarks");
                    Button btnlogin = (Button)gr.Cells[3].FindControl("btnlogin");
                    Button btnlogout = (Button)gr.Cells[3].FindControl("btnlogout");
                    if (pasword.Text == "")
                    {
                        Messagealert_.ShowMessage(lblmessage, "Please enter password to logout.", 0);
                        return;
                    }
                    objemp.EmployeeID = Convert.ToInt32(ID.Text);
                    objemp.UserPassword = pasword.Text;
                    objemp.Remarks = Remarks.Text;
                    objemp.ActionType = EnumActionType.Update;
                    int Result = objempBO.UpdateLogout(objemp);
                    if (Result == 2)
                    {
                        Getempattendancelist();
                        btnlogin.Enabled = false;
                        btnlogout.Enabled = false;
                        Remarks.Text = "";

                        Messagealert_.ShowMessage(lblmessage, "Logout Successfully", 1);
                    }
                    if (Result == 11)
                    {
                        Messagealert_.ShowMessage(lblmessage, "Please enter correct password.", 0);

                    }

                }

            }
            catch (Exception ex) //Exception in agent layer itself
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
            }

        }

        protected void Gvemployeeattendance_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            foreach (GridViewRow row in Gvemployeeattendance.Rows)
            {
                try
                {
                    Label lblisloigin = (Label)Gvemployeeattendance.Rows[row.RowIndex].Cells[0].FindControl("lbllogin");
                    Label lblattendance = (Label)Gvemployeeattendance.Rows[row.RowIndex].Cells[0].FindControl("lblattendance");
                    Label lbllogout = (Label)Gvemployeeattendance.Rows[row.RowIndex].Cells[0].FindControl("lbllogout");
                    Button btnlogin = (Button)Gvemployeeattendance.Rows[row.RowIndex].Cells[3].FindControl("btnlogin");
                    Button btnlogout = (Button)Gvemployeeattendance.Rows[row.RowIndex].Cells[3].FindControl("btnlogout");
                    TextBox txtremarks = (TextBox)Gvemployeeattendance.Rows[row.RowIndex].Cells[0].FindControl("txtremarks");


                    if (lblisloigin.Text == "1")
                    {
                        btnlogin.Enabled = false;
                    }
                    else
                    {
                        btnlogin.Enabled = true;
                    }
                    if (lbllogout.Text == "2")
                    {
                        btnlogout.Enabled = false;
                    }
                    else
                    {
                        btnlogout.Enabled = true;
                    }

                    if (lblattendance.Text == "L")
                    {
                        btnlogin.Enabled = false;
                        btnlogout.Enabled = false;
                        txtremarks.Text = "On Leave.";
                    }
                    if (lblisloigin.Text == "0" && lbllogout.Text == "0")
                    {
                        btnlogout.Enabled = false;
                    }

                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }

        }

        protected void btnsearchattendance_Click(object sender, EventArgs e)
        {
            EmployeeAttendanceData objemp = new EmployeeAttendanceData();
            EmployeeBO objempBO = new EmployeeBO();

            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objemp.EmployeeNo = txtemployeesID.Text == "" ? null : txtemployeesID.Text;
            objemp.EmpName = txtemployee.Text == "" ? null : txtemployee.Text;
            objemp.AcademicSessionID = Convert.ToInt32(ddlsessions.SelectedValue == "" ? "0" : ddlsessions.SelectedValue);
            objemp.Datefrom = from;
            objemp.Dateto = To;
            List<EmployeeAttendanceData> result = objempBO.GetEmpattendance(objemp);
            if (result.Count > 0)
            {
                Gvattendancedetaillist.DataSource = result;
                Gvattendancedetaillist.DataBind();
                Gvattendancedetaillist.Visible = true;
                lbltotresentlist.Text = result[0].TotalPresent.ToString();
                lbltotabsentlist.Text = result[0].TotalAbsent.ToString();
                lbltotonleavlist.Text = result[0].TotalOnleave.ToString();
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lblresult.CssClass = "MsgSuccess";
                lblresult.Visible = true;
            }
            else
            {
                Gvattendancedetaillist.DataSource = null;
                Gvattendancedetaillist.DataBind();
                Gvattendancedetaillist.Visible = true;
                lbltotresentlist.Text = "0";
                lbltotabsentlist.Text = "0";
                lbltotonleavlist.Text = "0";
               ;
                lblresult.CssClass = "Message";
                lblresult.Visible = true;
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtemployee.Text = "";
            txtemployeesID.Text = "";
            txtfrom.Text = "";
            txtto.Text = "";
            lbltotresentlist.Text = "0";
            lbltotabsentlist.Text = "0";
            lbltotonleavlist.Text = "0";
            Gvattendancedetaillist.DataSource = null;
            Gvattendancedetaillist.DataBind();
            Gvattendancedetaillist.Visible = false;
            lblresult.Visible = false;
        }

        protected void Gvattendancedetaillist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in Gvattendancedetaillist.Rows)
            {
                try
                {
                    Label logintime = (Label)Gvattendancedetaillist.Rows[row.RowIndex].Cells[5].FindControl("lbllogintime");
                    Label logoutime = (Label)Gvattendancedetaillist.Rows[row.RowIndex].Cells[5].FindControl("lbllogoutime");
                    //ddlattendance.SelectedIndex = 0;
                    if (logintime.Text == "12:00 AM")
                    {
                        logintime.Text = "00:00";
                    }
                    if (logoutime.Text == "12:00 AM")
                    {
                        logoutime.Text = "00:00";
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    //lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }




        }
    }
}