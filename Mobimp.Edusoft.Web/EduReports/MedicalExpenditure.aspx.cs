using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common;

namespace Mobimp.Campusoft.Web.EduReports
{
    public partial class MedicalExpenditure : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(dllstudentcategory, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            lblcasule.Text = "Total Expenditure Amount";
            lbltotalpaid.Text = "00.00";
        }
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclass.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlsection, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue)));
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Expenditure objexpt = new Expenditure();
                AddstudentBO objstdBO = new AddstudentBO();
                objexpt.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                objexpt.StudentCategrory = Convert.ToInt32(dllstudentcategory.SelectedValue == "" ? "0" : dllstudentcategory.SelectedValue);
                objexpt.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objexpt.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
                objexpt.RollNo = Convert.ToInt32(txtrollnos.Text == "" ? "0" : txtrollnos.Text);
                objexpt.ExpenditureAmount = Convert.ToDecimal(txtexpenditure.Text.Trim());
                objexpt.Remarks = txtremark.Text;
                objexpt.AddedBy = LoginToken.LoginId;
                objexpt.UserId = LoginToken.UserLoginId;
                objexpt.CompanyID = LoginToken.CompanyID;
                int result = objstdBO.Updateexpenditure(objexpt);
                if (result == 1 || result == 2)
                {
                    bindgrid();
                    btnprint.Enabled = true;
                    Messagealert_.ShowMessage(lblmessage, result == 1 ? "save" : "update", 1);
                }
                else if (result == 4)
                {
                    Messagealert_.ShowMessage(lblmessage, "Already Created.", 0);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void bindgrid()
        {
            List<Expenditure> studentdetails = GetExpenditure();
            if (studentdetails.Count > 0)
            {
                Gvexpenditure.DataSource = studentdetails;
                Gvexpenditure.DataBind();
                Gvexpenditure.Visible = true;
                btnprint.Enabled = true;
                lblresult.Text = "Total : " + studentdetails[0].MaximumRows.ToString() + " record found. ";
                lblresult.CssClass = "MsgSuccess";
                lblresult.Visible = true;
                if (ddlstatus.SelectedValue == "1")
                {
                    lblcasule.Text = "Total Expenditure Amount";
                    lbltotalpaid.Text = Commonfunction.Getrounding(studentdetails[0].TotalAmount.ToString());

                }
                else if (ddlstatus.SelectedValue == "0")
                {
                    lblcasule.Text = "Total Deleted Expenditure Amount";
                    lbltotalpaid.Text = Commonfunction.Getrounding(studentdetails[0].TotalAmount.ToString());

                }

            }
            else
            {
                btnprint.Enabled = false;
                Gvexpenditure.DataSource = null;
                Gvexpenditure.DataBind();
                Gvexpenditure.Visible = true;
                lblresult.Visible = false;
            }

        }
        public List<Expenditure> GetExpenditure()
        {
            Expenditure objexpt = new Expenditure();
            AddstudentBO objstdBO = new AddstudentBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objexpt.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexpt.StudentCategrory = Convert.ToInt32(dllstudentcategory.SelectedValue == "" ? "0" : dllstudentcategory.SelectedValue);
            objexpt.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objexpt.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
            objexpt.RollNo = Convert.ToInt32(txtrollnos.Text == "" ? "0" : txtrollnos.Text);
            objexpt.Datefrom = from;
            objexpt.Dateto = To;
            objexpt.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            return objstdBO.SearchExpendtiureDetails(objexpt);
        }
        protected void btncanceldeliv_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicalExpenditure.aspx", false);
        }
        protected void Gvexpenditure_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletes")
            {
                Expenditure objstd = new Expenditure();
                AddstudentBO objstdBO = new AddstudentBO();
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = Gvexpenditure.Rows[i];
                Label ID = (Label)gr.Cells[0].FindControl("lblccID");

                objstd.ID = Convert.ToInt64(ID.Text);
                objstd.AcademicSessionID = LoginToken.AcademicSessionID;
                objstd.AddedBy = LoginToken.LoginId;
                objstd.UserId = LoginToken.UserLoginId;

                int Result = objstdBO.DeleteExpenditureByID(objstd);
                if (Result == 1)
                {
                    bindgrid();
                    Messagealert_.ShowMessage(lblmessage, "delete", 1);
                }
                else
                {
                    Messagealert_.ShowMessage(lblmessage, "system", 0);
                }
            }
        }

    }
}