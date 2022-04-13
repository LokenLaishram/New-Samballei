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
using Mobimp.Edusoft.Common;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.Payroll
{
    public partial class OutsideDutyManager : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.Text = "Add";
                BindDdl();
                if (Session["ID"] != null)
                {
                    int ID = Convert.ToInt32(Session["ID"]);
                    getdutydetailsbyID(ID);
                    btnAdd.Text = "Update";
                }
                divsearch.Visible = false;
            }
        }
        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            Commonfunction.PopulateDdl(ddl_sessions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddl_month, mstlookup.GetLookupsList(LookupNames.Months));
            txt_datefrom.Text = GlobalConstant.MinSQLDateTime.ToString("dd/MM/yyyy");
            txt_to.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmployeeName(string prefixText, int count, string contextKey)
        {
            OutsideDutyManagerData ObjData = new OutsideDutyManagerData();
            OutsideDutyManagerBO ObjBO = new OutsideDutyManagerBO();
            List<OutsideDutyManagerData> getResult = new List<OutsideDutyManagerData>();
            ObjData.EmployeeName = prefixText;
            getResult = ObjBO.GetEmployeeName(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeName.ToString());
            }
            return list;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSession.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("AcademicSession") + "')", true);
                    ddlSession.Focus();
                    return;
                }
                if (txtEmployee.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("EnterEmployeeName") + "')", true);
                    txtEmployee.Focus();
                    return;
                }
                if (txtDate.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Date") + "')", true);
                    txtDate.Focus();
                    return;
                }
                if (txt_covinentcharge.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Convenience") + "')", true);
                    txt_covinentcharge.Focus();
                    return;
                }
                if (txtReason.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Reason") + "')", true);
                    txtReason.Focus();
                    return;
                }
                OutsideDutyManagerData ObjData = new OutsideDutyManagerData();
                OutsideDutyManagerBO ObjBO = new OutsideDutyManagerBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                ObjData.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
                ObjData.Year = ddlSession.SelectedItem.Text == null ? "" : ddlSession.SelectedItem.Text;
                ObjData.EmployeeID = Commonfunction.SemicolonSeparation_String_64(txtEmployee.Text.ToString());
                ObjData.EmployeeName = lblEmployeeName.Text == null ? "" : lblEmployeeName.Text.Trim();
                ObjData.Date = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                ObjData.Reason = txtReason.Text == null ? "" : txtReason.Text;
                ObjData.ConvenienceFee = Convert.ToDecimal(txt_covinentcharge.Text == "" ? "0.0" : txt_covinentcharge.Text);
                ObjData.UserId = LoginToken.UserLoginId;
                ObjData.AddedBy = LoginToken.LoginId;
                ObjData.CompanyID = LoginToken.CompanyID;
                ObjData.AcademicSessionID = LoginToken.AcademicSessionID;
                ObjData.IsActive = true;
                ObjData.ActionType = EnumActionType.Insert;
                if (Session["ID"] != null)
                {
                    ObjData.ActionType = EnumActionType.Update;
                    ObjData.ID = Convert.ToInt32(Session["ID"].ToString());
                }
                int result = ObjBO.UpdateOutsideDutyDetails(ObjData);
                if (result == 1 || result == 2)
                {
                    //ClearAll();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    Session["ID"] = null;
                    btnAdd.Text = "Add";
                    btnAdd.Attributes["disabled"] = "disabled";
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);

                }
                bindgrid(1);

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            txtEmployee.Text = "";
            lblEmployeeID.Text = "";
            lblEmployeeName.Text = "";
            txtDate.Text = "";
            txtReason.Text = "";
            txt_covinentcharge.Text = "";
            btnAdd.Text = "Add";
            Session[ID] = null;
            btnAdd.Attributes.Remove("disabled");
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            GvOutsideDutyList.PageSize = pagesize;
            List<OutsideDutyManagerData> lstOutsideDuty = GetOutsideDutyDetails(index, pagesize);
            if (lstOutsideDuty.Count > 0)
            {
                string record = lstOutsideDuty[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstOutsideDuty[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstOutsideDuty[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvOutsideDutyList.VirtualItemCount = lstOutsideDuty[0].MaximumRows;//total item is required for custom paging
                GvOutsideDutyList.PageIndex = index - 1;
                GvOutsideDutyList.DataSource = lstOutsideDuty;
                GvOutsideDutyList.DataBind();
                GvOutsideDutyList.Visible = true;
                ds = ConvertToDataSet(lstOutsideDuty);
                TableCell tableCell = GvOutsideDutyList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                divsearch.Visible = true;
                bindresponsive();
            }
            else
            {
                lblresult.Visible = false;
                GvOutsideDutyList.DataSource = null;
                GvOutsideDutyList.DataBind();
                divsearch.Visible = true;
            }
        }
        public List<OutsideDutyManagerData> GetOutsideDutyDetails(int curIndex, int pagesize)
        {
            OutsideDutyManagerData objdata = new OutsideDutyManagerData();
            OutsideDutyManagerBO objBO = new OutsideDutyManagerBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            objdata.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            objdata.EmployeeID = Convert.ToInt64(lblEmployeeID.Text == "" ? "0" : lblEmployeeID.Text);
            objdata.Datefrom = txt_datefrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_datefrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.Dateto = txt_to.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_to.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            objdata.PageSize = GvOutsideDutyList.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetOutsideDutyDetails(objdata);
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
            GvOutsideDutyList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvOutsideDutyList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvOutsideDutyList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvOutsideDutyList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvOutsideDutyList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvOutsideDutyList.UseAccessibleHeader = true;
            GvOutsideDutyList.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void getdaterange(int year, int month)
        {
            DateTime first = new DateTime(year, month, 1);
            DateTime last = first.AddMonths(1).AddSeconds(-1);
            txt_datefrom.Text = first.ToString("dd/MM/yyyy");
            txt_to.Text = last.ToString("dd/MM/yyyy");
        }
        protected void getyeardaterange(int year)
        {
            DateTime startDate = new DateTime(year, 1, 1);
            DateTime endDate = new DateTime(year, 12, 31);
            txt_datefrom.Text = startDate.ToString("dd/MM/yyyy");
            txt_to.Text = endDate.ToString("dd/MM/yyyy");
        }
        protected void ddl_months_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_month.SelectedIndex > 0)
            {
                lblmessage.Visible = false;
                if (ddl_sessions.SelectedIndex == 0)
                {
                    Messagealert_.ShowMessage(lblmessage, "Please select year", 0);
                    ddl_month.SelectedIndex = 0;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select session.") + "')", true);
                    return;
                }
                lblmessage.Visible = false;
                int year = Convert.ToInt32(ddl_sessions.SelectedItem.Text);
                int month = Convert.ToInt32(ddl_month.SelectedValue);
                getdaterange(year, month);
                bindgrid(1);
            }
            else
            {
                ddl_sessions.SelectedIndex = 0;
                txt_datefrom.Text = GlobalConstant.MinSQLDateTime.ToString("dd/MM/yyyy");
                txt_to.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                lblmessage.Visible = false;
                bindgrid(1);
            }
        }
        protected void GvOutsideDutyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    OutsideDutyManagerData ObjData = new OutsideDutyManagerData();
                    OutsideDutyManagerBO ObjBO = new OutsideDutyManagerBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvOutsideDutyList.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("Gv_lblID");
                    int IDs = Convert.ToInt32(ID.Text);
                    getdutydetailsbyID(IDs);
                    btnAdd.Text = "Update";
                    Response.Redirect("~/EduHRAndPayroll/Payroll/OutsideDutyManager.aspx", false);
                }
                if (e.CommandName == "Deletes")
                {
                    OutsideDutyManagerData ObjData = new OutsideDutyManagerData();
                    OutsideDutyManagerBO ObjBO = new OutsideDutyManagerBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvOutsideDutyList.Rows[i];
                    TextBox remark = (TextBox)gr.Cells[0].FindControl("Gv_txtRemark");
                    if (remark.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        remark.Focus();
                        return;
                    }
                    Label ID = (Label)gr.Cells[0].FindControl("Gv_lblID");
                    ObjData.ID = Convert.ToInt32(ID.Text);
                    ObjData.UserId = LoginToken.UserLoginId;
                    ObjData.AddedBy = LoginToken.LoginId;
                    ObjData.CompanyID = LoginToken.CompanyID;
                    ObjData.AcademicSessionID = LoginToken.AcademicSessionID;

                    int Result = ObjBO.DeleteOutsideDutyByID(ObjData);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
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
        protected void getdutydetailsbyID(int ID)
        {
            OutsideDutyManagerData ObjData = new OutsideDutyManagerData();
            OutsideDutyManagerBO ObjBO = new OutsideDutyManagerBO();
            ObjData.ID = ID;
            List<OutsideDutyManagerData> GetResult = ObjBO.GetOutsideDutyByID(ObjData);
            if (GetResult.Count > 0)
            {
                ddlSession.SelectedValue = GetResult[0].YearID.ToString();
                txtEmployee.Text = GetResult[0].EmployeeName;
                lblEmployeeID.Text = GetResult[0].EmployeeID.ToString();
                lblEmployeeName.Text = GetResult[0].EmployeeName.ToString();
                txt_covinentcharge.Text = Commonfunction.Getrounding(GetResult[0].ConvenienceFee.ToString());
                txtDate.Text = GetResult[0].Date.ToString("dd/MM/yyyy");
                txtReason.Text = GetResult[0].Reason.ToString();
                Session["ID"] = GetResult[0].ID;
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<OutsideDutyManagerData> ListOutsideDuty = new List<OutsideDutyManagerData>();
                OutsideDutyManagerBO objBO = new OutsideDutyManagerBO();
                OutsideDutyManagerData objData = new OutsideDutyManagerData();
                foreach (GridViewRow row in GvOutsideDutyList.Rows)
                {
                    Label ID = (Label)GvOutsideDutyList.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblID");
                    TextBox Reason = (TextBox)GvOutsideDutyList.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtReason");
                    TextBox ConvenienceFee = (TextBox)GvOutsideDutyList.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtConvenience");
                    OutsideDutyManagerData ObjDetails = new OutsideDutyManagerData();

                    ObjDetails.ID = Convert.ToInt64(ID.Text == "" ? "0" : ID.Text);
                    ObjDetails.Reason = Reason.Text == null ? "" : Reason.Text;
                    ObjDetails.ConvenienceFee = Convert.ToDecimal(ConvenienceFee.Text == null ? "" : ConvenienceFee.Text);
                    ListOutsideDuty.Add(ObjDetails);
                }
                objData.XMLData = XmlConvertor.OutsideDutyListToXml(ListOutsideDuty).ToString();
                objData.AddedBy = LoginToken.LoginId;
                objData.UserId = LoginToken.UserLoginId;
                objData.CompanyID = LoginToken.CompanyID;
                objData.AcademicSessionID = LoginToken.AcademicSessionID;

                int result = objBO.UpdateOutsideDutyListDetails(objData);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                    bindgrid(1);
                    return;
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void GvOutsideDutyList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvOutsideDutyList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ddl_sessions.SelectedIndex = 0;
            ddl_month.SelectedIndex = 0;
            txt_employeenames.Text = "";
            txt_datefrom.Text = "";
            txt_to.Text = "";
            ddl_status.SelectedIndex = 0;
            GvOutsideDutyList.DataSource = null;
            GvOutsideDutyList.DataBind();
            GvOutsideDutyList.Visible = false;
            divsearch.Visible = false;
        }
        protected void ddl_sessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_sessions.SelectedIndex > 0)
            {
                int year = Convert.ToInt32(ddl_sessions.SelectedItem.Text == "" ? "0" : ddl_sessions.SelectedItem.Text);
                getyeardaterange(year);
                bindgrid(1);
            }
            else
            {
                txt_datefrom.Text = GlobalConstant.MinSQLDateTime.ToString("dd/MM/yyyy");
                txt_to.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                bindgrid(1);
            }
            ddl_month.SelectedIndex = 0;
        }
    }
}