using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;

namespace Mobimp.Campusoft.Web.EduEmployee
{
    public partial class EmployeeSalaryMaster : BasePage
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
            Commonfunction.PopulateDdl(dllacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            dllacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlempcategories, mstlookup.GetLookupsList(LookupNames.StaffCategory));
            Commonfunction.PopulateDdl(ddlcategory, mstlookup.GetLookupsList(LookupNames.StaffCategory));

        }
        protected void txtempID_TextChanged(object sender, EventArgs e)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeNo = txtempID.Text == "" ? null : txtempID.Text;
            objemp.ActionType = EnumActionType.Select;
            List<EmployeeData> GetResult = objempBO.GetEmployeeDetailsByID(objemp);
            if (GetResult.Count > 0)
            {
                txtempname.Text = GetResult[0].EmpName;
                txtdepartment.Text = GetResult[0].Department;
                hdnEmpID.Value = GetResult[0].EmployeeID.ToString();
            }

        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmpNo(string prefixText, int count, string contextKey)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();
            List<EmployeeData> getResult = new List<EmployeeData>();
            objemp.EmployeeNo = prefixText;
            getResult = objempBO.GetEmpNo(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeNo.ToString());
            }
            return list;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeSalary objemp = new EmployeeSalary();
                EmployeeBO objempBO = new EmployeeBO();
                objemp.EmployeeID = Convert.ToInt64(hdnEmpID.Value == "" ? "0" : hdnEmpID.Value);
                objemp.EmployeeNo = txtempID.Text;
                objemp.EmpName = txtempname.Text;
                objemp.SalaryAmount = Convert.ToDecimal(txtsalary.Text == "" ? "0.0" : txtsalary.Text);
                objemp.Increament = Convert.ToDecimal(txtincreament.Text == "" ? "0.0" : txtincreament.Text);
                objemp.IsDeleted = ddlstatus.SelectedValue == "1" ? false : true;
                objemp.UserId = LoginToken.UserLoginId;
                objemp.AddedBy = LoginToken.LoginId;
                objemp.AcademicSessionID = LoginToken.AcademicSessionID;
                objemp.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objemp.ActionType = EnumActionType.Update;
                    objemp.SalaryID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objempBO.UpdateEmployeeSalaryDetails(objemp);
                if (result == 1 || result == 2)
                {
                    ViewState["ID"] = null;
                    Getsalarydetails();
                    Messagealert_.ShowMessage(lblmessage, result == 1 ? "save" : "update", 1);
                    lblmessage.Visible = true;
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
        protected void Getsalarydetails()
        {
            EmployeeSalary objemp = new EmployeeSalary();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeNo = txtempID.Text;
            objemp.IsDeleted = ddlstatus.SelectedValue == "1" ? false : true;
            objemp.EmployeeCategory = Convert.ToInt32(ddlempcategories.SelectedValue == "" ? "0" : ddlempcategories.SelectedValue);
            List<EmployeeSalary> result = objempBO.GetSalaryDetails(objemp);
            if (result.Count > 0)
            {
                GvEmployeeSalary.DataSource = result;
                GvEmployeeSalary.DataBind();
                GvEmployeeSalary.Visible = true;
            }
            else
            {
                GvEmployeeSalary.DataSource = null;
                GvEmployeeSalary.DataBind();
                GvEmployeeSalary.Visible = true;

            }
        }

        protected void btnsearchs_Click(object sender, EventArgs e)
        {
            Getsalarydetails();
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtempID.Text = "";
            txtdepartment.Text = "";
            txtempname.Text = "";
            txtsalary.Text = "";
            ddlstatus.SelectedIndex = 0;
            GvEmployeeSalary.DataSource = null;
            GvEmployeeSalary.DataBind();
            GvEmployeeSalary.Visible = false;
            hdnEmpID.Value = null;
            lblmessage.Visible = false;
            txtincreament.Text = "";
            ddlempcategories.SelectedIndex = 0;

        }
        protected void GvEmployeeSalary_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName == "Edits")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvEmployeeSalary.Rows[i];
                    Label SalaryID = (Label)gr.Cells[0].FindControl("lblsalaryID");
                    int LeaveID = Convert.ToInt32(SalaryID.Text);
                    EmployeeSalary objemp = new EmployeeSalary();
                    EmployeeBO objempBO = new EmployeeBO();
                    objemp.SalaryID = Convert.ToInt32(SalaryID.Text == "" ? "0" : SalaryID.Text);
                    List<EmployeeSalary> GetResult = objempBO.GetEmployeeSalaryDetailsByID(objemp);
                    if (GetResult.Count > 0)
                    {
                        txtempID.Text = GetResult[0].EmployeeNo.ToString();
                        txtempname.Text = GetResult[0].EmpName.ToString();
                        txtdepartment.Text = GetResult[0].Department.ToString();
                        txtsalary.Text = Commonfunction.Getrounding(GetResult[0].SalaryAmount.ToString());
                        txtincreament.Text = Commonfunction.Getrounding(GetResult[0].Increament.ToString());
                        ViewState["ID"] = GetResult[0].SalaryID.ToString();

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

        protected void Btnsearch_Click(object sender, EventArgs e)
        {
            EmployeeSalary objemp = new EmployeeSalary();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeNo = txtempnos.Text;
            objemp.EmpName = txtempnames.Text;
            objemp.EmployeeCategory = Convert.ToInt32(ddlcategory.SelectedValue == "" ? "0" : ddlcategory.SelectedValue);
            objemp.AcademicSessionID = Convert.ToInt32(dllacademicsession.SelectedValue == "" ? "0" : dllacademicsession.SelectedValue);
            List<EmployeeSalary> GetResult = objempBO.GetEmployeeSalaryDetails(objemp);
            GVSummary.Visible = true;
            if (GetResult.Count > 0)
            {
                GVSummary.DataSource = GetResult;
                GVSummary.DataBind();
            }
            else
            {
                GVSummary.DataSource = null;
                GVSummary.DataBind();

            }
        }
        protected void GVSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            foreach (GridViewRow row in GVSummary.Rows)
            {
                try
                {
                    Label lblclosingdate = (Label)GVSummary.Rows[row.RowIndex].Cells[0].FindControl("lblclosingdate");

                    if (lblclosingdate.Text == "01-01-0001")
                    {
                        lblclosingdate.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

            txtempnos.Text = "";
            txtempnames.Text = "";
            dllacademicsession.SelectedIndex = 1;
            GVSummary.DataSource = null;
            GVSummary.DataBind();
            GVSummary.Visible = false;
            ddlcategory.SelectedIndex = 0;

        }
    }
}