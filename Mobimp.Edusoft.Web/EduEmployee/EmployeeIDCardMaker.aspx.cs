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
using System.Data;
using ClosedXML.Excel;
using System.Reflection;

namespace Mobimp.Campusoft.Web.EduEmployee
{
    public partial class EmployeeIDCardMaker : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                bindddl();
                //bindgrid(1);
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
           
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
         
            Commonfunction.PopulateDdl(ddlstfftypes, mstlookup.GetLookupsList(LookupNames.StaffType));
            Commonfunction.PopulateDdl(ddlempcategories, mstlookup.GetLookupsList(LookupNames.StaffCategory));

        }
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
        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtempnames.Text = "";
            ddlacademicseesions.SelectedIndex = 0;
            ddlsexs.SelectedIndex = 0;
            txtempnames.Text = "";
            ddlstatus.SelectedIndex = 0;
            GvemployeeDetails.DataSource = null;
            GvemployeeDetails.DataBind();
            GvemployeeDetails.Visible = false;
            lblresult.Visible = false;
            divsearch.Visible = false;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<EmployeeData> lstemp = Bindempprofile(index, pagesize);
            if (lstemp.Count > 0)
            {
                string record = lstemp[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstemp[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstemp[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvemployeeDetails.VirtualItemCount = lstemp[0].MaximumRows;//total item is required for custom paging
                GvemployeeDetails.PageIndex = index - 1;
                GvemployeeDetails.AllowCustomPaging = true;
                GvemployeeDetails.AllowPaging = true;
                GvemployeeDetails.PageSize = lstemp.Count;
                GvemployeeDetails.DataSource = lstemp;
                GvemployeeDetails.DataBind();
                GvemployeeDetails.Visible = true;
                bindresponsive();
                ds = ConvertToDataSet(lstemp); 
            }
            else
            {
                GvemployeeDetails.DataSource = null;
                GvemployeeDetails.DataBind();
            }
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
        public List<EmployeeData> Bindempprofile(int curIndex,int pagesize)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();

            // objemp.EmployeeID = Convert.ToInt32(txtemployeedID.Text == "" ? "0" : txtemployeedID.Text);
            objemp.EmployeeNo = txtemployeedID.Text == "" ? "0" : txtemployeedID.Text;
            objemp.EmpName = txtempnames.Text == "" ? "0" : txtempnames.Text;
            objemp.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objemp.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objemp.StaffTypeID = Convert.ToInt32(ddlstfftypes.SelectedValue == "" ? "0" : ddlstfftypes.SelectedValue);
            objemp.EmployeeCatgeroyID = Convert.ToInt32(ddlempcategories.SelectedValue == "" ? "0" : ddlempcategories.SelectedValue);
            objemp.IsActiveALL = ddlstatus.SelectedValue;
            objemp.ActionType = EnumActionType.Select;
            objemp.PageSize = pagesize;
            objemp.CurrentIndex = curIndex;
            return objempBO.SearchEmployeeTypeDetails(objemp);
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "EmployeeIDCardMaker List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeIDCardMaker.xlsx");
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
            List<EmployeeData> ClassDetail = Bindempprofile(1, size);
            List<EmployeeIDCardDatatoExcel> classtoexcel = new List<EmployeeIDCardDatatoExcel>();
            int i = 0;
            foreach (EmployeeData row in ClassDetail)
            {
                EmployeeIDCardDatatoExcel EcxeclStd = new EmployeeIDCardDatatoExcel();
               // EcxeclStd.Code = ClassDetail[i].Code;
                //EcxeclStd.Class = ClassDetail[i].Descriptions;
                classtoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(classtoexcel);
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void GvemployeeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvemployeeDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

    }
}