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
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using System.Data.OleDb;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class SubjectWiseMarkEntry : BasePage
    {
        DataSet ds = new DataSet();
        static int rowcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            bindgridfoucs();
            if (!IsPostBack)
            {
                divsubject.Visible = true;
                BindDlls();
                lblNote.Visible = false;
                if (Session["ClassID"] != null && Session["ExamID"] != null && Session["academicsession"] != null)
                {
                    MasterLookupBO objmstlookupBO = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlclasses, objmstlookupBO.GetLookupsList(LookupNames.Class));
                    Commonfunction.PopulateDdl(ddlacademicseesions, objmstlookupBO.GetLookupsList(LookupNames.Academicsession));
                    ddlacademicseesions.SelectedValue = Session["academicsession"].ToString();
                    ddlexam.SelectedValue = Session["ExamID"].ToString();
                    ddlclasses.SelectedValue = Session["ClassID"].ToString();
                    Bindclasswisesubjectlist(1);
                    Session["ClassID"] = null;
                    Session["ExamID"] = null;
                    Session["academicsession"] = null;
                }
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();

            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlexam, mstlookup.GetLookupsList(LookupNames.ExamNames));

            Commonfunction.Insertzeroitemindex(ddlclasses);
            Commonfunction.Insertzeroitemindex(ddlsections);
            Commonfunction.Insertzeroitemindex(ddlsubject);
            Commonfunction.Insertzeroitemindex(ddl_enterby);
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclasses.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
                Commonfunction.PopulateDdl(ddlsubject, objmstlookupBO.GetSubjectByClassIDCatgeoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
                //Commonfunction.PopulateDdl(ddl_enterby, objmstlookupBO.GetLookupsList(LookupNames.TeachingStaff));
                Commonfunction.Insertzeroitemindex(ddl_enterby);
                Bindclasswisesubjectlist(1);
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlsections);
                Commonfunction.Insertzeroitemindex(ddlsubject);
                Commonfunction.Insertzeroitemindex(ddl_enterby);
                Gv_class_exam_subject_list.DataSource = null;
                Gv_class_exam_subject_list.DataBind();
                Gv_class_exam_subject_list.Visible = false;
                diventrylist.Visible = false;
            }
            divsubjectmark.Visible = false;
        }
        protected void ddlsections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindclasswisesubjectlist(1);
            divsubjectmark.Visible = false;
        }
        protected void bindgridfoucs()
        {
            for (int i = 0; i < Gv_subjectwiseStudentlist.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_subjectwiseStudentlist.Rows[i].Cells[5].FindControl("txt_WA") as TextBox;
                TextBox nexTextbox = Gv_subjectwiseStudentlist.Rows[i + 1].Cells[5].FindControl("txt_WA") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_subjectwiseStudentlist.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btn_save.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_subjectwiseStudentlist.Rows.Count - 1; i++)
            {
                TextBox curTexbox1 = Gv_subjectwiseStudentlist.Rows[i].Cells[6].FindControl("txt_CA") as TextBox;
                TextBox nexTextbox1 = Gv_subjectwiseStudentlist.Rows[i + 1].Cells[6].FindControl("txt_CA") as TextBox;
                curTexbox1.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox1.ClientID + "', event)");
                int lastindex = Gv_subjectwiseStudentlist.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox1.Attributes.Add("onkeypress", "return clickEnter('" + btn_save.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_subjectwiseStudentlist.Rows.Count - 1; i++)
            {
                TextBox curTexbox2 = Gv_subjectwiseStudentlist.Rows[i].Cells[6].FindControl("txt_GRADE") as TextBox;
                TextBox nexTextbox2 = Gv_subjectwiseStudentlist.Rows[i + 1].Cells[6].FindControl("txt_GRADE") as TextBox;
                curTexbox2.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox2.ClientID + "', event)");
                int lastindex = Gv_subjectwiseStudentlist.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox2.Attributes.Add("onkeypress", "return clickEnter('" + btn_save.ClientID + "', event)");
                }
            }
        }
        protected void ddlexam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlexam.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlclasses, objmstlookupBO.GetLookupsList(LookupNames.Class));
                //  Bindclasswisesubjectlist(1);
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlclasses);
                Commonfunction.Insertzeroitemindex(ddlsections);
                Commonfunction.Insertzeroitemindex(ddlsubject);
                Commonfunction.Insertzeroitemindex(ddl_enterby);
                Gv_class_exam_subject_list.DataSource = null;
                Gv_class_exam_subject_list.DataBind();
                Gv_class_exam_subject_list.Visible = false;
                diventrylist.Visible = false;
            }
            divsubjectmark.Visible = false;
        }
        private void Bindclasswisesubjectlist(int index)
        {
            List<ExamsubjectData> lstsubject = getSubjectdetails(index);
            if (lstsubject.Count > 0)
            {
                // btnupdate.Visible = true;
                rowcount = lstsubject.Count;
                Gv_class_exam_subject_list.DataSource = lstsubject;
                Gv_class_exam_subject_list.DataBind();
                Gv_class_exam_subject_list.Visible = true;
                diventrylist.Visible = true;
            }
            else
            {
                Gv_class_exam_subject_list.DataSource = null;
                Gv_class_exam_subject_list.DataBind();
                Gv_class_exam_subject_list.Visible = true;
                //btnupdate.Visible = false;
                diventrylist.Visible = false;
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            getSubjectdetails(1);
        }
        public List<ExamsubjectData> getSubjectdetails(int curIndex)
        {
            ExamsubjectData objexam = new ExamsubjectData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.CLassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexam.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.EmployeeID = LoginToken.EmployeeID;
            return objexamBO.GetSubjectWiseMarkDetails(objexam);
        }
        protected void GetsubjectstudentList(int classID, int ExamID, int sectID, int SubjectID, int SessionID)
        {
            ExammarkentryData objexam = new ExammarkentryData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.CLassID = classID;
            objexam.ExamID = ExamID;
            objexam.SectionID = sectID;
            objexam.SubjectID = SubjectID;
            objexam.AcademicSessionID = SessionID;
            objexam.Roll = 0; //Convert.ToInt32(txt_roll.Text == "" ? "0" : txt_roll.Text);
            objexam.EmployeeID = LoginToken.EmployeeID;
            List<ExammarkentryData> result = objexamBO.Getsubjectwisestudentlist(objexam);

            if (result.Count > 0)
            {
                List<ExammarkentryData> studentlist = Session["studentlist"] == null ? new List<ExammarkentryData>() : (List<ExammarkentryData>)Session["studentlist"];
                Session["studentlist"] = result;
                // txt_class.Text = result[0].ClassName;
                txt_UT.Text = "TH FM : " + result[0].UT_FM + " || TH PM : " + result[0].UT_PM;
                txt_PW.Text = "PW FM : " + result[0].PW_FM + " || PW PM : " + result[0].PW_PM;
                lblIsSubSubject.Text = result[0].IsSubSubject.ToString();
                lblIsGrade.Text = result[0].IsGradeSubject.ToString();
                Gv_subjectwiseStudentlist.DataSource = result;
                Gv_subjectwiseStudentlist.DataBind();
                bindgridfoucs();
                //if (lblIsGrade.Text == "1")
                //{
                //    Gv_subjectwiseStudentlist.Columns[2].Visible = true;
                //}
                //else if (lblIsGrade.Text == "0")
                //{
                //    Gv_subjectwiseStudentlist.Columns[2].Visible = false;
                //}
            }
            else
            {
                Gv_subjectwiseStudentlist.DataSource = null;
                Gv_subjectwiseStudentlist.DataBind();
            }
        }
        int countsecID = 1;
        string classID = "";
        protected void Gv_class_exam_subject_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Gv_class_exam_subject_list.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                    //TH Mark
                    Gv_class_exam_subject_list.Columns[4].Visible = true;
                    Gv_class_exam_subject_list.Columns[7].Visible = true;
                    Gv_class_exam_subject_list.Columns[8].Visible = true;
                    Gv_class_exam_subject_list.Columns[13].Visible = true;

                    //PW Mark
                    Gv_class_exam_subject_list.Columns[5].Visible = true;
                    Gv_class_exam_subject_list.Columns[9].Visible = true;
                    Gv_class_exam_subject_list.Columns[10].Visible = true;
                    Gv_class_exam_subject_list.Columns[14].Visible = true;

                    //Full Mark
                    Gv_class_exam_subject_list.Columns[11].Visible = true;
                    Gv_class_exam_subject_list.Columns[12].Visible = true;

                    Label ID = (Label)e.Row.FindControl("lbl_sectionID");
                    Label Class = (Label)e.Row.FindControl("lblClass");
                    Label slno = (Label)e.Row.FindControl("lbl_sno");
                    Label wa_status = (Label)e.Row.FindControl("lbl_wastatus");
                    Label ca_status = (Label)e.Row.FindControl("lbl_castatus");
                    Label isgradesubject = (Label)e.Row.FindControl("lbl_isgradesubject");
                    Label grade_status = (Label)e.Row.FindControl("lbl_gradestatus");
                    Label NoWaCount = (Label)e.Row.FindControl("lbl_noWA");
                    Label NoCaCount = (Label)e.Row.FindControl("lbl_noCA");
                    Label NoGradeCount = (Label)e.Row.FindControl("lbl_noGRADE");
                    LinkButton btn_wa = (LinkButton)e.Row.FindControl("lnl_WA");
                    LinkButton btn_ca = (LinkButton)e.Row.FindControl("lnl_CA");
                    LinkButton btn_grade = (LinkButton)e.Row.FindControl("lnl_grade");
                    Button btn_print = (Button)e.Row.FindControl("lnkPrint");

                    Label PW_FM = (Label)e.Row.FindControl("lbl_CAFM");
                    Label PW_PM = (Label)e.Row.FindControl("lbl_CAPM");
                    Label UT_FM = (Label)e.Row.FindControl("lbl_WAFM");
                    Label UT_PM = (Label)e.Row.FindControl("lbl_WAPM");
                    Label GRADEEntryCount = (Label)e.Row.FindControl("lbl_noGRADE");

                    Label TotalSubCount = (Label)e.Row.FindControl("lbl_TotalSubjectCount");
                    Label Zero_UT_FM_Count = (Label)e.Row.FindControl("lbl_UTFmZeroCount");
                    Label Zero_PW_FM_Count = (Label)e.Row.FindControl("lbl_PwFmZeroCount");

                    if (Convert.ToInt32(Zero_UT_FM_Count.Text) == Convert.ToInt32(TotalSubCount.Text))
                    {
                        Gv_class_exam_subject_list.Columns[4].Visible = false;
                        Gv_class_exam_subject_list.Columns[7].Visible = false;
                        Gv_class_exam_subject_list.Columns[8].Visible = false;
                        Gv_class_exam_subject_list.Columns[13].Visible = false;
                        Gv_class_exam_subject_list.Columns[11].Visible = false;
                        Gv_class_exam_subject_list.Columns[12].Visible = false;
                    }

                    if (Convert.ToInt32(Zero_PW_FM_Count.Text) == Convert.ToInt32(TotalSubCount.Text))
                    {
                        Gv_class_exam_subject_list.Columns[5].Visible = false;
                        Gv_class_exam_subject_list.Columns[9].Visible = false;
                        Gv_class_exam_subject_list.Columns[10].Visible = false;
                        Gv_class_exam_subject_list.Columns[14].Visible = false;
                        Gv_class_exam_subject_list.Columns[11].Visible = false;
                        Gv_class_exam_subject_list.Columns[12].Visible = false;
                    }

                    if (isgradesubject.Text == "1")
                    {
                        PW_FM.Text = "";
                        PW_PM.Text = "";
                        UT_FM.Text = "";
                        UT_PM.Text = "";
                        GRADEEntryCount.Text = "";
                        btn_wa.Enabled = false;
                        btn_ca.Enabled = false;
                    }
                    if (isgradesubject.Text == "0")
                    {
                        btn_grade.Enabled = false;
                    }

                    if (classID == ID.Text)
                    {
                        countsecID = countsecID + 1;
                        slno.Text = countsecID.ToString() + '.';
                    }
                    else
                    {
                        classID = ID.Text;
                        countsecID = 1;
                        btn_print.Visible = true;
                        slno.Text = countsecID.ToString() + '.';
                    }
                    if (countsecID > 1)
                    {
                        Class.Text = "";
                    }
                    //Grade 
                    if (grade_status.Text == "1")
                    {
                        btn_grade.Text = "Pending";
                        btn_grade.CssClass = "btn btn-warning cus_btn";
                    }
                    if (grade_status.Text == "2")
                    {
                        btn_grade.Text = "Partial";
                        btn_grade.CssClass = "btn btn-info cus_btn";
                    }
                    if (grade_status.Text == "3")
                    {
                        btn_grade.Text = "Completed";
                        btn_grade.CssClass = "btn btn-success cus_btn";
                    }
                    //WA
                    if (wa_status.Text == "1")
                    {
                        btn_wa.Text = "Pending";
                        btn_wa.CssClass = "btn btn-warning cus_btn";
                        btn_grade.Text = "";

                    }
                    if (wa_status.Text == "2")
                    {
                        btn_wa.Text = "Partial";
                        btn_wa.CssClass = "btn btn-info cus_btn";
                        btn_grade.Text = "";
                    }
                    if (wa_status.Text == "3")
                    {
                        btn_wa.Text = "Completed";
                        btn_wa.CssClass = "btn btn-success cus_btn";
                        btn_grade.Text = "";
                    }
                    if (wa_status.Text == "4")
                    {
                        btn_wa.Text = "";
                        NoWaCount.Text = "";
                    }
                    //CA
                    if (ca_status.Text == "1")
                    {
                        btn_ca.Text = "Pending";
                        btn_ca.CssClass = "btn btn-warning cus_btn";
                        btn_grade.Text = "";
                    }
                    if (ca_status.Text == "2")
                    {
                        btn_ca.Text = "Partial";
                        btn_ca.CssClass = "btn btn-info cus_btn";
                        btn_grade.Text = "";
                    }
                    if (ca_status.Text == "3")
                    {
                        btn_ca.Text = "Completed";
                        btn_ca.CssClass = "btn btn-success cus_btn";
                        btn_grade.Text = "";
                    }
                    if (ca_status.Text == "4")
                    {
                        btn_ca.Text = "";
                        NoCaCount.Text = "";
                    }
                    //WA_STATUS
                    if (UT_FM.Text == "0")
                    {
                        btn_wa.Visible = false;
                    }
                    else
                    {
                        btn_wa.Visible = true;
                    }
                    //CA_STATUS
                    if (PW_FM.Text == "0")
                    {
                        btn_ca.Visible = false;
                    }
                    else
                    {
                        btn_ca.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }
        protected void Gv_subjectwiseStudentlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = e.Row.RowIndex;
                TextBox WA = (TextBox)e.Row.FindControl("txt_WA");
                TextBox CA = (TextBox)e.Row.FindControl("txt_CA");
                TextBox Grade = (TextBox)e.Row.FindControl("txt_GRADE");
                Label lbl_wa = (Label)e.Row.FindControl("lbl_swa");
                Label lbl_ca = (Label)e.Row.FindControl("lbl_sca");
                Label lbl_grade = (Label)e.Row.FindControl("lbl_sgrade");
                Label lbl_wa_status = (Label)e.Row.FindControl("lbl_ut_entrystatus");
                Label lbl_ca_status = (Label)e.Row.FindControl("lbl_pw_entrystatus");
                Label lbl_grade_staus = (Label)e.Row.FindControl("lbl_grade_entrystatus");
                Label lblstatus = (Label)e.Row.FindControl("lbl_status");
                Label PWabsentstatus = (Label)e.Row.FindControl("lbl_absentPW");
                Label UTabsentstatus = (Label)e.Row.FindControl("lbl_absentUT");
                Label Gradeabsentstatus = (Label)e.Row.FindControl("lbl_absentGrade");
                Label isgradesub = (Label)e.Row.FindControl("lbl_isgrade");
                Label ut_fm = (Label)e.Row.FindControl("lbl_wa_fm");
                Label pw_fm = (Label)e.Row.FindControl("lbl_ca_fm");

                if (lbl_markingtype.Text == "WA" && id == 0)
                {
                    WA.Focus();
                }
                if (lbl_markingtype.Text == "CA" && id == 0)
                {
                    CA.Focus();
                }
                if (lbl_markingtype.Text == "Grade" && id == 0)
                {
                    Grade.Focus();
                }
                if (lbl_wa_status.Text == "0")
                {
                    lbl_wa.Text = "";
                    WA.Text = "";
                }
                if (lbl_ca_status.Text == "0")
                {
                    lbl_ca.Text = "";
                    CA.Text = "";
                }
                //if (lbl_grade_staus.Text == "0")
                //{
                //    lbl_grade.Text = "";
                //    Grade.Text = "";
                //}
                if (PWabsentstatus.Text == "1")
                {
                    CA.Text = "A";
                }
                if (UTabsentstatus.Text == "1")
                {
                    WA.Text = "A";
                }
                if (Gradeabsentstatus.Text == "1")
                {
                    Grade.Text = "AB";
                }
                if (lbl_wa_status.Text == "1" && WA.Text == "00")
                {
                    WA.Text = "0";
                }
                if (lbl_ca_status.Text == "1" && CA.Text == "00")
                {
                    CA.Text = "0";
                }
                if (lbl_grade_staus.Text == "1" && Grade.Text == "00")
                {
                    Grade.Text = "0";
                }
                if (lblIsSubSubject.Text == "1")
                {
                    WA.Enabled = false;
                    CA.Enabled = false;
                    Grade.Enabled = false;
                }
                if (lblIsSubSubject.Text == "0")
                {
                    WA.Enabled = true;
                    CA.Enabled = true;
                    Grade.Enabled = true;
                }

                ///////////////////
                if (lblIsGrade.Text == "1")
                {
                    WA.Enabled = false;
                    CA.Enabled = false;
                    Grade.Enabled = true;
                    WA.Text = "";
                    CA.Text = "";
                }
                if (lblIsGrade.Text == "0")
                {
                    WA.Enabled = true;
                    CA.Enabled = true;
                    Grade.Enabled = false;
                    Grade.Text = "";
                }
                if (ut_fm.Text == "0")
                {
                    Gv_subjectwiseStudentlist.Columns[5].Visible = false;
                    //Gv_subjectwiseStudentlist.Columns[6].Visible = true;
                }
                else
                {
                    Gv_subjectwiseStudentlist.Columns[5].Visible = true;
                }
                if (pw_fm.Text == "0")
                {
                    //Gv_subjectwiseStudentlist.Columns[5].Visible = true;
                    Gv_subjectwiseStudentlist.Columns[6].Visible = false;
                }
                else
                {
                    Gv_subjectwiseStudentlist.Columns[6].Visible = true;
                }
                if (ut_fm.Text == "0" && pw_fm.Text == "0")
                {
                    Gv_subjectwiseStudentlist.Columns[5].Visible = false;
                    Gv_subjectwiseStudentlist.Columns[6].Visible = false;
                }
            }
        }
        protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindclasswisesubjectlist(1);
            divsubjectmark.Visible = false;
        }
        protected void Gv_class_exam_subject_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "WA")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_class_exam_subject_list.Rows[i];
                    Label ClassID = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label SecID = (Label)gr.Cells[0].FindControl("lbl_sectionID");
                    Label SubjID = (Label)gr.Cells[0].FindControl("lbl_subjectID");
                    Label ClassName = (Label)gr.Cells[0].FindControl("lbl_classnames");
                    Label subject = (Label)gr.Cells[0].FindControl("lblsubject");
                    Label wa_fm = (Label)gr.Cells[0].FindControl("lbl_WAFM");
                    Label Wa_pm = (Label)gr.Cells[0].FindControl("lbl_WAPM");
                    Label ca_fm = (Label)gr.Cells[0].FindControl("lbl_CAFM");
                    Label ca_pm = (Label)gr.Cells[0].FindControl("lbl_CAPM");

                    lbl_subjectids.Text = SubjID.Text == "" ? "0" : SubjID.Text;
                    lbl_classids.Text = ClassID.Text == "" ? "0" : ClassID.Text;
                    lbl_sectionids.Text = SecID.Text == "" ? "0" : SecID.Text;
                    txt_class.Text = ClassName.Text + "_" + subject.Text;
                    lbl_utfm.Text = wa_fm.Text;
                    lbl_pwfm.Text = ca_fm.Text;

                    int classID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    int ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                    int sectID = Convert.ToInt32(SecID.Text == "" ? "0" : SecID.Text);
                    int SubjectID = Convert.ToInt32(SubjID.Text == "" ? "0" : SubjID.Text);
                    int SessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                    lbl_markingtype.Text = "WA";
                    GetsubjectstudentList(classID, ExamID, sectID, SubjectID, SessionID);
                    divsubject.Visible = false;
                    divsubjectmark.Visible = true;
                    lblNote.Visible = true;
                    lbl_errormessage.Visible = false;
                }
                if (e.CommandName == "CA")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_class_exam_subject_list.Rows[i];
                    Label ClassID = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label SecID = (Label)gr.Cells[0].FindControl("lbl_sectionID");
                    Label SubjID = (Label)gr.Cells[0].FindControl("lbl_subjectID");
                    Label ClassName = (Label)gr.Cells[0].FindControl("lbl_classnames");
                    Label SecName = (Label)gr.Cells[0].FindControl("lblSecName");
                    Label subject = (Label)gr.Cells[0].FindControl("lblsubject");
                    Label wa_fm = (Label)gr.Cells[0].FindControl("lbl_WAFM");
                    Label Wa_pm = (Label)gr.Cells[0].FindControl("lbl_WAPM");
                    Label ca_fm = (Label)gr.Cells[0].FindControl("lbl_CAFM");
                    Label ca_pm = (Label)gr.Cells[0].FindControl("lbl_CAPM");

                    lbl_subjectids.Text = SubjID.Text == "" ? "0" : SubjID.Text;
                    txt_class.Text = ClassName.Text + "_" + subject.Text;
                    lbl_SubjectName.Text = subject.Text == "" ? "All" : subject.Text;
                    lbl_classids.Text = ClassID.Text == "" ? "0" : ClassID.Text;
                    lbl_sectionids.Text = SecID.Text == "" ? "0" : SecID.Text;

                    int classID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    int ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                    int sectID = Convert.ToInt32(SecID.Text == "" ? "0" : SecID.Text);
                    int SubjectID = Convert.ToInt32(SubjID.Text == "" ? "0" : SubjID.Text);
                    int SessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                    lbl_markingtype.Text = "CA";
                    GetsubjectstudentList(classID, ExamID, sectID, SubjectID, SessionID);

                    divsubject.Visible = false;
                    divsubjectmark.Visible = true;
                    lblNote.Visible = true;
                    lbl_errormessage.Visible = false;
                }
                if (e.CommandName == "GRADE")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_class_exam_subject_list.Rows[i];
                    Label ClassID = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label SecID = (Label)gr.Cells[0].FindControl("lbl_sectionID");
                    Label SubjID = (Label)gr.Cells[0].FindControl("lbl_subjectID");
                    Label ClassName = (Label)gr.Cells[0].FindControl("lbl_classnames");
                    Label SecName = (Label)gr.Cells[0].FindControl("lblSecName");
                    Label subject = (Label)gr.Cells[0].FindControl("lblsubject");
                    Label wa_fm = (Label)gr.Cells[0].FindControl("lbl_WAFM");
                    Label Wa_pm = (Label)gr.Cells[0].FindControl("lbl_WAPM");
                    Label ca_fm = (Label)gr.Cells[0].FindControl("lbl_CAFM");
                    Label ca_pm = (Label)gr.Cells[0].FindControl("lbl_CAPM");

                    lbl_subjectids.Text = SubjID.Text == "" ? "0" : SubjID.Text;
                    txt_class.Text = ClassName.Text + ", " + subject.Text;
                    lbl_SubjectName.Text = subject.Text == "" ? "All" : subject.Text;
                    lbl_classids.Text = ClassID.Text == "" ? "0" : ClassID.Text;
                    lbl_sectionids.Text = SecID.Text == "" ? "0" : SecID.Text;

                    int classID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    int ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                    int sectID = Convert.ToInt32(SecID.Text == "" ? "0" : SecID.Text);
                    int SubjectID = Convert.ToInt32(SubjID.Text == "" ? "0" : SubjID.Text);
                    int SessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                    lbl_markingtype.Text = "GRADE";
                    GetsubjectstudentList(classID, ExamID, sectID, SubjectID, SessionID);

                    divsubject.Visible = false;
                    divsubjectmark.Visible = true;
                    lblNote.Visible = true;
                    lbl_errormessage.Visible = false;
                }
                if (e.CommandName == "BS")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_class_exam_subject_list.Rows[i];
                    Label lbl_classid = (Label)gr.Cells[0].FindControl("lbl_classID");
                    //   Label lbl_examid = (Label)gr.Cells[0].FindControl("lbl_examid");
                    Label lbl_sectionid = (Label)gr.Cells[0].FindControl("lbl_sectionID");
                    lbl_errormessage.Visible = false;
                    string classid = lbl_classid.Text;
                    string examid = ddlexam.SelectedValue;
                    string sectionid = ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue;
                    string sessionid = ddlacademicseesions.SelectedValue;
                    String Year = ddlacademicseesions.SelectedItem.Text;
                    string roll = "0";
                    //string rankshow = "0";
                    string url = "../EduReports/Reports/ReportViewer.aspx?option=PrintBroadsheet&Session=" + sessionid + "&ClassID=" + classid + "&SectionID=" + sectionid + "&Roll=" + roll + "&ExamID=" + examid + "&Rankshow=" + 0 + "&Year=" + Year;
                    string fullURL = "window.open('" + url + "', '_blank');";

                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
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
        protected void bindresponsive()
        {
            //Responsive 
            Gv_class_exam_subject_list.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_class_exam_subject_list.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_class_exam_subject_list.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_class_exam_subject_list.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_class_exam_subject_list.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_class_exam_subject_list.UseAccessibleHeader = true;
            Gv_class_exam_subject_list.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        //protected void GvExamdetails_Sorting(object sender, GridViewSortEventArgs e)
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
        //            GvExamdetails.DataSource = sortedView;
        //            GvExamdetails.DataBind();
        //            bindresponsive();
        //            TableCell tableCell = GvExamdetails.HeaderRow.Cells[ColumnIndex];
        //            Image img = new Image();
        //            img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
        //            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
        //            tableCell.Controls.Add(img);


        //        }
        //    }
        //    catch (Exception ex) //Exception in agent layer itself
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
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
        protected void GvExamdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_class_exam_subject_list.PageIndex = e.NewPageIndex;
            // Gv_class_exam_subject_list(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btnsearch_Click1(object sender, EventArgs e)
        {

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            List<ExammarkentryData> lstexamdata = new List<ExammarkentryData>();
            ExammarkentryData objexam = new ExammarkentryData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            int index = 0;
            int PWNoEntryCounts = 0;
            int UTNoEntryCounts = 0;
            int GradeNoEntryCounts = 0;
            int countutoverlimit = 0;
            int countpwoverlimit = 0;
            int countgradeoverlimit = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in Gv_subjectwiseStudentlist.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label StudentID = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_studentID");
                    Label RollNo = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lblrollno");
                    Label PWFM = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_ca_fm");
                    Label PWPM = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_ca_pm");
                    Label UTFM = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_wa_fm");
                    Label UTPM = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_wa_pm");
                    Label S_PW = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_sca");
                    Label S_UT = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_swa");
                    Label S_Grade = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_sgrade");
                    Label wa_entrystatus = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_wa_entrystatus");
                    Label ca_entrystatus = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_ca_entrystatus");
                    Label grade_entrystatus = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_grade_entrystatus");

                    Label pw_absentstatus = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_absentPW");
                    Label ut_absentstatus = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_absentUT");
                    Label grade_absentstatus = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_absentGrade");
                    Label isgradesubject = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("IsGradeSubject");
                    Label TWD = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lblTWD");
                    Label Attendance = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lblAttendance");

                    ExammarkentryData objexamdata = new ExammarkentryData();

                    ////start WA or UT
                    TextBox UT = (TextBox)Gv_subjectwiseStudentlist.Rows[row.RowIndex].Cells[0].FindControl("txt_WA");
                    if (UT.Text.Trim() == "." || UT.Text.Trim() == ".." || UT.Text.Trim() == "..." || UT.Text.Trim() == "...." || UT.Text.Trim() == ".....")
                    {
                        UT.Text = "";
                        UT.BackColor = System.Drawing.Color.Red;
                        UT.Focus();
                        return;
                    }
                    else
                    {
                        UT.BackColor = System.Drawing.Color.White;
                    }
                    UT.Text = UT.Text.Trim().Contains("A") ? "A" : UT.Text.Trim();
                    int count1 = UT.Text.Trim().Contains(".") ? UT.Text.Trim().Split('.').Length - 1 : 0;
                    if (count1 > 1)
                    {
                        UT.Text = "";
                        UT.BackColor = System.Drawing.Color.Red;
                        UT.Focus();
                        return;
                    }
                    else
                    {
                        UT.BackColor = System.Drawing.Color.White;
                    }
                    if (UT.Text.Trim() == "" && Convert.ToInt32(RollNo.Text) > 0)
                    {
                        UTNoEntryCounts = UTNoEntryCounts + 1;
                        objexamdata.ChkUTmarkentry = 0;
                    }
                    else
                    {
                        objexamdata.ChkUTmarkentry = 1;
                    }
                    objexamdata.UT_SM = float.Parse(UT.Text.Trim() == "" || UT.Text.Trim() == "A" ? "0.0" : UT.Text.Trim());
                    objexamdata.IsAbsentUT = UT.Text == "A" ? 1 : 0;
                    if (float.Parse(UT.Text.Trim() == "" || UT.Text.Trim() == "A" ? "0.0" : UT.Text.Trim()) > float.Parse(UTFM.Text == "" ? "0.0" : UTFM.Text))
                    {
                        countutoverlimit = countutoverlimit + 1;
                        UT.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        UT.BackColor = System.Drawing.Color.White;
                    }
                    //  end WA or UT

                    //start PW or CA
                    TextBox PW = (TextBox)Gv_subjectwiseStudentlist.Rows[row.RowIndex].Cells[0].FindControl("txt_CA");
                    if (PW.Text.Trim() == "." || PW.Text.Trim() == ".." || PW.Text.Trim() == "..." || PW.Text.Trim() == "...." || PW.Text.Trim() == ".....")
                    {
                        PW.Text = "";
                        PW.BackColor = System.Drawing.Color.Red;
                        PW.Focus();
                        return;
                    }
                    else
                    {
                        PW.BackColor = System.Drawing.Color.White;
                    }
                    PW.Text = PW.Text.Trim().Contains("A") ? "A" : PW.Text.Trim();
                    int count2 = PW.Text.Trim().Contains(".") ? PW.Text.Trim().Split('.').Length - 1 : 0;
                    if (count2 > 1)
                    {
                        PW.Text = "";
                        PW.BackColor = System.Drawing.Color.Red;
                        PW.Focus();
                        return;
                    }
                    else
                    {
                        PW.BackColor = System.Drawing.Color.White;
                    }
                    if (PW.Text.Trim() == "" && Convert.ToInt32(RollNo.Text) > 0)
                    {
                        PWNoEntryCounts = PWNoEntryCounts + 1;
                        objexamdata.ChkPWmarkentry = 0;
                    }
                    else
                    {
                        objexamdata.ChkPWmarkentry = 1;
                    }

                    objexamdata.PW_SM = float.Parse(PW.Text.Trim() == "" || PW.Text.Trim() == "A" ? "0.0" : PW.Text.Trim());
                    objexamdata.IsAbsentPW = PW.Text == "A" ? 1 : 0;
                    if (float.Parse(PW.Text.Trim() == "" || PW.Text.Trim() == "A" ? "0.0" : PW.Text.Trim()) > float.Parse(PWFM.Text == "" ? "0.0" : PWFM.Text))
                    {
                        countpwoverlimit = countpwoverlimit + 1;
                        PW.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        PW.BackColor = System.Drawing.Color.White;
                    }
                    //End PW or CA

                    //Start Grade
                    TextBox Grade = (TextBox)Gv_subjectwiseStudentlist.Rows[row.RowIndex].Cells[0].FindControl("txt_GRADE");
                    if (Grade.Text.Trim() == "." || Grade.Text.Trim() == ".." || Grade.Text.Trim() == "..." || Grade.Text.Trim() == "...." || Grade.Text.Trim() == ".....")
                    {
                        Grade.Text = "";
                        Grade.BackColor = System.Drawing.Color.Red;
                        Grade.Focus();
                        return;
                    }
                    else
                    {
                        Grade.BackColor = System.Drawing.Color.White;
                    }
                    Grade.Text = Grade.Text.Trim().Contains("AB") ? "AB" : Grade.Text.Trim();
                    int count3 = Grade.Text.Trim().Contains(".") ? Grade.Text.Trim().Split('.').Length - 1 : 0;
                    if (count3 > 1)
                    {
                        Grade.Text = "";
                        Grade.CssClass = "indicator2";
                        Grade.Focus();
                        return;
                    }
                    if (Grade.Text.Trim() == "" && Convert.ToInt32(RollNo.Text) > 0)
                    {
                        GradeNoEntryCounts = GradeNoEntryCounts + 1;
                        objexamdata.ChkGrademarkentry = 0;
                    }
                    else
                    {
                        objexamdata.ChkGrademarkentry = 1;
                    }

                    objexamdata.Grade_SM = Grade.Text.Trim();
                    objexamdata.IsAbsentGrade = Grade.Text == "AB" ? 1 : 0;
                    objexamdata.StudentID = Convert.ToInt32(StudentID.Text == "" ? "0" : StudentID.Text);
                    objexamdata.PW_FM = float.Parse(PWFM.Text == "" ? "0.0" : PWFM.Text);
                    objexamdata.PW_PM = float.Parse(PWPM.Text == "" ? "0.0" : PWPM.Text);
                    objexamdata.UT_FM = float.Parse(UTFM.Text == "" ? "0.0" : UTFM.Text);
                    objexamdata.UT_PM = float.Parse(UTPM.Text == "" ? "0.0" : UTPM.Text);
                    objexamdata.MarkingType = lbl_markingtype.Text;
                    objexamdata.Roll = Convert.ToInt32(RollNo.Text == "" ? "0" : RollNo.Text);
                    lstexamdata.Add(objexamdata);
                    index++;
                }
                objexam.XMLData = XmlConvertor.SubjectWiseMarkstoXML(lstexamdata).ToString();
                objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                objexam.CLassID = Convert.ToInt32(lbl_classids.Text == "" ? "0" : lbl_classids.Text);
                objexam.SectionID = Convert.ToInt32(lbl_sectionids.Text == "" ? "0" : lbl_sectionids.Text);
                objexam.SubjectID = Convert.ToInt32(lbl_subjectids.Text == "" ? "0" : lbl_subjectids.Text);
                objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                objexam.EmployeeID = LoginToken.EmployeeID;
                objexam.CompanyID = LoginToken.CompanyID;
                objexam.PWNoEntryCount = PWNoEntryCounts;
                objexam.UTNoEntryCount = UTNoEntryCounts;
                objexam.GradeNoEntryCount = GradeNoEntryCounts;
                objexam.MarkingType = lbl_markingtype.Text;

                if (countpwoverlimit > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("mark") + "')", true);
                    return;
                }
                if (countutoverlimit > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("mark") + "')", true);
                    return;
                }

                int results = objexamBO.UpdateSubjectWiseExamMarkslist(objexam);
                if (results == 1)
                {
                    bindstudentmarks();
                    getSubjectdetails(1);
                    bindstudentmarks();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
            }

            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void bindstudentmarks()
        {
            int classID = Convert.ToInt32(lbl_classids.Text == "" ? "0" : lbl_classids.Text);
            int ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            int sectID = Convert.ToInt32(lbl_sectionids.Text == "" ? "0" : lbl_sectionids.Text);
            int SubjectID = Convert.ToInt32(lbl_subjectids.Text == "" ? "0" : lbl_subjectids.Text);
            int SessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            GetsubjectstudentList(classID, ExamID, sectID, SubjectID, SessionID);
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            divsubject.Visible = true;
            divsubjectmark.Visible = false;
            lblNote.Visible = false;
            Bindclasswisesubjectlist(1);
        }
        protected void txt_WA_TextChanged(object sender, EventArgs e)
        {
            int Lastindex = Gv_subjectwiseStudentlist.Rows.Count - 1;
            TextBox txt = sender as TextBox;
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;

            if (Lastindex > index)
            {
                TextBox result2 = (TextBox)Gv_subjectwiseStudentlist.Rows[index + 1].Cells[0].FindControl("txt_WA");
                result2.Focus();

            }
            if (Lastindex == index)
            {
                TextBox result2 = (TextBox)Gv_subjectwiseStudentlist.Rows[0].Cells[0].FindControl("txt_CA");
                result2.Focus();
            }

        }
        protected void txt_CA_TextChanged(object sender, EventArgs e)
        {
            int Lastindex = Gv_subjectwiseStudentlist.Rows.Count - 1;
            TextBox txt = sender as TextBox;
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;

            if (Lastindex > index)
            {
                TextBox result2 = (TextBox)Gv_subjectwiseStudentlist.Rows[index + 1].Cells[0].FindControl("txt_CA");
                result2.Focus();

            }
            if (Lastindex == index)
            {
                TextBox result2 = (TextBox)Gv_subjectwiseStudentlist.Rows[0].Cells[0].FindControl("txt_WA");
                result2.Focus();
            }

        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            ////Check that directory with same is exists or not
            //string dirPath = Request.PhysicalApplicationPath + @"Documents/ExcelExamMarks/" + ddlacademicseesions.SelectedItem.Text + "/" + ddlexam.SelectedItem.Text + "/" + ddlclasses.SelectedItem.Text;

            //if (!(Directory.Exists(dirPath)))
            //{
            //    //Creating new directory
            //    Directory.CreateDirectory(dirPath);
            //}
            ExportoExcel();
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Marks");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";

                wb.Worksheet(1).Columns("D").Style.NumberFormat.SetFormat("@");
                wb.Worksheet(1).Columns("E").Style.NumberFormat.SetFormat("@");

                //Set the color of Header Row.
                //A resembles First Column while E resembles Fifth column.
                wb.Worksheet(1).Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    //A resembles First Column while C resembles Third column.
                    //Header row is at Position 1 and hence First row starts from Index 2.
                    string cellRange = string.Format("A{0}:E{0}", i + 1);
                    string ColRange = string.Format("D{0}:E{0}", i + 1);
                    wb.Worksheet(1).Cells(ColRange).Style.NumberFormat.Format.ToString();

                    if (i % 2 != 0)
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.LightGray;
                    }
                    else
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                    }
                }
                //Adjust widths of Columns.
                wb.Worksheet(1).Columns().AdjustToContents();

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Class_" + txt_class.Text + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected DataTable GetDatafromDatabase()
        {
            int classID = Convert.ToInt32(lbl_classids.Text == "" ? "0" : lbl_classids.Text);
            int ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            int sectID = Convert.ToInt32(lbl_sectionids.Text == "" ? "0" : lbl_sectionids.Text);
            int SubjectID = Convert.ToInt32(lbl_subjectids.Text == "" ? "0" : lbl_subjectids.Text);
            int SessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            //string Section = Convert.To

            List<ExammarkentryData> studentdetails = getSubjectStudentList(classID, ExamID, sectID, SubjectID, SessionID);
            List<ExcelExamMark> listecelstd = new List<ExcelExamMark>();
            int i = 0;
            foreach (ExammarkentryData row in studentdetails)
            {
                ExcelExamMark EcxeclStd = new ExcelExamMark();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.RollNo = studentdetails[i].Roll;
                EcxeclStd.Scored_Marks = Convert.ToString(studentdetails[i].UT_SM);
                listecelstd.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(listecelstd);
            return dt;
        }
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
        public List<ExammarkentryData> getSubjectStudentList(int classID, int ExamID, int sectID, int SubjectID, int SessionID)
        {
            ExammarkentryData objexam = new ExammarkentryData();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.CLassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(lbl_sectionids.Text == "" ? "0" : lbl_sectionids.Text);
            objexam.SubjectID = Convert.ToInt32(lbl_subjectids.Text == "" ? "0" : lbl_subjectids.Text);
            objexam.Roll = 0; // Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            return objexamBO.Getsubjectwisestudentlist(objexam);
        }
        //Import
        protected void btnImport_Click(object sender, EventArgs e)
        {
            //HttpPostedFile fileName = fileimport.PostedFile;
            if (!fileUploadBtn.HasFile)
            {
                lbl_errormessage.Visible = true;
                lbl_errormessage.Text = "Please select file and try.";
                lbl_errormessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                var fileName = fileUploadBtn.FileName.ToString();
                var currentfilename = "Class_" + txt_class.Text + ".xlsx";
                if (fileName != currentfilename)
                {
                    lbl_errormessage.Visible = true;
                    lbl_errormessage.Text = "Please name file as " + currentfilename;
                    lbl_errormessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    lbl_errormessage.Visible = false;
                }
                string extension = Path.GetExtension(fileUploadBtn.PostedFile.FileName);
                string rootFilePath = Request.PhysicalApplicationPath + @"Documents/ExcelExamMarks/";
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
                OleDbCommand oconn = new OleDbCommand("Select * From [Marks$]", con);
                con.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(oconn);
                da.Fill(ds);

                DataTable table = ds.Tables[0];
                int columnCount = Gv_subjectwiseStudentlist.Columns.Count;
                int rowCount = Gv_subjectwiseStudentlist.Rows.Count;
                Gv_subjectwiseStudentlist.AutoGenerateColumns = false;
                int index = 0;
                foreach (DataRow row in table.Rows)
                {
                    Label StdID = (Label)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("lbl_studentID");
                    string StudentID = StdID.Text.ToString();

                    TextBox UT = (TextBox)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("txt_WA");  //WA
                    TextBox PW = (TextBox)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("txt_CA");  //CA
                    TextBox HA = (TextBox)Gv_subjectwiseStudentlist.Rows[index].Cells[0].FindControl("txt_HA");

                    string ExStdID = table.Rows[index]["StudentID"].ToString().Trim();

                    if (StudentID.Equals(ExStdID.ToString().Trim()))
                    {
                        string SUTMark = table.Rows[index]["Scored_Marks"].ToString().Trim();
                        //string SPWMark = table.Rows[index]["Oral_Marks"].ToString().Trim();
                        UT.Text = SUTMark;
                        //PW.Text = SPWMark;
                        lbl_errormessage.Visible = false;
                    }
                    else
                    {
                        lbl_errormessage.Visible = true;
                        lbl_errormessage.Text = "Uploaded file is not correct for these student list. Please export the file and update the marks. Try again.";
                        lbl_errormessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    index++;
                }
                Gv_subjectwiseStudentlist.DataSource = table;
                //Gv_subjectwiseStudentlist.DataBind();
                lbl_errormessage.Visible = true;
                lbl_errormessage.Text = "Data has successfully imported.";
                lbl_errormessage.ForeColor = System.Drawing.Color.DarkGreen;
                da.Dispose();
                da.Dispose();
                con.Close();
                con.Dispose();
                GC.Collect();
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
            }
        }
    }
}