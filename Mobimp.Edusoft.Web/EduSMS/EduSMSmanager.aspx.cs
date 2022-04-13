using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduSMS;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.BussinessProcess.SMS;
using ASPSnippets.SmsAPI;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using SMSClassLibrary;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using System.Web.Services.Description;
using Mobimp.Edusoft.Common;
//using System.Web.Services.Description;
using System.Web.UI.HtmlControls;
//using System.Drawing;
using System.Net.NetworkInformation;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using System.Data;
using System.Data.OleDb;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Campusoft.Web.EduSMS
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }

    public partial class EduMSMmanager : BasePage
    {
        //DataSet ds = new DataSet();
        //for ways2sms
        string mbno, mseg, ckuser, ckpass;
        private HttpWebRequest req;
        private CookieContainer cookieCntr;
        private string strNewValue;
        public static string responseee;
        private HttpWebResponse response;
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            bool NetCon = NetworkInterface.GetIsNetworkAvailable();
            if (!IsPostBack)
            {
                BindDlls();
                lblexam.Visible = false;
                ddlexam.Visible = false;
            }
            //divsearch.Visible = false;
            DisplaySMSBalance();
            btnsend.Attributes["disabled"] = "disabled";
        }

        public void DisplaySMSBalance()
        {
            bool NetCon = NetworkInterface.GetIsNetworkAvailable();
            if (NetCon)
            {
                string lblchck = GetSmsBalance();
                lblchkbln.Text = lblchck;
                int apiError = 0;
                apiError = Regex.Matches(lblchck, @"[a-zA-Z]").Count;
                if (apiError > 0)
                {
                    lblchkbln.Text = "Please Contact Campusoft for the Correct SMS API";
                    lblchkbln.ForeColor = System.Drawing.Color.Red;
                    lblchkbln.Font.Bold = true;
                    lblchkbln.Font.Italic = true;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please Contact Campusoft for the Correct SMS API')", true);
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please Contact Campusoft for the right SMS API')", false);
                    return;
                }
                if ((Convert.ToInt32(lblchck) < 90000) && (Convert.ToInt32(lblchck) > 49999))
                {
                    lblchkbln.ForeColor = System.Drawing.Color.Blue;
                    //BindGrid(1);
                }
                if (Convert.ToInt32(lblchck) < 50000 && Convert.ToInt32(lblchck) > 1000)
                {
                    lblchkbln.ForeColor = System.Drawing.Color.Green;
                    //BindGrid(1);
                }
                if (Convert.ToInt32(lblchck) < 999)
                {
                    lblchkbln.ForeColor = System.Drawing.Color.Red;
                    lblchkblnVisi.Visible = true;
                    //BindGrid(1);
                }
            }
            else
            {
                lblchkbln.Text = "Please Check Your Internet Connection";
                lblchkbln.ForeColor = System.Drawing.Color.Red;
                lblchkbln.Font.Bold = true;
                lblchkbln.Font.Italic = true;
                //ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Check Your Internet Connection');", true);
                // Response.Redirect("~/Dashboard.aspx");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please Check Your Internet Connection')", true);
                return;
            }
            //iframe.Visible = true;
            //iframe.Attributes.Add("src", "http://sms.mobimp.com/user/index.php#delivery_reports_text");
        }
        public string GetSmsBalance()
        {
            string lblchck = "0";
            string authKey = GlobalConstant.smsapi;
            //check balance
            string chckbln = "http://sms.mobimp.com/api/balance.php?authkey=" + authKey + "&type=4";
            HttpWebRequest httpCheckBlnreq = (HttpWebRequest)WebRequest.Create(chckbln);
            httpCheckBlnreq.Method = "GET";
            httpCheckBlnreq.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response = (HttpWebResponse)httpCheckBlnreq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            lblchck = reader.ReadToEnd();
            return lblchck;
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclassess, mstlookup.GetLookupsList(LookupNames.Class));
            // Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            // ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlSendTo, mstlookup.GetLookupsList(LookupNames.SendTo));
            Commonfunction.PopulateDdl(ddlSMSMode, mstlookup.GetLookupsList(LookupNames.SmsType));
            Commonfunction.Insertzeroitemindex(ddlsections);
            Commonfunction.Insertzeroitemindex(ddlTemplate);
            divsearch.Visible = false;
            btnimport.Visible = false;
        }
        //Get autocomplete Student Names
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStdNames(string prefixText, int count, string contextKey)
        {
            StudentData objStd = new StudentData();
            AddstudentBO objStdBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objStd.StudentName = prefixText;
            getResult = objStdBO.GetStudentNames(objStd);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentName.ToString());
            }
            return list;
        }
        // Get autocomplete Employee Names
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmpNames(string prefixText, int count, string contextKey)
        {
            EmployeeData objEmp = new EmployeeData();
            EmployeeBO objEmpBO = new EmployeeBO();
            List<EmployeeData> getResult = new List<EmployeeData>();
            objEmp.EmpName = prefixText;
            getResult = objEmpBO.GetEmpnames(objEmp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmpName.ToString());
            }
            return list;
        }
        protected void ddlclassess_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
           // Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclassess.SelectedValue == "" ? "0" : ddlclassess.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : dse.SelectedValue)));
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclassess.SelectedValue == "" ? "0" : ddlclassess.SelectedValue)));
            txtrollNo.Text = "";
            BindGrid(1);
        }
        protected void ddlsections_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtrollNo.Text = "";
            BindGrid(1);
        }
        protected void ddlSMSMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlclassess.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddlsections);
            txtrollNo.Text = "";
            BindGrid(1);
        }
        protected void examtypeControlIf()
        {
            //lblsubtype.Visible = false;
            //ddlsubtype.Visible = false;
            //lblexamtype.Visible = false;
            lbltxtmessage.Visible = false;
            txtmessage.Visible = false;
            btnsend.Visible = false;
            btnsearch.Visible = false;
            btncancel.Visible = false;
            GvStudentSms.Visible = false;
            btnsend.Visible = false;
            //btnSentExamMark.Visible = false;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void BindGrid(int index)
        {
            if (ddlSendTo.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select send to.')", true);
            }
            if (ddlSMSMode.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select sms category.')", true);
            }
            SmsData objSms = new SmsData();
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlTemplate, mstlookup.GetLookupsList(LookupNames.Template));

            int pagesize = Convert.ToInt32(ddlshow.SelectedValue == "10000" ? lbl_totalrecords.Text : ddlshow.SelectedValue);
            List<SmsData> result = Getstudentdetails(index, pagesize);
            if (result.Count > 0)
            {
                GvStudentSms.DataSource = result;
                GvStudentSms.DataBind();
                GvStudentSms.Visible = true;
                btnsend.Visible = true;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvStudentSms.VirtualItemCount = result[0].MaximumRows;
                divsearch.Visible = true;
                btnsend.Attributes.Remove("disabled");
            }
            else
            {
                GvStudentSms.DataSource = null;
                GvStudentSms.DataBind();
                GvStudentSms.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = false;
                btnsend.Attributes["disabled"] = "disabled";

            }
        }
        public List<SmsData> Getstudentdetails(int curIndex, int pagesize)
        {
            SmsData objsms = new SmsData();
            SmsBO objsmsBO = new SmsBO();

            objsms.AcademicSessionID = LoginToken.AcademicSessionID;//Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objsms.SendTo = Convert.ToInt32(ddlSendTo.SelectedValue == "" ? "0" : ddlSendTo.SelectedValue);
            objsms.SmsTypeID = Convert.ToInt32(ddlSMSMode.SelectedValue == "" ? "0" : ddlSMSMode.SelectedValue);
            objsms.ClassID = Convert.ToInt32(ddlclassess.SelectedValue == "" ? "0" : ddlclassess.SelectedValue);
            objsms.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objsms.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objsms.StudentID = Commonfunction.SemicolonSeparation_String_64(txtStudentName.Text);
            objsms.EmployeeID = 0;// Commonfunction.SemicolonSeparation_String_64(txtEmployeeName.Text);
            //objsms.EmployeeName = txtEmployeeName.Text.Trim();
            //objsms.SMSCategoryID = Convert.ToInt32(ddlSMSMode.SelectedValue == "" ? "0" : ddlSMSMode.SelectedValue);
            //objsms.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);

            objsms.PageSize = 10;//GvStudentSms.PageSize;
            objsms.CurrentIndex = curIndex;
            objsms.UserId = LoginToken.UserLoginId;
            return objsmsBO.Getmobilenumers(objsms);
        }
        protected void SMSBindGridExamMark()
        {
            SmsData objSMSExamData = new SmsData();
            SmsBO objSMSBO = new SmsBO();
            objSMSExamData.ClassID = Convert.ToInt32(ddlclassess.SelectedValue == "" ? "0" : ddlclassess.SelectedValue);
            objSMSExamData.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objSMSExamData.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objSMSExamData.AcademicSessionID = LoginToken.AcademicSessionID;
            List<SmsData> result = objSMSBO.SMSBindGridExamMarkBO(objSMSExamData);
            if (result.Count > 0)
            {
                txtmessage.Visible = false;
                btnsearch.Visible = false;
                GvStudentSms.DataSource = null;
                GvStudentSms.Visible = false;
            }
            else
            {
                GvStudentSms.DataSource = null;
                GvStudentSms.DataBind();
                txtmessage.Visible = true;
                btnsearch.Visible = true;
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            resetall();
        }
        protected void ddlSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSMSMode.SelectedIndex = 0;
            ddlclassess.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddlsections);
            txtrollNo.Text = "";
            GvStudentSms.DataSource = null;
            GvStudentSms.DataBind();

            if (ddlSendTo.SelectedValue == "8")
            {
                fileUploadBtn.Visible = true;
                btnsearch.Visible = false;
                btnimport.Visible = true;
            }
            else
            {
                fileUploadBtn.Visible = false;
                btnsearch.Visible = true;
                btnimport.Visible = false;
            }
            //GvStudentSms.Visible = true;
            // BindGrid(1);
        }
        protected void ddlshow_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SmsData objSMS = new SmsData();
            SmsBO objSmsBO = new SmsBO();

            objSMS.TemplateID = Convert.ToInt32(ddlTemplate.SelectedValue == "" ? "0" : ddlTemplate.SelectedValue);

            List<SmsData> Result = objSmsBO.GetSMSTemplateDetailsByID(objSMS);

            if (ddlTemplate.SelectedIndex > 0)
            {
                txtmessage.Text = Result[0].Descriptions == null ? "" : Result[0].Descriptions.ToString();
            }
        }
        protected void resetall()
        {
            //divsearch.Visible = false;
            //ddlSendTo.SelectedIndex = 0;
            //ddlSMSMode.SelectedIndex = 0;
            //ddlclassess.SelectedIndex = 0;
            //lblexam.Visible = false;
            //ddlexam.Visible = false;
            //txtmessage.Visible = true;
            ////ddlsections.SelectedIndex = 0;
            //txtmessage.Text = "";
            //txtrollNo.Text = "";
            ////txtEmployeeName.Text = "";
            //txtStudentName.Text = "";
            //lblresult.Visible = false;
            ////lblmessage.Visible = false;
            //GvStudentSms.DataSource = null;
            //GvStudentSms.DataBind();
            //GvStudentSms.Visible = false;
            ////SMSGridExamData.Visible = false;
            ////btnSentExamMark.Visible = false;
            //Commonfunction.Insertzeroitemindex(ddlsections);
            //Commonfunction.Insertzeroitemindex(ddlTemplate);
            //fileUploadBtn.Visible = false;
            //btnsearch.Visible = true;
            //btnimport.Visible = false;/
            Response.Redirect("~/EduSMS/EduSMSmanager.aspx", false);
        }
        protected void btnsend_Click(object sender, EventArgs e)
        {
            SmsData objSms = new SmsData();
            SmsBO objSmsBO = new SmsBO();
            List<SmsData> lstSmsResult = new List<SmsData>();
            objSms.BalanceBefore = Convert.ToInt64(GetSmsBalance());
            int headcount = 0;
            foreach (GridViewRow row in GvStudentSms.Rows)
            {
                CheckBox chk = (CheckBox)GvStudentSms.Rows[row.RowIndex].Cells[0].FindControl("chkboxselect");
                if (chk.Checked)
                {
                    headcount = headcount + 1;
                }
            }
            int smscount = 0;
            int totalsmsmrequired = 0;
            int chars = txtmessage.Text.Length;

            if (chars <= 160)
            {
                smscount = 1;
            }
            if (chars > 160)
            {
                int count = chars / 160;
                smscount = count + 1;
            }
            totalsmsmrequired = smscount * headcount;

            string lblchck = GetSmsBalance();
            lblchkbln.Text = lblchck;
            if (totalsmsmrequired > Convert.ToInt32(lblchkbln.Text == "" ? "0" : lblchkbln.Text))
            {
                btnsend.Attributes.Remove("disabled");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Insufficient sms balance.") + "')", true);
                return;
            }

            string msg = "";
            string SmsDesc = txtmessage.Text;

            MatchCollection MatchResult = null;
            var regexObj = new Regex(@"#\w*#");
            MatchResult = regexObj.Matches(SmsDesc);
            if (txtmessage.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please enter the message to be sent.')", true);
                return;
            }
            if (MatchResult.Count > 0)
            {
                foreach (Match m in MatchResult)
                {
                    string setcase = m.Value.ToString().ToLower();
                    SmsDesc = SmsDesc.Replace(m.Value.ToString(), setcase);
                }
                msg = Regex.Replace(SmsDesc.Trim(), @"\s+", " ");
            }
            else
            {
                msg = Regex.Replace(txtmessage.Text.Trim(), @"\s+", " ");
            }

            objSms.TemplateID = Convert.ToInt32(ddlTemplate.SelectedValue == "" ? "0" : ddlTemplate.SelectedValue);
            objSms.Template = ddlTemplate.SelectedItem.Text.Trim();
            objSms.Descriptions = Regex.Replace(txtmessage.Text.Trim(), @"\s+", " ");
            objSms.SendTo = Convert.ToInt32(ddlSendTo.SelectedValue == "" ? "0" : ddlSendTo.SelectedValue);
            objSms.SmsTypeID = Convert.ToInt32(ddlSMSMode.SelectedValue == "" ? "0" : ddlSMSMode.SelectedValue);
            objSms.UserId = LoginToken.UserLoginId;
            objSms.SentBy = LoginToken.LoginId;
            objSms.CompanyID = LoginToken.CompanyID;
            objSms.AcademicSessionID = LoginToken.AcademicSessionID;
            lstSmsResult = SendSmsToStudents(msg);

            objSms.BalanceAfter = Convert.ToInt64(GetSmsBalance());
            objSms.HeaderStatusID = lstSmsResult.Count > 0 ? 1 : 0;
            objSms.HeaderStatus = lstSmsResult.Count > 0 ? "Sent" : "Failed";
            objSms.TotalSmsCost = Convert.ToInt32(objSms.BalanceBefore - objSms.BalanceAfter);
            objSms.RecipientCount = lstSmsResult.Count;
            objSms.XmlSendSMS = XmlConvertor.xmlStudentSmsData(lstSmsResult).ToString();
            if (lstSmsResult.Count > 0)
            {
                int result = objSmsBO.UpdateSentSMS(objSms);
                if (result == 1)
                {
                    DisplaySMSBalance();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('Message has sent and updated to database.')", true);
                    return;
                }
                else
                {
                    DisplaySMSBalance();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Message has sent but could not update to database.')", true);
                }
            }
        }
        protected void ddlDsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddlStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        public List<SmsData> SendSmsToStudents(string msg)
        {
            List<SmsData> lstSmsData = new List<SmsData>();

            int check = 0;
            int classID = 0;
            int sectionID = 0;
            int rollNo = 0;

            string msgReplace = "";
            string studentID = "";
            string stdName = "";
            string father = "";
            string mother = "";
            string MobileNumbers = "";

            string[] words = txtmessage.Text.Split(' ');
            Console.WriteLine(words.Length);


            foreach (GridViewRow row in GvStudentSms.Rows)
            {
                msgReplace = msg;
                CheckBox chk = (CheckBox)GvStudentSms.Rows[row.RowIndex].Cells[0].FindControl("chkboxselect");

                if (chk != null && chk.Checked)
                {
                    Label StdID = (Label)GvStudentSms.Rows[row.RowIndex].Cells[1].FindControl("lblstudentID");
                    Label Mobile = (Label)GvStudentSms.Rows[row.RowIndex].Cells[1].FindControl("lblcellNos");
                    Label RollNumber = (Label)GvStudentSms.Rows[row.RowIndex].Cells[3].FindControl("lblRollNo");
                    Label StudentName = (Label)GvStudentSms.Rows[row.RowIndex].Cells[2].FindControl("lblstudents");
                    Label ClassID = (Label)GvStudentSms.Rows[row.RowIndex].Cells[5].FindControl("lblclassID");
                    Label ClassName = (Label)GvStudentSms.Rows[row.RowIndex].Cells[5].FindControl("lblclassName");
                    Label SectionID = (Label)GvStudentSms.Rows[row.RowIndex].Cells[5].FindControl("lblsectionID");
                    Label SectionName = (Label)GvStudentSms.Rows[row.RowIndex].Cells[5].FindControl("lblsectionname");
                    Label FatherName = (Label)GvStudentSms.Rows[row.RowIndex].Cells[6].FindControl("lblFatherName");
                    Label MotherName = (Label)GvStudentSms.Rows[row.RowIndex].Cells[6].FindControl("lblMotherName");

                    MobileNumbers = Mobile.Text.ToString();
                    studentID = StdID.Text.Trim();
                    stdName = StudentName.Text.Trim();
                    rollNo = Convert.ToInt32(RollNumber.Text.Trim());
                    classID = Convert.ToInt32(ClassID.Text.Trim());
                    sectionID = Convert.ToInt32(SectionID.Text.Trim());
                    father = FatherName.Text.Trim();
                    mother = MotherName.Text.Trim();

                    if (msgReplace.Contains("#name#", StringComparison.OrdinalIgnoreCase))
                    {
                        msgReplace = msgReplace.Replace(@"#name#", StudentName.Text);
                    }
                    if (msgReplace.Contains("#rollno#", StringComparison.OrdinalIgnoreCase))
                    {
                        msgReplace = msgReplace.Replace("#rollno#", RollNumber.Text);
                    }
                    if (msgReplace.Contains("#class#", StringComparison.OrdinalIgnoreCase))
                    {
                        msgReplace = msgReplace.Replace("#class#", ClassName.Text);
                    }
                    if (msgReplace.Contains("#section#", StringComparison.OrdinalIgnoreCase))
                    {
                        msgReplace = msgReplace.Replace("#section#", SectionName.Text);
                    }
                    if (msgReplace.Contains("#father#", StringComparison.OrdinalIgnoreCase))
                    {
                        msgReplace = msgReplace.Replace("#father#", FatherName.Text);
                    }
                    if (msgReplace.Contains("#mother#", StringComparison.OrdinalIgnoreCase))
                    {
                        msgReplace = msgReplace.Replace("#mother#", MotherName.Text);
                    }

                    if ((MobileNumbers != "") && (MobileNumbers.Trim().Length == 10))
                    {
                        //Your authentication key
                        string authKey = GlobalConstant.smsapi;

                        //Multiple mobiles numbers separated by comma
                        string mobileNumber = MobileNumbers;
                        //List<string> mobileNumbers = mobileNumber.Split(',').ToList();

                        //Sender ID,While using route4 sender id should be 6 characters long.
                        string senderId = txtsenderid.Text;

                        //length of SMS, upto 160 char in 1 SMS
                        int charCount = msgReplace.Length;

                        //Your message to send, Add URL encoding here.
                        string message = HttpUtility.UrlEncode(msgReplace);

                        //Prepare you post parameters
                        StringBuilder sbPostData = new StringBuilder();
                        sbPostData.AppendFormat("authkey={0}", authKey);
                        sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                        sbPostData.AppendFormat("&message={0}", message);
                        sbPostData.AppendFormat("&sender={0}", senderId);
                        sbPostData.AppendFormat("&route={0}", 4);
                        try
                        {
                            //Call Send SMS API
                            string sendSMSUri = "http://sms.mobimp.com/api/sendhttp.php";
                            //Create HTTPWebrequest
                            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                            //Prepare and Add URL Encoded data
                            UTF8Encoding encoding = new UTF8Encoding();
                            byte[] data = encoding.GetBytes(sbPostData.ToString());
                            //Specify post method
                            httpWReq.Method = "POST";
                            httpWReq.ContentType = "application/x-www-form-urlencoded";
                            httpWReq.ContentLength = data.Length;
                            using (Stream stream = httpWReq.GetRequestStream())
                            {
                                stream.Write(data, 0, data.Length);
                            }

                            int smsCost = 0;
                            double rem = (Convert.ToDouble(msgReplace.Length) / Convert.ToDouble(160));
                            if (rem <= 1)
                            {
                                smsCost = 1;
                            }
                            if ((rem > 1) && (rem <= 2))
                            {
                                smsCost = 2;
                            }
                            if ((rem > 2) && (rem <= 3))
                            {
                                smsCost = 3;
                            }

                            //Get the response
                            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            string responseString = reader.ReadToEnd();

                            //objSms.Status = response.StatusCode.ToString();
                            //objSms.ResponseID = responseString.Trim();

                            lstSmsData.Add(new SmsData()
                            {
                                RecipientUniqueID = Convert.ToInt64(studentID)
                                                         ,
                                ClassID = classID
                                                         ,
                                SectionID = sectionID
                                                         ,
                                RollNo = rollNo
                                                         ,
                                FatherName = father
                                                         ,
                                MotherName = mother
                                                         ,
                                RecipientName = stdName
                                                         ,
                                SendTo = Convert.ToInt32(ddlSendTo.SelectedValue == "" ? "0" : ddlSendTo.SelectedValue)
                                                         ,
                                MobileNo = MobileNumbers
                                                         ,
                                SmsCost = smsCost
                                                         ,
                                DeliveredSMS = msgReplace
                                                         ,
                                CharCount = charCount
                                                         ,
                                StatusID = 1//response.StatusCode.ToString()
                                                         ,
                                Status = response.StatusCode.ToString()
                                                         ,
                                ResponseID = responseString.Trim()
                            });

                            //Close the response
                            reader.Close();
                            response.Close();
                            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('Message Successfully Sent')", true);
                            divsearch.Visible = false;
                            GvStudentSms.Visible = false;
                            lblresult.Visible = false;
                        }
                        catch (Exception)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Error! Please check your connection')", true);
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please check the Mobile Number')", true);
                    }
                }
                check++;
            }

            return lstSmsData;
        }
        protected void txtrollNo_TextChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void GvStudentSms_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // int id = e.Row.RowIndex;
                if (ddlSendTo.SelectedValue != "1")
                {
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                }
            }
        }
        //public List<SmsData> SendSmsToEmployees(string msg)
        //{
        //    List<SmsData> lstSmsData = new List<SmsData>();

        //    int check = 0;
        //    int dsgID = 0;
        //    int staffTypeID = 0;

        //    string msgReplace = "";
        //    string empID = "";
        //    string empNo = "";
        //    string empName = "";
        //    string dsgName = "";
        //    string staffTypeName = "";
        //    string MobileNumbers = "";

        //    foreach (GridViewRow row in GvEmployeeSms.Rows)
        //    {
        //        msgReplace = msg;
        //        CheckBox chk = (CheckBox)GvEmployeeSms.Rows[row.RowIndex].Cells[0].FindControl("chkboxselect");

        //        if (chk != null && chk.Checked)
        //        {
        //            Label EmpID = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[1].FindControl("lblempID");
        //            Label EmpNo = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[1].FindControl("lblEmpNo");
        //            Label EmpName = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[2].FindControl("lblEmpName");
        //            Label DesgID = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[5].FindControl("lblDesgID");
        //            Label DesgName = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[5].FindControl("lblDsgName");
        //            Label StaffTypeID = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[5].FindControl("lblStaffTypeID");
        //            Label StaffTypeName = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[5].FindControl("lblStaffTypeName");
        //            Label Mobile = (Label)GvEmployeeSms.Rows[row.RowIndex].Cells[1].FindControl("lblEmpMobile");

        //            empID = EmpID.Text.Trim();
        //            empNo = EmpNo.Text.Trim();
        //            empName = EmpName.Text.Trim();
        //            dsgID = Convert.ToInt32(DesgID.Text.Trim());
        //            dsgName = DesgName.Text.Trim();
        //            staffTypeID = Convert.ToInt32(StaffTypeID.Text.Trim());
        //            staffTypeName = StaffTypeName.Text.Trim();
        //            MobileNumbers = Mobile.Text.ToString();

        //            if (msgReplace.Contains("#name#", StringComparison.OrdinalIgnoreCase))
        //            {
        //                msgReplace = msgReplace.Replace(@"#name#", empName);
        //            }
        //            if (msgReplace.Contains("#empid#", StringComparison.OrdinalIgnoreCase))
        //            {
        //                msgReplace = msgReplace.Replace("#empid#", empNo);
        //            }
        //            if (msgReplace.Contains("#designation#", StringComparison.OrdinalIgnoreCase))
        //            {
        //                msgReplace = msgReplace.Replace("#designation#", dsgName);
        //            }
        //            if (msgReplace.Contains("#stafftype#", StringComparison.OrdinalIgnoreCase))
        //            {
        //                msgReplace = msgReplace.Replace("#stafftype#", staffTypeName);
        //            }

        //            if ((MobileNumbers != "") && (MobileNumbers.Trim().Length == 10))
        //            {
        //                //Your authentication key
        //                string authKey = GlobalConstant.smsapi;

        //                //Multiple mobiles numbers separated by comma
        //                string mobileNumber = MobileNumbers;
        //                //List<string> mobileNumbers = mobileNumber.Split(',').ToList();

        //                //Sender ID,While using route4 sender id should be 6 characters long.
        //                string senderId = txtsenderid.Text;

        //                //length of SMS, upto 160 char in 1 SMS
        //                int charCount = msgReplace.Length;

        //                //Your message to send, Add URL encoding here.
        //                string message = HttpUtility.UrlEncode(msgReplace);

        //                //Prepare you post parameters
        //                StringBuilder sbPostData = new StringBuilder();
        //                sbPostData.AppendFormat("authkey={0}", authKey);
        //                sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
        //                sbPostData.AppendFormat("&message={0}", message);
        //                sbPostData.AppendFormat("&sender={0}", senderId);
        //                sbPostData.AppendFormat("&route={0}", 4);
        //                try
        //                {
        //                    //Call Send SMS API
        //                    string sendSMSUri = "http://sms.mobimp.com/api/sendhttp.php";
        //                    //Create HTTPWebrequest
        //                    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
        //                    //Prepare and Add URL Encoded data
        //                    UTF8Encoding encoding = new UTF8Encoding();
        //                    byte[] data = encoding.GetBytes(sbPostData.ToString());
        //                    //Specify post method
        //                    httpWReq.Method = "POST";
        //                    httpWReq.ContentType = "application/x-www-form-urlencoded";
        //                    httpWReq.ContentLength = data.Length;
        //                    using (Stream stream = httpWReq.GetRequestStream())
        //                    {
        //                        stream.Write(data, 0, data.Length);
        //                    }

        //                    int smsCost = 0;
        //                    double rem = (Convert.ToDouble(msgReplace.Length) / Convert.ToDouble(160));
        //                    if (rem <= 1)
        //                    {
        //                        smsCost = 1;
        //                    }
        //                    if ((rem > 1) && (rem <= 2))
        //                    {
        //                        smsCost = 2;
        //                    }
        //                    if ((rem > 2) && (rem <= 3))
        //                    {
        //                        smsCost = 3;
        //                    }

        //                    //Get the response
        //                    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
        //                    StreamReader reader = new StreamReader(response.GetResponseStream());
        //                    string responseString = reader.ReadToEnd();

        //                    //objSms.Status = response.StatusCode.ToString();
        //                    //objSms.ResponseID = responseString.Trim();

        //                    lstSmsData.Add(new SmsData()
        //                    {
        //                        RecipientUniqueID = Convert.ToInt64(empID)
        //                                                 ,
        //                        EmployeeNo = empNo
        //                                                 ,
        //                        RecipientName = empName
        //                                                 ,
        //                        DesignationID = dsgID
        //                                                 ,
        //                        StaffTypeID = staffTypeID
        //                                                 ,
        //                        MobileNo = MobileNumbers
        //                                                 ,
        //                        SendTo = Convert.ToInt32(ddlSendTo.SelectedValue == "" ? "0" : ddlSendTo.SelectedValue)
        //                                                 ,
        //                        SmsCost = smsCost
        //                                                 ,
        //                        DeliveredSMS = msgReplace
        //                                                 ,
        //                        CharCount = charCount
        //                                                 ,
        //                        StatusID = 1//response.StatusCode.ToString()
        //                                                 ,
        //                        Status = response.StatusCode.ToString()
        //                                                 ,
        //                        ResponseID = responseString.Trim()
        //                    });

        //                    //Close the response
        //                    reader.Close();
        //                    response.Close();
        //                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('Message Successfully Sent')", true);
        //                    divsearch.Visible = false;
        //                    GvEmployeeSms.Visible = false;
        //                    lblresult.Visible = false;
        //                }
        //                catch (Exception)
        //                {
        //                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Error! Please check your connection')", true);
        //                }

        //            }
        //            else
        //            {
        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please check the Mobile Number')", true);
        //            }
        //        }
        //        check++;
        //    }

        //    return lstSmsData;
        //}

        //---------------------------------------End Previous Sending Code------------------------------------
        // }
        //protected void btnSentExamMark_Click(object sender, EventArgs e)
        //{
        //    int check = 0;
        //    string MobileNumbers = "";
        //    string GetExamData = "";
        //    foreach (GridViewRow row in SMSGridExamData.Rows)
        //    {

        //        CheckBox chk = (CheckBox)SMSGridExamData.Rows[row.RowIndex].Cells[0].FindControl("chkboxselect");
        //        if (chk != null && chk.Checked && chk.Enabled && chk.Visible)
        //        {
        //            //   MobileNumbers = SMSGridExamData.Cells[2].Text;

        //            Label Gmobileno = (Label)SMSGridExamData.Rows[row.RowIndex].Cells[0].FindControl("lblGmobileno");
        //            MobileNumbers = Gmobileno.Text.ToString() + ",";

        //            Label ExamData = (Label)SMSGridExamData.Rows[row.RowIndex].Cells[0].FindControl("lblExamData");
        //            GetExamData = ExamData.Text.ToString() + ",";

        //            if (MobileNumbers != "")
        //            {
        //                //Your authentication key
        //                string authKey = GlobalConstant.smsapi;

        //                //Multiple mobiles numbers separated by comma
        //                string mobileNumber = MobileNumbers;
        //                //List<string> mobileNumbers = mobileNumber.Split(',').ToList();

        //                //Sender ID,While using route4 sender id should be 6 characters long.
        //                string senderId = txtsenderid.Text;
        //                //Your message to send, Add URL encoding here.
        //                string message = HttpUtility.UrlEncode(GetExamData);

        //                //Prepare you post parameters
        //                StringBuilder sbPostData = new StringBuilder();
        //                sbPostData.AppendFormat("authkey={0}", authKey);
        //                sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
        //                sbPostData.AppendFormat("&message={0}", message);
        //                sbPostData.AppendFormat("&sender={0}", senderId);
        //                sbPostData.AppendFormat("&route={0}", 4);
        //                try
        //                {
        //                    //Call Send SMS API
        //                    string sendSMSUri = "http://sms.mobimp.com/api/sendhttp.php";
        //                    //Create HTTPWebrequest
        //                    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
        //                    //Prepare and Add URL Encoded data
        //                    UTF8Encoding encoding = new UTF8Encoding();
        //                    byte[] data = encoding.GetBytes(sbPostData.ToString());
        //                    //Specify post method
        //                    httpWReq.Method = "POST";
        //                    httpWReq.ContentType = "application/x-www-form-urlencoded";
        //                    httpWReq.ContentLength = data.Length;
        //                    using (Stream stream = httpWReq.GetRequestStream())
        //                    {
        //                        stream.Write(data, 0, data.Length);
        //                    }
        //                    //Get the response
        //                    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
        //                    StreamReader reader = new StreamReader(response.GetResponseStream());
        //                    string responseString = reader.ReadToEnd();

        //                    //Close the response
        //                    reader.Close();
        //                    response.Close();
        //                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('Message Successfully Sent')", true);
        //                    GvStudentSms.Visible = false;
        //                    lblresult.Visible = false;
        //                }
        //                catch (Exception)
        //                {
        //                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Error in Sending Message... Please Check your connection...')", true);
        //                }
        //            }
        //            else
        //            {
        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please update Mobile Number to the system.')", true);
        //            }

        //        }
        //        check = check + 1;
        //    }
        //    //check = check + 1;
        //}

        //Responsive
        protected void bindresponsive()
        {
            //Responsive 
            GvStudentSms.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvStudentSms.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvStudentSms.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvStudentSms.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvStudentSms.UseAccessibleHeader = true;
            GvStudentSms.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvStudentSms.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            //HttpPostedFile fileName = fileimport.PostedFile;
            if (!fileUploadBtn.HasFile)
            {
                divsearch.Visible = true;
                lblresult.Text = "Please select file and try.";
                lblresult.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                var fileName = fileUploadBtn.FileName.ToString();
                string extension = Path.GetExtension(fileUploadBtn.PostedFile.FileName);
                string rootFilePath = Request.PhysicalApplicationPath + @"Documents/SMS/";
                string[] fileList = Directory.GetFiles(rootFilePath);
                foreach (string file in fileList) // delete existing files
                {
                    File.Delete(file);
                }
                string FileAppPath = rootFilePath + fileName;
                fileUploadBtn.SaveAs(FileAppPath);
                Import_To_Grid(FileAppPath, extension, fileName);
            }
        }
        private void Import_To_Grid(string FilePath, string Extension, string fileName)
        {
            string ConStr = "";
            string fullFilepath = FilePath.Replace("/", "\\");

            if (Extension.Trim() == ".xls")
            {
                //connection string for the file with extension .xls  
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFilepath + ";Mode=ReadWrite;Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";
            }
            if (Extension.Trim() == ".xlsx")
            {
                //connection string for the file with extension .xlsx  
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFilepath + ";Extended Properties='Excel 12.0 xml;HDR=Yes;';";
            }
            try
            {
                //Read Data From Excel
                DataSet ds = new DataSet();

                OleDbConnection con = new OleDbConnection(ConStr);
                //Get the name of First Sheet
                con.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                if (SheetName != "Sheet1$")
                {
                    con.Close();
                    con.Dispose();
                    GC.Collect();
                    GvStudentSms.DataSource = null;
                    GvStudentSms.DataBind();
                    lblresult.Visible = true;
                    lblresult.Text = "Sheet name should be Sheet1 and only one sheet is allowed.Start column from index 0 (Name,MobileNo)";
                    lblresult.ForeColor = System.Drawing.Color.Red;
                    divsearch.Visible = true;
                    return;
                }
                else
                {
                    lblresult.Visible = false;
                }
                OleDbCommand oconn = new OleDbCommand("SELECT * From [" + SheetName + "] Where Name <>'' ", con);
                OleDbDataAdapter da = new OleDbDataAdapter(oconn);
                da.Fill(ds);
                DataTable table = ds.Tables[0];

                string name1 = table.Columns[0].ColumnName.ToString();
                string name2 = table.Columns[1].ColumnName.ToString();
                if (name1 == "" || name2 == "")
                {
                    da.Dispose();
                    da.Dispose();
                    con.Close();
                    con.Dispose();
                    GC.Collect();
                    GvStudentSms.DataSource = null;
                    GvStudentSms.DataBind();
                    lblresult.Visible = true;
                    lblresult.Text = "Start column from index 0 (Name,MobileNo)";
                    lblresult.ForeColor = System.Drawing.Color.Red;
                    divsearch.Visible = true;
                    return;
                }
                else
                {
                    lblresult.Visible = false;
                }
                if (name1 != "Name" || name2 != "MobileNo")
                {
                    da.Dispose();
                    da.Dispose();
                    con.Close();
                    con.Dispose();
                    GC.Collect();
                    GvStudentSms.DataSource = null;
                    GvStudentSms.DataBind();
                    lblresult.Visible = true;
                    lblresult.Text = "There should be only two coulmns i.e Name and MobileNo in the excel data.";
                    lblresult.ForeColor = System.Drawing.Color.Red;
                    divsearch.Visible = true;
                    return;
                }
                else
                {
                    lblresult.Visible = false;
                }
                if (table.Columns[0].DataType == typeof(string) && table.Columns[1].DataType == typeof(string))
                {
                    List<ImportSmsData> contactlist = ORHelper<ImportSmsData>.FromDataTableToList(table);
                    if (contactlist.Count > 0)
                    {
                        MasterLookupBO mstlookup = new MasterLookupBO();
                        Commonfunction.PopulateDdl(ddlTemplate, mstlookup.GetLookupsList(LookupNames.Template));
                        GvStudentSms.DataSource = contactlist;
                        GvStudentSms.DataBind();
                        lblresult.Visible = true;
                        lblresult.Text = "Data has successfully imported.";
                        lblresult.ForeColor = System.Drawing.Color.DarkGreen;
                        divsearch.Visible = true;
                        btnsend.Visible = true;
                        btnsend.Attributes.Remove("disabled");

                    }
                    else
                    {
                        da.Dispose();
                        da.Dispose();
                        con.Close();
                        con.Dispose();
                        GC.Collect();
                        GvStudentSms.DataSource = null;
                        GvStudentSms.DataBind();
                        lblresult.Visible = true;
                        lblresult.Text = "Data could not import.";
                        lblresult.ForeColor = System.Drawing.Color.Red;
                        divsearch.Visible = true;
                        btnsend.Visible = false;
                        btnsend.Attributes["disabled"] = "disabled";
                        return;
                    }
                }
                else
                {
                    da.Dispose();
                    da.Dispose();
                    con.Close();
                    con.Dispose();
                    GC.Collect();
                    GvStudentSms.DataSource = null;
                    GvStudentSms.DataBind();
                    divsearch.Visible = true;
                    lblresult.Text = "Please convert Name and MobileNo as Text in Excel Data.";
                    lblresult.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                da.Dispose();
                da.Dispose();
                con.Close();
                con.Dispose();
                GC.Collect();
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblresult.Text = ExceptionMessage.GetMessage(ex);
                return;
            }
        }
    }
}