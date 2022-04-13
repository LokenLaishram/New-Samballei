using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Mobimp.Edusoft.Common;  

namespace Mobimp.Campusoft.Web
{
    public partial class Backup : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();  

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBackup_Click(object sender, EventArgs e)
        {
            //IF SQL Server Authentication then Connection String  
            //con.ConnectionString = @"Server=MyPC\SqlServer2k8;database=" + YourDBName + ";uid=sa;pwd=password;";  

            //IF Window Authentication then Connection String 
           // con.ConnectionString = @"Server=MyPC\SqlServer2k8;database=Test;Integrated Security=true;";  

            con.ConnectionString = GlobalConstant.ConnectionString;

            string backupDIR = GlobalConstant.backuppath;
            string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"].ToString();
            string name = ConfigurationManager.AppSettings["name"].ToString();

            if (!System.IO.Directory.Exists(backupDIR))
            {
                System.IO.Directory.CreateDirectory(backupDIR);
            }
            try
            {
                con.Open();
                sqlcmd = new SqlCommand(DatabaseName + "='" + backupDIR + "\\" + name + "_" + DateTime.Now.ToString("dd_M_yy_hh_mm_ss tt") + "'", con);
                sqlcmd.ExecuteNonQuery();

                lblmessage.ForeColor = System.Drawing.Color.Green;
                lblmessage.Text = "Backup database successfully";
            }
            catch (Exception ex)
            {
                lblmessage.Text = "Error Occured During DB backup process !<br>" + ex.ToString();
            }
        }  
    }
}