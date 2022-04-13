using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.Web.EduEmployee
{
    public partial class AssignSubject : BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AssSubjectPager.PageCommand += new CustomPager.PageCommandDelegate(Pager_PageCommand);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                AssSubjectPager.Visible = false;
                bindddl();
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclassses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlsection, mstlookup.GetLookupsList(LookupNames.Section));
            Commonfunction.PopulateDdl(ddlteacher, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
            Commonfunction.PopulateDdl(ddlsubject, mstlookup.GetLookupsList(LookupNames.Subject));
            Commonfunction.PopulateDdl(ddlcatgeory, mstlookup.GetLookupsList(LookupNames.StaffCategory));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                AssignSubjectData objassignsubj = new AssignSubjectData();
                AssignSubjectBO objassignsubjBO = new AssignSubjectBO();
                objassignsubj.StaffCategoryID = Convert.ToInt32(ddlcatgeory.SelectedValue == "" ? "0" : ddlcatgeory.SelectedValue);
                objassignsubj.ClassID = Convert.ToInt32(ddlclassses.SelectedValue == "" ? "0" : ddlclassses.SelectedValue);
                objassignsubj.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
                objassignsubj.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
                objassignsubj.EmployeeID = Convert.ToInt64(ddlteacher.SelectedValue == "" ? "0" : ddlteacher.SelectedValue);
                objassignsubj.IsActiveALL = Radchecklist.SelectedValue;

                objassignsubj.AddedBy = LoginToken.LoginId;
                objassignsubj.UserId = LoginToken.UserLoginId;
                objassignsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                objassignsubj.CompanyID = LoginToken.CompanyID;
                objassignsubj.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objassignsubj.ActionType = EnumActionType.Update;
                    objassignsubj.AssignID = Convert.ToInt32(ViewState["ID"].ToString());
                    objassignsubj.IsActiveALL = Radchecklist.SelectedValue;
                }
                int result = objassignsubjBO.UpdateAssignDetails(objassignsubj);
                if (result == 1 || result == 2)
                {
                    clearall();
                    bindgrid();
                    Messagealert_.ShowMessage(lblmessage, result == 1 ? "save" : "update", 1);
                    ViewState["ID"] = null;
                }
                else if (result == 5)
                {
                    Messagealert_.ShowMessage(lblmessage, "duplicate", 0);
                    clearall();
                    GvAssign.DataSource = getAssignSubjectdetails(0);
                    GvAssign.DataBind();
                }
                else
                    Messagealert_.ShowMessage(lblmessage, "system", 0);
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
        protected void Pager_PageCommand(object sender, PagerEventArgs e)
        {
            List<AssignSubjectData> lstacademic = getAssignSubjectdetails(e.PageIndex);

            AssSubjectPager.PageSize = GvAssign.PageSize;
            AssSubjectPager.TotalRecords = lstacademic[0].MaximumRows;
            GvAssign.DataSource = lstacademic;
            GvAssign.DataBind();

            if (lstacademic.Count >= 1)
            {
                AssSubjectPager.Visible = true;
            }
            else
            {
                AssSubjectPager.Visible = false;
            }
        }
        protected void GvAssign_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    AssignSubjectData objassignsubj = new AssignSubjectData();
                    AssignSubjectBO objassignsubjBO = new AssignSubjectBO();
                    objassignsubj.AssignID = Convert.ToInt16(e.CommandArgument.ToString());
                    objassignsubj.ActionType = EnumActionType.Select;
                    List<AssignSubjectData> GetResult = objassignsubjBO.GetAssignDetailsByID(objassignsubj);
                    if (GetResult.Count > 0)
                    {
                        bindddl();
                        bindddls(GetResult[0].ClassID);
                        ddlclassses.SelectedValue = GetResult[0].ClassID.ToString();
                        ddlsection.SelectedValue = GetResult[0].SectionID.ToString();
                        ddlsubject.SelectedValue = GetResult[0].SubjectID.ToString();
                        ddlteacher.SelectedValue = GetResult[0].EmployeeID.ToString();
                        Radchecklist.SelectedValue = GetResult[0].IsActive.ToString();
                        ViewState["ID"] = GetResult[0].AssignID;
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    AssignSubjectData objassignsubj = new AssignSubjectData();
                    AssignSubjectBO objassignsubjBO = new AssignSubjectBO();
                    objassignsubj.AssignID = Convert.ToInt16(e.CommandArgument.ToString());
                    objassignsubj.ActionType = EnumActionType.Delete;
                    int Result = objassignsubjBO.DeleteAssignDetailsByID(objassignsubj);
                    if (Result == 1)
                    {
                        Messagealert_.ShowMessage(lblmessage, "delete", 1);
                        GvAssign.DataSource = getAssignSubjectdetails(0);
                        GvAssign.DataBind();
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
            bindgrid();

        }
        private void bindgrid()
        {
            List<AssignSubjectData> lstsubject = getAssignSubjectdetails(0);
            if (lstsubject.Count > 0)
            {
                GvAssign.DataSource = lstsubject;
                GvAssign.DataBind();
                if (lstsubject[0].MaximumRows > 10)
                {
                    AssSubjectPager.Visible = true;
                }
                else
                {
                    AssSubjectPager.Visible = false;
                }
            }
            else
            {
                GvAssign.DataSource = null;
                GvAssign.DataBind();
            }
        }
        public List<AssignSubjectData> getAssignSubjectdetails(int curIndex)
        {
            AssignSubjectData objassignsubj = new AssignSubjectData();
            AssignSubjectBO objassignsubjBO = new AssignSubjectBO();
            objassignsubj.StaffCategoryID = Convert.ToInt32(ddlcatgeory.SelectedValue == "" ? "0" : ddlcatgeory.SelectedValue);
            objassignsubj.ClassID = Convert.ToInt32(ddlclassses.SelectedValue == "" ? "0" : ddlclassses.SelectedValue);
            objassignsubj.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
            objassignsubj.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
            objassignsubj.EmployeeID = Convert.ToInt32(ddlteacher.SelectedValue == "" ? "0" : ddlteacher.SelectedValue);
            objassignsubj.IsActiveALL = Radchecklist.SelectedValue;
            objassignsubj.ActionType = EnumActionType.Select;
            objassignsubj.PageSize = GvAssign.PageSize;
            objassignsubj.CurrentIndex = curIndex;
            return objassignsubjBO.SearchAssignDetails(objassignsubj);
        }
        private void clearall()
        {
            ddlteacher.SelectedIndex = 0;
            ddlsubject.SelectedIndex = 0;
            ddlsubject.SelectedIndex = 0;
            ddlclassses.SelectedIndex = 0;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            AssSubjectPager.Visible = false;
            Response.Redirect("AssignSubject.aspx");
        }
        protected void GvAssign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAssign.DataSource = getAssignSubjectdetails(e.NewPageIndex);
            GvAssign.DataBind();
        }
        protected void ddlclassses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddls(Convert.ToInt32(ddlclassses.SelectedValue));
        }

        protected void bindddls(int classID)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsection, objmstlookupBO.GetSectionByClassID(classID));
            Commonfunction.PopulateDdl(ddlsubject, objmstlookupBO.GetSubjectByClassID(classID));

        }

    }
}