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

namespace Mobimp.Edusoft.Web.EduHRAndPayroll.HR.Reports
{
    public partial class ReportViewer : BasePage
    {
        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
        ReportDocument reportDocument = new ReportDocument();
        string constr = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
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
                CrystalReportViewer1.RefreshReport();

                switch (Request["option"].ToString())
                {
                    case "LoanPayment":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("LoanPaymentReceipt.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_HR_Payroll_LoanPaymentReceiptRPT";
                                    cmd.Parameters.Add("@LoanPaymentNo", SqlDbType.VarChar).Value = Convert.ToString(Request["LoanPaymentNo"].ToString() == "" ? "0" : Request["LoanPaymentNo"].ToString());
                                    cmd.Parameters.Add("@LoanTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["LoanTypeID"].ToString() == "" ? "0" : Request["LoanTypeID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "LoanPaymentReceipt");
                        break;

                    case "LoanPaymentDetailed":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("LoanPaymentDetailed.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_HR_Payroll_GetLoanRecordDetailsRPT";
                                    cmd.Parameters.Add("@LoanPaymentNo", SqlDbType.VarChar).Value = Convert.ToString(Request["LoanPaymentNo"].ToString() == "" ? "0" : Request["LoanPaymentNo"].ToString());
                                    cmd.Parameters.Add("@LoanTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["LoanTypeID"].ToString() == "" ? "0" : Request["LoanTypeID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "LoanPaymentDetailed");
                        break;

                    case "LoanPaymentList":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("LoanPaymentList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_HR_Payroll_GetLoanRecordDetailsRPT";
                                    cmd.Parameters.Add("@EmpID", SqlDbType.BigInt).Value = Convert.ToInt32(Request["EmpID"].ToString() == "" ? "0" : Request["EmpID"].ToString());
                                    cmd.Parameters.Add("@LoanTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["LoanTypeID"].ToString() == "" ? "0" : Request["LoanTypeID"].ToString());
                                    cmd.Parameters.Add("@LoanStatusID", SqlDbType.Int).Value = Convert.ToInt32(Request["LoanStatus"].ToString() == "" ? "0" : Request["LoanStatus"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Convert.ToInt32(Request["IsActive"].ToString() == "" ? "0" : Request["IsActive"].ToString());
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "LoanPaymentList");
                        break;

                    case "ManualAttendance":
                        DataTable dt4 = new DataTable();
                        reportDocument.Load(Server.MapPath("ManualAttendance.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_HR_Payroll_PrintManualAttendanceList";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Request["Date"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Date"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt4);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt4);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ManualAttendanceList");
                        break;


                }
            }

        }

    }
}