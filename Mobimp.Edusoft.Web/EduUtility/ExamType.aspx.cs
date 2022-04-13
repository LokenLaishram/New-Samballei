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

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class ExamType : BasePage
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

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ExamTypeData objexamtype = new ExamTypeData();
                ExamTypeBO objobjexamtype = new ExamTypeBO();

                objexamtype.AddedBy = LoginToken.LoginId;
                objexamtype.UserId = LoginToken.UserLoginId;
                objexamtype.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objexamtype.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                objexamtype.CompanyID = LoginToken.CompanyID;
                objexamtype.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objexamtype.ActionType = EnumActionType.Update;
                    objexamtype.ExamID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objobjexamtype.UpdateExamtypeDetails(objexamtype);
                if (result == 1 || result == 2)
                {
                   // clearall();
                    bindgrid();
                    Messagealert_.ShowMessage(lblmessage, result == 1 ? "save" : "update", 1);
                    ViewState["ID"] = null;
                }
                else if (result == 5)
                {
                    Messagealert_.ShowMessage(lblmessage, "duplicate", 0);
                    clearall();
                    GvExamdetails.DataSource = GetExamTypedetails();
                    GvExamdetails.DataBind();
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
        protected void GvExamdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ExamTypeData objexamtype = new ExamTypeData();
                    ExamTypeBO objobjexamtype = new ExamTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvExamdetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objexamtype.ID = Convert.ToInt32(ID.Text);
                    objexamtype.ActionType = EnumActionType.Select;
                    List<ExamTypeData> GetResult = objobjexamtype.GetExamtypeDetailsByID(objexamtype);
                    if (GetResult.Count > 0)
                    {

                        ddlexam.SelectedValue = GetResult[0].ExamID.ToString();
                        ViewState["ID"] = GetResult[0].ID;
                        ddlclasses.SelectedValue = GetResult[0].ClassID.ToString();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ExamTypeData objexamtype = new ExamTypeData();
                    ExamTypeBO objobjexamtype = new ExamTypeBO();
                    objexamtype.ID = Convert.ToInt16(e.CommandArgument.ToString());
                    objexamtype.ActionType = EnumActionType.Delete;
                    int Result = objobjexamtype.DeleteExamtypeDetailsByID(objexamtype);
                    if (Result == 1)
                    {
                        Messagealert_.ShowMessage(lblmessage, "delete", 1);
                        GvExamdetails.DataSource = GetExamTypedetails();
                        GvExamdetails.DataBind();
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
            objexamtype.ActionType = EnumActionType.Select;
            objexamtype.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexamtype.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            return objobjexamtype.SearchExamtypeDetails(objexamtype);

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

                    TextBox FullMark = (TextBox)GvExamdetails.Rows[index].Cells[1].FindControl("txtfullmark");
                    TextBox PassMark = (TextBox)GvExamdetails.Rows[index].Cells[1].FindControl("txtpassmark");
                    TextBox TotalMark = (TextBox)GvExamdetails.Rows[index].Cells[1].FindControl("txttotalmarks");
                    TextBox TotalPassMark = (TextBox)GvExamdetails.Rows[index].Cells[1].FindControl("txttotakpassmark");
                    //TextBox PM = (TextBox)GvExamdetails.Rows[index].Cells[1].FindControl("txtPMmark");
                    //TextBox PRpassmark = (TextBox)GvExamdetails.Rows[index].Cells[1].FindControl("txtPRpassmark");

                    ExamTypeData ObjDetails = new ExamTypeData();
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text == "T" || ClassID.Text == "" ? "0" : ClassID.Text);
                    ObjDetails.ID = Convert.ToInt32(ID.Text == "T" ? "0" : ID.Text);
                    ObjDetails.FullMark = float.Parse(FullMark.Text == "" ? "0" : FullMark.Text);
                    ObjDetails.PassMark = float.Parse(PassMark.Text == "" ? "0" : PassMark.Text);

                    ObjDetails.TotalMark = float.Parse(TotalMark.Text == "" ? "0" : TotalMark.Text);
                    ObjDetails.TotalPassMark = float.Parse(TotalPassMark.Text == "" ? "0" : TotalPassMark.Text);
                    //ObjDetails.PM = float.Parse(PM.Text == "" ? "0" : PM.Text);
                    //ObjDetails.PRpassMark = float.Parse(PRpassmark.Text == "" ? "0" : PRpassmark.Text);
                    lstmarks.Add(ObjDetails);
                    index++;
                }
                objstd.XmlMarksdetaillist = XmlConvertor.ExamMArksListtoXML(lstmarks).ToString();
                int results = objstdBO.UpdateExamMarks(objstd);
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