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

namespace Mobimp.Edusoft.Web.EduFeeUtility.Reports
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
                    case "OneTimePayment":
                    DataTable dtOneTimePayment = new DataTable();
                    reportDocument.Load(Server.MapPath("OneTimeFeePayment.rpt"));
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "usp_CMS_Util_SearchOneTimeFeePayment";
                                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToInt32(Request["CategoryID"].ToString() == "" ? "0" : Request["CategoryID"].ToString());
                                cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@AddRow", SqlDbType.Int).Value = 0;
                                cmd.Connection = con;
                                sda.SelectCommand = cmd;
                                sda.Fill(dtOneTimePayment);
                            }
                        }
                    }
                    reportDocument.SetDataSource(dtOneTimePayment);
                    CrystalReportViewer1.ReportSource = reportDocument;
                    reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "OneTimeFeePayment");
                    break;

                    case "MonthlyPayment":
                        DataTable dtMonthlyPayment = new DataTable();
                        reportDocument.Load(Server.MapPath("MonthlyPayment.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SearchMonthlyPayment";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToInt32(Request["CategoryID"].ToString() == "" ? "0" : Request["CategoryID"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = 2;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtMonthlyPayment);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtMonthlyPayment);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "MonthlyPayment");
                        break;

                        case "EmiPayment":
                        DataTable dtEmiPayment = new DataTable();
                        reportDocument.Load(Server.MapPath("EmiPayment.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SearchEMIPayment";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToInt32(Request["CategoryID"].ToString() == "" ? "0" : Request["CategoryID"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@NoEmi", SqlDbType.Int).Value = Convert.ToInt32(Request["NoEmi"].ToString() == "" ? "0" : Request["NoEmi"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtEmiPayment);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtEmiPayment);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "MonthlyPayment");
                        break;

                    case "ExemptionRule":
                        DataTable dtExemptionRule = new DataTable();
                        reportDocument.Load(Server.MapPath("ExemptionRule.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SearchExemptionRule";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Convert.ToInt32(Request["CategoryID"].ToString() == "" ? "0" : Request["CategoryID"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtExemptionRule);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtExemptionRule);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "MonthlyPayment");
                        break;
                }
            }
        }
    }
}