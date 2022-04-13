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

namespace Mobimp.Edusoft.Web.EduHostel.Reports
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
                    case "HostellerFeeDepositlist":
                        DataTable dt10 = new DataTable();
                        reportDocument.Load(Server.MapPath("HostellerFeeDepositList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Hostel_SearchDepositFeeDetailsRpt";
                                    cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt32(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                                    cmd.Parameters.Add("@PaymodeID", SqlDbType.Int).Value = Convert.ToInt32(Request["PaymodeID"].ToString() == "" ? "0" : Request["PaymodeID"].ToString());
                                    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = Request["DateFrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["DateFrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = Request["DateTo"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["DateTo"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@ReceiptNo", SqlDbType.VarChar).Value = Request["ReceiptNo"].ToString() == "" ? "null" : Request["ReceiptNo"].ToString();
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Convert.ToInt32(Request["Status"].ToString() == "" ? "0" : Request["Status"].ToString()); ;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt10);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt10);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HostellerFeeDepositlist");
                        break;

                    case "HostellerFeeDeposit":
                        DataTable dt9 = new DataTable();
                        reportDocument.Load(Server.MapPath("HostellerFeeDeposit.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Hostel_SearchDepositFeeRpt";
                                    cmd.Parameters.Add("@DepositID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["DepositID"].ToString() == "" ? "0" : Request["DepositID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt9);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt9);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HostellerFeeDeposit");
                        break;

                    case "Stdfeeajustedlist":
                        DataTable dt13 = new DataTable();
                        reportDocument.Load(Server.MapPath("FeeAjustedStdList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Hostel_SearchAjustedDetailsRpt";
                                    cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(Request["ClassID"].ToString() == "" ? "0" : Request["ClassID"].ToString());
                                    cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SectionID"].ToString() == "" ? "0" : Request["SectionID"].ToString());
                                    //cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Request["Status"];
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Convert.ToInt32(Request["Status"].ToString() == "" ? "0" : Request["Status"].ToString());
                                    cmd.Parameters.Add("@RollNo", SqlDbType.VarChar).Value = Request["RollNo"].ToString() == "" ? "0" : Request["RollNo"].ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt13);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt13);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Stdfeeajustedlist");
                        break;

                    case "AjustedFeeDeposit":
                        DataTable dt12 = new DataTable();
                        reportDocument.Load(Server.MapPath("AjustedFeesDeposit.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Hostel_SearchAjustedFeeRpt";
                                    cmd.Parameters.Add("@ACID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["ACID"].ToString() == "" ? "0" : Request["ACID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt12);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt12);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "AjustedFeeDeposit");
                        break;

                    case "Collectionajustedlist":
                        DataTable dt14 = new DataTable();
                        reportDocument.Load(Server.MapPath("CollectionFeeAjusted.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Hostel_SearchFeeAjustedCollectionDetailsRpt";
                                    cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@PaidRecieptNo", SqlDbType.VarChar).Value = Request["ReceiptNo"].ToString() == "" ? "null" : Request["ReceiptNo"].ToString();
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault); ;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Convert.ToInt32(Request["Status"].ToString() == "" ? "0" : Request["Status"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt14);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt14);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Collectionajustedlist");
                        break;

                    case "TakingItemDetails":
                        DataTable dt11 = new DataTable();
                        reportDocument.Load(Server.MapPath("TakingItemDetail.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Hostel_SearchTakingItemDetailsRpt";
                                    cmd.Parameters.Add("@ReceiptNo", SqlDbType.VarChar).Value = Request["ReceiptNo"].ToString() == "" ? "null" : Request["ReceiptNo"].ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt11);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt11);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "TakingItemDetails");
                        break;

                    case "HostelRegistration":
                        DataTable dt4 = new DataTable();
                        reportDocument.Load(Server.MapPath("HostelRegistration.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_SearchHostelRegistrationRPT";
                                    cmd.Parameters.Add("@SessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = (Request["Name"].ToString() == "" ? "0" : Request["Name"].ToString());
                                    cmd.Parameters.Add("@Campus", SqlDbType.Int).Value = Convert.ToInt32(Request["Campus"].ToString() == "" ? "0" : Request["Campus"].ToString());
                                    cmd.Parameters.Add("@Wing", SqlDbType.Int).Value = Convert.ToInt32(Request["Wing"].ToString() == "" ? "0" : Request["Wing"].ToString());
                                    cmd.Parameters.Add("@WardenID", SqlDbType.Int).Value = Convert.ToInt32(Request["WardenID"].ToString() == "" ? "0" : Request["WardenID"].ToString());
                                    cmd.Parameters.Add("@Class", SqlDbType.Int).Value = Convert.ToInt32(Request["Class"].ToString() == "" ? "0" : Request["Class"].ToString());
                                    cmd.Parameters.Add("@Section", SqlDbType.Int).Value = Convert.ToInt32(Request["Section"].ToString() == "" ? "0" : Request["Section"].ToString());
                                    cmd.Parameters.Add("@Isactive", SqlDbType.Bit).Value = Request["Isactive"] == "1" ? true : false;
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt4);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt4);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HostelRegistration");
                        break;
                }
            }

        }

    }
}


//cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToInt32(Request["MonthID"].ToString() == "" ? "0" : Request["MonthID"].ToString());