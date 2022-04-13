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

namespace Mobimp.Edusoft.Web.EduInvUtility.Reports
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
                    case "ItemList":
                        DataTable dt1 = new DataTable();
                        reportDocument.Load(Server.MapPath("ItemList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_util_rpt_itemlist";
                                    cmd.Parameters.Add("@groupid", SqlDbType.Int).Value = Convert.ToInt32(Request["groupid"].ToString() == "" ? "0" : Request["groupid"].ToString());
                                    cmd.Parameters.Add("@subgroupid", SqlDbType.Int).Value = Convert.ToInt32(Request["subgroupid"].ToString() == "" ? "0" : Request["subgroupid"].ToString());
                                    cmd.Parameters.Add("@itemname", SqlDbType.VarChar).Value = Request["itemname"].ToString() == "" ? Request["itemname"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Request["status"] == "1" ? true : false;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ItemList");
                        break;

                    case "ItemPriceList":
                        DataTable dt2 = new DataTable();
                        reportDocument.Load(Server.MapPath("ItemPriceList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_util_rpt_itempricelist";
                                    cmd.Parameters.Add("@groupid", SqlDbType.Int).Value = Convert.ToInt32(Request["groupid"].ToString() == "" ? "0" : Request["groupid"].ToString());
                                    cmd.Parameters.Add("@subgroupid", SqlDbType.Int).Value = Convert.ToInt32(Request["subgroupid"].ToString() == "" ? "0" : Request["subgroupid"].ToString());
                                    cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(Request["AcademicSessionID"].ToString() == "" ? "0" : Request["AcademicSessionID"].ToString());
                                    cmd.Parameters.Add("@YearID", SqlDbType.Int).Value = Convert.ToInt32(Request["yearid"].ToString() == "" ? "0" : Request["yearid"].ToString());
                                    cmd.Parameters.Add("@itemid", SqlDbType.Int).Value = Convert.ToInt32(Request["itemid"].ToString() == "" ? "0" : Request["itemid"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Request["status"] == "1" ? true : false; 
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "ItemPriceList");
                        break;

                    case "SupplierList":
                        DataTable dt3 = new DataTable();
                        reportDocument.Load(Server.MapPath("SupplierList.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_inv_util_rpt_Supplierlist";
                                    cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = Convert.ToInt32(Request["SupplierID"].ToString() == "" ? "0" : Request["SupplierID"].ToString());
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Request["status"] == "1" ? true : false;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dt3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dt3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "SupplierList");
                        break;
                }
            }

        }

    }
}