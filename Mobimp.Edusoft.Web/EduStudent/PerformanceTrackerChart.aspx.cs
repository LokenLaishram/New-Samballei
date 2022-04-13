using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using System.Data.SqlClient;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using System.Data;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Campusoft.Data.EduUtility;
using System.Reflection;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;


namespace Mobimp.Campusoft.Web.EduStudent
{
    public partial class PerformanceChart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
                Tap2BindDlls();
                Tap3BindDlls();
                Tap4BindDlls();
                Tap5BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlexam, mstlookup.GetLookupsList(LookupNames.ExamNames));
            ddlacademicseesions.SelectedIndex = 1;
        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                //put a breakpoint here and check datatable
                return dataTable;
            }
        }
        protected void ddlexamtap1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChart();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindChart();
        }
        protected void BindChart()
        {
            SqlParameter[] arParms = new SqlParameter[3];

            arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
            arParms[0].Value = ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue;

            arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
            arParms[1].Value = ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue;

            arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
            arParms[2].Value = LoginToken.LoginId;

            SqlDataReader sqlReader = null;

            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetClasswiseExamPerformance", arParms);
            List<ChartData> ListChartData = ORHelper<ChartData>.FromDataReaderToList(sqlReader);

            ListtoDataTableConverter convertor = new ListtoDataTableConverter();
            DataTable dt = convertor.ToDataTable(ListChartData);
            DataTable ChartData = dt;

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            decimal[] YPointMember = new decimal[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["Class"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToDecimal(ChartData.Rows[count]["PassPc"]);
            }
            //binding chart control  
            ExamChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);
            //Setting width of line  
            ExamChart.Series[0].BorderWidth = 5;
            //setting Chart type   
            ExamChart.Series[0].ChartType = SeriesChartType.Column;
            ExamChart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            BindChart();
            string docs = GlobalConstant.docpath;
            if (!System.IO.Directory.Exists(docs))
            {
                System.IO.Directory.CreateDirectory(docs);
            }
            try
            {
               
                string filename;
            
      
                if (ddlexam.SelectedIndex > 0)
                {
                    filename = "Exam_" + ddlexam.SelectedItem.Text + "_Result_Performance.pdf";

                    using (System.IO.FileStream fs = new FileStream(docs + "/" + filename, FileMode.Create))
                {

                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                    // Create an instance to the PDF file by creating an instance of the PDF
                    // Writer class using the document and the filestrem in the constructor.

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                    using (MemoryStream stream = new MemoryStream())
                    {
                        ClasswiseChart.SaveImage(stream, ChartImageFormat.Png);
                        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                        chartImage.ScalePercent(100f);
                        pdfDoc.Add(chartImage);
                    }
                    pdfDoc.Close();
                    System.Diagnostics.Process.Start(docs + "/" + filename);
                    fs.Close();
                    lblmessage.Visible = false;

                }
            }

            }

            catch (Exception ex)
            {
                Messagealert_.ShowMessage(lblmessage, "Please close the existing pdf file."+ex, 0);
            }
        }

        protected void View(object sender, EventArgs e)
        {
            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
            embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";
            ltEmbed.Text = string.Format(embed, ResolveUrl("~/Files/Mudassar_Khan.pdf"));
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlexam.SelectedIndex = 0;
            ddlclasstap2.SelectedIndex = 0;
            ddlclasstap3.SelectedIndex = 0;
            ddlclasstap4.SelectedIndex = 0;
            txtrollNo.Text = "";
            ddlsectionstap2.SelectedIndex = 0;
            lblmessage.Visible = false;
        }
        //-----------TAP 2 EXAMWISE PERFORMANCE-------------//
        protected void Tap2BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesionstap2, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlclasstap2, mstlookup.GetLookupsList(LookupNames.Class));
            ddlacademicseesionstap2.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsectionstap2, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasstap2.SelectedValue == "" ? "0" : ddlclasstap2.SelectedValue)));
            //Commonfunction.PopulateDdl(ddlexamtap2, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasstap2.SelectedValue == "" ? "0" : ddlclasstap2.SelectedValue)));
        }
        protected void tap2btnsearch_Click(object sender, EventArgs e)
        {
            Tap2BindChart();
        }
        protected void Tap2BindChart()
        {
            SqlParameter[] arParms = new SqlParameter[4];

            arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
            arParms[0].Value = ddlacademicseesionstap2.SelectedValue == "" ? "0" : ddlacademicseesionstap2.SelectedValue;

            arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParms[1].Value = ddlclasstap2.SelectedValue == "" ? "0" : ddlclasstap2.SelectedValue;

            arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
            arParms[2].Value = ddlsectionstap2.SelectedValue == "" ? "0" : ddlsectionstap2.SelectedValue;

            arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
            arParms[3].Value = LoginToken.LoginId;

            SqlDataReader sqlReader = null;

            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetExamwiseExamPerformance", arParms);
            List<ChartData> ListChartData = ORHelper<ChartData>.FromDataReaderToList(sqlReader);

            ListtoDataTableConverter convertor = new ListtoDataTableConverter();
            DataTable dt = convertor.ToDataTable(ListChartData);
            DataTable ChartData = dt;

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            decimal[] YPointMember = new decimal[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["ExamName"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToDecimal(ChartData.Rows[count]["PassPc"]);
            }
            //binding chart control  
            ClasswiseChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);
            //Setting width of line  
            ClasswiseChart.Series[0].BorderWidth = 5;
            //setting Chart type   
            ClasswiseChart.Series[0].ChartType = SeriesChartType.Column;

        }
        protected void tap2btnprint_Click(object sender, EventArgs e)
        {
            Tap2BindChart();
            string docs = GlobalConstant.docpath;
            if (!System.IO.Directory.Exists(docs))
            {
                System.IO.Directory.CreateDirectory(docs);
            }
            string filename;
            if (ddlclasstap2.SelectedIndex > 0)
            {
                filename = "Exam_" + ddlclasstap2.SelectedItem.Text + "_Result_Performance.pdf";

                using (System.IO.FileStream fs = new FileStream(docs + "/" + filename, FileMode.Create))
                {

                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                    // Create an instance to the PDF file by creating an instance of the PDF
                    // Writer class using the document and the filestrem in the constructor.

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                    using (MemoryStream stream = new MemoryStream())
                    {
                        ClasswiseChart.SaveImage(stream, ChartImageFormat.Png);
                        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                        chartImage.ScalePercent(100f);
                        pdfDoc.Add(chartImage);
                    }
                    pdfDoc.Close();
                    System.Diagnostics.Process.Start(docs + "/" + filename);
                    fs.Close();
                    lblmessage.Visible = false;

                }
            }
        }
        //-----------TAP 3 EXAMWISE PERFORMANCE-------------//
        protected void Tap3BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesionstap3, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlclasstap3, mstlookup.GetLookupsList(LookupNames.Class));
            ddlacademicseesionstap3.SelectedIndex = 1;
        }
        protected void ddlclassestap3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsectiontap3, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasstap3.SelectedValue == "" ? "0" : ddlclasstap3.SelectedValue)));
            //Commonfunction.PopulateDdl(ddlexamtap2, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasstap2.SelectedValue == "" ? "0" : ddlclasstap2.SelectedValue)));
        }
        protected void tap3btnsearch_Click(object sender, EventArgs e)
        {
            Tap3BindChart();
        }
        protected void Tap3BindChart()
        {
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
            arParms[0].Value = ddlacademicseesionstap3.SelectedValue == "" ? "0" : ddlacademicseesionstap3.SelectedValue;

            arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParms[1].Value = ddlclasstap3.SelectedValue == "" ? "0" : ddlclasstap3.SelectedValue;

            arParms[2] = new SqlParameter("@RollNo", SqlDbType.Int);
            arParms[2].Value = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);

            arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
            arParms[3].Value = LoginToken.LoginId;

            arParms[4] = new SqlParameter("@sectionid", SqlDbType.Int);
            arParms[4].Value = ddlsectiontap3.SelectedValue == "" ? "0" : ddlsectiontap3.SelectedValue;

            SqlDataReader sqlReader = null;

            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetStudentwiseExamPerformance", arParms);
            List<ChartData> ListChartData = ORHelper<ChartData>.FromDataReaderToList(sqlReader);

            ListtoDataTableConverter convertor = new ListtoDataTableConverter();
            DataTable dt = convertor.ToDataTable(ListChartData);
            DataTable ChartData = dt;

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            decimal[] YPointMember = new decimal[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["ExamName"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToDecimal(ChartData.Rows[count]["PassPc"]);
            }
            //binding chart control  
            StudentwiseChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);
            //Setting width of line  
            StudentwiseChart.Series[0].BorderWidth = 5;
            //setting Chart type   
            StudentwiseChart.Series[0].ChartType = SeriesChartType.Spline;

        }
        protected void tap3btnprint_Click(object sender, EventArgs e)
        {
            Tap3BindChart();
            string docs = GlobalConstant.docpath;
            if (!System.IO.Directory.Exists(docs))
            {
                System.IO.Directory.CreateDirectory(docs);
            }
            string filename;
            if (ddlclasstap3.SelectedIndex > 0)
            {
                filename = "Exam_" + ddlclasstap3.SelectedItem.Text + "_Result_Performance.pdf";
                using (System.IO.FileStream fs = new FileStream(docs + "/" + filename, FileMode.Create))
                {

                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                    // Create an instance to the PDF file by creating an instance of the PDF
                    // Writer class using the document and the filestrem in the constructor.

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();
                    using (MemoryStream stream = new MemoryStream())
                    {
                        StudentwiseChart.SaveImage(stream, ChartImageFormat.Png);
                        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                        chartImage.ScalePercent(100f);
                        pdfDoc.Add(chartImage);
                    }
                    pdfDoc.Close();
                    System.Diagnostics.Process.Start(docs + "/" + filename);
                    fs.Close();
                    lblmessage.Visible = false;
                }
            }
        }
        //-----------TAP 4 EXAMWISE PERFORMANCE-------------//
        protected void Tap4BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesionstap4, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlclasstap4, mstlookup.GetLookupsList(LookupNames.Class));
            ddlacademicseesionstap4.SelectedIndex = 1;
        }
        protected void ddlclassestap4_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsectiontap4, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasstap4.SelectedValue == "" ? "0" : ddlclasstap4.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexamtap4, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasstap4.SelectedValue == "" ? "0" : ddlclasstap4.SelectedValue)));
        }
        protected void ddlexamtap4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tap4BindChart();
        }
        protected void tap4btnsearch_Click(object sender, EventArgs e)
        {
            Tap4BindChart();
        }
        protected void Tap4BindChart()
        {
            SqlParameter[] arParms = new SqlParameter[5];

            arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
            arParms[0].Value = ddlacademicseesionstap4.SelectedValue == "" ? "0" : ddlacademicseesionstap4.SelectedValue;

            arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParms[1].Value = ddlclasstap4.SelectedValue == "" ? "0" : ddlclasstap4.SelectedValue;

            arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
            arParms[2].Value = ddlexamtap4.SelectedValue == "" ? "0" : ddlexamtap4.SelectedValue;

            arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
            arParms[3].Value = LoginToken.LoginId;

            arParms[4] = new SqlParameter("@sectionid", SqlDbType.Int);
            arParms[4].Value = ddlsectiontap4.SelectedValue == "" ? "0" : ddlsectiontap4.SelectedValue;

            SqlDataReader sqlReader = null;

            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetSubjectwiseExamPerformance", arParms);
            List<ChartData> ListChartData = ORHelper<ChartData>.FromDataReaderToList(sqlReader);

            ListtoDataTableConverter convertor = new ListtoDataTableConverter();
            DataTable dt = convertor.ToDataTable(ListChartData);
            DataTable ChartData = dt;

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            decimal[] YPointMember = new decimal[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["SubjectName"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToDecimal(ChartData.Rows[count]["PassPc"]);
            }
            //binding chart control  
            SubjectChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);
            //Setting width of line  
            SubjectChart.Series[0].BorderWidth = 5;
            //Setting for rotate XAxis Title
            SubjectChart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            //Setting for rotate XAxis Title
            SubjectChart.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
            //setting Chart type   
            SubjectChart.Series[0].ChartType = SeriesChartType.RangeColumn;

        }
        protected void tap4btnprint_Click(object sender, EventArgs e)
        {
            Tap4BindChart();
            string docs = GlobalConstant.docpath;
            if (!System.IO.Directory.Exists(docs))
            {
                System.IO.Directory.CreateDirectory(docs);
            }
            string filename;
            if (ddlclasstap4.SelectedIndex > 0)
            {
                filename = "Exam_" + ddlclasstap4.SelectedItem.Text + "_Result_Performance.pdf";
                using (System.IO.FileStream fs = new FileStream(docs + "/" + filename, FileMode.Create))
                {

                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                    // Create an instance to the PDF file by creating an instance of the PDF
                    // Writer class using the document and the filestrem in the constructor.

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();
                    using (MemoryStream stream = new MemoryStream())
                    {
                        SubjectChart.SaveImage(stream, ChartImageFormat.Png);
                        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                        chartImage.ScalePercent(100f);
                        pdfDoc.Add(chartImage);
                    }
                    pdfDoc.Close();
                    System.Diagnostics.Process.Start(docs + "/" + filename);
                    fs.Close();
                    lblmessage.Visible = false;
                }
            }
        }
        //-----------TAP 5 EXAMWISE PERFORMANCE-------------//
        protected void Tap5BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesionstap5, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlclasstap5, mstlookup.GetLookupsList(LookupNames.Class));
            ddlacademicseesionstap5.SelectedIndex = 1;
        }
        protected void ddlclassestap5_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsectiontap5, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasstap5.SelectedValue == "" ? "0" : ddlclasstap5.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexamtap5, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasstap5.SelectedValue == "" ? "0" : ddlclasstap5.SelectedValue)));
        }
        protected void tap5btnsearch_Click(object sender, EventArgs e)
        {
            Tap5BindChart();
        }
        protected void Tap5BindChart()
        {
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
            arParms[0].Value = ddlacademicseesionstap5.SelectedValue == "" ? "0" : ddlacademicseesionstap5.SelectedValue;

            arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParms[1].Value = ddlclasstap5.SelectedValue == "" ? "0" : ddlclasstap5.SelectedValue;

            arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
            arParms[2].Value = ddlexamtap5.SelectedValue == "" ? "0" : ddlexamtap5.SelectedValue;

            arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
            arParms[3].Value = Convert.ToInt32(txtrollNotap5.Text == "" ? "0" : txtrollNotap5.Text);

            arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
            arParms[4].Value = LoginToken.LoginId;

            arParms[5] = new SqlParameter("@sectionid", SqlDbType.Int);
            arParms[5].Value = ddlsectiontap5.SelectedValue == "" ? "0" : ddlsectiontap5.SelectedValue;

            SqlDataReader sqlReader = null;

            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetStudentSubjectwiseExamPerformance", arParms);
            List<ChartData> ListChartData = ORHelper<ChartData>.FromDataReaderToList(sqlReader);

            ListtoDataTableConverter convertor = new ListtoDataTableConverter();
            DataTable dt = convertor.ToDataTable(ListChartData);
            DataTable ChartData = dt;

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            decimal[] YPointMember = new decimal[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["SubjectName"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToDecimal(ChartData.Rows[count]["ScoreMarks"]);
            }
            //binding chart control  
            studentsubject.Series[0].Points.DataBindXY(XPointMember, YPointMember);
            //Setting width of line  
            studentsubject.Series[0].BorderWidth = 5;
            //Setting for rotate XAxis Title
            studentsubject.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            //Setting for rotate XAxis Title
            studentsubject.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
            //setting Chart type   
            studentsubject.Series[0].ChartType = SeriesChartType.RangeColumn;

        }
        protected void tap5btnprint_Click(object sender, EventArgs e)
        {
            Tap5BindChart();
            string docs = GlobalConstant.docpath;
            if (!System.IO.Directory.Exists(docs))
            {
                System.IO.Directory.CreateDirectory(docs);
            }
            string filename;
            if (ddlclasstap5.SelectedIndex > 0)
            {
                filename = "Exam_" + ddlclasstap5.SelectedItem.Text + "_Result_Performance.pdf";
                using (System.IO.FileStream fs = new FileStream(docs + "/" + filename, FileMode.Create))
                {

                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                    // Create an instance to the PDF file by creating an instance of the PDF
                    // Writer class using the document and the filestrem in the constructor.

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                    using (MemoryStream stream = new MemoryStream())
                    {
                        studentsubject.SaveImage(stream, ChartImageFormat.Png);
                        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                        chartImage.ScalePercent(100f);
                        pdfDoc.Add(chartImage);
                    }
                    pdfDoc.Close();
                    System.Diagnostics.Process.Start(docs + "/" + filename);
                    fs.Close();
                    lblmessage.Visible = false;

                }
            }
        }
    }
}