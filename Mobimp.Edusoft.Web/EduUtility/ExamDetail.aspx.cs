using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Campusoft.Web.EduUtility
{
    public partial class ExamDetail : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                BindDlls();
                //bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlexamtype, mstlookup.GetLookupsList(LookupNames.ExamNames));
            Commonfunction.PopulateDdl(ddlacademic, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademic.SelectedIndex = 1;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void bindgrid()//int index)
        {
            // int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<Examdata> lstsubject = getSubjectdetails(0);// index,pagesize);
            if (lstsubject.Count > 0)
            {
                //GvExamdetails.PageSize = pagesize;
                string record = lstsubject.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstsubject.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstsubject.Count.ToString();
                lbltotalmark.Text = lstsubject[0].FullMark.ToString();
                lblpassmark.Text = lstsubject[0].PassMark.ToString();
                lblresult.Visible = true;
                btnUpdate.Attributes.Remove("disabled");
                divsearch.Visible = true;
                //GvExamdetails.VirtualItemCount = lstsubject[0].MaximumRows;//total item is required for custom paging
                //GvExamdetails.PageIndex = index - 1;
                GvExamdetails.DataSource = lstsubject;
                GvExamdetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(lstsubject);
                bindgridfoucs();
            }
            else
            {
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
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
        protected void bindresponsive()
        {
            //Responsive 
            GvExamdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvExamdetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvExamdetails.UseAccessibleHeader = true;
            GvExamdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvExamdetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        public List<Examdata> getSubjectdetails(int curIndex)//,int pagesize)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexamtype.SelectedValue == "" ? "0" : ddlexamtype.SelectedValue);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademic.SelectedValue == "" ? "0" : ddlacademic.SelectedValue);
            //objexam.PageSize = pagesize;
            objexam.CurrentIndex = curIndex;
            return objexamBO.SearchexamSubjectDetails(objexam);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlclass.SelectedIndex = 0;
            ddlexamtype.SelectedIndex = 0;
            lblmessage.Visible = false;
            divsearch.Visible = false;
        }
        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            List<Examdata> lstexamdata = new List<Examdata>();
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvExamdetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    String ID = GvExamdetails.Rows[index].Cells[0].Text;
                    Label SubjectID = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblID");
                    TextBox txtutmark = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txtutmark");
                    TextBox txtutppmark = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txtutpmark");
                    TextBox txtpwmark = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txtpwmark");
                    TextBox txtpwpmark = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txtpwpmark");
                    TextBox txthamark = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txthamark");
                    TextBox txthapmark = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txthapmark");
                    TextBox txtprioValue = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txtprioValue");
                    CheckBox chkmarkcount = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chkmarkcount");
                    CheckBox chkIsScience = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chkIsScience");
                    CheckBox chkIsScocialScience = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chkIsScocialScience");
                    CheckBox chkgrade = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chkIsGrade");
                    CheckBox ChkMinorsubject = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chkIsMinor");
                    CheckBox ChkActivate = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chklActivate");
                    CheckBox Chk_alt = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chk_altsubject");
                    CheckBox Chk_opt = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("Chk_optional");

                    Examdata ObjDetails = new Examdata();

                    ObjDetails.ID = Convert.ToInt32(ID);
                    ObjDetails.SubjectID = Convert.ToInt32(SubjectID.Text == "" ? "0" : SubjectID.Text);
                    ObjDetails.UTmark = float.Parse(txtutmark.Text == "" ? "0" : txtutmark.Text);
                    ObjDetails.UTpassmark = float.Parse(txtutppmark.Text == "" ? "0" : txtutppmark.Text);
                    ObjDetails.PWmark = float.Parse(txtpwmark.Text == "" ? "0" : txtpwmark.Text);
                    ObjDetails.PWpassmark = float.Parse(txtpwpmark.Text == "" ? "0" : txtpwpmark.Text);
                    ObjDetails.HAmark = float.Parse(txthamark.Text == "" ? "0" : txthamark.Text);
                    ObjDetails.HApassmark = float.Parse(txthapmark.Text == "" ? "0" : txthapmark.Text);
                    ObjDetails.PrioValue = int.Parse(txtprioValue.Text == "" ? "0" : txtprioValue.Text);
                    ObjDetails.IsMarkCount = Convert.ToInt32(chkmarkcount.Checked ? 1 : 0);
                    ObjDetails.IsScience = Convert.ToInt32(chkIsScience.Checked ? 1 : 0);
                    ObjDetails.IsSocialScience = Convert.ToInt32(chkIsScocialScience.Checked ? 1 : 0);
                    ObjDetails.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                    ObjDetails.ExamID = Convert.ToInt32(ddlexamtype.SelectedValue == "" ? "0" : ddlexamtype.SelectedValue);
                    ObjDetails.IsGradeSubject = Convert.ToInt32(chkgrade.Checked ? 1 : 0);
                    ObjDetails.IsMinorSubject = Convert.ToInt32(ChkMinorsubject.Checked ? 1 : 0);
                    ObjDetails.Isactivate = Convert.ToInt32(ChkActivate.Checked ? 1 : 0);
                    ObjDetails.OptSubjectID = Convert.ToInt32(Chk_opt.Checked ? 1 : 0);
                    ObjDetails.AltSubjectID = Convert.ToInt32(Chk_alt.Checked ? 1 : 0);

                    lstexamdata.Add(ObjDetails);
                    index++;
                }
                objexam.xmlexammarklist = XmlConvertor.SubjectMarkstoXML(lstexamdata).ToString();
                objexam.ExamID = Convert.ToInt32(ddlexamtype.SelectedValue == "" ? "0" : ddlexamtype.SelectedValue);
                objexam.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objexam.AcademicSessionID = Convert.ToInt32(ddlacademic.SelectedValue == "" ? "0" : ddlacademic.SelectedValue);
                int results = objexamBO.UpdateExamMarkslist(objexam);
                if (results == 1)
                {
                    bindgrid();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                    // btnUpdate.Attributes["disabled"] = "disabled";
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

        protected void bindgridfoucs()
        {
            for (int i = 0; i < GvExamdetails.Rows.Count - 1; i++)
            {
                TextBox curTexbox = GvExamdetails.Rows[i].Cells[8].FindControl("txtutmark") as TextBox;
                TextBox nexTextbox = GvExamdetails.Rows[i + 1].Cells[8].FindControl("txtutmark") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = GvExamdetails.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvExamdetails.Rows.Count - 1; i++)
            {
                TextBox curTexbox1 = GvExamdetails.Rows[i].Cells[9].FindControl("txtutpmark") as TextBox;
                TextBox nexTextbox1 = GvExamdetails.Rows[i + 1].Cells[9].FindControl("txtutpmark") as TextBox;
                curTexbox1.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox1.ClientID + "', event)");
                int lastindex = GvExamdetails.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox1.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvExamdetails.Rows.Count - 1; i++)
            {
                TextBox curTexbox2 = GvExamdetails.Rows[i].Cells[10].FindControl("txtpwmark") as TextBox;
                TextBox nexTextbox2 = GvExamdetails.Rows[i + 1].Cells[10].FindControl("txtpwmark") as TextBox;
                curTexbox2.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox2.ClientID + "', event)");
                int lastindex = GvExamdetails.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox2.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvExamdetails.Rows.Count - 1; i++)
            {
                TextBox curTexbox2 = GvExamdetails.Rows[i].Cells[11].FindControl("txtpwpmark") as TextBox;
                TextBox nexTextbox2 = GvExamdetails.Rows[i + 1].Cells[11].FindControl("txtpwpmark") as TextBox;
                curTexbox2.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox2.ClientID + "', event)");
                int lastindex = GvExamdetails.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox2.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
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
                wb.Worksheets.Add(dt, "ExamDetail List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= ExamMarkDetail_for_" + ddlclass.Text.ToString().Trim() + "_" + ddlexamtype.Text.ToString().Trim() + "_" + ddlacademic.Text.ToString().Trim() + ".xlsx");
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
            // int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<Examdata> ExamDetail = getSubjectdetails(0);//1, size);
            List<ExamDatatoExcel> examtoexcel = new List<ExamDatatoExcel>();
            int i = 0;
            foreach (Examdata row in ExamDetail)
            {
                ExamDatatoExcel EcxeclStd = new ExamDatatoExcel();
                EcxeclStd.ExamName = ExamDetail[i].ExamName;
                EcxeclStd.ClassName = ExamDetail[i].ClassName;
                EcxeclStd.AcademicSessionName = ExamDetail[i].AcademicSessionName;
                EcxeclStd.SubjectName = ExamDetail[i].SubjectName;
                EcxeclStd.IsScience = Convert.ToString(ExamDetail[i].IsScience);
                EcxeclStd.IsSocialScience = Convert.ToString(ExamDetail[i].IsSocialScience);
                EcxeclStd.IsMarkCount = Convert.ToString(ExamDetail[i].IsMarkCount);
                EcxeclStd.TheoryFullMark = Convert.ToString(ExamDetail[i].UTmark);
                EcxeclStd.TheoryPassMark = Convert.ToString(ExamDetail[i].UTpassmark);
                EcxeclStd.PWmark = Convert.ToString(ExamDetail[i].PWmark);
                EcxeclStd.PWpassmark = Convert.ToString(ExamDetail[i].PWpassmark);
                EcxeclStd.HAmark = Convert.ToString(ExamDetail[i].HAmark);
                EcxeclStd.HApassmark = Convert.ToString(ExamDetail[i].HApassmark);
                EcxeclStd.PrioValue = Convert.ToString(ExamDetail[i].PrioValue);
                examtoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(examtoexcel);
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
        protected void GvExamdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvExamdetails.PageIndex = e.NewPageIndex;
            //   bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvExamdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvExamdetails.Rows)
            {
                try
                {
                    CheckBox chkmarkcount = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkmarkcount");
                    Label lmarkcount = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkmarkcount");
                    if (lmarkcount.Text == "1")
                    {
                        chkmarkcount.Checked = true;
                    }
                    CheckBox chkIsScience = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkIsScience");
                    Label lIsSience = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblIsScience");
                    if (lIsSience.Text == "1")
                    {
                        chkIsScience.Checked = true;
                    }
                    CheckBox chkIsScocialScience = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkIsScocialScience");
                    Label lIsSocialScience = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblIsSocialScience");
                    if (lIsSocialScience.Text == "1")
                    {
                        chkIsScocialScience.Checked = true;
                    }
                    CheckBox chk_altsubject = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chk_altsubject");
                    Label alt_ID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lbl_altsubject");
                    CheckBox chk_opt = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("Chk_optional");
                    Label opt_ID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lbl_optional");
                    CheckBox chk_grade = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkIsGrade");
                    Label grade_ID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblIsGrade");
                    CheckBox chk_minor = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkIsMinor");
                    Label minor_ID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblIsMinor");
                    CheckBox chk_activate = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chklActivate");
                    Label acivate_ID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblActivate");
                    if (alt_ID.Text == "1")
                    {
                        chk_altsubject.Checked = true;
                    }
                    if (opt_ID.Text == "1")
                    {
                        chk_opt.Checked = true;
                    }
                    if (grade_ID.Text == "1")
                    {
                        chk_grade.Checked = true;
                    }
                    if (minor_ID.Text == "1")
                    {
                        chk_minor.Checked = true;
                    }
                    if (acivate_ID.Text == "1")
                    {
                        chk_activate.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }
        protected void GvExamdetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                bindgrid();
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
                    GvExamdetails.DataSource = sortedView;
                    GvExamdetails.DataBind();

                    TableCell tableCell = GvExamdetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvExamdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvExamdetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvExamdetails.UseAccessibleHeader = true;
                    GvExamdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid();
        }
        protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlexamtype.SelectedIndex > 0)
            {
                if(ddlclass.SelectedIndex==0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Class") + "')", true);
                    return;
                }
          
                bindgrid();
            }
            else
            {
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
                divsearch.Visible = false;
            }
        }
    }
}
