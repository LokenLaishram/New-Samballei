using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Web.UserControls;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;
using static Mobimp.Edusoft.Data.EduFees.FeeCollectionData;

namespace Mobimp.Campusoft.Web.EduFees
{
    public partial class SchoolFeesCollection : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindddls();               
                divsearch.Visible = false;
                FeeCollectionDetailsListButtom.Visible = false;
                txtcareof.Attributes["disabled"]= "disabled";
                txtadmissiontype.Attributes["disabled"] = "disabled";
                txtstudenttype.Attributes["disabled"] = "disabled";
                txtbillno.Attributes["disabled"] = "disabled";
                btnsave.Attributes["disabled"] = "disabled";
                btnprint.Attributes["disabled"] = "disabled";
            }
        }
        protected void Bindddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
               
            Commonfunction.PopulateDdl(ddlfeetype, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            //  Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));           
            // Commonfunction.PopulateDdl(ddladmissiontype, mstlookup.GetLookupsList(LookupNames.Admissiontype));
            AutoCompleteExtender1.ContextKey = ddlacademicsession.SelectedValue;
            //FOR TAB 2
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            txtstudentanme.Attributes["disabled"] = "disabled";
            AutoCompleteExtenderstudentanme.ContextKey = ddlacademicseesions.SelectedValue;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlcategorys, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddluser, mstlookup.GetLookupsList(LookupNames.Clerk));
            
            Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Section));
            Commonfunction.PopulateDdl(ddlfeetypess, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            Commonfunction.PopulateDdl(ddlpaymentmodes, mstlookup.GetLookupsList(LookupNames.PayMode));
            Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetLookupsList(LookupNames.RouteNo));
            lbltotalpayable.Text = "0.00";
            lbltotfine.Text = "0.00";
            lblexemptedamount.Text = "0.00";
              }
        //TAB 2
        protected void ddlrouteno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlrouteno.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlvihicle, objmstlookupBO.GetVihicleByRootID(Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            }
        }        
        
        protected void ddlfeetypess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlfeetypess.SelectedValue == "3")
            {
                lblrouteno.Visible = true;
                ddlrouteno.Visible = true;
                lblvihicle.Visible = true;
                ddlvihicle.Visible = true;
            }
            else
            {
                lblrouteno.Visible = false;
                ddlrouteno.Visible = false;
                lblvihicle.Visible = false;
                ddlvihicle.Visible = false;
            }
        }
       
        protected void ddlsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCompleteExtender1.ContextKey = ddlacademicsession.SelectedValue;
        }
   
       // [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
       //public static List<string> GetStudentDetails(string prefixText, int count, string contextKey)
       // {
       //     FeeData objitemName = new FeeData();
       //     FeeBO objitemBO = new FeeBO();
       //     List<FeeData> getResult = new List<FeeData>();
       //     objitemName.StudentDetail = prefixText;
       //     objitemName.AcademicSessionID = Convert.ToInt32(contextKey);
       //     getResult = objitemBO.GetAutoStudentDetails(objitemName);

       //     List<String> list = new List<String>();
       //     for (int i = 0; i < getResult.Count; i++)
       //     {
       //         list.Add(getResult[i].StudentDetail.ToString());
       //     }

       //     return list;
       // }
        protected void stddetail_OnTextChanged(object sender, EventArgs e)
       {            
            ddlfeetype.SelectedIndex = 0;

            if (txtstddetail.Text != "")
            {
                FeeData objFeeData = new FeeData();
                FeeBO objitemBO = new FeeBO();
                var source = txtstddetail.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objFeeData.StudentID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objFeeData.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue);
                }
                else
                {
                    txtstddetail.Text = "";
                    txtstddetail.Text = "";
                    return;
                }
                List<FeeData> result = objitemBO.GetStudentDetailByID(objFeeData);
                if (result.Count > 0)
                {
                    hdstutypid.Value = result[0].StudentTypeID.ToString();
                    txtstudenttype.Text = result[0].StudentType.ToString();
                    txtadmissiontype.Text = result[0].AdmissionType.ToString();
                    txtcareof.Text = result[0].Gfirstname.ToString();
                    //hidden part
                    hdnTransportStudentTypeID.Value = result[0].TransportStudentTypeID.ToString();
                    txttransportstdtype.Text = result[0].TransportStudentTypeName.ToString();
                    hdnBoardingStudentTypeID.Value = result[0].BoardingStudentTypeID.ToString();
                    txtbordingstdtype.Text = result[0].BoardingStudentTypeName.ToString();
                    txtisadmissiondone.Value = result[0].IsAdmissionDone.ToString();
                    hdnistakingtransport.Value = result[0].Istakingtransports.ToString();
                    hdnisboardingstudent.Value = result[0].IsBoardingStudent.ToString();
                    hdnIsBoardingAdmissionDone.Value = result[0].IsBoardingAdmissionDone.ToString();
                    hdstudentid.Value = result[0].StudentID.ToString();
                    hdadmissiontypeID.Value = result[0].IsNew.ToString();                  
                    hdclassid.Value = result[0].ClassID.ToString();
                    hdrollno.Value = result[0].RollNo.ToString();
                    GvFeedetails.DataSource = null;
                    GvFeedetails.DataBind();
                    ddlfeetype.Focus();
                    txtstudenttype.Attributes["disabled"] = "disabled";
                    txtadmissiontype.Attributes["disabled"] = "disabled";
                    txtcareof.Attributes["disabled"] = "disabled";
                    txtbillno.Attributes["disabled"] = "disabled";
                    txttransportstdtype.Attributes["disabled"] = "disabled";
                    txtbordingstdtype.Attributes["disabled"] = "disabled";
                    txtparticular.Attributes["disabled"] = "disabled";
                    txtparticularamt.Attributes["disabled"] = "disabled";

                }
            }
        }

        protected void ddlfeetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridchange();  
        }
        private void gridchange()
        {
            FeeCollectionData objFeeData = new FeeCollectionData();
            FeeCollectionBO objitemBO = new FeeCollectionBO();
            if (txtstddetail.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Student Details cannot be blank.") + "')", true);
                //txttotaldiscount.Enabled = false;
                //txttotalpaidamt.Enabled = false;
                //btnsave.Enabled = false;
                //btnprint.Enabled = false;
                txttotaldiscount.Attributes["disabled"] = "disabled";
                txttotalpaidamt.Attributes["disabled"] = "disabled";
                btnsave.Attributes["disabled"] = "disabled";
                btnprint.Attributes["disabled"] = "disabled";
                return;
            }
            objFeeData.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objFeeData.FeeTypeID = Convert.ToInt32(ddlfeetype.SelectedValue == "" ? "0" : ddlfeetype.SelectedValue);
            objFeeData.StudentID = Convert.ToInt32(hdstudentid.Value == "" ? "0" : hdstudentid.Value);
            objFeeData.StudentTypeID = Convert.ToInt32(hdstutypid.Value == "" ? "0" : hdstutypid.Value);
            objFeeData.AdmissionType = Convert.ToInt32(hdadmissiontypeID.Value == "" ? "0" : hdadmissiontypeID.Value);
            objFeeData.ClassID = Convert.ToInt32(hdclassid.Value == "" ? "0" : hdclassid.Value);
            objFeeData.RollNo = Convert.ToInt32(hdrollno.Value == "" ? "0" : hdrollno.Value);
            List<FeeCollectionData> result = objitemBO.GetClasswiseFeesDetail(objFeeData);
            if (result.Count > 0)
            {
                GvFeedetails.Visible = true;
                GvFeedetails.DataSource = result;
                GvFeedetails.DataBind();
                hdnfeeamount.Text = result[0].FeeAmount.ToString("N2");
                hdnexemptedamount.Text = result[0].ExemptedAmount.ToString("N2");
                hdnfineamount.Text = result[0].FineAmount.ToString("N2");
                hdntotalfeeamount.Text = result[0].TotalFeeAmount.ToString("N2");
                txtisadmissiondone.Value = result[0].AdmissionStatus.ToString();
                hdnIsBoardingAdmissionDone.Value = result[0].BoardingStatus.ToString();
                hdnistakingtransport.Value = result[0].Istakingtransports.ToString();

                //CLEAR BEFORE SET
                lblgrandtotalfeeamount.Text = "";
                lbltotalnetamount.Text = "";
                lbltotalexemptamount.Text = "";
                txttotaldiscount.Text = "";
                lbltotalpayableamt.Text = "";
                txttotalpaidamt.Text = "";
                lbltotaldueamt.Text = "";
                //txttotaldiscount.Enabled = true;
                //txttotalpaidamt.Enabled = true;
                //btnsave.Enabled = true;
                txttotaldiscount.Attributes.Remove("disabled");
                txttotalpaidamt.Attributes.Remove("disabled");
                btnsave.Attributes.Remove("disabled");
                //lblmessage.Text = "";

                if (ddlfeetype.SelectedValue == "1")
                {

                    //Check the student is admission done or not
                    if (txtisadmissiondone.Value == "1")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Admission fee has clear for this student.") + "')", true);
                        //Messagealert_.ShowMessage(lblmessage, " Admission fee has clear for this student. ", 0);
                        visible();
                    }
                    else
                    {
                        //txttotaldiscount.Enabled = true;
                        //txttotalpaidamt.Enabled = true;
                        //btnsave.Enabled = true;
                        //btnprint.Enabled = true;
                        txttotaldiscount.Attributes.Remove("disabled");
                        txttotalpaidamt.Attributes.Remove("disabled");
                        btnsave.Attributes.Remove("disabled");
                        btnprint.Attributes.Remove("disabled");
                        //lblmessage.Text = "";
                    }
                }
                if (ddlfeetype.SelectedValue == "2" || ddlfeetype.SelectedValue == "3")
                {
                    if (txtisadmissiondone.Value != "1")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Admission fee is still not clear for this student. Please do admission first before you pay other fee.") + "')", true);
                        //Messagealert_.ShowMessage(lblmessage, " Admission fee is still not clear for this student. Please do admission first before you pay other fee. ", 0);
                        visible();
                        return;
                    }
                }
                if (ddlfeetype.SelectedValue == "3")
                {
                    if (hdnistakingtransport.Value != "1")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This student is not register in transport!. Please register first.") + "')", true);
                        //Messagealert_.ShowMessage(lblmessage, " This student is not register in transport!. Please register first. ", 0);
                        visible();
                        return;
                    }
                }
                if (ddlfeetype.SelectedValue == "4" || ddlfeetype.SelectedValue == "5")
                {
                    if (hdnisboardingstudent.Value != "1")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This student is not register in boarding!. Please register first.") + "')", true);
                        //Messagealert_.ShowMessage(lblmessage, " This student is not register in boarding!. Please register first. ", 0);
                        visible();
                        return;
                    }
                }
                if (ddlfeetype.SelectedValue == "4")
                {
                    if (hdnIsBoardingAdmissionDone.Value != "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(" Boarding Admission already done") + "')", true);
                        //Messagealert_.ShowMessage(lblmessage, " Boarding Admission already done ", 0);
                        visible();
                        return;
                    }
                }
                if (ddlfeetype.SelectedValue == "5")
                {
                    if (txtisadmissiondone.Value != "1")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Boarding Admission fee is not clear for this student. Please do boarding admission first..") + "')", true);
                        //Messagealert_.ShowMessage(lblmessage, " Boarding Admission fee is not clear for this student. Please do boarding admission first.. ", 0);
                        visible();
                        return;
                    }
                }
                if (Convert.ToInt32(ddlfeetype.SelectedValue) == 7)
                {
                    lblparticular.Visible = true;
                    txtparticular.Visible = true;
                    lblparticularamt.Visible = true;
                    txtparticularamt.Visible = true;
                    btnadd.Visible = true;
                    btnadd.Attributes.Remove("disabled");
                }
                else
                {
                    lblparticular.Visible = false;
                    txtparticular.Visible = false;
                    lblparticularamt.Visible = false;
                    txtparticularamt.Visible = false;

                    txtbordingstdtype.Visible = false;
                    txtbordingstdtype.Visible = false;
                    txttransportstdtype.Visible = false;

                    btnadd.Visible = false;
                    //btnadd.Enabled = false;
                    btnadd.Attributes["disabled"] = "disabled";
                }
                if (Convert.ToInt32(ddlfeetype.SelectedValue) == 3 || Convert.ToInt32(ddlfeetype.SelectedValue) == 4 || Convert.ToInt32(ddlfeetype.SelectedValue) == 5)
                {
                    lblbortranstdtype.Visible = true;

                    if (Convert.ToInt32(ddlfeetype.SelectedValue) == 3)
                    {
                        txttransportstdtype.Visible = true;
                    }
                    else
                    {
                        txttransportstdtype.Visible = false;

                    }
                    if (Convert.ToInt32(ddlfeetype.SelectedValue) == 4 || Convert.ToInt32(ddlfeetype.SelectedValue) == 5)
                    {
                        txtbordingstdtype.Visible = true;
                    }
                    else
                    {
                        txtbordingstdtype.Visible = false;

                    }
                }
                else
                {
                    lblbortranstdtype.Visible = false;
                }
            }
            else
            {
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                lblgrandtotalfeeamount.Text = "0.00";
                lbltotalpayableamt.Text = "0.00";
                //txttotaldiscount.Enabled = false;
                txttotaldiscount.Attributes["disabled"] = "disabled";
                //txttotalpaidamt.Enabled = false;
                txttotalpaidamt.Attributes["disabled"] = "disabled";
                //btnsave.Enabled = false;
                btnsave.Attributes["disabled"] = "disabled";
                //lblmessage.Text = "";
            }
        }
        protected void GvFeedetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            foreach (GridViewRow row in GvFeedetails.Rows)
            {
                try
                {
                    Label Status = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblFeeStatus");
                    CheckBox FeeCheckBox = (CheckBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("chkfeestatus");
                    Label feepaid = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblfeepaid");
                    if (Status.Text == "1")
                    {
                        feepaid.CssClass = "indicator";
                        FeeCheckBox.Visible = false;
                        feepaid.Visible = true;
                    }
                    else
                    {
                        feepaid.CssClass = "indicator2";
                        FeeCheckBox.Visible = true;
                        feepaid.Visible = false;
                    }
                }

                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                    //lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }

        }
        // SUM OF CHECK CHECKBOX
        protected void visible()
        {
            //txttotaldiscount.Enabled = false;
            txttotaldiscount.Attributes["disabled"] = "disabled";
            //txttotalpaidamt.Enabled = false;
            txttotalpaidamt.Attributes["disabled"] = "disabled";
            //btnsave.Enabled = false;
            btnsave.Attributes["disabled"] = "disabled";
            //btnprint.Enabled = false;
            btnprint.Attributes["disabled"] = "disabled";
            GvFeedetails.Visible = false;
        }
        protected void checkboxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            double SumFeeAmount = 0;
            double SumExemptAmount = 0;
            double SumFineAmount = 0;
            double SumTotalAmount = 0;
            foreach (GridViewRow gvr in GvFeedetails.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("chkfeestatus");
                if (cb.Checked)
                {
                    gvr.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                {
                    gvr.BackColor = System.Drawing.Color.Transparent;
                }
                if (cb.Checked && cb != null)
                {
                    Label FeeAmount = (Label)(gvr.FindControl("lblfeeamount"));
                    Label ExemptAmount = (Label)(gvr.FindControl("lblexemptamount"));
                    Label FineAmount = (Label)(gvr.FindControl("lblfineamount"));
                    Label TotalAmount = (Label)(gvr.FindControl("lbltotalamount"));

                    double FeeAmt = Convert.ToDouble(FeeAmount.Text);
                    double ExmptAmt = Convert.ToDouble(ExemptAmount.Text);
                    double FineAmt = Convert.ToDouble(FineAmount.Text);
                    double TotalAmt = Convert.ToDouble(TotalAmount.Text);
                    SumFeeAmount += FeeAmt;
                    SumExemptAmount += ExmptAmt;
                    SumFineAmount += FineAmt;
                    SumTotalAmount += TotalAmt;
                    hdntotalsumfeeamount.Text = SumFeeAmount.ToString("N2");
                    lbltotalexemptamount.Text = SumExemptAmount.ToString("N2");
                    lbltotalfineamount.Text = SumFineAmount.ToString("N2");
                    lblgrandtotalfeeamount.Text = SumTotalAmount.ToString("N2");
                    lbltotalpayableamt.Text = SumTotalAmount.ToString("N2");

                    txttotaldiscount.Text = "0";
                    txttotalpaidamt.Text = SumTotalAmount.ToString("N2");
                    lbltotaldueamt.Text = "0";
                    //btnsave.Enabled = true;
                    btnsave.Attributes.Remove("disabled");
                    btnsave.Focus();
                }
            }
            if (SumFeeAmount == 0)
            {
                lbltotalexemptamount.Text = "";
                lbltotalfineamount.Text = "";
                lblgrandtotalfeeamount.Text = "";
                lbltotalpayableamt.Text = "";
                txttotaldiscount.Text = "0";
                txttotalpaidamt.Text = "0";
                lbltotaldueamt.Text = "0";
                //btnsave.Enabled = false;
                btnsave.Attributes["disabled"] = "disabled";
            }
        }

        protected void discount_OnTextChanged(object sender, EventArgs e)
        {
            DiscountCal();
            txttotalpaidamt.Focus();
        }
        protected void DiscountCal()
        {
            double NetAmount = 0;
            double DisAmt = 0;
            double PayableAmt = 0;

            //Discount Calculation
            NetAmount = Convert.ToDouble(lblgrandtotalfeeamount.Text == "" ? "0" : lblgrandtotalfeeamount.Text);
            DisAmt = Convert.ToDouble(txttotaldiscount.Text == "" ? "0" : txttotaldiscount.Text);
            if (NetAmount >= DisAmt)
            {
                PayableAmt = (NetAmount - DisAmt);
                lbltotalpayableamt.Text = PayableAmt.ToString("N2");
                txttotalpaidamt.Text = PayableAmt.ToString("N2");
                lbltotaldueamt.Text = "0";
                //lblmessage.Text = "";               
                //btnsave.Enabled = true;
                btnsave.Attributes.Remove("disabled"); 
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Discount amount cannot be greater than payable amount") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "Discount amount cannot be greater than payable amount", 0);
                return;
            }
        }
        protected void paid_OnTextChanged(object sender, EventArgs e)
        {
            PaidCal();
        }
        protected void PaidCal()
        {
            Decimal PayableAmt = 0;
            Decimal PaidAmt = 0;
            Decimal DueAmt = 0;

            //Discount Calculation
            PayableAmt = Convert.ToDecimal(lbltotalpayableamt.Text == "" ? "0" : lbltotalpayableamt.Text);
            PaidAmt = Convert.ToDecimal(txttotalpaidamt.Text == "" ? "0" : txttotalpaidamt.Text);
            if (PayableAmt >= PaidAmt)
            {
                DueAmt = (PayableAmt - PaidAmt);
                lbltotaldueamt.Text = DueAmt.ToString("N2");
                //lblmessage.Text = "";
                //btnsave.Enabled = true;
                btnsave.Attributes.Remove("disabled");
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Paid amount cannot be greater than payable amount") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "Paid amount cannot be greater than payable amount", 0);
                return;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            List<FeeCollectionData> lstfeestatus = new List<FeeCollectionData>();
            FeeCollectionData objfee = new FeeCollectionData();
            FeeCollectionBO objfeedBO = new FeeCollectionBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            int index = 0;
            Decimal Disc = 0;
            if (hdstutypid.Value == "1" || hdstutypid.Value == "9" || hdstutypid.Value == "10" || hdstutypid.Value == "112")
            {
                if (txttotalpaidamt.Text == "" || txttotalpaidamt.Text == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter paid amount.") + "')", true);
                    //Messagealert_.ShowMessage(lblmessage, "Please enter paid amount.", 0);
                    return;
                }
            }
            if (ddlfeetype.SelectedValue == "1" || ddlfeetype.SelectedValue == "4")
            {
                objfee.FeeAmount = Convert.ToDecimal(hdnfeeamount.Text == "" ? "0" : hdnfeeamount.Text);
                objfee.ExemptedAmount = Convert.ToDecimal(hdnexemptedamount.Text == "" ? "0" : hdnexemptedamount.Text);
                objfee.FineAmount = Convert.ToDecimal(hdnexemptedamount.Text == "" ? "0" : hdnexemptedamount.Text);
                objfee.TotalAmount = Convert.ToDecimal(hdntotalfeeamount.Text == "" ? "0" : hdntotalfeeamount.Text);
            }
            if (ddlfeetype.SelectedValue == "2" || ddlfeetype.SelectedValue == "3" || ddlfeetype.SelectedValue == "5")
            {
                foreach (GridViewRow row in GvFeedetails.Rows)
                {
                    CheckBox ChkFeeStatus = (CheckBox)GvFeedetails.Rows[index].Cells[0].FindControl("chkfeestatus");
                    Label MonthID = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblmonthID");
                    Label FeeAmount = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblfeeamount");
                    Label ExemptedAmount = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblexemptamount");
                    Label FineAmount = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblfineamount");
                    Label TotalAmount = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lbltotalamount");

                    FeeCollectionData objfeedata = new FeeCollectionData();
                    if (ChkFeeStatus.Checked)
                    {
                        objfeedata.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
                        objfeedata.FeeAmount = Convert.ToInt32(FeeAmount.Text == "" ? "0" : FeeAmount.Text);
                        objfeedata.ExemptedAmount = Convert.ToInt32(ExemptedAmount.Text == "" ? "0" : ExemptedAmount.Text);
                        objfeedata.FineAmount = Convert.ToInt32(FineAmount.Text == "" ? "0" : FineAmount.Text);
                        objfeedata.TotalAmount = Convert.ToInt32(TotalAmount.Text == "" ? "0" : TotalAmount.Text);
                    }
                    else
                    {
                    }
                    lstfeestatus.Add(objfeedata);
                    index++;
                }
                objfee.xmlmonthlyfeepaidstatuslist = XmlConvertor.MonthFeePaidStatuslistToXML(lstfeestatus).ToString();
            }
           // Remark for discount //
            Disc = Convert.ToDecimal(txttotaldiscount.Text == "" ? "0" : txttotaldiscount.Text);
            if (Disc > 0)
            {
                if (txtremarks.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter the reason for discount.") + "')", true);
                    //Messagealert_.ShowMessage(lblmessage, "Please enter the reason for discount.", 0);
                    return;
                }
            }

            objfee.StudentID = Convert.ToInt64(hdstudentid.Value == "" ? "0" : hdstudentid.Value);
            objfee.AdmissionID = Convert.ToInt64(hdstudentid.Value == "" ? "0" : hdstudentid.Value);
            objfee.ClassID = Convert.ToInt32(hdclassid.Value == "" ? "0" : hdclassid.Value);
            //objfee.AdmissioNo = hdnAdmissionNo.Value;
            //objfee.StudentCategoryID = Convert.ToInt32(hdnStudentcategoryID.Value == "" ? "0" : hdnStudentcategoryID.Value);
            objfee.StudentTypeID = Convert.ToInt32(hdstutypid.Value == "" ? "0" : hdstutypid.Value);
            objfee.FeeTypeID = Convert.ToInt32(ddlfeetype.SelectedValue == "" ? "0" : ddlfeetype.SelectedValue);
            // NET TOTAL AMOUNT  
            objfee.FeeAmount = Convert.ToDecimal(hdnfeeamount.Text == "" ? "0" : hdnfeeamount.Text);
            objfee.TotalSumFeeAmount = Convert.ToDecimal(hdntotalsumfeeamount.Text == "" ? "0" : hdntotalsumfeeamount.Text);
            objfee.GrandTotalFeeAmount = Convert.ToDecimal(lblgrandtotalfeeamount.Text == "" ? "0" : lblgrandtotalfeeamount.Text);
            objfee.TotalexemptAmount = Convert.ToDecimal(lbltotalexemptamount.Text == "" ? "0" : lbltotalexemptamount.Text);
            objfee.TotalFineAmount = Convert.ToDecimal(lbltotalfineamount.Text == "" ? "0" : lbltotalfineamount.Text);
            objfee.TotalNetAmount = Convert.ToDecimal(lbltotalnetamount.Text == "" ? "0" : lbltotalnetamount.Text);
            objfee.TotalDiscountAmount = Convert.ToDecimal(txttotaldiscount.Text == "" ? "0" : txttotaldiscount.Text);
            objfee.TotalPayableAmount = Convert.ToDecimal(lbltotalpayableamt.Text == "" ? "0" : lbltotalpayableamt.Text);
            objfee.PaidAmount = Convert.ToDecimal(txttotalpaidamt.Text == "" ? "0" : txttotalpaidamt.Text);
            objfee.TotalDueAmount = Convert.ToDecimal(lbltotaldueamt.Text == "" ? "0" : lbltotaldueamt.Text);
            objfee.Remarks = txtremarks.Text == "" ? null : txtremarks.Text;

            // CHECKING 
            if (objfee.TotalDiscountAmount > objfee.GrandTotalFeeAmount)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Discount amount cannot be greater than total amount") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "Discount amount cannot be greater than total amount", 0);
                return;
            }
            if (objfee.PaidAmount > objfee.TotalPayableAmount)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Paid amount cannot be greater than payable amount") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "Paid amount cannot be greater than payable amount", 0);
                return;
            }
            //objfee.PaymentType = Convert.ToInt32(ddlpaymentype.SelectedValue == "" ? "0" : ddlpaymentype.SelectedValue);
            //objfee.FineAmount = Convert.ToDecimal(txtFineAmount.Text == "" ? null : txtFineAmount.Text);
            //objfee.PayModeID = Convert.ToInt32(ddlpaymentmode.SelectedValue == "" ? "0" : ddlpaymentmode.SelectedValue);
            //objfee.BankName = txtbankName.Text == "" ? null : txtbankName.Text;
            //objfee.ChalanNo = txtchalan.Text == "" ? null : txtchalan.Text;
            //objfee.PaymentType = Convert.ToInt32(ddlpaymentmode.SelectedValue == "" ? "0" : ddlpaymentmode.SelectedValue);
            //objfee.Remarks = "Late Fine.";

            objfee.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objfee.AddedBy = LoginToken.LoginId;
            objfee.UserId = LoginToken.UserLoginId;
            objfee.CompanyID = LoginToken.CompanyID;
            int result = objfeedBO.UpdateStudentFeeDetails(objfee);
            if (result > 0)
            {
                gridchange();
                txtbillno.Text = result.ToString();
                hdnbillno.Value = result.ToString();
                hdnfeetypeID.Value = ddlfeetype.SelectedValue;
                //btnsave.Enabled = false;
                btnsave.Attributes["disabled"] = "disabled";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "save", 1);
                ViewState["Count"] = null;
                //btnprint.Enabled = true;
                btnprint.Attributes.Remove("disabled");
            }
            if (result == 5)
            {
                //btnsave.Enabled = false;
                btnsave.Attributes["disabled"] = "disabled";
                ViewState["Count"] = null;
                //btnprint.Enabled = false;
                btnprint.Attributes["disabled"] = "disabled";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Admission already done!") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "Admission already done!", 0);
            }

        }

        protected void btnclearall_Click(object sender, EventArgs e)
        {
            Clearall();
        }
        protected void Clearall()
        {
            
            txtbillno.Text = "";
            Session.Remove("Itemlist");
            txtstddetail.Text = "";
            txtstudenttype.Text = "";
            txtcareof.Text = "";
            txtadmissiontype.Text = "";
            txtbillno.Text = "";
            hdstudentid.Value = "";
            hdadmissiontypeID.Value = "";
            hdstutypid.Value = "";
            hdclassid.Value = "";
            hdrollno.Value = "";
            hdnBoardingStudentTypeName.Value = "";
            hdnTransportStudentTypeName.Value = "";
            hdnIsBoardingAdmissionDone.Value = "";
            txttransportstdtype.Text = "";
            txtbordingstdtype.Text = "";
            txtparticular.Text = "";
            txtparticularamt.Text = "";
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            GvFeedetails.Visible = false;
            txtbillno.Text = "";
            //btnsave.Enabled = false;
            btnsave.Attributes["disabled"] = "disabled";
            ddlfeetype.SelectedIndex = 0;
            lblgrandtotalfeeamount.Text = "";
            lbltotalnetamount.Text = "";
            lbltotalexemptamount.Text = "";
            txttotaldiscount.Text = "";
            lbltotalpayableamt.Text = "";
            txttotalpaidamt.Text = "";
            lbltotaldueamt.Text = "";
            //txttotaldiscount.Enabled = false;
            //txttotalpaidamt.Enabled = false;
            txttotaldiscount.Attributes["disabled"] = "disabled";
            txttotalpaidamt.Attributes["disabled"] = "disabled";
            txtremarks.Text = "";
            //lblmessage.Text = "";
            txtstudenttype.Attributes["disabled"] = "disabled";
            txtadmissiontype.Attributes["disabled"] = "disabled";
            txtcareof.Attributes["disabled"] = "disabled";
            txtbillno.Attributes["disabled"] = "disabled";
            txttransportstdtype.Attributes["disabled"] = "disabled";
            txtbordingstdtype.Attributes["disabled"] = "disabled";
            txtparticular.Attributes["disabled"] = "disabled";
            txtparticularamt.Attributes["disabled"] = "disabled";
        }

        //////////////// TAB 2 ///////////////////////////
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            FeeData objSTD = new FeeData();
            FeeBO objempBO = new FeeBO();
            List<FeeData> getResult = new List<FeeData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //Getfedetailist(1);
            Tap2Bindgrid(1);
        }
        private void Tap2Bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<FeeCollectionData> result = Getfedetailist(index, pagesize);
            if (result.Count > 0)
                {
                    Gvfeedetailslist.Visible = true;
                    Gvfeedetailslist.PageSize = pagesize;
                    lblSumtotalsumfeeamount.Text = Commonfunction.Getrounding(result[0].SumTotalSumFeeAmount.ToString());
                    lbltotalbillamount.Text = Commonfunction.Getrounding(result[0].SUMGrandTotalFeeAmount.ToString());
                    lblexemptedamount.Text = Commonfunction.Getrounding(result[0].SUMTotalexemptAmount.ToString());
                    lbltotfine.Text = Commonfunction.Getrounding(result[0].SUMTotalFineAmount.ToString());
                    lbltotaldiscount.Text = Commonfunction.Getrounding(result[0].SUMTotalDiscountAmount.ToString());
                    lbltotalpayable.Text = Commonfunction.Getrounding(result[0].SUMTotalPayableAmount.ToString());
                    lbltotalpaidamount.Text = Commonfunction.Getrounding(result[0].SUMPaidAmount.ToString());
                    lblTotalDueamount.Text = Commonfunction.Getrounding(result[0].SUMTotalDueAmount.ToString());
                    Gvfeedetailslist.Visible = true;
                    Gvfeedetailslist.VirtualItemCount = result[0].MaximumRows;
                    Gvfeedetailslist.PageIndex = index - 1;
                    Gvfeedetailslist.DataSource = result;
                    Gvfeedetailslist.DataBind();
                    lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                    lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                    lblresult.Visible = true;
                    //Gvfeedetailslist.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                    //Gvfeedetailslist.PageIndex = index - 1;
                    bindresponsive();
                    ds = ConvertToDataSet(result);
                    divsearch.Visible = true;
                    FeeCollectionDetailsListButtom.Visible = true;
                    //lblresult.CssClass = "MsgSuccess";
                    lblresult.Visible = true;
                    if (ddlstatus.SelectedValue == "1")
                    {
                        //btnsend.Enabled = true;
                        btnsend.Attributes.Remove("disabled");
                    }
                    else
                    {
                        //btnsend.Enabled = false;
                        btnsend.Attributes["disabled"] = "disabled";
                    }
                }
                else
                {
                    divsearch.Visible = true;
                    FeeCollectionDetailsListButtom.Visible = true;
                    Gvfeedetailslist.DataSource = null;
                    Gvfeedetailslist.DataBind();
                    lblresult.CssClass = "Message";
                    lblresult.Visible = true;
                    lblresult.Text = "0";
                    lblSumtotalsumfeeamount.Text = "0.00";
                    lblexemptedamount.Text = "0.00";
                    lbltotfine.Text = "0.00";
                    lbltotalbillamount.Text = "0.00";
                    lbltotaldiscount.Text = "0.00";
                    lbltotalpayable.Text = "0.00";
                    lbltotalpaidamount.Text = "0.00";
                    lblTotalDueamount.Text = "0.00";
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
        public List<FeeCollectionData> Getfedetailist(int curIndex, int pagesize)
        {  
            FeeCollectionData objfee = new FeeCollectionData();
            FeeCollectionBO objfeedBO = new FeeCollectionBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objfee.StudentID = Convert.ToInt64(txtstudentIDs.Text == "" ? "0" : txtstudentIDs.Text);
            if (ddlsearch.SelectedIndex == 1)
            {
                objfee.Sfirstname = txtstudentanme.Text.Trim();
            }
            objfee.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objfee.PayModeID = Convert.ToInt32(ddlpaymentmodes.SelectedValue == "" ? "0" : ddlpaymentmodes.SelectedValue);
            //objfee.PaymentType = Convert.ToInt32(ddlpaymentypes.SelectedValue == "" ? "0" : ddlpaymentypes.SelectedValue);
            objfee.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objfee.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objfee.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objfee.FeeTypeID = Convert.ToInt32(ddlfeetypess.SelectedValue == "" ? "0" : ddlfeetypess.SelectedValue);
            objfee.StudentID = Convert.ToInt32(txtstudentIDs.Text == "" ? "0" : txtstudentIDs.Text);
            objfee.StudentCategoryID = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
            objfee.RouteID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
            objfee.VihicleID = Convert.ToInt32(ddlvihicle.SelectedValue == "" ? "0" : ddlvihicle.SelectedValue);
            objfee.UserId = Convert.ToInt32(ddluser.SelectedValue == "" ? "0" : ddluser.SelectedValue);
            objfee.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objfee.PageSize = pagesize;
            objfee.CurrentIndex = curIndex;

            objfee.Datefrom = from;
            objfee.Dateto = To;
            return objfeedBO.SearchSchoolFeeDetailsList(objfee);
            //List<FeeCollectionData> result = objfeedBO.SearchSchoolFeeDetailsList(objfee);
        }
        //TAP 2 CHILD GRIDVIEW
        protected void gv_Child_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    FeeCollectionData objitemData = new FeeCollectionData();
                    FeeCollectionBO objitemBO = new FeeCollectionBO();
                    Label BillNo = (Label)e.Row.FindControl("lblbillno");
                    Label FeeTypeID = (Label)e.Row.FindControl("lblfeeTypeID");
                    Label StudentID = (Label)e.Row.FindControl("lblStudentID");
                    Label Academic = (Label)e.Row.FindControl("lblacademic");
                    objitemData.BillNo = Convert.ToInt32(BillNo.Text.Trim() == "" ? "0" : BillNo.Text.Trim());
                    objitemData.FeeTypeID = Convert.ToInt32(FeeTypeID.Text.Trim() == "" ? "0" : FeeTypeID.Text.Trim());
                    objitemData.StudentID = Convert.ToInt64(StudentID.Text.Trim() == "" ? "0" : StudentID.Text.Trim());
                    objitemData.AcademicSessionID = Convert.ToInt32(Academic.Text.Trim() == "" ? "0" : Academic.Text.Trim());
                    List<FeeCollectionData> GetResult = objitemBO.SearchChildDetailByNo(objitemData);
                    if (GetResult.Count > 0)
                    {
                        GridView SC = (GridView)e.Row.FindControl("GridChild");
                        SC.DataSource = GetResult;
                        SC.DataBind();
                    }
                }

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
                //lblmessage.Visible = true;
                //lblmessage.CssClass = "Message";
            }
        }
        protected void Gvfeedetailslist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletes")
                {

                    FeeCollectionData objfee = new FeeCollectionData();
                    FeeCollectionBO objfeedBO = new FeeCollectionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvfeedetailslist.Rows[i];
                    Label billno = (Label)gr.Cells[0].FindControl("lblbillno");
                    Label feeTypeID = (Label)gr.Cells[7].FindControl("lblfeeTypeID");
                    Label StudentID = (Label)gr.Cells[0].FindControl("lblStudentID");
                    Label Academic = (Label)gr.Cells[0].FindControl("lblacademic");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    //txtremarks.Enabled = true;
                    txtremarks.Attributes.Remove("disabled");
                    if (txtremarks.Text == "")
                    {
                        //Messagealert_.ShowMessage(lblresult, "Please enter remarks", 0);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter remarks") + "')", true);
                        return;
                    }
                    else
                    {
                        objfee.Remarks = txtremarks.Text;
                    }
                    objfee.BillNo = Convert.ToInt32(billno.Text == "" ? "0" : billno.Text);
                    objfee.FeeTypeID = Convert.ToInt32(feeTypeID.Text == "" ? "0" : feeTypeID.Text);
                    objfee.StudentID = Convert.ToInt32(StudentID.Text == "" ? "0" : StudentID.Text);
                    objfee.AcademicSessionID = Convert.ToInt32(Academic.Text == "" ? "0" : Academic.Text);
                    objfee.UserId = LoginToken.UserLoginId;
                    int Result = objfeedBO.DeleteSchoolFeesByID(objfee);
                    if (Result == 1)
                    {
                        //Messagealert_.ShowMessage(lblresult, "delete", 1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        Tap2Bindgrid(1);


                    }
                    else if (Result == 4)
                    {
                        //Messagealert_.ShowMessage(lblresult, " This Bill No. cannot be delete because due amount has been collected! ", 0);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Bill No. cannot be delete because due amount has been collected!") + "')", true);
                    }
                    else
                    {
                        //Messagealert_.ShowMessage(lblresult, "system", 0);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
                //lblmessage.Visible = true;
                //lblmessage.CssClass = "Message";
            }
        }
        protected void Gvfeedetailslist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvfeedetailslist.PageIndex = e.NewPageIndex;
            Tap2Bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        protected void resetall()
        {
            divsearch.Visible = false;
            FeeCollectionDetailsListButtom.Visible = false;
            ddlsearch.SelectedIndex = 1;
            txtstudentanme.Text = "";
            txtstudentIDs.Text = "";
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Section));
            Commonfunction.PopulateDdl(ddlfeetypess, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Gvfeedetailslist.DataSource = null;
            Gvfeedetailslist.DataBind();
            Gvfeedetailslist.Visible = false;
            txtfrom.Text = "";
            txtto.Text = "";
            lblresult.Visible = false;
            //btnsend.Enabled = false;
            btnsend.Attributes["disabled"] = "disabled";
            lblmesagestudentlist.Visible = false;
            lbltotalpayable.Text = "0.00";
            lbltotfine.Text = "0.00";
            ddluser.SelectedIndex = 0;
            
            ddlrouteno.SelectedIndex = 0;
            //ddlvihicle.SelectedIndex = 0;
            lblrouteno.Visible = false;
            ddlrouteno.Visible = false;
            lblvihicle.Visible = false;
            ddlvihicle.Visible = false;
            lblSumtotalsumfeeamount.Text = "0.00";
            lblexemptedamount.Text = "0.00";
            lbltotalbillamount.Text = "0.00";
            lbltotaldiscount.Text = "0.00";
            lbltotalpayable.Text = "0.00";
            lbltotalpaidamount.Text = "0.00";
            lblTotalDueamount.Text = "0.00";
          
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
                wb.Worksheets.Add(dt, "Fee Collection");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Class :" + (ddlclasses.SelectedIndex == 0 ? "All" : ddlclasses.SelectedItem.Text) + " Section : " + (ddlsections.SelectedIndex == 0 ? "" : ddlsections.SelectedItem.Text) + ".xlsx");
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
            List<FeeCollectionData> studentdetails = Getstudentfeedetailstoexcel(0);
            List<ExcelFeeStudentList> listecelstd = new List<ExcelFeeStudentList>();
            int i = 0;
            foreach (FeeCollectionData row in studentdetails)
            {
                ExcelFeeStudentList EcxeclStd = new ExcelFeeStudentList();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.ClassName = studentdetails[i].ClassName;
                EcxeclStd.SectionName = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.ReceiptNo = studentdetails[i].ReceiptNo;
                EcxeclStd.FeeType = studentdetails[i].FeeType;
                EcxeclStd.TotalFeeAmount = studentdetails[i].TotalFeeAmount;
                EcxeclStd.TotalexemptAmount = studentdetails[i].TotalexemptAmount;
                EcxeclStd.TotalFineAmount = studentdetails[i].TotalFineAmount;
                EcxeclStd.TotalNetAmount = studentdetails[i].TotalNetAmount;
                EcxeclStd.TotalDiscountAmount = studentdetails[i].TotalDiscountAmount;
                EcxeclStd.TotalPayableAmount = studentdetails[i].TotalPayableAmount;
                EcxeclStd.PaidAmount = studentdetails[i].PaidAmount;
                EcxeclStd.TotalDueAmount = studentdetails[i].TotalDueAmount;
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
        public List<FeeCollectionData> Getstudentfeedetailstoexcel(int curIndex)
        {
            FeeCollectionData objstd = new FeeCollectionData();
            FeeCollectionBO objstdBO = new FeeCollectionBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objstd.StudentID = Commonfunction.SemicolonSeparation_String_64(txtstudentanme.Text);
            objstd.Datefrom = from;
            objstd.Dateto = To;
            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objstd.FeeTypeID = Convert.ToInt32(ddlfeetypess.SelectedValue == "" ? "0" : ddlfeetypess.SelectedValue);
            objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objstd.StudentCategoryID = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
            objstd.UserId = Convert.ToInt32(ddluser.SelectedValue == "" ? "0" : ddluser.SelectedValue);
            if (ddlsearch.SelectedItem.Value == "0")
            {
                objstd.StudentName ="";
            }
            if (ddlsearch.SelectedItem.Value == "1")
            {
                objstd.StudentName = txtstudentanme.Text;
            }
            objstd.IsActiveALL = ddlstatus.SelectedValue;
            objstd.ActionType = EnumActionType.Select;
            objstd.PageSize = Gvfeedetailslist.PageSize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.GetStudentFeeListoexcel(objstd);
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GettapStudentIDs(string prefixText, int count, string contextKey)
        {
            FeeData objSTD = new FeeData();
            FeeBO objempBO = new FeeBO();
            List<FeeData> getResult = new List<FeeData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
        }
        
       
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentDetail(string prefixText, int count, string contextKey)
        {
            FeeData objitemName = new FeeData();
            FeeBO objitemBO = new FeeBO();
            List<FeeData> getResult = new List<FeeData>();
            objitemName.StudentDetail = prefixText;
            objitemName.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = objitemBO.GetAutoStudentDetails(objitemName);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentDetail.ToString());
            }

            return list;
        }

        //-----------------New-----------------//

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentName(string prefixText, int count, string contextKey)
        {
            FeeData objitemName = new FeeData();
            FeeBO objitemBO = new FeeBO();
            List<FeeData> getResult = new List<FeeData>();
            objitemName.StudentDetail = prefixText;
            objitemName.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = objitemBO.GetAutoStudentName(objitemName);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentDetail.ToString());
            }

            return list;
        }
        //protected void txtstudentanme_OnTextChanged(object sender, EventArgs e)
        //{
        //    if (txtstudentanme.Text != "")
        //    {
        //        FeeData objFeeData = new FeeData();
        //        FeeBO objitemBO = new FeeBO();
        //        var source = txtstudentanme.Text.ToString();
        //        if (source.Contains(":"))
        //        {
        //            string ID = source.Substring(source.LastIndexOf(':') + 1);
        //            objFeeData.StudentID = Convert.ToInt32(ID == "" ? "0" : ID);
        //            objFeeData.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue);
        //        }
        //        else
        //        {
        //            txtstddetail.Text = "";
        //            txtstddetail.Text = "";
        //            return;
        //        }
        //        List<FeeData> result = objitemBO.GetStudentDetailByID(objFeeData);
        //        if (result.Count > 0)
        //        {
        //            hdstutypid.Value = result[0].StudentTypeID.ToString();
        //            txtstudenttype.Text = result[0].StudentType.ToString();
        //            txtadmissiontype.Text = result[0].AdmissionType.ToString();
        //            txtcareof.Text = result[0].Gfirstname.ToString();
        //            //hidden part
        //            hdnTransportStudentTypeID.Value = result[0].TransportStudentTypeID.ToString();
        //            txttransportstdtype.Text = result[0].TransportStudentTypeName.ToString();
        //            hdnBoardingStudentTypeID.Value = result[0].BoardingStudentTypeID.ToString();
        //            txtbordingstdtype.Text = result[0].BoardingStudentTypeName.ToString();
        //            txtisadmissiondone.Value = result[0].IsAdmissionDone.ToString();
        //            hdnistakingtransport.Value = result[0].Istakingtransports.ToString();
        //            hdnisboardingstudent.Value = result[0].IsBoardingStudent.ToString();
        //            hdnIsBoardingAdmissionDone.Value = result[0].IsBoardingAdmissionDone.ToString();
        //            hdstudentid.Value = result[0].StudentID.ToString();
        //            hdadmissiontypeID.Value = result[0].IsNew.ToString();
        //            hdclassid.Value = result[0].ClassID.ToString();
        //            hdrollno.Value = result[0].RollNo.ToString();
        //            GvFeedetails.DataSource = null;
        //            GvFeedetails.DataBind();
        //            ddlfeetype.Focus();

        //        }
        //    }
        //}


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
        protected void Gvfeedetailslist_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                Tap2Bindgrid(1); 
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
                    Gvfeedetailslist.DataSource = sortedView;
                    Gvfeedetailslist.DataBind();

                    TableCell tableCell = Gvfeedetailslist.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    Gvfeedetailslist.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    Gvfeedetailslist.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    Gvfeedetailslist.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    Gvfeedetailslist.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    Gvfeedetailslist.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    Gvfeedetailslist.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    Gvfeedetailslist.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    Gvfeedetailslist.UseAccessibleHeader = true;
                    Gvfeedetailslist.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
                //lblmessage.Visible = true;
                //lblmessage.CssClass = "Message";

            }
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            Tap2Bindgrid(1);
        }

        protected void bindresponsive()
        {
            //Responsive 
            Gvfeedetailslist.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Gvfeedetailslist.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[13].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[14].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[15].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[16].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[17].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[18].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[19].Attributes["data-hide"] = "phone,tablet";
            Gvfeedetailslist.HeaderRow.Cells[20].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gvfeedetailslist.UseAccessibleHeader = true;
            Gvfeedetailslist.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = Gvfeedetailslist.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }

        public void ddlsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsearch.SelectedItem.Value == "0")
            {
                txtstudentanme.Attributes["disabled"] = "disabled";
                txtstudentanme.Text = "";
            }
            else
            {
                txtstudentanme.Attributes.Remove("disabled");
                
            }
        }
    }
}
