using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Common;
using System.IO;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Web.UserControls;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web
{
    public partial class EmployeesMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindddl();
                if (Session["ID"] != null)
                {
                    Editprofile(Convert.ToInt32(Session["ID"]));
                    Session["ID"] = null;

                }
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlcountry, mstlookup.GetLookupsList(LookupNames.Country));
            ddlcountry.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlstate, mstlookup.GetLookupsList(LookupNames.State));
            ddlstate.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlDistrict, mstlookup.GetLookupsList(LookupNames.District));
            Commonfunction.PopulateDdl(ddlcountry1, mstlookup.GetLookupsList(LookupNames.Country));
            Commonfunction.PopulateDdl(ddlstate1, mstlookup.GetLookupsList(LookupNames.State));
            Commonfunction.PopulateDdl(ddldistrict1, mstlookup.GetLookupsList(LookupNames.District));
            Commonfunction.PopulateDdl(ddlsalutation, mstlookup.GetLookupsList(LookupNames.Salutation));
            Commonfunction.PopulateDdl(ddlsex, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlreligion, mstlookup.GetLookupsList(LookupNames.Religion));
            Commonfunction.PopulateDdl(ddlCast, mstlookup.GetLookupsList(LookupNames.Cast));
            Commonfunction.PopulateDdl(ddlemplyee, mstlookup.GetLookupsList(LookupNames.EmployeeType));
            Commonfunction.PopulateDdl(ddlreligion, mstlookup.GetLookupsList(LookupNames.Religion));
            Commonfunction.PopulateDdl(ddldesignation, mstlookup.GetLookupsList(LookupNames.Designation));
            // Commonfunction.PopulateDdl(ddldepartement, mstlookup.GetLookupsList(LookupNames.Department));
            Commonfunction.PopulateDdl(ddlmarital, mstlookup.GetLookupsList(LookupNames.MaritalStatus));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlbloodgroup, mstlookup.GetLookupsList(LookupNames.BloodGroup));
            Commonfunction.PopulateDdl(ddlStaffTypeID, mstlookup.GetLookupsList(LookupNames.StaffType));
            Commonfunction.PopulateDdl(ddlempcategory, mstlookup.GetLookupsList(LookupNames.StaffCategory));
            Commonfunction.PopulateDdl(ddlStaffTypeTab2, mstlookup.GetLookupsList(LookupNames.StaffType));
            Commonfunction.PopulateDdl(ddlempcategories, mstlookup.GetLookupsList(LookupNames.StaffCategory));

        }
        protected void ddlsalutation_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsex, objmstlookupBO.GetSexBySalutationID(Convert.ToInt32(ddlsalutation.SelectedValue)));
        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountry.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlstate, objmstlookupBO.GetStatelistByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)));
                ddlstate.SelectedIndex = 1;
            }
        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstate.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                int stateID = Convert.ToInt32(ddlstate.SelectedValue);
                int CountryID = Convert.ToInt32(ddlcountry.SelectedValue);
                Commonfunction.PopulateDdl(ddlDistrict, objmstlookupBO.GetDistrictlistByID(stateID, CountryID));
            }

        }
        protected void ddlcountry1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountry1.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlstate1, objmstlookupBO.GetStatelistByCountryID(Convert.ToInt32(ddlcountry1.SelectedValue)));
            }
        }
        protected void ddlstate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstate1.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                int stateID = Convert.ToInt32(ddlstate1.SelectedValue);
                int CountryID = Convert.ToInt32(ddlcountry1.SelectedValue);
                Commonfunction.PopulateDdl(ddldistrict1, objmstlookupBO.GetDistrictlistByID(stateID, CountryID));
            }
        }
        protected void chksame_CheckedChanged(object sender, EventArgs e)
        {
            if (chksame.Checked)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlcountry1, mstlookup.GetLookupsList(LookupNames.Country));
                Commonfunction.PopulateDdl(ddlstate1, mstlookup.GetLookupsList(LookupNames.State));
                Commonfunction.PopulateDdl(ddldistrict1, mstlookup.GetLookupsList(LookupNames.District));

                txtaddress1.Text = txtaddress.Text;
                ddlcountry1.SelectedValue = ddlcountry.SelectedValue;
                ddlstate1.SelectedValue = ddlstate.SelectedValue;
                ddldistrict1.SelectedValue = ddlDistrict.SelectedValue;
                txtpin1.Text = txtpin.Text;
                txtlandmark1.Text = txtlandmark.Text;
            }
            else
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                txtaddress1.Text = "";
                Commonfunction.PopulateDdl(ddlcountry1, mstlookup.GetLookupsList(LookupNames.Country));
                Commonfunction.PopulateDdl(ddlstate1, mstlookup.GetLookupsList(LookupNames.State));
                Commonfunction.PopulateDdl(ddldistrict1, mstlookup.GetLookupsList(LookupNames.District));
                txtpin1.Text = "";
                txtlandmark1.Text = "";
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeesMST.aspx");
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeesMST.aspx");
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeData objemp = new EmployeeData();
                EmployeeBO objempBO = new EmployeeBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

                // string fileName = digiupload.FileName.ToString();

                //if (fileName == "")
                //{
                //    objemp.DigitalSignatureLocation = "";
                //    objemp.DigitalSignatureImage = null;
                //}
                //else
                //{
                //    if (!digiupload.HasFile)
                //    {
                //        Messagealert_.ShowMessage(lblmessage, "system", 0);
                //        return;
                //    }
                //    else
                //    {
                //        string path = getDigitalPath(fileName); ;
                //        objemp.DigitalSignatureLocation = path;
                //        //imageuploader as bit image
                //        int length = digiupload.PostedFile.ContentLength;
                //        //create a byte array to store the binary image data
                //        byte[] imgbyte = new byte[length];
                //        //store the currently selected file in memeory
                //        HttpPostedFile img = digiupload.PostedFile;
                //        //set the binary data
                //        img.InputStream.Read(imgbyte, 0, length);
                //        objemp.DigitalSignatureImage = imgbyte;
                //        if (path == "fail" || objemp.DigitalSignatureLocation == "")
                //        {
                //            Messagealert_.ShowMessage(lblmessage, "system", 0);
                //            return;
                //        }
                //    }
                //}
                //string empFile = FileUploader.FileName.ToString();
                //if (empFile == "")
                //{
                //    objemp.EmployeePhotoLocation = "../EduImages/Employee.jpg";
                //}
                //else
                //{
                //    if (!FileUploader.HasFile)
                //    {
                //        Messagealert_.ShowMessage(lblmessage, "system", 0);
                //        return;
                //    }
                //    string EmpPath = getEmpPhotoPath(empFile); ;
                //    objemp.EmployeePhotoLocation = EmpPath;
                //    //imageuploader as bit image
                //    int length = FileUploader.PostedFile.ContentLength;
                //    //create a byte array to store the binary image data
                //    byte[] imgbyte = new byte[length];
                //    //store the currently selected file in memeory
                //    HttpPostedFile img = FileUploader.PostedFile;
                //    //set the binary data
                //    img.InputStream.Read(imgbyte, 0, length);
                //    objemp.EmployeePhotoImage = imgbyte;
                //    if (EmpPath == "fail" || objemp.EmployeePhotoLocation == "")
                //    {
                //        Messagealert_.ShowMessage(lblmessage, "system", 0);
                //        return;
                //    }
                //}
                objemp.SalutationID = Convert.ToInt32(ddlsalutation.SelectedValue == "" ? "0" : ddlsalutation.SelectedValue);
                objemp.SexID = Convert.ToInt32(ddlsex.SelectedValue == "" ? "0" : ddlsex.SelectedValue);
                objemp.CastID = Convert.ToInt32(ddlCast.SelectedValue == "" ? "0" : ddlCast.SelectedValue);
                objemp.DesignationID = Convert.ToInt32(ddldesignation.SelectedValue == "" ? "0" : ddldesignation.SelectedValue);
                objemp.ReligionID = Convert.ToInt32(ddlreligion.SelectedValue == "" ? "0" : ddlreligion.SelectedValue);
                objemp.CastID = Convert.ToInt32(ddlCast.SelectedValue == "" ? "0" : ddlCast.SelectedValue);
                //objemp.DepartmentID = Convert.ToInt32(ddldepartement.SelectedValue == "" ? "0" : ddldepartement.SelectedValue);
                objemp.EmployeeTypeID = Convert.ToInt32(ddlemplyee.SelectedValue == "" ? "0" : ddlemplyee.SelectedValue);
                objemp.EmployeeCatgeroyID = Convert.ToInt32(ddlempcategory.SelectedValue == "" ? "0" : ddlempcategory.SelectedValue);
                objemp.StaffTypeID = Convert.ToInt32(ddlStaffTypeID.SelectedValue == "" ? "0" : ddlStaffTypeID.SelectedValue);
                objemp.CurrentCountryID = Convert.ToInt32(ddlcountry.SelectedValue == "" ? "0" : ddlcountry.SelectedValue);
                objemp.CurrentStateID = Convert.ToInt32(ddlstate.SelectedValue == "" ? "0" : ddlstate.SelectedValue);
                objemp.CurrentDistrictID = Convert.ToInt32(ddlDistrict.SelectedValue == "" ? "0" : ddlDistrict.SelectedValue);
                objemp.PermCountryID = Convert.ToInt32(ddlcountry1.SelectedValue == "" ? "0" : ddlcountry1.SelectedValue);
                objemp.PermStateID = Convert.ToInt32(ddlstate1.SelectedValue == "" ? "0" : ddlstate1.SelectedValue);
                objemp.PermDistrictID = Convert.ToInt32(ddldistrict1.SelectedValue == "" ? "0" : ddldistrict1.SelectedValue);
                objemp.MaritalStatusID = Convert.ToInt32(ddlmarital.SelectedValue == "" ? "0" : ddlmarital.SelectedValue);
                objemp.EmpName = txtempname.Text == "" ? null : txtempname.Text;
                DateTime DOB = txtDOB.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDOB.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objemp.DOB = DOB;
                DateTime DOJ = txtdateofjoining.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdateofjoining.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objemp.DOJ = DOJ;
                objemp.EmaildID = txtemailid.Text == "" ? null : txtemailid.Text;
                objemp.MobileNo = txtmobile.Text == "" ? null : txtmobile.Text;
                objemp.EmployeeNo = txtempno.Text == "" ? null : txtempno.Text;
                //objemp.Qualification = txtqualification.Text == "" ? null : txtqualification.Text;
                objemp.Experience = txtexperience.Text == "" ? null : txtexperience.Text;
                objemp.BloodGroupID = Convert.ToInt32(ddlbloodgroup.SelectedValue == "" ? "0" : ddlbloodgroup.SelectedValue);
                objemp.IDmarks = txtIDmarks.Text == "" ? null : txtIDmarks.Text;
                //objemp.PhoneNo = txtphoneNo.Text == "" ? null : txtphoneNo.Text;
                objemp.CurrentAddress = txtaddress.Text == "" ? null : txtaddress.Text;
                objemp.CurrentPIN = Convert.ToInt32(txtpin.Text == "" ? "0" : txtpin.Text);
                objemp.CurrentLandMark = txtlandmark1.Text == "" ? null : txtlandmark1.Text;
                objemp.PermAddress = txtaddress1.Text == "" ? null : txtaddress1.Text;
                objemp.PermPIN = Convert.ToInt32(txtpin1.Text == "" ? "0" : txtpin1.Text);
                objemp.PermLandMark = txtlandmark1.Text == "" ? null : txtlandmark1.Text;
                objemp.ProfessionalQualification = txtprofessioanlqualification.Text == "" ? null : txtprofessioanlqualification.Text;
                objemp.University = txtuniversity.Text == "" ? null : txtuniversity.Text;
                objemp.EPF = txtepfno.Text == "" ? null : txtepfno.Text;
                objemp.BankName = txtbank.Text == "" ? null : txtbank.Text;
                objemp.AC = txtaccountno.Text == "" ? null : txtaccountno.Text;
                objemp.AddedBy = LoginToken.LoginId;
                objemp.UserId = LoginToken.UserLoginId;
                objemp.CompanyID = LoginToken.CompanyID;
                objemp.AcademicSessionID = LoginToken.AcademicSessionID;
                //if (ViewState["ID"] == null)
                //{
                //    objemp.ActionType = EnumActionType.Insert;
                //    int results = objempBO.UpdateEmployeeDetails(objemp);
                //    if (results > 5)
                //    {
                //        txtempno.Text = results.ToString();
                //        Messagealert_.ShowMessage(lblmessage, results != 2 ? "save" : "update", 1);
                //    }
                //    else if (results == 4)
                //    {
                //        Messagealert_.ShowMessage(lblmessage, "checkduplicateadmissionno", 0);
                //    }
                //    else if (results == 5)
                //    {
                //        Messagealert_.ShowMessage(lblmessage, "checkduplicatestudent", 0);
                //    }
                //}
                objemp.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objemp.ActionType = EnumActionType.Update;
                    objemp.EmployeeID = Convert.ToInt32(ViewState["ID"].ToString());
                    //if (empFile == null || empFile == "")
                    //{
                    //    objemp.EmployeePhotoLocation = ViewState["Photopath"].ToString();
                    //    ViewState["Photopath"] = null;
                    //}
                    //if (ViewState["EmpCategory"].ToString() != ddlempcategories.SelectedValue)
                    //{
                    //    objemp.Istransfer = true;
                    //}
                }
                int result = objempBO.UpdateEmployeeDetails(objemp);
                if (result == 1 || result == 2)
                {
                    ClearAll();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
                bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                return;
            }

        }
        protected string getDigitalPath(string fileName)
        {
            string path = "";
            // fileName = txtempname.Text.Trim() + "_" + fileName;
            try
            {
                if (Directory.Exists(Request.PhysicalApplicationPath + @"EduDigiSign/") == false)
                    Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduDigiSign/");

                if (File.Exists(Request.PhysicalApplicationPath + @"EduDigiSign/" + fileName))
                {
                    File.Delete(Request.PhysicalApplicationPath + @"EduDigiSign/" + fileName);
                    // return "exist";
                }

                //FileUploader.SaveAs(Request.PhysicalApplicationPath + @"EduDigiSign/" + fileName);
                //path = @"EduDigiSign/" + fileName;
            }
            catch
            {
                return "fail";
            }

            return path;
        }
        protected string getEmpPhotoPath(string empFile)
        {
            string path = "";
            try
            {
                if (Directory.Exists(Request.PhysicalApplicationPath + @"EduEmpPhoto/") == false)
                    Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduEmpPhoto/");

                if (File.Exists(Request.PhysicalApplicationPath + @"EduEmpPhoto/" + empFile))
                {
                    File.Delete(Request.PhysicalApplicationPath + @"EduEmpPhoto/" + empFile);
                    // return "exist";
                }
                //FileUploader.SaveAs(Request.PhysicalApplicationPath + @"EduEmpPhoto/" + empFile);
                // path = @"EduEmpPhoto/" + empFile;
            }
            catch
            {
                return "fail";
            }
            return path;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<EmployeeData> studentdetails = GetEmployeedetails(index, pagesize);
            if (studentdetails.Count > 0)
            {
                GvemployeeDetails.Visible = true;
                GvemployeeDetails.PageSize = pagesize;
                string record = studentdetails[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + studentdetails[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = studentdetails[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvemployeeDetails.VirtualItemCount = studentdetails[0].MaximumRows;//total item is required for custom paging
                GvemployeeDetails.PageIndex = index - 1;
                GvemployeeDetails.DataSource = studentdetails;
                GvemployeeDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(studentdetails);
                divsearch.Visible = true;
            }
            else
            {
                GvemployeeDetails.DataSource = null;
                GvemployeeDetails.DataBind();
                GvemployeeDetails.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public DataSet ConvertToDataSet<T>(IList<T> list)
        {
            DataSet dsFromDtStru = new DataSet();
            DataTable table = new DataTable();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            dsFromDtStru.Tables.Add(table);
            return dsFromDtStru;
        }
        public List<EmployeeData> GetEmployeedetails(int curIndex, int pagesize)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeNo = txtemployeedID.Text == "" ? null : txtemployeedID.Text;
            objemp.EmployeeID = Commonfunction.SemicolonSeparation_String_64(txtempnames.Text);
            objemp.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objemp.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objemp.StaffTypeID = Convert.ToInt32(ddlStaffTypeTab2.SelectedValue == "" ? "0" : ddlStaffTypeTab2.SelectedValue);
            objemp.EmployeeCatgeroyID = Convert.ToInt32(ddlempcategories.SelectedValue == "" ? "0" : ddlempcategories.SelectedValue);
            objemp.IsActiveALL = ddlstatus.SelectedValue;
            objemp.ActionType = EnumActionType.Select;
            objemp.PageSize = GvemployeeDetails.PageSize;
            objemp.CurrentIndex = curIndex;
            return objempBO.SearchEmployeeTypeDetails(objemp);
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetempNames(string prefixText, int count, string contextKey)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();
            List<EmployeeData> getResult = new List<EmployeeData>();
            objemp.EmpName = prefixText;
            getResult = objempBO.GetEmpnames(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmpName.ToString());
            }
            return list;
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvemployeeDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvemployeeDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvemployeeDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvemployeeDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvemployeeDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvemployeeDetails.UseAccessibleHeader = true;
            GvemployeeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void ClearAll()
        {
            txtempno.Text = "";
            ddlsalutation.SelectedIndex = 0;
            ddlsex.SelectedIndex = 0;
            ddlCast.SelectedIndex = 0;
            ddldesignation.SelectedIndex = 0;
            ddlreligion.SelectedIndex = 0;
            ddlCast.SelectedIndex = 0;
            // ddldepartement.SelectedIndex = 0;
            ddlemplyee.SelectedIndex = 0;
            ddlcountry.SelectedIndex = 0;
            ddlstate.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
            ddlcountry1.SelectedIndex = 0;
            ddlstate1.SelectedIndex = 0;
            ddldistrict1.SelectedIndex = 0;
            ddlmarital.SelectedIndex = 0;
            txtempname.Text = "";
            txtDOB.Text = "";
            txtemailid.Text = "";
            txtmobile.Text = "";
            //txtphoneNo.Text = "";
            txtaddress.Text = "";
            txtpin.Text = "";
            txtlandmark.Text = "";
            txtaddress1.Text = "";
            txtpin1.Text = "";
            txtlandmark1.Text = "";
        }
        private void Editprofile(Int64 EmployeeID)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeID = EmployeeID;
            objemp.ActionType = EnumActionType.Select;
            List<EmployeeData> GetResult = objempBO.GetEmployeeDetailsByID(objemp);
            if (GetResult.Count > 0)
            {
                ddlsalutation.SelectedValue = GetResult[0].SalutationID.ToString();
                txtempname.Text = GetResult[0].EmpName;
                ddlreligion.SelectedValue = GetResult[0].ReligionID.ToString();
                ddlsex.SelectedValue = GetResult[0].SexID.ToString();
                ddlemplyee.SelectedValue = GetResult[0].EmployeeTypeID.ToString();
                ddlmarital.SelectedValue = GetResult[0].MaritalStatusID.ToString();
                ddlempcategory.SelectedValue = GetResult[0].EmployeeCatgeroyID.ToString();
                ddlStaffTypeID.SelectedValue = GetResult[0].StaffTypeID.ToString();
                ddlCast.SelectedValue = GetResult[0].CastID.ToString();
                // ddldepartement.SelectedValue = GetResult[0].DepartmentID.ToString();
                ddldesignation.SelectedValue = GetResult[0].DesignationID.ToString();
                ddlcountry.SelectedValue = GetResult[0].CurrentCountryID.ToString();
                ddlstate.SelectedValue = GetResult[0].CurrentStateID.ToString();
                ddlDistrict.SelectedValue = GetResult[0].CurrentDistrictID.ToString();
                ddlcountry1.SelectedValue = GetResult[0].PermCountryID.ToString();
                ddlstate1.SelectedValue = GetResult[0].PermStateID.ToString();
                ddldistrict1.SelectedValue = GetResult[0].PermDistrictID.ToString();
                txtDOB.Text = GetResult[0].DOB.ToString("dd/MM/yyyy");
                txtdateofjoining.Text = GetResult[0].DOJ.ToString("dd/MM/yyyy");
                //txtphoneNo.Text = GetResult[0].PhoneNo;
                txtexperience.Text = GetResult[0].Experience;
                ddlbloodgroup.SelectedValue = GetResult[0].BloodGroupID.ToString();
                txtmobile.Text = GetResult[0].MobileNo;
                txtemailid.Text = GetResult[0].EmaildID;
                txtaddress.Text = GetResult[0].CurrentAddress;
                txtpin.Text = GetResult[0].CurrentPIN.ToString();
                txtIDmarks.Text = GetResult[0].IDmarks.ToString();
                txtempno.Text = GetResult[0].EmployeeNo.ToString();
                txtlandmark.Text = GetResult[0].CurrentLandMark;
                txtaddress1.Text = GetResult[0].PermAddress;
                txtlandmark1.Text = GetResult[0].PermLandMark;
                // txtqualification.Text = GetResult[0].Qualification;
                txtpin1.Text = GetResult[0].PermPIN.ToString();
                txtprofessioanlqualification.Text = GetResult[0].ProfessionalQualification.ToString();
                txtuniversity.Text = GetResult[0].University;
                txtifsc.Text = GetResult[0].IFSC;
                txtbank.Text = GetResult[0].BankName;
                txtaccountno.Text = GetResult[0].AC;
                ViewState["ID"] = GetResult[0].EmployeeID;
                //txtempno.Attributes["disabled"] = "disabled";
                Session["ID"] = GetResult[0].EmployeeID;
                ViewState["Photopath"] = GetResult[0].EmployeePhotoLocation;
                ViewState["EmpCategory"] = GetResult[0].EmployeeCatgeroyID;
                btnsave.Text = "UPDATE";
            }
        }

        protected void GvemployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvemployeeDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Int64 EmployeeID = Convert.ToInt64(ID.Text);
                    Editprofile(EmployeeID);
                    Response.Redirect("EmployeesMST.aspx", false);
                }
                if (e.CommandName == "Deletes")
                {
                    EmployeeData objemp = new EmployeeData();
                    EmployeeBO objempBO = new EmployeeBO();
                    objemp.ActionType = EnumActionType.Delete;
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvemployeeDetails.Rows[i];
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    Label lblID = (Label)gr.Cells[0].FindControl("lblID");
                    // txtremarks.Enabled = true;
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objemp.Remarks = txtremarks.Text;
                    }
                    objemp.EmployeeID = Convert.ToInt32(lblID.Text); ;
                    objemp.UserId = LoginToken.UserLoginId;
                    objemp.AcademicSessionID = LoginToken.AcademicSessionID;
                    int Result = objempBO.DeleteEmployeeDetailsByID(objemp);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                    bindresponsive();

                }

                if (e.CommandName == "View")
                {

                    EmployeeData objemp = new EmployeeData();
                    EmployeeBO objempBO = new EmployeeBO();
                    if (Convert.ToInt16(e.CommandArgument.ToString()) > 0)
                    {
                        Session["EmployeeID"] = Convert.ToInt16(e.CommandArgument.ToString());
                        Response.Redirect("~/EmpProfile.aspx", false);
                    }
                    else
                    {
                        Messagealert_.ShowMessage(lblmessage, "system", 0);

                    }

                }

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
            }
        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Employee List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Employee.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        protected DataTable GetDatafromDatabase()
        {
            int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<EmployeeData> empdetails = Getempdetailstoexcel(1, size);
            List<ExcelEmployeeList> listecelstd = new List<ExcelEmployeeList>();
            int i = 0;
            foreach (EmployeeData row in empdetails)
            {
                ExcelEmployeeList EcxeclStd = new ExcelEmployeeList();
                EcxeclStd.EmployeeNo = empdetails[i].EmployeeNo;
                EcxeclStd.EmployeeID = empdetails[i].EmployeeID;
                EcxeclStd.EmpName = empdetails[i].EmpName;
                EcxeclStd.DOB = empdetails[i].ExcelDOB;
                EcxeclStd.Gender = empdetails[i].SexName;
                EcxeclStd.Religion = empdetails[i].Religion;
                EcxeclStd.Address = empdetails[i].CurrentAddress;
                EcxeclStd.ContactNo = empdetails[i].MobileNo;
                EcxeclStd.BankName = empdetails[i].BankName;
                EcxeclStd.AccountNo = empdetails[i].AC;
                EcxeclStd.IFSC = empdetails[i].IFSC;
                listecelstd.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(listecelstd);
            return dt;

        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
        }
        public List<EmployeeData> Getempdetailstoexcel(int curIndex, int pagesize)
        {
            EmployeeData objstd = new EmployeeData();
            EmployeeBO objstdBO = new EmployeeBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            objstd.EmployeeID = Convert.ToInt64(txtemployeedID.Text == "" ? "0" : txtemployeedID.Text);
            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objstd.EmpName = txtempnames.Text.Trim();
            objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objstd.IsActiveALL = ddlstatus.SelectedValue;
            objstd.ActionType = EnumActionType.Select;
            objstd.PageSize = GvemployeeDetails.PageSize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.GetEmployeeListoexcel(objstd);
        }
        protected void GvEmployeeDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                bindgrid(1);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                {
                    string SortDir = string.Empty;
                    if (dir == SortDirection.Ascending)
                    {
                        dir = SortDirection.Descending;
                        SortDir = "Desc";
                    }
                    else
                    {
                        dir = SortDirection.Ascending;
                        SortDir = "Asc";
                    }
                    DataView sortedView = new DataView(dt);
                    sortedView.Sort = e.SortExpression + " " + SortDir;
                    GvemployeeDetails.DataSource = sortedView;
                    GvemployeeDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvemployeeDetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);


                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }

        }
        static public int GetColumnIndexByDBName(GridView aGridView, String ColumnText)
        {
            System.Web.UI.WebControls.BoundField DataColumn;
            for (int Index = 0; Index < aGridView.Columns.Count; Index++)
            {
                DataColumn = aGridView.Columns[Index] as System.Web.UI.WebControls.BoundField;
                if (DataColumn != null)
                {
                    if (DataColumn.DataField == ColumnText)
                        return Index;
                }
            }
            return -1;
        }
        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }
    }
}