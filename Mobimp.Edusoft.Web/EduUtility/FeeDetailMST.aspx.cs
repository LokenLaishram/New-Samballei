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
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.Common;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class FeeDetailMST : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                Bindddls();
            }
        }

        protected void Bindddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            //  Commonfunction.PopulateDdl(ddlstream, mstlookup.GetLookupsList(LookupNames.Stream));
            Commonfunction.PopulateDdl(ddlfeetype, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            //  Commonfunction.PopulateDdl(ddlstudentcategory, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            Commonfunction.PopulateDdl(ddladmissiontype, mstlookup.GetLookupsList(LookupNames.Admissiontype));
            ddlacademicsession.SelectedIndex = 1;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                FeesData objfees = new FeesData();
                FeeDetailBO objpayementBO = new FeeDetailBO();
                objfees.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                // objfees.StreamID = Convert.ToInt32(ddlstream.SelectedValue == "" ? "0" : ddlstream.SelectedValue);
                objfees.FeeTypeID = Convert.ToInt32(ddlfeetype.SelectedValue == "" ? "0" : ddlfeetype.SelectedValue);
                objfees.AdmissionTypeID = Convert.ToInt32(ddladmissiontype.SelectedValue == "" ? "0" : ddladmissiontype.SelectedValue);
                objfees.FeeAmount = Convert.ToDecimal(txtfee.Text == "" ? "0" : txtfee.Text);
                objfees.AddedBy = LoginToken.LoginId;
                objfees.UserId = LoginToken.UserLoginId; ;
                objfees.CompanyID = LoginToken.CompanyID;
                objfees.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue); ;
                // objfees.StudentCategoryID = Convert.ToInt32(ddlstudentcategory.SelectedValue == "" ? "0" : ddlstudentcategory.SelectedValue); ;
                objfees.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objfees.ActionType = EnumActionType.Update;
                    objfees.ID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objpayementBO.UpdateFeesDetails(objfees);
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
                    //clearall();
                    GvFeedetails.Visible = true;
                    GvFeedetails.DataSource = GetFeeDetails(0);
                    GvFeedetails.DataBind();
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
        protected void GvFeedetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    FeesData objfees = new FeesData();
                    FeeDetailBO objpayementBO = new FeeDetailBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvFeedetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objfees.ID = Convert.ToInt32(ID.Text);
                    objfees.ActionType = EnumActionType.Select;

                    List<FeesData> GetResult = objpayementBO.GetFeesDetailsByID(objfees);
                    if (GetResult.Count > 0)
                    {
                        // ddlstream.SelectedValue = GetResult[0].StreamID.ToString();
                        ddlclass.SelectedValue = GetResult[0].ClassID.ToString();
                        ddlfeetype.SelectedValue = GetResult[0].FeeTypeID.ToString();
                        ddladmissiontype.SelectedValue = GetResult[0].AdmissionTypeID.ToString();
                        // ddlstudentcategory.SelectedValue = GetResult[0].StudentCategoryID.ToString();
                        txtfee.Text = Commonfunction.Getrounding(GetResult[0].FeeAmount.ToString());
                        ViewState["ID"] = GetResult[0].ID;
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    FeesData objfees = new FeesData();
                    FeeDetailBO objpayementBO = new FeeDetailBO();
                    objfees.ID = Convert.ToInt16(e.CommandArgument.ToString());
                    objfees.ActionType = EnumActionType.Delete;
                    int Result = objpayementBO.DeleteFeesDetailsByID(objfees);
                    if (Result == 1)
                    {
                        Messagealert_.ShowMessage(lblmessage, "delete", 1);
                        GvFeedetails.Visible = true;
                        GvFeedetails.DataSource = GetFeeDetails(0);
                        GvFeedetails.DataBind();
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
            List<FeesData> lstPay = GetFeeDetails(0);
            if (lstPay.Count > 0)
            {
                GvFeedetails.Visible = true;
                GvFeedetails.DataSource = lstPay;
                GvFeedetails.DataBind();
            }
            else
            {
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
            }
        }
        public List<FeesData> GetFeeDetails(int curIndex)
        {
            FeesData objfees = new FeesData();
            FeeDetailBO objFeeBO = new FeeDetailBO();
            objfees.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            //  objfees.StreamID = Convert.ToInt32(ddlstream.SelectedValue == "" ? "0" : ddlstream.SelectedValue);
            objfees.FeeTypeID = Convert.ToInt32(ddlfeetype.SelectedValue == "" ? "0" : ddlfeetype.SelectedValue);
            objfees.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objfees.AdmissionTypeID = Convert.ToInt32(ddladmissiontype.SelectedValue == "" ? "0" : ddladmissiontype.SelectedValue);
            // objfees.StudentCategoryID = Convert.ToInt32(ddlstudentcategory.SelectedValue == "" ? "0" : ddlstudentcategory.SelectedValue);
            objfees.ActionType = EnumActionType.Select;
            objfees.PageSize = GvFeedetails.PageSize;
            objfees.CurrentIndex = curIndex;
            return objFeeBO.SearchFeesDetails(objfees);
        }
        private void clearall()
        {
            //Bindddls();
            txtfee.Text = "";
            lblmessage.Text = "";
            lblmessage.Visible = false;
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            //PaymentPager.Visible = false;
            GvFeedetails.Visible = false;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            Bindddls();
            manadmissiontype.Visible = false;
        }
        protected void GvFeedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvFeedetails.DataSource = GetFeeDetails(e.NewPageIndex);
            bindgrid();
        }
        protected void ddlfeetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlfeetype.SelectedValue == "10")
            {
                manadmissiontype.Visible = true;
            }
            else
            {
                manadmissiontype.Visible = false;
            }
        }
    }
}