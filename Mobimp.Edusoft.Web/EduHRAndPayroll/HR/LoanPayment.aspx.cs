using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Common;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.HR
{
    public partial class LoanPayment : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
                lbl_EmployeeID.Visible = false;
                txt_LoanPaymentNo.Attributes["disabled"] = "disabled";
            }
        }

        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlLoanType, mstlookup.GetLookupsList(LookupNames.LoanType));
            Commonfunction.PopulateDdl(ddltab2_LoanType, mstlookup.GetLookupsList(LookupNames.LoanType));
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmployeeName(string prefixText, int count, string contextKey)
        {
            LoanPaymentData ObjData = new LoanPaymentData();
            LoanPaymentBO ObjBO = new LoanPaymentBO();
            List<LoanPaymentData> getResult = new List<LoanPaymentData>();
            ObjData.EmployeeName = prefixText;
            getResult = ObjBO.GetEmployeeName(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeName.ToString());
            }
            return list;
        }

        protected void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text != "")
            {
                var source = txtEmployeeName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    lbl_EmployeeID.Text = (ID == "" ? "0" : ID);
                }
                else
                {
                    txtEmployeeName.Text = "";
                    return;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("EnterEmployeeName") + "')", true);
                txtEmployeeName.Focus();
                return;
            }
            if (lbl_EmployeeID.Text == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("EmployeeID") + "')", true);
                txtEmployeeName.Focus();
                return;
            }
            if (ddlLoanType.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("LoanType") + "')", true);
                ddlLoanType.Focus();
                return;
            }
            if (txtLoanAmount.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("LoanAmount") + "')", true);
                txtLoanAmount.Focus();
                return;
            }

            var source = txtEmployeeName.Text.ToString();
            if (source.Contains(":"))
            {
                List<LoanPaymentData> getResult = new List<LoanPaymentData>();
                LoanPaymentData ObjData = new LoanPaymentData();
                LoanPaymentBO ObjBO = new LoanPaymentBO();
                string ID = source.Substring(source.LastIndexOf(':') + 1);
                if (lbl_EmployeeID.Text == ID)
                {
                    ObjData.EmployeeID = Convert.ToInt64(ID == "" ? "0" : ID);
                    ObjData.LoanTypeID = Convert.ToInt32(ddlLoanType.SelectedValue == "" ? "0" : ddlLoanType.SelectedValue);
                    ObjData.LoanAmount = Convert.ToDecimal(txtLoanAmount.Text == "" ? "0" : txtLoanAmount.Text);
                    ObjData.AddedBy = LoginToken.LoginId;
                    ObjData.UserId = LoginToken.UserLoginId;
                    ObjData.CompanyID = LoginToken.CompanyID;
                    ObjData.AcademicSessionID = LoginToken.AcademicSessionID;
                    getResult = ObjBO.SaveLoanPayment(ObjData);
                    if (getResult.Count >0)
                    {
                        txt_LoanPaymentNo.Text = getResult[0].LoanPaymentNo;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    }
                    else
                    {
                        txt_LoanPaymentNo.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("SaveError") + "')", true);
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("NotEqualEmpID") + "')", true);
                    txtEmployeeName.Text = "";
                    lbl_EmployeeID.Text = "";
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllTab1();
        }

        protected void ClearAllTab1()
        {
            lblmessage.Text = "";
            txtEmployeeName.Text = "";
            lbl_EmployeeID.Text = "";
            ddlLoanType.SelectedIndex = 0;
            txtLoanAmount.Text = "";
            txt_LoanPaymentNo.Text = "";
        }


        //----------------------------------End Tab 1----------------------------

        //----------------------------------Start Tab 2----------------------------

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmployeeNameTab2(string prefixText, int count, string contextKey)
        {
            LoanPaymentData ObjData = new LoanPaymentData();
            LoanPaymentBO ObjBO = new LoanPaymentBO();
            List<LoanPaymentData> getResult = new List<LoanPaymentData>();
            ObjData.EmployeeName = prefixText;
            getResult = ObjBO.GetEmployeeName(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeName.ToString());
            }
            return list;
        }

        protected void btntab2_Search_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<LoanPaymentData> lstHoliday = GetLoanRecordDetails(index, pagesize);
            if (lstHoliday.Count > 0)
            {
                Gvtab2_LoanRecordList.PageSize = pagesize;
                string record = lstHoliday[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstHoliday[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstHoliday[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gvtab2_LoanRecordList.VirtualItemCount = lstHoliday[0].MaximumRows;//total item is required for custom paging
                Gvtab2_LoanRecordList.PageIndex = index - 1;
                Gvtab2_LoanRecordList.DataSource = lstHoliday;
                Gvtab2_LoanRecordList.DataBind();
                Gvtab2_LoanRecordList.Visible = true;
                ds = ConvertToDataSet(lstHoliday);
                TableCell tableCell = Gvtab2_LoanRecordList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gvtab2_LoanRecordList.DataSource = null;
                Gvtab2_LoanRecordList.DataBind();
            }
        }

        public List<LoanPaymentData> GetLoanRecordDetails(int curIndex, int pagesize)
        {
            LoanPaymentData objdata = new LoanPaymentData();
            LoanPaymentBO objBO = new LoanPaymentBO();
            
            if (txttab2_EmpName.Text != "")
            {
                var source = txttab2_EmpName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    lbltab2_EmpID.Text = ID;
                }                
            }
            objdata.EmployeeID = Convert.ToInt64(lbltab2_EmpID.Text == "" ? "0" : lbltab2_EmpID.Text);
            objdata.LoanTypeID = Convert.ToInt32(ddltab2_LoanType.SelectedValue == "" ? "0" : ddltab2_LoanType.SelectedValue);
            objdata.LoanStatusID = Convert.ToInt32(ddltab2_LoanStatus.SelectedValue == "" ? "0" : ddltab2_LoanStatus.SelectedValue);
            objdata.IsActive = ddltab2_IsActive.SelectedValue == "1" ? true : false;
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.DateFrom = from;
            objdata.DateTo = To;            
            objdata.PageSize = Gvtab2_LoanRecordList.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetLoanRecordDetails(objdata);
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
            Gvtab2_LoanRecordList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Gvtab2_LoanRecordList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_LoanRecordList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_LoanRecordList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_LoanRecordList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_LoanRecordList.UseAccessibleHeader = true;
            Gvtab2_LoanRecordList.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void ClearAll()
        {
            txttab2_EmpName.Text = "";
            lbltab2_EmpID.Text = "";
            ddltab2_LoanType.SelectedIndex = 0;
            ddltab2_LoanStatus.SelectedIndex = 0;
            ddltab2_IsActive.SelectedIndex = 0;
            txtfrom.Text = "";
            txtto.Text = "";
        }

        protected void Gvtab2_LoanRecordList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "LoanRepayment")
                {
                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvtab2_LoanRecordList.Rows[i];
                    LinkButton PaymentNo = (LinkButton)gr.Cells[0].FindControl("Gvlbtn_LoanPaymentNo");
                    Label LoanStatusID = (Label)gr.Cells[0].FindControl("Gvlbl_LoanStatusID");
                    if (PaymentNo.Text != "" && LoanStatusID.Text == "1")
                    {
                        Session["PaymentNo"] = PaymentNo.Text;
                        Response.Redirect("/EduHRAndPayroll/HR/LoanRepayment.aspx", false);
                    }
                    else if (PaymentNo.Text != "" && LoanStatusID.Text == "2")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("RepayCompleted") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("InvalidPaymentNo") + "')", true);
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    LoanPaymentData objData = new LoanPaymentData();
                    LoanPaymentBO objBO = new LoanPaymentBO();
                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvtab2_LoanRecordList.Rows[i];
                    LinkButton PaymentNo = (LinkButton)gr.Cells[0].FindControl("Gvlbtn_LoanPaymentNo");
                    TextBox Remark = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (Remark.Text=="")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        return;
                    }

                    objData.LoanPaymentNo = PaymentNo.Text == null ? "" : PaymentNo.Text;
                    objData.Remark = Remark.Text == null ? "" : Remark.Text;
                    objData.AddedBy = LoginToken.LoginId;
                    objData.UserId = LoginToken.UserLoginId;
                    objData.CompanyID = LoginToken.CompanyID;
                    objData.AcademicSessionID = LoginToken.AcademicSessionID;

                    int result = objBO.DeleteLoanByPaymentNo(objData);
                    if (result==1)
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
            catch(Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void Gvtab2_LoanRecordList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LoanPaymentData objdata = new LoanPaymentData();
                    LoanPaymentBO objBO = new LoanPaymentBO();
                    LinkButton PaymentNo = (LinkButton)e.Row.FindControl("Gvlbtn_LoanPaymentNo");
                    Label IsProcess = (Label)e.Row.FindControl("GVlbl_IsProcess");
                    Button DeleteButton = (Button)e.Row.FindControl("btn_delete");
                    Label LoanStatusID = (Label)e.Row.FindControl("Gvlbl_LoanStatusID");
                    Label LoanStatus = (Label)e.Row.FindControl("Gvlbl_LoanStatus");
                    if (IsProcess.Text=="1")
                    {
                        DeleteButton.Visible = false;
                    }
                    else
                    {
                        DeleteButton.Visible = true;
                    }
                    if (LoanStatusID.Text == "1")
                    {
                        
                        LoanStatus.ForeColor = System.Drawing.Color.Blue;
                        //LoanStatus.BackColor = System.Drawing.Color.Blue;
                        //LoanStatus.ForeColor = System.Drawing.Color.White;
                        //PaymentNo.ForeColor = System.Drawing.Color.Blue;                        
                    }
                    else if (LoanStatusID.Text=="2")
                    {
                        LoanStatus.ForeColor = System.Drawing.Color.Green;
                        PaymentNo.Attributes["disabled"] = "disabled";
                        PaymentNo.ForeColor = System.Drawing.Color.Green;
                        //LoanStatus.BackColor = System.Drawing.Color.Green;
                        //LoanStatus.ForeColor = System.Drawing.Color.White;
                        //PaymentNo.Attributes["disabled"] = "disabled";
                        //PaymentNo.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        LoanStatus.ForeColor = System.Drawing.Color.Yellow;
                        PaymentNo.Attributes["disabled"] = "disabled";
                        PaymentNo.ForeColor = System.Drawing.Color.Yellow;
                        //LoanStatus.BackColor = System.Drawing.Color.Yellow;  // Something went wrong
                        //LoanStatus.ForeColor = System.Drawing.Color.White;
                        //PaymentNo.Attributes["disabled"] = "disabled";
                        //PaymentNo.ForeColor = System.Drawing.Color.Yellow;
                    }


                    objdata.LoanPaymentNo = PaymentNo.Text.Trim();
                    List<LoanPaymentData> GetResult = objBO.SearchChildPaymentRecordDetails(objdata);
                    if (GetResult.Count > 0)
                    {
                        GridView SC = (GridView)e.Row.FindControl("GridChildRecordDetails");
                        SC.DataSource = GetResult;
                        SC.DataBind();
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

        protected void btntab2_Cancel_Click(object sender, EventArgs e)
        {
            ClearAllTab2();
        }

        protected void ClearAllTab2()
        {
            txttab2_EmpName.Text = "";
            ddltab2_LoanType.SelectedIndex = 0;
            ddltab2_LoanStatus.SelectedIndex = 0;
            ddltab2_IsActive.SelectedIndex = 0;
            txtfrom.Text = "";
            txtto.Text = "";
            lblmessage.Text = "";
            lblresult.Text = "";
            Gvtab2_LoanRecordList.DataSource = null;
            Gvtab2_LoanRecordList.DataBind();
            Gvtab2_LoanRecordList.Visible = false;
        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void Gvtab2_LoanRecordList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvtab2_LoanRecordList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }


        //----------------------------------End Tab 2----------------------------

    }
}