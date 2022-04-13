using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Campusoft.BussinessProcess.EduHostel;

namespace Mobimp.Campusoft.Web.EduHostel
{
    public partial class HostelDepositFee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddls();
            }
        }
        protected void Ddls()
        {
            //First Tap
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicyaer, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicyaer.SelectedIndex = 1;           
            Commonfunction.PopulateDdl(ddlpaymentmode, mstlookup.GetLookupsList(LookupNames.PayMode));
            Commonfunction.PopulateDdl(ddlstudentype, mstlookup.GetLookupsList(LookupNames.AdmissionType));
            //Second Tap
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));           
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlpaymentmodes, mstlookup.GetLookupsList(LookupNames.PayMode));

        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddlss(Convert.ToInt32(ddlclasses.SelectedValue));
        }
        protected void bindddlss(int classID)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(classID));
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            HostelRegistrationData objSTD = new HostelRegistrationData();
            HostelRegistrationBO objempBO = new HostelRegistrationBO();
            List<HostelRegistrationData> getResult = new List<HostelRegistrationData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
        }
        protected void txtstdID_TextChanged(object sender, EventArgs e)
        {
            HostelRegistrationData objstd = new HostelRegistrationData();
            HostelRegistrationBO objstdBO = new HostelRegistrationBO();
            objstd.StudentID = Convert.ToInt64(txtstdID.Text == "" ? "0" : txtstdID.Text);
            hdnstudentID.Value = txtstdID.Text;
            hdnacademicID.Value = LoginToken.AcademicSessionID.ToString();
            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicyaer.SelectedValue);
            List<HostelRegistrationData> stdetails = objstdBO.GetstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                Clearall();
                txtstdID.Text = stdetails[0].StudentID.ToString();
                txtname.Text = stdetails[0].StudentName;
                txtclass.Text = stdetails[0].ClassName;
                txtsex.Text = stdetails[0].SexName;
                txtsection.Text = stdetails[0].SectionName;
                txtstudentcategory.Text = stdetails[0].CategoryName;
                txtstudenttype.Text = stdetails[0].StudentType;
                txtrollnos.Text = stdetails[0].RollNo.ToString();
                ddlstudentype.SelectedValue = stdetails[0].IsNew.ToString();
                //.......Hidden Field.......
                hdnAdmissionID.Value = stdetails[0].AdmissionID.ToString();
                hdnclassID.Value = stdetails[0].ClassID.ToString();
                hdnstreamID.Value = stdetails[0].StreamID.ToString();
                hdnstudenttype.Value = stdetails[0].IsNew.ToString();
                hdnAdmissionNo.Value = stdetails[0].AdmissionNo.ToString();
                hdnstudenttypeID.Value = stdetails[0].StudentTypeID.ToString();
                hdnIshosteregister.Value = stdetails[0].IsHostelregister.ToString();
                hdndepositamount.Value = stdetails[0].DepositAmount.ToString();
                hdnpaymentypes.Value = stdetails[0].PaymentType.ToString();
                hdnStudentcategoryID.Value = stdetails[0].StudentCategory.ToString();
                lblmessage.Visible = false;
                txtdepositamount.Text = "";
                btnsave.Attributes.Remove("disabled");

            }
            else
            {
                txtname.Text = "";
                txtclass.Text = "";
                txtsex.Text = "";
                txtsection.Text = "";
                txtstreams.Text = "";
                hdnAdmissionID.Value = "";
                hdnclassID.Value = "";
                txtstudenttype.Text = "";
                lblmessage.Visible = true;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("No record found.") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "No record found.", 0);
                return;
            }
        }
        protected void ddlpaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpaymentmode.SelectedIndex > 1)
            {
                ManBank.Visible = true;
                Manchalan.Visible = true;
                lblbankName.Visible = true;
                lblchalan.Visible = true;
                txtbankName.Visible = true;
                txtchalan.Visible = true;
            }
            else
            {
                ManBank.Visible = false;
                Manchalan.Visible = false;
                lblbankName.Visible = false;
                lblchalan.Visible = false;
                txtbankName.Visible = false;
                txtchalan.Visible = false;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DepositFeeData objfee = new DepositFeeData();
                DepositFeeBO objfeedBO = new DepositFeeBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

                if (txtdepositamount.Text == "")
                {
                    Messagealert_.ShowMessage(lblmessage, "Please enter deposit amount.", 0);
                    return;
                }
                if (txtdate.Text == "")
                {
                    Messagealert_.ShowMessage(lblmessage, "Please enter deposit date.", 0);
                    return;
                }

                objfee.AdmissioNo = Convert.ToInt64(txtstdID.Text == "" ? "0" : txtstdID.Text);
                //objfee.AdmissionID = Convert.ToInt64(hdnAdmissionID.Value);
                //objfee.ClassID = Convert.ToInt32(hdnclassID.Value);
                //objfee.AdmissioNo = hdnAdmissionNo.Value;
                //objfee.StudentTypeID = Convert.ToInt32(ddlstudentype.SelectedValue == "" ? "0" : ddlstudentype.SelectedValue);

                objfee.PayModeID = Convert.ToInt32(ddlpaymentmode.SelectedValue == "" ? "0" : ddlpaymentmode.SelectedValue);
                objfee.BankName = txtbankName.Text == "" ? null : txtbankName.Text;
                objfee.ChalanNo = txtchalan.Text == "" ? null : txtchalan.Text;
                objfee.PaymentType = Convert.ToInt32(ddlpaymentmode.SelectedValue == "" ? "0" : ddlpaymentmode.SelectedValue);
                objfee.DepositAmount = Convert.ToDecimal(txtdepositamount.Text == "" ? null : txtdepositamount.Text);
                DateTime DepositDate = txtdate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objfee.DepositDate = DepositDate;
                objfee.AcademicSessionID = LoginToken.AcademicSessionID;
                objfee.ActionType = EnumActionType.Select;
                objfee.AddedBy = LoginToken.LoginId;
                objfee.UserId = LoginToken.UserLoginId;
                objfee.CompanyID = LoginToken.CompanyID;

                int result = objfeedBO.UpdateServiceFeeDepositDetails(objfee);

                if (result > 0)
                {
                    hdnrcno.Value = result.ToString();
                    btnsave.Attributes["disabled"] = "disabled";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    //Messagealert_.ShowMessage(lblmessage, "save", 1);
                    ViewState["Count"] = null;
                    btnprint.Attributes.Remove("disabled");
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    //Messagealert_.ShowMessage(lblmessage, "system", 0);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "MessageFailed";
            }
        }
        //Tap 2 Search
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Getfeedepositdetailist();
        }
        protected void Getfeedepositdetailist()
        {

            DepositFeeData objservfee = new DepositFeeData();
            DepositFeeBO objfeedBO = new DepositFeeBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objservfee.AdmissioNo = Convert.ToInt64(txtstudentIDs.Text == "" ? "0" : txtstudentIDs.Text);
            objservfee.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objservfee.PayModeID = Convert.ToInt32(ddlpaymentmodes.SelectedValue == "" ? "0" : ddlpaymentmodes.SelectedValue);
            objservfee.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objservfee.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objservfee.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objservfee.ReceiptNo = txtrecno.Text.Trim() == "" ? "null" : txtrecno.Text.Trim();
            objservfee.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objservfee.PageSize = Gvfeedetails.PageSize;
            objservfee.CurrentIndex = 0;
            objservfee.Datefrom = from;
            objservfee.Dateto = To;
            List<DepositFeeData> result = objfeedBO.SearchDepositFeeDetails(objservfee);
            if (result.Count > 0)
            {
                lbltotaldepositamount.Text = Commonfunction.Getrounding(result[0].TotalDepositAmount.ToString());
                lbltotalbalanceamount.Text = Commonfunction.Getrounding(result[0].TotalBalanceAmount.ToString());
                lbltotalcurrentajustesamount.Text = Commonfunction.Getrounding(result[0].TotalCurrentAjustedAmount.ToString());

                Gvfeedetails.Visible = true;
                Gvfeedetails.DataSource = result;
                Gvfeedetails.DataBind();
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lblresult.CssClass = "MsgSuccess";
                lblresult.Visible = true;

            }
            else
            {
                lbltotaldepositamount.Text = "0.00";
                lbltotalbalanceamount.Text = "0.00";
                Gvfeedetails.Visible = true;
                Gvfeedetails.DataSource = null;
                Gvfeedetails.DataBind();
                lblresult.Text = "Total :No record found. ";
                lblresult.CssClass = "Message";
                lblresult.Visible = true;
            }
        }

        protected void GvDepositfeedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvfeedetails.PageIndex = e.NewPageIndex;
            Getfeedepositdetailist();
        }
        protected void GvDepositfeedetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletes")
                {

                    DepositFeeData objdepositfee = new DepositFeeData();
                    DepositFeeBO objDepositfeedBO = new DepositFeeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvfeedetails.Rows[i];

                    Label ID = (Label)gr.Cells[0].FindControl("lbldepositfeeID");
                    Label StudentsID = (Label)gr.Cells[2].FindControl("lblstudentID");
                    Label SessionID = (Label)gr.Cells[12].FindControl("lblsessionID");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    txtremarks.Attributes.Remove("disabled");
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter remarks") + "')", true);
                        //Messagealert_.ShowMessage(lblresult, "Please enter remarks", 0);
                        return;
                    }
                    else
                    {
                        objdepositfee.Remarks = txtremarks.Text;
                    }
                    objdepositfee.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    objdepositfee.StudentsID = Convert.ToInt32(StudentsID.Text == "" ? "0" : StudentsID.Text);
                    objdepositfee.AcademicSessionID = Convert.ToInt32(SessionID.Text == "" ? "0" : SessionID.Text);
                    objdepositfee.UserId = LoginToken.UserLoginId;
                    int Result = objDepositfeedBO.DeleteDepositFeesByID(objdepositfee);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        //Messagealert_.ShowMessage(lblresult, "delete", 1);
                        Getfeedepositdetailist();
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                        Messagealert_.ShowMessage(lblresult, "system", 0);
                    }
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        //Tap 1 reset
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Clearall();
        }
        protected void Clearall() // Tap1 Reset all field
        {
            txtstdID.Text = "";
            txtsex.Text = "";
            txtstreams.Text = "";
            txtsection.Text = "";
            ddlpaymentmode.SelectedIndex = 1;
            txtdepositamount.Text = "";
            txtclass.Text = "";
            txtbankName.Text = "";
            txtbankName.Visible = false;
            txtchalan.Text = "";
            txtchalan.Visible = false;
            ManBank.Visible = false;
            lblbankName.Visible = false;
            lblchalan.Visible = false;
            Manchalan.Visible = false;
            hdnclassID.Value = null;
            hdnAdmissionID.Value = "";
            hdnBillGroup.Value = "";
            hdnstreamID.Value = "";
            txtname.Text = "";
            lblmessage.Visible = false;
            txtstudenttype.Text = "";
            hdnstudenttypeID.Value = null;
            btnsave.Attributes["disabled"] = "disabled";
            btnprint.Attributes["disabled"] = "disabled";
            hdnStudentcategoryID.Value = null;
            hdnIshosteregister.Value = null;
            ViewState["Count"] = null;
            txtrollnos.Text = "";
            txtstudenttype.Text = "";
            txtstudentcategory.Text = "";
            txtdate.Text = "";
            ddlstudentype.SelectedIndex = 0;
            hdnpaidamount.Value = null;
        }
        //tap 2 reset 
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        protected void resetall() // Tap 2 Reset
        {
            txtstudentIDs.Text = "";
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Section));
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Gvfeedetails.DataSource = null;
            Gvfeedetails.DataBind();
            Gvfeedetails.Visible = false;
            txtfrom.Text = "";
            txtto.Text = "";
            ddlstatus.SelectedIndex = 0;
            ddlsections.SelectedIndex = 0;
            ddlpaymentmodes.SelectedIndex = 0;
            txtrecno.Text = "";
            lblresult.Visible = false;
            lblmesagesdepositlist.Visible = false;
            lbltotaldepositamount.Text = "0.00";
            lbltotalbalanceamount.Text = "0.00";
            txtstudentcategory.Text = "";
        } 
    }
    
}