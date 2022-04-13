using Mobimp.Edusoft.BussinessProcess.Common;
using System;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Common.Logging;
using System.Reflection;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Text;
using System.Collections;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Common;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.HR
{
    public partial class LeaveRequest : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_ddl();
                txtRequestNo.Attributes["disabled"] = "disabled";
                btn_Send.Attributes["disabled"] = "disabled";
                ddlsession.Attributes["disabled"] = "disabled";
                btn_Print.Visible = false;
                btn_Send.Text = "Send";
            }
        }
        protected void bind_ddl()
        {
            MasterLookupBO mstLookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_leavetype, mstLookupBO.GetLookupsList(LookupNames.LeaveType));
            Commonfunction.Populatelistbox(monthlist, mstLookupBO.GetLookupsList(LookupNames.Months));
            Commonfunction.PopulateDdl(ddlsession, mstLookupBO.GetLookupsList(LookupNames.Academicsession));
            ddlsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(tab2_ddlleavetype, mstLookupBO.GetLookupsList(LookupNames.LeaveType));
            div1.Visible = false;
        }
        string selectedItem = "";
        private void bindgrid(int index)
        {
            try
            {
                if (ddlsession.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select session.')", true);
                    GvLeaveRequest.DataSource = null;
                    GvLeaveRequest.DataBind();
                    btn_Send.Attributes["disabled"] = "disabled";
                    return;
                }

                if (monthlist.Items.Count > 0)
                {
                    for (int i = 0; i < monthlist.Items.Count; i++)
                    {
                        if (monthlist.Items[i].Selected)
                        {
                            selectedItem = selectedItem + "," + monthlist.Items[i].Value;
                        }
                    }
                }
                if (selectedItem == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select month.')", true);
                    GvLeaveRequest.DataSource = null;
                    GvLeaveRequest.DataBind();
                    btn_Send.Attributes["disabled"] = "disabled";
                    return;
                }

                if (ddl_leavetype.SelectedValue == "0")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select leave type.')", true);
                    GvLeaveRequest.DataSource = null;
                    GvLeaveRequest.DataBind();
                    btn_Send.Attributes["disabled"] = "disabled";
                    return;
                }

                int pagesize = 10000; // Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
                List<LeaveRequestData> lstleaveRequest = GetLeaveRequestDetails(index, pagesize);
                if (lstleaveRequest.Count > 0)
                {
                    GvLeaveRequest.PageSize = pagesize;
                    string record = lstleaveRequest[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                    //lblresult.Text = "Total : " + lstleaveRequest[0].MaximumRows.ToString() + " " + record;
                    //lbl_totalrecords.Text = lstleaveRequest[0].MaximumRows.ToString(); ;
                    //lblresult.Visible = true;
                    txt_totalLR.Attributes["disabled"] = "disabled";
                    //txt_totalLR.Text = "0";
                    GvLeaveRequest.VirtualItemCount = lstleaveRequest[0].MaximumRows;//total item is required for custom paging
                    GvLeaveRequest.PageIndex = index - 1;
                    GvLeaveRequest.DataSource = lstleaveRequest;
                    GvLeaveRequest.DataBind();
                    ds = ConvertToDataSet(lstleaveRequest);
                    TableCell tableCell = GvLeaveRequest.HeaderRow.Cells[0];
                    Image img = new Image();
                    img.ImageUrl = "~/app-assets/images/asc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);
                    bindresponsive();
                    btn_Send.Attributes.Remove("disabled");
                }
                else
                {
                    GvLeaveRequest.DataSource = null;
                    GvLeaveRequest.DataBind();
                    btn_Send.Attributes["disabled"] = "disabled";

                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        public List<LeaveRequestData> GetLeaveRequestDetails(int curIndex, int pagesize)
        {
            LeaveRequestData objdata = new LeaveRequestData();
            LeaveRequestBO objBO = new LeaveRequestBO();
            objdata.YearID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
            objdata.Year = ddlsession.SelectedItem.Text == null ? "" : ddlsession.SelectedItem.Text;
            objdata.Month = selectedItem.Substring(1);
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetLeaveRequestDetail(objdata);
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
        protected void bindresponsive()
        {
            GvLeaveRequest.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvLeaveRequest.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvLeaveRequest.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvLeaveRequest.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvLeaveRequest.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvLeaveRequest.UseAccessibleHeader = true;
            GvLeaveRequest.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void GvLeaveRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLeaveRequest.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvLeaveRequestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label Day = (Label)e.Row.FindControl("Gv_lblDay");
                    Label IsHoliday = (Label)e.Row.FindControl("Gv_lblHoliday");
                    CheckBox ChkboxRequest = (CheckBox)e.Row.FindControl("Gv_ChkIsLeaveRequest");
                    Label PreviousLeavestatus = (Label)e.Row.FindControl("lbl_LeaveStatus");

                    if (PreviousLeavestatus.Text == "1")
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#00FF00");
                        ChkboxRequest.Enabled = false;
                    }
                    else
                    {
                        ChkboxRequest.Checked = false;
                        ChkboxRequest.Enabled = true;
                    }
                    if (Day.Text == "Sunday")
                    {
                        ChkboxRequest.Enabled = false;
                        e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4D4D");
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                    }
                    else if (IsHoliday.Text == "1")
                    {
                        e.Row.Cells[4].BackColor = System.Drawing.Color.Yellow;
                        ChkboxRequest.Enabled = false;

                    }
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txt_totalLR.Text = "0";
            bindgrid(1);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            ddlsession.SelectedIndex = 1;
            lblmessage.Text = "";
            //lblresult.Text = "";
            //lbl_show.Text = "";
            //ddl_month.SelectedIndex = 0;
            //ddl_show.SelectedIndex = 0;
            //lbl_totalrecords.Text = "";
            GvLeaveRequest.DataSource = null;
            GvLeaveRequest.DataBind();
            txtRequestNo.Text = "";
            txt_remark.Text = "";
            ddl_leavetype.SelectedIndex = 0;
            if (monthlist.Items.Count > 0)
            {
                for (int i = 0; i < monthlist.Items.Count; i++)
                {
                    monthlist.Items[i].Selected = false;
                }
            }
            btn_Send.Attributes["disabled"] = "disabled";
            btn_Print.Visible = false;
            btn_Send.Text = "Send";
        }
        protected void Gv_ChkIsLeaveRequest_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;
            GridViewRow row = ((CheckBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            foreach (GridViewRow gvr in GvLeaveRequest.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("Gv_ChkIsLeaveRequest");
                if (cb != null && cb.Checked)
                {
                    count += 1;
                }
                Label Day = (Label)GvLeaveRequest.Rows[rowindex].FindControl("Gv_lblDate");
                Day.Focus();
            }
            txt_totalLR.Text = Convert.ToString(count);
        }
        protected void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                List<LeaveRequestData> ListLeaveRequest = new List<LeaveRequestData>();
                LeaveRequestBO leaveRequestBo = new LeaveRequestBO();
                LeaveRequestData leaveRequestData = new LeaveRequestData();

                int countleave = 0;

                foreach (GridViewRow gvr in GvLeaveRequest.Rows)
                {
                    CheckBox cb = (CheckBox)gvr.FindControl("Gv_ChkIsLeaveRequest");
                    if (cb != null && cb.Checked)
                    {
                        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                        Label YearID = (Label)GvLeaveRequest.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblYearID");
                        Label Year = (Label)GvLeaveRequest.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblYear");
                        Label MonthID = (Label)GvLeaveRequest.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
                        Label Month = (Label)GvLeaveRequest.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblMonth");
                        Label Date = (Label)GvLeaveRequest.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblDate");
                        TextBox Reason = (TextBox)GvLeaveRequest.Rows[gvr.RowIndex].Cells[0].FindControl("txtreason");
                        CheckBox chkLR = (CheckBox)GvLeaveRequest.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_ChkIsLeaveRequest");
                        LeaveRequestData ObjDetails = new LeaveRequestData();
                        countleave = +1;
                        ObjDetails.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
                        ObjDetails.Year = (Year.Text == null ? "" : Year.Text);
                        ObjDetails.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
                        ObjDetails.Month = (Month.Text == "" ? "0" : Month.Text);
                        ObjDetails.Reason = Reason.Text == null ? "" : Reason.Text;
                        ObjDetails.IsHoliday = chkLR.Checked ? 1 : 0;
                        //ObjDetails.RequestedDate = Convert.ToDateTime( Date.Text == null ? "" : Date.Text);
                        ObjDetails.RequestedDate = Date.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(Date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        ListLeaveRequest.Add(ObjDetails);
                    }
                }
                leaveRequestData.XMLData = XmlConvertor.LeaveRequestListToXml(ListLeaveRequest).ToString();
                leaveRequestData.AddedBy = LoginToken.LoginId;
                leaveRequestData.LeaveID = Convert.ToInt32(ddl_leavetype.SelectedValue == "0" ? "0" : ddl_leavetype.SelectedValue);
                leaveRequestData.Remark = txt_remark.Text.Trim() == "" ? "" : txt_remark.Text.Trim();
                leaveRequestData.UserId = LoginToken.UserLoginId;
                leaveRequestData.CompanyID = LoginToken.CompanyID;
                leaveRequestData.AcademicSessionID = LoginToken.AcademicSessionID;
                leaveRequestData.TotalDays = Convert.ToInt32(txt_totalLR.Text == "" ? "0" : txt_totalLR.Text);
                leaveRequestData.YearID = Convert.ToInt32(ddlsession.SelectedValue == "" ? "0" : ddlsession.SelectedValue);
                leaveRequestData.Year = ddlsession.SelectedItem.Text == "" ? "0" : ddlsession.SelectedItem.Text;
                // leaveRequestData.MonthID = Convert.ToInt32(ddl_month.SelectedValue == "" ? "0" : ddl_month.SelectedValue);
                //leaveRequestData.Month = ddl_month.SelectedItem.Text == "" ? "0" : ddl_month.SelectedItem.Text;
                List<LeaveRequestData> result = new List<LeaveRequestData>();
                if (countleave == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please check at least one day to send leave request.") + "')", true);
                    return;
                }
                if (txt_remark.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter remarks.") + "')", true);
                    return;
                }
                result = leaveRequestBo.InsertLeaveRequestDetails(leaveRequestData);
                if (result.Count > 0)
                {
                    txtRequestNo.Text = result[0].LeaveRequestNo;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Successfully Sent!") + "')", true);
                    btn_Send.Attributes["disabled"] = "disabled";
                    btn_Send.Text = "Sent";
                    btn_Print.Visible = true;
                    bindgrid(1);
                    return;
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            tab2_ddlleavetype.SelectedIndex = 0;
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            Gv_RequestList.DataSource = null;
            Gv_RequestList.DataBind();
        }
        private void bindtab2_grid(int pageIndex)
        {
            try
            {
                int pagesize = Convert.ToInt32(tab2_ddlshow.SelectedValue == "10000" ? tab2_lbltotalrecords.Text : tab2_ddlshow.Text);
                List<LeaveRequestData> tab2_lstleaveRequest = GetLeaveRequestList(pageIndex, pagesize);
                if (tab2_lstleaveRequest.Count > 0)
                {
                    Gv_RequestList.PageSize = pagesize;
                    string record = tab2_lstleaveRequest[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                    tab2_lblresult.Text = "Total : " + tab2_lstleaveRequest[0].MaximumRows.ToString() + " " + record;
                    tab2_lbltotalrecords.Text = tab2_lstleaveRequest[0].MaximumRows.ToString();
                    //lblresult.Visible = true;                    
                    Gv_RequestList.VirtualItemCount = tab2_lstleaveRequest[0].MaximumRows;
                    Gv_RequestList.PageIndex = pageIndex - 1;
                    Gv_RequestList.DataSource = tab2_lstleaveRequest;
                    Gv_RequestList.DataBind();
                    ds = ConvertToDataSet(tab2_lstleaveRequest);
                    TableCell tableCell = Gv_RequestList.HeaderRow.Cells[0];
                    Image img = new Image();
                    img.ImageUrl = "~/app-assets/images/asc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);
                    tab2_bindresponsive();
                    div1.Visible = true;
                }
                else
                {
                    Gv_RequestList.DataSource = null;
                    Gv_RequestList.DataBind();
                    div1.Visible = true;

                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        public List<LeaveRequestData> GetLeaveRequestList(int curIndex, int pagesize)
        {
            LeaveRequestData objdata = new LeaveRequestData();
            LeaveRequestBO objBO = new LeaveRequestBO();
            objdata.LeaveID = Convert.ToInt32(tab2_ddlleavetype.SelectedValue == "" ? "0" : tab2_ddlleavetype.SelectedValue);
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            objdata.Datefrom = Convert.ToDateTime(txtdatefrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdatefrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            objdata.DateTo = Convert.ToDateTime(txtdateto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtdateto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            objdata.IsActive = Convert.ToBoolean(tab2_ddlstatus.SelectedValue == "1" ? true : false);
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetLeaveRequestList(objdata);
        }
        protected void tab2_bindresponsive()
        {
            Gv_RequestList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Gv_RequestList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_RequestList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_RequestList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_RequestList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            Gv_RequestList.UseAccessibleHeader = true;
            Gv_RequestList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void tab2_btnSearch_Click(object sender, EventArgs e)
        {
            bindtab2_grid(1);
        }
        protected void Gv_RequestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LeaveRequestData requestData = new LeaveRequestData();
                    LeaveRequestBO requestBO = new LeaveRequestBO();
                    Label StatusID = (Label)e.Row.FindControl("Gv_lbltab2StatusID");
                    Button DeleteBtn = (Button)e.Row.FindControl("Gv_DeleteRequestList");
                    Label LRnumber = (Label)e.Row.FindControl("Gv_lblRequestNo");
                    if (StatusID.Text == "1")
                    {
                        DeleteBtn.Visible = true;
                    }
                    else
                    {
                        DeleteBtn.Visible = false;
                    }
                    requestData.LeaveRequestNo = LRnumber.Text == null ? "" : LRnumber.Text;
                    List<LeaveRequestData> listdata = new List<LeaveRequestData>();
                    listdata = requestBO.GetChildLeaveRequest(requestData);
                    if (listdata.Count > 0)
                    {
                        GridView view = (GridView)e.Row.FindControl("GridChildRecordDetails");
                        view.DataSource = listdata;
                        view.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void Gv_RequestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    LeaveRequestData requestData = new LeaveRequestData();
                    LeaveRequestBO requestBO = new LeaveRequestBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gvr = Gv_RequestList.Rows[i];
                    Label RequestNo = (Label)gvr.Cells[0].FindControl("Gv_lblRequestNo");
                    TextBox DeleteRemark = (TextBox)gvr.Cells[0].FindControl("tab2_GvtxtDeleteRemark");

                    if (DeleteRemark.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        DeleteRemark.Focus();
                        return;
                    }

                    requestData.LeaveRequestNo = RequestNo.Text == null ? "" : RequestNo.Text;
                    requestData.DeleteRemark = DeleteRemark.Text == null ? "" : DeleteRemark.Text;
                    int result = requestBO.DeleteLeaveRequestDetailsByLRNo(requestData);
                    if (result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                    bindtab2_grid(1);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GridChildRecordDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvchild = sender as GridView;

            LeaveRequestData requestData = new LeaveRequestData();
            LeaveRequestBO requestBO = new LeaveRequestBO();

            requestData.ID = Convert.ToInt64(gvchild.DataKeys[e.RowIndex].Values[0]);
            requestData.LeaveRequestNo = gvchild.DataKeys[e.RowIndex].Values[1].ToString();
            int result = requestBO.DeleteChildGridRequestList(requestData);
            if (result == 1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                bindtab2_grid(1);
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
        }
        protected void tab2_ddlshow_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindtab2_grid(1);
        }
    }
}
