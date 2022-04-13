using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;

namespace Mobimp.Edusoft.Web.EduReports
{
    public partial class DeleveryProgressReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddldeliveryclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;

        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
        }
        protected void ddldeliveryclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddldeliverysection, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddldeliveryclass.SelectedValue == "" ? "0" : ddldeliveryclass.SelectedValue)));
            Commonfunction.PopulateDdl(ddldeliveryexams, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddldeliveryclass.SelectedValue == "" ? "0" : ddldeliveryclass.SelectedValue)));
        }
        protected void Btncreate_Click(object sender, EventArgs e)
        {
            getstudentmarksdetails();
        }
        protected void getstudentmarksdetails()
        {
            ExamMarksData objexammarks = new ExamMarksData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexammarks.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexammarks.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexammarks.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexammarks.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objexammarks.AcademicSessionID = LoginToken.AcademicSessionID;
            List<ExamMarksData> result = objexamBO.CreateProgressReport(objexammarks);
            if (result.Count > 0)
            {
                GvExamdetails.DataSource = result;
                GvExamdetails.DataBind();
                GvExamdetails.Visible = true;
                btnupdate.Enabled = true;
            }
            else
            {
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
                GvExamdetails.Visible = true;
                btnupdate.Enabled = false;
            }
        }
        protected void GvExamdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvExamdetails.Rows)
            {
                try
                {

                    Label IspEnglish = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisdEngpass");
                    Label IspAdEnglish = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisAdEngpass");
                    Label IspMeiteiMayek = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblMpass");
                    Label IspHindi = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblhpass");
                    Label IspMaths = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisMathsgpass");
                    Label IspPhysics = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisPhysicsgpass");
                    Label IspChemistry = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblischempass");
                    Label IspBiology = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisbiopass");
                    Label IspHistory = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisHistorygpass");
                    Label IspGeography = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisGeogpass");
                    Label IspCivics = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lbliscivicsgpass");
                    Label IspHrMaths = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisHrmathspass");
                    Label IspCommerce = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblcommpass");
                    Label IspComputer = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lbliscomppass");
                    Label IspHomescience = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblishomescgpass");
                    Label IspRhyme = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisrhympass");
                    Label IspCursive = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lbliscursivepass");
                    Label IspDrawing = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisdrwagpass");
                    Label IspGK = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisgkgpass");
                    Label IspScience = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblisScpass");
                    Label IspSocience = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblissocpass");
                    Label IspMSocience = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblismoralscpass");
                    Label lblstatus = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblstatus");
                    Label lbloptionalsubjectID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lbloptionalsubjectID");
                    Label lblalternativeSubjectID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblalternativeSubjectID");
                    Label lblrank = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblrank");
                    Label lbltotal = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lbltotal");
                    Label lblmarksobtain = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblmarksobtain");
                    Label lblPC = (Label)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("lblPC");



                    TextBox English = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtenglish");
                    TextBox AdEnglish = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtaddenglish");
                    TextBox MeiteiMayek = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtmeiteimayek");
                    TextBox Hindi = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtHindi");
                    TextBox Maths = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtmaths");
                    TextBox Physics = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtphysics");
                    TextBox Chemistry = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtchemistry");
                    TextBox Biology = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtbiology");
                    TextBox History = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txthistory");
                    TextBox Geography = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtgeo");
                    TextBox Civics = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtcivics");
                    TextBox HrMaths = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtHmaths");
                    TextBox Commerce = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtcommerce");
                    TextBox Computer = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtcomputer");
                    TextBox Homescience = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txthomescience");
                    TextBox Rhyme = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtrhyme");
                    TextBox Cursive = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtcursive");
                    TextBox Drawing = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtdrawing");
                    TextBox GK = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtGK");
                    TextBox Science = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtScience");
                    TextBox SocialScience = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtsocialscience");
                    TextBox MoralsScience = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtmoralscience");

                    lblPC.Text = Commonfunction.Getrounding(((Convert.ToDecimal(lblmarksobtain.Text) / Convert.ToDecimal(lbltotal.Text)) * 100).ToString());
                    if (lblrank.Text == "50000")
                    {
                        lblrank.Text = "";
                    }
                    if (Convert.ToInt32(IspEnglish.Text) == 1)
                    {
                        English.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspEnglish.Text) == 2)
                    {
                        English.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspAdEnglish.Text) == 1)
                    {
                        AdEnglish.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspAdEnglish.Text) == 2)
                    {
                        AdEnglish.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspBiology.Text) == 1)
                    {
                        Biology.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspBiology.Text) == 2)
                    {
                        Biology.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspChemistry.Text) == 1)
                    {
                        Chemistry.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspChemistry.Text) == 2)
                    {
                        Chemistry.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspPhysics.Text) == 1)
                    {
                        Physics.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspPhysics.Text) == 2)
                    {
                        Physics.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspMeiteiMayek.Text) == 1)
                    {
                        MeiteiMayek.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspMeiteiMayek.Text) == 2)
                    {
                        MeiteiMayek.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHindi.Text) == 1)
                    {
                        Hindi.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHindi.Text) == 2)
                    {
                        Hindi.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspMaths.Text) == 1)
                    {
                        Maths.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspMaths.Text) == 2)
                    {
                        Maths.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspCursive.Text) == 1)
                    {
                        Cursive.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspCursive.Text) == 2)
                    {
                        Cursive.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspDrawing.Text) == 1)
                    {
                        Drawing.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspDrawing.Text) == 2)
                    {
                        Drawing.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspGK.Text) == 1)
                    {
                        GK.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspGK.Text) == 2)
                    {
                        GK.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspScience.Text) == 1)
                    {
                        Science.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspScience.Text) == 2)
                    {
                        Science.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspSocience.Text) == 1)
                    {
                        SocialScience.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspSocience.Text) == 2)
                    {
                        SocialScience.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHistory.Text) == 1)
                    {
                        History.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHistory.Text) == 2)
                    {
                        History.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspGeography.Text) == 1)
                    {
                        Geography.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspGeography.Text) == 2)
                    {
                        Geography.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspCivics.Text) == 1)
                    {
                        Civics.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspCivics.Text) == 2)
                    {
                        Civics.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHrMaths.Text) == 1)
                    {
                        HrMaths.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHrMaths.Text) == 2)
                    {
                        HrMaths.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspCommerce.Text) == 1)
                    {
                        Commerce.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspCommerce.Text) == 2)
                    {
                        Commerce.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspComputer.Text) == 1)
                    {
                        Computer.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspComputer.Text) == 2)
                    {
                        Computer.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHomescience.Text) == 1)
                    {
                        Homescience.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHomescience.Text) == 2)
                    {
                        Homescience.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspMSocience.Text) == 1)
                    {
                        MoralsScience.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspMSocience.Text) == 2)
                    {
                        MoralsScience.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspRhyme.Text) == 1)
                    {
                        Rhyme.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspRhyme.Text) == 2)
                    {
                        Rhyme.CssClass = "indicator2";
                    }
                    if (lblstatus.Text == "Pass")
                    {
                        lblstatus.CssClass = "indicator";
                    }
                    else if (lblstatus.Text == "Fail")
                    {
                        lblstatus.CssClass = "indicator2";
                    }
                    Label lblclasID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[2].FindControl("lblclassID");
                    if (lblclasID.Text == "1" || lblclasID.Text == "2")
                    {
                        GvExamdetails.Columns[5].Visible = true;
                        GvExamdetails.Columns[7].Visible = true;
                        GvExamdetails.Columns[9].Visible = true;
                        GvExamdetails.Columns[20].Visible = true;
                        GvExamdetails.Columns[21].Visible = true;
                        GvExamdetails.Columns[22].Visible = true;

                        GvExamdetails.Columns[6].Visible = false;
                        GvExamdetails.Columns[8].Visible = false;
                        GvExamdetails.Columns[10].Visible = false;
                        GvExamdetails.Columns[11].Visible = false;
                        GvExamdetails.Columns[12].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[15].Visible = false;
                        GvExamdetails.Columns[16].Visible = false;
                        GvExamdetails.Columns[17].Visible = false;
                        GvExamdetails.Columns[18].Visible = false;
                        GvExamdetails.Columns[19].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[25].Visible = false;
                        GvExamdetails.Columns[24].Visible = false;
                        GvExamdetails.Columns[26].Visible = false;
                    }

                    if (lblclasID.Text == "3")
                    {
                        GvExamdetails.Columns[5].Visible = true;
                        GvExamdetails.Columns[7].Visible = true;
                        GvExamdetails.Columns[9].Visible = true;
                        GvExamdetails.Columns[24].Visible = true;
                        GvExamdetails.Columns[26].Visible = true;

                        GvExamdetails.Columns[6].Visible = false;
                        GvExamdetails.Columns[8].Visible = false;
                        GvExamdetails.Columns[10].Visible = false;
                        GvExamdetails.Columns[11].Visible = false;
                        GvExamdetails.Columns[12].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[15].Visible = false;
                        GvExamdetails.Columns[16].Visible = false;
                        GvExamdetails.Columns[17].Visible = false;
                        GvExamdetails.Columns[18].Visible = false;
                        GvExamdetails.Columns[19].Visible = false;
                        GvExamdetails.Columns[20].Visible = false;
                        GvExamdetails.Columns[21].Visible = false;
                        GvExamdetails.Columns[22].Visible = false;
                        GvExamdetails.Columns[23].Visible = false;
                        GvExamdetails.Columns[25].Visible = false;
                    }
                    if (lblclasID.Text == "4")
                    {
                        GvExamdetails.Columns[5].Visible = true;
                        GvExamdetails.Columns[7].Visible = true;
                        GvExamdetails.Columns[9].Visible = true;
                        GvExamdetails.Columns[19].Visible = true;
                        GvExamdetails.Columns[23].Visible = true;
                        GvExamdetails.Columns[24].Visible = true;
                        GvExamdetails.Columns[26].Visible = true;

                        GvExamdetails.Columns[8].Visible = false;
                        GvExamdetails.Columns[10].Visible = false;
                        GvExamdetails.Columns[11].Visible = false;
                        GvExamdetails.Columns[12].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[15].Visible = false;
                        GvExamdetails.Columns[16].Visible = false;
                        GvExamdetails.Columns[17].Visible = false;
                        GvExamdetails.Columns[18].Visible = false;
                        GvExamdetails.Columns[19].Visible = false;
                        GvExamdetails.Columns[20].Visible = false;
                        GvExamdetails.Columns[21].Visible = false;
                        GvExamdetails.Columns[6].Visible = false;
                        GvExamdetails.Columns[22].Visible = false;
                        GvExamdetails.Columns[25].Visible = false;

                    }

                    if (lblclasID.Text == "5" || lblclasID.Text == "6" || lblclasID.Text == "7")
                    {
                        GvExamdetails.Columns[5].Visible = true;
                        GvExamdetails.Columns[7].Visible = true;
                        GvExamdetails.Columns[8].Visible = true;
                        GvExamdetails.Columns[9].Visible = true;
                        GvExamdetails.Columns[19].Visible = true;
                        GvExamdetails.Columns[13].Visible = true;
                        GvExamdetails.Columns[23].Visible = true;
                        GvExamdetails.Columns[24].Visible = true;
                        GvExamdetails.Columns[26].Visible = true;

                        GvExamdetails.Columns[22].Visible = false;
                        GvExamdetails.Columns[6].Visible = false;
                        GvExamdetails.Columns[10].Visible = false;
                        GvExamdetails.Columns[11].Visible = false;
                        GvExamdetails.Columns[12].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[15].Visible = false;
                        GvExamdetails.Columns[16].Visible = false;
                        GvExamdetails.Columns[17].Visible = false;
                        GvExamdetails.Columns[18].Visible = false;
                        GvExamdetails.Columns[19].Visible = false;
                        GvExamdetails.Columns[20].Visible = false;
                        GvExamdetails.Columns[21].Visible = false;
                        GvExamdetails.Columns[25].Visible = false;

                    }
                    if (lblclasID.Text == "8" || lblclasID.Text == "9" || lblclasID.Text == "10")
                    {
                        GvExamdetails.Columns[5].Visible = true;
                        GvExamdetails.Columns[7].Visible = true;
                        GvExamdetails.Columns[8].Visible = true;
                        GvExamdetails.Columns[9].Visible = true;
                        GvExamdetails.Columns[19].Visible = true;
                        GvExamdetails.Columns[23].Visible = true;
                        GvExamdetails.Columns[24].Visible = true;
                        GvExamdetails.Columns[25].Visible = true;


                        GvExamdetails.Columns[10].Visible = false;
                        GvExamdetails.Columns[6].Visible = false;
                        GvExamdetails.Columns[11].Visible = false;
                        GvExamdetails.Columns[12].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[15].Visible = false;
                        GvExamdetails.Columns[16].Visible = false;
                        GvExamdetails.Columns[17].Visible = false;
                        GvExamdetails.Columns[18].Visible = false;
                        GvExamdetails.Columns[19].Visible = false;
                        GvExamdetails.Columns[20].Visible = false;
                        GvExamdetails.Columns[21].Visible = false;
                        GvExamdetails.Columns[22].Visible = false;
                        GvExamdetails.Columns[26].Visible = false;
                    }

                    if (lblclasID.Text == "11" || lblclasID.Text == "12")
                    {
                        GvExamdetails.Columns[5].Visible = true;
                        GvExamdetails.Columns[6].Visible = true;
                        GvExamdetails.Columns[7].Visible = true;
                        GvExamdetails.Columns[9].Visible = true;

                        GvExamdetails.Columns[19].Visible = true;
                        GvExamdetails.Columns[24].Visible = true;
                        GvExamdetails.Columns[8].Visible = false;
                        GvExamdetails.Columns[25].Visible = true;
                        GvExamdetails.Columns[10].Visible = false;
                        GvExamdetails.Columns[11].Visible = false;
                        GvExamdetails.Columns[12].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[15].Visible = false;
                        GvExamdetails.Columns[16].Visible = true;
                        GvExamdetails.Columns[17].Visible = true;
                        GvExamdetails.Columns[18].Visible = true;
                        GvExamdetails.Columns[19].Visible = true;
                        GvExamdetails.Columns[20].Visible = false;
                        GvExamdetails.Columns[21].Visible = false;
                        GvExamdetails.Columns[22].Visible = false;
                        GvExamdetails.Columns[23].Visible = false;

                        if (lblalternativeSubjectID.Text == "67" || lblalternativeSubjectID.Text == "77")
                        {
                            MeiteiMayek.Enabled = true;
                            AdEnglish.Enabled = false;
                            AdEnglish.CssClass = "Label3";
                            AdEnglish.Text = "";
                        }
                        else if (lblalternativeSubjectID.Text == "69" || lblalternativeSubjectID.Text == "79")
                        {
                            MeiteiMayek.Enabled = false;
                            MeiteiMayek.CssClass = "Label3";
                            AdEnglish.Enabled = true;
                            MeiteiMayek.Text = "";
                        }
                        if (lbloptionalsubjectID.Text == "72" || lbloptionalsubjectID.Text == "82")
                        {
                            HrMaths.Enabled = true;
                            Commerce.Enabled = false;
                            Computer.Enabled = false;
                            Homescience.Enabled = false;

                            Commerce.CssClass = "Label3";
                            Computer.CssClass = "Label3";
                            Homescience.CssClass = "Label3";
                            Computer.Text = "";
                            Commerce.Text = "";
                            Homescience.Text = "";
                        }
                        else if (lbloptionalsubjectID.Text == "73" || lbloptionalsubjectID.Text == "83")
                        {
                            HrMaths.Enabled = false;
                            Commerce.Enabled = false;
                            Computer.Enabled = false;
                            Homescience.Enabled = true;

                            HrMaths.CssClass = "Label3";
                            Computer.CssClass = "Label3";
                            Commerce.CssClass = "Label3";
                            HrMaths.Text = "";
                            Computer.Text = "";
                            Commerce.Text = "";
                        }
                        else if (lbloptionalsubjectID.Text == "74" || lbloptionalsubjectID.Text == "84")
                        {
                            HrMaths.Enabled = false;
                            Commerce.Enabled = true;
                            Computer.Enabled = false;
                            Homescience.Enabled = false;

                            HrMaths.CssClass = "Label3";
                            Computer.CssClass = "Label3";
                            Homescience.CssClass = "Label3";
                            HrMaths.Text = "";
                            Computer.Text = "";
                            Homescience.Text = "";
                        }
                        else if (lbloptionalsubjectID.Text == "75" || lbloptionalsubjectID.Text == "85")
                        {
                            HrMaths.Enabled = false;
                            Commerce.Enabled = false;
                            Computer.Enabled = true;
                            Homescience.Enabled = false;

                            HrMaths.CssClass = "Label3";
                            Commerce.CssClass = "Label3";
                            Homescience.CssClass = "Label3";

                            HrMaths.Text = "";
                            Commerce.Text = "";
                            Homescience.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {

            List<ExamMarksData> lstmarks = new List<ExamMarksData>();
            ExamMarksData objstd = new ExamMarksData();
            ExamTypeBO objstdBO = new ExamTypeBO();

            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvExamdetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label ExamID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblexamID");
                    Label ID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("ID");
                    Label StudentID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblstudentID");
                    Label ClassID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblclassID");
                    Label PC = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblPC");
                    TextBox Remarks = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[1].FindControl("txtremarks");
                    ExamMarksData ObjDetails = new ExamMarksData();
                    ObjDetails.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    ObjDetails.StudentID = Convert.ToInt32(StudentID.Text == "" ? "0" : StudentID.Text);
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    ObjDetails.ExamID = Convert.ToInt32(ExamID.Text == "" ? "0" : ExamID.Text);
                    ObjDetails.Pc = Convert.ToDouble(PC.Text == "" ? "0" : PC.Text);
                    ObjDetails.Remarks = Remarks.Text;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                    ObjDetails.AddedBy = LoginToken.LoginId;

                    lstmarks.Add(ObjDetails);

                }

                objstd.XmlMarksdetaillist = XmlConvertor.StudentProgresslisttoXML(lstmarks).ToString();

                objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
                objstd.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                objstd.AcademicSessionID = LoginToken.AcademicSessionID;
                int results = objstdBO.UpdateProgressReport(objstd);
                if (results == 1)
                {
                    getstudentmarksdetails();
                    Messagealert_.ShowMessage(lblmessage, "update", 1);
                }
                else if (results == 5)
                {
                    getstudentmarksdetails();
                    Messagealert_.ShowMessage(lblmessage, "duplicate", 0);
                }
                else
                {
                    Messagealert_.ShowMessage(lblmessage, "Error", 0);
                }
            }
            catch (Exception ex)
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            resetall();
        }
        protected void resetall()
        {
            ddlclasses.SelectedIndex = 0;
            ddlsections.SelectedIndex = 0;
            ddlexam.SelectedIndex = 0;
            txtrollNo.Text = "";
            GvExamdetails.DataSource = null;
            GvExamdetails.DataBind();
            GvExamdetails.Visible = false;
            btnupdate.Enabled = false;
            lblmessage.Visible = false;
        }
        protected void btndelivery_Click(object sender, EventArgs e)
        {
            ExamMarksData objexammarks = new ExamMarksData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexammarks.ClassID = Convert.ToInt32(ddldeliveryclass.SelectedValue == "" ? "0" : ddldeliveryclass.SelectedValue);
            objexammarks.SectionID = Convert.ToInt32(ddldeliverysection.SelectedValue == "" ? "0" : ddldeliverysection.SelectedValue);
            objexammarks.ExamID = Convert.ToInt32(ddldeliveryexams.SelectedValue == "" ? "0" : ddldeliveryexams.SelectedValue);
            objexammarks.RollNo = Convert.ToInt32(txtdeliveryrolls.Text == "" ? "0" : txtdeliveryrolls.Text);
            objexammarks.AcademicSessionID = LoginToken.AcademicSessionID;
            objexammarks.AddedBy = LoginToken.LoginId;

          List<ExamMarksData> result = objexamBO.DeliveryProgressReport(objexammarks);
            if (result.Count > 0)
            {
                GvdeliveryProgressReport.DataSource = result;
                GvdeliveryProgressReport.DataBind();
                GvdeliveryProgressReport.Visible = true;
                btnprint.Enabled = true;
            }
            else
            {
                GvdeliveryProgressReport.DataSource = null;
                GvdeliveryProgressReport.DataBind();
                GvExamdetails.Visible = true;
                btnprint.Enabled = false;

            }
        }
        protected void GvdeliveryProgressReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvdeliveryProgressReport.Rows)
            {
                try
                {

                    Label IspEnglish = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisdEngpass");
                    Label IspAdEnglish = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisAdEngpass");
                    Label IspMeiteiMayek = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblMpass");
                    Label IspHindi = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblhpass");
                    Label IspMaths = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisMathsgpass");
                    Label IspPhysics = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisPhysicsgpass");
                    Label IspChemistry = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblischempass");
                    Label IspBiology = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisbiopass");
                    Label IspHistory = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisHistorygpass");
                    Label IspGeography = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisGeogpass");
                    Label IspCivics = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lbliscivicsgpass");
                    Label IspHrMaths = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisHrmathspass");
                    Label IspCommerce = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblcommpass");
                    Label IspComputer = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lbliscomppass");
                    Label IspHomescience = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblishomescgpass");
                    Label IspRhyme = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisrhympass");
                    Label IspCursive = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lbliscursivepass");
                    Label IspDrawing = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisdrwagpass");
                    Label IspGK = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisgkgpass");
                    Label IspScience = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblisScpass");
                    Label IspSocience = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblissocpass");
                    Label IspMSocience = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblismoralscpass");
                    Label lblstatus = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblstatus");
                    Label lbloptionalsubjectID = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lbloptionalsubjectID");
                    Label lblalternativeSubjectID = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblalternativeSubjectID");
                    Label lblrank = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblrank");
                    Label lbltotal = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lbltotal");
                    Label lblmarksobtain = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblmarksobtain");
                    Label lblPC = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("lblPC");



                    TextBox English = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtenglish");
                    TextBox AdEnglish = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtaddenglish");
                    TextBox MeiteiMayek = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtmeiteimayek");
                    TextBox Hindi = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtHindi");
                    TextBox Maths = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtmaths");
                    TextBox Physics = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtphysics");
                    TextBox Chemistry = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtchemistry");
                    TextBox Biology = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtbiology");
                    TextBox History = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txthistory");
                    TextBox Geography = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtgeo");
                    TextBox Civics = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtcivics");
                    TextBox HrMaths = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtHmaths");
                    TextBox Commerce = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtcommerce");
                    TextBox Computer = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtcomputer");
                    TextBox Homescience = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txthomescience");
                    TextBox Rhyme = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtrhyme");
                    TextBox Cursive = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtcursive");
                    TextBox Drawing = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtdrawing");
                    TextBox GK = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtGK");
                    TextBox Science = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtScience");
                    TextBox SocialScience = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtsocialscience");
                    TextBox MoralsScience = (TextBox)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[1].FindControl("txtmoralscience");
                    if (lblrank.Text == "50000")
                    {
                        lblrank.Text = "";
                    }
                    if (Convert.ToInt32(IspEnglish.Text) == 1)
                    {
                        English.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspEnglish.Text) == 2)
                    {
                        English.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspAdEnglish.Text) == 1)
                    {
                        AdEnglish.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspAdEnglish.Text) == 2)
                    {
                        AdEnglish.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspBiology.Text) == 1)
                    {
                        Biology.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspBiology.Text) == 2)
                    {
                        Biology.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspChemistry.Text) == 1)
                    {
                        Chemistry.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspChemistry.Text) == 2)
                    {
                        Chemistry.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspPhysics.Text) == 1)
                    {
                        Physics.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspPhysics.Text) == 2)
                    {
                        Physics.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspMeiteiMayek.Text) == 1)
                    {
                        MeiteiMayek.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspMeiteiMayek.Text) == 2)
                    {
                        MeiteiMayek.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHindi.Text) == 1)
                    {
                        Hindi.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHindi.Text) == 2)
                    {
                        Hindi.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspMaths.Text) == 1)
                    {
                        Maths.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspMaths.Text) == 2)
                    {
                        Maths.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspCursive.Text) == 1)
                    {
                        Cursive.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspCursive.Text) == 2)
                    {
                        Cursive.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspDrawing.Text) == 1)
                    {
                        Drawing.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspDrawing.Text) == 2)
                    {
                        Drawing.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspGK.Text) == 1)
                    {
                        GK.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspGK.Text) == 2)
                    {
                        GK.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspScience.Text) == 1)
                    {
                        Science.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspScience.Text) == 2)
                    {
                        Science.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspSocience.Text) == 1)
                    {
                        SocialScience.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspSocience.Text) == 2)
                    {
                        SocialScience.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHistory.Text) == 1)
                    {
                        History.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHistory.Text) == 2)
                    {
                        History.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspGeography.Text) == 1)
                    {
                        Geography.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspGeography.Text) == 2)
                    {
                        Geography.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspCivics.Text) == 1)
                    {
                        Civics.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspCivics.Text) == 2)
                    {
                        Civics.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHrMaths.Text) == 1)
                    {
                        HrMaths.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHrMaths.Text) == 2)
                    {
                        HrMaths.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspCommerce.Text) == 1)
                    {
                        Commerce.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspCommerce.Text) == 2)
                    {
                        Commerce.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspComputer.Text) == 1)
                    {
                        Computer.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspComputer.Text) == 2)
                    {
                        Computer.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspHomescience.Text) == 1)
                    {
                        Homescience.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspHomescience.Text) == 2)
                    {
                        Homescience.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspMSocience.Text) == 1)
                    {
                        MoralsScience.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspMSocience.Text) == 2)
                    {
                        MoralsScience.CssClass = "indicator2";
                    }
                    if (Convert.ToInt32(IspRhyme.Text) == 1)
                    {
                        Rhyme.CssClass = "indicator";
                    }
                    else if (Convert.ToInt32(IspRhyme.Text) == 2)
                    {
                        Rhyme.CssClass = "indicator2";
                    }
                    if (lblstatus.Text == "Pass")
                    {
                        lblstatus.CssClass = "indicator";
                    }
                    else if (lblstatus.Text == "Fail")
                    {
                        lblstatus.CssClass = "indicator2";
                    }
                    Label lblclasID = (Label)GvdeliveryProgressReport.Rows[row.RowIndex].Cells[2].FindControl("lblclassID");
                    if (lblclasID.Text == "1" || lblclasID.Text == "2")
                    {
                        GvdeliveryProgressReport.Columns[5].Visible = true;
                        GvdeliveryProgressReport.Columns[7].Visible = true;
                        GvdeliveryProgressReport.Columns[9].Visible = true;
                        GvdeliveryProgressReport.Columns[20].Visible = true;
                        GvdeliveryProgressReport.Columns[21].Visible = true;
                        GvdeliveryProgressReport.Columns[22].Visible = true;

                        GvdeliveryProgressReport.Columns[6].Visible = false;
                        GvdeliveryProgressReport.Columns[8].Visible = false;
                        GvdeliveryProgressReport.Columns[10].Visible = false;
                        GvdeliveryProgressReport.Columns[11].Visible = false;
                        GvdeliveryProgressReport.Columns[12].Visible = false;
                        GvdeliveryProgressReport.Columns[13].Visible = false;
                        GvdeliveryProgressReport.Columns[14].Visible = false;
                        GvdeliveryProgressReport.Columns[15].Visible = false;
                        GvdeliveryProgressReport.Columns[16].Visible = false;
                        GvdeliveryProgressReport.Columns[17].Visible = false;
                        GvdeliveryProgressReport.Columns[18].Visible = false;
                        GvdeliveryProgressReport.Columns[19].Visible = false;
                        GvdeliveryProgressReport.Columns[13].Visible = false;
                        GvdeliveryProgressReport.Columns[14].Visible = false;
                        GvdeliveryProgressReport.Columns[25].Visible = false;
                        GvdeliveryProgressReport.Columns[24].Visible = false;
                        GvdeliveryProgressReport.Columns[26].Visible = false;
                    }

                    if (lblclasID.Text == "3")
                    {
                        GvdeliveryProgressReport.Columns[5].Visible = true;
                        GvdeliveryProgressReport.Columns[7].Visible = true;
                        GvdeliveryProgressReport.Columns[9].Visible = true;
                        GvdeliveryProgressReport.Columns[24].Visible = true;
                        GvdeliveryProgressReport.Columns[26].Visible = true;

                        GvdeliveryProgressReport.Columns[6].Visible = false;
                        GvdeliveryProgressReport.Columns[8].Visible = false;
                        GvdeliveryProgressReport.Columns[10].Visible = false;
                        GvdeliveryProgressReport.Columns[11].Visible = false;
                        GvdeliveryProgressReport.Columns[12].Visible = false;
                        GvdeliveryProgressReport.Columns[13].Visible = false;
                        GvdeliveryProgressReport.Columns[14].Visible = false;
                        GvdeliveryProgressReport.Columns[15].Visible = false;
                        GvdeliveryProgressReport.Columns[16].Visible = false;
                        GvdeliveryProgressReport.Columns[17].Visible = false;
                        GvdeliveryProgressReport.Columns[18].Visible = false;
                        GvdeliveryProgressReport.Columns[19].Visible = false;
                        GvdeliveryProgressReport.Columns[20].Visible = false;
                        GvdeliveryProgressReport.Columns[21].Visible = false;
                        GvdeliveryProgressReport.Columns[22].Visible = false;
                        GvdeliveryProgressReport.Columns[23].Visible = false;
                        GvdeliveryProgressReport.Columns[25].Visible = false;


                    }
                    if (lblclasID.Text == "4")
                    {
                        GvExamdetails.Columns[5].Visible = true;
                        GvExamdetails.Columns[7].Visible = true;
                        GvExamdetails.Columns[9].Visible = true;
                        GvExamdetails.Columns[19].Visible = true;
                        GvExamdetails.Columns[23].Visible = true;
                        GvExamdetails.Columns[24].Visible = true;
                        GvExamdetails.Columns[26].Visible = true;

                        GvExamdetails.Columns[8].Visible = false;
                        GvExamdetails.Columns[10].Visible = false;
                        GvExamdetails.Columns[11].Visible = false;
                        GvExamdetails.Columns[12].Visible = false;
                        GvExamdetails.Columns[13].Visible = false;
                        GvExamdetails.Columns[14].Visible = false;
                        GvExamdetails.Columns[15].Visible = false;
                        GvExamdetails.Columns[16].Visible = false;
                        GvExamdetails.Columns[17].Visible = false;
                        GvExamdetails.Columns[18].Visible = false;
                        GvExamdetails.Columns[19].Visible = false;
                        GvExamdetails.Columns[20].Visible = false;
                        GvExamdetails.Columns[21].Visible = false;
                        GvExamdetails.Columns[6].Visible = false;
                        GvExamdetails.Columns[22].Visible = false;
                        GvExamdetails.Columns[25].Visible = false;

                    }

                    if (lblclasID.Text == "5" || lblclasID.Text == "6" || lblclasID.Text == "7")
                    {
                        GvdeliveryProgressReport.Columns[5].Visible = true;
                        GvdeliveryProgressReport.Columns[7].Visible = true;
                        GvdeliveryProgressReport.Columns[8].Visible = true;
                        GvdeliveryProgressReport.Columns[9].Visible = true;
                        GvdeliveryProgressReport.Columns[19].Visible = true;
                        GvdeliveryProgressReport.Columns[13].Visible = true;
                        GvdeliveryProgressReport.Columns[23].Visible = true;
                        GvdeliveryProgressReport.Columns[24].Visible = true;
                        GvdeliveryProgressReport.Columns[26].Visible = true;

                        GvdeliveryProgressReport.Columns[22].Visible = false;
                        GvdeliveryProgressReport.Columns[6].Visible = false;
                        GvdeliveryProgressReport.Columns[10].Visible = false;
                        GvdeliveryProgressReport.Columns[11].Visible = false;
                        GvdeliveryProgressReport.Columns[12].Visible = false;
                        GvdeliveryProgressReport.Columns[13].Visible = false;
                        GvdeliveryProgressReport.Columns[14].Visible = false;
                        GvdeliveryProgressReport.Columns[15].Visible = false;
                        GvdeliveryProgressReport.Columns[16].Visible = false;
                        GvdeliveryProgressReport.Columns[17].Visible = false;
                        GvdeliveryProgressReport.Columns[18].Visible = false;
                        GvdeliveryProgressReport.Columns[19].Visible = false;
                        GvdeliveryProgressReport.Columns[20].Visible = false;
                        GvdeliveryProgressReport.Columns[21].Visible = false;
                        GvdeliveryProgressReport.Columns[25].Visible = false;

                    }
                    if (lblclasID.Text == "8" || lblclasID.Text == "9" || lblclasID.Text == "10")
                    {
                        GvdeliveryProgressReport.Columns[5].Visible = true;
                        GvdeliveryProgressReport.Columns[7].Visible = true;
                        GvdeliveryProgressReport.Columns[8].Visible = true;
                        GvdeliveryProgressReport.Columns[9].Visible = true;
                        GvdeliveryProgressReport.Columns[19].Visible = true;
                        GvdeliveryProgressReport.Columns[23].Visible = true;
                        GvdeliveryProgressReport.Columns[24].Visible = true;
                        GvdeliveryProgressReport.Columns[25].Visible = true;


                        GvdeliveryProgressReport.Columns[10].Visible = false;
                        GvdeliveryProgressReport.Columns[6].Visible = false;
                        GvdeliveryProgressReport.Columns[11].Visible = false;
                        GvdeliveryProgressReport.Columns[12].Visible = false;
                        GvdeliveryProgressReport.Columns[13].Visible = false;
                        GvdeliveryProgressReport.Columns[14].Visible = false;
                        GvdeliveryProgressReport.Columns[15].Visible = false;
                        GvdeliveryProgressReport.Columns[16].Visible = false;
                        GvdeliveryProgressReport.Columns[17].Visible = false;
                        GvdeliveryProgressReport.Columns[18].Visible = false;
                        GvdeliveryProgressReport.Columns[19].Visible = false;
                        GvdeliveryProgressReport.Columns[20].Visible = false;
                        GvdeliveryProgressReport.Columns[21].Visible = false;
                        GvdeliveryProgressReport.Columns[22].Visible = false;
                        GvdeliveryProgressReport.Columns[26].Visible = false;
                    }

                    if (lblclasID.Text == "11" || lblclasID.Text == "12")
                    {
                        GvdeliveryProgressReport.Columns[5].Visible = true;
                        GvdeliveryProgressReport.Columns[6].Visible = true;
                        GvdeliveryProgressReport.Columns[7].Visible = true;
                        GvdeliveryProgressReport.Columns[9].Visible = true;

                        GvdeliveryProgressReport.Columns[19].Visible = true;
                        GvdeliveryProgressReport.Columns[24].Visible = true;
                        GvdeliveryProgressReport.Columns[8].Visible = false;
                        GvdeliveryProgressReport.Columns[25].Visible = true;
                        GvdeliveryProgressReport.Columns[10].Visible = false;
                        GvdeliveryProgressReport.Columns[11].Visible = false;
                        GvdeliveryProgressReport.Columns[12].Visible = false;
                        GvdeliveryProgressReport.Columns[13].Visible = false;
                        GvdeliveryProgressReport.Columns[14].Visible = false;
                        GvdeliveryProgressReport.Columns[15].Visible = false;
                        GvdeliveryProgressReport.Columns[16].Visible = true;
                        GvdeliveryProgressReport.Columns[17].Visible = true;
                        GvdeliveryProgressReport.Columns[18].Visible = true;
                        GvdeliveryProgressReport.Columns[19].Visible = true;
                        GvdeliveryProgressReport.Columns[20].Visible = false;
                        GvdeliveryProgressReport.Columns[21].Visible = false;
                        GvdeliveryProgressReport.Columns[22].Visible = false;
                        GvdeliveryProgressReport.Columns[23].Visible = false;

                        if (lblalternativeSubjectID.Text == "67" || lblalternativeSubjectID.Text == "77")
                        {
                            MeiteiMayek.Enabled = true;
                            AdEnglish.Enabled = false;
                            AdEnglish.CssClass = "Label3";
                            AdEnglish.Text = "";
                        }
                        else if (lblalternativeSubjectID.Text == "69" || lblalternativeSubjectID.Text == "79")
                        {
                            MeiteiMayek.Enabled = false;
                            MeiteiMayek.CssClass = "Label3";
                            AdEnglish.Enabled = true;
                            MeiteiMayek.Text = "";
                        }
                        if (lbloptionalsubjectID.Text == "72" || lbloptionalsubjectID.Text == "82")
                        {
                            HrMaths.Enabled = true;
                            Commerce.Enabled = false;
                            Computer.Enabled = false;
                            Homescience.Enabled = false;

                            Commerce.CssClass = "Label3";
                            Computer.CssClass = "Label3";
                            Homescience.CssClass = "Label3";
                            Computer.Text = "";
                            Commerce.Text = "";
                            Homescience.Text = "";
                        }
                        else if (lbloptionalsubjectID.Text == "73" || lbloptionalsubjectID.Text == "83")
                        {
                            HrMaths.Enabled = false;
                            Commerce.Enabled = false;
                            Computer.Enabled = false;
                            Homescience.Enabled = true;

                            HrMaths.CssClass = "Label3";
                            Computer.CssClass = "Label3";
                            Commerce.CssClass = "Label3";
                            HrMaths.Text = "";
                            Computer.Text = "";
                            Commerce.Text = "";
                        }
                        else if (lbloptionalsubjectID.Text == "74" || lbloptionalsubjectID.Text == "84")
                        {
                            HrMaths.Enabled = false;
                            Commerce.Enabled = true;
                            Computer.Enabled = false;
                            Homescience.Enabled = false;

                            HrMaths.CssClass = "Label3";
                            Computer.CssClass = "Label3";
                            Homescience.CssClass = "Label3";
                            HrMaths.Text = "";
                            Computer.Text = "";
                            Homescience.Text = "";
                        }
                        else if (lbloptionalsubjectID.Text == "75" || lbloptionalsubjectID.Text == "85")
                        {
                            HrMaths.Enabled = false;
                            Commerce.Enabled = false;
                            Computer.Enabled = true;
                            Homescience.Enabled = false;

                            HrMaths.CssClass = "Label3";
                            Commerce.CssClass = "Label3";
                            Homescience.CssClass = "Label3";

                            HrMaths.Text = "";
                            Commerce.Text = "";
                            Homescience.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }

        protected void btncanceldeliv_Click(object sender, EventArgs e)
        {
            ddldeliveryclass.SelectedIndex = 0;
            ddldeliverysection.SelectedIndex = 0;
            ddldeliveryexams.SelectedIndex = 0;
            txtrollNo.Text = "";
            btnprint.Enabled = false;
            GvdeliveryProgressReport.DataSource = null;
            GvdeliveryProgressReport.DataBind();
            GvdeliveryProgressReport.Visible = false;

        }
    }
}