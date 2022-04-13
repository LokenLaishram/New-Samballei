using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using System.Web.Services;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using System.Collections;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Campusoft.Data.EduFeeUtility;


namespace Mobimp.Campusoft.Web
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private SqlConnection con;
        private SqlCommand com;
        private string constr, query;
        LoginToken objLoginToken;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            
            objLoginToken = (LoginToken)Session["LoginToken"];
            if (objLoginToken != null)
            {
                bindstudentchart();
                bindstudentAttendancechart();
                bindEmployeechart();
                bindEmployeeAttendnacechart();
                BindExamChart();
                BindFeeChart();
                Calendar1.DayStyle.Font.Size = new FontUnit(15);
                Calendar1.SelectedDate = Calendar1.TodaysDate;
            }

        }
        private void connection()
        {
            constr = GlobalConstant.ConnectionString;
            con = new SqlConnection(constr);
            con.Open();

        }
        protected void bindstudentchart()
        {
            connection();
            com = new SqlCommand("usp_CMS_Exam_GetSchoolStudentCount", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@academicsessionid", objLoginToken.AcademicSessionID);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["Gender"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["StudentCount"]);
            }
            //binding chart control  
            StudentChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            StudentChart.Series[0].BorderWidth = 10;
            //setting Chart type   
            StudentChart.Series[0].ChartType = SeriesChartType.Pie;
            StudentChart.Titles.Add("STUDENT STRENGTH");

            foreach (Series charts in StudentChart.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "M": point.Color = Color.LightSkyBlue; break;
                        case "F": point.Color = Color.LightPink; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.AxisLabel, point.YValues[0]);

                }
            }
            //Enabled 3D  
            //StudentChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            con.Close();
        }
        protected void bindstudentAttendancechart()
        {
            connection();
            com = new SqlCommand("usp_CMS_Exam_GetSchoolStudentAttendanceCount", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@academicsessionid", objLoginToken.AcademicSessionID);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["Type"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Count"]);
            }
            //binding chart control  
            StudentAttendnaceChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            StudentAttendnaceChart.Series[0].BorderWidth = 10;
            //setting Chart type   
            StudentAttendnaceChart.Series[0].ChartType = SeriesChartType.Pie;
            StudentAttendnaceChart.Titles.Add("STUDENT TODAY'S ATTENDANCE");

            foreach (Series charts in StudentAttendnaceChart.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "P": point.Color = Color.RoyalBlue; break;
                        case "A": point.Color = Color.Tomato; break;
                        case "L": point.Color = Color.Yellow; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.AxisLabel, point.YValues[0]);

                }
            }
            //Enabled 3D  
            //StudentAttendnaceChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            con.Close();
        }
        protected void bindEmployeechart()
        {
            connection();
            com = new SqlCommand("usp_CMS_Exam_GetSchoolEmployeeCount", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@academicsessionid", objLoginToken.AcademicSessionID);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["Gender"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["EmployeeCount"]);
            }
            //binding chart control  
            EmployeeChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            EmployeeChart.Series[0].BorderWidth = 10;
            //setting Chart type   
            EmployeeChart.Series[0].ChartType = SeriesChartType.Pie;
            EmployeeChart.Titles.Add("EMPLOYEE STRENGTH");

            foreach (Series charts in EmployeeChart.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "M": point.Color = Color.PowderBlue; break;//Teal PowderBlue
                        case "F": point.Color = Color.Thistle; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.AxisLabel, point.YValues[0]);

                }
            }

            //Enabled 3D  
            // EmployeeChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            con.Close();
        }
        protected void bindEmployeeAttendnacechart()
        {
            connection();
            com = new SqlCommand("usp_CMS_Exam_GetEmployeeAttendanceCount", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@academicsessionid", objLoginToken.AcademicSessionID);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["Type"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Count"]);
            }
            //binding chart control  
            EmployeeAttendanceChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            EmployeeAttendanceChart.Series[0].BorderWidth = 20;
            //setting Chart type   
            EmployeeAttendanceChart.Series[0].ChartType = SeriesChartType.Bar;
            EmployeeAttendanceChart.Titles.Add("EMPLOYEE TODAY'S ATTENDANCE");

            foreach (Series charts in EmployeeAttendanceChart.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "P": point.Color = Color.RoyalBlue; break;
                        case "A": point.Color = Color.Tomato; break;
                        case "L": point.Color = Color.Yellow; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.AxisLabel, point.YValues[0]);

                }
            }
            //EmployeeAttendanceChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            //Enabled 3D  
            // EmployeeAttendanceChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            con.Close();
        }
        protected void BindFeeChart()
        {
            connection();
            com = new SqlCommand("usp_CMS_Exam_GetIncomeStatement", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@academicsessionid", objLoginToken.AcademicSessionID);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["IncomeType"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Amount"]);
            }
            //binding chart control  
            FeeChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            FeeChart.Series[0].BorderWidth = 10;
            //setting Chart type   
            FeeChart.Series[0].ChartType = SeriesChartType.Pie;
            FeeChart.Titles.Add("MONTHLY FEE STATEMENT");

            foreach (Series charts in FeeChart.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "PMI": point.Color = Color.RoyalBlue; break;
                        case "CA": point.Color = Color.Yellow; break;
                        case "DA": point.Color = Color.PaleVioletRed; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.AxisLabel, point.YValues[0]);

                }
            }
            //Enabled 3D  
            //FeeChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            con.Close();
        }
        protected void BindExamChart()
        {
            connection();
            com = new SqlCommand("usp_CMS_Exam_GetSExamChart", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@academicsessionid", objLoginToken.AcademicSessionID);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["ExamType"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["PC"]);
            }
            //binding chart control  
            ExamChart.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            ExamChart.Series[0].BorderWidth = 30;
            //setting Chart type   
            ExamChart.Series[0].ChartType = SeriesChartType.Column;
            ExamChart.Titles.Add("RESULT OVERVIEW");
            ExamChart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            foreach (Series charts in ExamChart.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "PT-I": point.Color = Color.RoyalBlue; break;
                        case "PT-II": point.Color = Color.Gold; break;
                        case "PT-III": point.Color = Color.Gray; break;
                        case "PT-IV": point.Color = Color.Tomato; break;
                        case "TT-I": point.Color = Color.Yellow; break;
                        case "TT-II": point.Color = Color.PaleVioletRed; break;
                        case "APP": point.Color = Color.RosyBrown; break;
                        case "FINAL": point.Color = Color.DarkOrange; break;
                    }
                    //point.Label = string.Format("{0:0} - {1}", point.AxisLabel, point.YValues[0]);
                    
                }
            }
            //Enabled 3D  
            //ExamChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            con.Close();
        }
        [System.Web.Services.WebMethod]
        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static IList GetEvents()
        {
            IList events = new List<Event>();
            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                events.Add(new Event
                {
                    EventName = "My Event " + i.ToString(),
                    StartDate = DateTime.Now.AddDays(i).ToString("MM-dd-yyyy"),
                    EndDate = DateTime.Now.AddDays(1).ToString("MM-dd-yyyy"),
                    ImageType = i % 2,
                    Url = @"http://www.google.com"
                });
            }
            return events;
        }
        public class Event
        {
            public Guid EventID { get { return new Guid(); } }
            public string EventName { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public int ImageType { get; set; }
            public string Url { get; set; }
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //com = new SqlCommand("usp_CMS_Exam_GetSExamChart", con);
            //com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@academicsessionid", objLoginToken.AcademicSessionID);
            ////SqlDataAdapter da = new SqlDataAdapter(com);
            //////DataSet ds = new DataSet();
            //////da.Fill(ds);
            ////Literal l = new Literal(); //Creating a literal  
            ////l.Visible = true;
            ////l.Text = "<br/><font size=-1>"; //for breaking the line in cell 
            ////e.Cell.Controls.Add(l); //adding in all cell  

            ////da = new SqlDataAdapter("select * from Events", con);
            ////DataTable dt = new DataTable();
            ////da.Fill(dt);
            ////foreach (DataRow dr in dt.Rows)
            ////{
            ////    string x = dr[1].ToString();

            ////    if (dr[1].ToString() == e.Day.Date.ToString()) //comparision  
            ////    {
            ////        Label lb = new Label();
            ////        lb.Visible = true;
            ////        lb.Text = dr[0].ToString();

            ////        string a = lb.Text;
            ////        e.Cell.Controls.Add(lb);
            ////        e.Cell.BackColor = System.Drawing.Color.OrangeRed; // changing cell color  
            ////        e.Cell.ToolTip = dr[0].ToString(); //adding tooltip  
                }
            }
        }  
//    }
//}