using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common;
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
    public partial class Newstudentadmission : BasePage
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
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddl_class, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddl_feetype, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            ddl_feetype.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddl_studenttype, mstlookup.GetLookupsList(LookupNames.StudentType));
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_optionalsubject, objmstlookupBO.GetOptSubjectByClassID(Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
            // Commonfunction.Insertzeroitemindex(ddl_section);
            txtstddetail.Attributes["disabled"] = "disabled";
            //txt_paymentstatus.Attributes["disabled"] = "disabled";
            txt_totalamount.Attributes["disabled"] = "disabled";
            txt_totalfineamount.Attributes["disabled"] = "disabled";
            // txt_discountamount.Attributes["disabled"] = "disabled";
            txt_payableamount.Attributes["disabled"] = "disabled";
            btnpay.Attributes["disabled"] = "disabled";
            ddl_feetype.Attributes["disabled"] = "disabled";
            ddl_optionalsubject.Attributes["disabled"] = "disabled";
            txt_billdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddl_paymentmode.SelectedIndex = 1;

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
                lbl_payableamount.BackColor = System.Drawing.Color.White;
                lbl_payableamount.ForeColor = System.Drawing.Color.Black;
                if (listdetails[0].PaymentStatus.ToString() == "Not Paid" && listdetails[0].PaymentType.ToString() == "1")
                {
                    txt_totalamount.Text = Commonfunction.Getrounding(listdetails[0].TotalAmount.ToString());

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
                    btnpay.Attributes.Remove("disabled");


                }
                if (listdetails[0].PaymentStatus.ToString() == "Paid" && listdetails[0].PaymentType.ToString() == "1")
                {
                    txt_totalamount.Text = Commonfunction.Getrounding(listdetails[0].TotalAmount.ToString());
                    txt_totalfineamount.Text = Commonfunction.Getrounding(listdetails[0].FineAmount.ToString());
                    txt_discountamount.Text = Commonfunction.Getrounding(listdetails[0].ExemptionAmount.ToString());
                    txt_payableamount.Text = "0.0";
                    btnpay.Attributes["disabled"] = "disabled";

                    lbl_payableamount.Text = Commonfunction.Getrounding(listdetails[0].TotalPaidAmount.ToString());
                    lbl_payableamount.BackColor = System.Drawing.Color.Green;
                    lbl_payableamount.ForeColor = System.Drawing.Color.White;
                    lbl_payableamount.Text = txt_payableamount.Text;
                }

            }
            else
            {
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                GvFeedetails.Visible = true;

            }
        }
        public List<FeepaymentData> Getstudentpaymentdetails()
        {
            FeepaymentData objpayment = new FeepaymentData();
            FeeCollectionBO objpaymentBO = new FeeCollectionBO();
            objpayment.StudentID = Convert.ToInt64(lbl_studentID.Text == "" ? "0" : lbl_studentID.Text);
            objpayment.FeeTypeID = Convert.ToInt32(ddl_feetype.SelectedValue == "" ? "0" : ddl_feetype.SelectedValue);
            objpayment.StudentTypeID = Convert.ToInt32(ddl_studenttype.SelectedValue == "" ? "0" : ddl_studenttype.SelectedValue);
            objpayment.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objpayment.OptionalsubjectID = Convert.ToInt32(ddl_optionalsubject.SelectedValue == "" ? "0" : ddl_optionalsubject.SelectedValue);
            return objpaymentBO.Getfeepaymentdetails_newregister_student(objpayment);
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
                if (ddl_paymentmode.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Paymode") + "')", true);
                    return;
                }
                if (txt_billdate.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Billdate") + "')", true);
                    txt_billdate.Focus();
                    return;
                }
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
                    Label FineAmount = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblcalcfineamount");
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
                            objdata.FineAmount = Convert.ToDecimal(FineAmount.Text == "" ? "0" : FineAmount.Text);
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
                Objpaydata.PaymentType = Convert.ToInt32(ddl_paymentmode.SelectedValue == "" ? "0" : ddl_paymentmode.SelectedValue);
                Objpaydata.CompanyID = LoginToken.CompanyID;
                Objpaydata.EmployeeID = LoginToken.EmployeeID;
                Objpaydata.StudentTypeID = Convert.ToInt32(ddl_studenttype.SelectedValue == "" ? "0" : ddl_studenttype.SelectedValue);
                Objpaydata.OptionalsubjectID = Convert.ToInt32(ddl_optionalsubject.SelectedValue == "" ? "0" : ddl_optionalsubject.SelectedValue);
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime date = txt_billdate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_billdate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                Objpaydata.Billdate = date;

                List<FeepaymentData> result = objpaymentBO.Payfee_newstudents(Objpaydata);
                if (result.Count > 0)
                {
                    lblBillID.Text = result[0].ID.ToString();
                    lbl_studentID.Text = result[0].StudentID.ToString();

                    bindgrid(1);
                    btnpay.Attributes["disabled"] = "disabled";
                    btnpay.Visible = false;
                    btnprint.Visible = true;
                    btnprint.BackColor = System.Drawing.Color.Yellow;
                    btnprint.ForeColor = System.Drawing.Color.Black;

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Paid") + "')", true);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                return;
            }
        }
        protected void txt_ID_TextChanged(object sender, EventArgs e)
        {
            // ddl_feetype.SelectedIndex = 0;
            ddl_studenttype.SelectedIndex = 0;
            StudentDetailData objstd = new StudentDetailData();
            AddstudentBO objstdBO = new AddstudentBO();

            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            objstd.StudentID = Convert.ToInt32(txt_ID.Text == "" ? "0" : txt_ID.Text);
            List<StudentDetailData> list = objstdBO.GetnewregistrationbyID(objstd);
            if (list.Count > 0)
            {
                txtstddetail.Text = list[0].StudentName.ToString();
                lbl_studentID.Text = list[0].StudentID.ToString();
                if (list[0].Prevfeestatus.ToString() == "1")
                {
                    bindgrid(1);
                }
                else
                {
                    btnpay.Attributes["disabled"] = "disabled";
                }
            }
            else
            {
                txtstddetail.Text = "";
                txt_ID.Text = "";
                lbl_studentID.Text = "";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("No record found.") + "')", true);
            }
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;

            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            txt_totalamount.Text = "";
            txt_totalfineamount.Text = "";
            txt_discountamount.Text = "";
            txt_payableamount.Text = "";
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
            if (txt_ID.Text.Trim() == "")
            {
                ddl_feetype.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter ID.") + "')", true);
            }
            if (ddl_studenttype.SelectedIndex == 0)
            {
                ddl_feetype.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select student Type.") + "')", true);
            }
            bindgrid(1);
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;
        }
        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_optionalsubject.SelectedIndex = 0;
            //MasterLookupBO objmstlookupBO = new MasterLookupBO();
            ///Commonfunction.PopulateDdl(ddl_section, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
            //ddl_feetype.SelectedIndex = 0;
            txtstddetail.Text = "";
            txt_ID.Text = "";
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
            //lbl_freeStatus.Text = "";
            //lbl_freeStatus.BackColor = System.Drawing.Color.White;
            if (ddl_class.SelectedValue == "12" || ddl_class.SelectedValue == "13")
            {
                ddl_optionalsubject.Attributes.Remove("disabled");
            }
            else
            {
                ddl_optionalsubject.Attributes["disabled"] = "disabled";
            }
        }
        protected void ddl_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_feetype.SelectedIndex = 0;
            txtstddetail.Text = "";
            txt_ID.Text = "";
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
            //lbl_freeStatus.Text = "";
            //lbl_freeStatus.BackColor = System.Drawing.Color.White;
        }
        protected void ddlacademicsession_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ddl_class.SelectedIndex = 0;
            // Commonfunction.Insertzeroitemindex(ddl_section);
            //ddl_feetype.SelectedIndex = 0;
            txtstddetail.Text = "";
            txt_ID.Text = "";
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
                    Label monthID = e.Row.FindControl("lblmonthID") as Label;
                    CheckBox FeeCheckBox = e.Row.FindControl("chkfeestatus") as CheckBox;
                    Label fineamount = e.Row.FindControl("lblactualfineamount") as Label;
                    string CMonth = DateTime.Now.ToString("MM");
                    if (paymenttype.Text == "1")
                    {
                        GvFeedetails.Columns[5].Visible = false;
                        fineamount.Visible = false;
                        GvFeedetails.Columns[6].Visible = false;
                    }
                    if (paymenttype.Text == "2")
                    {
                        GvFeedetails.Columns[5].Visible = true;
                        GvFeedetails.Columns[6].Visible = true;
                        if (paymentstatus.Text == "Paid")
                        {
                            FeeCheckBox.Visible = false;
                            fineamount.Visible = true;
                        }
                        else
                        {
                            FeeCheckBox.Visible = true;
                            fineamount.Visible = false;
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
            double SumFineAmount = 0;
            double SumTotalAmount = 0;
            double NetAmount = 0;
            int index = 0;

            foreach (GridViewRow gvr in GvFeedetails.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("chkfeestatus");
                Label MonthID = gvr.FindControl("lblmonthID") as Label;
                Label prepaiddueDate = gvr.FindControl("lbl_prepaidDuedate") as Label;
                Label postpaiddueDate = gvr.FindControl("lbl_postpaidDuedate") as Label;
                Label fineamount = gvr.FindControl("lblactualfineamount") as Label;
                Label calfineamount = gvr.FindControl("lblcalcfineamount") as Label;
                string CMonth = DateTime.Now.ToString("MM");
                string CYear = DateTime.Now.ToString("yyyy");
                string CDate = DateTime.Now.ToString("dd");
                int cmonthIDs = Convert.ToInt32(CMonth + CYear);

                if (cb.Checked)
                {
                    gvr.BackColor = System.Drawing.Color.LightBlue;
                    if (Convert.ToInt32(cmonthIDs) > Convert.ToInt32(MonthID.Text))
                    {
                        calfineamount.Text = fineamount.Text;

                    }
                    if (Convert.ToInt32(cmonthIDs) == Convert.ToInt32(MonthID.Text))
                    {
                        if (Convert.ToInt32(CDate) > Convert.ToInt32(prepaiddueDate.Text))
                        { calfineamount.Text = fineamount.Text; }
                        else
                        { calfineamount.Text = ""; }
                    }
                }
                else
                {
                    gvr.BackColor = System.Drawing.Color.Transparent;
                    calfineamount.Text = "";
                }
                if (cb.Checked && cb != null)
                {
                    Label FeeAmount = (Label)(gvr.FindControl("lblfeeamount"));
                    double TotalAmt = Convert.ToDouble(FeeAmount.Text);
                    double cfineamount = Convert.ToDouble(calfineamount.Text == "" ? "0.0" : calfineamount.Text);
                    SumFineAmount += cfineamount;
                    SumTotalAmount += TotalAmt;
                    NetAmount += (TotalAmt + cfineamount);
                    txt_totalamount.Text = SumTotalAmount.ToString("N2");
                    txt_totalfineamount.Text = SumFineAmount.ToString("N2");
                    txt_payableamount.Text = NetAmount.ToString("N2");
                    lbl_payableamount.Text = NetAmount.ToString("N2");
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
                txt_totalfineamount.Text = "";
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
        protected void btn_printhistory_Click(object sender, EventArgs e)
        {
            string sessionid = ddlacademicsession.SelectedValue;
            string studentID = "0";// lbl_studentID.Text;
            string url = "../EduFees/Reports/ReportViewer.aspx?option=Paymenthistory&SessionID=" + sessionid + "&StudentID=" + studentID;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            ddlacademicsession.SelectedIndex = 1;
            txt_ID.Text = "";
            lbl_studentID.Text = "";
            // ddl_feetype.SelectedIndex = 0;
            GvFeedetails.Visible = false;
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            txtstddetail.Text = "";
            txt_totalamount.Text = "";
            txt_totalfineamount.Text = "";
            txt_discountamount.Text = "";
            lbl_payableamount.Text = "";
            txt_totalfineamount.Text = "";
            txt_billdate.Text = "";
            btnpay.Visible = true;
            btnprint.Visible = false;
            ddl_paymentmode.SelectedIndex = 0;
            txt_billdate.Text = "";
            txt_payableamount.Text = "";
            ddl_class.SelectedIndex = 0;
            ddl_optionalsubject.SelectedIndex = 0;
            ddl_studenttype.SelectedIndex = 0;
            btnpay.Attributes["disabled"] = "disabled";
            btnpay.Attributes["disabled"] = "disabled";
            txt_billdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddl_paymentmode.SelectedIndex = 1;
        }

        protected void ddl_studenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlacademicsession.SelectedIndex == 0)
            {
                ddl_feetype.SelectedIndex = 1;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select year.") + "')", true);
                return;
            }
            if (ddl_class.SelectedIndex == 0)
            {
                ddl_feetype.SelectedIndex = 1;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select class.") + "')", true);
                return;
            }
            if (txt_ID.Text.Trim() == "")
            {
                ddl_feetype.SelectedIndex = 1;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter ID.") + "')", true);
                return;
            }
            if (ddl_optionalsubject.SelectedIndex == 0 && (ddl_class.SelectedValue=="12" || ddl_class.SelectedValue == "13"))
            {
                ddl_feetype.SelectedIndex = 1;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select optional subject.") + "')", true);
                return;
            }
            if (ddl_studenttype.SelectedIndex == 0)
            {
                ddl_feetype.SelectedIndex = 1;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select student Type.") + "')", true);
                return;
            }

            bindgrid(1);
            lbl_payableamount.BackColor = System.Drawing.Color.White;
            lbl_payableamount.ForeColor = System.Drawing.Color.Black;

        }
    }
}