using ClosedXML.Excel;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.ELearning
{
    public partial class TeacherPasswordManager : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                BindGrid(1);
            }
        }
        private void BindGrid(int index)
        {
            EmployeeData objEmp = new EmployeeData();
            EmployeeBO objEmpBO = new EmployeeBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);

            List<EmployeeData> result = GetEmployeeList(index, pagesize);
            if (result.Count > 0)
            {
                btnUpdate.Visible = true;
                btnUpdate.Attributes.Remove("disabled");
                GvEmployeeDetails.Visible = true;
                GvEmployeeDetails.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvEmployeeDetails.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvEmployeeDetails.PageIndex = index - 1;
                GvEmployeeDetails.DataSource = result;
                GvEmployeeDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                GvEmployeeDetails.DataSource = null;
                GvEmployeeDetails.DataBind();
                GvEmployeeDetails.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<EmployeeData> GetEmployeeList(int curIndex, int pagesize)
        {
            EmployeeData objEmp = new EmployeeData();
            EmployeeBO objEmpBO = new EmployeeBO();
            objEmp.AcademicSessionID = LoginToken.AcademicSessionID;
            objEmp.AddedBy = LoginToken.LoginId;
            objEmp.PageSize = pagesize;
            objEmp.CurrentIndex = curIndex;
            return objEmpBO.GetEmployeePasswordList(objEmp);
        }
        private void resetall()
        {
            divsearch.Visible = false;
            GvEmployeeDetails.Visible = false;
            btnUpdate.Visible = false;
            lblresult.Text = "";
        }
        protected void GvstudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = e.Row.RowIndex;
                Label password = (Label)e.Row.FindControl("lbl_password");
                Commonfunction comfunc = new Commonfunction();
                password.Text = comfunc.Decrypt(password.Text.Trim());
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            List<EmployeeData> lstEmpList = new List<EmployeeData>();
            EmployeeData objEmp = new EmployeeData();
            EmployeeBO objEmpBO = new EmployeeBO();
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvEmployeeDetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    String EmployeeID = GvEmployeeDetails.Rows[row.RowIndex].Cells[1].Text;
                    Label realpassword = (Label)GvEmployeeDetails.Rows[row.RowIndex].Cells[1].FindControl("lbl_realpassword");
                    EmployeeData ObjDetails = new EmployeeData();
                    Commonfunction comfunc = new Commonfunction();
                    ObjDetails.EmployeeID = Convert.ToInt32(EmployeeID.Trim());
                    ObjDetails.UserPassword = comfunc.Encrypt(realpassword.Text.Trim());
                    lstEmpList.Add(ObjDetails);
                }
                objEmp.XmlEmployeeList = XmlConvertor.EmployeePasswordToXML(lstEmpList).ToString();
                int results = objEmpBO.UpdateEmployeePassword(objEmp);
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
            GvEmployeeDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvEmployeeDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvEmployeeDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvEmployeeDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvEmployeeDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvEmployeeDetails.UseAccessibleHeader = true;
            GvEmployeeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvEmployeeDetails.HeaderRow.Cells[0];
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
                Response.AddHeader("content-disposition", "attachment;filename= List of Username and Password for Teachers.xlsx");
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
            List<EmployeeData> studentdetails = GetEmployeeList(1, size);
            List<ExcelAssignEmployeepassword> listecelstd = new List<ExcelAssignEmployeepassword>();
            int i = 0;
            foreach (EmployeeData row in studentdetails)
            {
                ExcelAssignEmployeepassword EcxeclStd = new ExcelAssignEmployeepassword();
                EcxeclStd.EmployeeID = studentdetails[i].EmployeeID;
                EcxeclStd.EmployeeName = studentdetails[i].EmpName;
                EcxeclStd.Username = studentdetails[i].Username;
                Commonfunction comfunc = new Commonfunction();
                EcxeclStd.UserPassword = comfunc.Decrypt(studentdetails[i].UserPassword);
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
            GvEmployeeDetails.PageIndex = e.NewPageIndex;
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
                    GvEmployeeDetails.DataSource = sortedView;
                    GvEmployeeDetails.DataBind();

                    TableCell tableCell = GvEmployeeDetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvEmployeeDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvEmployeeDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvEmployeeDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvEmployeeDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvEmployeeDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvEmployeeDetails.UseAccessibleHeader = true;
                    GvEmployeeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
            BindGrid(1);
        }

        protected void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetall();
        }

        protected void ddlStaffTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
    }
}