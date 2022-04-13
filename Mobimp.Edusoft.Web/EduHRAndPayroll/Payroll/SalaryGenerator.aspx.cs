using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Campusoft.Data.HRAndPayroll.Payroll;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Payroll;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.Payroll
{
    public partial class SalaryGenerator : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
            }
        }

        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            Commonfunction.PopulateDdl(ddlMonth, mstlookup.GetLookupsList(LookupNames.Months));
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmployeeName(string prefixText, int count, string contextKey)
        {
            SalaryGeneratorData ObjData = new SalaryGeneratorData();
            SalaryGeneratorBO ObjBO = new SalaryGeneratorBO();
            List<SalaryGeneratorData> getResult = new List<SalaryGeneratorData>();
            ObjData.EmployeeName = prefixText;
            getResult = ObjBO.GetEmployeeName(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeName.ToString());
            }
            return list;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSession.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("AcademicSession") + "')", true);
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            if (ddlMonth.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("SelectMonth") + "')", true);
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            bindgrid(1);
            if (Convert.ToInt32(ddlSession.SelectedValue) == LoginToken.AcademicSessionID)
            {
                btnUpdate.Attributes.Remove("disabled");
            }
            else
            {
                btnUpdate.Attributes["disabled"] = "disabled";
            }
        }

        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SalaryGeneratorData> lstSalaryGenerator = GetSalaryGenerator(index, pagesize);
            if (lstSalaryGenerator.Count > 0)
            {
                GvSalaryGenerator.PageSize = pagesize;
                string record = lstSalaryGenerator[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstSalaryGenerator[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstSalaryGenerator[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvSalaryGenerator.VirtualItemCount = lstSalaryGenerator[0].MaximumRows;//total item is required for custom paging
                GvSalaryGenerator.PageIndex = index - 1;
                GvSalaryGenerator.DataSource = lstSalaryGenerator;
                GvSalaryGenerator.DataBind();
                ds = ConvertToDataSet(lstSalaryGenerator);
                TableCell tableCell = GvSalaryGenerator.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvSalaryGenerator.DataSource = null;
                GvSalaryGenerator.DataBind();
            }
        }

        public List<SalaryGeneratorData> GetSalaryGenerator(int curIndex, int pagesize)
        {
            SalaryGeneratorData objdata = new SalaryGeneratorData();
            SalaryGeneratorBO objBO = new SalaryGeneratorBO();
            objdata.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            objdata.Year = ddlSession.SelectedItem.Text == null ? "" : ddlSession.SelectedItem.Text;
            objdata.MonthID = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "0" : ddlMonth.SelectedValue);
            objdata.Month = ddlSession.SelectedItem.Text == null ? "" : ddlMonth.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.AcademicSessionID = LoginToken.AcademicSessionID;
            objdata.PageSize = GvSalaryGenerator.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetSalaryGenerator(objdata);
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
            GvSalaryGenerator.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvSalaryGenerator.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSalaryGenerator.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvSalaryGenerator.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSalaryGenerator.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvSalaryGenerator.UseAccessibleHeader = true;
            GvSalaryGenerator.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
    }
}