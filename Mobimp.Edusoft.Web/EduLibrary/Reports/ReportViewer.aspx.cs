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

namespace Mobimp.Edusoft.Web.EduLibrary.Reports
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
                    case "BookIssueReceipt":
                        DataTable dt7 = new DataTable();
                        reportDocument.Load(Server.MapPath("BookIssueReceipt.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_lib_BookIssueReceiptRPT";
                                    cmd.Parameters.Add("@IssueNo", SqlDbType.Int).Value = Request["IssueNo"].ToString();
                                    cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["typeID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt7);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt7);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "BookIssueReceipt");
                        break;

                    case "BookReturnReceipt":
                        DataTable dt8 = new DataTable();
                        reportDocument.Load(Server.MapPath("BookReturnReceipt.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_lib_BookReturnReceiptRPT";
                                    cmd.Parameters.Add("@IssueNo", SqlDbType.Int).Value = Request["IssueNo"].ToString();
                                    cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["typeID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt8);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt8);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "BookReturnReceipt");
                        break;
                }
            }

        }

    }
}