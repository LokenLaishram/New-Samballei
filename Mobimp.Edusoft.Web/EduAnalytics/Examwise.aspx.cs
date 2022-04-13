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
using Mobimp.Campusoft.Data.EduFeeUtility;
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
using System.Text;

namespace Mobimp.Campusoft.Web.EduStudent
{
    public partial class Examwise : BasePage
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
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
        }

        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindChart();
        }
        protected void BindChart()
        {
            SqlParameter[] arParms = new SqlParameter[4];

            arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
            arParms[0].Value = ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue;

            arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParms[1].Value = ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue;

            arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
            arParms[2].Value = ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue;

            arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
            arParms[3].Value = LoginToken.LoginId;

            SqlDataReader sqlReader = null;

            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetExamwiseExamPerformance", arParms);
            List<ChartData> ListChartData = ORHelper<ChartData>.FromDataReaderToList(sqlReader);

            StringBuilder strExamName = new StringBuilder();
            StringBuilder strPassPc = new StringBuilder();

            int i = 0;
            foreach (ChartData row in ListChartData)
            {
                if (i != 0)
                {
                    strExamName.Append(",");
                    strPassPc.Append(",");
                }
                strExamName.Append("\"" + ListChartData[i].ExamName.ToString() + "\"");
                strPassPc.Append("\"" + ListChartData[i].PassPc.ToString() + "\"");
                i++;
            }
            ArrayLiterals.Text = "<script language=\"javascript\">" +
            "var ItemArray = [" + strExamName + "];" +
            " var QtyArray=[" + strPassPc + "];" +
            " window.onload = function () {" +
            "drawgrap()" +
            "};" +
            "</script>";

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../EduAnalytics/Examwise.aspx");
        }


        //protected void tap2btnprint_Click(object sender, EventArgs e)
        //{
        //    string docs = GlobalConstant.docpath;
        //    if (!System.IO.Directory.Exists(docs))
        //    {
        //        System.IO.Directory.CreateDirectory(docs);
        //    }
        //    string filename;
        //    if (ddlclasses.SelectedIndex > 0)
        //    {
        //        filename = "Exam_" + ddlclasses.SelectedItem.Text + "_Result_Performance.pdf";

        //        using (System.IO.FileStream fs = new FileStream(docs + "/" + filename, FileMode.Create))
        //        {

        //            Document pdfDoc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
        //            // Create an instance to the PDF file by creating an instance of the PDF
        //            // Writer class using the document and the filestrem in the constructor.

        //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
        //            pdfDoc.Open();

        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                ClasswiseChart.SaveImage(stream, ChartImageFormat.Png);
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