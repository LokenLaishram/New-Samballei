using System;
using System.Collections.Generic;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using System.Data.SqlClient;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using System.Data;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Campusoft.Data.EduFeeUtility;
using System.Text;

namespace Mobimp.Campusoft.Web.EduStudent
{
    public partial class StudentSubjectwise : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlexam, mstlookup.GetLookupsList(LookupNames.ExamNames));
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            ddlacademicseesions.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindChart();
        }
        protected void BindChart()
        {
            SqlParameter[] arParms = new SqlParameter[6];

            arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
            arParms[0].Value = ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue;

            arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParms[1].Value = ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue;

            arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
            arParms[2].Value = ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue;

            arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
            arParms[3].Value = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);

            arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
            arParms[4].Value = LoginToken.LoginId;

            arParms[5] = new SqlParameter("@sectionid", SqlDbType.Int);
            arParms[5].Value = ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue;

            SqlDataReader sqlReader = null;

            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetStudentSubjectwiseExamPerformance", arParms);
            List<ChartData> ListChartData = ORHelper<ChartData>.FromDataReaderToList(sqlReader);

            StringBuilder strSubjectName = new StringBuilder();
            StringBuilder strScoreMarks = new StringBuilder();

            int i = 0;
            foreach (ChartData row in ListChartData)
            {
                if (i != 0)
                {
                    strSubjectName.Append(",");
                    strScoreMarks.Append(",");
                }
                strSubjectName.Append("\"" + ListChartData[i].SubjectName.ToString() + "\"");
                strScoreMarks.Append("\"" + ListChartData[i].ScoreMarks.ToString() + "\"");
                i++;
            }
            ArrayLiterals.Text = "<script language=\"javascript\">" +
            "var ItemArray = [" + strSubjectName + "];" +
            "var QtyArray=[" + strScoreMarks + "];" +
            "window.onload = function () {" +
            "drawgrap()" +
            "};" +
            "</script>";

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../EduAnalytics/StudentSubjectwise.aspx");
        }


        //protected void tap5btnprint_Click(object sender, EventArgs e)
        //{
        //    Tap5BindChart();
        //    string docs = GlobalConstant.docpath;
        //    if (!System.IO.Directory.Exists(docs))
        //    {
        //        System.IO.Directory.CreateDirectory(docs);
        //    }
        //    string filename;
        //    if (ddlclasstap5.SelectedIndex > 0)
        //    {
        //        filename = "Exam_" + ddlclasstap5.SelectedItem.Text + "_Result_Performance.pdf";
        //        using (System.IO.FileStream fs = new FileStream(docs + "/" + filename, FileMode.Create))
        //        {

        //            Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
        //            // Create an instance to the PDF file by creating an instance of the PDF
        //            // Writer class using the document and the filestrem in the constructor.

        //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
        //            pdfDoc.Open();

        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                studentsubject.SaveImage(stream, ChartImageFormat.Png);
        //                iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
        //                chartImage.ScalePercent(100f);
        //                pdfDoc.Add(chartImage);
        //            }
        //            pdfDoc.Close();
        //            System.Diagnostics.Process.Start(docs + "/" + filename);
        //            fs.Close();
        //            lblmessage.Visible = false;

        //        }
        //    }
        //}
    }
}