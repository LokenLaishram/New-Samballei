using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduFees
{
    public partial class AdmissionFee : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                //bindgrid(1);
            }
        }
        protected void BindDlls()
        {

            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_previuosyear, mstlookup.GetLookupsList(LookupNames.PreviuosYear));
            ddl_previuosyear.SelectedIndex = 1;
            ddl_previuosyear.Attributes["disabled"] = "disabled";
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            ddlacademicsession.Attributes["disabled"] = "disabled";
            Commonfunction.PopulateDdl(ddl_class, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddl_feetype, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            ddl_feetype.SelectedIndex = 1;
            ddl_feetype.Attributes["disabled"] = "disabled";
            Commonfunction.Insertzeroitemindex(ddl_section);
            txtstddetail.Attributes["disabled"] = "disabled";
            //txt_paymentstatus.Attributes["disabled"] = "disabled";
            txt_totalamount.Attributes["disabled"] = "disabled";
            txt_totalfineamount.Attributes["disabled"] = "disabled";
            // txt_discountamount.Attributes["disabled"] = "disabled";
            txt_payableamount.Attributes["disabled"] = "disabled";
            btnpay.Attributes["disabled"] = "disabled";
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvFeedetails.HeaderRow.Cells[0].Attributes["data-hide"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvFeedetails.UseAccessibleHeader = true;
            GvFeedetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvFeedetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            List<FeepaymentData> listdetails = Getstudentpaymentdetails();
            if (listdetails.Count > 0)
            {
                btnpay.Visible = true;
                btnprint.Visible = false;
                GvFeedetails.Visible = true;
                GvFeedetails.DataSource = listdetails;
                GvFeedetails.DataBind();
                //txt_paymentstatus.ForeColor = System.Drawing.Color.White;
                txt_totalamount.Text = "";
                txt_totalfineamount.Text = "";
                txt_discountamount.Text = "";
                txt_payableamount.Text = "";
                lbl_payableamount.Text = "";
                lbl_payableamount.BackColor = System.Drawing.Color.White;
                lbl_payableamount.ForeColor = System.Drawing.Color.Black;
                //txtstddetail.Text = listdetails[0].StudentName.ToString();
                //txt_paymentstatus.Text = listdetails[0].PaymentStatus.ToString();
                //lbl_lastdateID.Text = listdetails[0].FineDate.ToString("dd/MM/yyyy");
                txt_newclass.Text = "";
                txt_newsection.Text = "";
                txt_newroll.Text = "";
                if (listdetails[0].PaymentStatus.ToString() == "Not Paid" && listdetails[0].PaymentType.ToString() == "1")
                {
                    //lbllastdate.Text = "Last Date";
                    //lblpayableamount.Text = "Total Payable Amount (INR)";
                    txt_totalamount.Text = Commonfunction.Getrounding(listdetails[0].TotalAmount.ToString());
                    //txt_paymentstatus.BackColor = System.Drawing.Color.Yellow;
                    btnpay.Attributes.Remove("disabled");
                    if ((DateTime.Now - listdetails[0].FineDate).TotalDays > 0)
                    {
                        txt_totalfineamount.Text = Commonfunction.Getrounding(listdetails[0].FineAmount.ToString());
                    }
                    else
                    {
                        txt_totalfineamount.Text = "";
                    }
                    txt_discountamount.Text = Commonfunction.Getrounding(listdetails[0].ExemptionAmount.ToString());
                    txt_payableamount.Text = Commonfunction.Getrounding(((Convert.ToDecimal(txt_totalamount.Text == "" ? "0" : txt_totalamount.Text)
                                             + Convert.ToDecimal(txt_totalfineamount.Text == "" ? "0" : txt_totalfineamount.Text))
                                             - Convert.ToDecimal(txt_discountamount.Text == "" ? "0" : txt_discountamount.Text)).ToString());

                    lbl_payableamount.Text = txt_payableamount.Text;
                }
                if (listdetails[0].PaymentStatus.ToString() == "Paid" && listdetails[0].PaymentType.ToString() == "1")
                {
                    //txt_paymentstatus.BackColor = System.Drawing.Color.Green;
                    //txt_paymentstatus.ForeColor = System.Drawing.Color.White;
                    txt_totalamount.Text = Commonfunction.Getrounding(listdetails[0].TotalAmount.ToString());
                    txt_totalfineamount.Text = Commonfunction.Getrounding(listdetails[0].FineAmount.ToString());
                    txt_discountamount.Text = Commonfunction.Getrounding(listdetails[0].ExemptionAmount.ToString());
                    txt_payableamount.Text = "0.0";
                    btnpay.Attributes["disabled"] = "disabled";
                    // lbllastdate.Text = "Payment Date";
                    //lbl_lastdateID.Text = listdetails[0].PaymentDate.ToString("dd/MM/yyyy");
                    //lbl_lastdateID.BackColor = System.Drawing.Color.Green;
                    //lbl_lastdateID.ForeColor = System.Drawing.Color.White;
                    //lblpayableamount.Text = "Total Paid Amount (INR)";
                    lbl_payableamount.Text = Commonfunction.Getrounding(listdetails[0].TotalPaidAmount.ToString());
                    lbl_payableamount.BackColor = System.Drawing.Color.Green;
                    lbl_payableamount.ForeColor = System.Drawing.Color.White;
                    lbl_payableamount.Text = txt_payableamount.Text;
                    txt_newclass.Text = listdetails[0].NewClass.ToString();
                    txt_newsection.Text = listdetails[0].NewSectionName.ToString();
                    txt_newroll.Text = listdetails[0].NewRoll.ToString();
                }
                // bindresponsive();
                //ds = ConvertToDataSet(listdetails);
            }
            else
            {
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                GvFeedetails.Visible = true;
                txtstddetail.Text = "";
                //txt_paymentstatus.Text = "";
                //lbl_lastdateID.Text = "";
                txt_totalamount.Text = "";
                txt_totalfineamount.Text = "";
                txt_discountamount.Text = "";
                txt_payableamount.Text = "";
            }
        }
        public List<FeepaymentData> Getstudentpaymentdetails()
        {
            FeepaymentData objpayment = new FeepaymentData();
            FeeCollectionBO objpaymentBO = new FeeCollectionBO();
            objpayment.StudentID = Convert.ToInt64(lbl_studentID.Text == "" ? "0" : lbl_studentID.Text);
            objpayment.FeeTypeID = 1;// Convert.ToInt32(ddl_feetype.SelectedValue == "" ? "0" : ddl_feetype.SelectedValue); 
            objpayment.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            return objpaymentBO.Getfeepaymentdetails(objpayment);
        }
        protected void ddlacademicsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlacademicsession.SelectedIndex > 0)
            {
                bindgrid(1);
            }
            else
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
                ddlacademicsession.SelectedIndex = 1;
                bindgrid(1);
            }
        }
        protected void btnpay_Click(object sender, EventArgs e)
        {
            try
            {
                List<FeepaymentData> paymentlist = new List<FeepaymentData>();
                FeeCollectionBO objpaymentBO = new FeeCollectionBO();
                FeepaymentData Objpaydata = new FeepaymentData();

                int check = 0;
                foreach (GridViewRow row in GvFeedetails.Rows)
                {
                    Label IDS = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    Label monthID = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblmonthID");
                    Label feetype = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblfeetypeID");
                    Label Particular = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblparticulars");
                    Label Feeamount = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblfeeamount");
                    Label Class = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblclassID");
                    Label Session = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("sessionID");
                    Label paymenttype = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lbl_paymenttype");
                    FeepaymentData objdata = new FeepaymentData();
                    if (paymenttype.Text == "1")
                    {
                        objdata.ID = Convert.ToInt32(IDS.Text == "" ? "0" : IDS.Text);
                        objdata.ClassID = Convert.ToInt32(Class.Text == "" ? "0" : Class.Text);
                        objdata.MonthID = Convert.ToInt32(monthID.Text == "" ? "0" : monthID.Text);
                        objdata.FeeTypeID = Convert.ToInt32(feetype.Text == "" ? "0" : feetype.Text);
                        objdata.FeeAmount = Convert.ToDecimal(Feeamount.Text == "" ? "0" : Feeamount.Text);
                        objdata.Particulars = Convert.ToString(Particular.Text);
                        objdata.AcademicSessionID = Convert.ToInt32(Session.Text == "" ? "0" : Session.Text);
                        paymentlist.Add(objdata);
                    }
                    if (paymenttype.Text == "2")
                    {
                        CheckBox ChkFeeStatus = (CheckBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("chkfeestatus");
                        if (ChkFeeStatus.Checked)
                        {
                            objdata.ID = Convert.ToInt32(IDS.Text == "" ? "0" : IDS.Text);
                            objdata.ClassID = Convert.ToInt32(Class.Text == "" ? "0" : Class.Text);
                            objdata.MonthID = Convert.ToInt32(monthID.Text == "" ? "0" : monthID.Text);
                            objdata.FeeTypeID = Convert.ToInt32(feetype.Text == "" ? "0" : feetype.Text);
                            objdata.FeeAmount = Convert.ToDecimal(Feeamount.Text == "" ? "0" : Feeamount.Text);
                            objdata.Particulars = Convert.ToString(Particular.Text);
                            objdata.AcademicSessionID = Convert.ToInt32(Session.Text == "" ? "0" : Session.Text);
                            paymentlist.Add(objdata);
                        }
                    }
                    check++;
                }
                Objpaydata.XMLData = XmlConvertor.OnlinepaymenttoXML(paymentlist).ToString();
                Objpaydata.StudentID = Convert.ToInt64(lbl_studentID.Text == "" ? "0" : lbl_studentID.Text); // here employeeID is Student ID
                Objpaydata.FeeTypeID = Convert.ToInt32(ddl_feetype.SelectedValue == "" ? "0" : ddl_feetype.SelectedValue);
                Objpaydata.TotalAmount = Convert.ToDecimal(txt_totalamount.Text == "" ? "0" : txt_totalamount.Text);
                Objpaydata.FineAmount = Convert.ToDecimal(txt_totalfineamount.Text == "" ? "0" : txt_totalfineamount.Text);
                Objpaydata.ExemptionAmount = Convert.ToDecimal(txt_discountamount.Text == "" ? "0" : txt_discountamount.Text);
                Objpaydata.TotalPaidAmount = Convert.ToDecimal(lbl_payableamount.Text == "" ? "0" : lbl_payableamount.Text);
                Objpaydata.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                Objpaydata.CompanyID = LoginToken.CompanyID;
                int result = objpaymentBO.Payfee(Objpaydata);
                if (result > 0)
                {
                    bindgrid(1);
                    btnpay.Attributes["disabled"] = "disabled";
                    btnpay.Visible = false;
                    btnprint.Visible = true;
                    btnprint.BackColor = System.Drawing.Color.Yellow;
                    btnprint.ForeColor = System.Drawing.Color.Black;
                    lblBillID.Text = result.ToString();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Paid") + "')", true);
                }
                //if (result == 2)
                //{
                //    btnpay.Attributes.Remove("disabled");
                //    //txt_paymentstatus.BackColor = System.Drawing.Color.Green;
                //    //txt_paymentstatus.ForeColor = System.Drawing.Color.White;
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Duplicatepay") + "')", true);
                //}
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                return;
            }
        }
        protected void txt_roll_TextChanged(object sender, EventArgs e)
        {
            // ddl_feetype.SelectedIndex = 0;
            StudentDetailData objstd = new StudentDetailData();
            AddstudentBO objstdBO = new AddstudentBO();

            objstd.AcademicSessionID = Convert.ToInt32(ddl_previuosyear.SelectedValue == "" ? "0" : ddl_previuosyear.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddl_section.SelectedValue == "" ? "0" : ddl_section.SelectedValue);
            objstd.Roll = Convert.ToInt32(txt_roll.Text == "" ? "0" : txt_roll.Text);
            List<StudentDetailData> list = objstdBO.GetStudentdetailbyRoll(objstd);
            if (list.Count > 0)
            {
                txtstddetail.Text = list[0].StudentName.ToString();
                lbl_studentID.Text = list[0].StudentID.ToString();
                lbl_studentID.Text = list[0].StudentID.ToString();
                if (list[0].Prevfeestatus.ToString() == "1")
                {
                    bindgrid(1);
                    lbl_freeStatus.Text = "Cleared";
                    lbl_freeStatus.BackColor = System.Drawing.Color.Green;
                    lbl_freeStatus.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    lbl_freeStatus.Text = "Due";
                    lbl_freeStatus.BackColor = System.Drawing.Color.Red;
                    lbl_freeStatus.ForeColor = System.Drawing.Color.Black;
                    btnpay.Attributes["disabled"] = "disabled";
                }

            }
            else
            {    //GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                txtstddetail.Text = "";
                txt_roll.Text = "";
                lbl_studentID.Text = "";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("No record found.") + "')", true);
            }
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;


        }
        protected void ddl_feetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlacademicsession.SelectedIndex == 0)
            {
                ddl_feetype.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select year.") + "')", true);
            }
            if (ddl_class.SelectedIndex == 0)
            {
                ddl_feetype.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select class.") + "')", true);
            }
            if (ddl_section.SelectedIndex == 0)
            {
                ddl_feetype.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select section.") + "')", true);
            }
            if (txt_roll.Text.Trim() == "")
            {
                ddl_feetype.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter roll number.") + "')", true);
            }
            bindgrid(1);
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;
        }
        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_section, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue), Convert.ToInt32(ddl_previuosyear.SelectedValue == "" ? "0" : ddl_previuosyear.SelectedValue)));
            // ddl_feetype.SelectedIndex = 0;
            txtstddetail.Text = "";
            txt_roll.Text = "";
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            txt_totalamount.Text = "";
            txt_totalfineamount.Text = "";
            txt_payableamount.Text = "";
            txt_discountamount.Text = "";
            lbl_payableamount.Text = "";
            btnpay.Attributes["disabled"] = "disabled";
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;
        }
        protected void ddl_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddl_feetype.SelectedIndex = 0;
            txtstddetail.Text = "";
            txt_roll.Text = "";
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            txt_totalamount.Text = "";
            txt_totalfineamount.Text = "";
            txt_payableamount.Text = "";
            txt_discountamount.Text = "";
            lbl_payableamount.Text = "";
            btnpay.Attributes["disabled"] = "disabled";
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;
        }
        protected void ddlacademicsession_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ddl_class.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddl_section);
            //ddl_feetype.SelectedIndex = 0;
            txtstddetail.Text = "";
            txt_roll.Text = "";
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            txt_totalamount.Text = "";
            txt_totalfineamount.Text = "";
            txt_payableamount.Text = "";
            txt_discountamount.Text = "";
            lbl_payableamount.Text = "";
            btnpay.Attributes["disabled"] = "disabled";
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;
        }
        protected void GvFeedetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label paymenttype = e.Row.FindControl("lbl_paymenttype") as Label;
                    Label paymentstatus = e.Row.FindControl("lbl_paymentstatus") as Label;
                    CheckBox FeeCheckBox = e.Row.FindControl("chkfeestatus") as CheckBox;
                    if (paymenttype.Text == "1")
                    {
                        GvFeedetails.Columns[5].Visible = false;
                    }
                    if (paymenttype.Text == "2")
                    {
                        GvFeedetails.Columns[5].Visible = true;
                        if (paymentstatus.Text == "Paid")
                        {
                            FeeCheckBox.Visible = false;
                        }
                        else
                        {
                            FeeCheckBox.Visible = true;
                        }
                    }
                    if (paymentstatus.Text == "Paid")
                    {

                        e.Row.Cells[3].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        e.Row.Cells[3].BackColor = System.Drawing.Color.White;
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
            }

        }
        protected void txt_discountamount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txt_payableamount.Text == "" ? "0.0" : txt_payableamount.Text) > Convert.ToDecimal(txt_discountamount.Text == "" ? "0.0" : txt_discountamount.Text))
            {
                lbl_payableamount.Text = Commonfunction.Getrounding((Convert.ToDecimal(txt_payableamount.Text == "" ? "0.0" : txt_payableamount.Text) - Convert.ToDecimal(txt_discountamount.Text == "" ? "0.0" : txt_discountamount.Text)).ToString());
            }
            else
            {
                lbl_payableamount.Text = txt_payableamount.Text;
                txt_discountamount.Text = "";
                txt_discountamount.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Discount exceeds the net amount.") + "')", true);
            }
        }
        protected void chkfeestatus_CheckedChanged(object sender, EventArgs e)
        {
            double SumFeeAmount = 0;
            //double SumExemptAmount = 0;
            //double SumFineAmount = 0;
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
                    double TotalAmt = Convert.ToDouble(FeeAmount.Text);
                    SumTotalAmount += TotalAmt;
                    txt_totalamount.Text = SumTotalAmount.ToString("N2");
                    txt_payableamount.Text = SumTotalAmount.ToString("N2");
                    lbl_payableamount.Text = SumTotalAmount.ToString("N2");
                    btnpay.Attributes.Remove("disabled");
                    FeeAmount.Focus();

                }
            }
            if (SumTotalAmount == 0)
            {
                txt_totalamount.Text = "";
                txt_totalfineamount.Text = "";
                txt_payableamount.Text = "";
                txt_discountamount.Text = "";
                lbl_payableamount.Text = "";
                btnpay.Attributes["disabled"] = "disabled";
            }
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            string sessionid = ddlacademicsession.SelectedValue;
            string studentID = lbl_studentID.Text;
            string billID = lblBillID.Text;
            string feetype = ddl_feetype.SelectedValue;
            string url = "../EduFees/Reports/ReportViewer.aspx?option=FeeReciept&SessionID=" + sessionid + "&StudentID=" + studentID + "&BillID=" + billID + "&FeeTypeID=" + feetype;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }
    }
}