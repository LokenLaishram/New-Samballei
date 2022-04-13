using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduAdmin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Mobimp.Campusoft.Web
{
    public partial class HomeDashboard : System.Web.UI.Page
    {
        LoginToken objLoginToken;
        string strXML;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                objLoginToken = (LoginToken)HttpContext.Current.Session["LoginToken"];
                BindModules();

            }

        }
        private void BindModules()
        {
            StringBuilder UIstring = new StringBuilder();
            DataTable Modules = GetData();
            DataView view = new DataView(Modules);
            view.RowFilter = "ParentID=0";
            Modules = view.ToTable();
            List<SiteMapData> lsmodules = ORHelper<SiteMapData>.FromDataTableToList(Modules);
            if (lsmodules.Count > 0)
            {
                for (int i = 0; i < lsmodules.Count; i++)
                {
                    DataTable Module1 = GetData();
                    DataView view1 = new DataView(Module1);
                    if (lsmodules[i].Url == "#")
                    {
                        view1.RowFilter = "ParentID=" + lsmodules[i].SiteMapID.ToString();
                    }
                    else
                    {
                        view1.RowFilter = "SiteMapID=" + lsmodules[i].SiteMapID.ToString();

                    }
                    Module1 = view1.ToTable();
                    List<SiteMapData> Childlist = ORHelper<SiteMapData>.FromDataTableToList(Module1);
                    string ind_list = "";

                    for (int j = 0; j < Childlist.Count; j++)
                    {
                        ind_list = ind_list + "<a href = '" + Childlist[j].Url + "' class='dropdown-item url_dropdown_item'><i class='" + Childlist[j].CssFont.ToString() + "'></i>" + Childlist[j].Title + "</a>";
                    }

                    string temp = " <div class='col-md-3 card_col'>" +
                   " <div class='card-counter default right_cus_menu' style='background-image: url(app-assets/dashboardimage/" + lsmodules[i].DashboardImage.ToString() + ");' sitemap_id='" + lsmodules[i].SiteMapID.ToString() + "'>" +
                    "<div class='dropdown dropdown-user show_module_dropdown'>" +
                     "<div class='dropdown-toggle dashboard_module_dropdown' data-toggle='dropdown'>" +
                      "<span class='fa fa-ellipsis-v dashboard_module_dropdown_icon' style=''></span>" +
                       "</div>" +
                        "<div class='dropdown-menu url_dropdown_menu'>" + ind_list + "   </div>" +
                        "</div>" +
                        "<div class='show_module_dropdown_footer_wrapper' style='background-color: " + lsmodules[i].Dashboardfootercolor.ToString() + "'>" +
                         "<i class='" + lsmodules[i].CssFont.ToString() + "' style=''></i>" +
                          "<div class='count-numbers'>" + lsmodules[i].Title.ToString() + "</div>" +
                           "<div class='count-name'>" + lsmodules[i].Description.ToString() + "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>";

                    UIstring.Append(temp);
                }
            }
            ModuleDasboard.Text = "" + UIstring;
        }
        private DataTable GetData()
        {
            DataTable dt = new DataTable { TableName = "MenuTable" };
            string constr = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // string xmlData = "";
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_CMS_Adm_GetAllSiteMaps";
                        cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = objLoginToken.RoleID;
                        cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = objLoginToken.EmployeeID;
                        cmd.Connection = con;
                        // con.Open();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        //DataSet ds = new DataSet { DataSetName = "MainDataset" };
                        //ds.Tables.Add(dt);
                        ////sda.Fill(ds);
                        //strXML = ds.GetXml();

                    }
                }
                return dt;
            }
        }
    }
}