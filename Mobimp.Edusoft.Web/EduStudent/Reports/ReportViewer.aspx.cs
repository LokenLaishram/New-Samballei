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

namespace Mobimp.Edusoft.Web.EduStudent.Reports
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
            Commonfunction common = new Commonfunction();
            string decryptionstring = common.Decrypt(Request["ID"]);
            string baseparam = decryptionstring;
            string reuri = "http://ReportViewer.aspx?" + baseparam + "";
            Uri myUri = new Uri(reuri);

            if (Request["ID"] != null)
            {
                ParameterField paramLoginName = new ParameterField();
                ParameterDiscreteValue paramDiscreteLoginName = new ParameterDiscreteValue();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                paramLoginName.Name = "@LoginName";
                paramDiscreteLoginName.Value = LoginToken.LoginId;
                paramLoginName.CurrentValues.Add(paramDiscreteLoginName);
                paramFields.Add(paramLoginName);
                CrystalReportViewer1.RefreshReport();

                switch (HttpUtility.ParseQueryString(myUri.Query).Get("option"))
                {
                    case "StudentList":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("Studentlist.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_StudentListRPT";
                                    cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = HttpUtility.ParseQueryString(myUri.Query).Get("StudentID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("StudentID").ToString();
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SessionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SessionID").ToString();
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Status").ToString() == "1" ? true : false;
                                    cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SexID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SexID").ToString();
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString();
                                    cmd.Parameters.Add("@Category", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Category").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("Category").ToString();
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Datefrom").ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("Datefrom").ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Dateto").ToString() == "" ? System.DateTime.Today : DateTime.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("Dateto").ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@IsNew", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("IsNew").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("IsNew").ToString();
                                    cmd.Parameters.Add("@CastID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("CastID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("CastID").ToString();
                                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("UserID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("UserID").ToString();
                                    cmd.Parameters.Add("@HouseID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("HouseID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("HouseID").ToString();
                                    cmd.Parameters.Add("@StudentTypeID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("StudentTypeID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("StudentTypeID").ToString();
                                    cmd.Parameters.Add("@AdmissionStatus", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("AdmissionStatus").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("AdmissionStatus").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StudentList");
                        break;

                        //case "StudentProfile":
                        //    DataTable dt2 = new DataTable();
                        //    reportDocument.Load(Server.MapPath("StudentProfile.rpt"));
                        //    using (SqlConnection con = new SqlConnection(constr))
                        //    {
                        //        using (SqlCommand cmd = new SqlCommand())
                        //        {
                        //            using (SqlDataAdapter sda = new SqlDataAdapter())
                        //            {
                        //                cmd.CommandType = CommandType.StoredProcedure;
                        //                cmd.CommandText = "usp_CMS_Std_PrintStudentProfile";
                        //                cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                        //                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                        //                cmd.Parameters.Add("@Sfirstname", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "1" ? Request["SearchBy"].ToString() : null;
                        //                cmd.Parameters.Add("@Smiddlename", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "2" ? Request["SearchBy"].ToString() : null;
                        //                cmd.Parameters.Add("@Slastname", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "3" ? Request["SearchBy"].ToString() : null; ;
                        //                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"] == "1" ? true : false; ;
                        //                cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                        //                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                        //                cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                        //                cmd.Parameters.Add("@Category", SqlDbType.Int).Value = Convert.ToInt32(Request["Category"].ToString() == "" ? "0" : Request["Category"].ToString());
                        //                cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        //                cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        //                cmd.Parameters.Add("@IsNew", SqlDbType.Int).Value = Convert.ToInt32(Request["IsNew"].ToString() == "" ? "0" : Request["IsNew"].ToString());
                        //                cmd.Parameters.Add("@CastID", SqlDbType.Int).Value = Convert.ToInt32(Request["CasteID"].ToString() == "" ? "0" : Request["CasteID"].ToString());
                        //                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(Request["UserID"].ToString() == "" ? "0" : Request["UserID"].ToString());
                        //                cmd.Parameters.Add("@AdmissionStatus", SqlDbType.Int).Value = Convert.ToInt32(Request["Admissionstatus"].ToString() == "" ? "0" : Request["Admissionstatus"].ToString());
                        //                cmd.Connection = con;
                        //                sda.SelectCommand = cmd;
                        //                sda.Fill(dt2);
                        //            }
                        //        }
                        //    }
                        //    reportDocument.SetDataSource(dt2);
                        //    CrystalReportViewer1.ReportSource = reportDocument;
                        //    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StudentProfile");
                        //    break;

                        //case "AttendanceList":
                        //    DataTable dt3 = new DataTable();
                        //    reportDocument.Load(Server.MapPath("AttendanceDetallist.rpt"));
                        //    using (SqlConnection con = new SqlConnection(constr))
                        //    {
                        //        using (SqlCommand cmd = new SqlCommand())
                        //        {
                        //            using (SqlDataAdapter sda = new SqlDataAdapter())
                        //            {
                        //                cmd.CommandType = CommandType.StoredProcedure;
                        //                cmd.CommandText = "usp_CMS_Std_GetattendancelistRPT";
                        //                cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = 0;
                        //                cmd.Parameters.Add("@Sfirstname", SqlDbType.VarChar).Value = null;
                        //                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                        //                cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = 0;
                        //                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                        //                cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                        //                cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        //                cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        //                cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                        //                cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = 0;
                        //                cmd.Connection = con;
                        //                sda.SelectCommand = cmd;
                        //                sda.Fill(dt3);
                        //            }
                        //        }
                        //    }
                        //    reportDocument.SetDataSource(dt3);
                        //    CrystalReportViewer1.ReportSource = reportDocument;
                        //    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "AttendanceList");
                        //    break;

                        //case "SectionStudentList":
                        //    DataTable dt5 = new DataTable();
                        //    reportDocument.Load(Server.MapPath("SectionStudentlist.rpt"));
                        //    using (SqlConnection con = new SqlConnection(constr))
                        //    {
                        //        using (SqlCommand cmd = new SqlCommand())
                        //        {
                        //            using (SqlDataAdapter sda = new SqlDataAdapter())
                        //            {
                        //                cmd.CommandType = CommandType.StoredProcedure;
                        //                cmd.CommandText = "usp_CMS_Std_GetStudentListRPT";
                        //                cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                        //                cmd.Parameters.Add("@Sfirstname", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "1" ? Request["SearchBy"].ToString() : null;
                        //                cmd.Parameters.Add("@Smiddlename", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "2" ? Request["SearchBy"].ToString() : null;
                        //                cmd.Parameters.Add("@Slastname", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "3" ? Request["SearchBy"].ToString() : null; ;
                        //                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                        //                cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                        //                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                        //                cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                        //                cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                        //                cmd.Parameters.Add("@StudentCategory", SqlDbType.Int).Value = Convert.ToInt32(Request["Category"].ToString() == "" ? "0" : Request["Category"].ToString());
                        //                cmd.Connection = con;
                        //                sda.SelectCommand = cmd;
                        //                sda.Fill(dt5);
                        //            }
                        //        }
                        //    }
                        //    reportDocument.SetDataSource(dt5);
                        //    CrystalReportViewer1.ReportSource = reportDocument;
                        //    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "SectionStudentList");
                        //    break;

                        //case "ExamAttendance":
                        //    DataTable dt6 = new DataTable();
                        //    reportDocument.Load(Server.MapPath("ExamAttendanceList.rpt"));
                        //    using (SqlConnection con = new SqlConnection(constr))
                        //    {
                        //        using (SqlCommand cmd = new SqlCommand())
                        //        {
                        //            using (SqlDataAdapter sda = new SqlDataAdapter())
                        //            {
                        //                cmd.CommandType = CommandType.StoredProcedure;
                        //                cmd.CommandText = "usp_CMS_Std_SearchStudentListClassWise";
                        //                cmd.Parameters.Add("@StudentCategory", SqlDbType.Int).Value = Convert.ToInt32(Request["Category"].ToString() == "" ? "0" : Request["Category"].ToString());
                        //                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                        //                cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                        //                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                        //                cmd.Parameters.Add("@OptionalSubject", SqlDbType.Int).Value = Convert.ToInt32(Request["Optional"].ToString() == "" ? "0" : Request["Optional"].ToString());
                        //                cmd.Parameters.Add("@AltSubjectID", SqlDbType.Int).Value = Convert.ToInt32(Request["AltSubject"].ToString() == "" ? "0" : Request["AltSubject"].ToString());
                        //                cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = Convert.ToInt32(Request["SubjectID"].ToString() == "" ? "0" : Request["SubjectID"].ToString());
                        //                cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                        //                cmd.Connection = con;
                        //                sda.SelectCommand = cmd;
                        //                sda.Fill(dt6);
                        //            }
                        //        }
                        //    }
                        //    reportDocument.SetDataSource(dt6);
                        //    CrystalReportViewer1.ReportSource = reportDocument;
                        //    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExamAttendance");
                        //    break;

                        //case "PracticalSheet":
                        //    DataTable dt7 = new DataTable();
                        //    reportDocument.Load(Server.MapPath("PracticalMarksSheet.rpt"));
                        //    using (SqlConnection con = new SqlConnection(constr))
                        //    {
                        //        using (SqlCommand cmd = new SqlCommand())
                        //        {
                        //            using (SqlDataAdapter sda = new SqlDataAdapter())
                        //            {
                        //                cmd.CommandType = CommandType.StoredProcedure;
                        //                cmd.CommandText = "usp_CMS_Std_SearchStudentListClassWise";
                        //                cmd.Parameters.Add("@StudentCategory", SqlDbType.Int).Value = Convert.ToInt32(Request["Category"].ToString() == "" ? "0" : Request["Category"].ToString());
                        //                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                        //                cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                        //                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                        //                cmd.Parameters.Add("@OptionalSubject", SqlDbType.Int).Value = Convert.ToInt32(Request["Optional"].ToString() == "" ? "0" : Request["Optional"].ToString());
                        //                cmd.Parameters.Add("@AltSubjectID", SqlDbType.Int).Value = Convert.ToInt32(Request["AltSubject"].ToString() == "" ? "0" : Request["AltSubject"].ToString());
                        //                cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = Convert.ToInt32(Request["SubjectID"].ToString() == "" ? "0" : Request["SubjectID"].ToString());
                        //                cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                        //                cmd.Connection = con;
                        //                sda.SelectCommand = cmd;
                        //                sda.Fill(dt7);
                        //            }
                        //        }
                        //    }
                        //    reportDocument.SetDataSource(dt7);
                        //    CrystalReportViewer1.ReportSource = reportDocument;
                        //    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "PracticalSheet");
                        //    break;

                        //case "TransportStudentList":
                        //    DataTable dt8 = new DataTable();
                        //    reportDocument.Load(Server.MapPath("TransportStudentlist.rpt"));
                        //    using (SqlConnection con = new SqlConnection(constr))
                        //    {
                        //        using (SqlCommand cmd = new SqlCommand())
                        //        {
                        //            using (SqlDataAdapter sda = new SqlDataAdapter())
                        //            {
                        //                cmd.CommandType = CommandType.StoredProcedure;
                        //                cmd.CommandText = "usp_CMS_Std_GetTransportStudentListRPT";
                        //                cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                        //                cmd.Parameters.Add("@Sfirstname", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "1" ? Request["SearchBy"].ToString() : null;
                        //                cmd.Parameters.Add("@Smiddlename", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "2" ? Request["SearchBy"].ToString() : null;
                        //                cmd.Parameters.Add("@Slastname", SqlDbType.VarChar).Value = Request["Searchtype"].ToString() == "3" ? Request["SearchBy"].ToString() : null; ;
                        //                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                        //                cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                        //                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                        //                cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                        //                cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                        //                cmd.Parameters.Add("@Istakingtransport", SqlDbType.Int).Value = Request["Transport"].ToString() == "1" ? true : false;
                        //                cmd.Parameters.Add("@TransportTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["TransporType"].ToString() == "" ? "0" : Request["TransporType"].ToString());
                        //                cmd.Parameters.Add("@Rootno", SqlDbType.Int).Value = Convert.ToInt32(Request["Route"].ToString() == "" ? "0" : Request["Route"].ToString());
                        //                cmd.Connection = con;
                        //                sda.SelectCommand = cmd;
                        //                sda.Fill(dt8);
                        //            }
                        //        }
                        //    }
                        //    reportDocument.SetDataSource(dt8);
                        //    CrystalReportViewer1.ReportSource = reportDocument;
                        //    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "TransportStudentList");
                        //    break;

                        //case "HostelVisitorlist":
                        //    DataTable dt88 = new DataTable();
                        //    reportDocument.Load(Server.MapPath("HostelVisitorlist.rpt"));
                        //    using (SqlConnection con = new SqlConnection(constr))
                        //    {
                        //        using (SqlCommand cmd = new SqlCommand())
                        //        {
                        //            using (SqlDataAdapter sda = new SqlDataAdapter())
                        //            {
                        //                cmd.CommandType = CommandType.StoredProcedure;
                        //                cmd.CommandText = "usp_CMS_Std_GetTransportStudentListRPT";
                        //                cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                        //                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                        //                cmd.Parameters.Add("@RegistrationID", SqlDbType.Int).Value = Convert.ToInt32(Request["RegistrationID"].ToString() == "" ? "0" : Request["RegistrationID"].ToString());
                        //                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Convert.ToInt32(Request["IsActive"].ToString() == "" ? "0" : Request["IsActive"].ToString());
                        //                cmd.Connection = con;
                        //                sda.SelectCommand = cmd;
                        //                sda.Fill(dt88);
                        //            }
                        //        }
                        //    }
                        //    reportDocument.SetDataSource(dt88);
                        //    CrystalReportViewer1.ReportSource = reportDocument;
                        //    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HostelVisitorlist");
                        //    break;
                }

            }

        }
    }
}