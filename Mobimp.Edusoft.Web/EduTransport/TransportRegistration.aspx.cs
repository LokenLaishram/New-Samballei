using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Campusoft.Data.EduTransport;
using Mobimp.Campusoft.BussinessProcess.EduTransport;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;
using Mobimp.Edusoft.Data.EduTransport;
using Mobimp.Edusoft.BussinessProcess.EduTransport;

namespace Mobimp.Campusoft.Web.EduTransport
{
    public partial class TransportRegistration : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                txttransportregistrationno.Attributes["disabled"] = "disabled";
                txtsex.Attributes["disabled"] = "disabled";
                txtclass.Attributes["disabled"] = "disabled";
                txtsection.Attributes["disabled"] = "disabled";
                txtrollnos.Attributes["disabled"] = "disabled";
                txtDestination.Attributes["disabled"] = "disabled";
                if (Session["ID"] != null)
                {
                    edittransport(Convert.ToInt64(Session["ID"]));
                }
                divsearch.Visible = false;
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicyear, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicyear.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddltabacademicyear, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddltabacademicyear.SelectedIndex = 1;
            Commonfunction.PopulateDdl(Tabddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(Tabddlsection);
            Commonfunction.PopulateDdl(Tabddlsection, mstlookup.GetLookupsList(LookupNames.Section));
            Commonfunction.PopulateDdl(ddlTransportstudentType, mstlookup.GetLookupsList(LookupNames.StudentTransportType));
            Commonfunction.PopulateDdl(ddlrootID, mstlookup.GetLookupsList(LookupNames.Route));
            Commonfunction.PopulateDdl(TabddlrouteID, mstlookup.GetLookupsList(LookupNames.Route));
            Commonfunction.PopulateDdl(Tabddlvehicle, mstlookup.GetLookupsList(LookupNames.VehicleListwithDriver));
            ddlstatus.SelectedValue = "1";
            Commonfunction.Insertzeroitemindex(ddlVehicleID);
            Commonfunction.Insertzeroitemindex(TabddlsubrouteID);
            Commonfunction.Populatelistbox(monthlist, mstlookup.Getsessionmonthlist(Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue)));
        }
        protected void ddlacademicyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlacademicyear.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlrootID, mstlookup.GetRoutesByAcademicID(Convert.ToInt32(ddlacademicyear.SelectedValue)));
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlrootID);
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentNames(string prefixText, int count, string contextKey)
        {
            StudentData objemp = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objemp.StudentName = prefixText;
            getResult = objempBO.GetStudentNames(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentName.ToString());
            }
            return list;
        }
        protected void ddlrootID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlrootID.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlVehicleID, objmstlookupBO.GetVihicleByRootID(Convert.ToInt32(ddlrootID.SelectedValue == "" ? "0" : ddlrootID.SelectedValue), Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue)));
            }
            else
            {
                ddlVehicleID.SelectedIndex = 0;
            }
            txtDestination.Text = "";
        }
        protected void ddlVehicleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDestByRouteID();
        }
        protected void GetDestByRouteID()
        {
            if (ddlVehicleID.SelectedIndex > 0)
            {
                TransportFeeData objtransport = new TransportFeeData();
                TransportfeeBO objtransportBO = new TransportfeeBO();
                objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue);
                objtransport.RouteID = Convert.ToInt32(ddlrootID.SelectedValue == "" ? "0" : ddlrootID.SelectedValue);
                objtransport.VehicleID = Convert.ToInt32(ddlVehicleID.SelectedValue == "" ? "0" : ddlVehicleID.SelectedValue);

                List<TransportFeeData> Result = objtransportBO.GetDestinationByVehicleID(objtransport);
                if (Result.Count > 0)
                {
                    txtDestination.Text = Result[0].Destination.ToString();
                }
                else
                {
                    txtDestination.Text = "";
                }
            }
            else
            {
                txtDestination.Text = "";
            }
        }
        protected void TabddlrootID_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(TabddlsubrouteID, objmstlookupBO.GetVihicleByRootID(Convert.ToInt32(TabddlrouteID.SelectedValue == "" ? "0" : TabddlrouteID.SelectedValue), Convert.ToInt32(ddltabacademicyear.SelectedValue == "" ? "0" : ddltabacademicyear.SelectedValue)));
            bindgrid(1);
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            StudentData objSTD = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
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
            Int64 StudentID = Commonfunction.SemicolonSeparation_String_64(txtstdID.Text);
            Int32 AcademicSessionID = Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue);
            getstudentdeails(StudentID,AcademicSessionID);
        }
        protected void getstudentdeails(Int64 StudentID, Int32 AcademicSessionID)
        {
            StudentData objstd = new StudentData();
            TransportRegistrationBO objstdBO = new TransportRegistrationBO();
            objstd.StudentID = StudentID;
            //hdnstudentID.Value = StudentID;
            //hdnacademicID.Value = LoginToken.AcademicSessionID.ToString();
            objstd.AcademicSessionID = AcademicSessionID;
            List<StudentData> stdetails = objstdBO.GetTransportstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                hdnAdmissionNo.Value = stdetails[0].AdmissionNo.ToString();
                hdnclassID.Value = stdetails[0].ClassID.ToString();
                txtclass.Text = stdetails[0].ClassName;
                txtsex.Text = stdetails[0].SexName;
                hdnsectionID.Value = stdetails[0].SectionID.ToString();
                txtsection.Text = stdetails[0].SectionName;
                txtrollnos.Text = stdetails[0].RollNo.ToString();
                HiddenField2.Value = stdetails[0].IsTransportStudent.ToString();
                if (HiddenField2.Value == "1")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is Already Registered in Boarding.") + "')", true);
                }
            }
            else
            {
                txtclass.Text = "";
                txtsex.Text = "";
                txtsection.Text = "";
                hdnAdmissionID.Value = "";
                hdnclassID.Value = "";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student ID is not found.") + "')", true);
                return;
            }
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(Tabddlsection, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(Tabddlclass.SelectedValue == "" ? "0" : Tabddlclass.SelectedValue), Convert.ToInt32(ddltabacademicyear.SelectedValue == "" ? "0" : ddltabacademicyear.SelectedValue)));
        }
        string selectedItem = "";
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                TransportData objreg = new TransportData();
                TransportRegistrationBO objTransportRegistrationBO = new TransportRegistrationBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime StartDate = txtstartdate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtstartdate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objreg.StudentID = Commonfunction.SemicolonSeparation_String_64(txtstdID.Text);
                objreg.ClassID = Convert.ToInt32(hdnclassID.Value);
                objreg.SectionID = Convert.ToInt32(hdnsectionID.Value);
                objreg.RootID = Convert.ToInt32(ddlrootID.SelectedValue == "" ? "0" : ddlrootID.SelectedValue);
                objreg.TransportStudentTypeID = Convert.ToInt32(ddlTransportstudentType.SelectedValue == "" ? "0" : ddlTransportstudentType.SelectedValue);
                objreg.DestinationID = Convert.ToInt32(ddlVehicleID.SelectedValue == "" ? "0" : ddlVehicleID.SelectedValue);
                objreg.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
                objreg.AddedBy = LoginToken.LoginId;
                objreg.UserId = LoginToken.UserLoginId; ;
                objreg.CompanyID = LoginToken.CompanyID;
                objreg.StartDate = StartDate;

                objreg.AcademicSessionID = Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue); ;
                objreg.ActionType = EnumActionType.Insert;
                if (Session["ID"] != null)
                {
                    objreg.ActionType = EnumActionType.Update;
                    objreg.ID = Convert.ToInt32(Session["ID"].ToString());
                }
                int selectedcount = 0;
                if (monthlist.Items.Count > 0)
                {
                    for (int i = 0; i < monthlist.Items.Count; i++)
                    {
                        if (monthlist.Items[i].Selected)
                        {
                            selectedItem = selectedItem + "," + monthlist.Items[i].Value;
                            selectedcount = selectedcount + 1;
                        }
                    }
                }
                if (selectedcount == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select months.')", true);
                    return;
                }
                objreg.Monthlist = selectedItem.Substring(1);
                int result = objTransportRegistrationBO.UpdateTransportRegistration(objreg);
                if (result == 1 || result == 2)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    Session["ID"] = null;
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
        protected void GVtransportrehistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVtransportrehistration.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GVtransportrehistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    TransportData objreg = new TransportData();
                    TransportRegistrationBO objregBO = new TransportRegistrationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GVtransportrehistration.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objreg.ID = Convert.ToInt64(ID.Text);
                    objreg.ActionType = EnumActionType.Select;
                    edittransport(objreg.ID);
                    Response.Redirect("TransportRegistration.aspx", false);
                }
                if (e.CommandName == "Deletes")
                {
                    TransportData objreg = new TransportData();
                    TransportRegistrationBO objregBO = new TransportRegistrationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GVtransportrehistration.Rows[i];
                    objreg.ActionType = EnumActionType.Delete;
                    //TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    Label lblID = (Label)gr.Cells[0].FindControl("lblID");
                    //TextBox txtendDate = (TextBox)gr.Cells[0].FindControl("txtwdate");
                    //DropDownList ddlremark = (DropDownList)gr.Cells[0].FindControl("ddlremarks");

                    //ddlremark.Enabled = true;
                    //if (ddlremark.SelectedIndex == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Remark Type") + "')", true);
                    //    ddlremark.Focus();
                    //    return;
                    //}
                    //else
                    //{
                    //    objreg.Remarks = ddlremark.SelectedItem.Text;
                    //    objreg.RemarkID = Convert.ToInt32(ddlremark.SelectedValue == "" ? "0" : ddlremark.SelectedValue);
                    //    lblresult.Visible = false;
                    //}
                    //if (txtendDate.Text == "")
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter withdrawl Date") + "')", true);
                    //    txtendDate.Focus();
                    //    return;
                    //}
                    //else
                    //{

                    //    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    //    DateTime withdrawlDate = txtendDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtendDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    //    objreg.WithdrawlDate = withdrawlDate;
                    //    lblresult.Visible = false;
                    //}
                    objreg.ID = Convert.ToInt32(lblID.Text);
                    objreg.UserId = LoginToken.UserLoginId;
                    objreg.AcademicSessionID = LoginToken.AcademicSessionID;
                    //objreg.StudentID = Convert.ToInt64(StudentID.Text == "" ? "0" : StudentID.Text);
                    int Result = objregBO.DeleteTransportRegistrationByID(objreg);
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
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void edittransport(Int64 ID)
        {
            List<TransportData> GetResult = GetTransportRegistrationByID(ID);

            if (GetResult.Count > 0)
            {
                TransportFeeData objtransport = new TransportFeeData();
                TransportfeeBO objtransportBO = new TransportfeeBO();
                MasterLookupBO objmstlookupBO = new MasterLookupBO();

                Int64 StudentID = GetResult[0].StudentID;
                Int32 AcademicSessionID = Convert.ToInt32(GetResult[0].AcademicSessionID.ToString());
                Int32 RouteID = Convert.ToInt32(GetResult[0].RootID.ToString());

                Commonfunction.PopulateDdl(ddlrootID, objmstlookupBO.GetRoutesByAcademicID(AcademicSessionID));
                Commonfunction.PopulateDdl(ddlVehicleID, objmstlookupBO.GetVihicleByRootID(RouteID, AcademicSessionID));

                txtstdID.Text = GetResult[0].StudentName.ToString();
                txttransportregistrationno.Text = GetResult[0].TransportRegistrationNo.ToString();
                ddlTransportstudentType.SelectedValue = GetResult[0].TransportStudentTypeID.ToString();
                ddlrootID.SelectedValue = GetResult[0].RootID.ToString();

                getstudentdeails(StudentID,AcademicSessionID);
                ddlVehicleID.SelectedValue = GetResult[0].DestinationID.ToString();
                txtstartdate.Text = GetResult[0].StartDate.ToString("dd/MM/yyyy");
                ddlstatus.SelectedValue = GetResult[0].IsActive.ToString();
                Session["ID"] = GetResult[0].ID;
                ddlacademicyear.SelectedValue = GetResult[0].AcademicSessionID.ToString();

                GetDestByRouteID();
                Commonfunction.Populatelistbox(monthlist, objmstlookupBO.Getsessionmonthlist(Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue)));
                if (monthlist.Items.Count > 0)
                {
                    string SelectedMonths = GetResult[0].Monthlist.ToString();
                    string[] SplitMonths = SelectedMonths.Split(new Char[] {','});
                    for (int i = 0; i < monthlist.Items.Count; i++)
                    {
                        string ListOfMonths = monthlist.Items[i].Value.ToString();
                        foreach(string EachMonth in SplitMonths)
                        {
                            if (ListOfMonths.Equals(EachMonth))
                            {
                                monthlist.Items[i].Selected = true;
                            }
                        }
                    }
                }
                btnsave.Text = "Update";
            }
        }
        public List<TransportData> GetTransportRegistrationByID(Int64 ID)
        {
            TransportData objstd = new TransportData();
            TransportRegistrationBO objstdBO = new TransportRegistrationBO();
            objstd.ID = ID;
            return objstdBO.GetTransportRegistrationByID(objstd);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<TransportData> lstreg = GetTransportregistrationDetails(index, pagesize);
            if (lstreg.Count > 0)
            {
                GVtransportrehistration.PageSize = pagesize;
                string record = lstreg[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstreg[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstreg[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GVtransportrehistration.VirtualItemCount = lstreg.Count;//total item is required for custom paging
                GVtransportrehistration.PageIndex = index - 1;
                GVtransportrehistration.DataSource = lstreg;
                GVtransportrehistration.DataBind();
                ds = ConvertToDataSet(lstreg);
                TableCell tableCell = GVtransportrehistration.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                lblresult.Visible = false;
                GVtransportrehistration.Visible = true;
                GVtransportrehistration.DataSource = null;
                GVtransportrehistration.DataBind();
            }
            divsearch.Visible = true;
        }
        public List<TransportData> GetTransportregistrationDetails(int curIndex, int pagesize)
        {
            TransportData objreg = new TransportData();
            TransportRegistrationBO objFeeBO = new TransportRegistrationBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = Tabtxtdatefrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Tabtxtdatefrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = Tabtxtdateto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(Tabtxtdateto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objreg.StudentID = Commonfunction.SemicolonSeparation_String_64(txtstudentanme.Text);
            objreg.RootID = Convert.ToInt32(TabddlrouteID.SelectedValue == "" ? "0" : TabddlrouteID.SelectedValue);
            objreg.DestinationID = Convert.ToInt32(TabddlsubrouteID.SelectedValue == "" ? "0" : TabddlsubrouteID.SelectedValue);
            objreg.VihicleID = Convert.ToInt32(Tabddlvehicle.SelectedValue == "" ? "0" : Tabddlvehicle.SelectedValue);
            objreg.ClassID = Convert.ToInt32(Tabddlclass.SelectedValue == "" ? "0" : Tabddlclass.SelectedValue);
            objreg.SectionID = Convert.ToInt32(Tabddlsection.SelectedValue == "" ? "0" : Tabddlsection.SelectedValue);
            objreg.Datefrom = from;
            objreg.Dateto = To;
            objreg.AcademicSessionID = Convert.ToInt32(ddltabacademicyear.SelectedValue == "" ? "0" : ddltabacademicyear.SelectedValue);
            objreg.IsActive = tabddlstatus.SelectedValue == "1" ? true : false;
            objreg.CurrentIndex = curIndex;
            objreg.PageSize = pagesize;
            return objFeeBO.SearchTransportRegistration(objreg);
        }
        private void clearall()
        {
            ddlacademicyear.SelectedIndex = 1;
            ddlstatus.SelectedValue = "1";
            txttransportregistrationno.Text = "";
            txtstartdate.Text = "";
            txtstdID.Text = "";
            txtclass.Text = "";
            txtsection.Text = "";
            hdnclassID.Value = null;
            hdnstreamID.Value = null;
            hdnsectionID.Value = null;
            hdnAdmissionNo.Value = null;
            txtsex.Text = "";
            ddlTransportstudentType.SelectedIndex = 0;
            ddlrootID.SelectedIndex = 0;
            txtrollnos.Text = "";
            btnsave.Text = "Add";
            Commonfunction.Insertzeroitemindex(ddlVehicleID);
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.Populatelistbox(monthlist, mstlookup.Getsessionmonthlist(Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue)));
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Session["ID"] = null;
            clearall();
            // Response.Redirect("FeeCollection.aspx");
        }
        protected void txtstudentanme_TextChanged(object sender, EventArgs e)
        {
            if (txtstudentanme.Text.Trim() != "")
            {
                bindgrid(1);
            }
            else
            {
                txtstudentanme.Text = "";
                bindgrid(1);
            }
        }
        private void Tabclearall()
        {
            ddltabacademicyear.SelectedIndex = 1;
            tabddlstatus.SelectedValue = "1";
            txtstartdate.Text = "";
            Tabtxtdatefrom.Text = "";
            Tabtxtdateto.Text = "";
            Tabddlsection.SelectedIndex = 0;
            hdnclassID.Value = null;
            hdnstreamID.Value = null;
            hdnsectionID.Value = null;
            hdnAdmissionNo.Value = null;
            txtstudentanme.Text = "";
            Tabddlclass.SelectedIndex = 0;
            Tabddlsection.ClearSelection();
            ddlTransportstudentType.SelectedIndex = 0;
            TabddlrouteID.SelectedIndex = 0;
            TabddlsubrouteID.SelectedIndex = 0;
            Tabddlvehicle.SelectedIndex = 0;
            GVtransportrehistration.DataSource = null;
            GVtransportrehistration.DataBind();
            divsearch.Visible = false;
        }
        protected void Tabbtncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            Tabclearall();
        }
        protected void GVtransportrehistration_DataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GVtransportrehistration.Rows)
            {
                try
                {
                    Label lblremarkID = (Label)GVtransportrehistration.Rows[row.RowIndex].Cells[0].FindControl("lblremarkID");
                    DropDownList ddlremarks = (DropDownList)GVtransportrehistration.Rows[row.RowIndex].Cells[0].FindControl("ddlremarks");

                    MasterLookupBO mstlookup = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlremarks, mstlookup.GetLookupsList(LookupNames.Remarks));

                    if (lblremarkID.Text != "0")
                    {
                        ddlremarks.Items.FindByValue(ddlremarks.Text).Selected = true;

                    }
                    else
                    {
                        ddlremarks.Items.FindByValue(ddlremarks.Text).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GVtransportrehistration.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GVtransportrehistration.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GVtransportrehistration.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GVtransportrehistration.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GVtransportrehistration.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GVtransportrehistration.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GVtransportrehistration.UseAccessibleHeader = true;
            GVtransportrehistration.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GVtransportrehistration_Sorting(object sender, GridViewSortEventArgs e)
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
                    GVtransportrehistration.DataSource = sortedView;
                    GVtransportrehistration.DataBind();
                    bindresponsive();
                    TableCell tableCell = GVtransportrehistration.HeaderRow.Cells[ColumnIndex];
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
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Class List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= TransportReg.xlsx");
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
            List<TransportData> Transdata = GetTransportregistrationDetails(1, size);
            List<TransDataExcel> studentdetails = new List<TransDataExcel>();
            int i = 0;
            foreach (TransportData row in Transdata)
            {
                TransDataExcel EcxeclStd = new TransDataExcel();
                EcxeclStd.StudentID = Transdata[i].StudentID;
                EcxeclStd.StudentName = Transdata[i].StudentName;
                EcxeclStd.ClassName = Transdata[i].ClassName;
                EcxeclStd.SectionName = Transdata[i].SectionName;
                EcxeclStd.RollNo = Transdata[i].RollNo;
                studentdetails.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(studentdetails);
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void ddlsections_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddltabacademicyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltabacademicyear.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlrootID, mstlookup.GetRoutesByAcademicID(Convert.ToInt32(ddltabacademicyear.SelectedValue)));
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlrootID);
            }
            bindgrid(1);
        }
        protected void TabddlsubrouteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void Tabddlvehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void Tabtxtdatefrom_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void Tabtxtdateto_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void tabddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}