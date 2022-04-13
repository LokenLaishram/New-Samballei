using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.HR
{
    public partial class LeaveApproval : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_ddl();
                bindtab2_grid(1);
            }
        }
        protected void bind_ddl()
        {
            MasterLookupBO mstLookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsession, mstLookupBO.GetLookupsList(LookupNames.Academicsession));
            ddlsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(tab2_ddlleavetype, mstLookupBO.GetLookupsList(LookupNames.LeaveType));
            div1.Visible = false;
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
                    tab2_lblresult.Visible = true;
                }
                else
                {
                    Gv_RequestList.DataSource = null;
                    Gv_RequestList.DataBind();
                    div1.Visible = true;
                    tab2_lblresult.Visible = false;

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
            objdata.IsActive = true;
            objdata.RequestStatus = Convert.ToInt32(tab2_ddlstatus.SelectedValue == "" ? "0" : tab2_ddlstatus.SelectedValue);
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
                if (e.CommandName == "Action")
                {

                    LeaveRequestData requestData = new LeaveRequestData();
                    LeaveRequestBO requestBO = new LeaveRequestBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gvr = Gv_RequestList.Rows[i];
                    Label RequestNo = (Label)gvr.Cells[0].FindControl("Gv_lblRequestNo");
                    requestData.LeaveRequestNo = RequestNo.Text == null ? "" : RequestNo.Text;

                    List<LeaveRequestData> result = requestBO.GetleavedetailbyLRNo(requestData);
                    if (result.Count > 0)
                    {
                        gv_leavedeatils.DataSource = result;
                        gv_leavedeatils.DataBind();
                        lbl_requestedby.Text = result[0].RequestedBy.ToString();
                        lbl_lrnumber.Text = result[0].LeaveRequestNo.ToString();
                        lbl_leavetype.Text = result[0].LeaveType.ToString();
                        lbl_totalrequested.Text = result.Count.ToString();
                        lbl_eployeeID.Text = result[0].EmployeeID.ToString();
                        lbl_requestedon.Text = result[0].RequestedDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        lbl_requestedby.Text = "";
                        lbl_lrnumber.Text = "";
                        lbl_leavetype.Text = "";
                        lbl_totalrequested.Text = "";
                        lbl_requestedon.Text = "";
                        lbl_eployeeID.Text = "";
                        gv_leavedeatils.DataSource = null;
                        gv_leavedeatils.DataBind();

                    }
                    lbl_totalapprove.Text = "";
                    btn_approve.Text = "Reject All";
                    btn_approve.BackColor = System.Drawing.Color.Red;
                    btn_approve.ForeColor = System.Drawing.Color.Black;
                    this.ModalPopupExtender1.Show();
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

        protected void Gv_ChkIsLeaveRequest_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)check.NamingContainer;
            int count = 0;
            //  GridViewRow row = ((CheckBox)sender).Parent.Parent as GridViewRow;
            int rowindex = gridViewRow.RowIndex;

            Int32 lastindex = gv_leavedeatils.Rows.Count - 1;
            foreach (GridViewRow gvr in gv_leavedeatils.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("CheckApprove");
                if (cb != null && cb.Checked)
                {
                    count += 1;
                }
            }
            lbl_totalapprove.Text = count.ToString();
            if (count == 0)
            {
                btn_approve.BackColor = System.Drawing.Color.Red;
                btn_approve.ForeColor = System.Drawing.Color.Black;
                btn_approve.Text = "Reject All";
            }
            if (count > 0 && count < Convert.ToInt32(lbl_totalrequested.Text))
            {
                btn_approve.BackColor = System.Drawing.Color.Yellow;
                btn_approve.ForeColor = System.Drawing.Color.Black;
                btn_approve.Text = "Approve Partial";
            }
            if (count == Convert.ToInt32(lbl_totalrequested.Text))
            {
                btn_approve.BackColor = System.Drawing.Color.Green;
                btn_approve.ForeColor = System.Drawing.Color.White;
                btn_approve.Text = "Approve All";
            }
            TextBox reason = (TextBox)gridViewRow.FindControl("txtreason");
            reason.Focus();
            this.ModalPopupExtender1.Show();
        }
        protected void chekboxall_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)check.NamingContainer;
            int count = 0;

            Int32 lastindex = gv_leavedeatils.Rows.Count - 1;
            foreach (GridViewRow gvr in gv_leavedeatils.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("CheckApprove");
                if (cb != null && cb.Checked)
                {
                    count += 1;
                }
            }
            lbl_totalapprove.Text = count.ToString();
            if (count == 0)
            {
                btn_approve.BackColor = System.Drawing.Color.Red;
                btn_approve.ForeColor = System.Drawing.Color.Black;
                btn_approve.Text = "Reject All";

            }
            if (count > 0 && count < Convert.ToInt32(lbl_totalrequested.Text))
            {
                btn_approve.BackColor = System.Drawing.Color.Yellow;
                btn_approve.ForeColor = System.Drawing.Color.Black;
                btn_approve.Text = "Approve Partial";
            }
            if (count == Convert.ToInt32(lbl_totalrequested.Text))
            {
                btn_approve.BackColor = System.Drawing.Color.Green;
                btn_approve.ForeColor = System.Drawing.Color.White;
                btn_approve.Text = "Approve All";
            }
            this.ModalPopupExtender1.Show();
        }
        protected void btn_approve_Click(object sender, EventArgs e)
        {
            try
            {
                List<LeaveRequestData> ListLeaveRequest = new List<LeaveRequestData>();
                LeaveRequestBO leaveRequestBo = new LeaveRequestBO();
                LeaveRequestData ObjData = new LeaveRequestData();

                foreach (GridViewRow gvr in gv_leavedeatils.Rows)
                {
                    CheckBox cb = (CheckBox)gvr.FindControl("CheckApprove");

                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    Label YearID = (Label)gv_leavedeatils.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblYearID");
                    Label MonthID = (Label)gv_leavedeatils.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
                    Label Date = (Label)gv_leavedeatils.Rows[gvr.RowIndex].Cells[0].FindControl("Gv_lblDate");
                    TextBox Reason = (TextBox)gv_leavedeatils.Rows[gvr.RowIndex].Cells[0].FindControl("txtreason");
                    LeaveRequestData ObjDetails = new LeaveRequestData();

                    ObjDetails.YearID = Convert.ToInt32(YearID.Text == "" ? "0" : YearID.Text);
                    ObjDetails.MonthID = Convert.ToInt32(MonthID.Text == "" ? "0" : MonthID.Text);
                    ObjDetails.Reason = Reason.Text == null ? "" : Reason.Text;
                    ObjDetails.RequestedDate = Date.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(Date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    ObjDetails.IsApproved = Convert.ToInt32(cb.Checked ? "2" : "3");
                    ListLeaveRequest.Add(ObjDetails);

                }
                ObjData.XMLData = XmlConvertor.LeaveApproveListToXml(ListLeaveRequest).ToString();
                ObjData.AddedBy = LoginToken.LoginId;
                ObjData.Remark = txt_remarks.Text.Trim() == "" ? "" : txt_remarks.Text.Trim();
                ObjData.UserId = LoginToken.UserLoginId;
                ObjData.CompanyID = LoginToken.CompanyID;
                ObjData.AcademicSessionID = LoginToken.AcademicSessionID;
                ObjData.TotalDays = Convert.ToInt32(lbl_totalapprove.Text == "" ? "0" : lbl_totalapprove.Text);
                ObjData.EmployeeID = Convert.ToInt32(lbl_eployeeID.Text == "" ? "0" : lbl_eployeeID.Text);
                if (btn_approve.Text == "Approve All")
                {
                    ObjData.ApprovalStatus = 2;
                }
                if (btn_approve.Text == "Approve Partial")
                {
                    ObjData.ApprovalStatus = 3;
                }
                if (btn_approve.Text == "Reject All")
                {
                    ObjData.ApprovalStatus = 4;
                }

                ObjData.LeaveRequestNo = lbl_lrnumber.Text;
                if (txt_remarks.Text.Trim() == "")
                {
                    this.ModalPopupExtender1.Show();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter remarks.") + "')", true);
                    return;
                }
                int result = leaveRequestBo.UpdateLeaveApproval(ObjData);
                if (result == 1)
                {
                    if (btn_approve.Text == "Approve All")
                    {
                        btn_approve.Text ="Approved";
                    }
                    if (btn_approve.Text == "Approve Partial")
                    {
                        btn_approve.Text = "Approved Partial";
                    }
                    if (btn_approve.Text == "Reject All")
                    {
                        btn_approve.Text = "Rejected All";
                    }
                    bindtab2_grid(1);
                    this.ModalPopupExtender1.Show();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Successfully saved!") + "')", true);
                    return;
                }
                else
                {
                    this.ModalPopupExtender1.Show();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("System error.") + "')", true);
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
        protected void tab2_ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindtab2_grid(1);
        }
        protected void tab2_ddlleavetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindtab2_grid(1);
        }
        protected void txtdatefrom_TextChanged(object sender, EventArgs e)
        {
            bindtab2_grid(1);
        }
        protected void txtdateto_TextChanged(object sender, EventArgs e)
        {
            bindtab2_grid(1);
        }
    }
}