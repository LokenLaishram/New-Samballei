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
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.Web.EduEmployee
{
    public partial class LeaveCorrector : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddls();
            }
        }
        protected void bindddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsessions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlsessions.SelectedIndex = 1;
        }
        protected void btnsearchattendance_Click(object sender, EventArgs e)
        {
            bindgrid();
        }
        protected void bindgrid()
        {
            EmployeeAttendanceData objemp = new EmployeeAttendanceData();
            EmployeeBO objempBO = new EmployeeBO();

            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objemp.EmployeeNo = txtemployeesID.Text;
            objemp.EmpName = txtemployee.Text == "" ? null : txtemployee.Text;
            objemp.AcademicSessionID = Convert.ToInt32(ddlsessions.SelectedValue == "" ? "0" : ddlsessions.SelectedValue);
            objemp.Datefrom = from;
            objemp.Dateto = To;
            List<EmployeeAttendanceData> result = objempBO.GetEmpattendance(objemp);
            if (result.Count > 0)
            {
                Gvattendancedetaillist.DataSource = result;
                Gvattendancedetaillist.DataBind();
                Gvattendancedetaillist.Visible = true;
            }
            else
            {
                Gvattendancedetaillist.DataSource = null;
                Gvattendancedetaillist.DataBind();
                Gvattendancedetaillist.Visible = true;

            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<EmployeeAttendanceData> lstattendance = new List<EmployeeAttendanceData>();
            EmployeeAttendanceData objstd = new EmployeeAttendanceData();
            EmployeeBO objempBO = new EmployeeBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in Gvattendancedetaillist.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label EmpID = (Label)Gvattendancedetaillist.Rows[index].Cells[0].FindControl("lblID");
                    TextBox Attendance = (TextBox)Gvattendancedetaillist.Rows[index].Cells[0].FindControl("Attendance");
                    Label Date = (Label)Gvattendancedetaillist.Rows[index].Cells[0].FindControl("lbldate");
                    EmployeeAttendanceData ObjDetails = new EmployeeAttendanceData();
                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    DateTime AttendanceDate = Date.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    ObjDetails.EmployeeID = Convert.ToInt32(EmpID.Text);
                    ObjDetails.AddedDate = AttendanceDate;
                    ObjDetails.Attendance = Attendance.Text;
                    ObjDetails.AddedBy = LoginToken.LoginId;

                    lstattendance.Add(ObjDetails);
                    index++;
                }
                objstd.XmlEmployeeAttendancelist = XmlConvertor.EmployeeAttendancelisttoXML(lstattendance).ToString();
                int results = objempBO.UpdateEmployeeAttenedance(objstd);
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