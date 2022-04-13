using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Globalization;

namespace Mobimp.Edusoft.Web.EduEmployee
{
    public partial class EployeeLeaveApproval : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            objemp.IsActive = true;
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
        protected void GvemployeeLeave_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "save")
                {
                    EmployeeLeaveData objemp = new EmployeeLeaveData();
                    EmployeeBO objempBO = new EmployeeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvemployeeLeave.Rows[i];
                    Label LeaveID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox txtdatefrom = (TextBox)gr.Cells[3].FindControl("txtdatefrom");
                    TextBox txtdateto = (TextBox)gr.Cells[4].FindControl("txtdateto");
                    TextBox txtdays = (TextBox)gr.Cells[6].FindControl("txtdays");
                    Label lblnoofdays = (Label)gr.Cells[5].FindControl("lblnoofdays");
                    DropDownList status = (DropDownList)gr.Cells[8].FindControl("ddlstatus");
                    TextBox txtRremarks = (TextBox)gr.Cells[3].FindControl("txtRremarks");

                    if (status.SelectedItem.Value == "0")
                    {
                        Messagealert_.ShowMessage(lblmessage, "Please select status.", 0);
                        return;
                    }
                    else if (status.SelectedItem.Value == "1")
                    {

                        if (txtdays.Text == "0" || txtdays.Text == "")
                        {
                            Messagealert_.ShowMessage(lblmessage, "Please enter no of approved days.", 0);
                            return;
                        }
                        else if (Convert.ToInt32(txtdays.Text) > Convert.ToInt32(lblnoofdays.Text))
                        {
                            Messagealert_.ShowMessage(lblmessage, "Approved days could not be greater than request days.", 0);
                            return;
                        }
                        else
                        {
                            objemp.ApprovedDays = Convert.ToInt32(txtdays.Text == "" ? "0" : txtdays.Text);
                        }
                    }
                    if (status.SelectedItem.Value == "2")
                    {
                        if (txtRremarks.Text == "")
                        {
                            Messagealert_.ShowMessage(lblmessage, "Please enter rejection remarks.", 0);
                            return;
                        }
                        else
                        {
                            objemp.RejRemarks = txtRremarks.Text;
                        }
                    }
                    objemp.LeaveStatus = Convert.ToInt32(status.SelectedValue == "" ? "0" : status.SelectedValue);
                    objemp.LeaveID = Convert.ToInt32(LeaveID.Text);
                    objemp.DateFrom = Convert.ToDateTime(txtdatefrom.Text);
                    objemp.DateTo = Convert.ToDateTime(txtdateto.Text);
                    objemp.AprroveBy = LoginToken.LoginId;
                    int Result = objempBO.UpdateLeaveStatus(objemp);
                    if (Result == 1)
                    {
                        Messagealert_.ShowMessage(lblmessage, "Save Successfully", 1);
                        Getleavedetails();
                    }
                    else
                    {
                        Messagealert_.ShowMessage(lblmessage, " Could not Save Successfully", 1);

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
        protected void GvemployeeLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvemployeeLeave.Rows)
            {
                try
                {
                    Label Lstatus = (Label)GvemployeeLeave.Rows[row.RowIndex].Cells[8].FindControl("lblststus");
                    Label lblaproveddate = (Label)GvemployeeLeave.Rows[row.RowIndex].Cells[8].FindControl("lblaproveddate");
                    TextBox txtdays = (TextBox)GvemployeeLeave.Rows[row.RowIndex].Cells[8].FindControl("txtdays");
                    TextBox txtdatefrom = (TextBox)GvemployeeLeave.Rows[row.RowIndex].Cells[8].FindControl("txtdatefrom");
                    TextBox txtdateto = (TextBox)GvemployeeLeave.Rows[row.RowIndex].Cells[8].FindControl("txtdateto");
                    DropDownList ddlstatus = (DropDownList)GvemployeeLeave.Rows[row.RowIndex].Cells[8].FindControl("ddlstatus");
                    Button btn = (Button)GvemployeeLeave.Rows[row.RowIndex].Cells[8].FindControl("btnapprove");
                    if (Lstatus.Text == "1" || Lstatus.Text == "2")
                    {
                        ddlstatus.Items.FindByValue(Lstatus.Text).Selected = true;
                        btn.Enabled = false;
                        ddlstatus.Enabled = false;
                        txtdays.Enabled = false;
                    }
                    else
                    {
                        btn.Enabled = true;
                        ddlstatus.Enabled = true;
                        txtdays.Enabled = true;
                    }
                    if (lblaproveddate.Text == "01-01-0001")
                    {
                        lblaproveddate.Text = "00:00:0000";

                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }

        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlldropdown = (DropDownList)sender;
            if (ddlldropdown.SelectedIndex == 1)
            {

                Messagealert_.ShowMessage(lblmessage, "Please Keep in mind to select correct date range and number of approved days while doing  approval", 1);
            }
            else if (ddlldropdown.SelectedIndex == 2)
            {

                Messagealert_.ShowMessage(lblmessage, "Please enter Rejection Remarks", 1);
            }
            else
            {
                lblmessage.Visible = false;
            }


        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            txtempID.Text = "";
            GvemployeeLeave.DataSource = "";
            GvemployeeLeave.DataBind();
            GvemployeeLeave.Visible = false;

        }

        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnprint_Click(object sender, EventArgs e)
        {

        }


    }
}