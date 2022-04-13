using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class Encrypter : System.Web.UI.Page
    {
        string provider = "RSAProtectedConfigurationProvider";
        string section = "connectionStrings";
        string Appsection = "appSettings";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration confg = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                ConfigurationSection confStrSect = confg.GetSection(section);
                ConfigurationSection AppconfStrSect = confg.GetSection(Appsection);
                if (confStrSect != null && AppconfStrSect !=null)
                {
                    confStrSect.SectionInformation.ProtectSection(provider);
                    AppconfStrSect.SectionInformation.ProtectSection(provider);
                    confg.Save();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration confg = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                ConfigurationSection confStrSect = confg.GetSection(section);
                ConfigurationSection AppconfStrSect = confg.GetSection(Appsection);
                if (confStrSect != null && confStrSect.SectionInformation.IsProtected)
                {
                    confStrSect.SectionInformation.UnprotectSection();
                    AppconfStrSect.SectionInformation.UnprotectSection();
                    confg.Save();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
