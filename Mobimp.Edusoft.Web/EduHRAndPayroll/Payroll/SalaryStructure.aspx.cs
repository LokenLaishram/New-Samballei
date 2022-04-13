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
    public partial class SalaryStructure : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
                divupdate.Visible = false;
            }
        }
        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddl_employee, mstlookup.GetLookupsList(LookupNames.Employee));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            if (ddlSession.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("session") + "')", true);
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            GvSalaryStructure.PageSize = pagesize;
            List<SalaryStructureData> lstSalaryStructure = GetSalaryStructure(index, pagesize);
            if (lstSalaryStructure.Count > 0)
            {
                string record = lstSalaryStructure[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstSalaryStructure[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstSalaryStructure[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvSalaryStructure.VirtualItemCount = lstSalaryStructure[0].MaximumRows;//total item is required for custom paging
                GvSalaryStructure.PageIndex = index - 1;
                GvSalaryStructure.DataSource = lstSalaryStructure;
                GvSalaryStructure.DataBind();
                ds = ConvertToDataSet(lstSalaryStructure);
                TableCell tableCell = GvSalaryStructure.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                bindgridfoucs();
                divupdate.Visible = true;
            }
            else
            {
                GvSalaryStructure.DataSource = null;
                GvSalaryStructure.DataBind();
            }
        }

        public List<SalaryStructureData> GetSalaryStructure(int curIndex, int pagesize)
        {
            SalaryStructureData objdata = new SalaryStructureData();
            SalaryStructureBO objBO = new SalaryStructureBO();
            objdata.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            objdata.Year = ddlSession.SelectedItem.Text == null ? "" : ddlSession.SelectedItem.Text;
            objdata.EmployeeID = Convert.ToInt32(ddl_employee.SelectedValue == "" ? "0" : ddl_employee.SelectedValue);
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.AcademicSessionID = LoginToken.AcademicSessionID;
            objdata.PageSize = GvSalaryStructure.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetSalaryStructure(objdata);
        }
        protected void bindgridfoucs()
        {
            for (int i = 0; i < GvSalaryStructure.Rows.Count - 1; i++)
            {
                TextBox curTexbox = GvSalaryStructure.Rows[i].Cells[4].FindControl("Gv_txtBasicSalary") as TextBox;
                TextBox nexTextbox = GvSalaryStructure.Rows[i + 1].Cells[4].FindControl("Gv_txtBasicSalary") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = GvSalaryStructure.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvSalaryStructure.Rows.Count - 1; i++)
            {
                TextBox curTexbox1 = GvSalaryStructure.Rows[i].Cells[5].FindControl("Gv_txtTA") as TextBox;
                TextBox nexTextbox1 = GvSalaryStructure.Rows[i + 1].Cells[5].FindControl("Gv_txtTA") as TextBox;
                curTexbox1.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox1.ClientID + "', event)");
                int lastindex = GvSalaryStructure.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox1.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvSalaryStructure.Rows.Count - 1; i++)
            {
                TextBox curTexbox2 = GvSalaryStructure.Rows[i].Cells[6].FindControl("Gv_txtProxy") as TextBox;
                TextBox nexTextbox2 = GvSalaryStructure.Rows[i + 1].Cells[6].FindControl("Gv_txtProxy") as TextBox;
                curTexbox2.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox2.ClientID + "', event)");
                int lastindex = GvSalaryStructure.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox2.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvSalaryStructure.Rows.Count - 1; i++)
            {
                TextBox curTexbox = GvSalaryStructure.Rows[i].Cells[7].FindControl("Gv_txtAbsent") as TextBox;
                TextBox nexTextbox = GvSalaryStructure.Rows[i + 1].Cells[7].FindControl("Gv_txtAbsent") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = GvSalaryStructure.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvSalaryStructure.Rows.Count - 1; i++)
            {
                TextBox curTexbox1 = GvSalaryStructure.Rows[i].Cells[8].FindControl("Gv_txtEPF") as TextBox;
                TextBox nexTextbox1 = GvSalaryStructure.Rows[i + 1].Cells[8].FindControl("Gv_txtEPF") as TextBox;
                curTexbox1.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox1.ClientID + "', event)");
                int lastindex = GvSalaryStructure.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox1.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < GvSalaryStructure.Rows.Count - 1; i++)
            {
                TextBox curTexbox2 = GvSalaryStructure.Rows[i].Cells[9].FindControl("Gv_txtDA") as TextBox;
                TextBox nexTextbox2 = GvSalaryStructure.Rows[i + 1].Cells[9].FindControl("Gv_txtDA") as TextBox;
                curTexbox2.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox2.ClientID + "', event)");
                int lastindex = GvSalaryStructure.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox2.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
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
            GvSalaryStructure.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvSalaryStructure.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSalaryStructure.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvSalaryStructure.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSalaryStructure.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvSalaryStructure.UseAccessibleHeader = true;
            GvSalaryStructure.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void GvSalaryStructure_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSalaryStructure.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<SalaryStructureData> ListSalaryStructure = new List<SalaryStructureData>();
                SalaryStructureBO objBO = new SalaryStructureBO();
                SalaryStructureData objData = new SalaryStructureData();
                foreach (GridViewRow row in GvSalaryStructure.Rows)
                {
                    Label ID = (Label)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_ID");
                    Label YearID = (Label)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
                    Label EmployeeID = (Label)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblEmployeeID");
                    TextBox BasicSalary = (TextBox)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtBasicSalary");
                    TextBox TA = (TextBox)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtTA");
                    TextBox Proxy = (TextBox)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtProxy");
                    TextBox Absent = (TextBox)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtAbsent");
                    TextBox EPF = (TextBox)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtEPF");
                    TextBox DA = (TextBox)GvSalaryStructure.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtDA");
                    SalaryStructureData ObjDetails = new SalaryStructureData();

                    ObjDetails.ID = Convert.ToInt64(ID.Text == "" ? "0" : ID.Text);
                    ObjDetails.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
                    ObjDetails.EmployeeID = Convert.ToInt64(EmployeeID.Text == "" ? "0" : EmployeeID.Text);
                    ObjDetails.BasicSalary = Convert.ToDecimal(BasicSalary.Text == null ? "" : BasicSalary.Text);
                    ObjDetails.TA = Convert.ToDecimal(TA.Text == "" ? "0" : TA.Text);
                    ObjDetails.Proxy = Convert.ToDecimal(Proxy.Text == "" ? "0" : Proxy.Text);
                    ObjDetails.Absent = Convert.ToDecimal(Absent.Text == "" ? "0" : Absent.Text);
                    ObjDetails.EPF = Convert.ToDecimal(EPF.Text == "" ? "0" : EPF.Text);
                    ObjDetails.DA = Convert.ToDecimal(DA.Text == "" ? "0" : DA.Text);
                    ListSalaryStructure.Add(ObjDetails);
                }
                objData.XMLData = XmlConvertor.SalaryStructureListToXml(ListSalaryStructure).ToString();
                objData.AddedBy = LoginToken.LoginId;
                objData.UserId = LoginToken.UserLoginId;
                objData.CompanyID = LoginToken.CompanyID;
                objData.AcademicSessionID = LoginToken.AcademicSessionID;

                int result = objBO.UpdateSalaryStructure(objData);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    bindgrid(1);
                    return;
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    btnUpdate.Attributes["disabled"] = "disabled";
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            ddlSession.SelectedIndex = 0;
            ddl_employee.SelectedIndex = 0;
            lblmessage.Text = "";
            lblresult.Text = "";
            GvSalaryStructure.DataSource = null;
            GvSalaryStructure.DataBind();
            divupdate.Visible = false;
        }
        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddl_employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}