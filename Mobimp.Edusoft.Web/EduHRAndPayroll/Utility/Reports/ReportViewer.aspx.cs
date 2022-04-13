using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Mobimp.Edusoft.Common;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Mobimp.Edusoft.Web.EduHRAndPayroll.Utility.Reports
{
    public partial class ReportViewer : BasePage
    {
        ReportDocument reportDocument = new ReportDocument();
        ParameterFields paramFields = new ParameterFields();
        CrystalReportSource crystalReportSource = new CrystalReportSource();
        string constr = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
        string ReportUserId = ConfigurationManager.AppSettings["ReportUserId"];
        string ReportServerName = ConfigurationManager.AppSettings["ReportServerName"];
        string ReportDatabase = ConfigurationManager.AppSettings["ReportDatabase"];
        string ReportPassword = ConfigurationManager.AppSettings["ReportPassword"];
        protected void Page_Unload(Object sender, EventArgs evntArgs)
        {
            reportDocument.Close();
            reportDocument.Dispose();
            reportDocument = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["option"] != null)
            {
                ParameterField paramLoginName = new ParameterField();
                ParameterDiscreteValue paramDiscreteLoginName = new ParameterDiscreteValue();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                paramLoginName.Name = "@LoginName";
                paramDiscreteLoginName.Value = LoginToken.LoginId;
                paramLoginName.CurrentValues.Add(paramDiscreteLoginName);
                paramFields.Add(paramLoginName);

                CrystalReportViewer1.RefreshReport();
                switch (Request["option"].ToString())
                {
                    case "LeaveType":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("LeaveTypeMST.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_HR_Payroll_PrintLeaveTypeDetailsMST";
                                    cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Convert.ToString(Request["Code"].ToString() == "" ? "0" : Request["Code"].ToString());
                                    cmd.Parameters.Add("@LeaveType", SqlDbType.VarChar).Value = Convert.ToString(Request["Name"].ToString() == "" ? "0" : Request["Name"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Request["Status"] == "1" ? true : false;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "LeaveType");
                        break;

                    case "HolidayList":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("HolidayList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_HR_Payroll_PrintHolidayList_RPT";
                                    cmd.Parameters.Add("@YearID", SqlDbType.Int).Value = Convert.ToString(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HolidayList");
                        break;
                    case "Roster":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("Roster.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_HR_Payroll_Print_Roster_rpt";
                                    cmd.Parameters.Add("@SessionID", SqlDbType.Int).Value = Convert.ToString(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToString(Request["MonthID"].ToString() == "" ? "0" : Request["MonthID"].ToString());
                                    cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToString(Request["EmployeeID"].ToString() == "" ? "0" : Request["EmployeeID"].ToString());
                                    cmd.Parameters.Add("@ShiftID", SqlDbType.Int).Value = Convert.ToString(Request["ShiftID"].ToString() == "" ? "0" : Request["ShiftID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HolidayList");
                        break;
                }

            }

        }
    }
}