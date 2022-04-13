using Mobimp.Edusoft.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Mobimp.Campusoft.Web
{
    /// <summary>
    /// Summary description for EmpImageHandler
    /// </summary>
    public class EmpImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string imageid = context.Request.QueryString["EmpID"];
            SqlConnection con = new SqlConnection(GlobalConstant.ConnectionString);
            con.Open();
            SqlCommand empcmd = new SqlCommand("SELECT EmployeePhotoImage FROM CMS_Edu_EmployeeDetails WHERE EmployeeID=" + imageid, con);
            SqlDataReader empdr = empcmd.ExecuteReader();
            empdr.Read();
            if (!empdr.IsDBNull(0))
            {
                context.Response.BinaryWrite((byte[])empdr[0]);
            }
            else
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(context.Server.MapPath("~/EduImages/EmpDummyPh.png"));
                Byte[] image = imageToByteArray(img);
                context.Response.BinaryWrite(image);
            }
            con.Close();
            context.Response.End();
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {

            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}