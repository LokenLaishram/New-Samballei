using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class ClassTopper : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue),Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid();
            lblmessage.Visible = false;

        }
        private void bindgrid()
        {
            List<Examdata> lstsubject = getStudentdetails(0);
            if (lstsubject.Count > 0)
            {
                GvExamdetails.DataSource = lstsubject;
                GvExamdetails.DataBind();
                GvExamdetails.Visible = true;
            }
            else
            {
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
                GvExamdetails.Visible = true;
            }
        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlexam.SelectedIndex = 0;
        }
        public List<Examdata> getStudentdetails(int curIndex)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);

            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            return objexamBO.GetClassTopper(objexam);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlexam.SelectedIndex = 0;
            lblmessage.Visible = false;
            GvExamdetails.DataSource = null;
            GvExamdetails.DataBind();
            GvExamdetails.Visible = false;
           

        }
    }
}