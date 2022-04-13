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

namespace Mobimp.Edusoft.Web.EduStudent
{
    public partial class ClassIX_X_SubjectSetting : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                Ddls();
            }
        }
        protected void Ddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.ClassX));
            Commonfunction.Insertzeroitemindex(ddlSectionID);
            Commonfunction.Insertzeroitemindex(ddlOptSubject);
            Commonfunction.Insertzeroitemindex(ddlAltSubject);
        }
        protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            Commonfunction.PopulateDdl(ddlAltSubject, objmstlookupBO.GetAltSubjectByClassID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            Commonfunction.PopulateDdl(ddlOptSubject, objmstlookupBO.GetOptSubjectByClassID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            BindGrid(1);
        }
        protected void ddlSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStdNames(string prefixText, int count, string contextKey)
        {
            StudentData objemp = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objemp.StudentName = prefixText;
            getResult = objempBO.GetStudentNames(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentName.ToString());
            }
            return list;
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
        protected void ddlMainSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOptSubject.SelectedIndex = 0;
            ddlAltSubject.SelectedIndex = 0;
        }
        protected void ddlOptSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAltSubject.SelectedIndex = 0;
            BindGrid(1);
        }
        protected void ddlAltSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOptSubject.SelectedIndex = 0;
            BindGrid(1);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void BindGrid(int index)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StudentData> result = GetStudentList(index, pagesize);
            if (result.Count > 0)
            {
                btnUpdate.Visible = true;
                btnUpdate.Attributes.Remove("disabled");
                GvStudentSubjectDetails.Visible = true;
                GvStudentSubjectDetails.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvStudentSubjectDetails.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvStudentSubjectDetails.PageIndex = index - 1;
                GvStudentSubjectDetails.DataSource = result;
                GvStudentSubjectDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                GvStudentSubjectDetails.DataSource = null;
                GvStudentSubjectDetails.DataBind();
                GvStudentSubjectDetails.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<StudentData> GetStudentList(int curIndex, int pagesize)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objstd.OptSubjectID = Convert.ToInt32(ddlOptSubject.SelectedValue == "" ? "0" : ddlOptSubject.SelectedValue);
            objstd.AltSubjectID = Convert.ToInt32(ddlAltSubject.SelectedValue == "" ? "0" : ddlAltSubject.SelectedValue);
            objstd.RollNo = Convert.ToInt32(txtRollNo.Text == "" ? "0" : txtRollNo.Text);
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.Getclass910tudentlist(objstd);
        }
        protected void GvStudentSubjectDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvStudentSubjectDetails.Rows)
            {
                try
                {
                    DropDownList ddloptionalsubject = (DropDownList)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[5].FindControl("ddloptionalsubject");
                    DropDownList ddlaltsubject = (DropDownList)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[6].FindControl("ddlaltsubject");
                    //DropDownList ddlmainsubject = (DropDownList)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[8].FindControl("ddlmainsubject");

                    MasterLookupBO objmstlookupBO = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddloptionalsubject, objmstlookupBO.GetOptSubjectByClassID(Convert.ToInt32(ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue)));
                    Commonfunction.PopulateDdl(ddlaltsubject, objmstlookupBO.GetAltSubjectByClassID(Convert.ToInt32(ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue)));
                    //Commonfunction.PopulateDdl(ddlmainsubject, objmstlookupBO.GetMainSubjectByClassID(Convert.ToInt32(ddlClassID.SelectedValue)));

                    Label OptSubjectID = (Label)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[5].FindControl("lbloptional");
                    Label AltSubjectID = (Label)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[6].FindControl("lblaltsubject");
                    //  Label MainSubjectID = (Label)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[8].FindControl("lblmainsubject");

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
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }
        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            List<StudentData> lststudentlist = new List<StudentData>();
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            // int index = 0;
            bindresponsive();
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvStudentSubjectDetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    String StudentID = GvStudentSubjectDetails.Rows[row.RowIndex].Cells[0].Text.Trim();
                    String RollNo = GvStudentSubjectDetails.Rows[row.RowIndex].Cells[4].Text.Trim();
                    Label SectionID = (Label)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[1].FindControl("lblSectionID");
                    Label ClassID = (Label)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[1].FindControl("lblClassID");

                   // DropDownList MainSubjectID = (DropDownList)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[3].FindControl("ddlmainsubject");
                    DropDownList AltSubjectID = (DropDownList)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[3].FindControl("ddlaltsubject");
                    DropDownList OptSubjectID = (DropDownList)GvStudentSubjectDetails.Rows[row.RowIndex].Cells[3].FindControl("ddloptionalsubject");

                    StudentData ObjDetails = new StudentData();
                    ObjDetails.StudentID = Convert.ToInt32(StudentID);
                    ObjDetails.RollNo = Convert.ToInt32(RollNo);
                    ObjDetails.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    //ObjDetails.MainSubjectID = Convert.ToInt32(MainSubjectID.SelectedValue == "" ? "0" : MainSubjectID.SelectedValue);
                    ObjDetails.OptSubjectID = Convert.ToInt32(OptSubjectID.SelectedValue == "" ? "0" : OptSubjectID.SelectedValue);
                    ObjDetails.AltSubjectID = Convert.ToInt32(AltSubjectID.SelectedValue == "" ? "0" : AltSubjectID.SelectedValue);
                    ObjDetails.AddedBy = LoginToken.LoginId;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                    lststudentlist.Add(ObjDetails);
                }
                objstd.XmlSubjectlist = XmlConvertor.StudentSubjectListtoXML(lststudentlist).ToString();
                int results = objstdBO.UpdateSubjects(objstd);
                if (results == 1)
                {
                    BindGrid(1);
                    btnUpdate.Attributes["disabled"] = "disabled";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
                else
                {
                    btnUpdate.Attributes.Remove("disabled");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Error") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        private void resetall()
        {
            ddlClassID.SelectedIndex = 0;
            ddlSectionID.SelectedIndex = 0;
            txtRollNo.Text = "";
            divsearch.Visible = false;
            lblmessage.Visible = false;
            lblresult.Visible = false;
            Commonfunction.Insertzeroitemindex(ddlSectionID);
            Commonfunction.Insertzeroitemindex(ddlOptSubject);
            Commonfunction.Insertzeroitemindex(ddlAltSubject);
            GvStudentSubjectDetails.DataSource = null;
            GvStudentSubjectDetails.DataBind();
            GvStudentSubjectDetails.Visible = false;
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
        protected void bindresponsive()
        {
            //Responsive 
            GvStudentSubjectDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvStudentSubjectDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvStudentSubjectDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvStudentSubjectDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvStudentSubjectDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvStudentSubjectDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvStudentSubjectDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvStudentSubjectDetails.UseAccessibleHeader = true;
            GvStudentSubjectDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvStudentSubjectDetails.HeaderRow.Cells[0];
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
                Response.AddHeader("content-disposition", "attachment;filename= StudentList :" + (ddlClassID.SelectedIndex == 0 ? "All" : ddlClassID.SelectedItem.Text) + " Section : " + (ddlSectionID.SelectedIndex == 0 ? "" : ddlSectionID.SelectedItem.Text) + ".xlsx");
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
            List<ExcelSubjectManager> listecelstd = new List<ExcelSubjectManager>();
            int i = 0;
            foreach (StudentData row in studentdetails)
            {
                ExcelSubjectManager EcxeclStd = new ExcelSubjectManager();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.Alternative1 = studentdetails[i].OptSubjectName;
                EcxeclStd.Alternative2 = studentdetails[i].AltSubjectName;
                EcxeclStd.Alternative3 = studentdetails[i].MainSubjectName;
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void GvStudentSubjectDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvStudentSubjectDetails.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
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
        protected void GvStudentSubjectDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvStudentSubjectDetails.DataSource = sortedView;
                    GvStudentSubjectDetails.DataBind();

                    TableCell tableCell = GvStudentSubjectDetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvStudentSubjectDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvStudentSubjectDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvStudentSubjectDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvStudentSubjectDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvStudentSubjectDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvStudentSubjectDetails.UseAccessibleHeader = true;
                    GvStudentSubjectDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

    
    }
}