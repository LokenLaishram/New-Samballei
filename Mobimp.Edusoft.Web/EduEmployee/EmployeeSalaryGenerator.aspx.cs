using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Campusoft.Web.EduEmployee
{
    public partial class EmployeeSalaryGenerator : BasePage
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
            Commonfunction.PopulateDdl(ddlfinancialyear, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlfinancialyear.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlmonth, mstlookup.GetLookupsList(LookupNames.Months));
            lblcasule.Text = "Total Paid Salary Amount";
            lbltotalpaid.Text = "00.00";
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
            else
            {
                txtempname.Text = "";
                txtdepartment.Text = "";
                hdnEmpID.Value = "";

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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Generatesalary();
        }
        protected void Generatesalary()
        {
            EmployeeSalary objemp = new EmployeeSalary();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeNo = txtempID.Text == "" ? null : txtempID.Text;
            objemp.AcademicSessionID = Convert.ToInt32(ddlfinancialyear.SelectedValue == "" ? "0" : ddlfinancialyear.SelectedValue);
            objemp.SalaryStatus = Convert.ToInt32(ddlstatus.SelectedValue == "" ? "0" : ddlstatus.SelectedValue);
            objemp.MonthID = Convert.ToInt32(ddlmonth.SelectedValue == "" ? "0" : ddlmonth.SelectedValue);
            objemp.IsActive = ddlisdeleted.SelectedValue == "1" ? true : false;
            objemp.AddedBy = LoginToken.LoginId;
            objemp.EmployeeCategory = Convert.ToInt32(ddlcategory.SelectedValue == "" ? "0" : ddlcategory.SelectedValue);

            List<EmployeeSalary> result = objempBO.GenerateEmployeesalary(objemp);
            if (result.Count > 0)
            {
                GVsalarygenerator.DataSource = result;
                GVsalarygenerator.DataBind();
                GVsalarygenerator.Visible = true;
                if (ddlstatus.SelectedValue == "2")
                {
                    lblcasule.Text = "Total Paid Salary Amount";
                    lbltotalpaid.Text = Commonfunction.Getrounding(result[0].TotalPaidAmount.ToString());

                }
                if (ddlstatus.SelectedValue == "1")
                {
                    lblcasule.Text = "Total Unpaid Paid Salary Amount";
                    lbltotalpaid.Text = Commonfunction.Getrounding(result[0].TotalPaidAmount.ToString());

                }
                if (ddlisdeleted.SelectedValue == "2")
                {
                    lblcasule.Text = "Total Deleted Salary Amount";
                    lbltotalpaid.Text = Commonfunction.Getrounding(result[0].TotalPaidAmount.ToString());

                }
                //if (ddlisdeleted.SelectedValue == "1")
                //{
                //    lblcasule.Text = "Total Deleted Salary Amount";
                //    lbltotalpaid.Text = Commonfunction.Getrounding(result[0].TotalPaidAmount.ToString());

                //}
                //.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                //lblattendanelist.CssClass = "MsgSuccess";

            }
            else
            {
                GVsalarygenerator.DataSource = null;
                GVsalarygenerator.DataBind();
                GVsalarygenerator.Visible = true;
                lbltotalpaid.Text = "00.00";
                //lblattendanelist.Text = "Total :No record found. ";
                //lblattendanelist.CssClass = "Message";
                //lblattendanelist.Visible = true;
            }

        }
        protected void calculatesalary()
        {
            foreach (GridViewRow row in GVsalarygenerator.Rows)
            {
                try
                {
                    Label LeaveCount = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblleave");
                    Label AbsentCount = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblabsent");
                    Label Basic = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblbasic");
                    Label Increament = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblincreament");

                    TextBox Salary = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txttotalsalary");
                    TextBox Bonus = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txtbonus");
                    TextBox Incentive = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txtincentive");
                    TextBox Allowance = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txtallowance");
                    TextBox Surplus = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txtsurplus");
                    TextBox Proxy = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txtproxy");
                    TextBox Subduction = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txtsubduction");

                    decimal Totalsalary = Convert.ToDecimal(Basic.Text) + Convert.ToDecimal(Increament.Text)
                                        + Convert.ToDecimal(Bonus.Text) + Convert.ToDecimal(Incentive.Text)
                                        + Convert.ToDecimal(Allowance.Text) + Convert.ToDecimal(Surplus.Text)
                                        + Convert.ToDecimal(Proxy.Text) - Convert.ToDecimal(Subduction.Text);
                    Salary.Text = Commonfunction.Getrounding(Totalsalary.ToString());
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void txtbonus_TextChanged(object sender, EventArgs e)
        {
            calculatesalary();
        }
        protected void txtincentive_TextChanged(object sender, EventArgs e)
        {
            calculatesalary();
        }
        protected void txtallowance_TextChanged(object sender, EventArgs e)
        {
            calculatesalary();
        }
        protected void txtsurplus_TextChanged(object sender, EventArgs e)
        {
            calculatesalary();
        }
        protected void txtproxy_TextChanged(object sender, EventArgs e)
        {
            calculatesalary();
        }
        protected void txtsubduction_TextChanged(object sender, EventArgs e)
        {
            calculatesalary();
        }
        protected void GVsalarygenerator_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GVsalarygenerator.Rows)
            {
                try
                {
                    Label LeaveCount = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblleave");
                    Label AbsentCount = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblabsent");
                    Label Basic = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblbasic");
                    Label Increament = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblincreament");
                    TextBox Salary = (TextBox)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("txttotalsalary");
                    Label Status = (Label)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("lblstatus");
                    Button btnupdate = (Button)GVsalarygenerator.Rows[row.RowIndex].Cells[0].FindControl("btnupdate");
                    if (Status.Text == "Unpaid")
                    {
                        btnupdate.Enabled = true;

                        int countLA = Convert.ToInt16(LeaveCount.Text) + Convert.ToInt16(AbsentCount.Text);
                        decimal totalsalary = Convert.ToDecimal(Basic.Text) + Convert.ToDecimal(Increament.Text);
                        if (countLA > 2)
                        {
                            decimal deduction = (totalsalary / 30) * (countLA - 2);
                            Salary.Text = Commonfunction.Getrounding((totalsalary - deduction).ToString());

                        }
                        else
                        {
                            Salary.Text = Commonfunction.Getrounding(totalsalary.ToString());

                        }
                    }
                    else
                    {
                        btnupdate.Enabled = false;

                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }

        protected void GVsalarygenerator_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Updates")
                {
                    EmployeeSalary objemp = new EmployeeSalary();
                    EmployeeBO objempBO = new EmployeeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GVsalarygenerator.Rows[i];
                    Label SalaryID = (Label)gr.Cells[0].FindControl("lblID");
                    Label EmpNo = (Label)gr.Cells[0].FindControl("lblNo");

                    TextBox Salary = (TextBox)gr.Cells[0].FindControl("txttotalsalary");
                    TextBox Bonus = (TextBox)gr.Cells[0].FindControl("txtbonus");
                    TextBox Incentive = (TextBox)gr.Cells[0].FindControl("txtincentive");
                    TextBox Allowance = (TextBox)gr.Cells[0].FindControl("txtallowance");
                    TextBox Surplus = (TextBox)gr.Cells[0].FindControl("txtsurplus");
                    TextBox Proxy = (TextBox)gr.Cells[0].FindControl("txtproxy");
                    TextBox Subduction = (TextBox)gr.Cells[0].FindControl("txtsubduction");

                    Button btnupdate = (Button)gr.Cells[0].FindControl("btnupdate");

                    objemp.SalaryGeneratorID = Convert.ToInt32(SalaryID.Text);
                    objemp.EmployeeNo = EmpNo.Text;
                    objemp.AcademicSessionID = Convert.ToInt32(ddlfinancialyear.SelectedValue == "" ? "0" : ddlfinancialyear.SelectedValue);

                    objemp.Bonus = Convert.ToDecimal(Bonus.Text);
                    objemp.Incentives = Convert.ToDecimal(Incentive.Text);
                    objemp.Allowance = Convert.ToDecimal(Allowance.Text);
                    objemp.Surplus = Convert.ToDecimal(Surplus.Text);
                    objemp.Proxy = Convert.ToDecimal(Proxy.Text);
                    objemp.Subduction = Convert.ToDecimal(Subduction.Text);
                    objemp.SalaryAmount = Convert.ToDecimal(Salary.Text);
                    objemp.MonthID = Convert.ToInt32(ddlmonth.SelectedValue == "" ? "0" : ddlmonth.SelectedValue);
                    objemp.UserId = LoginToken.UserLoginId;
                    objemp.AddedBy = LoginToken.LoginId;

                    int Result = objempBO.UpdateEmployeeSalary(objemp);
                    if (Result == 1)
                    {
                        Generatesalary();
                        btnupdate.Enabled = false;
                        Messagealert_.ShowMessage(lblmessage, "Updated Successfully", 1);
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    EmployeeSalary objemp = new EmployeeSalary();
                    EmployeeBO objempBO = new EmployeeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GVsalarygenerator.Rows[i];
                    Label SalaryID = (Label)gr.Cells[0].FindControl("lblID");


                    objemp.SalaryGeneratorID = Convert.ToInt32(SalaryID.Text);
                    objemp.UserId = LoginToken.UserLoginId;
                    objemp.AddedBy = LoginToken.LoginId;

                    int Result = objempBO.DeletSalaryDetailsByID(objemp);
                    if (Result == 1)
                    {
                        Generatesalary();
                        Messagealert_.ShowMessage(lblmessage, "Deleted Successfully", 1);
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

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtempID.Text = "";
            txtdepartment.Text = "";
            txtempname.Text = "";
            ddlmonth.SelectedIndex = 0;
            ddlstatus.SelectedIndex = 0;
            GVsalarygenerator.DataSource = null;
            GVsalarygenerator.DataBind();
            GVsalarygenerator.Visible = false;
            ddlcategory.SelectedIndex = 0;
            lblmessage.Visible = false;

        }
    }
}