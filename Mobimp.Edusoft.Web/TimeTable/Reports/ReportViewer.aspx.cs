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

namespace Mobimp.Campusoft.Web.TimeTable.Reports
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

                    case "TeacherTimeTable":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("TeacherwisetimeTable.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_TimeTable_Print_teacherwisetimetable";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = Convert.ToInt32(Request["GroupID"].ToString() == "" ? "0" : Request["GroupID"].ToString());
                                    cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = Convert.ToInt32(Request["TeacherID"].ToString() == "" ? "0" : Request["TeacherID"].ToString());
                                    cmd.Parameters.Add("@DayID", SqlDbType.Int).Value = 0;
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
                    case "SectionTimeTable":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("SectionTimeTable.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_TimeTable_Print_sectionwise_timetable";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = Convert.ToInt32(Request["GroupID"].ToString() == "" ? "0" : Request["GroupID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["Class"].ToString() == "" ? "0" : Request["Class"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Section"].ToString() == "" ? "0" : Request["Section"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                        break;
                    case "Timetable":
                        DataTable dt5 = new DataTable();
                        reportDocument.Load(Server.MapPath("TimeTable.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Get_Time_Table";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = Convert.ToInt32(Request["GroupID"].ToString() == "" ? "0" : Request["GroupID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["Class"].ToString() == "" ? "0" : Request["Class"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Section"].ToString() == "" ? "0" : Request["Section"].ToString());
                                    cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@Periodid", SqlDbType.Int).Value = 0;
                                    cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = 0;
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
                    case "Dailytimetable":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("Dailytimetable.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Print_Daily_Timetable";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = Convert.ToInt32(Request["GroupID"].ToString() == "" ? "0" : Request["GroupID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = Convert.ToInt32(Request["SubjectID"].ToString() == "" ? "0" : Request["SubjectID"].ToString());
                                    cmd.Parameters.Add("@PeriodNo", SqlDbType.Int).Value = Convert.ToInt32(Request["PeriodNo"].ToString() == "" ? "0" : Request["PeriodNo"].ToString());
                                    cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = Convert.ToInt32(Request["TeacherID"].ToString() == "" ? "0" : Request["TeacherID"].ToString());
                                    DateTime date = Request["Date"].ToString().Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Date"].ToString().Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
                                    cmd.Connection = con;
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
                }

            }
        }
    }
}