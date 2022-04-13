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

namespace Mobimp.Campusoft.Web.EduSMS.Reports
{
    public partial class ReportViewer : BasePage
    {
        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
        ReportDocument reportDocument = new ReportDocument();
        ParameterFields paramFields = new ParameterFields();
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
                ParameterField paramLoginName = new ParameterField();
                ParameterDiscreteValue paramDiscreteLoginName = new ParameterDiscreteValue();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                paramLoginName.Name = "@LoginName";
                paramDiscreteLoginName.Value = LoginToken.LoginId;
                paramLoginName.CurrentValues.Add(paramDiscreteLoginName);
                paramFields.Add(paramLoginName);

                switch (Request["option"].ToString())
                {

                    case "SmsHistory":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("SMSHistoryList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_EduSMS_GetHeaderSmsHistoryRPT";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@SmsID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["SmsID"].ToString() == "" ? "0" : Request["SmsID"].ToString());
                                    cmd.Parameters.Add("@SentToID", SqlDbType.Int).Value = Convert.ToInt32(Request["SentToID"].ToString() == "" ? "0" : Request["SentToID"].ToString());
                                    cmd.Parameters.Add("@SmsTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["SmsTypeID"].ToString() == "" ? "0" : Request["SmsTypeID"].ToString());
                                    cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = Convert.ToInt32(Request["StatusID"].ToString() == "" ? "10" : Request["StatusID"].ToString());
                                    cmd.Parameters.Add("@SentByID", SqlDbType.Int).Value = Convert.ToInt32(Request["SentByID"].ToString() == "" ? "0" : Request["SentByID"].ToString());
                                    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Request["DateFrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["DateFrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Request["DateTo"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["DateTo"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "SmsHistoryRPT");
                        break;

                    case "SpecificStudentSmsHistory":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("SMSHistoryList_StudentSpecific.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_EduSMS_GetFooterSmsHistoryRPT";
                                    cmd.Parameters.Add("@SmsID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["SmsID"].ToString() == "" ? "0" : Request["SmsID"].ToString());
                                    cmd.Parameters.Add("@SendToID", SqlDbType.Int).Value = Convert.ToInt32(Request["SendToID"].ToString() == "" ? "0" : Request["SendToID"].ToString());
                                    cmd.Parameters.Add("@SmsTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["SmsTypeID"].ToString() == "" ? "0" : Request["SmsTypeID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "DetailedStudentSmsHistory");
                        break;

                    case "SpecificEmployeeSmsHistory":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("SMSHistoryList_EmployeeSpecific.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_EduSMS_GetFooterSmsHistoryRPT";
                                    cmd.Parameters.Add("@SmsID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["SmsID"].ToString() == "" ? "0" : Request["SmsID"].ToString());
                                    cmd.Parameters.Add("@SendToID", SqlDbType.Int).Value = Convert.ToInt32(Request["SendToID"].ToString() == "" ? "0" : Request["SendToID"].ToString());
                                    cmd.Parameters.Add("@SmsTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["SmsTypeID"].ToString() == "" ? "0" : Request["SmsTypeID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "DetailedEmployeeSmsHistory");
                        break;
                }
            }
        }
    }
}