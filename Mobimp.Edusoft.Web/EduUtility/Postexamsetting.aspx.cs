using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;

namespace Mobimp.Campusoft.Web.EduUtility
{
    public partial class Postexamsetting : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //ExamPager.PageCommand += new CustomPager.PageCommandDelegate(Pager_PageCommand);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
                // ExamPager.Visible = false;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlexam, mstlookup.GetLookupsList(LookupNames.ExamNames));
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid();

        }
        private void bindgrid()
        {
            List<ExamTypeData> lstexam = GetExamTypedetails();
            if (lstexam.Count > 0)
            {
                btnupdate.Enabled = true;
                GvExamdetails.Visible = true;
                GvExamdetails.DataSource = lstexam;
                GvExamdetails.DataBind();
                lblmessage.Visible = false;
            }
            else
            {
                btnupdate.Enabled = false;
                GvExamdetails.Visible = true;
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
                lblmessage.Visible = false;
            }
        }
        public List<ExamTypeData> GetExamTypedetails()
        {
            ExamTypeData objexamtype = new ExamTypeData();
            ExamTypeBO objobjexamtype = new ExamTypeBO();
            objexamtype.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexamtype.ActionType = EnumActionType.Select;
            objexamtype.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexamtype.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            return objobjexamtype.Getyearwiseexamlist(objexamtype);

        }
        private void clearall()
        {
            ddlexam.SelectedIndex = 0;
            ddlclasses.SelectedIndex = 0;

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            ddlclasses.SelectedIndex = 0;
            GvExamdetails.DataSource = null;
            GvExamdetails.DataBind();
            GvExamdetails.Visible = false;
            //Response.Redirect("ExamType.aspx");
            lblmessage.Visible = false;
        }
        protected void GvExamdetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GvExamdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvExamdetails.Rows)
            {
                try
                {
                    Label lblchkstudent = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkstudent");
                    Label lblchksubject = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchksubject");
                    Label lblchkaltsubject = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkaltsubject");
                    Label lblchkoptsubject = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkoptional");
                    Label lblchkmark = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkmark");
                    Label lblchkmarkentry = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkmarkentry");
                    Label lblchkresult = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkresult");
                    Label lblchkpublisresult = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkpublisresult");

                    CheckBox chkstudent = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkstd");
                    CheckBox chksubject = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chksubject");
                    CheckBox chkaltsubject = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkaltsubject");
                    CheckBox chkoptsubject = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkoptsubject");
                    CheckBox chkmark = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkmark");
                    CheckBox chkmarkentry = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkmarkentry");
                    CheckBox chkdresult = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkdresult");
                    if (lblchkpublisresult.Text == "1")
                    {
                        chkdresult.Enabled = true;
                    }
                    else
                    {
                        chkdresult.Enabled = false;
                    }
                    if (lblchkstudent.Text == "1")
                    {
                        chkstudent.Checked = true;
                    }
                    else
                    {
                        chkstudent.Checked = false;
                    }
                    if (lblchksubject.Text == "1")
                    {
                        chksubject.Checked = true;
                    }
                    else
                    {
                        chksubject.Checked = false;
                    }
                    if (lblchkaltsubject.Text == "1")
                    {
                        chkaltsubject.Checked = true;
                    }
                    else
                    {
                        chkaltsubject.Checked = false;
                    }
                    if (lblchkoptsubject.Text == "1")
                    {
                        chkoptsubject.Checked = true;
                    }
                    else
                    {
                        chkoptsubject.Checked = false;
                    }
                    if (lblchkmark.Text == "1")
                    {
                        chkmark.Checked = true;
                    }
                    else
                    {
                        chkmark.Checked = false;
                    }
                    if (lblchkmarkentry.Text == "1")
                    {
                        chkmarkentry.Checked = true;
                    }
                    else
                    {
                        chkmarkentry.Checked = false;
                    }
                    if (lblchkresult.Text == "1")
                    {
                        chkdresult.Checked = true;
                    }
                    else
                    {
                        chkdresult.Checked = false;
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
            List<ExamTypeData> lstmarks = new List<ExamTypeData>();
            ExamTypeData objstd = new ExamTypeData();
            ExamTypeBO objstdBO = new ExamTypeBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvExamdetails.Rows)
                {

                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ID = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblID");
                    Label ClassID = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblclassID");

                    CheckBox chkstudents = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkstd");
                    CheckBox chksubjects = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chksubject");
                    CheckBox chkaltsubjects = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkaltsubject");
                    CheckBox chkoptsubjects = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkoptsubject");
                    CheckBox chkmarks = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkmark");
                    CheckBox chkmarkentrys = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkmarkentry");
                    CheckBox chkdresult = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkdresult");

                    ExamTypeData ObjDetails = new ExamTypeData();
                    ObjDetails.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    ObjDetails.chkstudent = chkstudents.Checked ? 1 : 0;
                    ObjDetails.chksubject = chksubjects.Checked ? 1 : 0;
                    ObjDetails.chkaltsubject = chkaltsubjects.Checked ? 1 : 0;
                    ObjDetails.chkoptsubject = chkoptsubjects.Checked ? 1 : 0;
                    ObjDetails.chkmark = chkmarks.Checked ? 1 : 0;
                    ObjDetails.chkmarkentry = chkmarkentrys.Checked ? 1 : 0;
                    ObjDetails.chkresult = chkdresult.Checked ? 1 : 0;

                    lstmarks.Add(ObjDetails);
                    index++;
                }
                objstd.XmlMarksdetaillist = XmlConvertor.ProcessVerificationtoXML(lstmarks).ToString();
                int results = objstdBO.ProcessVerification(objstd);
                if (results == 1)
                {
                    bindgrid();
                    Messagealert_.ShowMessage(lblmessage, "update", 1);
                }
                else
                {
                    Messagealert_.ShowMessage(lblmessage, "Error", 0);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
            }
        }
    }
}