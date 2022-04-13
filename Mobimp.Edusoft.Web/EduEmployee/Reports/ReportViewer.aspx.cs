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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Mobimp.Edusoft.Web.EduEmployee.Reports
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
            if (Request["option"] != null)
            {
                ParameterField paramLoginName = new ParameterField();
                ParameterDiscreteValue paramDiscreteLoginName = new ParameterDiscreteValue();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                paramLoginName.Name = "@LoginName";
                paramDiscreteLoginName.Value = LoginToken.LoginId;
                paramLoginName.CurrentValues.Add(paramDiscreteLoginName);
                paramFields.Add(paramLoginName);

                CrystalReportViewer1.RefreshReport();

                switch (Request["option"].ToString())
                {
                    case "Emplist":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("EmpList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Emp_SeacrhEmployeeDetailRPT";
                                    cmd.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = Request["EmpNo"].ToString() == "" ? null : Request["EmpNo"].ToString();
                                    cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = Commonfunction.SemicolonSeparation_String_64(Request["EmpName"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                                    cmd.Parameters.Add("@EmployeeCatgeroyID", SqlDbType.Int).Value = Convert.ToInt32(Request["EmpCategory"].ToString() == "" ? "0" : Request["EmpCategory"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employeelist");
                        break;

                    case "EmpAttendanceTotal":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("EmpTotalAttendanceDetallist.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Emp_GetEmployeeAttendancelistRPT";
                                    cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(Request["EmpID"].ToString() == "" ? "0" : Request["EmpID"].ToString());
                                    cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = Request["EmpName"].ToString();
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
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
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "EmpTotalAttendanceDetallist");
                        break;

                    case "EmpProfile":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("EmployeeProfile.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_PrintEmployeeProfile";
                                    cmd.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = Request["EmpNo"].ToString() == "" ? null : Request["EmpNo"].ToString();
                                    cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = Request["EmpName"].ToString();
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                                    cmd.Parameters.Add("@EmployeeCatgeroyID", SqlDbType.Int).Value = Convert.ToInt32(Request["EmpCategory"].ToString() == "" ? "0" : Request["EmpCategory"].ToString());
                                    cmd.Parameters.Add("@StaffTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["StaffID"].ToString() == "" ? "0" : Request["StaffID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "EmployeeProfile");
                        break;

                    case "PaySlip":
                        DataTable dt4 = new DataTable();
                        reportDocument.Load(Server.MapPath("PaySlip.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_PaySlipRPT";
                                    cmd.Parameters.Add("@SalaryGeneratorID", SqlDbType.Int).Value = Convert.ToInt32(Request["SalaryID"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToInt32(Request["MonthID"].ToString());
                                    cmd.Parameters.Add("@SalaryStatus", SqlDbType.Int).Value = Convert.ToInt32(Request["SalaryStatus"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt4);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt4);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "EmployeeProfile");
                        break;

                    case "SalaryStatement":
                        DataTable dt5 = new DataTable();
                        reportDocument.Load(Server.MapPath("SalaryDetailLis.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Emp_GetEmployeeSalaryStatus";
                                    cmd.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = Request["EmployeeNo"].ToString();
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@MonthID", SqlDbType.Int).Value = Convert.ToInt32(Request["MonthID"].ToString());
                                    cmd.Parameters.Add("@SalaryStatus", SqlDbType.Int).Value = Convert.ToInt32(Request["SalaryStatus"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Parameters.Add("@EmployeeCategory", SqlDbType.Int).Value = Convert.ToInt32(Request["Category"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt5);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt5);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "SalaryDetailLis");
                        break;

                    case "EmpAttendance":
                        DataTable dt6 = new DataTable();
                        reportDocument.Load(Server.MapPath("EmpAttendanceDetallist.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Emp_GetEmployeeSalaryStatus";
                                    cmd.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = Request["EmpNo"].ToString() == "" ? null : Request["EmpNo"].ToString();
                                    cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = Request["EmpName"].ToString();
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["Session"].ToString() == "" ? "0" : Request["Session"].ToString());
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt6);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt6);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "SalaryDetailLis");
                        break;

                    case "EmpIDCard":
                        DataTable dt99 = new DataTable();
                        reportDocument.Load(Server.MapPath("Empcard.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_PrintEmployeeProfile";
                                    cmd.Parameters.Add("@EmployeeNo", SqlDbType.Int).Value = Request["EmpNo"].ToString() == "" ? null : Request["EmpNo"].ToString();
                                    cmd.Parameters.Add("@EmpName", SqlDbType.Int).Value = Request["EmpName"].ToString() == "" ? null : Request["EmpName"].ToString();
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Parameters.Add("@SexID", SqlDbType.Int).Value = Convert.ToInt32(Request["SexID"].ToString() == "" ? "0" : Request["SexID"].ToString());
                                    cmd.Parameters.Add("@EmployeeCatgeroyID", SqlDbType.Int).Value = Convert.ToInt32(Request["EmpCategory"].ToString() == "" ? "0" : Request["EmpCategory"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["SessionID"].ToString() == "" ? "0" : Request["SessionID"].ToString());
                                    cmd.Parameters.Add("@StaffTypeID", SqlDbType.Int).Value = Convert.ToInt32(Request["StaffID"].ToString() == "" ? "0" : Request["StaffID"].ToString());
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt99);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt99);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Vcard");
                        break;

                    case "EmployeeLeave":
                        DataTable dt7 = new DataTable();
                        reportDocument.Load(Server.MapPath("EmployeeLeaveList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Emp_SearchEmployeeListDetailRPT";
                                    cmd.Parameters.Add("@EmployeeNo", SqlDbType.VarChar).Value = Request["EmpNo"].ToString() == "" ? null : Request["EmpNo"].ToString();
                                    cmd.Parameters.Add("@Datefrom", SqlDbType.DateTime).Value = Request["Datefrom"].ToString() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Request["Datefrom"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Parameters.Add("@Dateto", SqlDbType.DateTime).Value = Request["Dateto"].ToString() == "" ? System.DateTime.Today : DateTime.Parse(Request["Dateto"].ToString(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt7);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt7);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "EmployeeLeaveList");
                        break;
                }
            }

        }
    }
}