using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class StaticalExamResultreport : System.Web.UI.Page
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
            Commonfunction.PopulateDdl(ddlcategory, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        }
        //protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    ddlclasses.SelectedIndex = 0;
        //   // ddlsections.SelectedIndex = 0;
        //    ddlexam.SelectedIndex = 0;
        //    //txtrollNo.Text = "";
        //}
        protected void btnprocess_Click(object sender, EventArgs e)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();


            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.StudentCategoryID = Convert.ToInt32(ddlcategory.SelectedValue == "" ? "0" : ddlcategory.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
           // objexam.ExamNo = Convert.ToInt32(examtypeID.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            int results = objexamBO.ProsessResultSummary(objexam);
            if (results == 1)
            {
                Messagealert_.ShowMessage(lblmessage, "Successfuly Created the report.", 1);
            }
            else if (results == 5)
            {
                Messagealert_.ShowMessage(lblmessage, "There in no mark entry.", 0);
            }
            else
            {

                Messagealert_.ShowMessage(lblmessage, "Error", 0);
            }
        }
        protected void ddlexam_SelectedIndexChanged(object sender, EventArgs e)
        {
            examtypeID.Text = ddlexam.SelectedIndex.ToString();
        }
    }
}