using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Mobimp.Edusoft.Web.EduExamination.Reports
{
    public partial class ReportViewer : BasePage
    {

        ReportDocument reportDocument = new ReportDocument();
        ParameterFields paramFields = new ParameterFields();
        CrystalReportSource crystalReportSource = new CrystalReportSource();
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
                    case "MarkRange":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("Overall_Result_MarkRange_IX_X.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Exam_PrintMarkRange";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(Request["ExamID"].ToString() == "" ? "0" : Request["ExamID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@MarkFrom", SqlDbType.Int).Value = Convert.ToInt32(Request["MarkFrom"].ToString() == "" ? "0" : Request["MarkFrom"].ToString());
                                    cmd.Parameters.Add("@MarkTo", SqlDbType.Int).Value = Convert.ToInt32(Request["MarkTo"].ToString() == "" ? "0" : Request["MarkTo"].ToString());
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
                }
            }
        }
    }
}