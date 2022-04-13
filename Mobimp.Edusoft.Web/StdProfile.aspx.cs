using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web
{
    public partial class StdProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Viewprofile();
            }
        }

        protected void gvcompulsory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Viewprofile()
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtage.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtage.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtage.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtage.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objstd.StudentID = Convert.ToInt32(Session["StudentID"].ToString());
            objstd.AcademicSessionID = Convert.ToInt32(Session["SessionID"].ToString());
            objstd.ActionType = EnumActionType.Select;
            objstd.Datefrom = from;
            objstd.Dateto = To;
            objstd.IsActiveALL = Session["StatusID"].ToString();
            objstd.PageSize = 1;
            objstd.CurrentIndex = 0;

            List<StudentData> studentdetails = objstdBO.SearchStudentDetails(objstd);
            if (studentdetails.Count > 0)
            {


                imgphoto.Src = studentdetails[0].StudentPhoto.ToString();
                txtname.Text = studentdetails[0].Salutation + "." + studentdetails[0].StudentName.ToString();
                txtfathername.Text = studentdetails[0].Gsalutation + "." + studentdetails[0].GurdianName.ToString();
                txtmothername.Text = studentdetails[0].Mothersalutation + "." + studentdetails[0].Mothername.ToString();
                txtstdtype.Text = studentdetails[0].StudentType.ToString();
                txtCast.Text = studentdetails[0].CastName.ToString();
                txtnationality.Text = studentdetails[0].Nationality.ToString();
                txtbloodgroup.Text = studentdetails[0].Bloogroup.ToString();
                txtreligion.Text = studentdetails[0].Religion.ToString();
                txtsex.Text = studentdetails[0].SexName.ToString();
                txtadmissionno.Text = studentdetails[0].AdmissionNo.ToString();
                if (studentdetails[0].TransportType == null)
                {
                    txttransport.Text = "";

                }
                else
                {
                    txttransport.Text = studentdetails[0].TransportType.ToString();
                }
                txtvehicleno.Text = studentdetails[0].VehicleNo.ToString();
                txtmotherocupation.Text = studentdetails[0].MotherOccupation.ToString();
                txtDOB.Text = studentdetails[0].DOB.ToString("dd/MM/yyyy");
                Gvoptionallist.DataSource = studentdetails;
                Gvoptionallist.DataBind();
                txtgmobile.Text = studentdetails[0].GmobileNo.ToString();
                txtrelation.Text = studentdetails[0].Grelationship.ToString();
                txtoccupation.Text = studentdetails[0].Goccupation.ToString();
                txtclass.Text = studentdetails[0].ClassName.ToString();
                txtcurraddress.Text = studentdetails[0].cAddress.ToString();
                txtcurrcountry.Text = studentdetails[0].cCountry.ToString();
                txtcurrstate.Text = studentdetails[0].cState.ToString();
                txtcurrdistrict.Text = studentdetails[0].cDistrict.ToString();
                txtcurrpin.Text = studentdetails[0].cPIN.ToString();
                txtcurrlandmarks.Text = studentdetails[0].cLandMark;
                txtcmobile.Text = studentdetails[0].cMobileNo;
                txtpermaddress.Text = studentdetails[0].pAddress.ToString();
                txtpermtcountry.Text = studentdetails[0].pCountry.ToString();
                txtpermstate.Text = studentdetails[0].pState.ToString();
                txtpermdistrict.Text = studentdetails[0].pDistrict.ToString();
                txtperpin.Text = studentdetails[0].pPIN.ToString();
                txtperlandmark.Text = studentdetails[0].pLandMark.ToString();
                txtpmobile.Text = studentdetails[0].pMobileNo.ToString();
                Getcsubjectlist(Convert.ToInt32(Session["StudentID"].ToString()), Convert.ToInt32(Session["AdmissionID"].ToString()));
            }
        }

        protected void Getcsubjectlist(int studentID, int AdmiisionID)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = studentID;
            objstd.AdmissionID = AdmiisionID;
            List<StudentData> csubjectlist = objstdBO.GetCsubjectlist(objstd);
            if (csubjectlist.Count > 0)
            {
                gvcompulsory.DataSource = csubjectlist;
                gvcompulsory.DataBind();
                Session["StudentID"] = null;
                Session["AdmissionID"] = null;
                Session["StatusID"] = null;

            }
            else
            {
                gvcompulsory.DataSource = null;
                gvcompulsory.DataBind();
                Session["StudentID"] = null;
                Session["AdmissionID"] = null;
                Session["StatusID"] = null;


            }
        }

    }
}