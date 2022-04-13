using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Mobimp.Campusoft.Web.webservices
{
    /// <summary>
    /// Summary description for AutocompleteLinks
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutocompleteLinks : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod()]
        public string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            if (count == 0)
            {
                count = 10;
            }
            DataTable dt = GetRecords(prefixText, contextKey);
            List<string> items = new List<string>(count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
        public DataTable GetRecords(string Links, String RoleID)
        {
            string strConn = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
            cmd.Parameters.Add("@Links", SqlDbType.VarChar).Value = Links;
            cmd.CommandText = "usp_MDQ_GetAultocompleteLinks";
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            return objDs.Tables[0];
        }
        [WebMethod]
        [ScriptMethod()]
        public string[] Getautostudentlist(string prefixText, int count, string contextKey)
        {
            if (count == 0)
            {
                count = 10;
            }
            DataTable dt = GetstudentRecords(prefixText, prefixText);
            List<string> items = new List<string>(count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
        public DataTable GetstudentRecords(string Links, String names)
        {
            string strConn = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = names;
            cmd.CommandText = "usp_CMS_Emp_autocompleteStudentNames";
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            return objDs.Tables[0];
        }
        [WebMethod]
        [ScriptMethod()]
        public string[] GetautosRegistrationlist(string prefixText, int count, string contextKey)
        {
            if (count == 0)
            {
                count = 10;
            }
            DataTable dt = GetOnlineregistrationRecords(prefixText, prefixText);
            List<string> items = new List<string>(count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
        public DataTable GetOnlineregistrationRecords(string Links, String names)
        {
            string strConn = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = names;
            cmd.CommandText = "usp_CMS_Emp_autocompleteOnlineRegistration";
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            return objDs.Tables[0];
        }
        [WebMethod]
        [ScriptMethod()]
        public string[] GetautoEmployeelist(string prefixText, int count, string contextKey)
        {
            if (count == 0)
            {
                count = 10;
            }
            DataTable dt = GetEmployeeRecords(prefixText, prefixText);
            List<string> items = new List<string>(count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
        public DataTable GetEmployeeRecords(string Links, String names)
        {
            string strConn = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = names;
            cmd.CommandText = "usp_CMS_Emp_autocompleteEmpnames";
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            return objDs.Tables[0];
        }
        [WebMethod]
        [ScriptMethod()]
        public string[] GetAutoTeachingStaffList(string prefixText, int count, string contextKey)
        {
            if (count == 0)
            {
                count = 10;
            }
            DataTable dt = GetAutoTeachingStaffRecords(prefixText, prefixText, contextKey);
            List<string> items = new List<string>(count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
        public DataTable GetAutoTeachingStaffRecords(string Links, String names, string contextKey)
        {
            Int64 EmpID = Convert.ToInt64(contextKey);
            string strConn = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = names;
            cmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = EmpID;
            //cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = BehaviorID;
            cmd.CommandText = "usp_CMS_Emp_AutoCompleteTeachingStaff";
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            return objDs.Tables[0];
        }
    }
}
