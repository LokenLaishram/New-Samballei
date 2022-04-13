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

namespace Mobimp.Edusoft.Web.EduInventory.Reports
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
                    case "ItemWiseStockStatus":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("ItemWiseStockStatus.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_printitemwisestockstatus";
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@UserLoginID", SqlDbType.Int).Value = Convert.ToInt32(Request["UserLoginID"].ToString() == "" ? "0" : Request["UserLoginID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ItemWiseStockStatus");
                        break;

                    case "StockEntryReceipt":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("StockEntryReceipt.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_printstockentryreceipt";
                                    cmd.Parameters.Add("@OrderTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["OrderTypeID"].ToString() == "" ? "0" : Request["OrderTypeID"].ToString());
                                    cmd.Parameters.Add("@VendorTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["VendorTypeID"].ToString() == "" ? "0" : Request["VendorTypeID"].ToString());
                                    cmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = Convert.ToInt32(Request["VendorID"].ToString() == "" ? "0" : Request["VendorID"].ToString());
                                    cmd.Parameters.Add("@ReceivedByID", SqlDbType.Int).Value = Convert.ToInt32(Request["ReceivedByID"].ToString() == "" ? "0" : Request["ReceivedByID"].ToString());
                                    cmd.Parameters.Add("@WorkOrderNo", SqlDbType.VarChar).Value = Request["WorkOrderNo"].ToString() == "" ? Request["WorkOrderNo"].ToString() : null;
                                    cmd.Parameters.Add("@ReceivedNo", SqlDbType.VarChar).Value = Request["ReceivedNo"].ToString() == "" ? Request["ReceivedNo"].ToString() : null;
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StockEntryReceipt");
                        break;

                    case "StockEntryWPOList":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("StockEntryWPOList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_getstockwithoutPO_Byrcptno";
                                    cmd.Parameters.Add("@ReceiptNo", SqlDbType.VarChar).Value = Request["ReceiptNo"].ToString() ;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StockEntryWPOList");
                        break;

                    case "Indentpaymentreceipt":
                        DataTable dt4 = new DataTable();
                        reportDocument.Load(Server.MapPath("Indentpaymentreceipt.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_sale_paymentreceipt";
                                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = Request["InvoiceNo"].ToString() == "" ? Request["InvoiceNo"].ToString() : null;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt4);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt4);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Indentpaymentreceipt");
                        break;

                    case "PaymentList":
                        DataTable dt5 = new DataTable();
                        reportDocument.Load(Server.MapPath("PaymentList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_sale_payment_list";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@VendorTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["VendorTypeID"].ToString() == "" ? "0" : Request["VendorTypeID"].ToString());
                                    cmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = Convert.ToInt32(Request["VendorID"].ToString() == "" ? "0" : Request["VendorID"].ToString());
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@BillNo", SqlDbType.Int).Value = Request["BillNo"].ToString() == "" ? Request["BillNo"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"] == "1" ? true : false;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt5);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt5);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "PaymentList");
                        break;

                    case "StockReleasedDetails":
                        DataTable dt6 = new DataTable();
                        reportDocument.Load(Server.MapPath("StockReleasedDetails.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_released_stockreleaseddetails";
                                    cmd.Parameters.Add("@BillNo", SqlDbType.Int).Value = Request["BillNo"].ToString() == "" ? Request["BillNo"].ToString() : null;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt6);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt6);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StockReleasedDetails");
                        break;

                    case "StockReleasedReceipt":
                        DataTable dt7 = new DataTable();
                        reportDocument.Load(Server.MapPath("StockReleasedReceipt.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_released_printstockreleasedreceipt";
                                    cmd.Parameters.Add("@ReleasedNo", SqlDbType.Int).Value = Request["ReleasedNo"].ToString() == "" ? Request["ReleasedNo"].ToString() : null;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt7);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt7);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StockReleasedReceipt");
                        break;

                    case "IndentGeneration":
                        DataTable dt8 = new DataTable();
                        reportDocument.Load(Server.MapPath("IndentGeneration.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_rpt_indent_generation";
                                    cmd.Parameters.Add("@IndentNo", SqlDbType.Int).Value = Request["IndentNo"].ToString() == "" ? Request["IndentNo"].ToString() : null;
                                    cmd.Parameters.Add("@PrintCopy", SqlDbType.Int).Value = Request["PrintCopy"].ToString() == "" ? Request["PrintCopy"].ToString() : null;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt8);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt8);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "IndentGeneration");
                        break;
                }
            }

        }

    }
}