using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using System.IO;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Web.UserControls;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;
using System.Threading.Tasks;
using System.Text;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Campusoft.Data.EduTransport;
using Mobimp.Campusoft.BussinessProcess.EduTransport;
using Mobimp.Campusoft.BussinessProcess.EduHostel;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Campusoft.Data.EduExam;
using Mobimp.Campusoft.BussinessProcess.EduExam;

namespace Mobimp.Edusoft.Web
{
    public partial class StudentProfile : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtAdmNo.Attributes["disabled"] = "disabled";
            ddlamdission.Attributes["disabled"] = "disabled";
            txtDOB.Attributes["disabled"] = "disabled";
            txtstudentname.Attributes["disabled"] = "disabled";
            txtBirthRegNo.Attributes["disabled"] = "disabled";
            ddlstudenttype.Attributes["disabled"] = "disabled";
            ddlCast.Attributes["disabled"] = "disabled";
            ddlsex.Attributes["disabled"] = "disabled";
            ddlreligion.Attributes["disabled"] = "disabled";
            txtMotherTongue.Attributes["disabled"] = "disabled";
            ddlBelongToBPL.Attributes["disabled"] = "disabled";
            ddlstudenycategory.Attributes["disabled"] = "disabled";
            ddlhouse.Attributes["disabled"] = "disabled";
            txtIDmarks.Attributes["disabled"] = "disabled";
            ddlhouse.Attributes["disabled"] = "disabled";
            ddlclass.Attributes["disabled"] = "disabled";
            ddlsection.Attributes["disabled"] = "disabled";
            txtrollno.Attributes["disabled"] = "disabled";
            txtregdno.Attributes["disabled"] = "disabled";
            ddlbloodgroup.Attributes["disabled"] = "disabled";
            txtallegry.Attributes["disabled"] = "disabled";
            txtfisrtSessionheight.Attributes["disabled"] = "disabled";
            txtIstsessioninitialwt.Attributes["disabled"] = "disabled";
            txtfathername.Attributes["disabled"] = "disabled";
            txtmothername.Attributes["disabled"] = "disabled";
            ddlrelationship.Attributes["disabled"] = "disabled";
            txtfatheroccupation.Attributes["disabled"] = "disabled";
            txtmotheroccupation.Attributes["disabled"] = "disabled";
            txtincome.Attributes["disabled"] = "disabled";
            txtgmobile.Attributes["disabled"] = "disabled";
            txtlastschoolName.Attributes["disabled"] = "disabled";
            txtlastclass.Attributes["disabled"] = "disabled";
            txtlastsection.Attributes["disabled"] = "disabled";
            txtlastroll.Attributes["disabled"] = "disabled";
            txtlatsmarks.Attributes["disabled"] = "disabled";
            txtattendance.Attributes["disabled"] = "disabled";
            txtbankname.Attributes["disabled"] = "disabled";
            txtifsc.Attributes["disabled"] = "disabled";
            txtaccountno.Attributes["disabled"] = "disabled";
            txtaadhar.Attributes["disabled"] = "disabled";
            txtaddress.Attributes["disabled"] = "disabled";
            txtpaddress.Attributes["disabled"] = "disabled";
            ddlacademicseesions.Attributes["disabled"] = "disabled";
            txtsubjectlist.Attributes["disabled"] = "disabled";



            if (!this.IsPostBack)
            {
                if (Session["StudentID"] != null && Session["academicsession"] != null)
                {
                    MasterLookupBO objmstlookupBO = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlacademicseesions, objmstlookupBO.GetLookupsList(LookupNames.Academicsession));
                    Commonfunction.PopulateDdl(ddlsession, objmstlookupBO.GetLookupsList(LookupNames.Academicsession));
                    Commonfunction.PopulateDdl(ddlEsession, objmstlookupBO.GetLookupsList(LookupNames.Academicsession));
                    Commonfunction.PopulateDdl(ddlPrintAcademicSession, objmstlookupBO.GetLookupsList(LookupNames.Academicsession));
                    Commonfunction.PopulateDdl(ddlHDsession, objmstlookupBO.GetLookupsList(LookupNames.Academicsession));
                    Commonfunction.PopulateDdl(ddlTsession, objmstlookupBO.GetLookupsList(LookupNames.Academicsession));
                    bindddl();
                    ddlacademicseesions.SelectedValue = Session["academicsession"].ToString();
                    ddlsession.SelectedValue = Session["academicsession"].ToString();
                    ddlEsession.SelectedValue = Session["academicsession"].ToString();
                    ddlPrintAcademicSession.SelectedValue = Session["academicsession"].ToString();
                    ddlHDsession.SelectedValue = Session["academicsession"].ToString();
                    ddlTsession.SelectedValue = Session["academicsession"].ToString();
                    txtAdmNo.Text = Session["StudentID"].ToString();
                    Int64 StudentID = Convert.ToInt64(txtAdmNo.Text);
                    int SessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue);
                    StudentsProfileList(StudentID, SessionID);
                    bindStatusDetails(1);
                    bindExamStatusDetails(1);
                    bindCertificateStatusDetails(1);
                    TransportStudentList(StudentID, SessionID);
                    HostelStudentList(StudentID, SessionID);



                    Session["StudentID"] = null;
                    Session["academicsession"] = null;
                }
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            //Commonfunction.PopulateDdl(ddlcountry, mstlookup.GetLookupsList(LookupNames.Country));
            //ddlcountry.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlstate, mstlookup.GetLookupsList(LookupNames.State));
            //ddlstate.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlDistrict, mstlookup.GetLookupsList(LookupNames.District));
            //ddlDistrict.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlpcountry, mstlookup.GetLookupsList(LookupNames.Country));
            //ddlpcountry.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlpstate, mstlookup.GetLookupsList(LookupNames.State));
            //ddlpstate.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlpdistrict, mstlookup.GetLookupsList(LookupNames.District));
            //ddlpdistrict.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlsex, mstlookup.GetLookupsList(LookupNames.Sex));
            //Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlreligion, mstlookup.GetLookupsList(LookupNames.Religion));
            Commonfunction.PopulateDdl(ddlCast, mstlookup.GetLookupsList(LookupNames.Cast));
            ddlCast.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlreligion, mstlookup.GetLookupsList(LookupNames.Religion));
            Commonfunction.PopulateDdl(ddlBelongToBPL, mstlookup.GetLookupsList(LookupNames.BelongToBPLoption));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlsection, mstlookup.GetLookupsList(LookupNames.Section));
            //Commonfunction.Insertzeroitemindex(ddlsection);
            //Commonfunction.Insertzeroitemindex(ddlsections);
            //Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            //ddlacademicseesions.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlcategorys, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            Commonfunction.PopulateDdl(ddlstudenycategory, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            ddlstudenycategory.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlbloodgroup, mstlookup.GetLookupsList(LookupNames.BloodGroup));
            Commonfunction.PopulateDdl(ddlrelationship, mstlookup.GetLookupsList(LookupNames.Relationship));
            Commonfunction.PopulateDdl(ddlstudenttype, mstlookup.GetLookupsList(LookupNames.StudentType));
            //Commonfunction.PopulateDdl(ddllstudentypes, mstlookup.GetLookupsList(LookupNames.StudentType));
            //Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlamdission, mstlookup.GetLookupsList(LookupNames.Admissiontype));
            //Commonfunction.PopulateDdl(ddladmissiontype, mstlookup.GetLookupsList(LookupNames.Admissiontype));
            Commonfunction.PopulateDdl(ddlhouse, mstlookup.GetLookupsList(LookupNames.House));
            //Commonfunction.PopulateDdl(ddlcastes, mstlookup.GetLookupsList(LookupNames.Cast));
            //Commonfunction.PopulateDdl(ddluser, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
            //Commonfunction.PopulateDdl(ddlhouselist, mstlookup.GetLookupsList(LookupNames.House));

            //txtDOB.Text = Convert.ToString("01/03/2000");
            //txtpin.Text = Convert.ToString("795009");
            //txtppin.Text = Convert.ToString("795009");
            btnmaximizetap1.Visible = false;
        }
        public List<StudentData> Getstudentprofile(Int64 StudentID, int SessionID)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = StudentID;
            objstd.AcademicSessionID = SessionID;
            return objstdBO.SearchStudentProfile(objstd);
        }
        protected void StudentsProfileList(Int64 studentID, int sessionID)
        {
            List<StudentData> studentprofile = Getstudentprofile(studentID, sessionID);
            if (studentprofile.Count > 0)
            {
                ddlamdission.SelectedValue = studentprofile[0].IsNew.ToString();
                txtstudentname.Text = studentprofile[0].StudentName.ToString();
                txtAdmNo.Text = studentprofile[0].AdmissionNo.ToString();
                txtDOB.Text = studentprofile[0].DOB.ToString();
                txtBirthRegNo.Text = studentprofile[0].BirthRegNo.ToString();
                ddlstudenttype.SelectedValue = studentprofile[0].StudentTypeID.ToString();
                ddlCast.SelectedValue = studentprofile[0].CastID.ToString();
                ddlsex.SelectedValue = studentprofile[0].SexID.ToString();
                ddlreligion.SelectedValue = studentprofile[0].ReligionID.ToString();
                txtMotherTongue.Text = studentprofile[0].MotherTongue.ToString();
                ddlBelongToBPL.SelectedValue = studentprofile[0].BelogToBPLoptionID.ToString();
                ddlstudenycategory.SelectedValue = studentprofile[0].StudentCategory.ToString();
                ddlhouse.SelectedValue = studentprofile[0].HouseID.ToString();
                txtIDmarks.Text = studentprofile[0].IDmarks.ToString();
                ddlclass.SelectedValue = studentprofile[0].ClassID.ToString();
                ddlsection.SelectedValue = studentprofile[0].SectionID.ToString();
                txtrollno.Text = studentprofile[0].RollNo.ToString();
                txtregdno.Text = studentprofile[0].RegdNo.ToString();
                ddlbloodgroup.SelectedValue = studentprofile[0].BloogroupID.ToString();
                txtallegry.Text = studentprofile[0].Allerrgic.ToString();
                txtfisrtSessionheight.Text = studentprofile[0].Isessioninitialheight.ToString();
                txtIstsessioninitialwt.Text = studentprofile[0].Isessioninitialweight.ToString();
                txtfathername.Text = studentprofile[0].GurdianName.ToString();
                txtmothername.Text = studentprofile[0].Mothername.ToString();
                ddlrelationship.SelectedValue = studentprofile[0].GrelationshipID.ToString();
                txtfatheroccupation.Text = studentprofile[0].Goccupation.ToString();
                txtmotheroccupation.Text = studentprofile[0].MotherOccupation.ToString();
                txtincome.Text = Commonfunction.Getrounding(studentprofile[0].Income.ToString());
                txtgmobile.Text = studentprofile[0].GmobileNo.ToString();
                txtlastschoolName.Text = studentprofile[0].LastSchoolName.ToString();
                txtlastclass.Text = studentprofile[0].LastClass.ToString();
                txtlastsection.Text = studentprofile[0].LastSection.ToString();
                txtlastroll.Text = studentprofile[0].LastRollno.ToString();
                txtlatsmarks.Text = studentprofile[0].LastMark.ToString();
                txtattendance.Text = studentprofile[0].LastAttendance.ToString();
                txtbankname.Text = studentprofile[0].BankName.ToString();
                txtifsc.Text = studentprofile[0].IFSC.ToString();
                txtaccountno.Text = studentprofile[0].AC.ToString();
                txtaadhar.Text = studentprofile[0].Aadhar.ToString();
                txtaddress.Text = studentprofile[0].cAddress.ToString();
                txtpaddress.Text = studentprofile[0].pAddress.ToString();
                ddlacademicseesions.SelectedValue = studentprofile[0].AcademicSessionID.ToString();
            }
            else
            {
                clearall();
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentNames(string prefixText, int count, string contextKey)
        {
            StudentData objemp = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objemp.StudentName = prefixText;
            getResult = objempBO.GetStudentNames(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentName.ToString());
            }
            return list;
        }
        //protected void GvstudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (ddlstatus.SelectedValue == "0")
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            GvstudentDetails.Columns[7].Visible = false;
        //            GvstudentDetails.Columns[8].Visible = false;
        //            GvstudentDetails.Columns[9].Visible = true;
        //            GvstudentDetails.Columns[11].Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            GvstudentDetails.Columns[7].Visible = true;
        //            GvstudentDetails.Columns[8].Visible = true;
        //            GvstudentDetails.Columns[9].Visible = false;
        //            GvstudentDetails.Columns[11].Visible = true;
        //        }
        //    }
        //    if (this.GvstudentDetails.Rows.Count > 0)
        //    {
        //        GvstudentDetails.UseAccessibleHeader = true;
        //        GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        // GvstudentDetails.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }
        //}
        //protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    MasterLookupBO objmstlookupBO = new MasterLookupBO();
        //    Commonfunction.PopulateDdl(ddlstate, objmstlookupBO.GetStatelistByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)));
        //}
        //protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    MasterLookupBO objmstlookupBO = new MasterLookupBO();
        //    int stateID = Convert.ToInt32(ddlstate.SelectedValue);
        //    int CountryID = Convert.ToInt32(ddlcountry.SelectedValue);
        //    Commonfunction.PopulateDdl(ddlDistrict, objmstlookupBO.GetDistrictlistByID(stateID, CountryID));
        //}
        //protected void chksame_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chksame.Checked)
        //    {
        //        MasterLookupBO mstlookup = new MasterLookupBO();
        //        Commonfunction.PopulateDdl(ddlpcountry, mstlookup.GetLookupsList(LookupNames.Country));
        //        Commonfunction.PopulateDdl(ddlpstate, mstlookup.GetLookupsList(LookupNames.State));
        //        Commonfunction.PopulateDdl(ddlpdistrict, mstlookup.GetLookupsList(LookupNames.District));
        //        txtpaddress.Text = txtaddress.Text;
        //        ddlpcountry.SelectedValue = ddlcountry.SelectedValue;
        //        ddlpstate.SelectedValue = ddlstate.SelectedValue;
        //        ddlpdistrict.SelectedValue = ddlDistrict.SelectedValue;
        //        txtppin.Text = txtpin.Text;
        //        txtplandmarks.Text = txtlandmark.Text;
        //    }
        //    else
        //    {
        //        MasterLookupBO mstlookup = new MasterLookupBO();
        //        txtpaddress.Text = "";
        //        Commonfunction.PopulateDdl(ddlpcountry, mstlookup.GetLookupsList(LookupNames.Country));
        //        Commonfunction.PopulateDdl(ddlpstate, mstlookup.GetLookupsList(LookupNames.State));
        //        Commonfunction.PopulateDdl(ddlpdistrict, mstlookup.GetLookupsList(LookupNames.District));
        //        txtppin.Text = "";
        //        txtplandmarks.Text = "";

        //    }
        //}
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                string fileName = studentphotouploader.FileName.ToString();
                if (fileName == "")
                {
                    objstd.StudentPhoto = "../EduImages/EmpDummyPh.png";
                    objstd.StudentImage = null;
                }
                else
                {
                    if (!studentphotouploader.HasFile)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                        return;
                    }
                    else
                    {
                        string path = getDigitalPath(fileName);
                        objstd.StudentPhoto = path;
                        //imageuploader as bit image
                        int length = studentphotouploader.PostedFile.ContentLength;
                        //create a byte array to store the binary image data
                        byte[] imgbyte = new byte[length];
                        //store the currently selected file in memeory
                        HttpPostedFile img = studentphotouploader.PostedFile;
                        //set the binary data
                        img.InputStream.Read(imgbyte, 0, length);
                        objstd.StudentImage = imgbyte;

                        if (path == "fail" || objstd.StudentPhoto == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                            return;
                        }
                    }
                }

                //objstd.AdmissionNo = txtadmissionNo.Text.Trim();
                objstd.EnrollmentNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.SexID = Convert.ToInt32(ddlsex.SelectedValue == "" ? "0" : ddlsex.SelectedValue);
                objstd.SalutationID = Convert.ToInt32(ddlsex.SelectedValue == "1" ? "1" : "2");
                objstd.StudentTypeID = Convert.ToInt32(ddlstudenttype.SelectedValue == "" ? "0" : ddlstudenttype.SelectedValue);
                objstd.NationalityID = 1;
                objstd.CastID = Convert.ToInt32(ddlCast.SelectedValue == "" ? "0" : ddlCast.SelectedValue);
                objstd.ReligionID = Convert.ToInt32(ddlreligion.SelectedValue == "" ? "0" : ddlreligion.SelectedValue);
                objstd.GsalutationID = 1;
                objstd.Msalutation = 2;
                objstd.Sfirstname = txtstudentname.Text == "" ? null : txtstudentname.Text.Trim();
                objstd.Gfirstname = txtfathername.Text == "" ? null : txtfathername.Text.Trim();
                objstd.StudentCategory = Convert.ToInt32(ddlstudenycategory.SelectedValue == "" ? "0" : ddlstudenycategory.SelectedValue);
                objstd.LastSchoolName = txtlastschoolName.Text.Trim();
                objstd.LastClass = txtlastclass.Text.Trim();
                objstd.LastSection = txtlastsection.Text.Trim();
                objstd.LastRollno = Convert.ToInt32(txtlastroll.Text.Trim() == "" ? "0" : txtlastroll.Text.Trim());
                objstd.LastMark = txtlatsmarks.Text.Trim();
                objstd.GrelationshipID = Convert.ToInt32(ddlrelationship.SelectedValue == "" ? "0" : ddlrelationship.SelectedValue);
                objstd.Goccupation = txtfatheroccupation.Text.Trim() == "" ? null : txtfatheroccupation.Text.Trim();
                objstd.MotherOccupation = txtmotheroccupation.Text.Trim() == "" ? null : txtmotheroccupation.Text.Trim();
                objstd.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objstd.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
                objstd.RollNo = Convert.ToInt32(txtrollno.Text == "" ? "0" : txtrollno.Text);
                objstd.RegdNo = txtregdno.Text.Trim();
                //objstd.cCountryID = Convert.ToInt32(ddlcountry.SelectedValue == "" ? "0" : ddlcountry.SelectedValue);
                //objstd.cStateID = Convert.ToInt32(ddlstate.SelectedValue == "" ? "0" : ddlstate.SelectedValue);
                //objstd.cDistrictID = Convert.ToInt32(ddlDistrict.SelectedValue == "" ? "0" : ddlDistrict.SelectedValue);
                //objstd.pCountryID = Convert.ToInt32(ddlpcountry.SelectedValue == "" ? "0" : ddlpcountry.SelectedValue);
                //objstd.pStateID = Convert.ToInt32(ddlpstate.SelectedValue == "" ? "0" : ddlpstate.SelectedValue);
                //objstd.pDistrictID = Convert.ToInt32(ddlpdistrict.SelectedValue == "" ? "0" : ddlpdistrict.SelectedValue);
                objstd.BloogroupID = Convert.ToInt32(ddlbloodgroup.SelectedValue == "" ? "0" : ddlbloodgroup.SelectedValue);
                DateTime DOB = txtDOB.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDOB.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objstd.DOB = DOB;
                objstd.MotherTongue = txtMotherTongue.Text == "" ? null : txtMotherTongue.Text.Trim();
                objstd.BirthRegNo = txtBirthRegNo.Text == "" ? null : txtBirthRegNo.Text.Trim();
                objstd.BelogToBPLoptionID = Convert.ToInt32(ddlBelongToBPL.SelectedValue == "" ? "0" : ddlBelongToBPL.SelectedValue);
                objstd.Aadhar = txtaadhar.Text == "" ? "0" : txtaadhar.Text;
                objstd.Mothername = txtmothername.Text == "" ? null : txtmothername.Text.Trim();
                objstd.GmobileNo = txtgmobile.Text == "" ? null : txtgmobile.Text.Trim();
                objstd.cAddress = txtaddress.Text == "" ? null : txtaddress.Text.Trim();
                //objstd.cPIN = Convert.ToInt32(txtpin.Text == "" ? "0" : txtpin.Text);
                //objstd.cLandMark = txtlandmark.Text == "" ? null : txtlandmark.Text.Trim();
                objstd.pAddress = txtpaddress.Text == "" ? null : txtpaddress.Text.Trim();
                //objstd.pLandMark = txtplandmarks.Text == "" ? null : txtplandmarks.Text.Trim();
                objstd.LastAttendance = txtattendance.Text == "" ? null : txtattendance.Text.Trim();
                objstd.IFSC = txtifsc.Text == "" ? null : txtifsc.Text.Trim();
                objstd.AC = txtaccountno.Text == "" ? null : txtaccountno.Text.Trim();
                objstd.BankName = txtbankname.Text == "" ? null : txtbankname.Text.Trim();
                //objstd.EmaildID = txtemail.Text == "" ? null : txtemail.Text.Trim();
                //objstd.pPIN = Convert.ToInt32(txtppin.Text == "" ? "0" : txtppin.Text);
                objstd.AddedBy = LoginToken.LoginId;
                objstd.UserId = LoginToken.UserLoginId;
                objstd.CompanyID = LoginToken.CompanyID;
                objstd.AcademicSessionID = LoginToken.AcademicSessionID;
                objstd.IsActive = true;
                objstd.IsNew = Convert.ToInt32(ddlamdission.SelectedValue == "" ? "0" : ddlamdission.SelectedValue);
                objstd.HouseID = Convert.ToInt32(ddlhouse.SelectedValue == "" ? "0" : ddlhouse.SelectedValue);
                //DateTime AdmissionDate = txtadmissioDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtadmissioDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                //objstd.AdmissionDate = AdmissionDate;
                objstd.IDmarks = txtIDmarks.Text.Trim() == "" ? null : txtIDmarks.Text.Trim();
                objstd.Allerrgic = txtallegry.Text.Trim() == "" ? null : txtallegry.Text.Trim();
                objstd.Isessioninitialheight = Convert.ToInt64(txtfisrtSessionheight.Text == "" ? "0" : txtfisrtSessionheight.Text);
                objstd.Isessioninitialweight = Convert.ToInt64(txtIstsessioninitialwt.Text == "" ? "0" : txtIstsessioninitialwt.Text);
                objstd.Income = Convert.ToDecimal(txtincome.Text == "" ? "0.00" : txtincome.Text);
                //if (objstd.IsNew == 2)
                //{
                //    if (objstd.AdmissionNo == "" || objstd.AdmissionNo == "0")
                //    {
                //        txtadmissionNo.Focus();
                //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("checkadmission") + "')", true);
                //        return;
                //    }
                //}
                //else
                //{
                //    objstd.AdmissionNo = txtadmissionNo.Text.Trim();
                //}
                if (ViewState["ID"] == null)
                {
                    objstd.ActionType = EnumActionType.Insert;
                    int results = objstdBO.UpdateStudentDetails(objstd);
                    if (results > 5)
                    {
                        //txtadmissionNo.Text = results.ToString();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                        clearall();
                        btnsave.Text = "Add";
                    }
                    if (results == 4)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("checkduplicateadmissionno") + "')", true);
                    }
                    if (results == 5)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("checkduplicatestudent") + "')", true);
                    }
                }
                if (ViewState["ID"] != null)
                {
                    if (ViewState["ID"] != null && ViewState["AdmissionID"] != null)
                    {
                        objstd.ActionType = EnumActionType.Update;
                        //objstd.AdmissionNo = txtadmissionNo.Text;
                        objstd.AdmissionID = Convert.ToInt64(ViewState["AdmissionID"].ToString());

                        if (ViewState["StudentCategory"].ToString() != ddlstudenycategory.SelectedValue)
                        {
                            objstd.Istransfer = true;
                        }
                        else
                        {
                            objstd.Istransfer = true;
                        }
                        ViewState["ID"] = null;
                        ViewState["AdmissionID"] = null;
                        ViewState["StudentCategory"] = null;

                    }
                    else
                    {
                        if (fileName == null || fileName == "")
                        {
                            objstd.StudentPhoto = ViewState["photo"].ToString();
                            ViewState["photo"] = null;

                        }
                        objstd.ActionType = EnumActionType.Insert;
                        //objstd.AdmissionNo = txtadmissionNo.Text.Trim();
                    }
                    int result = objstdBO.UpdateAdmissionDetails(objstd);
                    if (result == 2)
                    {
                        clearall();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                        btnsave.Text = "Add";
                    }
                    if (result == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Promotedclass") + "')", true);
                    }
                    if (result == 4)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("checkadmissionno") + "')", true);
                    }
                    if (result == 5)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("checkdoubleadmissionno") + "')", true);
                    }

                }
                //this.ddlamdission.Focus();
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected string getDigitalPath(string fileName)
        {
            string path = "";
            // fileName = txtempname.Text.Trim() + "_" + fileName;
            try
            {
                if (Directory.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/") == false)
                    Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduStudentPhoto/");

                if (File.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName))
                {
                    File.Delete(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                    // return "exist";
                }
                studentphotouploader.SaveAs(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                path = @"EduStudentPhoto/" + fileName;
            }
            catch
            {
                return "fail";
            }
            return path;
        }
        //protected void txtstudentanme_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtstudentanme.Text.Trim() != "")
        //    {
        //        bindgrid(1);

        //    }
        //    else
        //    {
        //        txtstudentanme.Text = "";
        //        bindgrid(1);

        //    }
        //}

        protected void clearall()
        {
            //txtadmissionNo.Text = "";
            ddlhouse.SelectedIndex = 0;
            ddlamdission.SelectedIndex = 0;
            txtIDmarks.Text = "";
            //txtadmissioDate.Text = "";
            txtfisrtSessionheight.Text = "";
            txtIstsessioninitialwt.Text = "";
            txtincome.Text = "";
            txtallegry.Text = "";
            ddlstudenttype.SelectedIndex = 0;
            ddlCast.SelectedIndex = 0;
            ddlreligion.SelectedIndex = 0;
            //txtstudentanme.Text = "";
            txtmothername.Text = "";
            txtfathername.Text = "";
            txtfatheroccupation.Text = "";
            txtmotheroccupation.Text = "";
            ddlbloodgroup.SelectedIndex = 0;
            ddlrelationship.SelectedIndex = 0;
            ddlclass.SelectedIndex = 0;
            txtstudentname.Text = "";
            //chksame.Checked = false;
            txtaccountno.Text = "";
            txtbankname.Text = "";
            //txtemail.Text = "";
            txtifsc.Text = "";
            ddlsection.SelectedIndex = 0;
            //ddlDistrict.SelectedIndex = 0;
            //ddlpcountry.SelectedIndex = 0;
            //ddlpstate.SelectedIndex = 0;
            //ddlpdistrict.SelectedIndex = 0;
            txtDOB.Text = "";
            txtgmobile.Text = "";
            txtaddress.Text = "";
            //txtpin.Text = "";
            //txtlandmark.Text = "";
            txtpaddress.Text = "";
            //txtppin.Text = "";
            //txtplandmarks.Text = "";
            //txtadmissionNo.Text = "";
            lblmessage.Visible = false;
            //chksame.Checked = false;
            //txtadmissionNo.Enabled = true;
            txtlastschoolName.Text = "";
            txtlastclass.Text = "";
            txtlastsection.Text = "";
            txtlastroll.Text = "";
            txtlastroll.Text = "";
            ddlstudenycategory.SelectedIndex = 0;
            txtlatsmarks.Text = "";
            ddlsex.SelectedIndex = 0;
            txtaadhar.Text = "";
            txtregdno.Text = "";
            btnsave.Text = "Save";
            txtBirthRegNo.Text = "";
            //Commonfunction.Insertzeroitemindex(ddlsections);
            btnsave.Text = "Add";
        }
        //public List<StudentData> GetEditstudentdetails(Int64 StudentID, int curIndex)
        //{
        //    StudentData objstd = new StudentData();
        //    AddstudentBO objstdBO = new AddstudentBO();
        //    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
        //    //DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        //    //DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

        //    objstd.StudentID = StudentID;
        //    objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
        //    objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
        //    objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
        //    objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
        //    objstd.IsActiveALL = ddlstatus.SelectedValue;
        //    objstd.Datefrom = from;
        //    objstd.Dateto = To;
        //    objstd.StudentCategory = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
        //    objstd.ActionType = EnumActionType.Select;
        //    objstd.PageSize = GvstudentDetails.PageSize;
        //    objstd.CurrentIndex = curIndex;
        //    return objstdBO.SearchStudentDetails(objstd);
        //}
        //public List<StudentData> Getstudentdetails(int curIndex, int pagesize)
        //{
        //    StudentData objstd = new StudentData();
        //    AddstudentBO objstdBO = new AddstudentBO(); IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
        //    DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        //    DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        //   // objstd.StudentID = Commonfunction.SemicolonSeparation_String_64(txtstudentanme.Text);
        //    objstd.Sfirstname = Convert.ToString(txtstudentanme.Text == "" ? "0" : txtstudentanme.Text);
        //    objstd.Datefrom = from;
        //    objstd.Dateto = To;
        //    objstd.IsAdmissionDone = Convert.ToInt32(ddl_admissionstatus.SelectedValue == "" ? "5" : ddl_admissionstatus.SelectedValue);
        //    objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
        //    objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
        //    objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
        //    objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
        //    objstd.CastID = Convert.ToInt32(ddlcastes.SelectedValue == "" ? "0" : ddlcastes.SelectedValue);
        //    objstd.UserId = Convert.ToInt32(ddluser.SelectedValue == "" ? "0" : ddluser.SelectedValue);
        //    objstd.HouseID = Convert.ToInt32(ddlhouselist.SelectedValue == "" ? "0" : ddlhouselist.SelectedValue);
        //    objstd.StudentTypeID = Convert.ToInt32(ddllstudentypes.SelectedValue == "" ? "0" : ddllstudentypes.SelectedValue);
        //    if (ddladmissiontype.SelectedIndex == 0)
        //    {
        //        objstd.IsNewall = 0;
        //    }
        //    else if (ddladmissiontype.SelectedValue == "1")
        //    {
        //        objstd.IsNewall = 1;
        //    }
        //    else if (ddladmissiontype.SelectedValue == "2")
        //    {
        //        objstd.IsNewall = 2;
        //    }
        //    objstd.StudentCategory = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
        //    objstd.IsActiveALL = ddlstatus.SelectedValue;

        //    objstd.ActionType = EnumActionType.Select;
        //    objstd.PageSize = pagesize;
        //    objstd.CurrentIndex = curIndex;
        //    return objstdBO.GetStudentList(objstd);
        //}
        //public List<StudentData> Getstudentdetailstoexcel(int curIndex)
        //{
        //    StudentData objstd = new StudentData();
        //    AddstudentBO objstdBO = new AddstudentBO(); IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
        //    DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        //    DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        //    objstd.StudentID = Commonfunction.SemicolonSeparation_String_64(txtstudentanme.Text);
        //    objstd.Datefrom = from;
        //    objstd.Dateto = To;
        //    objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
        //    objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
        //    objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
        //    objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
        //    objstd.CastID = Convert.ToInt32(ddlcastes.SelectedValue == "" ? "0" : ddlcastes.SelectedValue);
        //    objstd.UserId = Convert.ToInt32(ddluser.SelectedValue == "" ? "0" : ddluser.SelectedValue);
        //    objstd.HouseID = Convert.ToInt32(ddlhouselist.SelectedValue == "" ? "0" : ddlhouselist.SelectedValue);
        //    objstd.StudentTypeID = Convert.ToInt32(ddllstudentypes.SelectedValue == "" ? "0" : ddllstudentypes.SelectedValue);
        //    if (ddladmissiontype.SelectedIndex == 0)
        //    {
        //        objstd.IsNewall = 0;
        //    }
        //    else if (ddladmissiontype.SelectedValue == "1")
        //    {
        //        objstd.IsNewall = 1;
        //    }
        //    else if (ddladmissiontype.SelectedValue == "2")
        //    {
        //        objstd.IsNewall = 2;
        //    }
        //    objstd.StudentCategory = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
        //    objstd.IsActiveALL = ddlstatus.SelectedValue;

        //    objstd.ActionType = EnumActionType.Select;
        //    objstd.PageSize = GvstudentDetails.PageSize;
        //    objstd.CurrentIndex = curIndex;
        //    return objstdBO.GetStudentListoexcel(objstd);
        //}
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            StudentData objSTD = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
        }
        //protected void editstudents(Int64 studenID, int currenetIndex)
        //{
        //    List<StudentData> studentdetails = GetEditstudentdetails(studenID, currenetIndex);
        //    if (studentdetails.Count > 0)
        //    {
        //        ddlstudenttype.SelectedValue = studentdetails[0].StudentTypeID.ToString();
        //        ddlCast.SelectedValue = studentdetails[0].CastID.ToString();
        //        ddlreligion.SelectedValue = studentdetails[0].ReligionID.ToString();
        //        txtfatheroccupation.Text = studentdetails[0].Goccupation.ToString();
        //        txtmotheroccupation.Text = studentdetails[0].MotherOccupation.ToString();
        //        ddlrelationship.SelectedValue = studentdetails[0].GrelationshipID.ToString();
        //        ddlclass.SelectedValue = studentdetails[0].ClassID.ToString();
        //        MasterLookupBO objmstlookupBO = new MasterLookupBO();
        //        Commonfunction.PopulateDdl(ddlsection, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(studentdetails[0].ClassID.ToString())));
        //        ddlsection.SelectedValue = studentdetails[0].SectionID.ToString();
        //        txtrollno.Text = studentdetails[0].RollNo.ToString();
        //        txtregdno.Text = studentdetails[0].RegdNo.ToString();
        //        //ddlcountry.SelectedValue = studentdetails[0].cCountryID.ToString();
        //        //ddlstate.SelectedValue = studentdetails[0].cStateID.ToString();
        //        //ddlDistrict.SelectedValue = studentdetails[0].cDistrictID.ToString();
        //        //ddlpcountry.SelectedValue = studentdetails[0].pCountryID.ToString();
        //        //ddlpstate.SelectedValue = studentdetails[0].pStateID.ToString();
        //        //ddlpdistrict.SelectedValue = studentdetails[0].pDistrictID.ToString();
        //        //studentdetails[0].DOB.ToString("dd/mm/yyyy");
        //        txtDOB.Text = studentdetails[0].DOB.ToString("dd/MM/yyyy");
        //        txtMotherTongue.Text = studentdetails[0].MotherTongue;
        //        txtBirthRegNo.Text = studentdetails[0].BirthRegNo;
        //        ddlBelongToBPL.SelectedValue = studentdetails[0].BelogToBPLoptionID.ToString();
        //        txtstudentname.Text = studentdetails[0].Sfirstname.ToString();
        //        txtfathername.Text = studentdetails[0].Gfirstname;
        //        txtmothername.Text = studentdetails[0].Mothername;
        //        txtgmobile.Text = studentdetails[0].GmobileNo;
        //        txtaddress.Text = studentdetails[0].cAddress;
        //        ddlbloodgroup.SelectedValue = studentdetails[0].BloogroupID.ToString();
        //        //txtpin.Text = studentdetails[0].cPIN.ToString();
        //        txtAdmNo.Text = studentdetails[0].EnrollmentNo.ToString();
        //        //txtlandmark.Text = studentdetails[0].cLandMark;
        //        txtpaddress.Text = studentdetails[0].pAddress;
        //        //txtppin.Text = studentdetails[0].pPIN.ToString();
        //        txtaadhar.Text = studentdetails[0].Aadhar.ToString();
        //        //txtplandmarks.Text = studentdetails[0].pLandMark;
        //        ViewState["ID"] = studentdetails[0].StudentID; ;
        //        Session["ID"] = studentdetails[0].StudentID;
        //        Session["AdmissionID"] = studentdetails[0].AdmissionID;
        //        ViewState["AdmissionID"] = studentdetails[0].AdmissionID;
        //        ViewState["Photopath"] = studentdetails[0].StudentPhoto;
        //        ViewState["StudentCategory"] = studentdetails[0].StudentCategory;
        //        ddlhouse.SelectedValue = studentdetails[0].HouseID.ToString();
        //        txtIDmarks.Text = studentdetails[0].IDmarks.ToString();
        //        //txtadmissioDate.Text = studentdetails[0].AdmissionDate.ToString("dd/MM/yyyy");
        //        txtallegry.Text = studentdetails[0].Allerrgic.ToString();
        //        txtfisrtSessionheight.Text = studentdetails[0].Isessioninitialheight.ToString();
        //        txtIstsessioninitialwt.Text = studentdetails[0].Isessioninitialweight.ToString();
        //        //txtadmissionNo.Text = studentdetails[0].AdmissionNo.ToString();
        //        //txtadmissionNo.Attributes["disabled"] = "disabled";
        //        txtincome.Text = Commonfunction.Getrounding(studentdetails[0].Income.ToString());
        //        ddlamdission.SelectedValue = studentdetails[0].IsNew.ToString();
        //        ddlstudenycategory.SelectedValue = studentdetails[0].StudentCategory.ToString();
        //        txtlastschoolName.Text = studentdetails[0].LastSchoolName.ToString();
        //        txtlastclass.Text = studentdetails[0].LastClass.ToString();
        //        txtlastsection.Text = studentdetails[0].LastSection.ToString();
        //        txtlastroll.Text = studentdetails[0].LastRollno.ToString();
        //        txtlatsmarks.Text = studentdetails[0].LastMark.ToString();
        //        ddlsex.SelectedValue = studentdetails[0].SexID.ToString();
        //        //txtemail.Text = studentdetails[0].EmaildID.ToString();
        //        txtifsc.Text = studentdetails[0].IFSC.ToString();
        //        txtbankname.Text = studentdetails[0].BankName.ToString();
        //        txtattendance.Text = studentdetails[0].LastAttendance.ToString();
        //        txtlastroll.Text = studentdetails[0].LastRollno.ToString();
        //        txtaccountno.Text = studentdetails[0].AC.ToString();
        //        txtlatsmarks.Text = studentdetails[0].LastMark.ToString();
        //        btnsave.Text = "Update";
        //    }
        //    else
        //    {
        //        clearall();
        //    }
        //}
        //protected void btnactivate_Click(object sender, EventArgs e)
        //{
        //    List<StudentData> lststudentlist = new List<StudentData>();
        //    StudentData objstd = new StudentData();
        //    AddstudentBO objstdBO = new AddstudentBO();
        //    //int index = 0;
        //    //int count = 0;
        //    try
        //    {                // get all the record from the gridview
        //        foreach (GridViewRow row in GvstudentDetails.Rows)
        //        {
        //            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
        //            Label StudentID = (Label)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
        //            //CheckBox chk = (CheckBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("chekboxselect");
        //            StudentData ObjDetails = new StudentData();
        //            //if (chk.Checked)
        //            //{
        //                ObjDetails.StudentID = Convert.ToInt64(StudentID.Text);
        //                //count = count + 1;
        //                ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
        //                lststudentlist.Add(ObjDetails);
        //                //index++;
        //            //}
        //        }
        //        objstd.XmlStudentlist = XmlConvertor.ActivatedlisttoXML(lststudentlist).ToString();
        //        //if (count == 0)
        //        //{
        //            Messagealert_.ShowMessage(lblresult, "Please select atleast one student", 0);
        //            //return;
        //        //}
        //        int results = objstdBO.AcitvateStudent(objstd);
        //        if (results == 1)
        //        {
        //            bindgrid(1);
        //            Messagealert_.ShowMessage(lblresult, "Successfully activated", 1);
        //        }
        //        else
        //        {
        //            Messagealert_.ShowMessage(lblresult, "Error", 0);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        //lblresult.Text = ExceptionMessage.GetMessage(ex);
        //        //lblresult.Visible = true;
        //        //lblresult.CssClass = "Message";
        //    }
        //}
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            //int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            //List<StudentData> studentdetails = Getstudentdetails(index, pagesize);
            //if (studentdetails.Count > 0)
            //{
            //    //Check.Visible = true;
            //    //GvstudentDetails.Visible = true;
            //    //GvstudentDetails.PageSize = pagesize;
            //    string record = studentdetails[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
            //    //lblresult.Text = "Total : " + studentdetails[0].MaximumRows.ToString() + " " + record;
            //    //lbl_totalrecords.Text = studentdetails[0].MaximumRows.ToString();
            //    //lblresult.Visible = true;
            //    //GvstudentDetails.VirtualItemCount = studentdetails[0].MaximumRows;//total item is required for custom paging
            //    //GvstudentDetails.PageIndex = index - 1;
            //    //GvstudentDetails.DataSource = studentdetails;
            //    //GvstudentDetails.DataBind();
            //    //bindresponsive();
            //    ds = ConvertToDataSet(studentdetails);
            //    //divsearch.Visible = true;
            //    //GvstudentDetails.Columns[7].Visible = true;

            //}
            //else
            //{
            //    //GvstudentDetails.DataSource = null;
            //    //GvstudentDetails.DataBind();
            //    //GvstudentDetails.Visible = true;
            //    //lblresult.Visible = false;
            //    //divsearch.Visible = true;
            //    //GvstudentDetails.Columns[7].Visible = false;
            //}
        }
        protected void bindresponsive()
        {
            //Responsive 
            //GvstudentDetails.HeaderRow.Cells[0].Attributes["data-hide"] = "expand";
            //// GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            ////  Adds THEAD and TBODY to GridView.
            //GvstudentDetails.UseAccessibleHeader = true;
            //GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            //TableCell tableCell = GvstudentDetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            //tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            //tableCell.Controls.Add(img);
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

        protected void GvstudentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GvstudentDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));

        }
        //protected void ExportoExcel()
        //{
        //    DataTable dt = GetDatafromDatabase();
        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        wb.Worksheets.Add(dt, "Student List");
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        //Response.AddHeader("content-disposition", "attachment;filename= Class :" + (ddlclasses.SelectedIndex == 0 ? "All" : ddlclasses.SelectedItem.Text) + " Section : " + (ddlsections.SelectedIndex == 0 ? "" : ddlsections.SelectedItem.Text) + ".xlsx");
        //        using (MemoryStream MyMemoryStream = new MemoryStream())
        //        {
        //            wb.SaveAs(MyMemoryStream);
        //            MyMemoryStream.WriteTo(Response.OutputStream);
        //            Response.Flush();
        //            Response.End();
        //        }
        //    }
        //}
        //protected DataTable GetDatafromDatabase()
        //{
        //    List<StudentData> studentdetails = Getstudentdetailstoexcel(0);
        //    List<ExcelStudentList> listecelstd = new List<ExcelStudentList>();
        //    int i = 0;
        //    foreach (StudentData row in studentdetails)
        //    {
        //        ExcelStudentList EcxeclStd = new ExcelStudentList();
        //        EcxeclStd.StudentID = studentdetails[i].StudentID;
        //        EcxeclStd.StudentName = studentdetails[i].StudentName;
        //        EcxeclStd.ClassName = studentdetails[i].ClassName;
        //        EcxeclStd.SectionName = studentdetails[i].SectionName;
        //        EcxeclStd.RollNo = studentdetails[i].RollNo;
        //        EcxeclStd.House = studentdetails[i].House;
        //        EcxeclStd.AdmissionType = studentdetails[i].AdmissionType;
        //        EcxeclStd.FatherNameORGuardianName = studentdetails[i].Gfirstname;
        //        EcxeclStd.FatherORGuardianOccupation = studentdetails[i].Goccupation;
        //        EcxeclStd.RelationshipWithGuardian = studentdetails[i].Grelationship;
        //        EcxeclStd.Mothername = studentdetails[i].Mothername;
        //        EcxeclStd.MothersOccupation = studentdetails[i].MotherOccupation;
        //        EcxeclStd.ParentsIncome = studentdetails[i].Income;
        //        EcxeclStd.DOB = studentdetails[i].ExcelDOB;
        //        EcxeclStd.BirthRegNo = studentdetails[i].BirthRegNo;
        //        EcxeclStd.Gender = studentdetails[i].SexName;
        //        EcxeclStd.Religion = studentdetails[i].Religion;
        //        EcxeclStd.Caste = studentdetails[i].CastName;
        //        EcxeclStd.MotherTongue = studentdetails[i].MotherTongue;
        //        EcxeclStd.BelongToBPL = studentdetails[i].BelongToBPLoptionName;
        //        EcxeclStd.Address = studentdetails[i].pAddress;
        //        EcxeclStd.District = studentdetails[i].pDistrict;
        //        EcxeclStd.PIN = studentdetails[i].pPIN;
        //        EcxeclStd.ContactNo = studentdetails[i].GmobileNo;
        //        EcxeclStd.AadharNo = studentdetails[i].Aadhar;
        //        EcxeclStd.BankName = studentdetails[i].BankName;
        //        EcxeclStd.AccountNo = studentdetails[i].AC;
        //        EcxeclStd.IFSC = studentdetails[i].IFSC;
        //        EcxeclStd.EmailID = studentdetails[i].EmailID;
        //        EcxeclStd.AdmissionDate = studentdetails[i].ExcelAD;
        //        listecelstd.Add(EcxeclStd);
        //        i++;
        //    }
        //    ListtoDataTableConverter converter = new ListtoDataTableConverter();
        //    DataTable dt = converter.ToDataTable(listecelstd);
        //    return dt;

        //}
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlstudenycategory.SelectedIndex = 0;
            txtlastschoolName.Text = "";
            txtlastclass.Text = "";
            txtlastsection.Text = "";
            txtlastroll.Text = "";
            txtlatsmarks.Text = "";
            clearall();
            //ddlhouselist.SelectedIndex = 0;
        }
        private void resetall()
        {
            //txtstudentanme.Text = "";
            //ddlacademicseesions.SelectedIndex = 0;
            //ddlclasses.SelectedIndex = 0;
            //ddlsections.ClearSelection();
            //GvstudentDetails.DataSource = null;
            //GvstudentDetails.DataBind();
            //GvstudentDetails.Visible = false;
            //lblresult.Visible = false;
            ViewState["Photopath"] = null;
            ViewState["ID"] = null;
            ViewState["AdmissionID"] = null;
            //ddlacademicseesions.SelectedIndex = 1;
            //txtfrom.Text = "";
            //txtto.Text = "";
            //ddlcategorys.SelectedIndex = 0;
            //ddlhouselist.SelectedIndex = 0;
            txtrollno.Text = "";
            //ddllstudentypes.SelectedIndex = 0;
            //txtadmissionNo.Enabled = true;
            //divsearch.Visible = false;
            Commonfunction.Insertzeroitemindex(ddlsection);
        }
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsection, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclass.SelectedValue)));
        }
        protected void ddlamdission_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlamdission.SelectedValue == "1")
            {
                //txtadmissionNo.Attributes["disabled"] = "disabled";
            }
            else
            {
                //txtadmissionNo.Attributes["disabled"] = "disabled";
            }
            //txtadmissionNo.Text = "";
        }
        //protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    MasterLookupBO objmstlookupBO = new MasterLookupBO();
        //    Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        //    //bindresponsive();
        //    //bindgrid(1, 10);
        //}
        //protected void bindddlss(int classID)
        //{
        //    MasterLookupBO objmstlookupBO = new MasterLookupBO();
        //    Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
        //}
        //protected void GvstudentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "Edits")
        //        {
        //            int i = Convert.ToInt16(e.CommandArgument.ToString());
        //            GridViewRow gr = GvstudentDetails.Rows[i];
        //            Label ID = (Label)gr.Cells[0].FindControl("lblID");
        //            Int64 StudentID = Convert.ToInt64(ID.Text);
        //            editstudents(StudentID, 0);
        //            Response.Redirect("AddStudent.aspx", false);
        //            btnsave.Text = "Update";
        //        }
        //        if (e.CommandName == "Deletes")
        //        {
        //            StudentData objstd = new StudentData();
        //            AddstudentBO objstdBO = new AddstudentBO();
        //            int i = Convert.ToInt16(e.CommandArgument.ToString());
        //            GridViewRow gr = GvstudentDetails.Rows[i];
        //            Label ID = (Label)gr.Cells[0].FindControl("lblID");
        //            TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
        //            if (txtremarks.Text == "")
        //            {
        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
        //                bindresponsive();
        //                txtremarks.Focus();
        //                return;
        //            }
        //            else
        //            {
        //                objstd.Remarks = txtremarks.Text;
        //            }
        //            objstd.StudentID = Convert.ToInt64(ID.Text);
        //            objstd.AcademicSessionID = LoginToken.AcademicSessionID;
        //            objstd.ActionType = EnumActionType.Delete;
        //            objstd.UserId = LoginToken.UserLoginId;
        //            int Result = objstdBO.DeleteStudentDetailsByID(objstd);
        //            if (Result == 1)
        //            {
        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
        //                bindgrid(1);
        //            }
        //            else
        //            {
        //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
        //            }
        //            bindresponsive();

        //        }
        //        if (e.CommandName == "View")
        //        {
        //            StudentData objstd = new StudentData();
        //            AddstudentBO objstdBO = new AddstudentBO();

        //            int i = Convert.ToInt16(e.CommandArgument.ToString());
        //            GridViewRow gr = GvstudentDetails.Rows[i];
        //            Label ID = (Label)gr.Cells[0].FindControl("lblID");
        //            Label AdmissionID = (Label)gr.Cells[0].FindControl("lbladID");
        //            Label SessionID = (Label)gr.Cells[0].FindControl("lblsessionID");
        //            Session["StatusID"] = Convert.ToInt32(ddlstatus.SelectedValue);
        //            Session["StudentID"] = ID.Text;
        //            Session["AdmissionID"] = AdmissionID.Text;
        //            Session["SessionID"] = SessionID.Text;
        //            Response.Redirect("~/StdProfile.aspx", false);
        //        }
        //        if (e.CommandName == "activate")
        //        {
        //            int i = Convert.ToInt16(e.CommandArgument.ToString());
        //            GridViewRow gr = GvstudentDetails.Rows[i];
        //            Label ID = (Label)gr.Cells[0].FindControl("lblID");
        //            Int64 StudentID = Convert.ToInt64(ID.Text);
        //            editstudentsActivated(StudentID, 0);
        //        }         
        //    }
        //    catch (Exception ex) //Exception in agent layer itself
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
        //        return;
        //    }
        //}
        protected void editstudentsActivated(Int64 studenID, int currenetIndex)
        {
            List<StudentData> studentdetails = GetActivatedstudentdetails(studenID, currenetIndex);
            bindgrid(1);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Successfully activated") + "')", true);

        }
        public List<StudentData> GetActivatedstudentdetails(Int64 StudentID, int curIndex)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = StudentID;
            //objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            return objstdBO.ActivatedStudentDetails(objstd);
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            bindgrid(1);
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
        //protected void GvstudentDetails_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    try
        //    {
        //        String ColumnName = e.SortExpression;
        //        int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
        //        bindgrid(1);
        //        DataTable dt = new DataTable();

        //        dt = ds.Tables[0];

        //        {

        //            string SortDir = string.Empty;

        //            if (dir == SortDirection.Ascending)

        //            {

        //                dir = SortDirection.Descending;

        //                SortDir = "Desc";

        //            }

        //            else

        //            {

        //                dir = SortDirection.Ascending;

        //                SortDir = "Asc";

        //            }
        //            DataView sortedView = new DataView(dt);
        //            sortedView.Sort = e.SortExpression + " " + SortDir;
        //            GvstudentDetails.DataSource = sortedView;
        //            GvstudentDetails.DataBind();

        //            TableCell tableCell = GvstudentDetails.HeaderRow.Cells[ColumnIndex];
        //            Image img = new Image();
        //            img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
        //            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
        //            tableCell.Controls.Add(img);

        //            GvstudentDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
        //            GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
        //            GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
        //            GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
        //            GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
        //            GvstudentDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
        //            GvstudentDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
        //            // Adds THEAD and TBODY to GridView.
        //            GvstudentDetails.UseAccessibleHeader = true;
        //            GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

        //        }
        //    }
        //    catch (Exception ex) //Exception in agent layer itself
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        lblmessage.Text = ExceptionMessage.GetMessage(ex);
        //        lblmessage.Visible = true;
        //        lblmessage.CssClass = "Message";
        //    }
        //}
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
        protected void ddlacademicseesions_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddladmissiontype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlcategorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddllstudentypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlsections_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlsexs_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlcastes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlhouselist_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txtfrom_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddluser_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        //protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow row in GvstudentDetails.Rows)
        //    {
        //        TextBox Remark = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("txtremarks");


        //        if (ddlstatus.SelectedItem.Value == "1")
        //        {                   
        //            GvstudentDetails.Columns[7].Visible = true;
        //        }
        //        else
        //        {               
        //            GvstudentDetails.Columns[7].Visible = false;
        //        }
        //    }
        //    bindgrid(1);
        //}
        //protected void btn_export_Click(object sender, EventArgs e)
        //{
        //    ExportoExcel();
        //}

        protected void btnminimizetap1_Click(object sender, EventArgs e)
        {
            Tap1.Visible = false;
            btnmaximizetap1.Visible = true;
            btnminimizetap1.Visible = false;
        }

        protected void btnmaximizetap1_Click(object sender, EventArgs e)
        {
            Tap1.Visible = true;
            btnmaximizetap1.Visible = false;
            btnminimizetap1.Visible = true;
        }

        protected void btnminimizetap2_Click(object sender, EventArgs e)
        {
            Tap2.Visible = false;
            btnmaximizetap2.Visible = true;
            btnminimizetap2.Visible = false;
        }

        protected void btnmaximizetap2_Click(object sender, EventArgs e)
        {
            Tap2.Visible = true;
            btnmaximizetap2.Visible = false;
            btnminimizetap2.Visible = true;
        }

        protected void btnminimizetap3_Click(object sender, EventArgs e)
        {
            Tap3.Visible = false;
            btnmaximizetap3.Visible = true;
            btnminimizetap3.Visible = false;
        }

        protected void btnmaximizetap3_Click(object sender, EventArgs e)
        {
            Tap3.Visible = true;
            btnmaximizetap3.Visible = false;
            btnminimizetap3.Visible = true;
        }

        protected void btnminimizetap4_Click(object sender, EventArgs e)
        {
            Tap4.Visible = false;
            btnmaximizetap4.Visible = true;
            btnminimizetap4.Visible = false;
        }

        protected void btnmaximizetap4_Click(object sender, EventArgs e)
        {
            Tap4.Visible = true;
            btnmaximizetap4.Visible = false;
            btnminimizetap4.Visible = true;
        }

        protected void btnminimizetap5_Click(object sender, EventArgs e)
        {
            Tap5.Visible = false;
            btnmaximizetap5.Visible = true;
            btnminimizetap5.Visible = false;
        }

        protected void btnmaximizetap5_Click(object sender, EventArgs e)
        {
            Tap5.Visible = true;
            btnmaximizetap5.Visible = false;
            btnminimizetap5.Visible = true;
        }

        protected void btnminimizetap6_Click(object sender, EventArgs e)
        {
            Tap6.Visible = false;
            btnmaximizetap6.Visible = true;
            btnminimizetap6.Visible = false;
        }

        protected void btnmaximizetap6_Click(object sender, EventArgs e)
        {
            Tap6.Visible = true;
            btnmaximizetap6.Visible = false;
            btnminimizetap6.Visible = true;
        }

        protected void btnminimizetap7_Click(object sender, EventArgs e)
        {
            Tap7.Visible = false;
            btnmaximizetap7.Visible = true;
            btnminimizetap7.Visible = false;
        }

        protected void btnmaximizetap7_Click(object sender, EventArgs e)
        {
            Tap7.Visible = true;
            btnmaximizetap7.Visible = false;
            btnminimizetap7.Visible = true;
        }

        protected void btnminimizetap8_Click(object sender, EventArgs e)
        {
            Tap8.Visible = false;
            btnmaximizetap8.Visible = true;
            btnminimizetap8.Visible = false;
        }

        protected void btnmaximizetap8_Click(object sender, EventArgs e)
        {
            Tap8.Visible = true;
            btnmaximizetap8.Visible = false;
            btnminimizetap8.Visible = true;
        }

        protected void btnminimizetap9_Click(object sender, EventArgs e)
        {
            Tap9.Visible = false;
            btnmaximizetap9.Visible = true;
            btnminimizetap9.Visible = false;
        }

        protected void btnmaximizetap9_Click(object sender, EventArgs e)
        {
            Tap9.Visible = true;
            btnmaximizetap9.Visible = false;
            btnminimizetap9.Visible = true;
        }

        protected void btnTap2minimize1_Click(object sender, EventArgs e)
        {
            Tap21.Visible = false;
            btnTap2maximize1.Visible = true;
            btnTap2minimize1.Visible = false;
        }

        protected void btnTap2maximize1_Click(object sender, EventArgs e)
        {
            Tap21.Visible = true;
            btnTap2maximize1.Visible = false;
            btnTap2minimize1.Visible = true;
        }

        protected void btnTap2minimize2_Click(object sender, EventArgs e)
        {
            Tap22.Visible = false;
            btnTap2maximize2.Visible = true;
            btnTap2minimize2.Visible = false;
        }

        protected void btnTap2maximize2_Click(object sender, EventArgs e)
        {
            Tap22.Visible = true;
            btnTap2maximize2.Visible = false;
            btnTap2minimize2.Visible = true;
        }

        protected void btnTap2minimize3_Click(object sender, EventArgs e)
        {
            Tap24.Visible = false;
            btnTap2maximize3.Visible = true;
            btnTap2minimize3.Visible = false;
        }

        protected void btnTap2maximize3_Click(object sender, EventArgs e)
        {
            Tap24.Visible = true;
            btnTap2maximize3.Visible = false;
            btnTap2minimize3.Visible = true;
        }

        protected void btnTap2minimize4_Click(object sender, EventArgs e)
        {
            Tap25.Visible = false;
            btnTap2maximize4.Visible = true;
            btnTap2minimize4.Visible = false;
        }

        protected void btnTap2maximize4_Click(object sender, EventArgs e)
        {
            Tap25.Visible = true;
            btnTap2maximize4.Visible = false;
            btnTap2minimize4.Visible = true;
        }

        protected void btnTap2minimize5_Click(object sender, EventArgs e)
        {
            Tap26.Visible = false;
            btnTap2maximize5.Visible = true;
            btnTap2minimize5.Visible = false;
        }

        protected void btnTap2maximize5_Click(object sender, EventArgs e)
        {
            Tap26.Visible = true;
            btnTap2maximize5.Visible = false;
            btnTap2minimize5.Visible = true;
        }

        protected void btnTap2minimize6_Click(object sender, EventArgs e)
        {
            Tap27.Visible = false;
            btnTap2maximize6.Visible = true;
            btnTap2minimize6.Visible = false;
        }

        protected void btnTap2maximize6_Click(object sender, EventArgs e)
        {
            Tap27.Visible = true;
            btnTap2maximize6.Visible = false;
            btnTap2minimize6.Visible = true;
        }

        protected void btnTap2minimize7_Click(object sender, EventArgs e)
        {
            Tap23.Visible = false;
            btnTap2maximize7.Visible = true;
            btnTap2minimize7.Visible = false;
        }

        protected void btnTap2maximize7_Click(object sender, EventArgs e)
        {
            Tap23.Visible = true;
            btnTap2maximize7.Visible = false;
            btnTap2minimize7.Visible = true;
        }

        protected void btntap1edit_Click(object sender, EventArgs e)
        {
            btntap1edit.Visible = false;
            btntap1save.Visible = true;
            btntap1cancel.Visible = true;
            //txtAdmNo.Attributes.Remove("disabled");
            ddlamdission.Attributes.Remove("disabled");
            txtDOB.Attributes.Remove("disabled");
            txtstudentname.Attributes.Remove("disabled");
            txtBirthRegNo.Attributes.Remove("disabled");
            ddlstudenttype.Attributes.Remove("disabled");
            ddlCast.Attributes.Remove("disabled");
            ddlsex.Attributes.Remove("disabled");
            ddlreligion.Attributes.Remove("disabled");
            txtMotherTongue.Attributes.Remove("disabled");
            ddlBelongToBPL.Attributes.Remove("disabled");
            ddlstudenycategory.Attributes.Remove("disabled");
            ddlhouse.Attributes.Remove("disabled");
            txtIDmarks.Attributes.Remove("disabled");
            
        }

        protected void btntap1save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.IsNewall = Convert.ToInt32(ddlamdission.SelectedValue == "" ? "0" : ddlamdission.SelectedValue);
                objstd.Sfirstname = txtstudentname.Text.Trim();
                DateTime DOB = txtDOB.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDOB.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objstd.DOB = DOB;
                objstd.BirthRegNo = txtBirthRegNo.Text.Trim();
                objstd.StudentTypeID = Convert.ToInt32(ddlstudenttype.SelectedValue == "" ? "0" : ddlstudenttype.SelectedValue);
                objstd.CastID= Convert.ToInt32(ddlCast.SelectedValue == "" ? "0" : ddlCast.SelectedValue);
                objstd.SexID = Convert.ToInt32(ddlsex.SelectedValue == "" ? "0" : ddlsex.SelectedValue);
                objstd.ReligionID = Convert.ToInt32(ddlreligion.SelectedValue == "" ? "0" : ddlreligion.SelectedValue);
                objstd.MotherTongue = txtMotherTongue.Text.Trim();
                objstd.BelogToBPLoptionID = Convert.ToInt32(ddlBelongToBPL.SelectedValue == "" ? "0" : ddlBelongToBPL.SelectedValue);
                objstd.StudentCategory = Convert.ToInt32(ddlstudenycategory.SelectedValue == "" ? "0" : ddlstudenycategory.SelectedValue);
                objstd.IDmarks = txtIDmarks.Text.Trim();
                objstd.HouseID = Convert.ToInt32(ddlhouse.SelectedValue == "" ? "0" : ddlhouse.SelectedValue);
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 1;
                int result = objstdBO.UpdateStudentProfileTab1(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btntap1cancel_Click(object sender, EventArgs e)
        {
            //ddlamdission.SelectedIndex = 0;
            //txtstudentname.Text = "";
            //txtAdmNo.Text = "";
            //txtDOB.Text = "";
            //txtBirthRegNo.Text = "";
            //ddlstudenttype.SelectedIndex = 0;
            //ddlCast.SelectedIndex = 0;
            //ddlsex.SelectedIndex = 0;
            //ddlreligion.SelectedIndex = 0;
            //txtMotherTongue.Text = "";
            //ddlBelongToBPL.SelectedIndex = 0;
            //ddlstudenycategory.SelectedIndex = 0;
            //ddlhouse.SelectedIndex = 0;
            //txtIDmarks.Text = "";
            btntap1edit.Visible = true;
            btntap1save.Visible = false;
            btntap1cancel.Visible = false;
        }

        protected void btntap2edit_Click(object sender, EventArgs e)
        {
            btntap2edit.Visible = false;
            btntap2save.Visible = true;
            btntap2cancel.Visible = true;
            ddlclass.Attributes.Remove("disabled");
            ddlsection.Attributes.Remove("disabled");
            txtrollno.Attributes.Remove("disabled");
            txtregdno.Attributes.Remove("disabled");
        }

        protected void btntap2save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objstd.RegdNo = txtregdno.Text.Trim();
                objstd.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
                objstd.RollNo = Convert.ToInt32(txtrollno.Text.Trim() == "" ? "0" : txtrollno.Text.Trim());                
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 2;
                int result = objstdBO.UpdateStudentProfileTab2(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap2edit.Visible = true;
                btntap2save.Visible = false;
                btntap2cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btntap2cancel_Click(object sender, EventArgs e)
        {
            //ddlclass.SelectedIndex = 0;
            //ddlsection.SelectedIndex = 0;
            //txtrollno.Text = "";
            //txtregdno.Text = "";
            btntap2edit.Visible = true;
            btntap2save.Visible = false;
            btntap2cancel.Visible = false;

        }

        protected void btntap3edit_Click(object sender, EventArgs e)
        {
            btntap3edit.Visible = false;
            btntap3save.Visible = true;
            btntap3cancel.Visible = true;
            ddlbloodgroup.Attributes.Remove("disabled");
            txtallegry.Attributes.Remove("disabled");
            txtfisrtSessionheight.Attributes.Remove("disabled");
            txtIstsessioninitialwt.Attributes.Remove("disabled");
        }

        protected void btntap3save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.BloogroupID = Convert.ToInt32(ddlbloodgroup.SelectedValue == "" ? "0" : ddlbloodgroup.SelectedValue);
                objstd.Allerrgic = txtallegry.Text.Trim();
                objstd.IIsessioninitialweight = Convert.ToInt64(txtIstsessioninitialwt.Text.Trim() == "" ? "0" : txtIstsessioninitialwt.Text.Trim());
                objstd.IIsessioninitialheight = Convert.ToInt32(txtfisrtSessionheight.Text.Trim() == "" ? "0" : txtfisrtSessionheight.Text.Trim());
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 3;
                int result = objstdBO.UpdateStudentProfileTab3(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap3edit.Visible = true;
                btntap3save.Visible = false;
                btntap3cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }

        }

        protected void btntap3cancel_Click(object sender, EventArgs e)
        {
            //ddlbloodgroup.SelectedIndex = 0;
            //txtallegry.Text = "";
            //txtfisrtSessionheight.Text = "";
            //txtIstsessioninitialwt.Text = "";
            btntap3edit.Visible = true;
            btntap3save.Visible = false;
            btntap3cancel.Visible = false;
        }

        protected void btntap4edit_Click(object sender, EventArgs e)
        {
            btntap4edit.Visible = false;
            btntap4save.Visible = true;
            btntap4cancel.Visible = true;
            txtfathername.Attributes.Remove("disabled");
            txtmothername.Attributes.Remove("disabled");
            ddlrelationship.Attributes.Remove("disabled");
            txtfatheroccupation.Attributes.Remove("disabled");
            txtmotheroccupation.Attributes.Remove("disabled");
            txtincome.Attributes.Remove("disabled");
            txtgmobile.Attributes.Remove("disabled");
        }

        protected void btntap4save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.FatherName = txtfathername.Text.Trim();
                objstd.MotherName = txtmothername.Text.Trim();
                objstd.GrelationshipID = Convert.ToInt32(ddlrelationship.SelectedValue == "" ? "0" : ddlrelationship.SelectedValue);
                objstd.Goccupation = txtfatheroccupation.Text.Trim();
                objstd.MotherOccupation = txtmotheroccupation.Text.Trim();
                objstd.Income = Convert.ToDecimal(txtincome.Text == "" ? "0.00" : txtincome.Text);
                objstd.GmobileNo = txtgmobile.Text.Trim();
                objstd.tab = 4;
                int result = objstdBO.UpdateStudentProfileTab4(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap4edit.Visible = true;
                btntap4save.Visible = false;
                btntap4cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }

        }

        protected void btntap4cancel_Click(object sender, EventArgs e)
        {
            
            btntap4edit.Visible = true;
            btntap4save.Visible = false;
            btntap4cancel.Visible = false;
        }

        protected void btntap5edit_Click(object sender, EventArgs e)
        {
            btntap5edit.Visible = false;
            btntap5save.Visible = true;
            btntap5cancel.Visible = true;
            txtlastschoolName.Attributes.Remove("disabled");
            txtlastclass.Attributes.Remove("disabled");
            txtlastsection.Attributes.Remove("disabled");
            txtlastroll.Attributes.Remove("disabled");
            txtlatsmarks.Attributes.Remove("disabled");
            txtattendance.Attributes.Remove("disabled");

        }

        protected void btntap5save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.LastSchoolName = txtlastschoolName.Text.Trim();
                objstd.LastClass = txtlastclass.Text.Trim();
                objstd.LastSection = txtlastsection.Text.Trim();
                objstd.LastRollno = Convert.ToInt32(txtlastroll.Text == "" ? "0" :txtlastroll.Text);
                objstd.LastMark = txtlatsmarks.Text.Trim();
                objstd.LastAttendance = txtattendance.Text.Trim();
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 5;
                int result = objstdBO.UpdateStudentProfileTab5(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap5edit.Visible = true;
                btntap5save.Visible = false;
                btntap5cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btntap5cancel_Click(object sender, EventArgs e)
        {
            //txtlastschoolName.Text = "";
            //txtlastclass.Text = "";
            //txtlastsection.Text = "";
            //txtlastroll.Text = "";
            //txtlatsmarks.Text = "";
            //txtattendance.Text = "";
            btntap5edit.Visible = true;
            btntap5save.Visible = false;
            btntap5cancel.Visible = false;
        }

        protected void btntap6edit_Click(object sender, EventArgs e)
        {
            btntap6edit.Visible = false;
            btntap6save.Visible = true;
            btntap6cancel.Visible = true;
            txtbankname.Attributes.Remove("disabled");
            txtifsc.Attributes.Remove("disabled");
            txtaccountno.Attributes.Remove("disabled");
            txtaadhar.Attributes.Remove("disabled");
        }

        protected void btntap6save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.BankName = txtbankname.Text.Trim();
                objstd.IFSC = txtifsc.Text.Trim();
                objstd.AC = txtaccountno.Text.Trim();
                objstd.Aadhar = txtaadhar.Text.Trim();
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 6;
                int result = objstdBO.UpdateStudentProfileTab6(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap6edit.Visible = true;
                btntap6save.Visible = false;
                btntap6cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btntap6cancel_Click(object sender, EventArgs e)
        {
            //txtbankname.Text = "";
            //txtifsc.Text = "";
            //txtaccountno.Text = "";
            //txtaadhar.Text = "";
            btntap6edit.Visible = true;
            btntap6save.Visible = false;
            btntap6cancel.Visible = false;
        }

        protected void btntap7edit_Click(object sender, EventArgs e)
        {
            btntap7edit.Visible = false;
            btntap7save.Visible = true;
            btntap7cancel.Visible = true;
            txtaddress.Attributes.Remove("disabled");
        }

        protected void btntap7save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.Address = txtaddress.Text.Trim();
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 7;
                int result = objstdBO.UpdateStudentProfileTab7(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap6edit.Visible = true;
                btntap6save.Visible = false;
                btntap6cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btntap7cancel_Click(object sender, EventArgs e)
        {
            //txtaddress.Text = "";
            btntap7edit.Visible = true;
            btntap7save.Visible = false;
            btntap7cancel.Visible = false;
        }

        protected void btntap8edit_Click(object sender, EventArgs e)
        {
            btntap8edit.Visible = false;
            btntap8save.Visible = true;
            btntap8cancel.Visible = true;
            txtpaddress.Attributes.Remove("disabled");
        }

        protected void btntap8save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.pAddress = txtpaddress.Text.Trim();
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 8;
                int result = objstdBO.UpdateStudentProfileTab8(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap6edit.Visible = true;
                btntap6save.Visible = false;
                btntap6cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btntap8cancel_Click(object sender, EventArgs e)
        {
            //txtpaddress.Text = "";
            btntap8edit.Visible = true;
            btntap8save.Visible = false;
            btntap8cancel.Visible = false;

        }

        protected void btntap9edit_Click(object sender, EventArgs e)
        {
            btntap9edit.Visible = false;
            btntap9save.Visible = true;
            btntap9cancel.Visible = true;
            ddlacademicseesions.Attributes.Remove("disabled");
        }

        protected void btntap9save_Click(object sender, EventArgs e)
        {
            try
            {

                StudentData objstd = new StudentData();
                AddstudentBO objstdBO = new AddstudentBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                objstd.AdmissionNo = txtAdmNo.Text == "" ? "0" : txtAdmNo.Text.Trim();
                objstd.SubjectName = txtsubjectlist.Text.Trim();
                objstd.AcademicSessionID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                objstd.tab = 9;
                int result = objstdBO.UpdateStudentProfileTab9(objstd);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                btntap6edit.Visible = true;
                btntap6save.Visible = false;
                btntap6cancel.Visible = false;
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btntap9cancel_Click(object sender, EventArgs e)
        {
            ddlacademicseesions.SelectedIndex = 0;
            txtsubjectlist.Text = "";
            btntap9edit.Visible = true;
            btntap9save.Visible = false;
            btntap9cancel.Visible = false;
        }

        protected void GvCertificateDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GvTransportDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        //Fee Status
        protected void bindStatusDetails(int index)
        {
            List<FeeData> lststatus = GetFeeStatusDetails(index);
            if (lststatus.Count > 0)
            {
                Gv_Feestatusdetails.DataSource = lststatus;
                Gv_Feestatusdetails.DataBind();
                Gv_Feestatusdetails.Visible = true;
                Gv_Feestatusdetails.Visible = true;
            }
            else
            {
                Gv_Feestatusdetails.DataSource = null;
                Gv_Feestatusdetails.DataBind();
                Gv_Feestatusdetails.Visible = true;
                Gv_Feestatusdetails.Visible = false;
            }
        }
        public List<FeeData> GetFeeStatusDetails(int curIndex)
        {
            FeeData objfee = new FeeData();
            FeeBO objfeeBO = new FeeBO();
            objfee.ClassID = 0; // Convert.ToInt32(.Text);
            objfee.StudentID = Convert.ToInt32(txtAdmNo.Text);
            objfee.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objfee.EmployeeID = LoginToken.EmployeeID;
            return objfeeBO.SearchFeeStatusDetails(objfee);
        }

        //Exam Status
        protected void bindExamStatusDetails(int index)
        {
            List<Examdata> lstsubject = GetExamDetails(index);
            if (lstsubject.Count > 0)
            {
                GvExamDetails.DataSource = lstsubject;
                GvExamDetails.DataBind();
                GvExamDetails.Visible = true;
                Tap22.Visible = true;
            }
            else
            {
                GvExamDetails.DataSource = null;
                GvExamDetails.DataBind();
                GvExamDetails.Visible = true;
                Tap22.Visible = false;
            }
        }
        public List<Examdata> GetExamDetails(int curIndex)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.ClassID = 0;// Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.StudentID = Convert.ToInt32(txtAdmNo.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.EmployeeID = LoginToken.EmployeeID;
            objexam.CompanyID = LoginToken.CompanyID;
            return objexamBO.SearchStudentExamlist(objexam);
        }
        //Certificate
        protected void bindCertificateStatusDetails(int index)
        {
            List<Examdata> lstcertificate = GetCertificateDetails(index);
            if (lstcertificate.Count > 0)
            {
                GvCertificateDetails.DataSource = lstcertificate;
                GvCertificateDetails.DataBind();
                GvCertificateDetails.Visible = true;
                Tap27.Visible = true;
            }
            else
            {
                GvCertificateDetails.DataSource = null;
                GvCertificateDetails.DataBind();
                GvCertificateDetails.Visible = true;
                Tap27.Visible = false;
            }
        }
        public List<Examdata> GetCertificateDetails(int curIndex)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.StudentID = Convert.ToInt32(txtAdmNo.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.EmployeeID = LoginToken.EmployeeID;
            objexam.CompanyID = LoginToken.CompanyID;
            return objexamBO.SearchCertificateList(objexam);
        }
        //TRANSPORT
        public List<TransportData> GetTransportregistrationDetails(Int64 StudentID, int SessionID)
        {
            TransportData objtrans = new TransportData();
            TransportRegistrationBO objstdBO = new TransportRegistrationBO();
            objtrans.StudentID = StudentID;
            objtrans.AcademicSessionID = SessionID;
            return objstdBO.SearchTransportStudentDetails(objtrans);
        }
        protected void TransportStudentList(Int64 studentID, int sessionID)
        {
            List<TransportData> Tstudentprofile = GetTransportregistrationDetails(studentID, sessionID);
            if (Tstudentprofile.Count > 0)
            {
                TransportData objreg = new TransportData();
                TransportRegistrationBO objFeeBO = new TransportRegistrationBO();
                txtRouteno.Text = Tstudentprofile[0].RootID.ToString();
                txtroute.Text = Tstudentprofile[0].Routename.ToString();
                Txtdriver.Text = Tstudentprofile[0].DriverName.ToString();
                txtbusno.Text = Tstudentprofile[0].VehicleNo.ToString();
            }
            else
            {
                //clearall();
            }

        }

        //Hostel
        public List<HostelRegistrationData> GetHostelregistrationDetails(Int64 StudentID, int SessionID)
        {
            HostelRegistrationData objHostel = new HostelRegistrationData();
            HostelRegistrationBO objstdBO = new HostelRegistrationBO();
            objHostel.StudentID = StudentID;
            objHostel.AcademicSessionID = SessionID;
            return objstdBO.SearchHostelStudentDetails(objHostel);
        }
        protected void HostelStudentList(Int64 studentID, int sessionID)
        {
            List<HostelRegistrationData> Hstudentprofile = GetHostelregistrationDetails(studentID, sessionID);
            if (Hstudentprofile.Count > 0)
            {
                HostelRegistrationData objreg = new HostelRegistrationData();
                HostelRegistrationBO objFeeBO = new HostelRegistrationBO();
                Txtblock.Text = Hstudentprofile[0].BlockName.ToString();
                txtwing.Text = Hstudentprofile[0].Dry.ToString();
                txtwardenname.Text = Hstudentprofile[0].EmpName.ToString();
                txtbed.Text = Hstudentprofile[0].Bed.ToString();
            }
            else
            {
                //clearall();
            }

        }

    }
}