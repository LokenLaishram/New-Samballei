using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.Reports;
using Mobimp.Edusoft.BussinessProcess.Reports;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using SMSClassLibrary;
using Mobimp.Edusoft.Data.EduUtility;
using ASPSnippets.SmsAPI;

namespace Mobimp.Edusoft.Web.EduReports
{
    public partial class Defaulterlist : BasePage
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
            ddlsearch.SelectedIndex = 1;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Section));
            Commonfunction.PopulateDdl(ddlstreams, mstlookup.GetLookupsList(LookupNames.Stream));
            Commonfunction.PopulateDdl(ddlfeetypess, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlmonths, mstlookup.GetLookupsList(LookupNames.Months));
            lbltotalamount.Text = "0.00";
            lbltotfine.Text = "0.00";
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddlss(Convert.ToInt32(ddlclasses.SelectedValue));
        }
        protected void bindddlss(int classID)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(classID));
            Commonfunction.PopulateDdl(ddlstreams, objmstlookupBO.GetStreamByClassID(classID));
        }
        protected void btncreate_Click(object sender, EventArgs e)
        {
            try
            {

                DefaulterListData objfee = new DefaulterListData();
                DefaulterListBO objfeedBO = new DefaulterListBO();
                if (ddlstatus.SelectedValue == "1")
                {
                    btnsend.Enabled = true;
                }
                else
                {
                    btnsend.Enabled = false;
                }
                objfee.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                objfee.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objfee.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
                objfee.MonthID = Convert.ToInt32(ddlmonths.SelectedValue == "" ? "0" : ddlmonths.SelectedValue);
                objfee.FeeTypeID = Convert.ToInt32(ddlfeetypess.SelectedValue == "" ? "0" : ddlfeetypess.SelectedValue);
                objfee.IsActive = Convert.ToInt32(ddlstatus.SelectedValue == "" ? "0" : ddlstatus.SelectedValue);
                if (ddlfeetypess.SelectedValue == "1")
                {
                    objfee.ActionTypes = 1;
                }
                else if (ddlfeetypess.SelectedValue == "2")
                {
                    objfee.ActionTypes = 2;
                }
                else if (ddlfeetypess.SelectedValue == "3")
                {
                    objfee.ActionTypes = 3;
                }
                //else if (ddlfeetypess.SelectedValue == "4")
                //{
                //    objfee.ActionTypes = 4;
                //}
                objfee.UserId = LoginToken.UserLoginId;
                objfee.AcademicSessionID = LoginToken.AcademicSessionID;
                objfee.AddedBy = LoginToken.LoginId;

                List<DefaulterListData> result = objfeedBO.CreateDefaulterlist(objfee);
                if (result.Count > 0)
                {
                    lbltotalamount.Text = Commonfunction.Getrounding(result[0].TotalFees.ToString());
                    lbltotfine.Text = Commonfunction.Getrounding(result[0].TotalFine.ToString());
                    GvDefaulterlist.Visible = true;
                    GvDefaulterlist.DataSource = result;
                    GvDefaulterlist.DataBind();
                    Messagealert_.ShowMessage(lblmessage, "Successfully Created Defaulter List.", 1);
                }
                else
                {
                    lbltotalamount.Text = "0.00";
                    lbltotfine.Text = "0.00";
                    GvDefaulterlist.Visible = true;
                    GvDefaulterlist.DataSource = null;
                    GvDefaulterlist.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                Messagealert_.ShowMessage(lblmessage, "Could not Create Defaulter list.", 0);
            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        protected void resetall()
        {
            try
            {
                ddlsearch.SelectedIndex = 0;
                txtstudentanme.Text = "";
                txtstudentIDs.Text = "";
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
                ddlacademicseesions.SelectedIndex = 1;
                Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Section));
                Commonfunction.PopulateDdl(ddlstreams, mstlookup.GetLookupsList(LookupNames.Stream));
                Commonfunction.PopulateDdl(ddlfeetypess, mstlookup.GetLookupsList(LookupNames.FeeTypes));
                Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
                Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
                GvDefaulterlist.DataSource = null;
                GvDefaulterlist.DataBind();
                GvDefaulterlist.Visible = false;
                lblresult.Visible = false;
                lblmessage.Visible = false;
                txtfrom.Text = "";
                txtto.Text = "";
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                Messagealert_.ShowMessage(lblmessage, "System Error!.", 0);
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DefaulterListData objfee = new DefaulterListData();
            DefaulterListBO objfeedBO = new DefaulterListBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            if (ddlstatus.SelectedValue == "1")
            {
                btnsend.Enabled = true;
            }
            else
            {
                btnsend.Enabled = false;
            }
            objfee.StudentID = Convert.ToInt32(txtstudentIDs.Text == "" ? "0" : txtstudentIDs.Text);
            if (ddlsearch.SelectedIndex == 1)
            {
                objfee.StudentName = txtstudentanme.Text.Trim() == "" ? null : txtstudentanme.Text.Trim();
            }
            objfee.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objfee.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objfee.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objfee.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objfee.MonthID = Convert.ToInt32(ddlmonths.SelectedValue == "" ? "0" : ddlmonths.SelectedValue);
            objfee.FeeTypeID = Convert.ToInt32(ddlfeetypess.SelectedValue == "" ? "0" : ddlfeetypess.SelectedValue);
            objfee.IsActive = Convert.ToInt32(ddlstatus.SelectedValue == "" ? "0" : ddlstatus.SelectedValue);
            if (ddlfeetypess.SelectedValue == "1")
            {
                objfee.ActionTypes = 1;
            }
            else if (ddlfeetypess.SelectedValue == "2")
            {
                objfee.ActionTypes = 2;
            }
            else if (ddlfeetypess.SelectedValue == "3")
            {
                objfee.ActionTypes = 3;
            }
            //else if (ddlfeetypess.SelectedValue == "4")
            //{
            //    objfee.ActionTypes = 4;
            //}
            objfee.Datefrom = from;
            objfee.Dateto = To;
            objfee.AcademicSessionID = LoginToken.AcademicSessionID;
            List<DefaulterListData> result = objfeedBO.Getdefaulterlist(objfee);
            if (result.Count > 0)
            {
                lbltotalamount.Text = Commonfunction.Getrounding(result[0].TotalFees.ToString());
                lbltotfine.Text = Commonfunction.Getrounding(result[0].TotalFine.ToString());
                GvDefaulterlist.Visible = true;
                GvDefaulterlist.DataSource = result;
                GvDefaulterlist.DataBind();
            }
            else
            {
                lbltotalamount.Text = "0.00";
                lbltotfine.Text = "0.00";
                GvDefaulterlist.Visible = true;
                GvDefaulterlist.DataSource = null;
                GvDefaulterlist.DataBind();
            }
        }
        protected void btnsend_Click(object sender, EventArgs e)
        {
            // get all the record from the gridview
            try
            {

                foreach (GridViewRow row in GvDefaulterlist.Rows)
                {
                    int check = 0;
                    CheckBox chk = (CheckBox)GvDefaulterlist.Rows[row.RowIndex].Cells[0].FindControl("chekboxselect");
                    if (chk != null && chk.Checked && chk.Enabled && chk.Visible)
                    {
                        SMSdata objsms = new SMSdata();
                        Label cellnos = (Label)GvDefaulterlist.Rows[row.RowIndex].Cells[1].FindControl("lblcellno");
                        Label Name = (Label)GvDefaulterlist.Rows[row.RowIndex].Cells[1].FindControl("lblname");
                        Label Feeamount = (Label)GvDefaulterlist.Rows[row.RowIndex].Cells[1].FindControl("lblfee");
                        Label Fine = (Label)GvDefaulterlist.Rows[row.RowIndex].Cells[1].FindControl("lblfine");
                        Label Month = (Label)GvDefaulterlist.Rows[row.RowIndex].Cells[1].FindControl("lblmonth");

                        if (cellnos.Text != "")
                        {
                            string msg = "Hi, " + Name.Text.Trim() + " you have to pay late fine of Rs. " + Fine.Text.Trim() + "For the" + Month.Text + "Month.--MGS,Kakching.";
                            string CellNos = cellnos.Text;
                            SendsmsSite2sms(CellNos, msg);
                        }
                        else
                        {
                            Messagealert_.ShowMessage(lblmessage, "Please update Cell nos to the system.", 0);

                        }
                        check = check + 1;
                    }
                    if (check == 0)
                    {
                        Messagealert_.ShowMessage(lblmessage, "Please select atleast one student details to send.", 0);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                Messagealert_.ShowMessage(lblmessage, "System could not connect to the server.Check your internet connection and try again.", 0);
            }
        }
        public void SendsmsSite2sms(string mobnos, string msg)
        {
            SMS.APIType = SMSGateway.Site2SMS;
            SMS.MashapeKey = "2ECu69rcX5mshyt3ITAmPo3rS1eUp1hbXD2jsnwaaKKriuMJoC";
            string user = "8575226390";
            string pass = "imapaba";
            SMS.Username = user.Trim();
            SMS.Password = pass.Trim();
            if (mobnos != "")
            {   //Single SMS
                SMS.SendSms(mobnos, msg);
                Messagealert_.ShowMessage(lblmessage, "message sent.", 1);
                btnsend.Enabled = false;
                return;
            }
            //else if (listcellnos.Count > 1)
            //{
            //    //Multiple SMS
            //    SMS.SendSms(listcellnos[0].CellNos.Trim(), txtmassage.Text.Trim());
            //    Messagealert_.ShowMessage(lblmessage, "message sent.", 1);
            //}
            else
            {
                Messagealert_.ShowMessage(lblmessage, "Please select atleast one number.", 0);
                return;
            }

        }
    }
}