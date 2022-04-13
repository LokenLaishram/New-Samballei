using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Mobimp.Edusoft.Common
{
  public static  class GlobalConstant
    {
        public static string ConnectionString;
        public static string xlsConnectionString;
        public static string EncryptionKey;
        public static string DateFormat;
        public static string backuppath;
        public static string multifoto;
        public static string docpath;
        public static string smsapi;
        public static string DriverPhoto;

        public static DateTime MinSQLDateTime; //= DateTime.Parse("01/01/1753", provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

        static GlobalConstant()
        {
            //Connection for SQL Server Database
            ConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString11"].ConnectionString;
           //EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            DateFormat = ConfigurationManager.AppSettings["DateFormat"];
            backuppath = ConfigurationManager.AppSettings["backup"].ToString();
            multifoto = ConfigurationManager.AppSettings["multiphoto"].ToString();
            docpath = ConfigurationManager.AppSettings["Document"].ToString();

            smsapi = ConfigurationManager.AppSettings["SMSAPI"].ToString();
            DriverPhoto = ConfigurationManager.AppSettings["driverphoto"].ToString();

            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
            MinSQLDateTime = DateTime.Parse("01/01/1753", provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        }
    }
}
