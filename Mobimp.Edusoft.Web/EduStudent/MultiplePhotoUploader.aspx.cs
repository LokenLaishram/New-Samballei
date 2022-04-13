using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.IO;

namespace Mobimp.Campusoft.Web.EduStudent
{
    public partial class MultiplePhotoUploader : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddls();
            }
        }
        protected void Ddls()
        {
              MasterLookupBO mstlookup = new MasterLookupBO();
             Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Sectionlist));
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlcategorys, mstlookup.GetLookupsList(LookupNames.StudentCategory));

        }
        protected void Gvstudenlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in Gvstudenlist.Rows)
            {
                try
                {
                    DropDownList ddlaltsubject = (DropDownList)Gvstudenlist.Rows[row.RowIndex].Cells[3].FindControl("ddlaltsubject");
                    DropDownList ddloptionalsubject = (DropDownList)Gvstudenlist.Rows[row.RowIndex].Cells[3].FindControl("ddloptionalsubject");

                    MasterLookupBO objmstlookupBO = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlaltsubject, objmstlookupBO.GetAltSubjectByClassID(Convert.ToInt32(ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue)));
                   // Commonfunction.PopulateDdl(ddloptionalsubject, objmstlookupBO.GetOptSubjectByClassID(Convert.ToInt32(ddlclasses.SelectedValue)));


                    Label AltSubjectID = (Label)Gvstudenlist.Rows[row.RowIndex].Cells[0].FindControl("lblaltsubject");
                    Label OptSubjectID = (Label)Gvstudenlist.Rows[row.RowIndex].Cells[0].FindControl("lbloptional");
                    if (AltSubjectID.Text != "0")
                    {
                        ddlaltsubject.Items.FindByValue(AltSubjectID.Text).Selected = true;
                    }
                    if (OptSubjectID.Text != "0")
                    {
                        ddloptionalsubject.Items.FindByValue(OptSubjectID.Text).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<StudentData> lststudentlist = new List<StudentData>();
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            // int index = 0;

            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in Gvstudenlist.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label StudentID = (Label)Gvstudenlist.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    Label rollno = (Label)Gvstudenlist.Rows[row.RowIndex].Cells[1].FindControl("lblrollno");
                    Label SectionID = (Label)Gvstudenlist.Rows[row.RowIndex].Cells[1].FindControl("lblsectionID");
                    Label ClassID = (Label)Gvstudenlist.Rows[row.RowIndex].Cells[1].FindControl("lblclassIDs");
                    FileUpload studentphotouploader = (FileUpload)Gvstudenlist.Rows[row.RowIndex].Cells[6].FindControl("studentphotouploader");


                    StudentData ObjDetails = new StudentData();
                    string fileName = studentphotouploader.FileName.ToString();
                    if (fileName == "")
                    {
                        objstd.StudentPhoto = "../EduImages/EmpDummyPh.jpg";
                        objstd.StudentImage = null;
                    }
                    else
                    {
                        if (!studentphotouploader.HasFile)
                        {
                            Messagealert_.ShowMessage(lblmesagestudentlist, "system", 0);
                            return;
                        }
                        else
                        {
                            //Photo Path
                            if (Directory.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/") == false)
                                Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduStudentPhoto/");

                            if (File.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName))
                            {
                                File.Delete(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                                // return "exist";
                            }
                            studentphotouploader.SaveAs(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                            string path = @"EduStudentPhoto/" + fileName;


                            ObjDetails.StudentPhoto = path;
                            //imageuploader as bit image
                            int length = studentphotouploader.PostedFile.ContentLength;
                            //create a byte array to store the binary image data
                            byte[] imgbyte = new byte[length];
                            //store the currently selected file in memeory
                            HttpPostedFile img = studentphotouploader.PostedFile;
                            //set the binary data
                            img.InputStream.Read(imgbyte, 0, length);
                            ObjDetails.StudentImage = imgbyte;

                            if (path == "fail" || objstd.StudentPhoto == "")
                            {
                                Messagealert_.ShowMessage(lblmesagestudentlist, "system", 0);
                                return;
                            }
                        }
                    }

                    ObjDetails.StudentID = Convert.ToInt32(StudentID.Text);
                    ObjDetails.RollNo = Convert.ToInt32(rollno.Text);
                    ObjDetails.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    ObjDetails.AddedBy = LoginToken.LoginId;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                    lststudentlist.Add(ObjDetails);
                }
                objstd.XmlPhotolist = XmlConvertor.StudentPhototoXML(lststudentlist).ToString();
                int results = objstdBO.UpLoadStudentPhoto(objstd);
                if (results == 1)
                {
                    GetStudentlist();
                    // btnupdate.Enabled = false;
                    Messagealert_.ShowMessage(lblresult, "update", 1);
                }
                else
                {
                    // btnupdate.Enabled = true;
                    Messagealert_.ShowMessage(lblresult, "Error", 0);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblresult.Text = ExceptionMessage.GetMessage(ex);
                lblresult.Visible = true;
                lblresult.CssClass = "Message";
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            StudentData objSTD = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        private void resetall()
        {
           // txtstudentanme.Text = "";
            //txtstudentIDs.Text = "";
           // ddlsexs.SelectedIndex = 0;
            ddlclasses.SelectedIndex = 0;
            lblmesagestudentlist.Visible = false;
            ddlsections.SelectedIndex = 0;
            Gvstudenlist.DataSource = null;
            Gvstudenlist.DataBind();
            Gvstudenlist.Visible = false;
            lblresult.Visible = false;
            ddlcategorys.SelectedIndex = 0;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclasses.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GetStudentlist();
        }
        protected void GetStudentlist()
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            //objstd.StudentID = Convert.ToInt64(txtstudentIDs.Text == "" ? "0" : txtstudentIDs.Text);
            //if (ddlsearch.SelectedIndex == 1)
            //{
            //    objstd.Sfirstname = txtstudentanme.Text.Trim();
            //}
            //if (ddlsearch.SelectedIndex == 2)
            //{
            //    objstd.Smiddlename = txtstudentanme.Text;
            //}
            //if (ddlsearch.SelectedIndex == 3)
            //{
            //    objstd.Slastname = txtstudentanme.Text;
            //}

            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            //objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objstd.RollNo = Convert.ToInt32(txtrollno.Text == "" ? "0" : txtrollno.Text);
            objstd.StudentCategory = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
            objstd.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            List<StudentData> result = objstdBO.GetclassstudentPhotolist(objstd);
            if (result.Count > 0)
            {
                Gvstudenlist.DataSource = result;
                Gvstudenlist.DataBind();
                Gvstudenlist.Visible = true;
                //btnupdate.Enabled = true;
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lblresult.CssClass = "MsgSuccess";
                lblresult.Visible = true;
            }
            else
            {
                Gvstudenlist.DataSource = null;
                Gvstudenlist.DataBind();
                Gvstudenlist.Visible = true;
                // btnupdate.Enabled = false;
               ;
                lblresult.CssClass = "Message";
                lblresult.Visible = true;
            }

        }

        protected void Gvstudenlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Upload")
                {
                    StudentData objstdphoto = new StudentData();
                    AddstudentBO objempBO = new AddstudentBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvstudenlist.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Label RollNo = (Label)gr.Cells[0].FindControl("lblrollno");
                    Label SectionID = (Label)gr.Cells[0].FindControl("lblsectionID");
                    Label ClassID = (Label)gr.Cells[0].FindControl("lblclassIDs");
                    FileUpload studentphotouploader = (FileUpload)gr.Cells[6].FindControl("studentphotouploader");
                    string fileName = studentphotouploader.FileName.ToString();
                    if (fileName != "")
                    {
                        if (Directory.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/") == false)
                            Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduStudentPhoto/");

                        if (File.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName))
                        {
                            File.Delete(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                            // return "exist";
                        }
                        studentphotouploader.SaveAs(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                        string path = @"EduStudentPhoto/" + fileName;


                        objstdphoto.StudentPhoto = path;
                        //imageuploader as bit image
                        int length = studentphotouploader.PostedFile.ContentLength;
                        //create a byte array to store the binary image data
                        byte[] imgbyte = new byte[length];
                        //store the currently selected file in memeory
                        HttpPostedFile img = studentphotouploader.PostedFile;
                        //set the binary data
                        img.InputStream.Read(imgbyte, 0, length);
                        objstdphoto.StudentImage = imgbyte;

                        objstdphoto.StudentID = Convert.ToInt64(ID.Text);
                        objstdphoto.RollNo = Convert.ToInt32(RollNo.Text);
                        objstdphoto.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
                        objstdphoto.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
              
                        int results = objempBO.UpLoadStudentPhoto(objstdphoto);
                        if (results == 1)
                        {
                             GetStudentlist();
                            // btnupdate.Enabled = false;
                            Messagealert_.ShowMessage(lblresult, "Uploaded Successfully", 1);
                        }
                        else
                        {
                            // btnupdate.Enabled = true;
                            Messagealert_.ShowMessage(lblresult, "Error", 0);
                        }




                    }
                
                
                
                }


            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblresult.Text = ExceptionMessage.GetMessage(ex);
                lblresult.Visible = true;
                lblresult.CssClass = "Message";
            }

        }
        protected void ddlcategorys_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlclasses.SelectedIndex = 0;
            ddlsections.SelectedIndex = 0;

        }
    }
}