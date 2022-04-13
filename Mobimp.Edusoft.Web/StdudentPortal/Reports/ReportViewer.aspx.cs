using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mediqura.Web.MedRadTemplate
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            if (Request.QueryString["option"] != null)
            {
                switch (Request.QueryString["option"].ToString())
                {
                    case "PaymentReceipt":
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Connection = con;
                                    cmd.CommandText = "usp_CMS_Print_Fee_Receipt";
                                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["BillID"]);
                                    cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["StudentID"]);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    byte[] bytes = (byte[])cmd.ExecuteScalar();
                                    string base64 = Convert.ToBase64String(bytes);

                                    string extension = GetFileExtension(base64);

                                    if(extension== "jpg")
                                    {
                                       Response.ContentType = "image/jpeg";
                                    }
                                    if (extension == "png")
                                    {
                                        Response.ContentType = "image/png";
                                    }
                                    if (extension == "pdf")
                                    {
                                        Response.ContentType = "application/pdf";
                                    }
                                  
                                    Response.AddHeader("content-length", bytes.Length.ToString());
                                    Response.BinaryWrite(bytes);
                                }
                            }
                        }
                        break;
                
                }

            }
        }
        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }
    }
}