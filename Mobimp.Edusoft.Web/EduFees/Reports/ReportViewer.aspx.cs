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

namespace Mobimp.Edusoft.Web.EduFees.Reports
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
                    case "FeeReciept":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("FeeReciept.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Fee_PrintFeeRecieptrpt";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = Convert.ToInt32(Request["BillID"].ToString() == "" ? "0" : Request["BillID"].ToString());
                                    cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "FeeReciept_" + Convert.ToString(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString()));
                        break;

                    case "Paymenthistory":
                        DataTable dt45 = new DataTable();
                        reportDocument.Load(Server.MapPath("paymenthistory.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Fee_PrintPaymenyHistory";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt45);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt45);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "FeeCollectionlist");
                        break;
                    case "FeeStatus":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("FeeStatus.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Fee_Getfeestatus";
                                    DateTime from = Request["DateFrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["DateFrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    DateTime To = Request["DateTo"].ToString() == "" ? System.DateTime.Now : DateTime.Parse(Request["DateTo"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = from;
                                    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = To;
                                    cmd.Parameters.Add("@CollectedBy", SqlDbType.Int).Value = Convert.ToInt32(Request["CollectedBy"].ToString() == "" ? "0" : Request["CollectedBy"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@PaymentMode", SqlDbType.Int).Value = Convert.ToInt32(Request["Paymode"].ToString() == "" ? "0" : Request["Paymode"].ToString());
                                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Convert.ToInt32(Request["Status"].ToString() == "" ? "0" : Request["Status"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = 10000000;// Convert.ToInt32(Request["PageSize"].ToString() == "" ? "0" : Request["PageSize"].ToString());
                                    cmd.Parameters.Add("@CurrentIndex", SqlDbType.Int).Value = 1;
                                    cmd.Parameters.Add("@AdmissionTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["AdmissionTypeID"].ToString() == "" ? "0" : Request["AdmissionTypeID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "FeeCollectionlist");
                        break;

                    case "Mtfeestatus":
                        DataTable dt56 = new DataTable();
                        reportDocument.Load(Server.MapPath("MTreports.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Fee_DefaulterList";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToInt32(Request["Month"].ToString() == "" ? "0" : Request["Month"].ToString());
                                    cmd.Parameters.Add("@Paystatus", SqlDbType.Int).Value = Convert.ToInt32(Request["Status"].ToString() == "" ? "0" : Request["Status"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = 10000000;// Convert.ToInt32(Request["PageSize"].ToString() == "" ? "0" : Request["PageSize"].ToString());
                                    cmd.Parameters.Add("@CurrentIndex", SqlDbType.Int).Value = 1;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt56);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt56);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "FeeCollectionlist");
                        break;
                    case "SMtfeestatus":
                        DataTable dt57 = new DataTable();
                        reportDocument.Load(Server.MapPath("SMTreports.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Fee_DefaulterList";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["FeeTypeID"].ToString() == "" ? "0" : Request["FeeTypeID"].ToString());
                                    cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToInt32(Request["Month"].ToString() == "" ? "0" : Request["Month"].ToString());
                                    cmd.Parameters.Add("@Paystatus", SqlDbType.Int).Value = Convert.ToInt32(Request["Status"].ToString() == "" ? "0" : Request["Status"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = 10000000;// Convert.ToInt32(Request["PageSize"].ToString() == "" ? "0" : Request["PageSize"].ToString());
                                    cmd.Parameters.Add("@CurrentIndex", SqlDbType.Int).Value = 1;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt57);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt57);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "FeeCollectionlist");
                        break;
                    case "AutoRolls":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("AutoGeneratedRolls.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_GetAutogenaredrollnumbers";
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString());
                                    cmd.Parameters.Add("@AllotedStatus", SqlDbType.Int).Value = Convert.ToInt32(Request["Status"].ToString() == "" ? "0" : Request["Status"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = 1000000;
                                    cmd.Parameters.Add("@CurrentIndex", SqlDbType.Int).Value = 1;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "FeeCollectionlist");
                        break;
                }

            }

        }

    }
}