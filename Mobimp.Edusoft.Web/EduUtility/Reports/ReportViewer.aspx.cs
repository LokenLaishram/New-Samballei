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

namespace Mobimp.Campusoft.Web.EduUtility.Reports 
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

                //For First Parameter
                //ParameterField paramField1 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                //ParameterField paramField2 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                //ParameterField paramField3 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                //ParameterField paramField4 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                //ParameterField paramField5 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                //ParameterField paramField6 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue6 = new ParameterDiscreteValue();
                //ParameterField paramField7 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue7 = new ParameterDiscreteValue();
                //ParameterField paramField8 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue8 = new ParameterDiscreteValue();
                //ParameterField paramField9 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue9 = new ParameterDiscreteValue();
                //ParameterField paramField10 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue10 = new ParameterDiscreteValue();
                //ParameterField paramField11 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue11 = new ParameterDiscreteValue();
                //ParameterField paramField12 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue12 = new ParameterDiscreteValue();
                //ParameterField paramField13 = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue13 = new ParameterDiscreteValue();

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
                    case "StudentTypeList":

                        DataTable dtST1 = new DataTable();
                        reportDocument.Load(Server.MapPath("StudentTypeRPT.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SeacrhStudentTypeDetailRPT";
                                    cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Request["Description"].ToString() == "1" ? Request["Description"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"].ToString() == "1" ? true : false;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtST1);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtST1);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "StudentTypelist");
                        break;

                        //paramField1.Name = "@Code";
                        //paramDiscreteValue1.Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                        //paramField1.CurrentValues.Add(paramDiscreteValue1);
                        //paramFields.Add(paramField1);

                        //paramField2.Name = "@Description";
                        //paramDiscreteValue2.Value = Request["Description"].ToString() == "1" ? Request["Description"].ToString() : null;
                        //paramField2.CurrentValues.Add(paramDiscreteValue2);
                        //paramFields.Add(paramField2);

                        //paramField3.Name = "@IsActive";
                        //paramDiscreteValue3.Value = Request["Status"].ToString() == "1" ? true : false;
                        //paramField3.CurrentValues.Add(paramDiscreteValue3);
                        //paramFields.Add(paramField3);


                        //reportDocument.Load(Server.MapPath("StudentTypeRPT.rpt"));
                        //CrystalReportViewer1.ParameterFieldInfo = paramFields;
                        //CrystalReportViewer1.ReportSource = SetDatabaseInfo(reportDocument);
                        //CrystalReportViewer1.DisplayToolbar = true;
                        //CrystalReportViewer1.HasCrystalLogo = false;
                        //CrystalReportViewer1.HasToggleGroupTreeButton = false;
                        //CrystalReportViewer1.HasSearchButton = false;
                        //CrystalReportViewer1.HasViewList = false;
                        //CrystalReportViewer1.HasDrillUpButton = false;
                        //CrystalReportViewer1.HasZoomFactorList = false;
                        //CrystalReportViewer1.DisplayGroupTree = false;
                        //CrystalReportViewer1.EnableParameterPrompt = false;
                        //break;
                       case "housetype":

                        DataTable dtST2 = new DataTable();
                        reportDocument.Load(Server.MapPath("HouseTypeRPT.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SeacrhHouseTypeDetailRPT";
                                    cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Request["Description"].ToString() == "1" ? Request["Description"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"].ToString() == "1" ? true : false;
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtST2);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtST2);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "HouseTypelist");
                        break;

                    //paramField1.Name = "@Code";
                    //paramDiscreteValue1.Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                    //paramField1.CurrentValues.Add(paramDiscreteValue1);
                    //paramFields.Add(paramField1);

                    //paramField2.Name = "@Description";
                    //paramDiscreteValue2.Value = Request["Description"].ToString() == "1" ? Request["Description"].ToString() : null;
                    //paramField2.CurrentValues.Add(paramDiscreteValue2);
                    //paramFields.Add(paramField2);

                    //paramField3.Name = "@IsActive";
                    //paramDiscreteValue3.Value = Request["Status"].ToString() == "1" ? true : false;
                    //paramField3.CurrentValues.Add(paramDiscreteValue3);
                    //paramFields.Add(paramField3);


                    //reportDocument.Load(Server.MapPath("HouseTypeRPT.rpt"));
                    //CrystalReportViewer1.ParameterFieldInfo = paramFields;
                    //CrystalReportViewer1.ReportSource = SetDatabaseInfo(reportDocument);
                    //CrystalReportViewer1.DisplayToolbar = true;
                    //CrystalReportViewer1.HasCrystalLogo = false;
                    //CrystalReportViewer1.HasToggleGroupTreeButton = false;
                    //CrystalReportViewer1.HasSearchButton = false;
                    //CrystalReportViewer1.HasViewList = false;
                    //CrystalReportViewer1.HasDrillUpButton = false;
                    //CrystalReportViewer1.HasZoomFactorList = false;
                    //CrystalReportViewer1.DisplayGroupTree = false;
                    //CrystalReportViewer1.EnableParameterPrompt = false;
                    //break;

                    case "RouteList":

                        DataTable dtST3 = new DataTable();
                        reportDocument.Load(Server.MapPath("RouteListRPT.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SeacrhRouteListlRPT";
                                    cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Request["Description"].ToString() == "1" ? Request["Description"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtST3);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtST3);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "RouteList");
                        break;

                    case "SubRouteList":

                        DataTable dtST4 = new DataTable();
                        reportDocument.Load(Server.MapPath("SubRouteListRPT.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SeacrhSubRouteListlRPT";
                                    cmd.Parameters.Add("@Route", SqlDbType.VarChar).Value = Request["Route"].ToString() == "1" ? Request["Route"].ToString() : null;
                                    cmd.Parameters.Add("@SubRoute", SqlDbType.VarChar).Value = Request["SubRoute"].ToString() == "1" ? Request["SubRoute"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtST4);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtST4);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "SubRouteTypelist");
                        break;

                    case "VehicleTypeList":

                        DataTable dtST5 = new DataTable();
                        reportDocument.Load(Server.MapPath("VehicleTypeListRPT.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SeacrhVehicleTypeListlRPT";
                                    cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                                    cmd.Parameters.Add("@VehicleType", SqlDbType.VarChar).Value = Request["VehicleType"].ToString() == "1" ? Request["VehicleType"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtST5);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtST5);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "VehicleTypelist");
                        break;

                    case "CampusList":

                        DataTable dtST7 = new DataTable();
                        reportDocument.Load(Server.MapPath("CampusListRPT.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SeacrhCampusListlRPT";
                                    cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Request["Description"].ToString() == "1" ? Request["Description"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtST7);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtST7);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "CampusList");
                        break;

                    case "Winglist":

                        DataTable dtST8 = new DataTable();
                        reportDocument.Load(Server.MapPath("WingListRPT.rpt"));
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "usp_CMS_Util_SeacrhWingListlRPT";
                                    cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Request["Code"].ToString() == "1" ? Request["Code"].ToString() : null;
                                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Request["Description"].ToString() == "1" ? Request["Description"].ToString() : null;
                                    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Request["Status"];
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    sda.Fill(dtST8);
                                }
                            }
                        }
                        reportDocument.SetDataSource(dtST8);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        reportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Winglist");
                        break;

                        //case "AdmissionBreakUpList":

                        // paramField1.Name = "@AcademicsessionId";
                        // paramDiscreteValue1.Value = Convert.ToInt32(Request["AcademicsessionId"].ToString() != "" ? Request["AcademicsessionId"] : "0");

                        // paramField1.CurrentValues.Add(paramDiscreteValue1);
                        // paramFields.Add(paramField1);

                        // paramField2.Name = "@ClassId";
                        // paramDiscreteValue2.Value = Convert.ToInt32(Request["ClassId"] != "" ? Request["ClassId"] : "0");
                        // paramField2.CurrentValues.Add(paramDiscreteValue2);
                        // paramFields.Add(paramField2);

                        // paramField3.Name = "@StudentTypeId";
                        // paramDiscreteValue3.Value = Convert.ToInt32(Request["StudentTypeId"] != "" ? Request["StudentTypeId"] : "0");
                        // paramField3.CurrentValues.Add(paramDiscreteValue3);
                        // paramFields.Add(paramField3);


                        // reportDocument.Load(Server.MapPath("AdmissionBreakupRPT.rpt"));
                        // CrystalReportViewer1.ParameterFieldInfo = paramFields;
                        // CrystalReportViewer1.ReportSource = SetDatabaseInfo(reportDocument);
                        // CrystalReportViewer1.DisplayToolbar = true;
                        // CrystalReportViewer1.HasCrystalLogo = false;
                        // CrystalReportViewer1.HasToggleGroupTreeButton = false;
                        // CrystalReportViewer1.HasSearchButton = false;
                        // CrystalReportViewer1.HasViewList = false;
                        // CrystalReportViewer1.HasDrillUpButton = false;
                        // CrystalReportViewer1.HasZoomFactorList = false;
                        // CrystalReportViewer1.DisplayGroupTree = false;
                        // CrystalReportViewer1.EnableParameterPrompt = false;
                        // break;

                }
            }

        }
        //public ReportDocument SetDatabaseInfo(ReportDocument crReportDocument)
        //{
        //    try
        //    {
        //        // CR variables		
        //        Database crDatabase;
        //        Tables crTables;
        //        TableLogOnInfo crTableLogOnInfo;
        //        ConnectionInfo crConnectionInfo;
        //        crConnectionInfo = new ConnectionInfo();

        //        ReportObjects crReportObjects;
        //        Sections crSections;
        //        ReportDocument crSubreportDocument;
        //        SubreportObject crSubreportObject;

        //        crConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings["ReportServerName"]; ;
        //        crConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["ReportDatabase"];
        //        crConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings["ReportUserId"];
        //        crConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["ReportPassword"];
        //        //Get the tables collection from the report object
        //        crDatabase = crReportDocument.Database;
        //        crTables = crDatabase.Tables;
        //        //Apply the logon information to each table in the collection
        //        foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
        //        {
        //            crTableLogOnInfo = crTable.LogOnInfo;
        //            crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
        //            crTable.ApplyLogOnInfo(crTableLogOnInfo);
        //        }


        //        crSections = crReportDocument.ReportDefinition.Sections;
        //        // loop through all the sections to find all the report objects 
        //        foreach (Section crSection in crSections)
        //        {
        //            crReportObjects = crSection.ReportObjects;
        //            //loop through all the report objects in there to find all subreports 
        //            foreach (ReportObject crReportObject in crReportObjects)
        //            {
        //                if (crReportObject.Kind == ReportObjectKind.SubreportObject)
        //                {
        //                    crSubreportObject = (SubreportObject)crReportObject;
        //                    //open the subreport object and logon as for the general report 
        //                    crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);
        //                    crDatabase = crSubreportDocument.Database;
        //                    crTables = crDatabase.Tables;
        //                    foreach (CrystalDecisions.CrystalReports.Engine.Table aTable in crTables)
        //                    {
        //                        crTableLogOnInfo = aTable.LogOnInfo;
        //                        crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
        //                        aTable.ApplyLogOnInfo(crTableLogOnInfo);
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //    return crReportDocument;
        //}

    }
}