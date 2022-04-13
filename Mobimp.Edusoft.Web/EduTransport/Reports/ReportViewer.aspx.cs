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

namespace Mobimp.Edusoft.Web.EduTransport.Reports
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

                    case "PrintDriverID":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("DriverIDCard.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Trans_GetPrintDriverID";
                                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(Request["ID"].ToString() == "" ? "0" : Request["ID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@RouteID", SqlDbType.Int).Value = Convert.ToInt32(Request["RouteID"].ToString() == "" ? "0" : Request["RouteID"].ToString());
                                    cmd.Parameters.Add("@TransportType", SqlDbType.Int).Value = Convert.ToInt32(Request["TranportTypeID"].ToString() == "" ? "0" : Request["TranportTypeID"].ToString());
                                    cmd.Parameters.Add("@VehicleNo", SqlDbType.VarChar).Value = Request["VehicleNo"].ToString() == "" ? "0" : Request["VehicleNo"].ToString();
                                    cmd.Parameters.Add("@DriverName", SqlDbType.VarChar).Value = Request["DriverName"].ToString() == "" ? "0" : Request["DriverName"].ToString();
                                    cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = Request["ContactNo"].ToString() == "" ? "0" : Request["ContactNo"].ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "DriverIDCard");
                        break;

                    case "VehicleManager":
                        DataTable dt4 = new DataTable();
                        reportDocument.Load(Server.MapPath("VehicleManager.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Trans_GetPrintDriverID";
                                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(Request["ID"].ToString() == "" ? "0" : Request["ID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@RouteID", SqlDbType.Int).Value = Convert.ToInt32(Request["RouteID"].ToString() == "" ? "0" : Request["RouteID"].ToString());
                                    cmd.Parameters.Add("@TransportType", SqlDbType.Int).Value = Convert.ToInt32(Request["TranportTypeID"].ToString() == "" ? "0" : Request["TranportTypeID"].ToString());
                                    cmd.Parameters.Add("@VehicleNo", SqlDbType.VarChar).Value = Request["VehicleNo"].ToString() == "" ? "0" : Request["VehicleNo"].ToString();
                                    cmd.Parameters.Add("@DriverName", SqlDbType.VarChar).Value = Request["DriverName"].ToString() == "" ? "0" : Request["DriverName"].ToString();
                                    cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = Request["ContactNo"].ToString() == "" ? "0" : Request["ContactNo"].ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt4);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt4);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "VehicleManager");
                        break;

                    case "TransportRegistration":
                        DataTable dt5 = new DataTable();
                        reportDocument.Load(Server.MapPath("TransportRegistration.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_SearchTransportRegistrationRPT";
                                    cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = Convert.ToInt64(Request["StudentID"].ToString() == "" ? "0" : Request["StudentID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Request["IsActive"] == "1" ? true : false;
                                    cmd.Parameters.Add("@TransStudentype", SqlDbType.Int).Value = Convert.ToInt32(Request["TransStudentype"].ToString() == "" ? "0" : Request["TransStudentype"].ToString());
                                    cmd.Parameters.Add("@Startmonth", SqlDbType.Int).Value = Convert.ToInt32(Request["Startmonth"].ToString() == "" ? "0" : Request["Startmonth"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt5);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt5);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HostelRegistration");
                        break;
                }
            }

        }

    }
}