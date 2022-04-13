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
    public partial class DailyProxyManager : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlSession.Attributes["disabled"] = "disabled";
                txtProxyCharge.Attributes["disabled"] = "disabled";
                BindDdl();
                if (Session["ID"] != null)
                {
                    int ID = Convert.ToInt32(Session["ID"]);
                    getproxydetailsbyid(ID);
                    btnAdd.Text = "Update";
                }
            }
        }
        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            Commonfunction.PopulateDdl(ddlClass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddltab2_Session, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddltab2_Session.SelectedValue = LoginToken.AcademicSessionID.ToString();
            Commonfunction.PopulateDdl(ddltab2_Class, mstlookup.GetLookupsList(LookupNames.Class));
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmployeeName(string prefixText, int count, string contextKey)
        {
            DailyProxyManagerData ObjData = new DailyProxyManagerData();
            DailyProxyManagerBO ObjBO = new DailyProxyManagerBO();
            List<DailyProxyManagerData> getResult = new List<DailyProxyManagerData>();
            ObjData.EmployeeName = prefixText;
            getResult = ObjBO.GetEmployeeName(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeName.ToString());
            }
            return list;
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployee.Text != "")
            {
                var source = txtEmployee.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    lblEmployeeID.Text = (ID == "" ? "0" : ID);
                    DailyProxyManagerData ObjData = new DailyProxyManagerData();
                    DailyProxyManagerBO ObjBO = new DailyProxyManagerBO();
                    List<DailyProxyManagerData> getResult = new List<DailyProxyManagerData>();
                    ObjData.EmployeeID = Convert.ToInt32(lblEmployeeID.Text);
                    ObjData.YearID = Convert.ToInt32(ddlSession.SelectedValue);
                    getResult = ObjBO.GetEmployeeDetailsByID(ObjData);
                    if (getResult.Count > 0)
                    {
                        lblEmployeeName.Text = getResult[0].EmployeeName;
                        txtProxyCharge.Text = getResult[0].ProxyCharge.ToString("0.00");
                    }
                    else
                    {
                        lblEmployeeID.Text = "";
                        lblEmployeeName.Text = "";
                        txtProxyCharge.Text = "";
                    }
                }
                else
                {
                    txtEmployee.Text = "";
                    lblEmployeeID.Text = "";
                    lblEmployeeName.Text = "";
                    txtProxyCharge.Text = "";
                    return;
                }
            }
        }

        protected void txtProxyFor_TextChanged(object sender, EventArgs e)
        {
            if (txtProxyFor.Text != "")
            {
                var source = txtProxyFor.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    lblProxyForID.Text = (ID == "" ? "0" : ID);
                    DailyProxyManagerData ObjData = new DailyProxyManagerData();
                    DailyProxyManagerBO ObjBO = new DailyProxyManagerBO();
                    List<DailyProxyManagerData> getResult = new List<DailyProxyManagerData>();
                    ObjData.EmployeeID = Convert.ToInt32(lblProxyForID.Text);
                    ObjData.YearID = Convert.ToInt32(ddlSession.SelectedValue);
                    getResult = ObjBO.GetEmployeeDetailsByID(ObjData);
                    if (getResult.Count > 0)
                    {
                        lblProxyForName.Text = getResult[0].EmployeeName;
                    }
                    else
                    {
                        lblProxyForID.Text = "";
                        lblProxyForName.Text = "";
                    }
                }
                else
                {
                    txtProxyFor.Text = "";
                    lblProxyForID.Text = "";
                    lblProxyForName.Text = "";
                    return;
                }
            }
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
                if (txtProxyFor.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("EnterEmployeeName") + "')", true);
                    txtProxyFor.Focus();
                    return;
                }
                if (ddlClass.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Class") + "')", true);
                    ddlClass.Focus();
                    return;
                }
                if (txtReason.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Reason") + "')", true);
                    txtReason.Focus();
                    return;
                }
                if (ddlStatus.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("SelectActive") + "')", true);
                    ddlStatus.Focus();
                    return;
                }

                DailyProxyManagerData ObjData = new DailyProxyManagerData();
                DailyProxyManagerBO ObjBO = new DailyProxyManagerBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                ObjData.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
                ObjData.Year = ddlSession.SelectedItem.Text == null ? "" : ddlSession.SelectedItem.Text;
                ObjData.EmployeeID = Convert.ToInt64(lblEmployeeID.Text == "" ? "0" : lblEmployeeID.Text);
                ObjData.EmployeeName = lblEmployeeName.Text == null ? "" : lblEmployeeName.Text.Trim();
                ObjData.ProxyCharge = Convert.ToDecimal(txtProxyCharge.Text == "" ? "0" : txtProxyCharge.Text);
                ObjData.Date = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                ObjData.ProxyForID = Convert.ToInt64(lblProxyForID.Text == "" ? "0" : lblProxyForID.Text);
                ObjData.ProxyForName = lblProxyForName.Text == null ? "" : lblProxyForName.Text;
                ObjData.ClassID = Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue);
                ObjData.ClassName = ddlClass.SelectedItem.Text == null ? "" : ddlClass.SelectedItem.Text;
                ObjData.Reason = txtReason.Text == null ? "" : txtReason.Text;
                ObjData.UserId = LoginToken.UserLoginId;
                ObjData.AddedBy = LoginToken.LoginId;
                ObjData.CompanyID = LoginToken.CompanyID;
                ObjData.AcademicSessionID = LoginToken.AcademicSessionID;
                ObjData.IsActive = ddlStatus.SelectedValue == "1" ? true : false; ;
                ObjData.ActionType = EnumActionType.Insert;
                if (Session["ID"] != null)
                {
                    ObjData.ActionType = EnumActionType.Update;
                    ObjData.ID = Convert.ToInt32(Session["ID"].ToString());
                }
                if (Convert.ToInt64(lblEmployeeID.Text == "" ? "0" : lblEmployeeID.Text) == Convert.ToInt64(lblProxyForID.Text == "" ? "0" : lblProxyForID.Text))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter another employee for proxy.") + "')", true);
                    return;
                }

                int result = ObjBO.UpdateDailyProxyDetails(ObjData);
                if (result == 1 || result == 2)
                {
                    //ClearAll();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    Session["ID"] = null;
                    btnAdd.Text = "Save";
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
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            lblmessage.Text = "";
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            txtEmployee.Text = "";
            lblEmployeeID.Text = "";
            lblEmployeeName.Text = "";
            txtProxyCharge.Text = "";
            txtDate.Text = "";
            txtProxyFor.Text = "";
            lblProxyForID.Text = "";
            lblProxyForName.Text = "";
            ddlClass.SelectedValue = "0";
            txtReason.Text = "";
            ddlStatus.SelectedIndex = 0;
            btnAdd.Text = "Save";
            Session["ID"] = null;
        }
        //-- ----------------------------End Tab 1------------------------------
        //-- ----------------------------Start Tab 2------------------------------
        protected void txttab2_EmpName_TextChanged(object sender, EventArgs e)
        {
            if (txttab2_EmpName.Text != "")
            {
                var source = txttab2_EmpName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    lbltab2_EmpID.Text = (ID == "" ? "0" : ID);
                }
                else
                {
                    txttab2_EmpName.Text = "";
                    lbltab2_EmpID.Text = "";
                    return;
                }
            }
            bindgrid(1);
        }



        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void btntab2_Search_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            Gvtab2_ProxyManagerList.PageSize = pagesize;
            List<DailyProxyManagerData> lstDailyProxy = GetDailyProxyDetails(index, pagesize);
            if (lstDailyProxy.Count > 0)
            {
                string record = lstDailyProxy[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstDailyProxy[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstDailyProxy[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gvtab2_ProxyManagerList.VirtualItemCount = lstDailyProxy[0].MaximumRows;//total item is required for custom paging
                Gvtab2_ProxyManagerList.PageIndex = index - 1;
                Gvtab2_ProxyManagerList.DataSource = lstDailyProxy;
                Gvtab2_ProxyManagerList.DataBind();
                Gvtab2_ProxyManagerList.Visible = true;
                ds = ConvertToDataSet(lstDailyProxy);
                TableCell tableCell = Gvtab2_ProxyManagerList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gvtab2_ProxyManagerList.DataSource = null;
                Gvtab2_ProxyManagerList.DataBind();
            }
        }

        public List<DailyProxyManagerData> GetDailyProxyDetails(int curIndex, int pagesize)
        {
            DailyProxyManagerData objdata = new DailyProxyManagerData();
            DailyProxyManagerBO objBO = new DailyProxyManagerBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            objdata.YearID = Convert.ToInt32(ddltab2_Session.SelectedValue == "" ? "0" : ddltab2_Session.SelectedValue);
            objdata.EmployeeID = Convert.ToInt64(lbltab2_EmpID.Text == "" ? "0" : lbltab2_EmpID.Text);
            objdata.ClassID = Convert.ToInt32(ddltab2_Class.SelectedValue == "" ? "0" : ddltab2_Class.SelectedValue);
            objdata.DateFrom = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.DateTo = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.IsActive = ddltab2_IsActive.SelectedValue == "1" ? true : false;
            objdata.PageSize = Gvtab2_ProxyManagerList.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetDailyProxyDetails(objdata);
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
            Gvtab2_ProxyManagerList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Gvtab2_ProxyManagerList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_ProxyManagerList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_ProxyManagerList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_ProxyManagerList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_ProxyManagerList.UseAccessibleHeader = true;
            Gvtab2_ProxyManagerList.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void Gvtab2_ProxyManagerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    DailyProxyManagerData ObjData = new DailyProxyManagerData();
                    DailyProxyManagerBO ObjBO = new DailyProxyManagerBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvtab2_ProxyManagerList.Rows[i];
                    Label IDs = (Label)gr.Cells[0].FindControl("Gv_lblID");
                    int ID = Convert.ToInt32(IDs.Text);
                    getproxydetailsbyid(ID);
                    Response.Redirect("~/EduHRAndPayroll/Payroll/DailyProxyManager.aspx", false);
                    btnAdd.Text = "Update";
                }
                if (e.CommandName == "Deletes")
                {
                    DailyProxyManagerData ObjData = new DailyProxyManagerData();
                    DailyProxyManagerBO ObjBO = new DailyProxyManagerBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvtab2_ProxyManagerList.Rows[i];
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
                    int Result = ObjBO.DeleteDailyProxyByID(ObjData);
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

        protected void getproxydetailsbyid(int ID)
        {
            DailyProxyManagerData ObjData = new DailyProxyManagerData();
            DailyProxyManagerBO ObjBO = new DailyProxyManagerBO();
            ObjData.ID = ID;
            List<DailyProxyManagerData> GetResult = ObjBO.GetDailyProxyByID(ObjData);
            if (GetResult.Count > 0)
            {
                ddlSession.SelectedValue = GetResult[0].YearID.ToString();
                txtEmployee.Text = GetResult[0].EmployeeName;
                lblEmployeeID.Text = GetResult[0].EmployeeID.ToString();
                lblEmployeeName.Text = GetResult[0].EmployeeName.ToString();
                txtProxyCharge.Text = GetResult[0].ProxyCharge.ToString("N");
                txtDate.Text = GetResult[0].Date.ToString("dd/MM/yyyy");
                txtProxyFor.Text = GetResult[0].ProxyForName;
                lblProxyForID.Text = GetResult[0].ProxyForID.ToString();
                lblProxyForName.Text = GetResult[0].ProxyForName;
                ddlClass.SelectedValue = GetResult[0].ClassID.ToString();
                txtReason.Text = GetResult[0].Reason.ToString();
                Session["ID"] = GetResult[0].ID.ToString();
            }
        }
        protected void Gvtab2_ProxyManagerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvtab2_ProxyManagerList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void btntab2_Cancel_Click(object sender, EventArgs e)
        {
            ClearAllTab2();
        }
        protected void ClearAllTab2()
        {
            lbltab2_Message.Text = "";
            lblresult.Text = "";
            ddltab2_Session.SelectedValue = LoginToken.AcademicSessionID.ToString();
            txttab2_EmpName.Text = "";
            lbltab2_EmpID.Text = "";
            ddltab2_Class.SelectedValue = "0";
            txtfrom.Text = "";
            txtto.Text = "";
            ddltab2_IsActive.SelectedIndex = 0;
            Gvtab2_ProxyManagerList.DataSource = null;
            Gvtab2_ProxyManagerList.DataBind();
        }
        protected void ddltab2_Session_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddltab2_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txtfrom_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddltab2_IsActive_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}