using System;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.WebPortal;
using Mobimp.Edusoft.BussinessProcess.WebPortal;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
//using Ionic.Zip;
using System.Drawing;

namespace Mobimp.Campusoft.Web.WebPortal
{
    public partial class DataSync : System.Web.UI.Page
    {
        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
        ReportDocument reportDocument = new ReportDocument();
        string constr = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
                Boolean isOnline = Commonfunction.CheckForInternetConnection();
                if (isOnline)
                {
                    lblmessage.Text = "Online";

                }
                else
                {
                    lblmessage.Text = "Ofline";
                }
                bindgrid();
            }

        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlexam, mstlookup.GetLookupsList(LookupNames.ExamNames));
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            if (ddlclasses.SelectedIndex > 0)
            {
                ddlsections.Enabled = true;
            }
            else
            {
                ddlsections.SelectedIndex = 0;

            }
        }
        protected void ddlsections_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void bindgrid()
        {
            DataSincData objdata = new DataSincData();
            DataSincBO objexamBO = new DataSincBO();

            objdata.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objdata.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objdata.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objdata.RollNo = Convert.ToInt32(txtrollno.Text == "" ? "0" : txtrollno.Text);
            string resultss = objexamBO.GetAllData(objdata);

            txtjson.Text = resultss;
            gvDataSinc.DataBind();
            btnSinc.Visible = true;

        }
        //protected void btnSinc_Click(object sender, EventArgs e)
        //{

        //    string URL = "http://campusoft.hol.es/";
        //    //Boolean flag = Commonfunction.isValidURL(URL);
        //    //if (flag)
        //    Boolean isOnline = Commonfunction.CheckForInternetConnection();
        //    if (isOnline)
        //    {
        //        string Json;
        //        string constring = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
        //        using (SqlConnection con = new SqlConnection(constring))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("usp_CMS_get_WebPortal_AllData", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ClassID", Convert.ToInt32(ddlclasses.SelectedValue == "0" ? null : ddlclasses.SelectedValue));
        //                cmd.Parameters.AddWithValue("@RollNo", txtrollno.Text.ToString());
        //                cmd.Parameters.AddWithValue("@AcademicSessionID", ddlacademicseesions.SelectedValue);
        //                cmd.Parameters.AddWithValue("@SectionID", ddlsections.SelectedValue);
        //                cmd.Parameters.Add("@jsonOutput", SqlDbType.VarChar, 100000);
        //                cmd.Parameters["@jsonOutput"].Direction = ParameterDirection.Output;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //                Json = cmd.Parameters["@jsonOutput"].Value.ToString();
        //                String response = SendReqst(Json);

        //                // lblmessage.Text = "Online";
        //                txtjson.Text = Json;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        lblmessage.Text = "Offline";
        //    }

        //}
        public string SendReqst(string pWebRequstStr)
        {
            string URL = "http://campusoft.hol.es/api/v1/sync";
            string lResponseStr = "";
            string lResult = "";
            try
            {
                String WebPortalHost = URL;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(WebPortalHost);
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("apikey", "123456789");
                httpWebRequest.ContentLength = (long)pWebRequstStr.Length;
                httpWebRequest.ContentType = "application/json";
                StreamWriter lStrmWritr = new StreamWriter(httpWebRequest.GetRequestStream());
                lStrmWritr.Write(pWebRequstStr);
                lStrmWritr.Close();
                HttpWebResponse lhttpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream lreceiveStream = lhttpResponse.GetResponseStream();
                StreamReader lStreamReader = new StreamReader(lreceiveStream, Encoding.UTF8);
                lResponseStr = lStreamReader.ReadToEnd();
                lhttpResponse.Close();
                lStreamReader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            lResult = lResponseStr;
            return lResult;
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSincData objdata = new DataSincData();
            DataSincBO objexamBO = new DataSincBO();

            objdata.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objdata.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objdata.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objdata.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objdata.RollNo = Convert.ToInt32(txtrollno.Text == "" ? "0" : txtrollno.Text);
            List<DataSincData> list = objexamBO.list(objdata);
            objdata.ClassName = list[0].ClassName;
            string ClassName = objdata.ClassName;
            int studentno = list.Count;
            if (list != null)
            {
                for (int i = 0; i < studentno; i++)
                {
                    objdata.StudentName = list[i].StudentName;
                    objdata.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                    objdata.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                    objdata.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
                    objdata.RollNo = list[i].RollNo;
                    objdata.StudentID = list[i].StudentID;
                    objdata.Examname = list[i].Examname;
                    string Name = objdata.StudentName;
                    


                    DataTable dt = new DataTable();
                    reportDocument.Load(Server.MapPath("~/EduReports/Reports/MarkSheetProtrait.rpt"));

                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "usp_CMS_exam_Print";
                                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Convert.ToInt32(ddlclasses.SelectedValue);
                                cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = Convert.ToInt32(ddlsections.SelectedValue);
                                cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = Convert.ToInt32(ddlexam.SelectedValue);
                                cmd.Parameters.Add("@AcademicSessionID", SqlDbType.Int).Value = Convert.ToInt32(ddlacademicseesions.SelectedValue);
                                cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = list[i].RollNo;
                                cmd.Connection = con;
                                sda.SelectCommand = cmd;
                                sda.Fill(dt);
                            }
                        }
                        reportDocument.SetDataSource(dt);
                        ExportOptions CrExportOptions;
                        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                        CrDiskFileDestinationOptions.DiskFileName = "E:\\Exam\\" + Name + ".pdf";
                        CrExportOptions = reportDocument.ExportOptions;
                        {
                            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                            CrExportOptions.FormatOptions = CrFormatTypeOptions;
                        }
                        reportDocument.Export();

                        lblmsg.Text = studentno + " PDF Export";
                    }
                }
            }
            // Ziping 
            string path = @"E:\Exam\";
            string savepath = "E:\\Exam\\"+ClassName+".zip";
            string[] Filenames = Directory.GetFiles(path);
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFiles(Filenames, ClassName);//Zip file inside filename  
                zip.Save(savepath);//location and name for creating zip file  

            }

        }

        protected void btnZip_Click(object sender, EventArgs e)
        {
            string path = @"E:\Exam\";
          //  string path = Server.MapPath("E/Exam/");//Location for inside Test Folder  
            string[] Filenames = Directory.GetFiles(path);
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFiles(Filenames, "Project");//Zip file inside filename  
                zip.Save(@"E:\\Exam\\Projectzip.zip");//location and name for creating zip file  

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sourceDir = @"E:\Exam";
            string backupDir = @"E:\Exam\Backup";

            try
            {
                string[] picList = Directory.GetFiles(sourceDir, "*.jpg");
                string[] pdfList = Directory.GetFiles(sourceDir, "*.pdf");

                // Copy picture files. 
                foreach (string f in picList)
                {
                    // Remove path from the file name. 
                    string fName = f.Substring(sourceDir.Length + 1);

                    // Use the Path.Combine method to safely append the file name to the path. 
                    // Will overwrite if the destination file already exists.
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }

                // Copy pdf files. 
                //foreach (string f in pdfList)
                //{

                //    // Remove path from the file name. 
                //    string fName = f.Substring(sourceDir.Length + 1);

                //    try
                //    {
                //        // Will not overwrite if the destination file already exists.
                //        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName));
                //    }

                //    // Catch exception if the file was already copied. 
                //    catch (IOException copyError)
                //    {
                //         lblmsg.Text=(copyError.Message);
                //    }
                //}

                // Delete source files that were copied. 
                foreach (string f in pdfList)
                {
                    File.Delete(f);
                }
                foreach (string f in picList)
                {
                    File.Delete(f);
                }
                lblmsg.Text = "Delete Successfully";             
                lblmsg.ForeColor = Color.Red;

                lblmessage.Text = "Delete Successfully";
                lblmessage.ForeColor = Color.Red;
                return;
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                lblmsg.Text=(dirNotFound.Message);
                lblmessage.Text = (dirNotFound.Message);
            }
        }
    }
}
 
