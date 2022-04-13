using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using System.IO;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Web.UserControls;
using System.Data;
using System.Reflection;
using System.Configuration;

namespace Mobimp.Edusoft.Web.EduStudent
{
    public partial class AdmissionWithFee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                //GetAvailableStudentID();
                txtStudentID.Attributes["disabled"] = "disabled";
                txtfeeamount.Attributes["disabled"] = "disabled";
                txtexempted.Attributes["disabled"] = "disabled";
                txttotalamount.Attributes["disabled"] = "disabled";
                txtPayableAmount.Attributes["disabled"] = "disabled";
                ddlamdission.Attributes["disabled"] = "disabled";
                //btnsave.Attributes["disabled"] = "disabled";
                btnprint.Attributes["disabled"] = "disabled";
                txtDue.Attributes["disabled"] = "disabled";
                //txttotalamount.Attributes["disabled"] = "disabled";
            }
        }

        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsex, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlstudenttype, mstlookup.GetLookupsList(LookupNames.StudentType));
            Commonfunction.PopulateDdl(ddlamdission, mstlookup.GetLookupsList(LookupNames.Admissiontype));
            ddlamdission.SelectedIndex = 1; 
        }

        protected void ddlamdission_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlamdission.SelectedValue == "1")
            {
                txtStudentID.Attributes["disabled"] = "disabled";
            }
            else
            {
                txtStudentID.Attributes.Remove("disabled");
            }
        }
        
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsection, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclass.SelectedValue)));
        }
        
        protected void ddlstudenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlclass.SelectedIndex>0)
            {
                FeeCollectionData objFeeData = new FeeCollectionData();
                FeeCollectionBO objitemBO = new FeeCollectionBO();

                objFeeData.AcademicSessionID = LoginToken.AcademicSessionID; // Convert.ToInt32(ddla.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                objFeeData.FeeTypeID = 1; //Convert.ToInt32(ddlfeetype.SelectedValue == "" ? "0" : ddlfeetype.SelectedValue);
                objFeeData.StudentTypeID = Convert.ToInt32(ddlstudenttype.SelectedValue == "" ? "0" : ddlstudenttype.SelectedValue);
                objFeeData.AdmissionType = Convert.ToInt32(ddlamdission.SelectedValue == "" ? "0" : ddlamdission.SelectedValue);
                objFeeData.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                List<FeeCollectionData> result = objitemBO.GetClasswiseFeesDetail(objFeeData);
                if (result.Count > 0)
                {
                    txtfeeamount.Text = result[0].FeeAmount.ToString("N2");
                    txtexempted.Text = result[0].ExemptedAmount.ToString("N2");
                    txtFineAmount.Text = result[0].FineAmount.ToString("N2");
                    txttotalamount.Text = result[0].TotalFeeAmount.ToString("N2");
                    //CLEAR BEFORE SET
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please Set the Fee Amount.") + "')", true);
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                AdmissionWithFeeData objstd = new AdmissionWithFeeData();
                AdmissionWithFeeBO objstdBO = new AdmissionWithFeeBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

                objstd.IsNew = Convert.ToInt32(ddlamdission.SelectedValue == "" ? "0" : ddlamdission.SelectedValue);
                objstd.AdmissionNo = txtStudentID.Text.Trim();
                objstd.StudentName = txtstudentname.Text == "" ? null : txtstudentname.Text.Trim();
                DateTime DOB = txtDOB.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDOB.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objstd.DOB = DOB;
                DateTime AdmDate = txtadmissioDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtadmissioDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objstd.AdmissionDate = AdmDate;
                objstd.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objstd.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
                objstd.RollNo = Convert.ToInt32(txtrollno.Text == "" ? "0" : txtrollno.Text);
                objstd.StudentTypeID = Convert.ToInt32(ddlstudenttype.SelectedValue == "" ? "0" : ddlstudenttype.SelectedValue);
                objstd.SexID = Convert.ToInt32(ddlsex.SelectedValue == "" ? "0" : ddlsex.SelectedValue);
                objstd.cAddress = txtaddress.Text == "" ? null : txtaddress.Text.Trim();
                objstd.GmobileNo = txtgmobile.Text == "" ? null : txtgmobile.Text.Trim();

                objstd.AddedBy = LoginToken.LoginId;
                objstd.UserId = LoginToken.UserLoginId;
                objstd.AcademicSessionID = LoginToken.AcademicSessionID;
                //if (ddlamdission.SelectedValue == "2" && txtStudentID.Text == "")
                //{

                //    txtStudentID.Focus();
                //    Messagealert_.ShowMessage(lblmessage, "Please Enter Admission No.", 0);
                //    return;
                //}
                int results = objstdBO.UpdateStudentDetails(objstd);
                if (results > 0)
                {
                    txtStudentID.Text = results.ToString();
                    getAdmissionFeeDetails();
                    btnprint.Attributes.Remove("disabled");
                }
                else if (results == -1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Admission Number Already Exist.") + "')", true);
                    //Messagealert_.ShowMessage(lblmessage, "Admission Number Already Exist.", 0);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void clearall()
        {
            ddlamdission.SelectedIndex = 1;
            txtStudentID.Text = "";
            txtStudentID.Attributes["disabled"] = "disabled";
            ddlstudenttype.SelectedIndex = 0;
            ddlsex.SelectedIndex = 0;
            ddlclass.SelectedIndex = 0;
            ddlsection.SelectedIndex = 0;
            txtstudentname.Text = "";
            txtDOB.Text = "";
            txtaddress.Text = "";
            txtgmobile.Text = "";
            lblmessage.Visible = false;
            txtbillno.Text = "";
            txtfeeamount.Text = "";
            txtexempted.Text = "";
            txttotalamount.Text = "";
            txtDiscount.Text = "";
            txtFineAmount.Text = "";
            txtPayableAmount.Text = "";
            txtpaidamount.Text = "";
            txtDue.Text = "";
            txtremarks.Text = "";
            hdnbillno.Value = "0";
            hdnfeetypeID.Value = "0";
            hdnacademicID.Value = "0";
            btnsave.Attributes.Remove("disabled");
            btnprint.Attributes["disabled"] = "disabled";
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }

        ///////////////////////////////   FEE PART

        protected void txtexempted_TextChanged(object sender, EventArgs e)
        {
            Decimal FeeAmount = Convert.ToDecimal(txtfeeamount.Text.Trim());
            Decimal ExemptedAmount = Convert.ToDecimal(txtexempted.Text.Trim() == "" ? "0.0" : txtexempted.Text.Trim());
            txttotalamount.Text = Convert.ToString(FeeAmount - ExemptedAmount);
            txtDiscount.Focus();

            Decimal discount = Convert.ToDecimal(txtDiscount.Text.Trim() == "" ? "0.0" : txtDiscount.Text.Trim());
            Decimal TotalAmount = Convert.ToDecimal(txttotalamount.Text.Trim());
            txtPayableAmount.Text = Convert.ToString(TotalAmount - discount);
            txtpaidamount.Text = Convert.ToString(TotalAmount - discount);
            hdnPaidAmount.Value = Convert.ToString(TotalAmount - discount);
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            
            Decimal discount = Convert.ToDecimal(txtDiscount.Text.Trim() == "" ? "0.0" : txtDiscount.Text.Trim());
            Decimal TotalAmount = Convert.ToDecimal(txttotalamount.Text.Trim());
            txtPayableAmount.Text = Convert.ToString(TotalAmount - discount);
            txtpaidamount.Text = Convert.ToString(TotalAmount - discount);
            hdnPaidAmount.Value = Convert.ToString(TotalAmount - discount);
            txtFineAmount.Focus();
            //if (txtDiscount.Text != "")
            //{
            //    txtDiscount.Attributes["disabled"] = "disabled";
            //}
            //else
            //{
            //    txtDiscount.Attributes.Remove("disabled");
            //}
        }

        protected void txtfine_TextChanged(object sender, EventArgs e)
        {
            Decimal total;
            Decimal TotalAmount = Convert.ToDecimal(txttotalamount.Text.Trim());
            Decimal discount = Convert.ToDecimal(txtDiscount.Text.Trim() == "" ? "0.0" : txtDiscount.Text.Trim());
            
            total = Convert.ToDecimal(TotalAmount - discount + Convert.ToDecimal(txtFineAmount.Text.Trim() == "" ? "0.0" : txtFineAmount.Text.Trim()));
            txtPayableAmount.Text = Commonfunction.Getrounding(total.ToString());
            txtpaidamount.Text = Commonfunction.Getrounding(total.ToString());
            hdnPaidAmount.Value = Commonfunction.Getrounding(total.ToString());
            txtpaidamount.Focus();
            //txtFineAmount.Enabled = false;
        }

        protected void txtpaidamount_TextChanged(object sender, EventArgs e)
        {
            Decimal hdnPaidAmt = Convert.ToDecimal(hdnPaidAmount.Value);
            Decimal paidAmount = Convert.ToDecimal(txtpaidamount.Text.Trim());
            if (paidAmount <= hdnPaidAmt)
            {
                txtDue.Focus();
                txtDue.Text = Convert.ToString(hdnPaidAmt - paidAmount);
                btnsave.Attributes.Remove("disabled");
            }
            else if (paidAmount > hdnPaidAmt)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("The Amount shouldn't exceed the Paid Amount") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "The Amount shouldn't exceed the Paid Amount", 0);
                return;
            }
        }

        protected void getfeedetailsBystudenttypeID()
        {
            AdmFeeData objfee = new AdmFeeData();
            AdmissionWithFeeBO objfeedBO = new AdmissionWithFeeBO();

            objfee.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "3" ? "0" : ddlclass.SelectedValue);
            objfee.AdmissionTypeID = Convert.ToInt32(ddlamdission.SelectedValue == "" ? "0" : ddlamdission.SelectedValue);
            objfee.StudentTypeID = Convert.ToInt32(ddlstudenttype.SelectedValue == "" ? "0" : ddlstudenttype.SelectedValue);
            objfee.AcademicSessionID = LoginToken.AcademicSessionID;

            List<AdmFeeData> lsfeesamount = objfeedBO.getfeedetailsBystudenttypeID(objfee);
            if (lsfeesamount.Count > 0)
            {
                txtfeeamount.Text = Commonfunction.Getrounding(lsfeesamount[0].FeeAmount.ToString());
                txtexempted.Text = Commonfunction.Getrounding(lsfeesamount[0].ExemptedAmount.ToString());
                txtFineAmount.Text = Commonfunction.Getrounding(lsfeesamount[0].FineAmount.ToString());
                txttotalamount.Text = Commonfunction.Getrounding(lsfeesamount[0].TotalFeeAmount.ToString());

                txtpaidamount.Text = Commonfunction.Getrounding(lsfeesamount[0].TotalFeeAmount.ToString());
                hdnPaidAmount.Value = Commonfunction.Getrounding(lsfeesamount[0].TotalFeeAmount.ToString());
            }
            else
            {
                txtfeeamount.Text = "";
                txttotalamount.Text = "";
                txtFineAmount.Text = "";
                txtexempted.Text = "";
                txtpaidamount.Text = "";
            }
        }
        
        protected void getAdmissionFeeDetails()
        {
            AdmFeeData objfee = new AdmFeeData();
            AdmissionWithFeeBO objfeedBO = new AdmissionWithFeeBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

            objfee.StudentID = Convert.ToInt64(txtStudentID.Text == "" ? "0" : txtStudentID.Text);
            objfee.FeeAmount = Convert.ToDecimal(txtfeeamount.Text == "" ? null : txtfeeamount.Text);
            objfee.PaidAmount = Convert.ToDecimal(txtpaidamount.Text == "" ? null : txtpaidamount.Text);
            objfee.FineAmount = Convert.ToDecimal(txtFineAmount.Text == "" ? null : txtFineAmount.Text);
            objfee.ExemptedAmount = Convert.ToDecimal(txtexempted.Text == "" ? null : txtexempted.Text);
            objfee.TotalFeeAmount = Convert.ToDecimal(txttotalamount.Text == "" ? null : txttotalamount.Text);
            objfee.DiscountAmount = Convert.ToDecimal(txtDiscount.Text == "" ? null : txtDiscount.Text);
            objfee.DueAmount = Convert.ToDecimal(txtDue.Text == "" ? null : txtDue.Text);
            objfee.Remark = txtremarks.Text.Trim();
            objfee.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objfee.AdmissionTypeID = Convert.ToInt32(ddlamdission.SelectedValue == "" ? "0" : ddlamdission.SelectedValue);
            objfee.StudentTypeID = Convert.ToInt32(ddlstudenttype.SelectedValue == "" ? "0" : ddlstudenttype.SelectedValue);
            objfee.AcademicSessionID = LoginToken.AcademicSessionID;
            DateTime AdmDate = txtadmissioDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtadmissioDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objfee.AdmissionDate = AdmDate;
            objfee.AddedBy = LoginToken.LoginId;
            objfee.UserId = LoginToken.UserLoginId;

            int result = objfeedBO.UpdateAdmissionFeeDetails(objfee);
            if (result > 0)
            {
                txtbillno.Text = result.ToString();
                hdnbillno.Value = result.ToString();
                hdnfeetypeID.Value = "1";
                hdnacademicID.Value = Convert.ToString(LoginToken.AcademicSessionID);
                btnprint.Attributes.Remove("disabled");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                btnsave.Attributes["disabled"] = "disabled";
                //Messagealert_.ShowMessage(lblmessage, result != 2 ? "save" : "update", 1);
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("System") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "System error", 0);
            }
        }

        protected void txtPayableAmount_TextChanged(object sender, EventArgs e)
        {

            btnsave.Attributes.Remove("disabled");
        }
    }
}