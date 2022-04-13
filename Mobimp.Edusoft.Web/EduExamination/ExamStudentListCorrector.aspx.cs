using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Collections.Generic;
using System;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class StudentListCorrector : BasePage
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
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            Commonfunction.PopulateDdl(ddlsubject, objmstlookupBO.GetSubjectByClassIDCatgeoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void bindgrid()
        {
            List<Examdata> lstsubject = getSubjectdetails(0);
            if (lstsubject.Count > 0)
            {
                GvExamdetails.DataSource = lstsubject;
                GvExamdetails.DataBind();
                GvExamdetails.Visible = true;
                lblmessage.Visible = false;
                txtpwfullmark.Text = lstsubject[0].PWmark.ToString();
                txtpwpassmark.Text = lstsubject[0].PWpassmark.ToString();
                txtutfullmarks.Text = lstsubject[0].UTmark.ToString();
                txtutpassmark.Text = lstsubject[0].UTpassmark.ToString();
                txthafullmark.Text = lstsubject[0].HAmark.ToString();
                txthapassmark.Text = lstsubject[0].HApassmark.ToString();
                txtFullMark.Text = lstsubject[0].FullMark.ToString();
                txtpassmark.Text = lstsubject[0].PassMark.ToString();
                txttotalmark.Text = lstsubject[0].TotalMark.ToString();
                txttotalpassmark.Text = lstsubject[0].TotalPassMark.ToString();
            }
            else
            {
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
                GvExamdetails.Visible = true;
            }

        }
        protected void ddlexam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExamTypeData objexamtype = new ExamTypeData();
            ExamTypeBO objobjexamtype = new ExamTypeBO();
            objexamtype.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexamtype.ActionType = EnumActionType.Select;
            objexamtype.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexamtype.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
        }
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
        public List<Examdata> getSubjectdetails(int curIndex)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexam.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
            objexam.StudentID = Convert.ToInt32(txtstudentID.Text == "" ? "0" : txtstudentID.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            return objexamBO.GetSubjectWiseStudentList(objexam);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlsections.ClearSelection();
            ddlexam.SelectedIndex = 0;
            lblmessage.Visible = false;
            GvExamdetails.DataSource = null;
            GvExamdetails.DataBind();
            GvExamdetails.Visible = false;
            txtstudentID.Text = "";
            ddlexam.SelectedIndex = 0;
            ddlsubject.SelectedIndex = 0;
            txtstudentID.Text = "";
        }
        protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsubject.SelectedIndex > 0)
            {
                GvExamdetails.Visible = true;
                bindgrid();
            }
            else
            {
                GvExamdetails.Visible = false;
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexam.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
            objexam.StudentID = Convert.ToInt32(txtstudentID.Text == "" ? "0" : txtstudentID.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.PWmark = float.Parse(txtpwfullmark.Text == "" ? "0.0" : txtpwfullmark.Text);
            objexam.PWpassmark = float.Parse(txtpwpassmark.Text == "" ? "0.0" : txtpwpassmark.Text);
            objexam.UTmark = float.Parse(txtutfullmarks.Text == "" ? "0.0" : txtutfullmarks.Text);
            objexam.UTpassmark = float.Parse(txtutpassmark.Text == "" ? "0.0" : txtutpassmark.Text);
            objexam.HAmark = float.Parse(txthafullmark.Text == "" ? "0.0" : txthafullmark.Text);
            objexam.HApassmark = float.Parse(txthapassmark.Text == "" ? "0.0" : txthapassmark.Text);
            objexam.TotalMark = float.Parse(txttotalmark.Text == "" ? "0.0" : txttotalmark.Text);
            objexam.TotalPassMark = float.Parse(txttotalpassmark.Text == "" ? "0.0" : txttotalpassmark.Text);
            objexam.AddedBy = LoginToken.LoginId;
            int result = objexamBO.SubjectwiseAddStudent(objexam);
            if (result == 1)
            {
                bindgrid();
                Messagealert_.ShowMessage(lblmessage, "Successfully added.", 1);
            }
            else
            {
                Messagealert_.ShowMessage(lblmessage, "Error", 0);
            }
        }
        protected void GvExamdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletes")
            {

                Examdata objexam = new Examdata();
                ExamTypeBO objexamBO = new ExamTypeBO();
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvExamdetails.Rows[i];
                Label ID = (Label)gr.Cells[0].FindControl("lblID");
                objexam.StudentID = Convert.ToInt64(ID.Text);
                objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
                objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                objexam.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
                objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue);
                objexam.ActionType = EnumActionType.Delete;
                objexam.UserId = LoginToken.UserLoginId;
                int Result = objexamBO.DeleteStudentfromexamlist(objexam);
                if (Result == 1)
                {
                    Messagealert_.ShowMessage(lblmessage, "delete", 1);
                    bindgrid();
                }
                else
                {
                    Messagealert_.ShowMessage(lblmessage, "system", 0);
                }
            }
        }
        protected void txtstudentID_TextChanged(object sender, EventArgs e)
        {
            bindgrid();
        }
    }
}