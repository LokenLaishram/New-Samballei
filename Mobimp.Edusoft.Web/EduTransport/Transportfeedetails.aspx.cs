using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Data.EduTransport;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.EduTransport;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Data.EduFeeUtility;
using Mobimp.Campusoft.BussinessProcess.EduFeeUtility;

namespace Mobimp.Campusoft.Web.EduTransport
{
    public partial class Transportfeedetails : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                bindgrid(1);
                txtdestination.Attributes["disabled"] = "disabled";
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetRoutesByAcademicID(Convert.ToInt32(ddlacademicsession.SelectedValue)));
            //Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetLookupsList(LookupNames.Route));
            divsearch.Visible = false;
            Commonfunction.Insertzeroitemindex(ddltranporttype);
            Commonfunction.Insertzeroitemindex(ddl_vehiclenumber);
        }
        protected void ddlacademicsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlacademicsession.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetRoutesByAcademicID(Convert.ToInt32(ddlacademicsession.SelectedValue)));
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlrouteno);
            }
            //lblVehicleID.Text = "0";
            bindgrid(1);
        }
        protected void ddlrouteno_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            if (ddlrouteno.SelectedIndex > 0)
            {
                Commonfunction.PopulateDdl(ddltranporttype, objmstlookupBO.GetVehicleTypeByRouteID(Convert.ToInt32(ddlrouteno.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue)));
                ddl_vehiclenumber.SelectedIndex = 0;
            }
            else
            {
                //lblVehicleID.Text = "0";
                ddl_vehiclenumber.SelectedIndex = 0;
                ddltranporttype.SelectedIndex = 0;
                ddl_vehiclenumber.SelectedIndex = 0;
            }
            //lblVehicleID.Text = "0";
            txtdestination.Text = "";
            bindgrid(1);
        }
        protected void ddltranporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            if (ddltranporttype.SelectedIndex > 0)
            {
                //lblVehicleID.Text = "0";
                Commonfunction.PopulateDdl(ddl_vehiclenumber, mstlookup.GetVehicleNumberByVehicleTypeID(Convert.ToInt32(ddltranporttype.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue), Convert.ToInt32(ddlrouteno.SelectedValue)));
            }
            else
            {
                ddl_vehiclenumber.SelectedIndex = 0;
                //lblVehicleID.Text = "0";
            }
            txtdestination.Text = "";
            bindgrid(1);
        }
        protected void ddl_vehiclenumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_vehiclenumber.SelectedIndex > 0)
            {
                GetDestByRouteID();
                bindgrid(1);
            }
            else
            {
                //lblVehicleID.Text = "0";
                txtdestination.Text = "";
            }
        }
        protected void GetDestByRouteID()
        {
            TransportFeeData objtransport = new TransportFeeData();
            TransportfeeBO objtransportBO = new TransportfeeBO();
            objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objtransport.RouteID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
            objtransport.VehicleID = Convert.ToInt32(ddl_vehiclenumber.SelectedValue == "" ? "0" : ddl_vehiclenumber.SelectedValue);

            List<TransportFeeData> Result = objtransportBO.GetDestinationByVehicleID(objtransport);
            if (Result.Count > 0)
            {
                //lblVehicleID.Text = Result[0].VehicleID.ToString();
                txtdestination.Text = Result[0].Destination.ToString();
            }
            else
            {
                //lblVehicleID.Text = "0";
                txtdestination.Text = "";
            }
        }
        protected void txtexemptedamount_OnTextChanged(object sender, EventArgs e)
        {
            double TransfeeAmount = 0;
            double TransExemptAmount = 0;
            double FareAmount = 0;
            TransfeeAmount = Convert.ToDouble(txttranfeeamount.Text.Trim() == "" ? "0" : txttranfeeamount.Text.Trim());
              if (TransfeeAmount >= TransExemptAmount)
            {
                FareAmount = TransfeeAmount - TransExemptAmount;
                //txtfare.Text = FareAmount.ToString("N2");
                btnsave.Enabled = true;
                btnsave.Focus();
            }
            else
            {
                // txtfare.Text = "0.00";
                btnsave.Enabled = false;
                Messagealert_.ShowMessage(lblmessage, "Exempted amount is greater than fee amount.", 0);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                TransportFeeData objtransport = new TransportFeeData();
                TransportfeeBO objtransportBO = new TransportfeeBO();

                objtransport.RouteID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
                objtransport.TransportType = Convert.ToInt32(ddltranporttype.SelectedValue == "" ? "0" : ddltranporttype.SelectedValue);
                GetDestByRouteID();
                objtransport.VehicleNo = Convert.ToString(ddl_vehiclenumber.SelectedItem.Text == "" ? "0" : ddl_vehiclenumber.SelectedItem.Text);
                objtransport.VehicleID = Convert.ToInt32(ddl_vehiclenumber.SelectedValue == "" ? "0" : ddl_vehiclenumber.SelectedValue);
                objtransport.Destination = txtdestination.Text.Trim();
                objtransport.TransportFeeAmount = Convert.ToDecimal(txttranfeeamount.Text.Trim() == "" ? "0" : txttranfeeamount.Text.Trim());
                objtransport.Fare = Convert.ToDecimal(txttranfeeamount.Text.Trim() == "" ? "0" : txttranfeeamount.Text.Trim());
                objtransport.ActionType = EnumActionType.Insert;
                objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                objtransport.CompanyID = LoginToken.CompanyID;
                objtransport.AddedBy = LoginToken.LoginId;
                objtransport.UserId = LoginToken.UserLoginId;

                if (ViewState["ID"] != null)
                {
                    objtransport.ActionType = EnumActionType.Update;
                    objtransport.ID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objtransportBO.UpdateTransportFeesDetails(objtransport);
                if (result == 1 || result == 2)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                if (result == 5)
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
        protected void GvTransport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                TransportFeeData objfees = new TransportFeeData();
                TransportfeeBO objpayementBO = new TransportfeeBO();
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvTransport.Rows[i];

                if (e.CommandName == "Edits")
                {
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objfees.ID = Convert.ToInt32(ID.Text);

                    List<TransportFeeData> GetResult = objpayementBO.GetTransportFeesDetailsByID(objfees);
                    if (GetResult.Count > 0)
                    {
                        MasterLookupBO mstlookup = new MasterLookupBO();
                        ddlacademicsession.SelectedValue = GetResult[0].AcademicSessionID.ToString();
                        Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetRoutesByAcademicID(Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
                        ddlrouteno.SelectedValue = GetResult[0].RouteID.ToString();
                        Commonfunction.PopulateDdl(ddltranporttype, mstlookup.GetVehicleTypeByRouteID(Convert.ToInt32(ddlrouteno.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue)));
                        ddltranporttype.SelectedValue = GetResult[0].TransportType.ToString();
                        //Commonfunction.PopulateDdl(ddl_vehiclenumber, mstlookup.GetVehiclenumberbyTID(Convert.ToInt32(GetResult[0].TransportType)));
                        Commonfunction.PopulateDdl(ddl_vehiclenumber, mstlookup.GetVehicleNumberByVehicleTypeID(Convert.ToInt32(ddltranporttype.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue), Convert.ToInt32(ddlrouteno.SelectedValue)));
                        ddl_vehiclenumber.SelectedValue = GetResult[0].VehicleID.ToString();
                        //ddl_vehiclenumber.SelectedItem.Text = GetResult[0].VehicleNo.ToString();
                        GetDestByRouteID();
                        //txtdestination.Text = GetResult[0].Destination.ToString();
                        txttranfeeamount.Text = Commonfunction.Getrounding(GetResult[0].Fare.ToString());
                        ViewState["ID"] = GetResult[0].ID;
                        btnsave.Enabled = true;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                    else
                    {
                        ddlrouteno.SelectedIndex = 0;
                        ddltranporttype.SelectedIndex = 0;
                        ddl_vehiclenumber.SelectedIndex = 0;
                        txtdestination.Text = "";
                        txttranfeeamount.Text = "";
                        ViewState["ID"] = null;
                    }
                }
                if (e.CommandName == "Rule")
                {
                    Label vehiclenumber = (Label)gr.Cells[0].FindControl("lbl_vehiclenumber");
                    Label vehicledetails = (Label)gr.Cells[0].FindControl("lbl_vehicledetails");
                    Label routeID = (Label)gr.Cells[0].FindControl("lbl_routeID");
                    Label routeNo = (Label)gr.Cells[0].FindControl("lbl_routeNo");
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    lbl_route.Text = "Route : " + routeNo.Text;
                    lbl_vehicle.Text = "Vehicle Details : " + vehicledetails.Text;
                    lbl_session.Text = "Session : " + ddlacademicsession.SelectedItem.Text;
                    hdnlbl_feeID.Text = ID.Text;
                    hdnlbl_vehiclenumbers.Text = vehicledetails.Text;
                    hdn_lbl_routeid.Text = routeID.Text;

                    int SessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                    int Route = Convert.ToInt32(routeID.Text == "" ? "0" : routeID.Text);
                    string Vehcilenumber = vehicledetails.Text;
                    int FeeID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    GetExemptionRule(SessionID, Route, Vehcilenumber, FeeID);
                    this.ModalPopupExtender5.Show();
                }
                if (e.CommandName == "Deletes")
                {
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objfees.ID = Convert.ToInt32(ID.Text);

                    int Result = objpayementBO.DeleteTransFeesDetailsByID(objfees);
                    if (Result == 1)
                    {
                        GvTransport.Visible = true;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else
                    {
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
        }
        public void GetExemptionRule(int SessionID, int Route, string Vehcilenumber, int FeeID)
        {
            TransportExemptionRuleData objexemp = new TransportExemptionRuleData();
            ExemptionRuleBO objexempBO = new ExemptionRuleBO();
            objexemp.AcademicSessionID = SessionID;
            objexemp.RouteID = Route;
            objexemp.CompanyID = LoginToken.CompanyID;
            objexemp.VehicleNo = Vehcilenumber;
            objexemp.FeeID = FeeID;
            List<TransportExemptionRuleData> result = objexempBO.GetTransportExemptionRule(objexemp);
            if (result.Count > 0)
            {
                Gv_Exemption.DataSource = result;
                Gv_Exemption.DataBind();
                bindgridfoucs();
                this.ModalPopupExtender5.Show();
            }
            else
            {
                Gv_Exemption.DataSource = null;
                Gv_Exemption.DataBind();
            }
        }
        protected void btnsavepop5_Click(object sender, EventArgs e)
        {
            List<TransportExemptionRuleData> ExemptionList = new List<TransportExemptionRuleData>();
            TransportExemptionRuleData objexemp = new TransportExemptionRuleData();
            ExemptionRuleBO objexempBO = new ExemptionRuleBO();
            foreach (GridViewRow row in Gv_Exemption.Rows)
            {
                Label feeID = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lbl_feeID");
                Label StudentTypeID = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lbl_studenttypeID");
                Label fare = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lbl_fare");
                TextBox Exempted = (TextBox)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("txt_exemptedamount");
                Label netamount = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lbl_netfare");
                Label ID = (Label)Gv_Exemption.Rows[row.RowIndex].Cells[0].FindControl("lbl_exemtionID");

                TransportExemptionRuleData objXmlExemp = new TransportExemptionRuleData();
                objXmlExemp.ExemptionID = Convert.ToInt32(ID.Text);
                objXmlExemp.StudentTypeID = Convert.ToInt32(StudentTypeID.Text);
                objXmlExemp.FeeID = Convert.ToInt32(feeID.Text == "" ? "0" : feeID.Text);
                if (Convert.ToDecimal(Exempted.Text) > Convert.ToDecimal(fare.Text))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exemption exceeds the fare amount.") + "')", true);
                    Exempted.BackColor = System.Drawing.Color.Red;
                    Exempted.ForeColor = System.Drawing.Color.Black;
                    this.ModalPopupExtender5.Show();
                    return;
                }
                else
                {
                    Exempted.BackColor = System.Drawing.Color.White;
                    Exempted.ForeColor = System.Drawing.Color.Black;
                }

                objXmlExemp.ExemptedAmount = Convert.ToDecimal(Exempted.Text);
                objXmlExemp.NetFare = Convert.ToDecimal(fare.Text) - Convert.ToDecimal(Exempted.Text);
                ExemptionList.Add(objXmlExemp);
            }
            objexemp.XMLData = XmlConvertor.TransExemptiontoXML(ExemptionList).ToString();
            objexemp.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objexemp.FeeID = Convert.ToInt32(hdnlbl_feeID.Text == "" ? "0" : hdnlbl_feeID.Text);
            objexemp.UserId = LoginToken.UserLoginId;
            objexemp.CompanyID = LoginToken.CompanyID;
            int result = objexempBO.UpdateTransportExemptionRule(objexemp);
            if (result == 2)
            {
                int SessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                int Route = Convert.ToInt32(hdn_lbl_routeid.Text == "" ? "0" : hdn_lbl_routeid.Text);
                string Vehcilenumber = hdnlbl_vehiclenumbers.Text;
                int FeeID = Convert.ToInt32(hdnlbl_feeID.Text == "" ? "0" : hdnlbl_feeID.Text);
                GetExemptionRule(SessionID, Route, Vehcilenumber, FeeID);
                bindgrid(1);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
            }
            else
            {
                // BindExemption();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
            this.ModalPopupExtender5.Show();
        }
        protected void GvTransport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label Exemptionstatus = (Label)e.Row.FindControl("lbl_status");
                    Button lnlExemption = (Button)e.Row.FindControl("btn_rule");
                    Label lblActivate = (Label)e.Row.FindControl("lblactivate");
                    CheckBox ChkActivate = (CheckBox)e.Row.FindControl("chkactivate");
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
                    if (lblActivate.Text == "1")
                    {
                        ChkActivate.Checked = true;
                    }
                    else
                    {
                        ChkActivate.Checked = false;
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void bindgridfoucs()
        {
            for (int i = 0; i < Gv_Exemption.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_Exemption.Rows[i].Cells[3].FindControl("txt_exemptedamount") as TextBox;
                TextBox nexTextbox = Gv_Exemption.Rows[i + 1].Cells[3].FindControl("txt_exemptedamount") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_Exemption.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btn_save.ClientID + "', event)");
                }
            }

        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<TransportFeeData> lstexam = GetTransportfeedetails(index, pagesize);
            if (lstexam.Count > 0)
            {
                GvTransport.PageSize = pagesize;
                string record = lstexam[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstexam[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstexam[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvTransport.VirtualItemCount = lstexam[0].MaximumRows;//total item is required for custom paging
                GvTransport.PageIndex = index - 1;
                GvTransport.DataSource = lstexam;
                GvTransport.DataBind();
                GvTransport.Visible = true;
                ds = ConvertToDataSet(lstexam);
                TableCell tableCell = GvTransport.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();

            }
            else
            {
                GvTransport.Visible = true;
                GvTransport.DataSource = null;
                GvTransport.DataBind();
                lblmessage.Visible = false;
                lblresult.Visible = false;
            }
            divsearch.Visible = true;
        }
        public List<TransportFeeData> GetTransportfeedetails(int index, int pagesize)
        {
            TransportFeeData objtransport = new TransportFeeData();
            TransportfeeBO objtransportBO = new TransportfeeBO();
            objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objtransport.RouteID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
            objtransport.TransportType = Convert.ToInt32(ddltranporttype.SelectedValue == "" ? "0" : ddltranporttype.SelectedValue);
            //objtransport.VehicleNo = ddl_vehiclenumber.SelectedValue == "" ? "0" : ddl_vehiclenumber.SelectedValue;
            if (ddl_vehiclenumber.SelectedIndex > 0)
            {
                objtransport.VehicleNo = Convert.ToString(ddl_vehiclenumber.SelectedItem.Text.Trim());
            }
            else
            {
                objtransport.VehicleNo = "0";
            }
            objtransport.VehicleID = Convert.ToInt32(ddl_vehiclenumber.SelectedValue == "" ? "0" : ddl_vehiclenumber.SelectedValue);
            objtransport.Destination = txtdestination.Text.Trim();
            objtransport.PageSize = pagesize;
            objtransport.CurrentIndex = index;
            return objtransportBO.GetTransportfeedetails(objtransport);
        }
        private void clearall()
        {
            ddlrouteno.SelectedIndex = 0;
            ddltranporttype.SelectedIndex = 0;
            // ddltranportstdtype.SelectedIndex = 0;
            ddl_vehiclenumber.SelectedIndex = 0;
            //lblVehicleID.Text = "0";
            txtdestination.Text = "";
            txttranfeeamount.Text = "";
            // txtexemptedamount.Text = "";
            //txtfare.Text = "";
            GvTransport.DataSource = null;
            GvTransport.DataBind();
            GvTransport.Visible = false;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            GvTransport.DataSource = null;
            GvTransport.DataBind();
            GvTransport.Visible = false;
            btnsave.Text = "Add";
            divsearch.Visible = false;
            Commonfunction.Insertzeroitemindex(ddl_vehiclenumber);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvTransport.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvTransport.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvTransport.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvTransport.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvTransport.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvTransport.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvTransport.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvTransport.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvTransport.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvTransport.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvTransport.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvTransport.UseAccessibleHeader = true;
            GvTransport.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvTransport_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                bindgrid(1);
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
                    GvTransport.DataSource = sortedView;
                    GvTransport.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvTransport.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }
        }
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
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
                wb.Worksheets.Add(dt, "Fee Detail List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= TransportFeedetail.xlsx");
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
            int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<TransportFeeData> ClassDetail = GetTransportfeedetails(1, size);
            List<TransportFeeDatatoExcel> classtoexcel = new List<TransportFeeDatatoExcel>();
            int i = 0;
            foreach (TransportFeeData row in ClassDetail)
            {
                TransportFeeDatatoExcel EcxeclStd = new TransportFeeDatatoExcel();
                EcxeclStd.RouteNo = ClassDetail[i].RouteNo;
                EcxeclStd.TransportName = ClassDetail[i].TransportName;
                EcxeclStd.Destination = ClassDetail[i].Destination;
                classtoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(classtoexcel);
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
        protected void chkactivate_CheckedChanged(object sender, EventArgs e)
        {
            TransportFeeData objtransport = new TransportFeeData();
            TransportfeeBO objtransportBO = new TransportfeeBO();
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            Label ID = (Label)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("lblID");
            Label status = (Label)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("lbl_status");
            if (status.Text == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please make exemption rule.") + "')", true);
                return;
            }
            CheckBox chkf = (CheckBox)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("chkactivate");
            objtransport.IsActivate = chkf.Checked ? 1 : 0;
            objtransport.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
            objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            int result = objtransportBO.ActivateTransportFee(objtransport);
            if (result == 1)
            {
                bindgrid(1);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
        }
    }
}