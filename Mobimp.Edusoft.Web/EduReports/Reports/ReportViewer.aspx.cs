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

namespace Mobimp.Edusoft.Web.EduReports.Reports
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
        string Year;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["option"] != null)
            {
                CrystalReportViewer1.RefreshReport();

                switch (Request["option"].ToString())
                {

                    case "DefaulterList":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("Defaulterlist.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_GetFeeDefaulterListRPT";
                                    cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                                    cmd.Parameters.Add("@Sfirstname", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "1" ? Request["SearchBy"].ToString() : null;
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToInt32(Request["MonthID"].ToString() == "" ? "0" : Request["MonthID"].ToString());
                                    cmd.Parameters.Add("@ActionType", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = Convert.ToInt32(Request["CategoryID"].ToString() == "" ? "0" : Request["CategoryID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                        break;

                    case "CharacterAnalys":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("CharacterAnalys.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_SearchCharacterAnalysRPT";
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToInt32(Request["MonthID"].ToString() == "" ? "0" : Request["MonthID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                        break;

                    case "Expenditure":
                        DataTable dt4 = new DataTable();
                        reportDocument.Load(Server.MapPath("Expenditurelist.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_GetFeeDefaulterListRPT";
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@StudentCategrory", SqlDbType.Int).Value = Convert.ToInt32(Request["CategoryID"].ToString() == "" ? "0" : Request["CategoryID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"].ToString() == "1" ? true : false;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt4);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt4);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                        break;

                    case "IDcard":
                        DataTable dt5 = new DataTable();
                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/Certificates/IDcard.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_GenarateIDCard";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@StudentCategory", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt5);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt5);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                        break;

                    case "Character":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/Certificates/ReadingCharacterCertificate.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    //usp_CMS_Std_SearchPTCertificateRPT
                                    DateTime printdate = Request["PrintDate"].ToString().Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["PrintDate"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_SearchCTPCertificateRPT";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@CertificateType", SqlDbType.Int).Value = Convert.ToInt32(Request["CertificateType"].ToString() == "" ? "0" : Request["CertificateType"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = printdate;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "CharacterCertificate");
                        break;

                    case "Transfer":
                        DataTable dt6 = new DataTable();
                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/Certificates/TransferCertificate.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    DateTime printdate = Request["PrintDate"].ToString().Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["PrintDate"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_SearchCTPCertificateRPT";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@CertificateType", SqlDbType.Int).Value = Convert.ToInt32(Request["CertificateType"].ToString() == "" ? "0" : Request["CertificateType"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = printdate;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt6);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt6);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "TransferCertificate");
                        break;

                    case "Provisional":
                        DataTable dt7 = new DataTable();
                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/Certificates/ProvisionalCertificate.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    DateTime printdate = Request["PrintDate"].ToString().Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["PrintDate"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_SearchCTPCertificateRPT";
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@CertificateType", SqlDbType.Int).Value = Convert.ToInt32(Request["CertificateType"].ToString() == "" ? "0" : Request["CertificateType"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = printdate;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt7);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt7);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ProvisionalCertificate");
                        break;

                    case "LowerReading":
                        DataTable dt8 = new DataTable();
                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/Certificates/ReadingCertificate.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {

                                    DateTime printdate = Request["PrintDate"].ToString().Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["PrintDate"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_SearchCTPCertificateRPT";
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@CertificateType", SqlDbType.Int).Value = Convert.ToInt32(Request["CertificateType"].ToString() == "" ? "0" : Request["CertificateType"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = printdate;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt8);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt8);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                        break;

                    case "PrintBroadsheet":
                        DataTable dt9 = new DataTable();

                        Year = Request["Year"].ToString();

                        if (Request["ClassID"].ToString() == "1")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_LowerNursery_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "2")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_UpperNursery_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "3")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_Primary_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "4")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_I_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "5" || Request["ClassID"].ToString() == "6" || Request["ClassID"].ToString() == "7" || Request["ClassID"].ToString() == "8")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_II_V_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "9")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_VI_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "10")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_VII_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "11")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_VIII_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "12" || Request["ClassID"].ToString() == "13")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/BroadsheetResult_IX_X_" + Year + ".rpt"));
                        }
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintMarkSheet";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["Roll"].ToString() == "" ? "0" : Request["Roll"].ToString());
                                    cmd.Parameters.Add("@Rankshow", SqlDbType.Int).Value = Convert.ToInt32(Request["Rankshow"].ToString() == "" ? "0" : Request["Rankshow"].ToString());
                                    cmd.Parameters.Add("@FeeStatus", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeStatus"].ToString() == "" ? "0" : Request["FeeStatus"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt9);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt9);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "BroadSheet");
                        break;

                    case "PrintMarksheet":
                        DataTable dt13 = new DataTable();

                        Year = Request["Year"].ToString();

                        if (Request["ClassID"].ToString() == "1")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_LowerNursery_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "2")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_UpperNursery_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "3")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_Primary_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "4")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_I_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "5" || Request["ClassID"].ToString() == "6" || Request["ClassID"].ToString() == "7" || Request["ClassID"].ToString() == "8")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_II_V_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "9")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_VI_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "10")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_VII_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "11")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_VIII_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "12" || Request["ClassID"].ToString() == "13")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/Marksheet_IX_X_" + Year + ".rpt"));
                        }
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintMarkSheet";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["Roll"].ToString() == "" ? "0" : Request["Roll"].ToString());
                                    cmd.Parameters.Add("@Rankshow", SqlDbType.Int).Value = Convert.ToInt32(Request["Rankshow"].ToString() == "" ? "0" : Request["Rankshow"].ToString());
                                    cmd.Parameters.Add("@FeeStatus", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeStatus"].ToString() == "" ? "0" : Request["FeeStatus"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt13);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt13);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;

                    case "PrintOverallBroadsheet":
                        DataTable dt10 = new DataTable();
                        Year = Request["Year"].ToString();

                        if (Request["ClassID"].ToString() == "1" || Request["ClassID"].ToString() == "2")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallBroadsheetResult_Pre_Nry_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "3")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallBroadsheetResult_KG_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "4" || Request["ClassID"].ToString() == "5")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallBroadsheetResult_I_II_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "6" || Request["ClassID"].ToString() == "7" || Request["ClassID"].ToString() == "8")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallBroadsheetResult_III_V_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "9" || Request["ClassID"].ToString() == "10" || Request["ClassID"].ToString() == "11")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallBroadsheetResult_VI_VIII_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "12" || Request["ClassID"].ToString() == "13")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallBroadsheetResult_IX_X_" + Year + ".rpt"));
                        }
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintOvearllMarkSheet";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["Roll"].ToString() == "" ? "0" : Request["Roll"].ToString());
                                    cmd.Parameters.Add("@Rankshow", SqlDbType.Int).Value = Convert.ToInt32(Request["Rankshow"].ToString() == "" ? "0" : Request["Rankshow"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt10);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt10);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;

                    case "PrintOverallMarksheet":
                        DataTable dt11 = new DataTable();
                        Year = Request["Year"].ToString();
                        if (Request["ClassID"].ToString() == "1" || Request["ClassID"].ToString() == "2")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallMarkSheet_Pre_Nry_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "3")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallMarkSheet_KG_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "4" || Request["ClassID"].ToString() == "5")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallMarkSheet_I_II_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "6" || Request["ClassID"].ToString() == "7" || Request["ClassID"].ToString() == "8")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallMarkSheet_III_IV_V_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "9" || Request["ClassID"].ToString() == "10" || Request["ClassID"].ToString() == "11")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallMarkSheet_VI_VII_VIII_" + Year + ".rpt"));
                        }
                        if (Request["ClassID"].ToString() == "12" || Request["ClassID"].ToString() == "13")
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/" + Year + "/OverallMarkSheet_IX_X_" + Year + ".rpt"));
                        }
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_Print_Classwise_OvearllMarkSheet";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    //  cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["Roll"].ToString() == "" ? "0" : Request["Roll"].ToString());
                                    cmd.Parameters.Add("@Rankshow", SqlDbType.Int).Value = Convert.ToInt32(Request["Rankshow"].ToString() == "" ? "0" : Request["Rankshow"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt11);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt11);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;


                    case "AdmitCard":
                        DataTable dt12 = new DataTable();
                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/Certificates/AdmitCard.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    IFormatProvider opt = new System.Globalization.CultureInfo("en-GB", true);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_GetAdmitCardRPT";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt12);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt12);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                        break;
                }
            }
        }
    }
}