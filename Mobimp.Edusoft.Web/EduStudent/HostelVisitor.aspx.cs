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
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Campusoft.BussinessProcess.EduHostel;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Edusoft.Web.EduStudent
{
    public partial class HostelVisitor : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                divsearch.Visible = false;
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));
            ddlAcademicSessionID.SelectedIndex = 1;
            ddlstatus.SelectedIndex = 1;
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            StudentData objSTD = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetHostelStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStdNames(string prefixText, int count, string contextKey)
        {
            StudentData objemp = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objemp.StudentName = prefixText;
            getResult = objempBO.GetHostelStudentNames(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentName.ToString());
            }
            return list;
        }
        protected void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = Convert.ToInt64(txtStudentID.Text == "" ? "0" : txtStudentID.Text);
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            List<StudentData> stdetails = objstdBO.GetHostelStudentByID(objstd);
            if (stdetails.Count > 0)
            {
                txtStudentID.Text = Convert.ToString(stdetails[0].StudentID);
                txtStudentName.Text = Convert.ToString(stdetails[0].StudentName);
                ddlClassID.SelectedValue = Convert.ToString(stdetails[0].ClassID);
                txtRegdNo.Text = stdetails[0].RegistrationNo.ToString();
                hdnclassID.Value = stdetails[0].ClassID.ToString();
            }
            else
            {
                txtStudentID.Text = "";
                txtStudentName.Text = "";
                ddlClassID.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is not found.") + "')", true);
                //Messagealert_.ShowMessage(lblMessage, "This Student is not found.", 0);
                return;
            }
        }
        protected void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentName = Convert.ToString(txtStudentName.Text.Trim() == "" ? "0" : txtStudentName.Text.Trim());
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            List<StudentData> stdetails = objstdBO.GetHostelStudentByName(objstd);
            if (stdetails.Count > 0)
            {
                txtStudentID.Text = Convert.ToString(stdetails[0].StudentID);
                txtStudentName.Text = Convert.ToString(stdetails[0].StudentName);
                ddlClassID.SelectedValue = Convert.ToString(stdetails[0].ClassID);
                txtRegdNo.Text = stdetails[0].RegistrationNo.ToString();
                hdnclassID.Value = stdetails[0].ClassID.ToString();
            }
            else
            {
                txtStudentID.Text = "";
                txtStudentName.Text = "";
                ddlClassID.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is not found.") + "')", true);
                //Messagealert_.ShowMessage(lblMessage, "This Student is not found.", 0);
                return;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HostelVisitorData objreg = new HostelVisitorData();
                HostelVisitorBO objHostelRegistrationBO = new HostelVisitorBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime VisitDate = txtvisitdate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtvisitdate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objreg.VisitDate = VisitDate;
                objreg.StudentID = Convert.ToInt32(txtStudentID.Text == "" ? "0" : txtStudentID.Text);
                objreg.RegistrationNo = Convert.ToInt32(txtRegdNo.Text == "" ? "0" : txtRegdNo.Text);
                objreg.ClassID = Convert.ToInt32(hdnclassID.Value);
                objreg.VisitorName = txtvisitname.Text == "" ? "0" : txtvisitname.Text.Trim();
                objreg.VisitPurpose = txtpurpose.Text == "" ? "0" : txtpurpose.Text.Trim();
                objreg.VisitTime = txtvisittime.Text == "" ? "0" : txtvisittime.Text.Trim();
                objreg.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
                objreg.AddedBy = LoginToken.LoginId;
                objreg.UserId = LoginToken.UserLoginId; ;
                objreg.CompanyID = LoginToken.CompanyID;
                objreg.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue); ;
                objreg.ActionType = EnumActionType.Insert;
                int result = objHostelRegistrationBO.UpdateHostelVisitor(objreg);
                if (result == 1 || result == 2)
                {
                    clearall();
                    BindGrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    //Messagealert_.ShowMessage(lblMessage, result == 1 ? "save" : "update", 1);
                    ViewState["ID"] = null;
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("register") + "')", true);
                    //Messagealert_.ShowMessage(lblMessage, "register", 0);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    //Messagealert_.ShowMessage(lblMessage, "system", 0);
                }

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        private void BindGrid(int index)
        {
            HostelVisitorData objstd = new HostelVisitorData();
            HostelVisitorBO objstdBO = new HostelVisitorBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<HostelVisitorData> result = GetStudentList(index, pagesize);
            if (result.Count > 0)
            {
                GvHostelVisit.Visible = true;
                GvHostelVisit.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvHostelVisit.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvHostelVisit.PageIndex = index - 1;
                GvHostelVisit.DataSource = result;
                GvHostelVisit.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                GvHostelVisit.DataSource = null;
                GvHostelVisit.DataBind();
                GvHostelVisit.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<HostelVisitorData> GetStudentList(int curIndex, int pagesize)
        {
            HostelVisitorData objreg = new HostelVisitorData();
            HostelVisitorBO objFeeBO = new HostelVisitorBO();
            objreg.StudentID = Convert.ToInt64(txtStudentID.Text == "" ? "0" : txtStudentID.Text);
            objreg.StudentName = txtStudentName.Text.Trim() == "" ? "0" : txtStudentName.Text.Trim();
            objreg.RegistrationNo = Convert.ToInt64(txtRegdNo.Text == "" ? "0" : txtRegdNo.Text);
            objreg.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objreg.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objreg.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objreg.PageSize = pagesize;
            objreg.CurrentIndex = curIndex;
            return objFeeBO.SearchHostelVisitor(objreg);
        }
        private void clearall()
        {
            bindddl();
            txtRegdNo.Text = "";
            txtStudentID.Text = "";
            ddlClassID.SelectedIndex = 0;
            txtvisitname.Text = "";
            txtpurpose.Text = "";
            txtvisitdate.Text = "";
            txtvisittime.Text = "";
            lblMessage.Text = "";
            lblMessage.Visible = false;
            GvHostelVisit.DataSource = null;
            GvHostelVisit.DataBind();
            GvHostelVisit.Visible = false;
            txtStudentName.Text = "";
            lblresult.Text = "";
            lblresult.Visible = false;
            divsearch.Visible = false;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            clearall();
        }
        protected void GvHostelVisit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvHostelVisit.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvHostelVisit_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvHostelVisit.DataSource = sortedView;
                    GvHostelVisit.DataBind();

                    TableCell tableCell = GvHostelVisit.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvHostelVisit.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvHostelVisit.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvHostelVisit.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvHostelVisit.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvHostelVisit.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvHostelVisit.UseAccessibleHeader = true;
                    GvHostelVisit.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvHostelVisit.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvHostelVisit.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvHostelVisit.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvHostelVisit.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[13].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[14].Attributes["data-hide"] = "phone,tablet";
            //GvHostelVisit.HeaderRow.Cells[15].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvHostelVisit.UseAccessibleHeader = true;
            GvHostelVisit.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvHostelVisit.HeaderRow.Cells[0];
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
                Response.AddHeader("content-disposition", "attachment;filename= Visitor List of Class :" + (ddlClassID.SelectedIndex == 0 ? "All" : ddlClassID.SelectedItem.Text) + ".xlsx");
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
            List<HostelVisitorData> studentdetails = GetStudentList(1, size);
            List<ExcelHostelVisitor> listecelstd = new List<ExcelHostelVisitor>();
            int i = 0;
            foreach (HostelVisitorData row in studentdetails)
            {
                ExcelHostelVisitor EcxeclStd = new ExcelHostelVisitor();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.RegdNo = studentdetails[i].RegistrationNo;
                EcxeclStd.Category = studentdetails[i].CategoryName;
                EcxeclStd.Gender = studentdetails[i].Gender;
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.FatherName = studentdetails[i].FatherName;
                EcxeclStd.MotherName = studentdetails[i].MotherName;
                EcxeclStd.Address = studentdetails[i].Address;
                EcxeclStd.Contact = studentdetails[i].Contact;
                EcxeclStd.VisitorName = studentdetails[i].VisitorName;
                EcxeclStd.PurposeOfVisit = studentdetails[i].VisitPurpose;
                EcxeclStd.DateOfVisit = studentdetails[i].VisitDate.ToString("dd/MM/yyyy");
                EcxeclStd.TimeOfVisit = studentdetails[i].VisitTime;
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