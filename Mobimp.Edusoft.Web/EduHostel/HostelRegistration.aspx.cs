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

using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;
using Mobimp.Campusoft.BussinessProcess.EduHostel;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using System.IO;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Web.UserControls;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;
namespace Mobimp.Campusoft.Web.EduHostel
{
    public partial class HostelRegistration : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
                txtregistrationno.Attributes["disabled"] ="disabled";
                if (Session["ID"] != null)
                {
                    editstudents(Convert.ToInt32(Session["ID"]), 0);
                    Session["ID"] = null;
                }
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicyear, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicyear.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddltabacademicyear, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddltabacademicyear.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlblock, mstlookup.GetLookupsList(LookupNames.Campus));
            Commonfunction.PopulateDdl(TabddlcampusID, mstlookup.GetLookupsList(LookupNames.Campus)); 
            Commonfunction.PopulateDdl(ddlwardenname, mstlookup.GetLookupsList(LookupNames.Warden));
            Commonfunction.PopulateDdl(Tabddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(Tabddlsection, mstlookup.GetLookupsList(LookupNames.Section));
            Commonfunction.PopulateDdl(ddldry, mstlookup.GetLookupsList(LookupNames.Wing));
            Commonfunction.PopulateDdl(TabddlwingID, mstlookup.GetLookupsList(LookupNames.Wing));
            //Commonfunction.PopulateDdl(ddlmonth, mstlookup.GetLookupsList(LookupNames.Months));
            Commonfunction.PopulateDdl(ddlstudentType, mstlookup.GetLookupsList(LookupNames.BoardingStudentType));
            //ddlacademicyear.SelectedIndex = 1;
            ddlstatus.SelectedIndex = 1;
        }
        protected void txtstdID_TextChanged(object sender, EventArgs e)
        {
            HostelRegistrationData objstd = new HostelRegistrationData();
            HostelRegistrationBO objstdBO = new HostelRegistrationBO();
            objstd.StudentID = Convert.ToInt64(txtstdID.Text == "" ? "0" : txtstdID.Text);
            hdnstudentID.Value = txtstdID.Text;
            hdnacademicID.Value = LoginToken.AcademicSessionID.ToString();
            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue);
            List<HostelRegistrationData> stdetails = objstdBO.GetHostelstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                txtname.Text = stdetails[0].StudentName;
                txtclass.Text = stdetails[0].ClassName;
                //txtsex.Text = stdetails[0].SexName;
                txtsection.Text = stdetails[0].SectionName;
                txtrollnos.Text = stdetails[0].RollNo.ToString();
                hdnAdmissionNo.Value = stdetails[0].AdmissionNo.ToString();
                hdnsectionID.Value = stdetails[0].SectionID.ToString();
                hdnclassID.Value = stdetails[0].ClassID.ToString();
                HiddenField2.Value = stdetails[0].Istakingtransport.ToString();
                if (HiddenField2.Value == "1")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is Already Registered in Transport.") + "')", true);
                    //Messagealert_.ShowMessage(lblmessage, "This Student is Already Registered in Transport.", 0);
                }
            }
            else
            {
                txtname.Text = "";
                txtclass.Text = "";
                //txtsex.Text = "";
                txtsection.Text = "";
                hdnAdmissionID.Value = "";
                hdnclassID.Value = "";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student ID is not found.") + "')", true);
                //Messagealert_.ShowMessage(lblmessage, "This Student ID is not found.", 0);
                return;

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

        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(Tabddlsection, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(Tabddlclass.SelectedValue == "" ? "0" : Tabddlclass.SelectedValue), Convert.ToInt32(ddltabacademicyear.SelectedValue == "" ? "0" : ddltabacademicyear.SelectedValue)));
            
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                HostelRegistrationData objreg = new HostelRegistrationData();
                HostelRegistrationBO objHostelRegistrationBO = new HostelRegistrationBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime EntranceDate = txtentdate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtentdate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                objreg.StudentID = Convert.ToInt32(txtstdID.Text == "" ? "0" : txtstdID.Text);
                objreg.HstudentTypeID = Convert.ToInt32(ddlstudentType.Text == "" ? "0" : ddlstudentType.Text);
                objreg.ClassID = Convert.ToInt32(hdnclassID.Value);
                // objreg.StreamID = Convert.ToInt32(hdnstreamID.Value);
                objreg.SectionID = Convert.ToInt32(hdnsectionID.Value);
                objreg.BlockID = Convert.ToInt32(ddlblock.SelectedValue == "" ? "0" : ddlblock.SelectedValue);
                objreg.WardenID = Convert.ToInt32(ddlwardenname.SelectedValue == "" ? "0" : ddlwardenname.SelectedValue);
                objreg.DryID = Convert.ToInt32(ddldry.SelectedValue == "" ? "0" : ddldry.SelectedValue);
                //objreg.MonthID = Convert.ToInt32(ddlmonth.SelectedValue == "" ? "0" : ddlmonth.SelectedValue);
                objreg.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
                objreg.AddedBy = LoginToken.LoginId;
                objreg.UserId = LoginToken.UserLoginId; ;
                objreg.CompanyID = LoginToken.CompanyID;
                objreg.EntranceDate = EntranceDate;
                objreg.AcademicSessionID = Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue); ;
                objreg.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objreg.ActionType = EnumActionType.Update;
                    objreg.ID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objHostelRegistrationBO.UpdateHostelRegistration(objreg);
                if (result == 1 || result == 2)
                {
                    clearall();
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    //Messagealert_.ShowMessage(lblmessage, result == 1 ? "save" : "update", 1);
                    ViewState["ID"] = null;
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    GVhostelrehistration.Visible = true;
                    bindgrid(1);
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
        protected void GVhostelrehistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVhostelrehistration.PageIndex = e.NewPageIndex;
            bindgrid(1);
        }
        protected void GvHostelstudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GVhostelrehistration.Rows)
            {
                try
                {
                    DropDownList ddlremark = (DropDownList)GVhostelrehistration.Rows[row.RowIndex].Cells[0].FindControl("ddlremarks");
                    MasterLookupBO objmstlookupBO = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlremark, objmstlookupBO.GetLookupsList(LookupNames.Remarks));
                    Label RemarkID = (Label)GVhostelrehistration.Rows[row.RowIndex].Cells[0].FindControl("lblremarkID");
                    if (RemarkID.Text != "0")
                    {
                        ddlremark.Items.FindByValue(RemarkID.Text).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }

        }
        public List<HostelRegistrationData> GetEditstudentdetails(Int64 IDS, int curIndex)
        {
            HostelRegistrationData objreg = new HostelRegistrationData();
            HostelRegistrationBO objregBO = new HostelRegistrationBO();
            objreg.IDS = IDS;
            return objregBO.GetHostelRegistrationByID(objreg);
        }
        protected void editstudents(Int64 IDS, int currenetIndex)
        {
            List<HostelRegistrationData> GetResult = GetEditstudentdetails(IDS, currenetIndex);
            if (GetResult.Count > 0)
            {
                //bindddl();
                txtstdID.Text = GetResult[0].StudentID.ToString();
                //txtregistrationno.Text = GetResult[0].RegistrationNo.ToString();
                ddlstatus.SelectedValue = GetResult[0].IsActive.ToString();
                ddlblock.SelectedValue = GetResult[0].BlockID.ToString();
                ddlwardenname.SelectedValue = GetResult[0].WardenID.ToString();
                ddlstudentType.SelectedValue = GetResult[0].HstudentTypeID.ToString();
                //ddlmonth.SelectedValue = GetResult[0].MonthID.ToString();
                ddldry.SelectedValue = GetResult[0].DryID.ToString();
                //txtentdate.Text = GetResult[0].EntranceDate.ToString();
                ViewState["ID"] = GetResult[0].ID;
                ddlacademicyear.SelectedValue = GetResult[0].AcademicSessionID.ToString();
                //HostelRegistrationData objstd = new HostelRegistrationData();
                //HostelRegistrationBO objstdBO = new HostelRegistrationBO();
                //objstd.StudentID = Convert.ToInt64(GetResult[0].StudentID.ToString());
                //objstd.AcademicSessionID = Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue);
                //List<HostelRegistrationData> stdetails = objstdBO.GetstudentDetailByID(objstd);
                //if (stdetails.Count > 0)
                //{
                //    txtname.Text = stdetails[0].StudentName;
                //    txtclass.Text = stdetails[0].ClassName;
                //    //txtsex.Text = stdetails[0].SexName;
                //    txtsection.Text = stdetails[0].SectionName;
                //    txtrollnos.Text = stdetails[0].RollNo.ToString();
                //    hdnAdmissionID.Value = stdetails[0].AdmissionID.ToString();
                //    hdnclassID.Value = stdetails[0].ClassID.ToString();
                //    hdnstreamID.Value = stdetails[0].StreamID.ToString();
                //    hdnstudenttype.Value = stdetails[0].IsNew.ToString();
                //    hdnAdmissionNo.Value = stdetails[0].AdmissionNo.ToString();
                //    hdnsectionID.Value = stdetails[0].SectionID.ToString();

                //}
                //else
                //{
                //    txtname.Text = "";
                //    txtclass.Text = "";
                //    //txtsex.Text = "";
                //    txtsection.Text = "";
                //    hdnAdmissionID.Value = "";
                //    hdnclassID.Value = "";
                //}
            }
        }
        protected void GVhostelrehistration_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editss")
                {
                    HostelRegistrationData objreg = new HostelRegistrationData();
                    HostelRegistrationBO objregBO = new HostelRegistrationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GVhostelrehistration.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblIDS");
                    Int64 IDS = Convert.ToInt64(ID.Text);
                    objreg.ActionType = EnumActionType.Select;
                    editstudents(IDS, 0);
                    Response.Redirect("HostelRegistration.aspx", false);
                    btnsave.Text = "Update";

                }
                if (e.CommandName == "Deletes")
                {
                    HostelRegistrationData objreg = new HostelRegistrationData();
                    HostelRegistrationBO objregBO = new HostelRegistrationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GVhostelrehistration.Rows[i];
                    objreg.ActionType = EnumActionType.Delete;
                    Label lblID = (Label)gr.Cells[0].FindControl("lblIDS");
                    TextBox txtendDate = (TextBox)gr.Cells[0].FindControl("txtwdate");
                    DropDownList ddlremark = (DropDownList)gr.Cells[0].FindControl("ddlremarks");
                    Label StudentID = (Label)gr.Cells[0].FindControl("lblstudentID");

                    ddlremark.Enabled = true;
                    if (ddlremark.SelectedIndex == 0)
                    {
                        Messagealert_.ShowMessage(lblresult, "Please select Remark Type", 0);
                        ddlremark.Focus();
                        return;
                    }
                    else
                    {
                        objreg.Remarks = ddlremark.SelectedItem.Text;
                        objreg.RemarkID = Convert.ToInt32(ddlremark.SelectedValue == "" ? "0" : ddlremark.SelectedValue);
                        lblresult.Visible = false;
                    }
                    if (txtendDate.Text == "")
                    {
                        Messagealert_.ShowMessage(lblresult, "Please enter withdrawl Date", 0);
                        txtendDate.Focus();
                        return;
                    }
                    else
                    {

                        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                        DateTime withdrawlDate = txtendDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtendDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        objreg.WithdrawlDate = withdrawlDate;
                        lblresult.Visible = false;
                    }
                    objreg.ID = Convert.ToInt32(lblID.Text);
                    objreg.UserId = LoginToken.UserLoginId;
                    objreg.AcademicSessionID = LoginToken.AcademicSessionID;
                    objreg.StudentID = Convert.ToInt64(StudentID.Text == "" ? "0" : StudentID.Text);

                    int Result = objregBO.DeleteHostelRegistrationByID(objreg);
                    if (Result == 1)
                    {
                        Messagealert_.ShowMessage(lblmessage, "delete", 1);
                        bindgrid(1);

                    }
                    else
                    {
                        Messagealert_.ShowMessage(lblmessage, "system", 0);
                    }

                }


            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
            }
        }
        protected void GVhostelrehistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           


        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
       
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<HostelRegistrationData> studentdetails = GetHostelregistrationDetails(index, pagesize);
            if (studentdetails.Count > 0)
            {
                GVhostelrehistration.Visible = true;
                GVhostelrehistration.PageSize = pagesize;
                string record = studentdetails[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + studentdetails[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = studentdetails[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GVhostelrehistration.VirtualItemCount = studentdetails[0].MaximumRows;//total item is required for custom paging
                GVhostelrehistration.PageIndex = index - 1;
                GVhostelrehistration.DataSource = studentdetails;
                GVhostelrehistration.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(studentdetails);
                divsearch.Visible = true;
            }
            else
            {
                GVhostelrehistration.DataSource = null;
                GVhostelrehistration.DataBind();
                GVhostelrehistration.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<HostelRegistrationData> GetHostelregistrationDetails(int curIndex,int pagesize)
        {
            HostelRegistrationData objreg = new HostelRegistrationData();
            HostelRegistrationBO objFeeBO = new HostelRegistrationBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = Tabtxtdatefrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Tabtxtdatefrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = Tabtxtdateto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(Tabtxtdateto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objreg.Sfirstname = Convert.ToString(txtstudentanme.Text == "" ? "0" : txtstudentanme.Text);
            objreg.StudentID = Convert.ToInt64(txtstdID.Text == "" ? "0" : txtstdID.Text);
            //objreg.RegistrationNo = Convert.ToInt64(txtregistrationno.Text == "" ? "0" : txtregistrationno.Text);
            objreg.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objreg.AcademicSessionID = Convert.ToInt32(ddlacademicyear.SelectedValue == "" ? "0" : ddlacademicyear.SelectedValue);
            objreg.BlockID = Convert.ToInt32(TabddlcampusID.SelectedValue == "" ? "0" : TabddlcampusID.SelectedValue);
            //objreg.MonthID = Convert.ToInt32(ddlmonth.SelectedValue == "" ? "0" : ddlmonth.SelectedValue);
            objreg.DryID = Convert.ToInt32(TabddlwingID.SelectedValue == "" ? "0" : TabddlwingID.SelectedValue);
            objreg.WardenID = Convert.ToInt32(Tabddlwarden.SelectedValue == "" ? "0" : Tabddlwarden.SelectedValue);
            objreg.ClassID = Convert.ToInt32(Tabddlclass.SelectedValue == "" ? "0" : Tabddlclass.SelectedValue);
            objreg.SectionID = Convert.ToInt32(Tabddlsection.SelectedValue == "" ? "0" : Tabddlsection.SelectedValue);
            objreg.Datefrom = from;
            objreg.Dateto = To;
            objreg.CurrentIndex = curIndex;
            objreg.PageSize = pagesize;
            return objFeeBO.SearchHostelRegistration(objreg);
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
        private void clearall()
        {
            //bindddl();
            //txtregistrationno.Text = "";
            txtstdID.Text = "";
            txtclass.Text = "";
            txtsection.Text = "";
            hdnclassID.Value = null;
            hdnstreamID.Value = null;
            hdnsectionID.Value = null;
            hdnAdmissionNo.Value = null;
            lblmessage.Text = "";
            lblmessage.Visible = false;
            //GVhostelrehistration.DataSource = null;
            //GVhostelrehistration.DataBind();
            //GVhostelrehistration.Visible = false;
            txtname.Text = "";
            //txtsex.Text = "";
            lblresult.Text = "";
            lblresult.Visible = false;
            ddlstudentType.SelectedIndex = 0;
            txtrollnos.Text = "";
            txtentdate.Text = "";
            //txtregistrationno.Attributes["disabled"] = "disabled";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
        }

        private void Tabclearall()
        {
            ddltabacademicyear.SelectedIndex = 1;
            tabddlstatus.SelectedValue = "1";
            //ddlstartmonth.SelectedIndex = 0;
            txtentdate.Text = "";
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
            ddlstudentType.SelectedIndex = 0;
            TabddlcampusID.SelectedIndex = 0;
            TabddlwingID.SelectedIndex = 0;
            Tabddlwarden.SelectedIndex = 0;
            GVhostelrehistration.DataSource = null;
            GVhostelrehistration.DataBind();
            //txtrollnos.Text = "";
            bindgrid(1);
        }
        protected void Tabbtncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            Tabclearall();
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

        protected void bindresponsive()
        {
            //Responsive 
            GVhostelrehistration.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GVhostelrehistration.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GVhostelrehistration.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GVhostelrehistration.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GVhostelrehistration.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GVtransportrehistration.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GVhostelrehistration.UseAccessibleHeader = true;
            GVhostelrehistration.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        ///Sorting
        protected void GVhostelrehistration_Sorting(object sender, GridViewSortEventArgs e)
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
                    GVhostelrehistration.DataSource = sortedView;
                    GVhostelrehistration.DataBind();

                    TableCell tableCell = GVhostelrehistration.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GVhostelrehistration.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GVhostelrehistration.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GVhostelrehistration.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GVhostelrehistration.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GVhostelrehistration.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GVhostelrehistration.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GVhostelrehistration.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GVhostelrehistration.UseAccessibleHeader = true;
                    GVhostelrehistration.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
            }
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

        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Student List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Class : Hos" + ".xlsx");
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
            List<HostelRegistrationData> studentdetails = GetHostelregistrationDetails(1, size);
            List<ExcelStudentList> listecelstd = new List<ExcelStudentList>();
            int i = 0;
            foreach (HostelRegistrationData row in studentdetails)
            {
                ExcelStudentList EcxeclStd = new ExcelStudentList();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.ClassName = studentdetails[i].ClassName;
                EcxeclStd.SectionName = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                //EcxeclStd.House = studentdetails[i].House;
                //EcxeclStd.AdmissionType = studentdetails[i].AdmissionType;
                //EcxeclStd.FatherNameORGuardianName = studentdetails[i].Gfirstname;
                //EcxeclStd.FatherORGuardianOccupation = studentdetails[i].Goccupation;
                //EcxeclStd.RelationshipWithGuardian = studentdetails[i].Grelationship;
                //EcxeclStd.Mothername = studentdetails[i].Mothername;
                //EcxeclStd.MothersOccupation = studentdetails[i].MotherOccupation;
                //EcxeclStd.ParentsIncome = studentdetails[i].Income;
                //EcxeclStd.DOB = studentdetails[i].ExcelDOB;
                //EcxeclStd.BirthRegNo = studentdetails[i].BirthRegNo;
                //EcxeclStd.Gender = studentdetails[i].SexName;
                //EcxeclStd.Religion = studentdetails[i].Religion;
                //EcxeclStd.Caste = studentdetails[i].CastName;
                //EcxeclStd.MotherTongue = studentdetails[i].MotherTongue;
                //EcxeclStd.BelongToBPL = studentdetails[i].BelongToBPLoptionName;
                //EcxeclStd.Address = studentdetails[i].pAddress;
                //EcxeclStd.District = studentdetails[i].pDistrict;
                //EcxeclStd.PIN = studentdetails[i].pPIN;
                //EcxeclStd.ContactNo = studentdetails[i].GmobileNo;
                //EcxeclStd.AadharNo = studentdetails[i].Aadhar;
                //EcxeclStd.BankName = studentdetails[i].BankName;
                //EcxeclStd.AccountNo = studentdetails[i].AC;
                //EcxeclStd.IFSC = studentdetails[i].IFSC;
                //EcxeclStd.EmailID = studentdetails[i].EmailID;
                //EcxeclStd.AdmissionDate = studentdetails[i].ExcelAD;
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

        
    }
}