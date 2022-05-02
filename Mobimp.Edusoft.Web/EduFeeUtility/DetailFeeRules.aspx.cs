using Mobimp.Campusoft.BussinessProcess.EduFeeUtility;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Data.EduFeeUtility;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;


using System.Web.UI;

using System.Web.UI.WebControls;

namespace Mobimp.Edusoft.Web.EduFeeUtility
{
    public partial class DetailFeeRules : BasePage
    {
        DataSet ds = new DataSet();
        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlfeetypes, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            ddlsessionID.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlnoemipop4, mstlookup.GetEMIByAcademicYear(LoginToken.AcademicSessionID));
            Commonfunction.PopulateDdl(ddlcategoryIDpop6, mstlookup.GetLookupsList(LookupNames.FeeTypeCategory));

            for (int i = 0; i < 29; i++)
            {
                ddlprepaidpop3.Items.Insert(i, new ListItem((i).ToString(), (i).ToString()));
            }
            for (int i = 0; i < 29; i++)
            {
                ddlpostpaidpop3.Items.Insert(i, new ListItem((i).ToString(), (i).ToString()));
            }

        }
        public List<FeeDetailRulesData> GetFeeDetails(int curIndex, int pagesize)
        {
            FeeDetailRulesData objfees = new FeeDetailRulesData();
            FeeDetailRulesBO objFeeBO = new FeeDetailRulesBO();
            objfees.AcademicSessionID = Convert.ToInt32(ddlsessionID.SelectedValue == "" ? "0" : ddlsessionID.SelectedValue);
            objfees.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objfees.FeeTypeID = Convert.ToInt32(ddlfeetypes.SelectedValue == "" ? "0" : ddlfeetypes.SelectedValue);
            objfees.ID = Convert.ToInt32(lblhiddenID.Text == "" ? "0" : lblhiddenID.Text);
            objfees.ActionType = EnumActionType.Select;
            objfees.PageSize = pagesize;
            objfees.CurrentIndex = curIndex;
            return objFeeBO.SearchFeesDetails(objfees);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<FeeDetailRulesData> FeeDetails = GetFeeDetails(index, pagesize);
            if (FeeDetails.Count > 0)
            {

                GvDetailFee.PageSize = pagesize;
                string record = FeeDetails[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + FeeDetails[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = FeeDetails[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvDetailFee.VirtualItemCount = FeeDetails[0].MaximumRows;//total item is required for custom paging
                GvDetailFee.PageIndex = index - 1;
                GvDetailFee.DataSource = FeeDetails;
                GvDetailFee.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(FeeDetails);
            }
            else
            {
                GvDetailFee.DataSource = null;
                GvDetailFee.DataBind();
            }
        }
        protected void GvDetailFee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvDetailFee.Rows[i];

                Label ID = (Label)gr.Cells[0].FindControl("lblID");
                Label SessionID = (Label)gr.Cells[0].FindControl("lblsessionID");
                Label Session = (Label)gr.Cells[0].FindControl("lblsession");
                Label ClassID = (Label)gr.Cells[0].FindControl("lblclassID");
                Label Class = (Label)gr.Cells[0].FindControl("lblclasss");
                Label FeeTypeID = (Label)gr.Cells[0].FindControl("lblfeetypeID");
                Label FeeType = (Label)gr.Cells[0].FindControl("lblfeetypess");
                Label CategoryID = (Label)gr.Cells[0].FindControl("lblcategoryID");
                Label Category = (Label)gr.Cells[0].FindControl("lblcategorys");
                Label noemi = (Label)gr.Cells[0].FindControl("lbl_noemi");

                DropDownList ddlpayment = (DropDownList)gr.Cells[0].FindControl("ddlpaymenttype");
                Label lblpayment = (Label)gr.Cells[0].FindControl("lblpaymenttype");
                Label IsFeeStructure = (Label)gr.Cells[0].FindControl("lblfeestructure");
                TextBox NewFeeAmount = (TextBox)gr.Cells[0].FindControl("txtfeeamount_newstudent");
                TextBox OldFeeAmount = (TextBox)gr.Cells[0].FindControl("txtfeeamount_oldstudent");

                lblhiddenID.Text = Convert.ToString(ID.Text == "" ? "0" : ID.Text);
                lblhiddensessionID.Text = Convert.ToString(SessionID.Text == "" ? "0" : SessionID.Text);
                lblhiddensession.Text = Convert.ToString(Session.Text == "" ? "0" : Session.Text);
                lblhiddenclassID.Text = Convert.ToString(ClassID.Text == "" ? "0" : ClassID.Text);
                lblhiddenclass.Text = Convert.ToString(Class.Text == "" ? "0" : Class.Text);
                lblhiddenfeetypeID.Text = Convert.ToString(FeeTypeID.Text == "" ? "0" : FeeTypeID.Text);
                lblhiddenfeetype.Text = Convert.ToString(FeeType.Text == "" ? "0" : FeeType.Text);
                lblhiddencategoryID.Text = Convert.ToString(CategoryID.Text == "" ? "0" : CategoryID.Text);
                lblhiddencategory.Text = Convert.ToString(Category.Text == "" ? "0" : Category.Text);
                lblhiddenpaymentID.Text = Convert.ToString(ddlpayment.SelectedValue == "" ? "0" : ddlpayment.SelectedValue);
                lblhiddenNewFeeAmount.Text = NewFeeAmount.Text;
                lblhiddenOldFeeAmount.Text = OldFeeAmount.Text;
                lblhiddennoemi.Text = Convert.ToString(noemi.Text == "" ? "1" : noemi.Text);

                int IsFeeStruncture = Convert.ToInt32(IsFeeStructure.Text);
                int Pop_SessionID = Convert.ToInt32(SessionID.Text == "" ? "0" : SessionID.Text);
                int Pop_ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                int Pop_CategoryID = Convert.ToInt32(CategoryID.Text == "" ? "0" : CategoryID.Text);
                int Pop_FeeTypeID = Convert.ToInt32(FeeTypeID.Text == "" ? "0" : FeeTypeID.Text);

                lblhiddensessionID.Text = Pop_SessionID.ToString();
                lblhiddenclassID.Text = Pop_ClassID.ToString();
                lblhiddencategoryID.Text = Pop_CategoryID.ToString();
                lblhiddenfeetypeID.Text = Pop_FeeTypeID.ToString();

                int Pop_AddRow = 0;
                if (e.CommandName == "FeeStructure")
                {
                    if (ddlpayment.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Payment Type") + "')", true);
                        return;
                    }
                    if (ddlpayment.SelectedValue == "1")
                    {
                        lblsessionIDpop12.Text = lblhiddensession.Text;
                        lblclasspop12.Text = lblhiddenclass.Text;
                        lblcategorypop12.Text = lblhiddencategory.Text;
                        lblfeetypespop12.Text = lblhiddenfeetype.Text;
                        int Pop_PayemntID = 1;
                        GetOneTimePaymentList(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID, Pop_PayemntID, Pop_AddRow);
                        this.ModalPopupExtender1.Show();
                    }
                    if (ddlpayment.SelectedValue == "2")
                    {
                        lblsessionIDpop3.Text = lblhiddensession.Text;
                        lblclassIDpop3.Text = lblhiddenclass.Text;
                        lblcategoryIDpop3.Text = lblhiddencategory.Text;
                        lblfeetypeIDpop3.Text = lblhiddenfeetype.Text;
                        int Pop_PayemntID = 2;
                        GetMonthlyPayment(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID, Pop_PayemntID);
                        this.ModalPopupExtender3.Show();
                    }
                    if (ddlpayment.SelectedValue == "3")
                    {
                        lblsessionIDpop4.Text = lblhiddensession.Text;
                        lblclassIDpop4.Text = lblhiddenclass.Text;
                        lblcategoryIDpop4.Text = lblhiddencategory.Text;
                        lblfeetypeIDpop4.Text = lblhiddenfeetype.Text;
                        int Pop_PayemntID = 3;
                        GetEMIPayment(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID, Pop_PayemntID);
                        this.ModalPopupExtender4.Show();
                    }
                }
                if (e.CommandName == "ExemptionRule")
                {
                    lblsessionIDpop5.Text = lblhiddensession.Text;
                    lblclassIDpop5.Text = lblhiddenclass.Text;
                    lblcategoryIDpop5.Text = lblhiddencategory.Text;
                    lblfeetypeIDpop5.Text = lblhiddenfeetype.Text;
                    GetExemptionRule(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID);
                    this.ModalPopupExtender5.Show();
                }
                if (e.CommandName == "InclusiveRule")
                {
                    lblsessionIDpop62.Text = lblhiddensession.Text;
                    lblclassIDpop62.Text = lblhiddenclass.Text;
                    lblsessionIDpop62.Text = lblhiddensession.Text;
                    lblcategoryIDpop62.Text = lblhiddencategory.Text;
                    lblfeetypeIDpop62.Text = lblhiddenfeetype.Text;
                    GetInclusiveOtherFeeTypes(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID);
                    this.ModalPopupExtender62.Show();
                }
                if (e.CommandName == "Deletes")
                {
                    FeeDetailRulesData objfees = new FeeDetailRulesData();
                    FeeDetailRulesBO objFeeBO = new FeeDetailRulesBO();
                    objfees.ID = Convert.ToInt32(ID.Text);
                    int Result = objFeeBO.DeleteFeeDetailsByID(objfees);
                    if (Result == 1)
                    {
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                    }
                    else
                    {
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
            //divsearch.Visible = true;
        }
        protected void GvDetailFee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            List<LookupItem> lookpayment = objmstlookupBO.GetLookupsList(LookupNames.PaymentType);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label PaymentType = (Label)e.Row.FindControl("lblpaymenttype");
                    DropDownList ddlPayment = (DropDownList)e.Row.FindControl("ddlpaymenttype");
                    Label FeeStructurestatus = (Label)e.Row.FindControl("lblfeestructure");
                    LinkButton lnlbtnFeeStructure = (LinkButton)e.Row.FindControl("lnlfeestructure");
                    Label Exemptionstatus = (Label)e.Row.FindControl("lblexemptionrule");
                    LinkButton lnlExemption = (LinkButton)e.Row.FindControl("lnlexemptionrule");
                    Label Inclusivestatus = (Label)e.Row.FindControl("lblinclusiverule");
                    LinkButton lnlInclusive = (LinkButton)e.Row.FindControl("lnlinclusiverule");
                    Label lblStudentType = (Label)e.Row.FindControl("lblstudenttypeapply");
                    CheckBox ChkStudentType = (CheckBox)e.Row.FindControl("chkstudenttypeapply");
                    Label lblActivate = (Label)e.Row.FindControl("lblactivate");
                    CheckBox ChkActivate = (CheckBox)e.Row.FindControl("chkactivate");

                    //TextBox txt_FeeAmountOld = (TextBox)e.Row.FindControl("txtfeeamount_oldstudent");
                    //TextBox txt_FeeAmountNew = (TextBox)e.Row.FindControl("txtfeeamount_newstudent");

                    //Int64 FeeAmountOld = Convert.ToInt64(txt_FeeAmountOld.Text);
                    //Int64 FeeAmountNew = Convert.ToInt64(txt_FeeAmountNew.Text);

                    Commonfunction.PopulateDdl(ddlPayment, lookpayment);

                    if (PaymentType.Text != "")
                    {
                        ddlPayment.Items.FindByValue(PaymentType.Text).Selected = true;
                    }
                    if (FeeStructurestatus.Text == "0")
                    {
                        lnlbtnFeeStructure.Text = "Make";
                        lnlbtnFeeStructure.CssClass = "btn btn-warning cus_btn";
                    }
                    if (FeeStructurestatus.Text == "1")
                    {
                        lnlbtnFeeStructure.Text = "Edit";
                        lnlbtnFeeStructure.CssClass = "btn btn-success cus_btn";
                    }
                    if (Exemptionstatus.Text == "0")
                    {
                        lnlExemption.Text = "Make";
                        lnlExemption.CssClass = "btn btn-warning cus_btn";
                    }
                    if (Exemptionstatus.Text == "1")
                    {
                        lnlExemption.Text = "Edit";
                        lnlExemption.CssClass = "btn btn-success cus_btn";
                    }
                    if (Inclusivestatus.Text == "0")
                    {
                        lnlInclusive.Text = "Make";
                        lnlInclusive.CssClass = "btn btn-warning cus_btn";
                    }
                    if (Inclusivestatus.Text == "1")
                    {
                        lnlInclusive.Text = "Edit";
                        lnlInclusive.CssClass = "btn btn-success cus_btn";
                    }
                    if (lblStudentType.Text == "1")
                    {
                        ChkStudentType.Checked = true;
                    }
                    else
                    {
                        ChkStudentType.Checked = false;
                    }
                    if (lblActivate.Text == "True")
                    {
                        ChkActivate.Checked = true;
                    }
                    else
                    {
                        ChkActivate.Checked = false;
                    }

                    if (PaymentType.Text == "2" || PaymentType.Text == "3")
                    {
                        lnlInclusive.Visible = false;
                        //txt_FeeAmountOld.Text = Convert.ToString(Commonfunction.Getrounding(Convert.ToString(Convert.ToInt64(FeeAmountOld) / 12)));
                        //txt_FeeAmountNew.Text = Convert.ToString(Commonfunction.Getrounding(Convert.ToString(Convert.ToInt64(FeeAmountNew) / 12)));
                    }
                    else
                    {
                        lnlInclusive.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                FeeDetailRulesData objfees = new FeeDetailRulesData();
                FeeDetailRulesBO objtypes = new FeeDetailRulesBO();
                objfees.SessionID = Convert.ToInt32(ddlsessionID.SelectedValue == "" ? "0" : ddlsessionID.SelectedValue);
                objfees.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objfees.FeeTypeID = Convert.ToInt32(ddlfeetypes.SelectedValue == "" ? "0" : ddlfeetypes.SelectedValue);
                objfees.AddedBy = LoginToken.LoginId;
                objfees.UserId = LoginToken.UserLoginId;
                objfees.CompanyID = LoginToken.CompanyID;
                int result = objtypes.SaveFeeDetails(objfees);
                if (result == 1)
                {
                    ddlfeetypes.SelectedIndex = 0;
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void chkactivate_CheckedChanged(object sender, EventArgs e)
        {

            FeeDetailRulesData objdetail = new FeeDetailRulesData();
            FeeDetailRulesBO objdetailBO = new FeeDetailRulesBO();
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;

            Label Lb_SessionID = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblsessionID");
            Label Lb_ClassID = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblclassID");
            Label LbCategoryID = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblcategoryID");
            Label LbFeeTypeID = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblfeetypeID");
            Label Lb_PaymentID = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblpaymenttype");

            Label feestructurestatus = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblfeestructure");
            Label feeexemptionstatus = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblexemptionrule");

            Label ID = (Label)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("lblID");
            DropDownList ddlpayment = (DropDownList)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("ddlpaymenttype");
            TextBox newfeeamount = (TextBox)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("txtfeeamount_newstudent");
            TextBox oldfeeamount = (TextBox)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("txtfeeamount_oldstudent");
            CheckBox isstudenttype = (CheckBox)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("chkstudenttypeapply");
            TextBox heirarchy = (TextBox)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("txtheirarchy");
            CheckBox isactivate = (CheckBox)GvDetailFee.Rows[row.RowIndex].Cells[0].FindControl("chkactivate");

            if (ddlpayment.SelectedValue == "0")
            {
                isactivate.Checked = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Payment Type") + "')", true);
                return;
            }
            objdetail.ID = Convert.ToInt32(ID.Text);
            objdetail.PaymentTypeID = Convert.ToInt32(ddlpayment.SelectedValue == "" ? "0" : ddlpayment.SelectedValue);
            objdetail.FeeNewStudent = Convert.ToDecimal(newfeeamount.Text == "" ? "00" : newfeeamount.Text.Trim());
            objdetail.FeeOldStudent = Convert.ToDecimal(oldfeeamount.Text == "" ? "00" : oldfeeamount.Text.Trim());
            if (isstudenttype.Checked == true)
            {
                objdetail.IsStudentTypeApply = 1;
            }
            else
            {
                objdetail.IsStudentTypeApply = 0;
            }
            objdetail.FeeHeirarchy = Convert.ToInt32(heirarchy.Text == "" ? "0" : heirarchy.Text.Trim());
            if (isactivate.Checked == true)
            {
                objdetail.IsActivate = true;

            }
            else
            {
                objdetail.IsActivate = false;
            }

            objdetail.AcademicSessionID = Convert.ToInt32(Lb_SessionID.Text);
            objdetail.ClassID = Convert.ToInt32(Lb_ClassID.Text);
            objdetail.CategoryID = Convert.ToInt32(LbCategoryID.Text);
            objdetail.FeeTypeID = Convert.ToInt32(LbFeeTypeID.Text);

            objdetail.UserId = LoginToken.UserLoginId;
            objdetail.CompanyID = LoginToken.CompanyID;

            if (feestructurestatus.Text == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please make fee structure rule. ") + "')", true);
                isactivate.Checked = false;
                return;
            }
            if (feeexemptionstatus.Text == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please make fee exemption rule. ") + "')", true);
                isactivate.Checked = false;
                return;
            }
            int result = objdetailBO.UpdateFeeDetails(objdetail);
            if (result == 2)
            {
                GvExtraRule.DataBind();
                bindgrid(1);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                ViewState["ID"] = null;
            }
            if (result == 4)
            {
                GvExtraRule.DataSource = null;
                GvExtraRule.DataBind();
                bindgrid(1);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Already Exists Active Payment Type.") + "')", true);
            }
            else
            {
                GvExtraRule.DataSource = null;
                GvExtraRule.DataBind();
                bindgrid(1);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
        }
        protected void bindresponsive()
        {

        }
        protected void ExportoExcel()
        {
            //DataTable dt = GetDatafromDatabase();
        }
        //protected DataTable GetDatafromDatabase()
        //{
        //}
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
            bindgrid(1);
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void GvDetailFee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDetailFee.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void clearall()
        {
            ddlfeetypes.SelectedIndex = 0;
            ddlclass.SelectedIndex = 0;
            GvDetailFee.DataSource = null;
            bindgrid(1);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlfeetypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        //---------OneTimePayment------------//
        public void GetOneTimePaymentList(int SessionID, int ClassID, int CategoryID, int FeeTypeID, int PaymentID, int AddRow)
        {
            OneTimePaymentData objonetime = new OneTimePaymentData();
            OneTimePaymentBO objonetimeBO = new OneTimePaymentBO();
            objonetime.AcademicSessionID = SessionID;
            objonetime.ClassID = ClassID;
            objonetime.CategoryID = CategoryID;
            objonetime.FeeTypeID = FeeTypeID;
            objonetime.PaymentID = PaymentID;
            objonetime.AddRow = AddRow;
            List<OneTimePaymentData> result = objonetimeBO.GetOneTimePaymentList(objonetime);
            if (result.Count > 0)
            {
                txtdiscountlimit.Text = Commonfunction.Getrounding(result[0].DiscountLimit.ToString());
                txtduedatepop1.Text = result[0].DueDate.ToString();
                txtfinepop1.Text = Commonfunction.Getrounding(result[0].Fine.ToString());
                GvOneTimeFee.DataSource = result;
                GvOneTimeFee.DataBind();
            }
            else
            {
                txtdiscountlimit.Text = "";
                txtduedatepop1.Text = "";
                txtfinepop1.Text = "";
                GvOneTimeFee.DataSource = null;
                GvOneTimeFee.DataBind();
            }
        }
        public void BindOneTimePayment()
        {
            int Pop1_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop1_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            int Pop1_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop1_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);

            int Pop1_PaymentID = Convert.ToInt32(lblhiddenpaymentID.Text);
            int Pop1_AddRow = 0;
            GetOneTimePaymentList(Pop1_SessionID, Pop1_ClassID, Pop1_CategoryID, Pop1_FeeTypeID, Pop1_PaymentID, Pop1_AddRow);
        }
        decimal TotalAmount_NewStudent = 0;
        decimal TotalAmount_OldStudent = 0;
        protected void GvOneTimeFee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label amountnewstudent = (Label)e.Row.FindControl("lbl_totalnew");
                TotalAmount_NewStudent = Convert.ToDecimal(amountnewstudent.Text);
                Label amountoldstudent = (Label)e.Row.FindControl("lbl_totalold");
                TotalAmount_OldStudent = Convert.ToDecimal(amountoldstudent.Text);

                Label IsActivate = (Label)e.Row.FindControl("lblactivatepop1");
                CheckBox ChkIsActivate = (CheckBox)e.Row.FindControl("chkactivatepop1");
                if (IsActivate.Text == "True")
                {
                    ChkIsActivate.Checked = true;
                }
                else
                {
                    ChkIsActivate.Checked = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                Label totalnew_footer = (Label)e.Row.FindControl("lbl_totalfee_new_fotter");
                totalnew_footer.Text = TotalAmount_NewStudent.ToString();

                Label totalold_footer = (Label)e.Row.FindControl("lbl_totalfee_old_fotter");
                totalold_footer.Text = TotalAmount_OldStudent.ToString();
            }
        }
        protected void btnsaveonetime_Click(object sender, EventArgs e)
        {
            List<OneTimePaymentData> OneTimeFeeList = new List<OneTimePaymentData>();
            OneTimePaymentData objonetime = new OneTimePaymentData();
            OneTimePaymentBO objonetimeBO = new OneTimePaymentBO();
            int check = 0;
            Decimal totalnewstudent = 0;
            Decimal totaloldstudent = 0;
            foreach (GridViewRow row in GvOneTimeFee.Rows)
            {
                Label OneTimeID = (Label)GvOneTimeFee.Rows[row.RowIndex].Cells[0].FindControl("lblonetimeID");
                TextBox Particulars = (TextBox)GvOneTimeFee.Rows[row.RowIndex].Cells[0].FindControl("txtParticulars");
                TextBox NewFeeAmount = (TextBox)GvOneTimeFee.Rows[row.RowIndex].Cells[0].FindControl("txtnewfeeamount");
                TextBox OldFeeAmount = (TextBox)GvOneTimeFee.Rows[row.RowIndex].Cells[0].FindControl("txtoldfeeamount");
                CheckBox IsActivate = (CheckBox)GvOneTimeFee.Rows[row.RowIndex].Cells[0].FindControl("chkactivatepop1");
                OneTimePaymentData objXmlonetime = new OneTimePaymentData();
                objXmlonetime.OnetimeID = Convert.ToInt32(OneTimeID.Text);
                objXmlonetime.Particulars = Convert.ToString(Particulars.Text);
                objXmlonetime.FeeAmount_New = Convert.ToDecimal(NewFeeAmount.Text);
                objXmlonetime.FeeAmount_Old = Convert.ToDecimal(OldFeeAmount.Text);
                if (IsActivate.Checked == true)
                {
                    objXmlonetime.IsActivate = true;
                    totalnewstudent = totalnewstudent + Convert.ToDecimal(NewFeeAmount.Text == "" ? "0.0" : NewFeeAmount.Text);
                    totaloldstudent = totaloldstudent + Convert.ToDecimal(OldFeeAmount.Text == "" ? "0.0" : OldFeeAmount.Text);
                }
                else
                {
                    objXmlonetime.IsActivate = false;
                }
                OneTimeFeeList.Add(objXmlonetime);
                check++;
            }
            objonetime.XMLData = XmlConvertor.OneTimeFeetoXML(OneTimeFeeList).ToString();
            objonetime.DiscountLimit = Convert.ToDecimal(txtdiscountlimit.Text == "" ? "0" : txtdiscountlimit.Text);
            objonetime.DueDate = txtduedatepop1.Text.Trim();
            objonetime.Fine = Convert.ToDecimal(txtfinepop1.Text == "" ? "0" : txtfinepop1.Text);
            objonetime.ID = Convert.ToInt32(lblhiddenID.Text == "" ? "0" : lblhiddenID.Text);
            objonetime.AcademicSessionID = Convert.ToInt32(lblhiddensessionID.Text);
            objonetime.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objonetime.CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            objonetime.FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            objonetime.UserId = LoginToken.UserLoginId;
            objonetime.CompanyID = LoginToken.CompanyID;
            if (Convert.ToDecimal(txtdiscountlimit.Text == "" ? "0.0" : txtdiscountlimit.Text) > Convert.ToDecimal(totalnewstudent))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Discount limit could not be greater than total amount. ") + "')", true);
                this.ModalPopupExtender1.Show();
                return;
            }
            if (Convert.ToDecimal(txtdiscountlimit.Text == "" ? "0.0" : txtdiscountlimit.Text) > Convert.ToDecimal(totaloldstudent))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Discount limit could not be greater than total amount. ") + "')", true);
                this.ModalPopupExtender1.Show();
                return;
            }
            if (Convert.ToDecimal(txtfinepop1.Text == "" ? "0.0" : txtfinepop1.Text) > Convert.ToDecimal(totalnewstudent))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("fine amount could not be greater than total amount. ") + "')", true);
                this.ModalPopupExtender1.Show();
                return;
            }
            if (Convert.ToDecimal(txtfinepop1.Text == "" ? "0.0" : txtfinepop1.Text) > Convert.ToDecimal(totaloldstudent))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("fine amount could not be greater than total amount. ") + "')", true);
                this.ModalPopupExtender1.Show();
                return;
            }
            int result = objonetimeBO.UpdateOneTimePayment(objonetime);
            if (result == 2)
            {
                BindOneTimePayment();
                GvOneTimeFee.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
            }
            else
            {
                BindOneTimePayment();
                GvOneTimeFee.DataSource = null;
                GvOneTimeFee.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
            this.ModalPopupExtender1.Show();
        }
        protected void btnaddrowpop1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvDetailFee.Rows)
            {
                int SessionID = Convert.ToInt32(lblhiddensessionID.Text);
                int CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
                int FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
                int ClassID = Convert.ToInt32(lblhiddenclassID.Text);


                int PaymentID = Convert.ToInt32(lblhiddenpaymentID.Text);
                int AddRow = 1;
                if (GvDetailFee.Rows.Count == row.RowIndex + 1)
                {
                    GetOneTimePaymentList(SessionID, CategoryID, FeeTypeID, ClassID, PaymentID, AddRow);

                }
            }
            this.ModalPopupExtender1.Show();
        }
        protected void GvOneTimeFee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvOneTimeFee.Rows[i];
                if (e.CommandName == "Deletespop1")
                {
                    OneTimePaymentData objonetime = new OneTimePaymentData();
                    OneTimePaymentBO objonetimeBO = new OneTimePaymentBO();
                    Label ID = (Label)gr.Cells[0].FindControl("lblonetimeID");
                    objonetime.OnetimeID = Convert.ToInt32(ID.Text);
                    int Result = objonetimeBO.DeleteOneTimeByID(objonetime);
                    if (Result == 1)
                    {
                        BindOneTimePayment();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                    }
                    else
                    {
                        BindOneTimePayment();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                }
                this.ModalPopupExtender1.Show();
            }
            catch
            {

            }
        }
        protected void lnlextrarulepop1_Click(object sender, EventArgs e)
        {
            BindExtraRule();
            this.ModalPopupExtender2.Show();
        }
        protected void lnbtnclosePopup1_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnOneTimepayment_Click(object sender, EventArgs e)
        {
            string url = "../EduFeeUtility/Reports/ReportViewer.aspx?option=OneTimePayment&AcademicSessionID=" + lblhiddensessionID.Text + "&ClassID=" + lblhiddenclassID.Text + "&CategoryID=" + lblhiddencategoryID.Text + "&FeeTypeID=" + lblhiddenfeetypeID.Text;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            this.ModalPopupExtender1.Show();
        }
        //---------ExtraRule------------//
        protected void GetExtraRule(int SessionID, int CategoryID, int FeeTypeID, int ClassID, int AddRow)
        {
            ExtraFeeRuleData objextra = new ExtraFeeRuleData();
            ExtraFeeRuleBO objextraBO = new ExtraFeeRuleBO();
            objextra.AcademicSessionID = SessionID;
            objextra.CategoryID = CategoryID;
            objextra.FeeTypeID = FeeTypeID;
            objextra.ClassID = ClassID;
            objextra.AddRow = AddRow;
            if (ChkIsMiscpop2.Checked)
            {
                chkIsOptionalpop2.Checked = false;
                ChkIsMiscpop2.Checked = true;
                objextra.IsMisc = 1;
                objextra.IsOptional = 0;
            }
            else
            {
                chkIsOptionalpop2.Checked = true;
                ChkIsMiscpop2.Checked = false;
                objextra.IsOptional = 1;
                objextra.IsMisc = 0;
            }
            List<ExtraFeeRuleData> result = objextraBO.GetExtraRule(objextra);
            if (result.Count > 0)
            {
                GvExtraRule.DataSource = result;
                GvExtraRule.DataBind();
            }
            else
            {
                GvExtraRule.DataSource = null;
                GvExtraRule.DataBind();
            }
        }
        public void BindExtraRule()
        {
            int Pop2_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop2_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop2_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            int Pop2_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            int Pop2_AddRow = 0;
            lblsessionIDpop22.Text = lblhiddensession.Text;
            lblcategorypop22.Text = lblhiddencategory.Text;
            lblfeetypespop22.Text = lblhiddenfeetype.Text;

            GetExtraRule(Pop2_SessionID, Pop2_CategoryID, Pop2_FeeTypeID, Pop2_ClassID, Pop2_AddRow);
        }
        protected void chkIsOptionalpop2_CheckedChanged(object sender, EventArgs e)
        {
            ChkIsMiscpop2.Checked = false;
            BindExtraRule();
            this.ModalPopupExtender2.Show();
        }
        protected void ChkIsMiscpop2_CheckedChanged(object sender, EventArgs e)
        {
            chkIsOptionalpop2.Checked = false;
            BindExtraRule();
            this.ModalPopupExtender2.Show();
        }
        protected void btnaddrowpop2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvExtraRule.Rows)
            {
                int SessionID = Convert.ToInt32(lblhiddensessionID.Text);
                int CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
                int FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
                int ClassID = Convert.ToInt32(lblhiddenclassID.Text);
                int AddRow = 1;
                if (GvExtraRule.Rows.Count == row.RowIndex + 1)
                {
                    GetExtraRule(SessionID, CategoryID, FeeTypeID, ClassID, AddRow);
                }
            }
            this.ModalPopupExtender2.Show();
        }
        protected void btnsaveextra_Click(object sender, EventArgs e)
        {
            List<ExtraFeeRuleData> ExtraRuleList = new List<ExtraFeeRuleData>();
            ExtraFeeRuleData objextra = new ExtraFeeRuleData();
            ExtraFeeRuleBO objextraBO = new ExtraFeeRuleBO();
            int check = 0;
            foreach (GridViewRow row in GvExtraRule.Rows)
            {
                Label Subject = (Label)GvExtraRule.Rows[row.RowIndex].Cells[0].FindControl("lblsubjectpop2");
                DropDownList ddlsubject = (DropDownList)GvExtraRule.Rows[row.RowIndex].Cells[0].FindControl("ddlSubjectpop2");
                TextBox Misc = (TextBox)GvExtraRule.Rows[row.RowIndex].Cells[0].FindControl("txtMiscpop2");
                TextBox Amount = (TextBox)GvExtraRule.Rows[row.RowIndex].Cells[0].FindControl("txtpop2Amount");
                CheckBox IsActivate = (CheckBox)GvExtraRule.Rows[row.RowIndex].Cells[0].FindControl("chkactivatepop2");
                Label ID = (Label)GvExtraRule.Rows[row.RowIndex].Cells[0].FindControl("lblpop2ID");
                ExtraFeeRuleData objXmlextra = new ExtraFeeRuleData();
                if (chkIsOptionalpop2.Checked)
                {
                    objXmlextra.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
                    objXmlextra.Miscellaneous = "";
                }
                if (ChkIsMiscpop2.Checked)
                {
                    objXmlextra.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
                    objXmlextra.Miscellaneous = Convert.ToString(Misc.Text.Trim() == "" ? "NULL" : Misc.Text.Trim());
                }

                objXmlextra.Amount = Convert.ToDecimal(Amount.Text);
                if (IsActivate.Checked == true)
                {
                    objXmlextra.IsActivate = true;
                }
                else
                {
                    objXmlextra.IsActivate = false;
                }
                if (Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue) != 0)
                {
                    ExtraRuleList.Add(objXmlextra);
                }
                if (Misc.Text.Trim() != "")
                {
                    ExtraRuleList.Add(objXmlextra);
                }
                objXmlextra.ID = Convert.ToInt32(ID.Text);
                check++;
            }
            objextra.XMLData = XmlConvertor.ExtraRuletoXML(ExtraRuleList).ToString();
            objextra.AcademicSessionID = Convert.ToInt32(ddlsessionID.SelectedValue == "" ? "0" : ddlsessionID.SelectedValue);
            objextra.FeeTypeID = Convert.ToInt32(ddlfeetypes.SelectedValue == "" ? "0" : ddlfeetypes.SelectedValue);

            objextra.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objextra.UserId = LoginToken.UserLoginId;
            objextra.CompanyID = LoginToken.CompanyID;
            int result = objextraBO.UpdateExtraFeeRule(objextra);
            if (result == 2)
            {
                GvExtraRule.DataBind();
                BindExtraRule();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
            }
            else
            {
                GvExtraRule.DataSource = null;
                GvExtraRule.DataBind();
                BindExtraRule();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);

            }
            this.ModalPopupExtender2.Show();
        }
        protected void GvExtraRule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvExtraRule.Rows[i];
                if (e.CommandName == "Deletespop2")
                {
                    ExtraFeeRuleData objextra = new ExtraFeeRuleData();
                    ExtraFeeRuleBO objextraBO = new ExtraFeeRuleBO();
                    Label ID = (Label)gr.Cells[0].FindControl("lblpop2ID");
                    objextra.ID = Convert.ToInt32(ID.Text);
                    int Result = objextraBO.DeleteExtraRuleByID(objextra);
                    if (Result == 1)
                    {
                        BindExtraRule();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                    }
                    else
                    {
                        BindExtraRule();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                }
                this.ModalPopupExtender2.Show();
            }
            catch
            {

            }
        }
        protected void GvExtraRule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            List<LookupItem> looksubject = objmstlookupBO.GetLookupsList(LookupNames.Subject);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label Subject = (Label)e.Row.FindControl("lblsubjectpop2");
                    DropDownList ddlSubject = (DropDownList)e.Row.FindControl("ddlSubjectpop2");
                    Label IsActivate = (Label)e.Row.FindControl("lblactivatepop2");
                    CheckBox ChkIsActivate = (CheckBox)e.Row.FindControl("chkactivatepop2");
                    Commonfunction.PopulateDdl(ddlSubject, looksubject);
                    if (Subject.Text != "")
                    {
                        ddlSubject.Items.FindByValue(Subject.Text).Selected = true;
                    }

                    if (IsActivate.Text == "True")
                    {
                        ChkIsActivate.Checked = true;
                    }
                    else
                    {
                        ChkIsActivate.Checked = false;
                    }
                    if (ChkIsMiscpop2.Checked)
                    {
                        GvExtraRule.Columns[1].Visible = false;
                        GvExtraRule.Columns[2].Visible = true;
                    }
                    else
                    {
                        GvExtraRule.Columns[1].Visible = true;
                        GvExtraRule.Columns[2].Visible = false;
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }
        protected void lnbtnclosedpop2_Click(object sender, EventArgs e)
        {
            int Pop_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            int Pop_ClassID = Convert.ToInt32(lblhiddenclassID.Text);

            int Pop_PaymentID = Convert.ToInt32(lblhiddenpaymentID.Text);


            int Pop_AddRow = 0;
            int Pop_EMI = Convert.ToInt32(ddlnoemipop4.SelectedValue == "0" ? "1" : ddlnoemipop4.SelectedValue);
            if (lblhiddenpaymentID.Text == "1")
            {

                GetOneTimePaymentList(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID, Pop_PaymentID, Pop_AddRow);


                this.ModalPopupExtender1.Show();
            }
            if (lblhiddenpaymentID.Text == "2")
            {

                GetMonthlyPayment(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID, Pop_PaymentID);

                this.ModalPopupExtender3.Show();
            }
            if (lblhiddenpaymentID.Text == "3")
            {

                GetEMIPayment(Pop_SessionID, Pop_ClassID, Pop_CategoryID, Pop_FeeTypeID, Pop_PaymentID);

                this.ModalPopupExtender4.Show();
            }

        }
        //---------MonthlyPayment------------//
        public void GetMonthlyPayment(int SessionID, int ClassID, int CategoryID, int FeeTypeID, int PaymentID)

        {
            MonthlyPaymentData objmonthly = new MonthlyPaymentData();
            MonthlyPaymentBO objmonthlyBO = new MonthlyPaymentBO();
            objmonthly.AcademicSessionID = SessionID;
            objmonthly.ClassID = ClassID;
            objmonthly.CategoryID = CategoryID;
            objmonthly.FeeTypeID = FeeTypeID;
            objmonthly.PaymentID = PaymentID;

            List<MonthlyPaymentData> result = objmonthlyBO.GetMonthlyPayment(objmonthly);
            if (result.Count > 0)
            {
                txtfinepop3.Text = Commonfunction.Getrounding(result[0].Fine.ToString());

                if (Convert.ToDecimal(result[0].Prepaid.ToString()) > 0)
                {
                    chkPrePaidpop3.Checked = true;
                    ddlprepaidpop3.SelectedValue = result[0].Prepaid.ToString();
                }
                else
                {
                    chkPrePaidpop3.Checked = false;
                    ddlprepaidpop3.SelectedIndex = 0;
                }
                if (Convert.ToDecimal(result[0].Postpaid.ToString()) > 0)
                {
                    chkPostPaidpop3.Checked = true;
                    ddlpostpaidpop3.SelectedValue = result[0].Postpaid.ToString();
                }
                else
                {
                    chkPostPaidpop3.Checked = false;
                    ddlpostpaidpop3.SelectedIndex = 0;
                }
                if (Convert.ToDecimal(result[0].DiscountLimit) > 0)
                {
                    chkonetimepaymentpop3.Checked = true;
                    txtavaildiscdatepop3.Enabled = true;
                    txtdiscountlimitpop3.Enabled = true;
                    txtdiscountlimitpop3.Text = Commonfunction.Getrounding(result[0].DiscountLimit.ToString());
                    txtavaildiscdatepop3.Text = result[0].DiscountDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    chkonetimepaymentpop3.Checked = false;
                    txtavaildiscdatepop3.Enabled = false;
                    txtdiscountlimitpop3.Enabled = false;
                    txtdiscountlimitpop3.Text = "";
                    txtavaildiscdatepop3.Text = "";
                }

                GvMonthlyPayment.DataSource = result;
                GvMonthlyPayment.DataBind();
            }
            else
            {
                txtfinepop3.Text = "";
                txtdiscountlimitpop3.Text = "";
                GvMonthlyPayment.DataSource = null;
                GvMonthlyPayment.DataBind();
            }
        }
        public void BindMonthlyPayment()
        {
            int Pop3_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop3_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            int Pop3_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop3_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);

            int Pop3_PaymentID = Convert.ToInt32(lblhiddenpaymentID.Text);
            GetMonthlyPayment(Pop3_SessionID, Pop3_ClassID, Pop3_CategoryID, Pop3_FeeTypeID, Pop3_PaymentID);

        }
        protected void lnlextrarulepop3_Click(object sender, EventArgs e)
        {
            BindExtraRule();
            this.ModalPopupExtender2.Show();
        }
        protected void GvMonthlyPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label amountnewstudent3 = (Label)e.Row.FindControl("lblamountnewfeepop3");
                TotalAmount_NewStudent = Convert.ToDecimal(amountnewstudent3.Text);
                Label amountoldstudent3 = (Label)e.Row.FindControl("lblamountoldfeepop3");
                TotalAmount_OldStudent = Convert.ToDecimal(amountoldstudent3.Text);
                Label IsActivate = (Label)e.Row.FindControl("lblactivatepop3");
                CheckBox ChkIsActivate = (CheckBox)e.Row.FindControl("chkactivatepop3");
                if (IsActivate.Text == "True")
                {
                    ChkIsActivate.Checked = true;
                }
                else
                {
                    ChkIsActivate.Checked = false;
                }
                if (chkPrePaidpop3.Checked)
                {
                    chkPostPaidpop3.Checked = false;
                }
                if (chkPostPaidpop3.Checked)
                {
                    chkPrePaidpop3.Checked = false;
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                Label totalnew_footer = (Label)e.Row.FindControl("lblamountnewfeepop31");
                totalnew_footer.Text = TotalAmount_NewStudent.ToString();

                Label totalold_footer = (Label)e.Row.FindControl("lblamountoldfeepop31");
                totalold_footer.Text = TotalAmount_OldStudent.ToString();
            }
        }
        protected void chkPostPaidpop3_CheckedChanged(object sender, EventArgs e)
        {
            chkPrePaidpop3.Checked = false;
            chkPostPaidpop3.Checked = true;
            ddlprepaidpop3.Enabled = false;
            ddlpostpaidpop3.Enabled = true;
            this.ModalPopupExtender3.Show();
        }
        protected void chkPrePaidpop3_CheckedChanged(object sender, EventArgs e)
        {
            chkPrePaidpop3.Checked = true;
            chkPostPaidpop3.Checked = false;
            ddlprepaidpop3.Enabled = true;
            ddlpostpaidpop3.Enabled = false;
            this.ModalPopupExtender3.Show();
        }
        protected void btnsavepop3_Click(object sender, EventArgs e)
        {
            List<MonthlyPaymentData> MonthPaymentList = new List<MonthlyPaymentData>();
            MonthlyPaymentData objmonthly = new MonthlyPaymentData();
            MonthlyPaymentBO objmonthlyBO = new MonthlyPaymentBO();
            int check = 0;
            Decimal TotalNewAmount = 0;
            Decimal TotalOldAmount = 0;


            foreach (GridViewRow row in GvMonthlyPayment.Rows)
            {
                TextBox NewAmount = (TextBox)GvMonthlyPayment.Rows[row.RowIndex].Cells[0].FindControl("txtnewfeeamountpop3");
                TextBox OldAmount = (TextBox)GvMonthlyPayment.Rows[row.RowIndex].Cells[0].FindControl("txtoldfeeamountpop3");
                TextBox Exemption = (TextBox)GvMonthlyPayment.Rows[row.RowIndex].Cells[0].FindControl("txtexemptionpop3");
                CheckBox IsActivate = (CheckBox)GvMonthlyPayment.Rows[row.RowIndex].Cells[0].FindControl("chkactivatepop3");
                Label ID = (Label)GvMonthlyPayment.Rows[row.RowIndex].Cells[0].FindControl("lblMonthlyIDpop3");

                MonthlyPaymentData objXmlmonthly = new MonthlyPaymentData();
                objXmlmonthly.MonthlyID = Convert.ToInt32(ID.Text);
                objXmlmonthly.FeeAmount_New = Convert.ToDecimal(NewAmount.Text == "" ? "0" : NewAmount.Text.Trim());
                objXmlmonthly.FeeAmount_Old = Convert.ToDecimal(OldAmount.Text == "" ? "0" : OldAmount.Text.Trim());
                objXmlmonthly.Exemption = Convert.ToDecimal(Exemption.Text == "" ? "0" : Exemption.Text.Trim());
                if (IsActivate.Checked == true)
                {
                    objXmlmonthly.IsActivate = true;
                    TotalNewAmount = TotalNewAmount + Convert.ToDecimal(NewAmount.Text == "" ? "0" : NewAmount.Text.Trim());
                    TotalOldAmount = TotalOldAmount + Convert.ToDecimal(OldAmount.Text == "" ? "0" : OldAmount.Text.Trim());
                }
                else
                {
                    objXmlmonthly.IsActivate = false;
                }
                MonthPaymentList.Add(objXmlmonthly);
                check++;
            }
            objmonthly.XMLData = XmlConvertor.MonthlyPaymenttoXML(MonthPaymentList).ToString();
            objmonthly.Prepaid = Convert.ToInt32(ddlprepaidpop3.SelectedValue == "" ? "0" : ddlprepaidpop3.SelectedValue);
            objmonthly.Postpaid = Convert.ToInt32(ddlpostpaidpop3.SelectedValue == "" ? "0" : ddlpostpaidpop3.SelectedValue);
            objmonthly.Fine = Convert.ToDecimal(txtfinepop3.Text.Trim() == "" ? "0" : txtfinepop3.Text.Trim());
            if (chkonetimepaymentpop3.Checked)
            {
                objmonthly.IsOneTimePayment = 1;

            }
            else
            {
                objmonthly.IsOneTimePayment = 0;
            }
            DateTime DiscDate = txtavaildiscdatepop3.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtavaildiscdatepop3.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objmonthly.DiscountDate = DiscDate;
            objmonthly.DiscountLimit = Convert.ToDecimal(txtdiscountlimitpop3.Text.Trim() == "" ? "0" : txtdiscountlimitpop3.Text.Trim());
            objmonthly.ID = Convert.ToInt32(lblhiddenID.Text == "" ? "0" : lblhiddenID.Text);
            objmonthly.AcademicSessionID = Convert.ToInt32(lblhiddensessionID.Text);
            objmonthly.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objmonthly.CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            objmonthly.FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            objmonthly.UserId = LoginToken.UserLoginId;
            objmonthly.CompanyID = LoginToken.CompanyID;
            if (Convert.ToDecimal(txtdiscountlimit.Text == "" ? "0.0" : txtdiscountlimit.Text) > Convert.ToDecimal(TotalNewAmount))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Discount limit could not be greater than total amount. ") + "')", true);
                txtdiscountlimit.ForeColor = System.Drawing.Color.Red;
                this.ModalPopupExtender3.Show();
                return;
            }
            else
            {
                txtdiscountlimit.ForeColor = System.Drawing.Color.White;
            }
            if (Convert.ToDecimal(txtdiscountlimit.Text == "" ? "0.0" : txtdiscountlimit.Text) > Convert.ToDecimal(TotalOldAmount))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Discount limit could not be greater than total amount. ") + "')", true);
                txtdiscountlimit.ForeColor = System.Drawing.Color.Red;
                this.ModalPopupExtender3.Show();
                return;
            }
            else
            {
                txtdiscountlimit.ForeColor = System.Drawing.Color.White;
            }
            if (Convert.ToDecimal(txtfinepop3.Text == "" ? "0.0" : txtfinepop3.Text) > Convert.ToDecimal(TotalNewAmount))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Fine could not be greater than total amount. ") + "')", true);
                txtfinepop3.ForeColor = System.Drawing.Color.Red;
                this.ModalPopupExtender3.Show();
                return;
            }
            else
            {
                txtfinepop3.ForeColor = System.Drawing.Color.White;
            }
            if (Convert.ToDecimal(txtfinepop3.Text == "" ? "0.0" : txtfinepop3.Text) > Convert.ToDecimal(TotalOldAmount))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Fine could not be greater than total amount. ") + "')", true);
                txtfinepop3.ForeColor = System.Drawing.Color.Red;
                this.ModalPopupExtender3.Show();
                return;
            }
            else
            {
                txtfinepop3.ForeColor = System.Drawing.Color.White;
            }
            int result = objmonthlyBO.UpdateMonthlyPayment(objmonthly);
            if (result == 2)
            {
                BindMonthlyPayment();
                GvMonthlyPayment.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
            }
            else
            {
                BindMonthlyPayment();
                GvMonthlyPayment.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
            this.ModalPopupExtender3.Show();
        }
        protected void chkonetimepaymentpop3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkonetimepaymentpop3.Checked)
            {
                txtavaildiscdatepop3.Enabled = true;
                txtdiscountlimitpop3.Enabled = true;
            }
            else
            {
                txtavaildiscdatepop3.Enabled = false;
                txtdiscountlimitpop3.Enabled = false;

            }
            this.ModalPopupExtender3.Show();
        }
        protected void lnbtnclosedpop3_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnMonthlyPayment_Click(object sender, EventArgs e)
        {
            string url = "../EduFeeUtility/Reports/ReportViewer.aspx?option=MonthlyPayment&AcademicSessionID=" + lblhiddensessionID.Text + "&ClassID=" + lblhiddenclassID.Text + "&CategoryID=" + lblhiddencategoryID.Text + "&FeeTypeID=" + lblhiddenfeetypeID.Text;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            this.ModalPopupExtender3.Show();
        }
        //---------EMI------------//
        public void GetEMIPayment(int SessionID, int ClassID, int CategoryID, int FeeTypeID, int PaymentID)


        {
            EMIPaymentData objemi = new EMIPaymentData();
            EMIPaymentBO objemieBO = new EMIPaymentBO();
            objemi.AcademicSessionID = SessionID;
            objemi.ClassID = ClassID;
            objemi.CategoryID = CategoryID;
            objemi.FeeTypeID = FeeTypeID;


            objemi.NoEmi = Convert.ToInt32(lblhiddennoemi.Text == "" ? "1" : lblhiddennoemi.Text);
            //if (ddlnoemipop4.SelectedValue != lblhiddennoemi.Text)
            //{
            //    objemi.NoEmi = Convert.ToInt32(ddlnoemipop4.SelectedValue == "" ? "1" : ddlnoemipop4.SelectedValue);
            //}
            objemi.PaymentID = PaymentID;
            List<EMIPaymentData> result = objemieBO.GetEMIPayment(objemi);
            if (result.Count > 0)
            {
                if (result[0].AcademicSessionID.ToString() == lblhiddensessionID.Text && result[0].CategoryID.ToString() == lblhiddencategoryID.Text && result[0].FeeTypeID.ToString() == lblhiddenfeetypeID.Text && result[0].ClassID.ToString() == lblhiddenclassID.Text)
                {
                    ddlnoemipop4.SelectedValue = result[0].NoEmi.ToString();
                }
                if (Convert.ToDecimal(result[0].DiscountLimit) > 0)
                {
                    chkonetimepaymentpop4.Checked = true;
                    txtdiscountlimitpop4.Text = Commonfunction.Getrounding(result[0].DiscountLimit.ToString());
                }
                else
                {
                    chkonetimepaymentpop4.Checked = false;
                    txtdiscountlimitpop4.Text = "";
                }
                lblhiddencount.Text = Convert.ToString(result.Count);
                Gv_Emipayment.DataSource = result;
                Gv_Emipayment.DataBind();
            }
            else
            {
                Gv_Emipayment.DataSource = null;
                Gv_Emipayment.DataBind();
            }
        }
        public void BindEMIPayment()
        {
            int Pop4_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop4_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            int Pop4_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop4_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            int Pop4_EMI = Convert.ToInt32(ddlnoemipop4.SelectedValue == "0" ? "1" : ddlnoemipop4.SelectedValue);
            int Pop4_PaymentID = Convert.ToInt32(lblhiddenpaymentID.Text);
            GetEMIPayment(Pop4_SessionID, Pop4_ClassID, Pop4_CategoryID, Pop4_FeeTypeID, Pop4_PaymentID);

        }
        protected void lnlemipop4_Click(object sender, EventArgs e)
        {
            BindExtraRule();
            this.ModalPopupExtender2.Show();
        }
        protected void ddlnoemipop4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlnoemipop4.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Pls Select No.EMI") + "')", true);
                this.ModalPopupExtender4.Show();
                return;
            }
            else
            {
                lblhiddennoemi.Text = ddlnoemipop4.SelectedValue;
                BindEMIPayment();
            }
            this.ModalPopupExtender4.Show();
        }
        protected void Gv_Emipayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int Totalcount = Convert.ToInt32(lblhiddencount.Text);
            int NoEMI = Convert.ToInt32(ddlnoemipop4.SelectedValue == "0" ? "1" : ddlnoemipop4.SelectedValue);
            int InstalmentNo = (Totalcount / NoEMI);
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }
            Label lblInstallment = (Label)e.Row.FindControl("lblInstallmentOrderpop4");
            Label lblisLastIndex = (Label)e.Row.FindControl("lblisLastIndex");
            TextBox txtNewFeeAmt = (TextBox)e.Row.FindControl("txtNewFeeAmountpop4");
            TextBox txtOldFeeAmt = (TextBox)e.Row.FindControl("txtOldFeeAmountpop4");
            TextBox txtExemptionAmt = (TextBox)e.Row.FindControl("txtexemptionpop4");
            Label lblNetNewFeeAmt = (Label)e.Row.FindControl("lblnewnetfeeamountpop4");
            Label lblNetOldFeeAmt = (Label)e.Row.FindControl("lbloldnetfeeamountpop4");
            TextBox txtDueDate = (TextBox)e.Row.FindControl("txtDueDatepop4");
            TextBox txtFine = (TextBox)e.Row.FindControl("txtFinepop4");
            Label IsActivate = (Label)e.Row.FindControl("lblActivatepop4");
            Label lblActivated = (Label)e.Row.FindControl("lblActivatedpop4");
            CheckBox ChkIsActivate = (CheckBox)e.Row.FindControl("chkactivatepop4");

            int InstallmentID = Convert.ToInt32(lblInstallment.Text == "" ? "0" : lblInstallment.Text);
            //if (lblActivated.Text != "0")
            //{
            //    ddlnoemipop4.Attributes["disabled"] = "disabled";
            //}

            //if (lblActivated.Text == "0")
            //{
            //    ddlnoemipop4.Attributes.Remove("disabled");
            //}

            if (IsActivate.Text == "True")
            {
                ChkIsActivate.Checked = true;
            }
            else
            {
                ChkIsActivate.Checked = false;
            }
            if (txtDueDate.Text == "01/01/0001 12:00:00 AM" || txtDueDate.Text == "01/01/1753 12:00:00 AM" || txtDueDate.Text == "01 / 01 / 0001") ;
            {
                txtDueDate.Text = "";
            }
            if (lblisLastIndex.Text == "0")
            {
                lblInstallment.Text = "";
                txtNewFeeAmt.Text = "";
                txtNewFeeAmt.Attributes["disabled"] = "disabled";
                txtOldFeeAmt.Text = "";
                txtOldFeeAmt.Attributes["disabled"] = "disabled";
                txtExemptionAmt.Text = "";
                txtExemptionAmt.Attributes["disabled"] = "disabled";
                lblNetNewFeeAmt.Text = "";
                lblNetNewFeeAmt.Attributes["disabled"] = "disabled";
                lblNetOldFeeAmt.Text = "";
                lblNetOldFeeAmt.Attributes["disabled"] = "disabled";
                txtDueDate.Text = "";
                txtDueDate.Attributes["disabled"] = "disabled";
                txtFine.Text = "";
                txtFine.Attributes["disabled"] = "disabled";
                IsActivate.Text = "";
                ChkIsActivate.Text = "";
                ChkIsActivate.Enabled = false;
            }

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                TableCell Cell = e.Row.Cells[i];
                for (int j = 1; j <= InstalmentNo * NoEMI; j++)    // colour loop//
                {
                    if (j % 2 != 0)
                    {
                        if (e.Row.RowIndex < InstalmentNo * j && (e.Row.RowIndex >= InstalmentNo * (j - 1) && e.Row.RowIndex <= InstalmentNo * j))
                        {
                            Cell.BackColor = System.Drawing.Color.LightBlue;

                        }
                    }
                    if (j % 2 == 0)
                    {
                        if (e.Row.RowIndex < InstalmentNo * j && (e.Row.RowIndex >= InstalmentNo * (j - 1) && e.Row.RowIndex <= InstalmentNo * j))
                        {
                            Cell.BackColor = System.Drawing.Color.Wheat;
                        }
                    }
                }
            }

        }
        protected void chkprepaidpop4_CheckedChanged(object sender, EventArgs e)
        {
            chkpostpaidpop4.Checked = false;
            BindEMIPayment();
            this.ModalPopupExtender4.Show();
        }
        protected void chkpostpaidpop4_CheckedChanged(object sender, EventArgs e)
        {
            chkprepaidpop4.Checked = false;
            BindEMIPayment();
            this.ModalPopupExtender4.Show();
        }
        protected void btnsavepop4_Click(object sender, EventArgs e)
        {
            List<EMIPaymentData> EMIPaymentList = new List<EMIPaymentData>();
            EMIPaymentData objemi = new EMIPaymentData();
            EMIPaymentBO objemiBO = new EMIPaymentBO();
            int check = 0;
            foreach (GridViewRow row in Gv_Emipayment.Rows)
            {
                Label ID = (Label)Gv_Emipayment.Rows[row.RowIndex].Cells[0].FindControl("lblMonthlyIDpop4");
                TextBox NewAmount = (TextBox)Gv_Emipayment.Rows[row.RowIndex].Cells[0].FindControl("txtNewFeeAmountpop4");
                TextBox OldAmount = (TextBox)Gv_Emipayment.Rows[row.RowIndex].Cells[0].FindControl("txtOldFeeAmountpop4");
                TextBox Exemption = (TextBox)Gv_Emipayment.Rows[row.RowIndex].Cells[0].FindControl("txtexemptionpop4");
                TextBox DueDate = (TextBox)Gv_Emipayment.Rows[row.RowIndex].Cells[0].FindControl("txtDueDatepop4");
                TextBox Fine = (TextBox)Gv_Emipayment.Rows[row.RowIndex].Cells[0].FindControl("txtFinepop4");
                CheckBox IsActivate = (CheckBox)Gv_Emipayment.Rows[row.RowIndex].Cells[0].FindControl("chkactivatepop4");

                EMIPaymentData objXmlEMI = new EMIPaymentData();
                objXmlEMI.MonthlyID = Convert.ToInt32(ID.Text);
                objXmlEMI.FeeAmount_New = Convert.ToDecimal(NewAmount.Text == "" ? "0" : NewAmount.Text.Trim());
                objXmlEMI.FeeAmount_Old = Convert.ToDecimal(OldAmount.Text == "" ? "0" : OldAmount.Text.Trim());
                objXmlEMI.Exemption = Convert.ToDecimal(Exemption.Text == "" ? "0" : Exemption.Text.Trim());
                //  DateTime DueDates = DueDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(DueDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objXmlEMI.DueDate = DueDate.Text.Trim();
                objXmlEMI.Fine = Convert.ToDecimal(Fine.Text == "" ? "0" : Fine.Text.Trim());
                if (IsActivate.Checked == true)
                {
                    objXmlEMI.IsActivate = true;
                }
                else
                {
                    objXmlEMI.IsActivate = false;
                }
                EMIPaymentList.Add(objXmlEMI);
                check++;
            }
            objemi.XMLData = XmlConvertor.EMIPaymenttoXML(EMIPaymentList).ToString();
            if (chkprepaidpop4.Checked)
            {
                objemi.IsPrePaid = 1;
            }
            if (chkprepaidpop4.Checked)
            {
                objemi.IsPrePaid = 1;
            }
            if (chkonetimepaymentpop4.Checked)
            {
                objemi.IsOneTimePayment = 1;
            }
            else
            {
                objemi.IsOneTimePayment = 0;
            }
            objemi.DiscountLimit = Convert.ToDecimal(txtdiscountlimitpop4.Text.Trim() == "" ? "0" : txtdiscountlimitpop4.Text.Trim());

            objemi.ID = Convert.ToInt32(lblhiddenID.Text == "" ? "0" : lblhiddenID.Text);

            objemi.AcademicSessionID = Convert.ToInt32(lblhiddensessionID.Text);
            objemi.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objemi.CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            objemi.FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            objemi.NoEmi = Convert.ToInt32(ddlnoemipop4.SelectedValue == "0" ? "1" : ddlnoemipop4.SelectedValue);
            objemi.UserId = LoginToken.UserLoginId;
            objemi.CompanyID = LoginToken.CompanyID;
            int result = objemiBO.UpdateEMIPayment(objemi);
            if (result == 2)
            {
                BindEMIPayment();
                // ddlnoemipop4.Attributes["disabled"] = "disabled";
                Gv_Emipayment.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
            }
            else
            {
                BindEMIPayment();
                Gv_Emipayment.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
            this.ModalPopupExtender4.Show();
        }
        protected void lnbtnclosedpop4_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnEmiPayment_Click(object sender, EventArgs e)
        {
            string url = "../EduFeeUtility/Reports/ReportViewer.aspx?option=EmiPayment&AcademicSessionID=" + lblhiddensessionID.Text + "&ClassID=" + lblhiddenclassID.Text + "&CategoryID=" + lblhiddencategoryID.Text + "&FeeTypeID=" + lblhiddenfeetypeID.Text + "&NoEmi=" + ddlnoemipop4.SelectedValue;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            this.ModalPopupExtender4.Show();
        }
        //------------XXXXXXXXXXXX--------------//

        //---------Exemption Rule------------//
        public void GetExemptionRule(int SessionID, int ClassID, int CategoryID, int FeeTypeID)
        {
            ExemptionRuleData objexemp = new ExemptionRuleData();
            ExemptionRuleBO objexempBO = new ExemptionRuleBO();
            objexemp.AcademicSessionID = SessionID;
            objexemp.ClassID = ClassID;
            objexemp.CategoryID = CategoryID;
            objexemp.FeeTypeID = FeeTypeID;

            objexemp.PaymentID = Convert.ToInt32(lblhiddenpaymentID.Text);
            objexemp.FeeAmount_New = Convert.ToDecimal(lblhiddenNewFeeAmount.Text);
            objexemp.FeeAmount_Old = Convert.ToDecimal(lblhiddenOldFeeAmount.Text);

            List<ExemptionRuleData> result = objexempBO.GetExemptionRule(objexemp);
            if (result.Count > 0)
            {
                Gv_Exemption.DataSource = result;
                Gv_Exemption.DataBind();
            }
            else
            {
                Gv_Exemption.DataSource = null;
                Gv_Exemption.DataBind();
            }
        }
        public void BindExemption()
        {
            int Pop5_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop5_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            int Pop5_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop5_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            GetExemptionRule(Pop5_SessionID, Pop5_ClassID, Pop5_CategoryID, Pop5_FeeTypeID);
        }
        protected void btnsavepop5_Click(object sender, EventArgs e)
        {
            List<ExemptionRuleData> ExemptionList = new List<ExemptionRuleData>();
            ExemptionRuleData objexemp = new ExemptionRuleData();
            ExemptionRuleBO objexempBO = new ExemptionRuleBO();
            int check = 0;
            foreach (GridViewRow row in Gv_Exemption.Rows)
            {
                Label ID = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lblExemptionpop5");
                Label StudentTypeID = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lblStudentTypeIDpop5");

                Label NewAmount = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lblFeeAmountNewpop5");
                Label OldAmount = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lblFeeAmountOldpop5");

                TextBox NewExemption = (TextBox)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("txtExempAmountNewpop5");
                TextBox OldExemption = (TextBox)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("txtExempAmountOldpop5");
                Label NetNewAmount = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lblNetAmountNewpop5");
                Label NetOldAmount = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lblNetAmountOldpop5");
                CheckBox IsActivate = (CheckBox)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("chkactivatepop5");

                ExemptionRuleData objXmlExemp = new ExemptionRuleData();
                objXmlExemp.ExemptionID = Convert.ToInt32(ID.Text);
                objXmlExemp.StudentTypeID = Convert.ToInt32(StudentTypeID.Text);

                objXmlExemp.FeeAmount_New = Convert.ToDecimal(NewAmount.Text);
                objXmlExemp.FeeAmount_Old = Convert.ToDecimal(OldAmount.Text);

                objXmlExemp.ExemptedAmount_New = Convert.ToDecimal(NewExemption.Text == "" ? "0" : NewExemption.Text.Trim());
                objXmlExemp.ExemptedAmount_Old = Convert.ToDecimal(OldExemption.Text == "" ? "0" : OldExemption.Text.Trim());
                if (IsActivate.Checked == true)
                {
                    objXmlExemp.IsActivate = true;
                }
                else
                {
                    objXmlExemp.IsActivate = false;
                }
                if (Convert.ToDecimal(NewExemption.Text) > Convert.ToDecimal(NewAmount.Text))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("New student exemption exceeds the fee amount.") + "')", true);
                    NewExemption.BackColor = System.Drawing.Color.Red;
                    NewExemption.ForeColor = System.Drawing.Color.Black;
                    this.ModalPopupExtender5.Show();
                    return;
                }
                else
                {
                    NewExemption.BackColor = System.Drawing.Color.White;
                    NewExemption.ForeColor = System.Drawing.Color.Black;
                }
                if (Convert.ToDecimal(OldExemption.Text) > Convert.ToDecimal(OldAmount.Text))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Old student exemption exceeds the fee amount.") + "')", true);
                    OldExemption.BackColor = System.Drawing.Color.Red;
                    OldExemption.ForeColor = System.Drawing.Color.Black;
                    this.ModalPopupExtender5.Show();
                    return;
                }
                else
                {
                    OldExemption.BackColor = System.Drawing.Color.White;
                    OldExemption.ForeColor = System.Drawing.Color.Black;
                }
                ExemptionList.Add(objXmlExemp);
                check++;
            }
            objexemp.XMLData = XmlConvertor.ExemptiontoXML(ExemptionList).ToString();

            objexemp.ID = Convert.ToInt32(lblhiddenID.Text == "" ? "0" : lblhiddenID.Text);
            objexemp.AcademicSessionID = Convert.ToInt32(lblhiddensessionID.Text);
            objexemp.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objexemp.CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            objexemp.FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);

            objexemp.UserId = LoginToken.UserLoginId;
            objexemp.CompanyID = LoginToken.CompanyID;
            int result = objexempBO.UpdateExemptionRule(objexemp);
            if (result == 2)
            {
                BindExemption();
                Gv_Exemption.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
            }
            else
            {
                BindExemption();
                Gv_Exemption.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
            this.ModalPopupExtender5.Show();
        }
        protected void Gv_Exemption_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label IsActivate = (Label)e.Row.FindControl("lblActivatepop5");
                CheckBox ChkIsActivate = (CheckBox)e.Row.FindControl("chkactivatepop5");
                if (IsActivate.Text == "True")
                {
                    ChkIsActivate.Checked = true;
                }
                else
                {
                    ChkIsActivate.Checked = false;
                }
            }
        }
        protected void lnbclosedpop5_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnExemptionRule_Click(object sender, EventArgs e)
        {
            string url = "../EduFeeUtility/Reports/ReportViewer.aspx?option=ExemptionRule&AcademicSessionID=" + lblhiddensessionID.Text + "&ClassID=" + lblhiddenclassID.Text + "&CategoryID=" + lblhiddencategoryID.Text + "&FeeTypeID=" + lblhiddenfeetypeID.Text;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            this.ModalPopupExtender5.Show();
        }
        //------------XXXXXXXXXXXX--------------//
        //---------Inclusive Rule------------//
        protected void ddlcategoryIDpop6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcategoryIDpop6.SelectedValue == "0")
            {
                this.ModalPopupExtender6.Show();
            }

            if (ddlcategoryIDpop6.SelectedValue != "0")
            {
                //lblcategoryIDpop61.Text = ddlcategoryIDpop6.SelectedItem.Text.ToString();
                lblcategoryIDpop62.Text = ddlcategoryIDpop6.SelectedItem.Text.ToString();

                int Pop61_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
                int Pop61_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
                int Pop61_CategoryID = Convert.ToInt32(ddlcategoryIDpop6.SelectedValue);
                GetInclusiveOneTime(Pop61_SessionID, Pop61_ClassID, Pop61_CategoryID);
                //this.ModalPopupExtender61.Show();
            }
        }
        public void GetInclusiveOneTime(int SessionID, int ClassID, int CategoryID)
        {
            InclusiveRuleData objincl = new InclusiveRuleData();
            InclusiveRuleBO objinclBO = new InclusiveRuleBO();
            objincl.AcademicSessionID = SessionID;
            objincl.ClassID = ClassID;
            objincl.CategoryID = CategoryID;

            List<InclusiveRuleData> result = objinclBO.GetInclusiveOneTime(objincl);
            if (result.Count > 0)
            {
                lblhiddenfeetypeID.Text = Convert.ToString(result[0].FeeTypeID);

                lblhiddenfeetype.Text = result[0].Particulars;
                //Gv_InclusiveOneTime.DataSource = result;
                //Gv_InclusiveOneTime.DataBind();
            }
            else
            {
                // Gv_InclusiveOneTime.DataSource = null;
                // Gv_InclusiveOneTime.DataBind();
            }
        }
        protected void Gv_InclusiveOneTime_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                //GridViewRow gr = Gv_InclusiveOneTime.Rows[i];
                if (e.CommandName == "InclusiveOneTime")
                {
                    lblfeetypeIDpop62.Text = lblhiddenfeetype.Text;
                    int Pop62_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
                    int Pop62_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
                    int Pop62_CategoryID = Convert.ToInt32(ddlcategoryIDpop6.SelectedValue);
                    int Pop62_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
                    GetInclusiveOtherFeeTypes(Pop62_SessionID, Pop62_ClassID, Pop62_CategoryID, Pop62_FeeTypeID);
                    this.ModalPopupExtender62.Show();
                }
            }
            catch
            {

            }
        }
        public void BindInclusiveOtherFeeTypes()
        {
            int Pop62_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop62_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            int Pop62_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop62_FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            GetInclusiveOtherFeeTypes(Pop62_SessionID, Pop62_ClassID, Pop62_CategoryID, Pop62_FeeTypeID);
        }
        public void GetInclusiveOtherFeeTypes(int SessionID, int ClassID, int CategoryID, int FeetypesID)
        {
            InclusiveRuleData objincl = new InclusiveRuleData();
            InclusiveRuleBO objinclBO = new InclusiveRuleBO();
            objincl.AcademicSessionID = SessionID;
            objincl.ClassID = ClassID;
            objincl.CategoryID = CategoryID;
            objincl.FeeTypeID = FeetypesID;

            List<InclusiveRuleData> result = objinclBO.GetInclusiveOtherFeeTypes(objincl);
            if (result.Count > 0)
            {

                Gv_InclusiveOtherFeeTypes.DataSource = result;
                Gv_InclusiveOtherFeeTypes.DataBind();
            }
            else
            {
                Gv_InclusiveOtherFeeTypes.DataSource = null;
                Gv_InclusiveOtherFeeTypes.DataBind();
            }
        }
        protected void chkactivateInclusiveOtherFeeTypes_CheckedChanged(object sender, EventArgs e)
        {
            List<InclusiveRuleData> InclusiveList = new List<InclusiveRuleData>();
            InclusiveRuleData objincl = new InclusiveRuleData();
            InclusiveRuleBO objinclBO = new InclusiveRuleBO();
            int check = 0;
            foreach (GridViewRow row in Gv_InclusiveOtherFeeTypes.Rows)
            {
                Label InclusiveID = (Label)Gv_InclusiveOtherFeeTypes.Rows[row.RowIndex].Cells[0].FindControl("lblInclusiveID");
                Label OtherFeeTypeID = (Label)Gv_InclusiveOtherFeeTypes.Rows[row.RowIndex].Cells[0].FindControl("lblOtherFeeTypesID");
                CheckBox IsActivate = (CheckBox)Gv_InclusiveOtherFeeTypes.Rows[row.RowIndex].Cells[0].FindControl("chkactivateInclusiveOtherFeeTypes");
                InclusiveRuleData objXmlInc = new InclusiveRuleData();
                objXmlInc.InclusiveID = Convert.ToInt32(InclusiveID.Text);
                objXmlInc.OtherFeeTypeID = Convert.ToInt32(OtherFeeTypeID.Text);
                if (IsActivate.Checked == true)
                {
                    objXmlInc.IsActivate = true;
                }
                else
                {
                    objXmlInc.IsActivate = false;
                }
                InclusiveList.Add(objXmlInc);
                check++;
            }
            objincl.XMLData = XmlConvertor.InclusiveOtherFeetoXML(InclusiveList).ToString();
            objincl.UserId = LoginToken.UserLoginId;
            objincl.CompanyID = LoginToken.CompanyID;
            objincl.ID = Convert.ToInt32(lblhiddenID.Text == "" ? "0" : lblhiddenID.Text);
            objincl.AcademicSessionID = Convert.ToInt32(lblhiddensessionID.Text);
            objincl.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objincl.CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            objincl.FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            int result = objinclBO.UpdateInclusiveOtherFee(objincl);
            if (result == 2)
            {
                BindInclusiveOtherFeeTypes();
                bindgrid(1);
                Gv_InclusiveOtherFeeTypes.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
            }
            else
            {
                BindInclusiveOtherFeeTypes();
                Gv_InclusiveOtherFeeTypes.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
            this.ModalPopupExtender62.Show();
        }
        protected void Gv_InclusiveOtherFeeTypes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label InclusiveID = (Label)e.Row.FindControl("lblInclusiveID");
                Label IsActivate = (Label)e.Row.FindControl("lblActivateInclusiveOtherFeeTypes");
                CheckBox ChkIsActivate = (CheckBox)e.Row.FindControl("chkactivateInclusiveOtherFeeTypes");
                if (IsActivate.Text == "True")
                {
                    ChkIsActivate.Checked = true;
                }
                else
                {
                    ChkIsActivate.Checked = false;
                }
            }
        }
        protected void Gv_InclusiveOtherFeeTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());

                GridViewRow gr = Gv_InclusiveOtherFeeTypes.Rows[i];
                Label OtherFeeTypeID = (Label)gr.Cells[0].FindControl("lblOtherFeeTypesID");


                if (e.CommandName == "InclusiveOtherFeeTypes")
                {
                    lblfeetypeIDpop62.Text = lblhiddenfeetype.Text;
                    int Pop63_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
                    int Pop63_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
                    int Pop63_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);

                    int Pop63_FeeTypeID = Convert.ToInt32(OtherFeeTypeID.Text);
                    //lblhiddencategoryID.Text = Convert.ToString(ddlcategoryIDpop6.SelectedValue);
                    lblhiddenOtherfeetypeID.Text = OtherFeeTypeID.Text;

                    GetInclusiveMonths(Pop63_SessionID, Pop63_ClassID, Pop63_CategoryID, Pop63_FeeTypeID);
                    this.ModalPopupExtender63.Show();
                }
            }
            catch
            {

            }
        }
        public void BindInclusiveMonths()
        {
            int Pop63_SessionID = Convert.ToInt32(lblhiddensessionID.Text);
            int Pop63_ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            int Pop63_CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            int Pop63_FeeTypeID = Convert.ToInt32(lblhiddenOtherfeetypeID.Text);
            GetInclusiveMonths(Pop63_SessionID, Pop63_ClassID, Pop63_CategoryID, Pop63_FeeTypeID);
            this.ModalPopupExtender63.Show();
        }
        public void GetInclusiveMonths(int SessionID, int ClassID, int CategoryID, int FeetypesID)
        {
            InclusiveRuleData objincl = new InclusiveRuleData();
            InclusiveRuleBO objinclBO = new InclusiveRuleBO();
            objincl.AcademicSessionID = SessionID;
            objincl.ClassID = ClassID;
            objincl.CategoryID = CategoryID;
            objincl.FeeTypeID = FeetypesID;

            List<InclusiveRuleData> result = objinclBO.GetInclusiveMonths(objincl);
            if (result.Count > 0)
            {
                Gv_InclusiveMonths.DataSource = result;
                Gv_InclusiveMonths.DataBind();
            }
            else
            {
                Gv_InclusiveMonths.DataSource = null;
                Gv_InclusiveMonths.DataBind();
            }
        }
        protected void btnInclusiveMonth_Click(object sender, EventArgs e)
        {
            List<InclusiveRuleData> InclusiveList = new List<InclusiveRuleData>();
            InclusiveRuleData objincl = new InclusiveRuleData();
            InclusiveRuleBO objinclBO = new InclusiveRuleBO();
            int check = 0;
            foreach (GridViewRow row in Gv_InclusiveMonths.Rows)
            {
                Label MonthID = (Label)Gv_InclusiveMonths.Rows[row.RowIndex].Cells[0].FindControl("lblInclusiveMonthID");
                Label OtherFeeTypeID = (Label)Gv_InclusiveMonths.Rows[row.RowIndex].Cells[0].FindControl("lblInclusiveMonthOtherFeeTypesID");
                TextBox TotalAmount = (TextBox)Gv_InclusiveMonths.Rows[row.RowIndex].Cells[0].FindControl("txtInclusiveTotalAmounts");
                CheckBox IsActivate = (CheckBox)Gv_InclusiveMonths.Rows[row.RowIndex].Cells[0].FindControl("chkInclusiveIsActivateMonth");
                InclusiveRuleData objXmlInc = new InclusiveRuleData();
                objXmlInc.MonthlyID = Convert.ToInt32(MonthID.Text);
                objXmlInc.OtherFeeTypeID = Convert.ToInt32(OtherFeeTypeID.Text);
                objXmlInc.TotalFeeAmount = Convert.ToDecimal(TotalAmount.Text == "" ? "0" : TotalAmount.Text.Trim());
                if (IsActivate.Checked == true)
                {
                    objXmlInc.IsActivate = true;
                }
                else
                {
                    objXmlInc.IsActivate = false;
                }
                InclusiveList.Add(objXmlInc);
                check++;
            }
            objincl.XMLData = XmlConvertor.InclusiveMonthtoXML(InclusiveList).ToString();
            objincl.UserId = LoginToken.UserLoginId;
            objincl.CompanyID = LoginToken.CompanyID;
            objincl.ID = Convert.ToInt32(lblhiddenID.Text == "" ? "0" : lblhiddenID.Text);
            objincl.AcademicSessionID = Convert.ToInt32(lblhiddensessionID.Text);
            objincl.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objincl.CategoryID = Convert.ToInt32(lblhiddencategoryID.Text);
            objincl.FeeTypeID = Convert.ToInt32(lblhiddenfeetypeID.Text);
            int result = objinclBO.UpdateInclusiveMonths(objincl);
            if (result == 2)
            {
                BindInclusiveMonths();
                Gv_InclusiveMonths.DataBind();
                bindgrid(1);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                ViewState["ID"] = null;
            }
            else
            {
                BindInclusiveMonths();
                Gv_InclusiveMonths.DataSource = null;
                GvExtraRule.DataBind();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
            this.ModalPopupExtender63.Show();
        }
        protected void Gv_InclusiveMonths_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label IsActivate = (Label)e.Row.FindControl("lblInclusiveIsActivate");
                CheckBox ChkIsActivate = (CheckBox)e.Row.FindControl("chkInclusiveIsActivateMonth");
                if (IsActivate.Text == "True")
                {
                    ChkIsActivate.Checked = true;
                }
                else
                {
                    ChkIsActivate.Checked = false;
                }
            }
        }
        protected void lnbclosedpop6_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void lnbclosedpop61_Click(object sender, EventArgs e)
        {
            ddlcategoryIDpop6.SelectedValue = "0";
            this.ModalPopupExtender6.Show();
        }
        protected void lnbtnclosedpop62_Click(object sender, EventArgs e)
        {
            //this.ModalPopupExtender61.Show();
        }
        protected void lnbclosedpop63_Click(object sender, EventArgs e)
        {
            BindInclusiveOtherFeeTypes();
            this.ModalPopupExtender62.Show();
        }
        protected void chkonetimepaymentpop4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkonetimepaymentpop4.Checked)
            {
                txtdiscountlimitpop4.Enabled = true;
            }
            else
            {
                txtdiscountlimitpop4.Text = "";
                txtdiscountlimitpop4.Enabled = false;
            }
            this.ModalPopupExtender4.Show();
        }
    }
}
