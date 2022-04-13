using Mobimp.Campusoft.BussinessProcess.EduExam;
using Mobimp.Campusoft.Data.EduExam;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class ExamRemarkRule : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlExamID, mstlookup.GetLookupsList(LookupNames.ExamNames));

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSessionID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select academic session.") + "')", true);
                    ddlSessionID.Focus();
                    return;
                }
                if (ddlClassID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select name of the class") + "')", true);
                    ddlClassID.Focus();
                    return;
                }
                if (ddlExamID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select name of the exam") + "')", true);
                    ddlExamID.Focus();
                    return;
                }
                ExamRemarkRuleData objData = new ExamRemarkRuleData();
                ExamRemarkRuleBO objBO = new ExamRemarkRuleBO();
                objData.SessionID = Convert.ToInt32(ddlSessionID.SelectedValue == "" ? "0" : ddlSessionID.SelectedValue);
                objData.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
                objData.ExamID = Convert.ToInt32(ddlExamID.SelectedValue == "" ? "0" : ddlExamID.SelectedValue);
                int result = objBO.AddNewRowRecord(objData);
                if (result == 1 || result == 2)
                {
                    bindgrid(1);
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
                bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvExamRemarkRule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    ExamRemarkRuleData objgrade = new ExamRemarkRuleData();
                    ExamRemarkRuleBO objexamBO = new ExamRemarkRuleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvExamRemarkRule.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrade.ID = Convert.ToInt32(ID.Text);
                    objgrade.ActionType = EnumActionType.Delete;
                    int Result = objexamBO.DeleteExamRemarkRuleByID(objgrade);
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
        protected void ddlExamID_OnTextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnsearch_OnClick(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            if (ddlSessionID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select academic session.") + "')", true);
                ddlSessionID.Focus();
                return;
            }
            if (ddlClassID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select name of the class") + "')", true);
                ddlClassID.Focus();
                return;
            }
            if (ddlExamID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select name of the exam") + "')", true);
                ddlExamID.Focus();
                return;
            }
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ExamRemarkRuleData> lstclass = GetGradeValues(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvExamRemarkRule.PageSize = pagesize;
                string record = lstclass.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvExamRemarkRule.VirtualItemCount = lstclass.Count;//total item is required for custom paging
                GvExamRemarkRule.PageIndex = index - 1;
                GvExamRemarkRule.DataSource = lstclass;
                GvExamRemarkRule.DataBind();
                GvExamRemarkRule.Visible = true;
                //ds = ConvertToDataSet(lstclass);
                //TableCell tableCell = GvExamRemarkRule.HeaderRow.Cells[0];
                //Image img = new Image();
                //img.ImageUrl = "~/app-assets/images/asc.gif";
                //tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                //tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvExamRemarkRule.DataSource = null;
                GvExamRemarkRule.DataBind();
            }
        }
        public List<ExamRemarkRuleData> GetGradeValues(int curIndex, int pagesize)
        {
            ExamRemarkRuleData objData = new ExamRemarkRuleData();
            ExamRemarkRuleBO objexamBO = new ExamRemarkRuleBO();
            objData.SessionID = Convert.ToInt32(ddlSessionID.SelectedValue == "" ? "0" : ddlSessionID.SelectedValue);
            objData.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objData.ExamID = Convert.ToInt32(ddlExamID.SelectedValue == "" ? "0" : ddlExamID.SelectedValue);
            return objexamBO.GetExamRemarkRuleList(objData);
        }

        //protected void btnupdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlSessionID.SelectedIndex == 0)
        //        {
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select academic session.") + "')", true);
        //            ddlSessionID.Focus();
        //            return;
        //        }
        //        if (ddlClassID.SelectedIndex == 0)
        //        {
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select name of the class.") + "')", true);
        //            ddlClassID.Focus();
        //            return;
        //        }
        //        if (ddlExamID.SelectedIndex == 0)
        //        {
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select name of the exam.") + "')", true);
        //            ddlClassID.Focus();
        //            return;
        //        }
        //        List<ExamRemarkRuleData> lstruledata = new List<ExamRemarkRuleData>();
        //        ExamRemarkRuleData objrule = new ExamRemarkRuleData();
        //        ExamRemarkRuleBO objBO = new ExamRemarkRuleBO();
        //        int index = 0;

        //        foreach (GridViewRow row in GvExamRemarkRule.Rows)
        //        {                    
        //            Label lblID = (Label)GvExamRemarkRule.Rows[index].Cells[0].FindControl("lblID");
        //            TextBox txtMarkFrom = (TextBox)GvExamRemarkRule.Rows[row.RowIndex].Cells[0].FindControl("txtMarkFrom");
        //            TextBox txtMarkUpTo = (TextBox)GvExamRemarkRule.Rows[row.RowIndex].Cells[0].FindControl("txtMarkUpTo");
        //            TextBox txtMarkRemark = (TextBox)GvExamRemarkRule.Rows[row.RowIndex].Cells[0].FindControl("txtMarkRemark");

        //            ExamRemarkRuleData objexamremark = new ExamRemarkRuleData();
        //            objexamremark.ID = Convert.ToInt32(lblID.Text == "" ? "0" : lblID.Text);
        //            objexamremark.MarkFrom = Convert.ToDecimal(txtMarkFrom.Text == "" ? "0" : txtMarkFrom.Text);
        //            objexamremark.MarkUpTo = Convert.ToDecimal(txtMarkUpTo.Text == "" ? "0" : txtMarkUpTo.Text);
        //            objexamremark.MarkRemarks = txtMarkRemark.Text == "" ? "" : txtMarkRemark.Text;
        //            lstruledata.Add(objexamremark);/
        //            index++;
        //        }
        //        objrule.xmlRemarkRulelist = XmlConvertor.ExamRemarkRuletoXML(lstruledata).ToString();
        //        objrule.AcademicSessionID = Convert.ToInt32(ddlSessionID.SelectedValue == "" ? "0" : ddlSessionID.SelectedValue);
        //        objrule.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
        //        objrule.ExamID = Convert.ToInt32(ddlExamID.SelectedValue == "" ? "0" : ddlExamID.SelectedValue);
        //        objrule.AddedBy = LoginToken.LoginId;
        //        objrule.CompanyID = LoginToken.CompanyID;

        //        int results = objBO.UpdateExamRemarkRule(objrule);
        //        if (results == 1)
        //        {
        //            bindgrid(1);
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
        //        }
        //        else
        //        {
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
        //    }

        //}
      
        protected void btncancel_Click(object sender, EventArgs e)
        {         
            GvExamRemarkRule.DataSource = null;
            GvExamRemarkRule.DataBind();
            lblresult.Text = "";
        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvExamRemarkRule.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvExamRemarkRule.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExamRemarkRule.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExamRemarkRule.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";

            GvExamRemarkRule.UseAccessibleHeader = true;
            GvExamRemarkRule.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvExamRemarkRule_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvExamRemarkRule.DataSource = sortedView;
                    GvExamRemarkRule.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvExamRemarkRule.HeaderRow.Cells[ColumnIndex];
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
    }
}