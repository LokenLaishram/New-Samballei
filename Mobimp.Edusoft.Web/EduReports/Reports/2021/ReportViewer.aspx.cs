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


namespace Mobimp.Campusoft.Web.EduReports.Reports._2021
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
            var myUri = new Uri(reuri);

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
                    case "PrintMarksheet_Term_I":
                        DataTable dt25 = new DataTable();
                        if ((Convert.ToInt32(HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? "0" : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString()) == 20)
                                 && (Convert.ToInt32(HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? "0" : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString()) <= 5))
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/FT_MarkSheet_I_II_2021.rpt"));
                        }
                        else if ((Convert.ToInt32(HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? "0" : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString()) == 20)
                                 && (Convert.ToInt32(HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? "0" : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString()) >= 6))
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/FT_MarkSheet_III_V_2021.rpt"));
                        }
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintOverAll_TermIMarkSheet_from2021";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString();
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString();
                                    cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString();
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt25);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt25);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;

                    case "PrintMarksheet_VI_VIII_Term_I":
                        DataTable dt7 = new DataTable();

                        //if (Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString()) == 20 && Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString()) == 6)

                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/FT_MarkSheet_VI_VIII_2021.rpt"));

                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintOverAll_TermIMarkSheet_from2021";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString();
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString();
                                    cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString();
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt7);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt7);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Markeheet");
                        break;

                    case "PrintMarksheet_IX_X_Term_I":
                        DataTable dt273 = new DataTable();

                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/FT_MarkSheet_IX_2021.rpt"));

                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintOverAll_TermIMarkSheet_from2021";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString();
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString();
                                    cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString();
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt273);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt273);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;

                    //----------------------------- Start Overall Print Mark Sheet----------------------------------------
                    case "PrintMarksheetOverall_I_V_Term_II":
                        DataTable dt31 = new DataTable();

                        if (Convert.ToInt32(HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? "0" : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString()) <= 5)
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/O_I_II_2021.rpt"));
                        }
                        else
                        {
                            reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/O_III_V_2021.rpt"));
                        }

                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintOverAll_MarkSheet_2021";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString();
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString();
                                    cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString();
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt31);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt31);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;

                    case "PrintMarksheetOverall_VI_VIII_Term_II":
                        DataTable dt32 = new DataTable();

                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/O_VI_VIII_2021.rpt"));

                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintOverAll_MarkSheet_2021";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString();
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString();
                                    cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString();
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt32);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt32);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;

                    case "PrintMarkSheetOverall_IX_X_Term_II":
                        DataTable dt33 = new DataTable();

                        reportDocument.Load(Server.MapPath("~/EduReports/Reports/2021/O_IX_2021.rpt"));

                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintOverAll_MarkSheet_2021";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SectionID").ToString();
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ExamID").ToString();
                                    cmd.Parameters.Add("@StudentCategoryID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("Session").ToString();
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("RollNo").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt33);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt33);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Marksheet");
                        break;

                }

            }
        }
    }
}