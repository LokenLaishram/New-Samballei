using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Data.EduEmployee;
using System.IO;
using Mobimp.Edusoft.Common;
using System.Globalization;

namespace Mobimp.Edusoft.Web.EduEmployee
{
    public partial class EmployeeLeaveRequest : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeLeaveData objemp = new EmployeeLeaveData();
                EmployeeBO objempBO = new EmployeeBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime from = txtdatefrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdatefrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                DateTime To = txtdateto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtdateto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                string Today = DateTime.Today.ToString("dd-MM-yyyy");
                string FromDate = Convert.ToDateTime(txtdatefrom.Text).ToString("dd-MM-yyyy");
                string ToDate = Convert.ToDateTime(txtdateto.Text).ToString("dd-MM-yyyy");
                DateTime Today1 = DateTime.ParseExact(Today, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime From1 = DateTime.ParseExact(FromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime To1 = DateTime.ParseExact(ToDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                if ((From1 - To1).TotalDays > 0)
                {
                    Messagealert_.ShowMessage(lblmessage, "From Date Should not be greater than Todate", 0);
                    return;
                }

                if ((From1 - Today1).TotalDays < 1 || (To1 - Today1).TotalDays < 1)
                {
                    Messagealert_.ShowMessage(lblmessage, "Leave Should be taken Before One day", 0);
                    return;
                }

                string empFile = FileUploader.FileName.ToString();
                if (empFile == "")
                {
                    objemp.LeaveDocumentpath = "../EduImages/EmpDummyPh.jpg";
                }
                else
                {
                    if (!FileUploader.HasFile)
                    {
                        Messagealert_.ShowMessage(lblmessage, "system", 0);
                        return;
                    }
                    ////if (!".jpg,.jpeg,.gif,.png".Contains(Path.GetExtension(empFile.ToLower())))
                    ////{
                    ////    Messagealert_.ShowMessage(lblmessage, "system", 0);
                    ////    return;
                    ////}
                    string EmpPath = Getlevedocpath(empFile); ;
                    objemp.LeaveDocumentpath = EmpPath;

                    if (EmpPath == "fail" || objemp.LeaveDocumentpath == "")
                    {
                        Messagealert_.ShowMessage(lblmessage, "system", 0);
                        return;
                    }
                }
                objemp.EmployeeNo = txtempID.Text == "" ? "0" : txtempID.Text;
                objemp.Remarks = txtremarks.Text;
                objemp.DateFrom = from;
                objemp.DateTo = To;
                objemp.NosDays = Convert.ToInt32(txtdays.Text == "" ? "0" : txtdays.Text);
                objemp.AddedBy = LoginToken.LoginId;
                objemp.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
                objemp.UserId = LoginToken.UserLoginId; ;
                objemp.CompanyID = LoginToken.CompanyID;
                objemp.AcademicSessionID = LoginToken.AcademicSessionID;
                objemp.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objemp.ActionType = EnumActionType.Update;
                    objemp.LeaveID = Convert.ToInt32(ViewState["ID"].ToString());
                    if (empFile == null || empFile == "")
                    {
                        objemp.LeaveDocumentpath = ViewState["LeaveDocs"].ToString();
                        ViewState["LeaveDocs"] = null;
                    }
                }
                int result = objempBO.UpdateEmployeeLeaveDetails(objemp);
                if (result == 1 || result == 2)
                {
                    Messagealert_.ShowMessage(lblmessage, result == 1 ? "save" : "update", 1);
                    resetall();
                    Getleavedetails();
                    lblmessage.Visible = true;
                }
                else if (result == 5)
                {
                    Messagealert_.ShowMessage(lblmessage, "Already requested for this Date range.Please edit in the existing request.", 0);
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
        protected string Getlevedocpath(string fileName)
        {
            string path = "";
            // fileName = txtempname.Text.Trim() + "_" + fileName;
            try
            {
                if (Directory.Exists(Request.PhysicalApplicationPath + @"EmpLeaveDocs/") == false)
                    Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EmpLeaveDocs/");

                if (File.Exists(Request.PhysicalApplicationPath + @"EmpLeaveDocs/" + fileName))
                {
                    File.Delete(Request.PhysicalApplicationPath + @"EmpLeaveDocs/" + fileName);
                    // return "exist";
                }

                FileUploader.SaveAs(Request.PhysicalApplicationPath + @"EmpLeaveDocs/" + fileName);
                path = @"EmpLeaveDocs/" + fileName;
            }
            catch
            {
                return "fail";
            }

            return path;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Getleavedetails();
        }
        protected void Getleavedetails()
        {
            EmployeeLeaveData objemp = new EmployeeLeaveData();
            EmployeeBO objempBO = new EmployeeBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtdatefrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdatefrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtdateto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtdateto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objemp.EmployeeNo = txtempID.Text == "" ? null : txtempID.Text;
            objemp.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objemp.DateFrom = from;
            objemp.DateTo = To;

            List<EmployeeLeaveData> result = objempBO.SearchEmployeeLeaveDetails(objemp);
            if (result.Count > 0)
            {
                GvemployeeLeave.DataSource = result;
                GvemployeeLeave.DataBind();
                GvemployeeLeave.Visible = true;
            }
            else
            {
                GvemployeeLeave.DataSource = null;
                GvemployeeLeave.DataBind();
                GvemployeeLeave.Visible = true;

            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
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
            }

        }
        private void resetall()
        {
            txtempID.Text = "";
            txtempname.Text = "";
            txtdepartment.Text = "";
            txtremarks.Text = "";
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            lblmessage.Visible = true;
            GvemployeeLeave.DataSource = null;
            GvemployeeLeave.DataBind();
            GvemployeeLeave.Visible = false;
            lblmessage.Visible = false;
            txtdays.Text = "";
            ViewState["ID"] = null;
        }
        private void Getemployeedetails(int LeaveID)
        {
            EmployeeLeaveData objemp = new EmployeeLeaveData();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.LeaveID = LeaveID;
            List<EmployeeLeaveData> GetResult = objempBO.GetEmployeeLeaveDetailsByID(objemp);
            if (GetResult.Count > 0)
            {
                txtempID.Text = GetResult[0].EmployeeNo.ToString();
                txtempname.Text = GetResult[0].EmpName.ToString();
                txtdepartment.Text = GetResult[0].Department.ToString();
                txtremarks.Text = GetResult[0].Remarks.ToString();
                txtdatefrom.Text = GetResult[0].DateFrom.ToString("dd/MM/yyyy");
                txtdateto.Text = GetResult[0].DateTo.ToString("dd/MM/yyyy");
                txtdays.Text = GetResult[0].NosDays.ToString();
                ViewState["ID"] = GetResult[0].LeaveID.ToString();
                ViewState["LeaveDocs"] = GetResult[0].LeaveDocumentpath.ToString();
            }
        }
        protected void GvemployeeLeave_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvemployeeLeave.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    int LeaveID = Convert.ToInt32(ID.Text);
                    Getemployeedetails(LeaveID);

                }
                if (e.CommandName == "Deletes")
                {
                    EmployeeLeaveData objemp = new EmployeeLeaveData();
                    EmployeeBO objempBO = new EmployeeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvemployeeLeave.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objemp.LeaveID = Convert.ToInt32(ID.Text);
                    int Result = objempBO.DeleteEmployeeLeaveDetailsByID(objemp);
                    if (Result == 1)
                    {
                        Messagealert_.ShowMessage(lblmessage, "delete", 1);
                        Getleavedetails();
                    }
                    else
                    {
                        Messagealert_.ShowMessage(lblmessage, "Could not deleted.", 0);
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

    }
}