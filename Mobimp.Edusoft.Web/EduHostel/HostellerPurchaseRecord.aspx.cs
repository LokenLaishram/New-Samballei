using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Campusoft.BussinessProcess.EduHostel;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Data.EduStudent;

namespace Mobimp.Campusoft.Web.EduHostel
{
    public partial class HostellerPurchaseRecord : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddls();
                txtitemname.Attributes["disabled"] = "disabled";
                txtquantity.Attributes["disabled"] = "disabled";
                txtrate.Attributes["disabled"] = "disabled";
                btnsave.Attributes["disabled"] = "disabled";
                btnprint.Attributes["disabled"] = "disabled";
                lblstdblc.Attributes["disabled"] = "disabled";
            }
        }
        protected void Ddls()
        {
            //First Tap
            MasterLookupBO mstlookup = new MasterLookupBO();
            //Second Tap
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlacademicseesion, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesion.SelectedIndex = 1;
            ddlacademicseesions.SelectedIndex=1;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));            
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
            ItemData objstd = new ItemData();
            GetAutoItemNameBO objstdBO = new GetAutoItemNameBO();
            objstd.StudentID = Convert.ToInt64(txtstdID.Text == "" ? "0" : txtstdID.Text);
            objstd.AcademicSessionID = LoginToken.AcademicSessionID;
            hdnacademicID.Value = LoginToken.AcademicSessionID.ToString();
            List<ItemData> stdetails = objstdBO.GetstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                Clearall();
                txtstdID.Text = stdetails[0].StudentID.ToString();
                var stName = stdetails[0].StudentName;
                var className = stdetails[0].ClassName;
                var sex = stdetails[0].SexName;
                var section = stdetails[0].SectionName;
                var rollnos = stdetails[0].RollNo.ToString();
                lblstdblc.Text = Commonfunction.Getrounding(stdetails[0].DepositBalance.ToString());
                var CurrentBalance = Commonfunction.Getrounding(stdetails[0].CurrentAjustedAmount.ToString()); 
                //Concatenation
                //lblstudentname.Text = "<span style=\"color:green\">Name :</span> " + stName + " , <span style=\"color:green\">Sex : </span>" + sex + " , <span style=\"color:green\"> Class : </span> " + className + " , <span style=\"color:green\"> Section : </span> " + section + " , <span style=\"color:green\"> Roll No. : </span>" + rollnos + " , <span style=\"color:green\"> Due Amount. : </span>" + CurrentBalance;

                hdnacademicID.Value = stdetails[0].AcademicSessionID.ToString();
                hdnAdmissionID.Value = stdetails[0].AdmissionID.ToString();
                hdnAdmissionNo.Value = stdetails[0].AdmissionNo.ToString();
                hdnstudentID.Value = stdetails[0].StudentID.ToString();
                hdnclassID.Value = stdetails[0].ClassID.ToString();
                hdnsectionID.Value = stdetails[0].SectionID.ToString();
                hdnrollno.Value = stdetails[0].RollNo.ToString();
                hdndepositbalance.Value = stdetails[0].DepositBalance.ToString();
                txtitemname.Attributes.Remove("disabled");
                txtrate.Attributes.Remove("disabled");
                txtquantity.Attributes.Remove("disabled");
            }
            else
            {
                //lblstudentname.Text = "";
                hdnAdmissionID.Value = "";
                hdnclassID.Value = "";
                txtitemname.Attributes["disabled"]= "disabled";
                txtrate.Attributes["disabled"] = "disabled";
                txtquantity.Attributes["disabled"] = "disabled";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("No Record Found") + "')", true);
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

        protected void txtstudentanme_TextChanged(object sender, EventArgs e)
        {
            if (txtstudentanme.Text.Trim() != "")
            {
                Gettakingitemlist();

            }
            else
            {
                txtstudentanme.Text = "";
                Gettakingitemlist();

            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetItemNames(string prefixText, int count, string contextKey)
        {
            ItemData objitemName = new ItemData();
            GetAutoItemNameBO objitemBO = new GetAutoItemNameBO();
            List<ItemData> getResult = new List<ItemData>();
            objitemName.ItemName = prefixText;
            getResult = objitemBO.GetAutoItemName(objitemName);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].ItemName.ToString());
            }
            return list;
        }
        protected void TxtChange_TextChanged(object sender, EventArgs e)
        {
            txtrate.Focus();
            txtitemname.Attributes["disabled"] = "disabled";
        }
        protected void TxtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtitemname.Text != "")
            {
                ItemData objitem = new ItemData();
                GetAutoItemNameBO objitemBO = new GetAutoItemNameBO();

                var source = txtitemname.Text.ToString();
                //if (source.Contains(":"))
                //{
                //    string ID = source.Substring(source.LastIndexOf(':') + 1);
                //    objitem.ItemID = Convert.ToInt32(ID);

                //    // Check Duplicate data 
                //    foreach (GridViewRow row in Gvitemdetails.Rows)
                //    {
                //        IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                //        Label ServiceID = (Label)Gvitemdetails.Rows[row.RowIndex].Cells[0].FindControl("lblItemID");
                //        if (Convert.ToInt32(ServiceID.Text) == Convert.ToInt32(ID))
                //        {
                //            Messagealert_.ShowMessage(lblmessage, "Already added to the list", 0);
                //            txtquantity.Text = "";
                //            return;
                //        }
                //        else
                //        {
                //            lblmessage.Visible = false;
                //        }

                //    }
                //}
                //else
                //{
                //    txtitemname.Text = "";
                //    txtquantity.Text = "";
                //    return;
                //}

                //List<ItemData> result = objitemBO.GetItemDetailByID(objitem);
                if (txtitemname.Text !="")
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    List<ItemData> Itemlist = Session["Itemlist"] == null ? new List<ItemData>() : (List<ItemData>)Session["Itemlist"];
                    ItemData objItem = new ItemData();

                    //objItem.ItemID = Convert.ToInt32(result[0].ItemID.ToString());
                    objItem.ItemName = txtitemname.Text.Trim();
                    // objItem.ItemRate = Convert.ToDecimal(result[0].ItemRate.ToString());
                    //objItem.ItemQty = Convert.ToInt32(result[0].ItemQty.ToString());

                    objItem.ItemRate = Convert.ToInt32(txtrate.Text == "" ? "1" : txtrate.Text);
                    objItem.ItemQty = Convert.ToInt32(txtquantity.Text == "" ? "1" : txtquantity.Text);
                    objItem.TotalAmount = Convert.ToInt32(txtquantity.Text == "" ? "1" : txtquantity.Text) * Convert.ToInt32(txtrate.Text == "" ? "1" : txtrate.Text);
                    Decimal Netcharge = Convert.ToInt32(txtquantity.Text == "" ? "1" : txtquantity.Text) * Convert.ToInt32(txtrate.Text == "" ? "1" : txtrate.Text);

                    Itemlist.Add(objItem);

                    if (Itemlist.Count > 0)
                    {
                        Gvitemdetails.DataSource = Itemlist;
                        Gvitemdetails.DataBind();
                        Gvitemdetails.Visible = true;
                        Session["Itemlist"] = Itemlist;
                        btnsave.Attributes.Remove("disabled");
                        txtitemname.Attributes.Remove("disabled");
                        txtitemname.Text = "";
                        txtrate.Text = "";
                        txtquantity.Text = "";
                        txtitemname.Focus();
                        TotalSum();
                    }
                    else
                    {
                        Gvitemdetails.DataSource = null;
                        Gvitemdetails.DataBind();
                        Gvitemdetails.Visible = true;
                        btnsave.Attributes["disabled"]="disable";
                    }
                    // HighlightDuplicate(this.Gvitemdetails);
                }
                else
                {

                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Item name cannot be blank!, Please choose it.") + "')", true);
                txtitemname.Text = "";
                txtrate.Text = "";
                txtquantity.Text = "";
                return;
            }
        }
        //Sum of the gridview
        protected void TotalSum()
        {
            // TextBox txtquantity = (TextBox)sender;
            double Netamount = 0;
            double qtytotal = 0;
            double Balance = 0;
            double AjustedAmt = 0;
            foreach (GridViewRow gvr in Gvitemdetails.Rows)
            {
                Label ItemID = (Label)gvr.Cells[0].FindControl("lblItemID");
                Label ItemName = (Label)gvr.Cells[0].FindControl("lblitemname");
                Label Rate = (Label)gvr.Cells[0].FindControl("lblitemrate");
                Label qty = (Label)gvr.Cells[0].FindControl("lblquantity");
                Label TotalNet = (Label)gvr.Cells[0].FindControl("lbltotalAmount");
                Double totalamount;

                totalamount = Convert.ToDouble(qty.Text) * Convert.ToDouble(Rate.Text);
                TotalNet.Text = totalamount.ToString();
                Netamount = Netamount + totalamount;
                qtytotal = qtytotal + Convert.ToDouble(qty.Text);
            }
            //Display  the Totals in the Footer row
            lbltotalqty.Text = qtytotal.ToString();
            lbltotalamount.Text = Netamount.ToString();
            // Ajusted amount
            Balance = Convert.ToDouble(lblstdblc.Text == "" ? "0" : lblstdblc.Text);
            if (Netamount > Balance)
            {
                AjustedAmt = Netamount - Balance;
                lblajustedamt.Text = AjustedAmt.ToString();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Student balance is less than total amount.Please check if you to ajust from school a/c.") + "')", true);
                btnsave.Attributes["disabled"]="disabled";
                checkajust.Enabled = true;
            }
            else
            {
                lblajustedamt.Text = "0.00";
                checkajust.Enabled = false;
            }
        }
        protected void Txtbox_TextChanged(object sender, EventArgs e)
        {
            if (checkajust.Checked)
            {
                btnsave.Attributes.Remove("disabled");
            }
            else
            {
                btnsave.Attributes["disabled"]="disabled";
            }
        }

        protected void Gvitemdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvitemdetails.Rows[i];
                    List<ItemData> Itemlist = Session["Itemlist"] == null ? new List<ItemData>() : (List<ItemData>)Session["Itemlist"];
                    if (Itemlist.Count > 0)
                    {
                        Decimal totalamount = Itemlist[i].TotalAmount;
                        //lbltotalamount.Text = Commonfunction.Getrounding((Convert.ToDecimal(lbltotalamount.Text == "" ? "0" : lbltotalamount.Text) - totalamount).ToString());
                        //txtpaidamount.Text = Commonfunction.Getrounding((Convert.ToDecimal(txtpaidamount.Text == "" ? "0" : txtpaidamount.Text) - totalamount).ToString());
                    }
                    Itemlist.RemoveAt(i);
                    Session["Itemlist"] = Itemlist;
                    Gvitemdetails.DataSource = Itemlist;
                    Gvitemdetails.DataBind();
                    TotalSum();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                List<ItemData> ItemList = new List<ItemData>();
                ItemData objitem = new ItemData();
                GetAutoItemNameBO objitemBO = new GetAutoItemNameBO();
                foreach (GridViewRow row in Gvitemdetails.Rows)
                {
                    Label ItemID = (Label)Gvitemdetails.Rows[row.RowIndex].Cells[0].FindControl("lblItemID");
                    Label ItemName = (Label)Gvitemdetails.Rows[row.RowIndex].Cells[0].FindControl("lblitemname");
                    Label ItemRate = (Label)Gvitemdetails.Rows[row.RowIndex].Cells[0].FindControl("lblitemrate");
                    Label ItemQty = (Label)Gvitemdetails.Rows[row.RowIndex].Cells[0].FindControl("lblquantity");
                    Label ItemTotal = (Label)Gvitemdetails.Rows[row.RowIndex].Cells[0].FindControl("lbltotalAmount");
                    ItemData objitemlist = new ItemData();
                    objitemlist.ItemID = Convert.ToInt32(ItemID.Text == "" ? "0" : ItemID.Text);
                    objitemlist.ItemName = ItemName.Text.Trim();
                    objitemlist.ItemRate = Convert.ToDecimal(ItemRate.Text == "" ? "0" : ItemRate.Text);
                    objitemlist.ItemQty = Convert.ToInt32(ItemQty.Text == "" ? "0" : ItemQty.Text);
                    objitemlist.TotalAmount = Convert.ToDecimal(ItemTotal.Text == "" ? "0" : ItemTotal.Text);
                    ItemList.Add(objitemlist);
                    index++;
                }
                objitem.xmlItemList = XmlConvertor.ServiceItemListXML(ItemList).ToString();
                objitem.StudentID = Convert.ToInt32(hdnstudentID.Value == "" ? "0" : hdnstudentID.Value);
                objitem.ClassID = Convert.ToInt32(hdnclassID.Value == "" ? "0" : hdnclassID.Value);
                objitem.SectionID = Convert.ToInt32(hdnsectionID.Value == "" ? "0" : hdnsectionID.Value);
                objitem.RollNo = Convert.ToInt32(hdnrollno.Value == "" ? "0" : hdnrollno.Value);
                objitem.TotalItemQty = Convert.ToInt32(lbltotalqty.Text == "" ? "0" : lbltotalqty.Text);
                if (checkajust.Checked)
                {
                    objitem.IsAjusted = Convert.ToInt32(checkajust.Checked ? 1 : 0);
                    objitem.AjustedAmt = Convert.ToDecimal(lblajustedamt.Text == "" ? "0" : lblajustedamt.Text);
                }
                else
                {
                    objitem.IsAjusted = Convert.ToInt32(checkajust.Checked ? 1 : 0);
                    objitem.AjustedAmt = 0;
                }
                objitem.NetAmount = Convert.ToDecimal(lbltotalamount.Text == "" ? "0" : lbltotalamount.Text);
                objitem.AddedBy = LoginToken.LoginId;
                objitem.CompanyID = LoginToken.CompanyID;
                objitem.AcademicSessionID = LoginToken.AcademicSessionID;

                int results = objitemBO.UpdateTakingServiceItem(objitem);
                if (results > 0)
                {
                    // Session.Remove("Itemlist");
                    hdnreceiptno.Value = results.ToString();
                    // Gvitemdetails.DataSource = null;
                    // Gvitemdetails.DataBind();
                    // Gvitemdetails.Visible = false;
                    // txtstdID.Text = "";
                    //  lblstudentname.Text = "";
                    //  lblstdblc.Text = "";
                    //  lblajustedamt.Text = "";
                    //  lbltotalqty.Text = "";
                    //lbltotalamount.Text = "";
                    btnsave.Attributes["disabled"]="disabled";
                    btnprint.Attributes.Remove("disabled");
                    checkajust.Enabled = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnsave.Attributes["disabled"] = "disabled";
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
        // TAP 2 SEARCH
        protected void btnsearchs_Click(object sender, EventArgs e)
        {
            Gettakingitemlist();
        }
        protected void Gettakingitemlist()
        {

            ItemData objitemlist = new ItemData();
            GetAutoItemNameBO objitemBO = new GetAutoItemNameBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objitemlist.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objitemlist.StudentID = Convert.ToInt64(txtstudentIDs.Text.Trim() == "" ? "0" : txtstudentIDs.Text.Trim());
            objitemlist.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objitemlist.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objitemlist.ReceiptNo = txtrcno.Text.Trim() == "" ? "0" : txtrcno.Text.Trim();
            objitemlist.IsActiveALL = ddlstatus.SelectedValue;
            objitemlist.PageSize = Gvtakingitemdetails.PageSize;
            objitemlist.CurrentIndex = 0;
            objitemlist.Datefrom = from;
            objitemlist.Dateto = To;
            List<ItemData> result = objitemBO.SearchTakingItemListDetails(objitemlist);
            if (result.Count > 0)
            {
                lblnetqty.Text = Commonfunction.Getrounding(result[0].NetItemQty.ToString());
                lbltotalnetamount.Text = Commonfunction.Getrounding(result[0].TotalNetAmount.ToString());
                lbltotalajustedamt.Text = Commonfunction.Getrounding(result[0].TotalAjustedAmount.ToString());
                Gvtakingitemdetails.Visible = true;
                Gvtakingitemdetails.DataSource = result;
                Gvtakingitemdetails.DataBind();
                lblresults.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
            }
            else
            {
                lbltotalnetamount.Text = "0.00";
                lblnetqty.Text = "0";
                Gvtakingitemdetails.Visible = true;
                Gvtakingitemdetails.DataSource = null;
                Gvtakingitemdetails.DataBind();
            }
        }


        //TAP 2 CHILD GRIDVIEW
        protected void gv_Child_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ItemData objitemData = new ItemData();
                    GetAutoItemNameBO objitemBO = new GetAutoItemNameBO();
                    Label ReciptNo = (Label)e.Row.FindControl("lblrecipt");
                    objitemData.ReceiptNo = ReciptNo.Text.Trim();
                    List<ItemData> GetResult = objitemBO.SearchTakingItemByRecieptNo(objitemData);
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
            }
        }

        //TAP2 DELETE RECORD
        protected void GvTakingItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ItemData objitemdata = new ItemData();
                    GetAutoItemNameBO objDepositfeedBO = new GetAutoItemNameBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvtakingitemdetails.Rows[i];

                    Label lblrecipt = (Label)gr.Cells[12].FindControl("lblrecipt");
                    Label StudentID = (Label)gr.Cells[2].FindControl("lblstudentID");
                    Label SessionID = (Label)gr.Cells[12].FindControl("lblsessionID");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    txtremarks.Enabled = true;
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter remarks") + "')", true);
                        return;
                    }
                    else
                    {
                        objitemdata.Remarks = txtremarks.Text;
                    }
                    objitemdata.ReceiptNo = lblrecipt.Text == "" ? "null" : lblrecipt.Text;
                    objitemdata.StudentID = Convert.ToInt32(StudentID.Text == "" ? "0" : StudentID.Text);
                    objitemdata.AcademicSessionID = Convert.ToInt32(SessionID.Text == "" ? "0" : SessionID.Text);
                    objitemdata.UserId = LoginToken.UserLoginId;
                    int Result = objDepositfeedBO.DeleteTakingItemByReceiptNo(objitemdata);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                       Gettakingitemlist();
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
        protected void GvDepositfeedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvtakingitemdetails.PageIndex = e.NewPageIndex;
            Gettakingitemlist();
        }
        //TAP 1 RESET
        protected void btnreset_Click(object sender, EventArgs e)
        {
            Clearall();
        }
        protected void Clearall()
        {
            Session.Remove("Itemlist");
            txtstdID.Text = "";
            hdnclassID.Value = null;
            hdnAdmissionID.Value = "";
            //lblstudentname.Text = "";
            lblstdblc.Text = "";
            txtitemname.Text = "";
            txtitemname.Attributes["disabled"] = "disabled";
            txtrate.Text = "";
            txtrate.Attributes["disabled"] = "disabled";
            txtquantity.Attributes["disabled"] = "disabled";
            txtquantity.Text = "";
            lblmessage.Visible = false;
            hdnstudenttypeID.Value = null;
            ViewState["Count"] = null;
            Gvitemdetails.DataSource = null;
            Gvitemdetails.DataBind();
            Gvitemdetails.Visible = false;
            checkajust.Checked = false;
           // checkajust.Attributes["disabled"] = "disabled";
            lblajustedamt.Text = "0.00";
            lbltotalqty.Text = "0";
            lbltotalamount.Text = "0.00";
            btnprint.Attributes["disabled"] = "disabled";
            btnsave.Attributes["disabled"] = "disabled";
        }
        //TAP 2  RESET
        protected void btnresetall_Click(object sender, EventArgs e)
        {
            resetall();
        }
        protected void resetall()
        {
            txtstudentIDs.Text = "";
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Section));
            Gvtakingitemdetails.DataSource = null;
            Gvtakingitemdetails.DataBind();
            Gvtakingitemdetails.Visible = false;
            txtfrom.Text = "";
            txtto.Text = "";
            txtrcno.Text = "";
            ddlstatus.SelectedIndex = 0;
            ddlsections.SelectedIndex = 0;
            lblresults.Visible = false;
            lblmesagesdepositlist.Visible = false;
            lblnetqty.Text = "0";
            lbltotalnetamount.Text = "0.00";
            lbltotalajustedamt.Text = "0.00";
        }       
    }
}