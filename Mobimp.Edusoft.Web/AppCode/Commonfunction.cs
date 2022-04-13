using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.Common;
using System.Globalization;
using Saplin.Controls;
using System.Net;
using System.Xml;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Mobimp.Edusoft.Web.AppCode
{
    public class Commonfunction
    {
        public static bool isValidDate(string input)
        {
            DateTime outTime; bool ValidateTime;
            ValidateTime = DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outTime);
            return ValidateTime;
        }
        #region LookUps DropDowns
        public static void PopulateDdl(DropDownList drpDownList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (drpDownList != null && lstLookups != null)
            {
                drpDownList.DataSource = lstLookups;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemName";
                drpDownList.DataBind();
                drpDownList.Items.Insert(0, "-- Select --");
                drpDownList.Items[0].Value = "0";
                drpDownList.ClearSelection();

            }
        }
        public static void TimetablePopulateDdl(DropDownList drpDownList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (drpDownList != null && lstLookups != null)
            {
                drpDownList.DataSource = lstLookups;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemName";
                drpDownList.DataBind();
                drpDownList.Items.Insert(0, "-- Not Selected --");
                drpDownList.Items[0].Value = "0";
                drpDownList.ClearSelection();

            }
        }
        public static void PopulateteacherDdl(DropDownList drpDownList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (drpDownList != null && lstLookups != null)
            {
                drpDownList.DataSource = lstLookups;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemName";
                drpDownList.DataBind();
                drpDownList.Items.Insert(0, "Show all teachers");
                drpDownList.Items[0].Value = "0";
                drpDownList.ClearSelection();

            }
        }
        public static void Populatelistbox(ListBox itemlist, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (itemlist != null && lstLookups != null)
            {
                itemlist.DataSource = lstLookups;
                itemlist.DataValueField = "ItemId";
                itemlist.DataTextField = "ItemName";
                itemlist.DataBind();
                //itemlist.Items.Insert(0, "-- Select --");
                //itemlist.Items[0].Value = "0";
                itemlist.ClearSelection();

            }
        }
        public static void PopulateListbox(ListBox Listbox, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (Listbox != null && lstLookups != null)
            {
                Listbox.DataSource = lstLookups;
                Listbox.DataValueField = "ItemId";
                Listbox.DataTextField = "ItemName";
                Listbox.DataBind();
                Listbox.ClearSelection();
            }
        }
        public static void PopulateDdlnoselect(DropDownList drpDownList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (drpDownList != null && lstLookups != null)
            {
                drpDownList.DataSource = lstLookups;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemName";
                drpDownList.DataBind();
                drpDownList.ClearSelection();

            }
        }
        public static void PopulateCheckbox(DropDownCheckBoxes checkboxList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (checkboxList != null && lstLookups != null)
            {
                checkboxList.DataSource = lstLookups;
                checkboxList.DataValueField = "ItemId";
                checkboxList.DataTextField = "ItemName";
                checkboxList.DataBind();
                checkboxList.ClearSelection();

            }
        }
        public static void PopulateDdls(DropDownList drpDownList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (drpDownList != null && lstLookups != null)
            {
                drpDownList.DataSource = lstLookups;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemName";
                drpDownList.DataBind();
                drpDownList.ClearSelection();

            }
        }
        public static void PopulateDdlCode(DropDownList drpDownList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (drpDownList != null && lstLookups != null)
            {
                drpDownList.DataSource = lstLookups;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemCode";
                drpDownList.DataBind();
                drpDownList.Items.Insert(0, "-- Select --");
                drpDownList.Items[0].Value = "0";
                drpDownList.ClearSelection();
            }
        }
        public static void Insertzeroitemindex(DropDownList drpDownList)
        {
            drpDownList.Items.Clear();
            drpDownList.Items.Insert(0, "-- Select --");
            drpDownList.Items[0].Value = "0";
        }
        public static void PopulateDdlAll(DropDownList drpDownList, List<LookupItem> lstLookups)
        {
            if (lstLookups == null) lstLookups = new List<LookupItem>();
            if (drpDownList != null && lstLookups != null)
            {
                drpDownList.DataSource = lstLookups;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemName";
                drpDownList.DataBind();
                drpDownList.Items.Insert(0, "-- All --");
                drpDownList.Items[0].Value = "0";
                drpDownList.ClearSelection();
            }
        }
        public static void PopulateDdlAny<T>(DropDownList drpDownList, List<T> lstObj, bool isAll)
        {
            if (lstObj == null) lstObj = new List<T>();
            if (drpDownList != null && lstObj != null)
            {
                drpDownList.DataSource = lstObj;
                drpDownList.DataValueField = "ItemId";
                drpDownList.DataTextField = "ItemName";
                drpDownList.DataBind();
                if (isAll)
                {
                    drpDownList.Items.Insert(0, "-- All --");
                    drpDownList.Items[0].Value = "0";
                }
                drpDownList.ClearSelection();
            }

        }
        public static Int32 SemicolonSeparation_String_32(string SourceString)
        {
            try
            {
                if (SourceString.Contains(":") && SourceString.Substring(SourceString.LastIndexOf(':') + 1).All(char.IsDigit) == true)
                {
                    Int32 x = Convert.ToInt32(SourceString.Substring(SourceString.LastIndexOf(':') + 1));
                    return x;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static Int64 SemicolonSeparation_String_64(string SourceString)
        {
            try
            {

                if (SourceString.Contains(":") && SourceString.Substring(SourceString.LastIndexOf(':') + 1).All(char.IsDigit) == true)
                {
                    Int64 x = Convert.ToInt64(SourceString.Substring(SourceString.LastIndexOf(':') + 1));
                    return x;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        #endregion
        #region Hour-Min-AMPM-Day DropDowns
        public static void PopulateDdlHour(DropDownList drpDownList)
        {
            drpDownList.Items.Add(new ListItem("HH", "00"));
            for (int i = 1; i <= 12; i++)
            {
                string t = i.ToString();
                if (t.Length == 1) t = "0" + t;
                drpDownList.Items.Add(new ListItem(t, t));
            }
        }
        public static void PopulateDdlMinute(DropDownList drpDownList)
        {
            drpDownList.Items.Add(new ListItem("MM", "00"));
            for (int i = 1; i <= 60; i++)
            {
                string t = i.ToString();
                if (t.Length == 1) t = "0" + t;
                drpDownList.Items.Add(new ListItem(t, t));
            }
        }
        public static void PopulateDdlAMPM(DropDownList drpDownList)
        {
            //drpDownList.Items.Add(new ListItem("AM/PM", "AM/PM"));
            drpDownList.Items.Add(new ListItem("AM", "AM"));
            drpDownList.Items.Add(new ListItem("PM", "PM"));
        }
        public static void PopulateDdlDays(DropDownList drpDownList)
        {
            drpDownList.Items.Add(new ListItem("--Select Day--", "0"));
            drpDownList.Items.Add(new ListItem("Sunday", "1"));
            drpDownList.Items.Add(new ListItem("Monday", "2"));
            drpDownList.Items.Add(new ListItem("Tuesday", "3"));
            drpDownList.Items.Add(new ListItem("Wednesday", "4"));
            drpDownList.Items.Add(new ListItem("Thursday", "5"));
            drpDownList.Items.Add(new ListItem("Friday", "6"));
            drpDownList.Items.Add(new ListItem("Saturday", "7"));
        }
        public static String Getrounding(String str) // in xxx.xxxxx
        {
            try
            {
                decimal number;
                Decimal.TryParse(str, out number);
                return Decimal.Round(number, 2).ToString(); // in xxx.xx format
            }
            catch
            {
                return "0.00"; // in 0.00 format if invalid number is passed
            }
        }



        #endregion

        public static string GetClientIPAddress()
        {
            string clientIPAddress;// = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            clientIPAddress = "127.0.0.1";
            return clientIPAddress;
        }
        public static bool isValidURL(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Timeout = 2000;
            WebResponse webResponse;
            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch //If exception thrown then couldn't get response from address
            {
                return false;
            }
            webResponse.Close();
            return true;
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;

            }
            catch
            {
                return false;
            }
        }
        public static String GetRoundingToNumber(String str) // in xxx.xxxxx
        {
            try
            {
                decimal number;
                Decimal.TryParse(str, out number);
                return Decimal.Round(number, 0).ToString(); // in xxx.xx format
            }
            catch
            {
                return "0.00"; // in 0.00 format if invalid number is passed
            }
        }
        string EncryptionKey;
        private static string GenerateKey(int iKeySize)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = iKeySize;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;
            aesEncryption.GenerateIV();
            string ivStr = Convert.ToBase64String(aesEncryption.IV);
            aesEncryption.GenerateKey();
            string keyStr = Convert.ToBase64String(aesEncryption.Key);
            string completeKey = ivStr + "," + keyStr;
            return Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(completeKey));
        }
        public  string Encrypt(string clearText)
        {
            EncryptionKey = "MAKV2SPBNI99212$&#(!";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public  string Decrypt(string cipherText)
        {
            EncryptionKey = "MAKV2SPBNI99212$&#(!";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}