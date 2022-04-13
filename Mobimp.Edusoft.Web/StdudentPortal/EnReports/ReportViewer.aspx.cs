
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace Mobimp.Campusoft.Web.StdudentPortal.EnReports
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
                    case "FeeReciept":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("~/StdudentPortal/EnReports/FeeReciept.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Fee_PrintFeeRecieptrpt";
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SessionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SessionID").ToString();
                                    cmd.Parameters.Add("@FeeTypeID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("FeeTypeID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("FeeTypeID").ToString();
                                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("BillID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("BillID").ToString();
                                    cmd.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = HttpUtility.ParseQueryString(myUri.Query).Get("StudentID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("StudentID").ToString();
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Feereceipt");
                        break;
                    case "StudentList":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("Onlineregistrationlist.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Std_Getonlineregistration_List";
                                    cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = HttpUtility.ParseQueryString(myUri.Query).Get("StudentID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("StudentID").ToString();
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SessionID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SessionID").ToString();
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Status").ToString() == "1" ? true : false;
                                    cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("SexID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("SexID").ToString();
                                    cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("ClassID").ToString();
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Datefrom").ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("Datefrom").ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = HttpUtility.ParseQueryString(myUri.Query).Get("Dateto").ToString() == "" ? System.DateTime.Today : DateTime.Parse(HttpUtility.ParseQueryString(myUri.Query).Get("Dateto").ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@CastID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("CastID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("CastID").ToString();
                                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("UserID").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("UserID").ToString();
                                    cmd.Parameters.Add("@AdmissionStatus", SqlDbType.Int).Value = HttpUtility.ParseQueryString(myUri.Query).Get("AdmissionStatus").ToString() == "" ? null : HttpUtility.ParseQueryString(myUri.Query).Get("AdmissionStatus").ToString();
                                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = 10000000;// Convert.ToInt32(Request["PageSize"].ToString() == "" ? "0" : Request["PageSize"].ToString());
                                    cmd.Parameters.Add("@CurrentIndex", SqlDbType.Int).Value = 1;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StudentList");
                        break;
                }
            }
        }
    }
}