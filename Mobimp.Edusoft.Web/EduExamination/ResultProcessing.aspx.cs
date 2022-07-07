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
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class ClassWiseMarkEntry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                divoverall.Visible = false;
                btn_printbroadsheet.Attributes["disabled"] = "disabled";
                btn_overallresult.Attributes["disabled"] = "disabled";
                btn_overallmarksheet.Attributes["disabled"] = "disabled";
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.Insertzeroitemindex(ddlexam);
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclasses.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamlistbysessionID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
                Commonfunction.PopulateDdl(ddl_sections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
                bindresults(1);
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlexam);
                divresultlist.Visible = false;
                divoverall.Visible = false;
            }
        }
        protected void ddlexam_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindresults(1);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlexam.SelectedIndex = 0;
            lblmessage.Visible = false;
            divoverall.Visible = false;
        }
        private void bindresults(int index)
        {
            List<ExamresultData> lstsubject = Getexamresltlist(index);
            if (lstsubject.Count > 0)
            {
                Gv_resultlist.DataSource = lstsubject;
                Gv_resultlist.DataBind();
                Gv_resultlist.Visible = true;
                divresultlist.Visible = true;
                divoverall.Visible = false;
                btn_publishoverall.Text = "Publish Overall";
                btn_publishoverall.CssClass = "btn btn-sm btn-info button";
                btn_printbroadsheet.Attributes["disabled"] = "disabled";
                btn_overallresult.Attributes["disabled"] = "disabled";
                btn_overallmarksheet.Attributes["disabled"] = "disabled";
                ddl_sections.SelectedIndex = 0;
                ddl_types.SelectedIndex = 0;
                txt_roll.Text = "";
            }
            else
            {
                Gv_resultlist.DataSource = null;
                Gv_resultlist.DataBind();
                Gv_resultlist.Visible = true;
                divresultlist.Visible = false;
                divoverall.Visible = false;
                ddl_sections.SelectedIndex = 0;
                ddl_types.SelectedIndex = 0;
                txt_roll.Text = "";
            }
        }
        public List<ExamresultData> Getexamresltlist(int curIndex)
        {
            ExamresultData objexam = new ExamresultData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.CLassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.EmployeeID = LoginToken.EmployeeID;
            objexam.CompanyID = LoginToken.CompanyID;
            return objexamBO.GetExamresultlist(objexam);
        }
        protected void Gv_resultlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label ID = (Label)e.Row.FindControl("lbl_sectionID");
                Label Class = (Label)e.Row.FindControl("lblClass");

                Label entrystatus = (Label)e.Row.FindControl("lbl_markentrystatus");
                Label publishstatus = (Label)e.Row.FindControl("lbl_publishedsatus");
                Label pendingcount = (Label)e.Row.FindControl("lbl_pendingcount");
                Label lbl_declaredon = (Label)e.Row.FindControl("lbl_declaredon");
                Label lbl_pc = (Label)e.Row.FindControl("lbl_pc");

                LinkButton btn_entry = (LinkButton)e.Row.FindControl("btn_entry");
                LinkButton btn_publish = (LinkButton)e.Row.FindControl("btn_published");
                Button btn_print = (Button)e.Row.FindControl("lnkPrint");
                Button btn_printmark = (Button)e.Row.FindControl("btn_marksheet");
                Button btn_printresult = (Button)e.Row.FindControl("btn_result");

                DropDownList ddlsections = (DropDownList)e.Row.FindControl("ddl_section");
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));

                btn_printmark.Attributes["disabled"] = "disabled";
                btn_printresult.Attributes["disabled"] = "disabled";
                if (entrystatus.Text == "0")
                {
                    btn_entry.Text = "Pending" + "(" + pendingcount.Text + ")";
                    btn_entry.CssClass = "btn btn-warning cus_btn";
                    lbl_pc.Text = "";
                    lbl_declaredon.Text = "";
                    lbl_declaredon.Visible = false;
                    lbl_pc.Visible = false;
                    btn_entry.Attributes.Remove("disabled");
                    btn_publish.Attributes["disabled"] = "disabled";
                }
                if (entrystatus.Text == "1")
                {
                    btn_entry.Text = "Completed";
                    btn_entry.CssClass = "btn btn-success cus_btn";
                    btn_publish.Attributes.Remove("disabled");
                    lbl_declaredon.Visible = false;
                    lbl_pc.Visible = false;
                    btn_entry.Attributes["disabled"] = "disabled";
                }
                if (entrystatus.Text == "2")
                {
                    btn_entry.Text = "Pending";
                    btn_entry.CssClass = "btn btn-warning cus_btn";
                    lbl_pc.Text = "";
                    lbl_declaredon.Text = "";
                    lbl_declaredon.Visible = false;
                    lbl_pc.Visible = false;
                    btn_entry.Attributes.Remove("disabled");
                    btn_publish.Attributes["disabled"] = "disabled";
                }
                if (publishstatus.Text == "0")
                {
                    lbl_declaredon.Visible = false;
                    lbl_pc.Visible = false;
                    lbl_pc.Text = "";
                    lbl_declaredon.Text = "";
                    btn_print.Attributes.Remove("disabled");
                    btn_print.Attributes["disabled"] = "disabled";
                    btn_printmark.Attributes.Remove("disabled");
                    btn_printmark.Attributes["disabled"] = "disabled";
                    btn_publish.Text = "Publish";
                    btn_publish.CssClass = "btn btn-info cus_btn";
                }
                if (publishstatus.Text == "1")
                {
                    lbl_declaredon.Visible = true;
                    lbl_pc.Visible = true;
                    btn_print.Attributes.Remove("disabled");
                    btn_printmark.Attributes.Remove("disabled");
                    btn_publish.Text = "Published";
                    btn_publish.CssClass = "btn btn-success cus_btn";
                }
                if (publishstatus.Text == "2")
                {
                    lbl_declaredon.Visible = false;
                    lbl_pc.Visible = false;
                    lbl_pc.Text = "";
                    lbl_declaredon.Text = "";
                    btn_print.Attributes.Remove("disabled");
                    btn_print.Attributes["disabled"] = "disabled";
                    btn_printmark.Attributes.Remove("disabled");
                    btn_printmark.Attributes["disabled"] = "disabled";
                    btn_publish.Text = "Republish";
                    btn_publish.CssClass = "btn btn-info cus_btn";
                }
            }
        }
        protected void Gv_resultlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "mark")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_resultlist.Rows[i];
                    Label lbl_classid = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label lbl_examid = (Label)gr.Cells[0].FindControl("lbl_examid");
                    Label lbl_markentrystatus = (Label)gr.Cells[0].FindControl("lbl_markentrystatus");
                    if (lbl_markentrystatus.Text == "0" || lbl_markentrystatus.Text == "2")
                    {
                        Session["ClassID"] = lbl_classid.Text;
                        Session["ExamID"] = lbl_examid.Text;
                        Session["academicsession"] = ddlacademicseesions.SelectedValue;
                        Response.Redirect("~/EduExamination/SubjectWiseMarkEntry.aspx", false);
                    }
                }
                if (e.CommandName == "publish")
                {

                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_resultlist.Rows[i];
                    Label lbl_classid = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label lbl_examid = (Label)gr.Cells[0].FindControl("lbl_examid");
                    Label lbl_markentrystatus = (Label)gr.Cells[0].FindControl("lbl_markentrystatus");

                    if (lbl_markentrystatus.Text == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("markentry") + "')", true);
                        return;
                    }

                    ExamresultData objexam = new ExamresultData();
                    ExamTypeBO objexamBO = new ExamTypeBO();

                    objexam.CLassID = Convert.ToInt32(lbl_classid.Text == "" ? "0" : lbl_classid.Text);
                    objexam.ExamID = Convert.ToInt32(lbl_examid.Text == "" ? "0" : lbl_examid.Text);
                    objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                    objexam.EmployeeID = LoginToken.EmployeeID;

                    int results = objexamBO.Publishresult(objexam);
                    if (results == 1)
                    {
                        bindresults(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("publish") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Checkexmsteps") + "')", true);
                    }
                }
                if (e.CommandName == "BS")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_resultlist.Rows[i];
                    Label lbl_classid = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label lbl_examid = (Label)gr.Cells[0].FindControl("lbl_examid");
                    DropDownList ddl_section = (DropDownList)gr.Cells[0].FindControl("ddl_section");
                    DropDownList ddl_rank = (DropDownList)gr.Cells[0].FindControl("ddl_rankshow");
                    DropDownList ddl_feestatus = (DropDownList)gr.Cells[0].FindControl("ddl_feestatus");
                    TextBox Rollno = (TextBox)gr.Cells[0].FindControl("txt_roll");

                    string classid = lbl_classid.Text;
                    string examid = lbl_examid.Text;
                    string sectionid = ddl_section.SelectedValue;
                    string sessionid = ddlacademicseesions.SelectedValue;
                    string roll = Rollno.Text == "" ? "0" : Rollno.Text;
                    string rankshow = ddl_rank.SelectedValue;
                    string feestatus = ddl_feestatus.SelectedValue;
                    String Year = ddlacademicseesions.SelectedItem.Text;
                    string url = "../EduReports/Reports/ReportViewer.aspx?option=PrintBroadsheet&Session=" + sessionid + "&ClassID=" + classid + "&SectionID=" + sectionid + "&Roll=" + roll + "&ExamID=" + examid + "&Rankshow=" + rankshow + "&Year=" + Year + "&FeeStatus=" + feestatus;
                    string fullURL = "window.open('" + url + "', '_blank');";

                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
                }
                if (e.CommandName == "MS")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_resultlist.Rows[i];
                    Label lbl_classid = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label lbl_examid = (Label)gr.Cells[0].FindControl("lbl_examid");
                    DropDownList ddl_section = (DropDownList)gr.Cells[0].FindControl("ddl_section");
                    DropDownList ddl_rank = (DropDownList)gr.Cells[0].FindControl("ddl_rankshow");
                    DropDownList ddl_feestatus = (DropDownList)gr.Cells[0].FindControl("ddl_feestatus");
                    TextBox Rollno = (TextBox)gr.Cells[0].FindControl("txt_roll");

                    string classid = lbl_classid.Text;
                    string examid = lbl_examid.Text;
                    string sectionid = ddl_section.SelectedValue;
                    string sessionid = ddlacademicseesions.SelectedValue;
                    string roll = Rollno.Text == "" ? "0" : Rollno.Text;
                    string rankshow = ddl_rank.SelectedValue;
                    string feestatus = ddl_feestatus.SelectedValue;
                    String Year = ddlacademicseesions.SelectedItem.Text;
                    string url = "../EduReports/Reports/ReportViewer.aspx?option=PrintMarksheet&Session=" + sessionid + "&ClassID=" + classid + "&SectionID=" + sectionid + "&Roll=" + roll + "&ExamID=" + examid + "&Rankshow=" + rankshow + "&Year=" + Year + "&FeeStatus=" + feestatus;
                    string fullURL = "window.open('" + url + "', '_blank');";

                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
                }
                if (e.CommandName == "RS")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_resultlist.Rows[i];
                    Label lbl_classid = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label lbl_examid = (Label)gr.Cells[0].FindControl("lbl_examid");
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
        protected void btn_publishoverall_Click(object sender, EventArgs e)
        {
            ExamresultData objexam = new ExamresultData();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.CLassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.EmployeeID = LoginToken.EmployeeID;
            int results = objexamBO.Publishoverallresult(objexam);
            if (results == 1)
            {
                btn_publishoverall.Text = "Published Overall";
                btn_publishoverall.CssClass = "btn btn-success cus_btn";
                btn_printbroadsheet.Attributes.Remove("disabled");
                btn_overallmarksheet.Attributes.Remove("disabled");
                //btn_overallresult.Attributes.Remove("disabled");
                //btn_overallmarksheet.Attributes.Remove("disabled");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("publish") + "')", true);
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Checkexmsteps") + "')", true);
            }
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlexam.SelectedIndex = 0;
            ddl_sections.SelectedIndex = 0;
            ddl_types.SelectedIndex = 0;
            txt_roll.Text = "";
            lblmessage.Visible = false;
            divoverall.Visible = false;
            Gv_resultlist.DataSource = null;
            Gv_resultlist.DataBind();
            divresultlist.Visible = false;
            Gv_resultlist.Visible = false;
            btn_publishoverall.Text = "Publish Overall";
            btn_printbroadsheet.Attributes["disabled"] = "disabled";
            btn_overallresult.Attributes["disabled"] = "disabled";
            btn_overallmarksheet.Attributes["disabled"] = "disabled";
        }

        protected void btn_printbroadsheet_Click(object sender, EventArgs e)
        {
            string classid = ddlclasses.SelectedValue;
            string examid = "10";// lbl_examid.Text;
            string sectionid = ddl_sections.SelectedValue;
            string sessionid = ddlacademicseesions.SelectedValue;
            string roll = txt_roll.Text == "" ? "0" : txt_roll.Text;
            string rankshow = ddl_types.SelectedValue;
            String Year = ddlacademicseesions.SelectedItem.Text;
            string url = "../EduReports/Reports/ReportViewer.aspx?option=PrintOverallBroadsheet&Session=" + sessionid + "&ClassID=" + classid + "&SectionID=" + sectionid + "&Roll=" + roll + "&ExamID=" + examid + "&Rankshow=" + rankshow + "&Year=" + Year;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }

        protected void btn_overallmarksheet_Click(object sender, EventArgs e)
        {
            string classid = ddlclasses.SelectedValue;
            string examid = "10";// lbl_examid.Text;
            string sectionid = ddl_sections.SelectedValue;
            string sessionid = ddlacademicseesions.SelectedValue;
            string roll = txt_roll.Text == "" ? "0" : txt_roll.Text;
            string rankshow = ddl_types.SelectedValue;
            String Year = ddlacademicseesions.SelectedItem.Text;
            string url = "../EduReports/Reports/ReportViewer.aspx?option=PrintOverallMarksheet&Session=" + sessionid + "&ClassID=" + classid + "&SectionID=" + sectionid + "&Roll=" + roll + "&ExamID=" + examid + "&Rankshow=" + rankshow + "&Year=" + Year;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

        }

        protected void timerGridview_Tick(object sender, EventArgs e)
        {
            bindresults(1);
        }
    }
}