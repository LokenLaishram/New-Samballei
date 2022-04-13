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
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Campusoft.BussinessProcess.EduHostel;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Common;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;

namespace Mobimp.Campusoft.Web.EduHostel
{
    public partial class HostellerAjustedFeeDetails : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddls();
            }
        }
        protected void Ddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();

            /*********First Tap********/
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
           
            /*********Third Tap********/
            Commonfunction.PopulateDdl(ddlacademicsessions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsessions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));            
        }
        //protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bindddlss(Convert.ToInt32(ddlclass.SelectedValue));
        //}

        //protected void bindddlss(int classID)
        //{
        //    MasterLookupBO objmstlookupBO = new MasterLookupBO();
        //    Commonfunction.PopulateDdl(ddlsection, objmstlookupBO.GetSectionByClassID(classID));
        //}

        /*********Third Tap********/
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddl(Convert.ToInt32(ddlclasses.SelectedValue));
        }

        protected void bindddl(int classID)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsectionss, objmstlookupBO.GetSectionByClassID(classID));
        }

        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        //public static List<string> GetStudentID(string prefixText, int count, string contextKey)
        //{
        //    HostelRegistrationData objSTD = new HostelRegistrationData();
        //    HostelRegistrationBO objempBO = new HostelRegistrationBO();
        //    List<HostelRegistrationData> getResult = new List<HostelRegistrationData>();
        //    objSTD.AdmissionNo = prefixText;
        //    getResult = objempBO.GetStudentID(objSTD);

        //    List<String> list = new List<String>();
        //    for (int i = 0; i < getResult.Count; i++)
        //    {
        //        list.Add(getResult[i].AdmissionNo.ToString());
        //    }
        //    return list;
        //}

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

        protected void txtstudentanme_TextChanged(object sender, EventArgs e)
        {
            if (txtstudentanme.Text.Trim() != "")
            {
                GetAjustedlist();

            }
            else
            {
                txtstudentanme.Text = "";
                GetAjustedlist();

            }
        }
        protected void txtstudID_TextChanged(object sender, EventArgs e)
        {
            AjustedData objstd = new AjustedData();
            GetAjustedBO objstdBO = new GetAjustedBO();
            objstd.StudentID = Convert.ToInt64(txtstudID.Text == "" ? "0" : txtstudID.Text);
            hdnacademicID.Value = LoginToken.AcademicSessionID.ToString();
            List<AjustedData> stdetails = objstdBO.GetstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                Clearall();
                txtstudID.Text = stdetails[0].StudentID.ToString();
                var stName = stdetails[0].StudentName;
                var className = stdetails[0].ClassName;
                var sex = stdetails[0].SexName;
                var section = stdetails[0].SectionName;
                var rollnos = stdetails[0].RollNo.ToString();
                lblajustblc.Text = Commonfunction.Getrounding(stdetails[0].AjustedBalance.ToString());
                //Concatenation
                txtname.Text = "<span style=\"color:green\">Name :</span> " + stName + " , <span style=\"color:green\">Sex : </span>" + sex + " , <span style=\"color:green\"> Class : </span> " + className + " , <span style=\"color:green\"> Section : </span> " + section + " , <span style=\"color:green\"> Roll No. : </span>" + rollnos;

                hdnacademicID.Value = stdetails[0].AcademicSessionID.ToString();
                hdnAdmissionID.Value = stdetails[0].AdmissionID.ToString();
                hdnAdmissionNo.Value = stdetails[0].AdmissionNo.ToString();
                hdnstudentID.Value = stdetails[0].StudentID.ToString();
                hdnclassID.Value = stdetails[0].ClassID.ToString();
                hdnsectionID.Value = stdetails[0].SectionID.ToString();
                hdnrollno.Value = stdetails[0].RollNo.ToString();
                hdndepositbalance.Value = stdetails[0].AjustedBalance.ToString();
                txtpaidamount.Attributes.Remove("disabled");
                txtdate.Attributes.Remove("disabled");
                btnsave.Attributes.Remove("disabled");
            }
            else
            {
                txtname.Text = "";
                hdnAdmissionID.Value = "";
                hdnclassID.Value = "";
                txtpaidamount.Attributes["disabled"]= "disabled";
                txtdate.Attributes["disabled"] = "disabled";
                btnsave.Attributes["disabled"] = "disabled";
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GetAjustedlist();
        }
        protected void GetAjustedlist()
        {
            AjustedData objajustedlist = new AjustedData();
            GetAjustedBO objajustedBO = new GetAjustedBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objajustedlist.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            //objajustedlist.StudentID = Convert.ToInt64(txtstdId.Text.Trim() == "" ? "0" : txtstdId.Text.Trim());
            objajustedlist.StudentName = Convert.ToString(txtstudentanme.Text == "" ? "0" : txtstudentanme.Text);
            //objajustedlist.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            //objajustedlist.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
            //objajustedlist.RollNo = Convert.ToInt32(txtrollno.Text.Trim() == "" ? "0" : txtrollno.Text.Trim());            
            objajustedlist.Datefrom = DateFrom;
            objajustedlist.Dateto = DateTo;
            objajustedlist.Duestatus = ddlduestatus.SelectedValue;
            objajustedlist.IsActiveALL = ddlstatus.SelectedValue;
            objajustedlist.PageSize = GvAjustedDetails.PageSize;
            objajustedlist.CurrentIndex = 1 ;
            List<AjustedData> result = objajustedBO.SearchAjustedtDetails(objajustedlist);
            if (result.Count > 0)
            {
                lbltotalajustedamount.Text = Commonfunction.Getrounding(result[0].TotalAjustedAmount.ToString());
                GvAjustedDetails.Visible = true;
                GvAjustedDetails.DataSource = result;
                GvAjustedDetails.DataBind();
                lblresults.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lblresults.CssClass = "MsgSuccess";
                lblresults.Visible = true;

            }
            else
            {
                GvAjustedDetails.Visible = true;
                GvAjustedDetails.DataSource = null;
                GvAjustedDetails.DataBind();
                lblresults.Visible = true;
            }
        }
        /*********Tap 2 btn save********/
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal Ajustblc = 0, Paid = 0;
                AjustedData objajutdata = new AjustedData();
                GetAjustedBO objajustBO = new GetAjustedBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime PaidDate = txtdate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objajutdata.AcademicSessionID = LoginToken.AcademicSessionID;
                objajutdata.StudentID = Convert.ToInt32(txtstudID.Text == "" ? "0" : txtstudID.Text);
                if (txtstudID.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Student ID cannot be blank, Please enter it.") + "')", true);
                    return;
                }
                if (txtpaidamount.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Amount field cannot be blank, Please enter it.") + "')", true);
                    return;
                }
                if (txtdate.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Date field cannot be blank, Please pick date.") + "')", true);
                    return;
                }
                Ajustblc = Convert.ToDecimal(lblajustblc.Text.Trim());
                Paid = Int64.Parse(txtpaidamount.Text);

                if (Paid > Ajustblc)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Entered amount is greater than ajusted balance.") + "')", true);
                    return;
                }
                else
                {
                    objajutdata.AjustedBalance = Convert.ToDecimal(lblajustblc.Text == "" ? "0" : lblajustblc.Text);
                    objajutdata.PaidAmount = Convert.ToDecimal(txtpaidamount.Text == "" ? "0" : txtpaidamount.Text);
                }
                objajutdata.PaidDate = PaidDate;
                objajutdata.AddedBy = LoginToken.LoginId;
                objajutdata.CompanyID = LoginToken.CompanyID;
                objajutdata.AcademicSessionID = LoginToken.AcademicSessionID;
                int results = objajustBO.UpdateAjustedDetails(objajutdata);
                if (results > 0)
                {
                    hdnrcid.Value = results.ToString();
                    txtpaidamount.Attributes.Remove("disabled");
                    txtdate.Attributes.Remove("disabled");
                    btnsave.Attributes["disabled"]= "disabled";
                    btnprintss.Attributes.Remove("disabled");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnsave.Attributes.Remove("disabled");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        /****** Tap 3 *******/
        protected void btnsearchs_Click(object sender, EventArgs e)
        {
            GetFeeAjustedCollectionlist();
        }
        protected void GetFeeAjustedCollectionlist()
        {
            AjustedData objfeeajustedlist = new AjustedData();
            GetAjustedBO objfeeajustedBO = new GetAjustedBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objfeeajustedlist.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objfeeajustedlist.StudentID = Convert.ToInt64(txtstudentIDs.Text.Trim() == "" ? "0" : txtstudentIDs.Text.Trim());
            objfeeajustedlist.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objfeeajustedlist.SectionID = Convert.ToInt32(ddlsectionss.SelectedValue == "" ? "0" : ddlsectionss.SelectedValue);
            objfeeajustedlist.PaidRecieptNo = txtrcno.Text.Trim() == "" ? null : txtrcno.Text.Trim();
            objfeeajustedlist.Datefrom = DateFrom;
            objfeeajustedlist.Dateto = DateTo;
            objfeeajustedlist.IsActive = ddlstatuss.SelectedValue == "1" ? true : false;
            objfeeajustedlist.PageSize = Gvfeecollectiondetails.PageSize;
            objfeeajustedlist.CurrentIndex = 0;

            List<AjustedData> result = objfeeajustedBO.SearchFeeAjustedCollectoionDetails(objfeeajustedlist);
            if (result.Count > 0)
            {
                lbltotalajustedamount.Text = Commonfunction.Getrounding(result[0].TotalAjustedAmount.ToString());
                lblcollectedamount.Text = Commonfunction.Getrounding(result[0].TotalCollectedAmount.ToString());
                Gvfeecollectiondetails.Visible = true;
                Gvfeecollectiondetails.DataSource = result;
                Gvfeecollectiondetails.DataBind();
                lblresultses.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lblresultses.Visible = true;

            }
            else
            {
                Gvfeecollectiondetails.Visible = true;
                Gvfeecollectiondetails.DataSource = null;
                Gvfeecollectiondetails.DataBind();
                lblresultses.Visible = true;
            }
        }
        protected void GvAjustedfeedetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletess")
                {
                    AjustedData objajustdata = new AjustedData();
                    GetAjustedBO objAjustedBO = new GetAjustedBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvfeecollectiondetails.Rows[i];

                    Label ID = (Label)gr.Cells[0].FindControl("lblACID");
                    Label StudentsID = (Label)gr.Cells[2].FindControl("lblstudentID");
                    Label SessionID = (Label)gr.Cells[12].FindControl("lblsessionID");
                    TextBox txtremarkss = (TextBox)gr.Cells[0].FindControl("txtremarkss");
                    txtremarkss.Enabled = true;
                    if (txtremarkss.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter remarks") + "')", true);
                    }
                    else
                    {
                        objajustdata.Remarks = txtremarkss.Text;
                    }
                    objajustdata.ACID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    objajustdata.StudentID = Convert.ToInt32(StudentsID.Text == "" ? "0" : StudentsID.Text);
                    objajustdata.AcademicSessionID = Convert.ToInt32(SessionID.Text == "" ? "0" : SessionID.Text);
                    objajustdata.UserId = LoginToken.UserLoginId;
                    int Result = objAjustedBO.DeleteAjustedFeesByID(objajustdata);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        GetFeeAjustedCollectionlist();
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
        
        /****************Tap 1 Reset**********************/
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Clearall();
        }
        protected void Clearall()
        {
            txtstudentanme.Text = "";
            //txtstdId.Text = "";
            hdnclassID.Value = null;
            hdnAdmissionID.Value = "";
            txtname.Text = "";
            //ddlclass.SelectedIndex = 0;
            //ddlsection.SelectedIndex = 0;
            //txtrollno.Text = "";
            txtdatefrom.Text = "";
            txttoo.Text = "";
            ddlstatus.SelectedIndex = 0;
            hdnstudenttypeID.Value = null;
            ViewState["Count"] = null;
            txtpaidamount.Text = "";
            lblresults.Text = "";
            lbltotalajustedamount.Text = "0.00";
            GvAjustedDetails.Visible = true;
            GvAjustedDetails.DataSource = null;
            GvAjustedDetails.DataBind();
        }
        /**********Tap2 Reset*********************/
        protected void btnreset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        protected void ResetAll()
        {
            txtstudID.Text = "";
            hdnclassID.Value = null;
            hdnAdmissionID.Value = "";
            txtname.Text = "";
            hdnstudenttypeID.Value = null;
            ViewState["Count"] = null;
            txtpaidamount.Text = "";
            txtpaidamount.Enabled = true;
            lblajustblc.Text = "";
            txtdate.Text = "";
            txtdate.Enabled = true;
            /**********Tap3 Reset*********************/
            lblresultses.Text = "";
            txtstudentIDs.Text = "";
            ddlclasses.SelectedIndex = 0;
            ddlsectionss.SelectedIndex = 0;
            txtrcno.Text = "";
            txtfrom.Text = "";
            txtto.Text = "";
            ddlstatuss.SelectedIndex = 0;
            Gvfeecollectiondetails.Visible = true;
            Gvfeecollectiondetails.DataSource = null;
            Gvfeecollectiondetails.DataBind();
            lblcollectedamount.Text = "0.00";
        }

        /****************/
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<AjustedData> Ajustedlist = GetAjustedlist(index, pagesize);
            if (Ajustedlist.Count > 0)
            {
                GvAjustedDetails.Visible = true;
                GvAjustedDetails.PageSize = pagesize;
                string record = Ajustedlist[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresults.Text = "Total : " + Ajustedlist[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = Ajustedlist[0].MaximumRows.ToString();
                lblresults.Visible = true;
                GvAjustedDetails.VirtualItemCount = Ajustedlist[0].MaximumRows;//total item is required for custom paging
                GvAjustedDetails.PageIndex = index - 1;
                GvAjustedDetails.DataSource = Ajustedlist;
                GvAjustedDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(Ajustedlist);
                divsearch.Visible = true;
            }
            else
            {
                GvAjustedDetails.DataSource = null;
                GvAjustedDetails.DataBind();
                GvAjustedDetails.Visible = true;
                lblresults.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<AjustedData> GetAjustedlist(int curIndex, int pagesize)
        {
            AjustedData objstd = new AjustedData();
            GetAjustedBO objstdBO = new GetAjustedBO(); IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //objstd.StudentID = Commonfunction.SemicolonSeparation_String_64(txtstudentIDs.Text);
            objstd.StudentName = Convert.ToString(txtstudentanme.Text == "" ? "0" : txtstudentanme.Text);
            objstd.Datefrom = from;
            objstd.Dateto = To;
            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);            
            objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            //objstd.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);            
            objstd.IsActiveALL = ddlstatus.SelectedValue;
            objstd.ActionType = EnumActionType.Select;
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.SearchAjustedtDetails(objstd);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvAjustedDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            GvAjustedDetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvAjustedDetails.UseAccessibleHeader = true;
            GvAjustedDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvAjustedDetails.HeaderRow.Cells[0];
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
    }
}