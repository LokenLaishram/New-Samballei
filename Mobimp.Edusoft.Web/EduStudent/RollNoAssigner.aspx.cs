﻿using System;
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
    public partial class RollNoAssigner : BasePage
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
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(ddlSectionID);

        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue)));
            if (ddlClassID.SelectedValue == "0")
            {
                GvstudentDetails.Visible = false;
                lblresult.Visible = false;
            }
            else
            {
                ddl_show.SelectedIndex = 0;
                BindGrid(1);
                GvstudentDetails.Visible = true;
                lblresult.Visible = true;
            }
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
                btnUpdate.Attributes.Remove("disabled");
                GvstudentDetails.Visible = true;
                GvstudentDetails.PageSize = pagesize;
                string record = result[0].TotalAdmissioncount.ToString() == "1" ? "  " : "  ";
                lblresult.Text = "Total Admission : " + result[0].TotalAdmissioncount.ToString() + " " + record;
                lblresult.BackColor = System.Drawing.Color.Green;
                lblresult.ForeColor = System.Drawing.Color.White;
                lbl_notadmission.Text = "Total Pending : " + result[0].TotalAdmissionpedning.ToString();
                lbl_notadmission.BackColor = System.Drawing.Color.Yellow;
                lbl_notadmission.ForeColor = System.Drawing.Color.Black;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                lbl_notadmission.Visible = true;
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
                lbl_notadmission.Visible = false;
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
            objstd.RollNo = Convert.ToInt32(txtRollNo.Text == "" ? "0" : txtRollNo.Text);
            objstd.IsAdmissionDone = Convert.ToInt32(ddl_admissionstatus.SelectedValue == "" ? "0" : ddl_admissionstatus.SelectedValue);
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.Getclasswisestudentlist(objstd);
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
            GvstudentDetails.Visible = false;
            btnUpdate.Visible = false;
            lblresult.Text = "";
            ddl_admissionstatus.SelectedIndex = 0;
        }
        protected void GvstudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GvstudentDetails.Columns[0].Visible = true;
            GvstudentDetails.Columns[1].Visible = true;
            GvstudentDetails.Columns[2].Visible = true;
            GvstudentDetails.Columns[3].Visible = true;
            GvstudentDetails.Columns[4].Visible = true;
            if (this.GvstudentDetails.Rows.Count > 0)
            {
                GvstudentDetails.UseAccessibleHeader = true;
                GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                // GvstudentDetails.FooterRow.TableSection = TableRowSection.TableFooter;
            }
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            List<LookupItem> looksection = objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue));
            foreach (GridViewRow row in GvstudentDetails.Rows)
            {
                try
                {
                    DropDownList ddlsection = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[3].FindControl("ddlsections");
                    Commonfunction.PopulateDdl(ddlsection, looksection);
                    Label SectionID = (Label)GvstudentDetails.Rows[row.RowIndex].Cells[3].FindControl("lblsectionID");
                    if (SectionID.Text != "0")
                    {
                        ddlsection.Items.FindByValue(SectionID.Text).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            List<StudentData> lststudentlist = new List<StudentData>();
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            // int index = 0;
            int rollnumers = 0;
            int Section = 0;
            int count = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvstudentDetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    String StudentID = GvstudentDetails.Rows[row.RowIndex].Cells[0].Text;
                    TextBox rollno = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[4].FindControl("lblrollno");
                    TextBox admissiondate = (TextBox)GvstudentDetails.Rows[row.RowIndex].Cells[5].FindControl("txt_admissiondate");
                    DropDownList ddlsection = (DropDownList)GvstudentDetails.Rows[row.RowIndex].Cells[3].FindControl("ddlsections");

                    StudentData ObjDetails = new StudentData();

                    ObjDetails.StudentID = Convert.ToInt32(StudentID.Trim());
                    ObjDetails.RollNo = Convert.ToInt32(rollno.Text);
                    ObjDetails.AdmissionDateTime = admissiondate.Text;
                    ObjDetails.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
                    ObjDetails.AddedBy = LoginToken.LoginId;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;

                    if (rollnumers == Convert.ToInt16(rollno.Text) && Section == Convert.ToInt16(ddlsection.SelectedValue) && Convert.ToInt32(rollno.Text) > 0)
                    {
                        count = count + 1;
                        rollno.BackColor = System.Drawing.Color.Yellow;
                        rollno.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        rollno.BackColor = System.Drawing.Color.White;
                        rollno.ForeColor = System.Drawing.Color.Black;
                    }

                    rollnumers = Convert.ToInt32(rollno.Text);
                    Section = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue); ;
                    lststudentlist.Add(ObjDetails);

                }
                objstd.XmlStudentlist = XmlConvertor.StudentListtoXML(lststudentlist).ToString();

                if (count > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("SameRollSameSec") + "')", true);
                    return;
                }

                int results = objstdBO.UpdateStudentRollnos(objstd);
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
            GvstudentDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvstudentDetails.UseAccessibleHeader = true;
            GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvstudentDetails.HeaderRow.Cells[0];
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
                Response.AddHeader("content-disposition", "attachment;filename= List of RollNos for Class :" + (ddlClassID.SelectedIndex == 0 ? "All" : ddlClassID.SelectedItem.Text) + " Section : " + (ddlSectionID.SelectedIndex == 0 ? "" : ddlSectionID.SelectedItem.Text) + ".xlsx");
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
            List<ExcelAssignRollNo> listecelstd = new List<ExcelAssignRollNo>();
            int i = 0;
            foreach (StudentData row in studentdetails)
            {
                ExcelAssignRollNo EcxeclStd = new ExcelAssignRollNo();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
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
        protected void ddlSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_show.SelectedIndex = 0;
            txtRollNo.Text = "";
            BindGrid(1);
        }
        protected void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            ddl_show.SelectedIndex = 0;
            BindGrid(1);
        }

        protected void ddl_admissionstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClassID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select class.") + "')", true);
            }
            else
            {
                ddl_show.SelectedIndex = 0;
                BindGrid(1);
            }
        }
    }
}