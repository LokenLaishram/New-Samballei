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
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.Web.EduExamination
{
    public partial class ExamTimeTable : BasePage
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
            //Commonfunction.PopulateDdl(ddlcategory, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsubjects, objmstlookupBO.GetSubjectByClassID(Convert.ToInt32(ddlclasses.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ExamSchedulerData objrelation = new ExamSchedulerData();
                ExamTimeTableBO objrelationBO = new ExamTimeTableBO();
                IFormatProvider option1 = new System.Globalization.CultureInfo("en-GB", true);
                if (ViewState["Date"] != null)
                {
                    if (Convert.ToDateTime(ViewState["Date"].ToString()) == Convert.ToDateTime(txtfrom.Text.ToString()))
                    {
                        objrelation.StartDate = Convert.ToDateTime(txtfrom.Text);
                    }
                    else
                    {
                        DateTime date = Convert.ToDateTime(txtfrom.Text);
                        objrelation.StartDate = date;
                    }
                }
                else
                {
                    DateTime date = Convert.ToDateTime(txtfrom.Text);
                    objrelation.StartDate = date;
                }
                objrelation.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objrelation.SubjectID = Convert.ToInt32(ddlsubjects.SelectedValue == "" ? "0" : ddlsubjects.SelectedValue);
                //objrelation.CategoryID = Convert.ToInt32(ddlcategory.SelectedValue == "" ? "0" : ddlcategory.SelectedValue);
                objrelation.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                objrelation.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);

                objrelation.Starttime = txtstarttime.Text;
                objrelation.Endtime = txtendtime.Text;
                objrelation.StartimeAffix = Convert.ToInt32(ddlstartime.SelectedValue);
                objrelation.EndtimeAffix = Convert.ToInt32(ddlendtime.SelectedValue);
                objrelation.AddedBy = LoginToken.LoginId;
                objrelation.UserId = LoginToken.UserLoginId; ;
                objrelation.CompanyID = LoginToken.CompanyID;
                objrelation.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objrelation.ActionType = EnumActionType.Update;
                    objrelation.ScheduleID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objrelationBO.UpdateExamscheduler(objrelation);
                if (result == 1 || result == 2)
                {
                    //clearall();
                    ddlsubjects.SelectedIndex = 0;
                    Bindgrid();
                    Messagealert_.ShowMessage(lblmessage, result == 1 ? "save" : "update", 1);
                    ViewState["ID"] = null;
                    ViewState["Date"] = null;
                }
                else if (result == 5)
                {
                    Messagealert_.ShowMessage(lblmessage, "duplicate", 0);
                    clearall();
                    GvExamScheduledetails.DataSource = GetExamschedules(0);
                    GvExamScheduledetails.DataBind();
                }
                else
                {
                    Messagealert_.ShowMessage(lblmessage, "system", 0);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "MessageFailed";
            }
        }

        protected void GvExamScheduledetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ExamSchedulerData objrelation = new ExamSchedulerData();
                    ExamTimeTableBO objrelationBO = new ExamTimeTableBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvExamScheduledetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblscheduleID");
                    objrelation.ScheduleID = Convert.ToInt32(ID.Text);
                    objrelation.ActionType = EnumActionType.Select;

                    List<ExamSchedulerData> GetResult = objrelationBO.GetExamschedulerByID(objrelation);
                    if (GetResult.Count > 0)
                    {
                        ddlclasses.SelectedValue = GetResult[0].ClassID.ToString();
                        MasterLookupBO objmstlookupBO = new MasterLookupBO();
                        Commonfunction.PopulateDdl(ddlsubjects, objmstlookupBO.GetSubjectByClassID(Convert.ToInt32(GetResult[0].ClassID.ToString() == "" ? "0" : GetResult[0].ClassID.ToString())));
                        //Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(GetResult[0].ClassID.ToString() == "" ? "0" : GetResult[0].ClassID.ToString())));
                        ddlacademicsession.SelectedValue = GetResult[0].AcademicSessionID.ToString();
                        ddlexam.SelectedValue = GetResult[0].ExamID.ToString();
                       // ddlcategory.SelectedValue = GetResult[0].CategoryID.ToString();
                        ddlsubjects.SelectedValue = GetResult[0].SubjectID.ToString();
                        txtfrom.Text = GetResult[0].StartDate.ToString();
                        txtstarttime.Text = GetResult[0].Starttime.ToString();
                        txtendtime.Text = GetResult[0].Endtime.ToString();
                        ddlacademicsession.SelectedValue = GetResult[0].AcademicSessionID.ToString();
                        ViewState["ID"] = GetResult[0].ScheduleID.ToString();
                        ddlstartime.SelectedValue = GetResult[0].StartimeAffix.ToString();
                        ddlendtime.SelectedValue = GetResult[0].EndtimeAffix.ToString();
                        ViewState["Date"] = GetResult[0].StartDate.ToString("MM/dd/yyyy");

                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ExamSchedulerData objrelation = new ExamSchedulerData();
                    ExamTimeTableBO objrelationBO = new ExamTimeTableBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvExamScheduledetails.Rows[i];

                    Label ID = (Label)gr.Cells[0].FindControl("lblscheduleID");
                    objrelation.ScheduleID = Convert.ToInt32(ID.Text);
                    objrelation.ActionType = EnumActionType.Delete;
                    int Result = objrelationBO.DeleteExamschedulerByID(objrelation);
                    if (Result == 1)
                    {
                        Messagealert_.ShowMessage(lblmessage, "delete", 1);
                        GvExamScheduledetails.DataSource = GetExamschedules(0);
                        GvExamScheduledetails.DataBind();
                    }
                    else
                    {
                        Messagealert_.ShowMessage(lblmessage, "system", 0);
                    }

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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Bindgrid();
        }
        private void Bindgrid()
        {
            List<ExamSchedulerData> lstrelation = GetExamschedules(0);
            if (lstrelation.Count > 0)
            {
                GvExamScheduledetails.DataSource = lstrelation;
                GvExamScheduledetails.DataBind();
                GvExamScheduledetails.Visible = true;
                lblmessage.Visible = false;

            }
            else
            {
                GvExamScheduledetails.DataSource = null;
                GvExamScheduledetails.DataBind();
                GvExamScheduledetails.Visible = true;

            }
        }
        public List<ExamSchedulerData> GetExamschedules(int curIndex)
        {
            ExamSchedulerData objrelation = new ExamSchedulerData();
            ExamTimeTableBO objrelationBO = new ExamTimeTableBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            // DateTime date = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objrelation.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objrelation.SubjectID = Convert.ToInt32(ddlsubjects.SelectedValue == "" ? "0" : ddlsubjects.SelectedValue);
            objrelation.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objrelation.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            //objrelation.StartDate = date;
            //objrelation.CategoryID = Convert.ToInt32(ddlcategory.SelectedValue == "" ? "0" : ddlcategory.SelectedValue);

            objrelation.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            return objrelationBO.SearchExamscheduler(objrelation);

        }
        private void clearall()
        {
            ddlclasses.SelectedIndex = 0;
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsubjects, objmstlookupBO.GetSubjectByClassID(Convert.ToInt32(0)));
            //Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(0)));
            txtstarttime.Text = "";
            txtfrom.Text = "";
            txtendtime.Text = "";
            ddlacademicsession.SelectedIndex = 1;
            ViewState["ID"] = null;
            lblmessage.Text = "";
            lblmessage.Visible = false;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            GvExamScheduledetails.DataSource = null;
            GvExamScheduledetails.Visible = false;
            clearall();
        }

        protected void GvExamScheduledetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //foreach (GridViewRow row in GvExamScheduledetails.Rows)
            //{
            //    try
            //    {
            //        Label startaffix = (Label)GvExamScheduledetails.Rows[row.RowIndex].FindControl("lblstartaffix");
            //        Label endaffix = (Label)GvExamScheduledetails.Rows[row.RowIndex].FindControl("lblendaffix");
            //        Label starttime = (Label)GvExamScheduledetails.Rows[row.RowIndex].FindControl("lblstarttime");
            //        Label endtime = (Label)GvExamScheduledetails.Rows[row.RowIndex].FindControl("lblendtime");

            //        if (startaffix.Text == "1")
            //        {
            //            starttime.Text = starttime.Text + " AM";
            //        }
            //        else
            //        {
            //            starttime.Text = starttime.Text + " PM";
            //        }
            //        if (endaffix.Text == "1")
            //        {
            //            endtime.Text = endtime.Text + " PM";
            //        }
            //        else
            //        {
            //            endtime.Text = endtime.Text + " AM";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //       PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
            //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
            //        lblmessage.Text = ExceptionMessage.GetMessage(ex);
            //        lblmessage.Visible = true;
            //        lblmessage.CssClass = "Message";
            //    }
            //}
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}