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
    public partial class StdDetailsAssigner : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Ddls();
                divsearch.Visible = false;
                //btnUpdate.Attributes["disabled"] = "disabled";
            }
        }
        protected void Ddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            // Commonfunction.PopulateDdl(ddlGenderID, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlSectionID, mstlookup.GetLookupsList(LookupNames.Sectionlist));
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));
            //Commonfunction.PopulateDdl(ddlstream, mstlookup.GetLookupsList(LookupNames.Stream));
            // Commonfunction.PopulateDdl(ddlCategoryID, mstlookup.GetLookupsList(LookupNames.StudentCategory));
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
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue)));
            BindGrid(1);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
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
                btnUpdate.Attributes["disabled"] = "disabled";
                GvstudentDetails.Visible = true;
                GvstudentDetails.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvstudentDetails.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvstudentDetails.PageIndex = index - 1;
                GvstudentDetails.DataSource = result;
                GvstudentDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                GvstudentDetails.DataSource = null;
                GvstudentDetails.DataBind();
                GvstudentDetails.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<StudentData> GetStudentList(int curIndex, int pagesize)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            //objstd.StudentID = Convert.ToInt64(txtStudentID.Text.Trim() == "" ? "0" : txtStudentID.Text.Trim());
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objstd.RollNo = Convert.ToInt32(txtRollNo.Text == "" ? "0" : txtRollNo.Text);
            // objstd.SexID = Convert.ToInt32(ddlGenderID.SelectedValue == "" ? "0" : ddlGenderID.SelectedValue);
            // objstd.StudentCategory = Convert.ToInt32(ddlCategoryID.SelectedValue == "" ? "0" : ddlCategoryID.SelectedValue);
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.GetclasswisestudentIDDetails(objstd);
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        private void resetall()
        {
            //txtStudentID.Text = "";
            ddlClassID.SelectedIndex = 0;
            ddlSectionID.SelectedIndex = 0;
            txtRollNo.Text = "";
            //ddlCategoryID.SelectedIndex = 0;
            //ddlGenderID.SelectedIndex = 0;
            GvstudentDetails.Visible = false;
            btnUpdate.Visible = false;
            lblresult.Text = "";
            divsearch.Visible = false;
        }

        protected void GvstudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvstudentDetails.Rows)
            {
                try
                {
                    DropDownList ddlbloodGroups = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("ddlbloodgroup");

                    Label BloodGroups = (Label)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("lblbloodgroup");

                    DropDownList studenttype = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("ddlstudenttype");

                    Label studenttypeid = (Label)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("lblstudenttype");

                    DropDownList housetype = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("ddlhousetype");

                    Label housetypeid = (Label)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("lblhousetype");


                    MasterLookupBO mstlookup = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlbloodGroups, mstlookup.GetLookupsList(LookupNames.BloodGroup));
                    Commonfunction.PopulateDdl(studenttype, mstlookup.GetLookupsList(LookupNames.StudentType));
                    Commonfunction.PopulateDdl(housetype, mstlookup.GetLookupsList(LookupNames.House));

                    if (studenttypeid.Text != "0")
                    {
                        studenttype.Items.FindByValue(studenttypeid.Text).Selected = true;

                    }
                    if (BloodGroups.Text != "0")
                    {
                        ddlbloodGroups.Items.FindByValue(BloodGroups.Text).Selected = true;

                    }
                    if (housetypeid.Text != "0")
                    {
                        housetype.Items.FindByValue(housetypeid.Text).Selected = true;
                    }

                    TextBox StudentName = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[3].FindControl("lblname");
                    StudentName.Attributes["disabled"] = "disabled";
                    TextBox DOBS = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[5].FindControl("txtdob");
                    DOBS.Attributes["disabled"] = "disabled";
                    DropDownList dlbloodGrps = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("ddlbloodgroup");
                    dlbloodGrps.Attributes["disabled"] = "disabled";
                    DropDownList studenttypeID = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("ddlstudenttype");
                    studenttypeID.Attributes["disabled"] = "disabled";
                    DropDownList housetypeID = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("ddlhousetype");
                    housetypeID.Attributes["disabled"] = "disabled";
                    CheckBox chkbox = (CheckBox)GvstudentDetails.Rows[row.RowIndex].Cells[6].FindControl("chkbox");
                    chkbox.Checked = false;
                    TextBox fathername = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[7].FindControl("lblfatherno");
                    fathername.Attributes["disabled"] = "disabled";
                    TextBox mothername = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[8].FindControl("lblmotherno");
                    mothername.Attributes["disabled"] = "disabled";
                    TextBox mobilenos = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[9].FindControl("lblmobileno");
                    mobilenos.Attributes["disabled"] = "disabled";
                    TextBox Address = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[10].FindControl("lbladdress");
                    Address.Attributes["disabled"] = "disabled";

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
            int check = 0;
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            //int count = 0;
            try
            {
                //get all the record from the gridview
                foreach (GridViewRow row in GvstudentDetails.Rows)
                {
                    CheckBox chkbox = (CheckBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("chkbox");
                    if (chkbox.Checked == true)
                    {
                        IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                        String StudentID = GvstudentDetails.Rows[row.RowIndex].Cells[0].Text;
                        String ClassName = GvstudentDetails.Rows[row.RowIndex].Cells[1].Text;
                        String RollNo = GvstudentDetails.Rows[row.RowIndex].Cells[2].Text;
                        TextBox StudentName = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("lblname");
                        TextBox DOBOOO = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("txtdob");
                        TextBox FatherName = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("lblfatherno");
                        TextBox MotherName = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("lblmotherno");
                        TextBox MobileNumber = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("lblmobileno");
                        TextBox Address = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("lbladdress");
                        DropDownList ddlbloodgroup = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlbloodgroup");
                        DropDownList studenttype = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlstudenttype");
                        DropDownList housetype = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlhousetype");
                        DateTime DOB1 = DOBOOO.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(DOBOOO.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                        StudentData ObjDetails = new StudentData();
                        ObjDetails.StudentID = Convert.ToInt64(StudentID.Trim());
                        ObjDetails.ClassName = ClassName.Trim();
                        ObjDetails.RollNo = Convert.ToInt32(RollNo.Trim());
                        ObjDetails.StudentName = Convert.ToString(StudentName.Text);
                        ObjDetails.DOB = DOB1;
                        ObjDetails.House = Convert.ToString(housetype.Text == "" ? "0" : housetype.SelectedItem.Text);
                        ObjDetails.BloodGroup = Convert.ToString(ddlbloodgroup.SelectedIndex == 0 ? "0" : ddlbloodgroup.SelectedItem.Text);
                        ObjDetails.FatherName = Convert.ToString(FatherName.Text);
                        ObjDetails.MotherName = Convert.ToString(MotherName.Text);
                        ObjDetails.MobileNumber = Convert.ToString(MobileNumber.Text);
                        ObjDetails.Address = Convert.ToString(Address.Text);
                        ObjDetails.AddedBy = LoginToken.LoginId;

                        ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                        ObjDetails.HouseID = Convert.ToInt32(housetype.SelectedValue == "" ? "0" : housetype.SelectedValue);
                        ObjDetails.BloodGroupID = Convert.ToInt32(ddlbloodgroup.SelectedValue == "" ? "0" : ddlbloodgroup.SelectedValue);
                        ObjDetails.StudentTypeID = Convert.ToInt32(studenttype.SelectedValue == "" ? "0" : studenttype.SelectedValue);
                        lststudentlist.Add(ObjDetails);
                        check++;
                    }
                }

                objstd.XmlStudentlist = XmlConvertor.StudentIDDetailstoXML(lststudentlist).ToString();
                int results = objstdBO.UpdateStudentIDDetails(objstd);
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
        protected void GvstudentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    bindresponsive();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvstudentDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox StudentName = (TextBox)gr.Cells[1].FindControl("lblname");
                    StudentName.Attributes.Remove("disabled");
                    TextBox DOBS = (TextBox)gr.Cells[5].FindControl("txtdob");
                    DOBS.Attributes.Remove("disabled");
                    DropDownList dlbloodGrps = (DropDownList)gr.Cells[6].FindControl("ddlbloodgroup");
                    dlbloodGrps.Attributes.Remove("disabled");
                    DropDownList studenttype = (DropDownList)gr.Cells[6].FindControl("ddlstudenttype");
                    studenttype.Attributes.Remove("disabled");
                    DropDownList housetype = (DropDownList)gr.Cells[6].FindControl("ddlhousetype");
                    housetype.Attributes.Remove("disabled");
                    CheckBox chkbox = (CheckBox)gr.Cells[6].FindControl("chkbox");
                    chkbox.Checked = true;
                    TextBox fathername = (TextBox)gr.Cells[7].FindControl("lblfatherno");
                    fathername.Attributes.Remove("disabled");
                    TextBox mothername = (TextBox)gr.Cells[8].FindControl("lblmotherno");
                    mothername.Attributes.Remove("disabled");
                    TextBox mobilenos = (TextBox)gr.Cells[9].FindControl("lblmobileno");
                    mobilenos.Attributes.Remove("disabled");
                    TextBox Address = (TextBox)gr.Cells[10].FindControl("lbladdress");
                    Address.Attributes.Remove("disabled");

                    btnUpdate.Attributes.Remove("disabled");
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                return;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvstudentDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[13].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[14].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[15].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvstudentDetails.UseAccessibleHeader = true;
            GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvstudentDetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
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
                Response.AddHeader("content-disposition", "attachment;filename= Edited Details of Class :" + (ddlClassID.SelectedIndex == 0 ? "All" : ddlClassID.SelectedItem.Text) + " Section : " + (ddlSectionID.SelectedIndex == 0 ? "" : ddlSectionID.SelectedItem.Text) + ".xlsx");
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
            List<ExcelStdDetailsEditor> listecelstd = new List<ExcelStdDetailsEditor>();
            int i = 0;
            foreach (StudentData row in studentdetails)
            {
                ExcelStdDetailsEditor EcxeclStd = new ExcelStdDetailsEditor();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.FatherName = studentdetails[i].FatherName;
                EcxeclStd.Mothername = studentdetails[i].MotherName;
                EcxeclStd.StudentType = studentdetails[i].StudentType;
                EcxeclStd.House = studentdetails[i].House;
                EcxeclStd.DOB = Convert.ToString(studentdetails[i].DOB);
                EcxeclStd.BloodGroup = studentdetails[i].BloodGroup;
                EcxeclStd.ContactNo = studentdetails[i].MobileNumber;
                EcxeclStd.Address = studentdetails[i].Address;
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
        protected void GvstudentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvstudentDetails.PageIndex = e.NewPageIndex;
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
        protected void GvstudentDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvstudentDetails.DataSource = sortedView;
                    GvstudentDetails.DataBind();

                    TableCell tableCell = GvstudentDetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvstudentDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvstudentDetails.UseAccessibleHeader = true;
                    GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            //objstd.StudentID = Convert.ToInt64(txtStudentID.Text == "" ? "0" : txtStudentID.Text);
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            List<StudentData> stdetails = objstdBO.GetstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue)));
                //txtStudentID.Text = Convert.ToString(stdetails[0].StudentID);
                ddlClassID.SelectedValue = Convert.ToString(stdetails[0].ClassID);
            }
            else
            {
                //txtStudentID.Text = "";
                ddlClassID.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is not found.") + "')", true);
                //Messagealert_.ShowMessage(lblMessage, "This Student is not found.", 0);
                return;
            }
        }
        protected void ddlSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
    }
}