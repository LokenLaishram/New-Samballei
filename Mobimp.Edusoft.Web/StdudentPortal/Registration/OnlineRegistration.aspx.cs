using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.StdudentPortal.Registration
{
    public partial class OnlineRegistration : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bindddl();
                if (Session["ID"] != null)
                {
                    Int64 ID = Convert.ToInt64(Session["ID"].ToString());
                    Getstudentdetails(ID);
                }

            }
        }
        protected void Getstudentdetails(Int64 ID)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = ID;
            List<StudentData> studentdetails = objstdBO.GetregistrationdetailbyID(objstd);
            if (studentdetails.Count > 0)
            {

                ddlCast.SelectedValue = studentdetails[0].CastID.ToString();
                ddlreligion.SelectedValue = studentdetails[0].ReligionID.ToString();
                txtfatheroccupation.Text = studentdetails[0].Goccupation.ToString();
                txtmotheroccupation.Text = studentdetails[0].MotherOccupation.ToString();
                ddlrelationship.SelectedValue = studentdetails[0].GrelationshipID.ToString();
                ddlclass.SelectedValue = studentdetails[0].ClassID.ToString();
                ddlcountry.SelectedValue = studentdetails[0].cCountryID.ToString();
                ddlstate.SelectedValue = studentdetails[0].cStateID.ToString();
                ddlDistrict.SelectedValue = studentdetails[0].cDistrictID.ToString();
                txtDOB.Text = studentdetails[0].DOB.ToString("dd/MM/yyyy");
                txtMotherTongue.Text = studentdetails[0].MotherTongue;
                ddlBelongToBPL.SelectedValue = studentdetails[0].BelogToBPLoptionID.ToString();
                txtstudentname.Text = studentdetails[0].Sfirstname.ToString();
                txtfathername.Text = studentdetails[0].Gfirstname;
                txtmothername.Text = studentdetails[0].Mothername;
                txt_GuardianName.Text = studentdetails[0].GurdianName;
                txtgmobile.Text = studentdetails[0].GmobileNo;
                txtaddress.Text = studentdetails[0].cAddress;
                ddlbloodgroup.SelectedValue = studentdetails[0].BloogroupID.ToString();
                txtpin.Text = studentdetails[0].cPIN.ToString();
                ViewState["ID"] = studentdetails[0].StudentID; ;
                txtIDmarks.Text = studentdetails[0].IDmarks.ToString();
                txtallegry.Text = studentdetails[0].Allerrgic.ToString();
                txtfisrtSessionheight.Text = studentdetails[0].Isessioninitialheight.ToString();
                txtIstsessioninitialwt.Text = studentdetails[0].Isessioninitialweight.ToString();
                txtincome.Text = Commonfunction.Getrounding(studentdetails[0].Income.ToString());
                txtlastschoolName.Text = studentdetails[0].LastSchoolName.ToString();
                txtlastclass.Text = studentdetails[0].LastClass.ToString();
                txtlastsection.Text = studentdetails[0].LastSection.ToString();
                txtlastroll.Text = studentdetails[0].LastRollno.ToString();
                txtlatsmarks.Text = studentdetails[0].LastMark.ToString();
                ddlsex.SelectedValue = studentdetails[0].SexID.ToString();
                txtemail.Text = studentdetails[0].EmaildID.ToString();
                txtattendance.Text = studentdetails[0].LastAttendance.ToString();
                txtlastroll.Text = studentdetails[0].LastRollno.ToString();
                txtlatsmarks.Text = studentdetails[0].LastMark.ToString();
                ddlCast.SelectedValue = studentdetails[0].CastID.ToString();
                ddlBelongToBPL.SelectedValue = studentdetails[0].BelogToBPLoptionID.ToString();
                btnsave.Text = "Update";
            }
            else
            {
                clearall();
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlcountry, mstlookup.GetLookupsList(LookupNames.Country));
            ddlcountry.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlstate, mstlookup.GetLookupsList(LookupNames.State));
            ddlstate.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlDistrict, mstlookup.GetLookupsList(LookupNames.District));
            Commonfunction.PopulateDdl(ddlsex, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlreligion, mstlookup.GetLookupsList(LookupNames.Religion));
            Commonfunction.PopulateDdl(ddlCast, mstlookup.GetLookupsList(LookupNames.Cast));
            Commonfunction.PopulateDdl(ddlreligion, mstlookup.GetLookupsList(LookupNames.Religion));
            Commonfunction.PopulateDdl(ddlBelongToBPL, mstlookup.GetLookupsList(LookupNames.BelongToBPLoption));
            Commonfunction.PopulateDdl(ddlbloodgroup, mstlookup.GetLookupsList(LookupNames.BloodGroup));
            Commonfunction.PopulateDdl(ddlrelationship, mstlookup.GetLookupsList(LookupNames.Relationship));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.SexID = Convert.ToInt32(ddlsex.SelectedValue == "" ? "0" : ddlsex.SelectedValue);
                objstd.SalutationID = Convert.ToInt32(ddlsex.SelectedValue == "1" ? "1" : "2");
                objstd.CastID = Convert.ToInt32(ddlCast.SelectedValue == "" ? "0" : ddlCast.SelectedValue);
                objstd.ReligionID = Convert.ToInt32(ddlreligion.SelectedValue == "" ? "0" : ddlreligion.SelectedValue);
                objstd.Sfirstname = txtstudentname.Text == "" ? null : txtstudentname.Text.Trim();
                objstd.Gfirstname = txtfathername.Text == "" ? null : txtfathername.Text.Trim();
                objstd.LastSchoolName = txtlastschoolName.Text.Trim();
                objstd.LastClass = txtlastclass.Text.Trim();
                objstd.LastSection = txtlastsection.Text.Trim();
                objstd.LastRollno = Convert.ToInt32(txtlastroll.Text.Trim() == "" ? "0" : txtlastroll.Text.Trim());
                objstd.LastMark = txtlatsmarks.Text.Trim();
                objstd.GrelationshipID = Convert.ToInt32(ddlrelationship.SelectedValue == "" ? "0" : ddlrelationship.SelectedValue);
                objstd.Goccupation = txtfatheroccupation.Text.Trim() == "" ? null : txtfatheroccupation.Text.Trim();
                objstd.MotherOccupation = txtmotheroccupation.Text.Trim() == "" ? null : txtmotheroccupation.Text.Trim();
                objstd.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objstd.BelogToBPLoptionID = Convert.ToInt32(ddlBelongToBPL.SelectedValue == "" ? "0" : ddlBelongToBPL.SelectedValue);
                objstd.cCountryID = Convert.ToInt32(ddlcountry.SelectedValue == "" ? "0" : ddlcountry.SelectedValue);
                objstd.cStateID = Convert.ToInt32(ddlstate.SelectedValue == "" ? "0" : ddlstate.SelectedValue);
                objstd.cDistrictID = Convert.ToInt32(ddlDistrict.SelectedValue == "" ? "0" : ddlDistrict.SelectedValue);
                DateTime DOB = txtDOB.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDOB.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objstd.DOB = DOB;
                objstd.MotherTongue = txtMotherTongue.Text == "" ? null : txtMotherTongue.Text.Trim();
                objstd.Mothername = txtmothername.Text == "" ? null : txtmothername.Text.Trim();
                objstd.GurdianName = txt_GuardianName.Text == "" ? null : txt_GuardianName.Text.Trim();
                objstd.GmobileNo = txtgmobile.Text == "" ? null : txtgmobile.Text.Trim();
                objstd.cAddress = txtaddress.Text == "" ? null : txtaddress.Text.Trim();
                objstd.cPIN = Convert.ToInt32(txtpin.Text == "" ? "0" : txtpin.Text);
                objstd.LastAttendance = txtattendance.Text == "" ? null : txtattendance.Text.Trim();
                objstd.EmaildID = txtemail.Text == "" ? null : txtemail.Text.Trim();
                objstd.AddedBy = LoginToken.LoginId;
                objstd.UserId = LoginToken.UserLoginId;
                objstd.CompanyID = LoginToken.CompanyID;
                objstd.AcademicSessionID = LoginToken.AcademicSessionID;
                objstd.IDmarks = txtIDmarks.Text.Trim() == "" ? null : txtIDmarks.Text.Trim();
                objstd.Allerrgic = txtallegry.Text.Trim() == "" ? null : txtallegry.Text.Trim();
                objstd.BloogroupID = Convert.ToInt32(ddlbloodgroup.SelectedValue == "" ? "0" : ddlbloodgroup.SelectedValue);
                objstd.Isessioninitialheight = Convert.ToInt64(txtfisrtSessionheight.Text == "" ? "0" : txtfisrtSessionheight.Text);
                objstd.Isessioninitialweight = Convert.ToInt64(txtIstsessioninitialwt.Text == "" ? "0" : txtIstsessioninitialwt.Text);
                objstd.Income = Convert.ToDecimal(txtincome.Text == "" ? "0.00" : txtincome.Text);
                if (Session["ID"] == null)
                {
                    objstd.ActionType = EnumActionType.Insert;
                }
                else
                {
                    objstd.ActionType = EnumActionType.Update;
                    objstd.StudentID = Convert.ToInt64(ViewState["ID"].ToString());
                }
                int results = objstdBO.UpdateonlineregistartionDetails(objstd);
                if (results == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                if (results == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                if (results == 2)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
                Session["ID"] = null;

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
            clearall();
        }
        protected void clearall()
        {
            txtlastschoolName.Text = "";
            txtlastclass.Text = "";
            txtlastsection.Text = "";
            txtlastroll.Text = "";
            txtlatsmarks.Text = "";
            ViewState["ID"] = null;
            txtIDmarks.Text = "";
            txtfisrtSessionheight.Text = "";
            txtIstsessioninitialwt.Text = "";
            txtincome.Text = "";
            txtallegry.Text = "";
            ddlCast.SelectedIndex = 0;
            ddlreligion.SelectedIndex = 0;
            txtmothername.Text = "";
            txtfathername.Text = "";
            txtfatheroccupation.Text = "";
            txtmotheroccupation.Text = "";
            ddlbloodgroup.SelectedIndex = 0;
            ddlrelationship.SelectedIndex = 0;
            ddlclass.SelectedIndex = 0;
            txtstudentname.Text = "";
            txtemail.Text = "";
            ddlDistrict.SelectedIndex = 0;
            txtDOB.Text = "";
            txtgmobile.Text = "";
            txtaddress.Text = "";
            txtpin.Text = "";
            txtlastschoolName.Text = "";
            txtlastclass.Text = "";
            txtlastsection.Text = "";
            txtlastroll.Text = "";
            txtlastroll.Text = "";
            txtlatsmarks.Text = "";
            ddlsex.SelectedIndex = 0;
            btnsave.Text = "Add";
            txt_GuardianName.Text = "";
            txtMotherTongue.Text = "";
            ddlBelongToBPL.SelectedIndex = 0;
            txtattendance.Text = "";
        }
    }
}