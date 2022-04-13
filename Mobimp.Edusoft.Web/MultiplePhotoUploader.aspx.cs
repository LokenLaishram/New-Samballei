using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Edusoft.Web
{
    public partial class MultiplePhotoUploader : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddls();
                divsearch.Visible = false;
            }
        }

        protected void Ddls()
        {
            //ddlsearch.SelectedIndex = 1;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(ddlSectionID);
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

        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClassID.SelectedIndex > 0)
            {

                ddlSectionID.Attributes.Remove("disabled");
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            }
            else
            {
                ddlSectionID.SelectedIndex = 0;
                ddlSectionID.Attributes["disabled"] = "disabled";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            int index = 0;

            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvStudentPhotoDetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    String StudentID = GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].Text.Trim();
                    Label SectionID = (Label)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].FindControl("lblsectionID");
                    Label ClassID = (Label)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].FindControl("lblclassIDs");
                    String rollno = GvStudentPhotoDetails.Rows[row.RowIndex].Cells[4].Text.Trim();
                    CheckBox chkstatus = (CheckBox)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].FindControl("chkstatus");
                    CheckBox UploadStatus = (CheckBox)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].FindControl("chkuploadstatus");
                    StudentData ObjDetails = new StudentData();

                    string fileName = StudentID + ".jpg";
                    if (chkstatus.Checked)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(GlobalConstant.multifoto + "/" + fileName);
                        Byte[] image = imageToByteArray(img);
                        ObjDetails.StudentImage = image;
                        ObjDetails.IsPhotoUploaded = true;

                    }
                    else
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/EduImages/EmpDummyPh.png"));
                        Byte[] image = imageToByteArray(img);
                        ObjDetails.StudentImage = image;
                        ObjDetails.IsPhotoUploaded = false;

                    }
                    ObjDetails.StudentID = Convert.ToInt32(StudentID);
                    ObjDetails.RollNo = Convert.ToInt32(rollno);
                    ObjDetails.SectionID = Convert.ToInt32(SectionID.Text.Trim() == "" ? "0" : SectionID.Text.Trim());
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text.Trim() == "" ? "0" : ClassID.Text.Trim());
                    ObjDetails.AddedBy = LoginToken.LoginId;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                    if (!UploadStatus.Checked || chkstatus.Checked)
                    {
                        int results = objstdBO.UpLoadStudentPhoto(ObjDetails);
                        if (results == 1)
                        {
                            BindGrid(1);
                            btnUpdate.Attributes.Remove("disabled");
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("upload") + "')", true);
                        }
                        else
                        {
                            btnUpdate.Attributes.Remove("disabled");
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Not Upload") + "')", true);
                        }
                        index++;
                    }
                    else
                    {
                        BindGrid(1);
                    }
                }

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        private void resetall()
        {
            ddlClassID.SelectedIndex = 0;
            ddlSectionID.SelectedIndex = 0;
            txtRollNo.Text = "";
            GvStudentPhotoDetails.DataSource = null;
            GvStudentPhotoDetails.DataBind();
            GvStudentPhotoDetails.Visible = false;
            lblresult.Visible = false;
            divsearch.Visible = false;
            Commonfunction.Insertzeroitemindex(ddlSectionID);
        }
        private bool FileExists(string rootpath, string filename)
        {
            if (File.Exists(Path.Combine(rootpath, filename)))
                return true;

            foreach (string subDir in Directory.GetDirectories(rootpath, "*", SearchOption.AllDirectories))
            {
                if (File.Exists(Path.Combine(subDir, filename)))
                    return true;
            }

            return false;
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {

            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        //protected void GvStudentPhotoDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "Upload")
        //        {
        //            StudentData objstdphoto = new StudentData();
        //            AddstudentBO objempBO = new AddstudentBO();
        //            int i = Convert.ToInt16(e.CommandArgument.ToString());
        //            GridViewRow gr = GvStudentPhotoDetails.Rows[i];
        //            Label ID = (Label)gr.Cells[0].FindControl("lblID");
        //            Label RollNo = (Label)gr.Cells[0].FindControl("lblrollno");
        //            Label SectionID = (Label)gr.Cells[0].FindControl("lblsectionID");
        //            Label ClassID = (Label)gr.Cells[0].FindControl("lblclassIDs");
        //            FileUpload studentphotouploader = (FileUpload)gr.Cells[6].FindControl("studentphotouploader");
        //            string fileName = studentphotouploader.FileName.ToString();
        //            if (fileName != "")
        //            {
        //                if (Directory.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/") == false)
        //                    Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduStudentPhoto/");

        //                if (File.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName))
        //                {
        //                    File.Delete(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
        //                    // return "exist";
        //                }
        //                studentphotouploader.SaveAs(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
        //                string path = @"EduStudentPhoto/" + fileName;


        //                objstdphoto.StudentPhoto = path;
        //                //imageuploader as bit image
        //                int length = studentphotouploader.PostedFile.ContentLength;
        //                //create a byte array to store the binary image data
        //                byte[] imgbyte = new byte[length];
        //                //store the currently selected file in memeory
        //                HttpPostedFile img = studentphotouploader.PostedFile;
        //                //set the binary data
        //                img.InputStream.Read(imgbyte, 0, length);
        //                objstdphoto.StudentImage = imgbyte;

        //                objstdphoto.StudentID = Convert.ToInt64(ID.Text);
        //                objstdphoto.RollNo = Convert.ToInt32(RollNo.Text);
        //                objstdphoto.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
        //                objstdphoto.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);

        //                int results = objempBO.UpLoadStudentPhoto(objstdphoto);
        //                if (results == 1)
        //                {
        //                    GetStudentlist();
        //                    // btnupdate.Enabled = false;
        //                    Messagealert_.ShowMessage(lblresult, "Uploaded Successfully", 1);
        //                }
        //                else
        //                {
        //                    // btnupdate.Enabled = true;
        //                    Messagealert_.ShowMessage(lblresult, "Error", 0);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex) //Exception in agent layer itself
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        lblresult.Text = ExceptionMessage.GetMessage(ex);
        //        lblresult.Visible = true;
        //        lblresult.CssClass = "Message";
        //    }

        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        private void BindGrid(int index)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StudentData> result = GetStudentList(index, pagesize);
            if (result.Count > 0)
            {
                btnUpdate.Visible = true;
                btnUpdate.Attributes.Remove("disabled");
                GvStudentPhotoDetails.Visible = true;
                GvStudentPhotoDetails.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvStudentPhotoDetails.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvStudentPhotoDetails.PageIndex = index - 1;
                GvStudentPhotoDetails.DataSource = result;
                GvStudentPhotoDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                GvStudentPhotoDetails.DataSource = null;
                GvStudentPhotoDetails.DataBind();
                GvStudentPhotoDetails.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }

        public List<StudentData> GetStudentList(int curIndex, int pagesize)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = 0;
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            //objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objstd.RollNo = Convert.ToInt32(txtRollNo.Text == "" ? "0" : txtRollNo.Text);
            //objstd.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.GetclassstudentPhotolist(objstd);
        }

        protected void GvStudentPhotoDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            List<LookupItem> looksection = objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue));
            foreach (GridViewRow row in GvStudentPhotoDetails.Rows)
            {
                try
                {
                    //DropDownList ddlsection = (DropDownList)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[3].FindControl("ddlsections");
                    //Commonfunction.PopulateDdl(ddlsection, looksection);
                    String StudentID = GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].Text;
                    CheckBox chkstatus = (CheckBox)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].FindControl("chkstatus");
                    CheckBox chkupload = (CheckBox)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].FindControl("chkuploadstatus");
                    Label uploadstatus = (Label)GvStudentPhotoDetails.Rows[row.RowIndex].Cells[0].FindControl("lbluploadstatus");

                    string fileName = StudentID.Trim() + ".jpg";
                    string path = GlobalConstant.multifoto;

                    if (File.Exists(Path.Combine(path, fileName)) == true)
                    {
                        chkstatus.Checked = true;
                    }
                    else
                    {
                        chkstatus.Checked = false;
                    }

                    if (uploadstatus.Text == "True")
                    {
                        chkupload.Checked = true;
                    }
                    else
                    {
                        chkupload.Checked = false;
                    }

                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }

        protected void GvStudentPhotoDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                BindGrid(1);
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
                    GvStudentPhotoDetails.DataSource = sortedView;
                    GvStudentPhotoDetails.DataBind();

                    TableCell tableCell = GvStudentPhotoDetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvStudentPhotoDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvStudentPhotoDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvStudentPhotoDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvStudentPhotoDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvStudentPhotoDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GvStudentPhotoDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GvStudentPhotoDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvStudentPhotoDetails.UseAccessibleHeader = true;
                    GvStudentPhotoDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GvStudentPhotoDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvStudentPhotoDetails.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void bindresponsive()
        {
            //Responsive 
            GvStudentPhotoDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvStudentPhotoDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvStudentPhotoDetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvStudentPhotoDetails.UseAccessibleHeader = true;
            GvStudentPhotoDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvStudentPhotoDetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
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
                wb.Worksheets.Add(dt, "Student List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Photo Upload Status for Class :" + (ddlClassID.SelectedIndex == 0 ? "All" : ddlClassID.SelectedItem.Text) + " Section : " + (ddlSectionID.SelectedIndex == 0 ? "" : ddlSectionID.SelectedItem.Text) + ".xlsx");
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
            List<StudentData> studentdetails = GetStudentList(1, size);
            List<ExcelUploadPhoto> listecelstd = new List<ExcelUploadPhoto>();
            int i = 0;
            foreach (StudentData row in studentdetails)
            {
                ExcelUploadPhoto EcxeclStd = new ExcelUploadPhoto();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.Status = Convert.ToString(studentdetails[i].IsPhotoUploaded == true ? "Uploaded" : "Not Uploaded");
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

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = 0;
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            List<StudentData> stdetails = objstdBO.GetstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                ddlSectionID.Attributes.Remove("disabled");
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                ddlClassID.SelectedValue = Convert.ToString(stdetails[0].ClassID);
            }
            else
            {
                ddlClassID.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is not found.") + "')", true);
                //Messagealert_.ShowMessage(lblMessage, "This Student is not found.", 0);
                return;
            }
        }
    }
}