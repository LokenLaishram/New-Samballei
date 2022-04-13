using Mobimp.Campusoft.BussinessProcess.EduExam;
using Mobimp.Campusoft.Data.EduFeeUtility;
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

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class ExtraCuricularGrade :BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid(1);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ExamGradeData objData = new ExamGradeData();
                ExtraCuricularGradeBO objexamBO = new ExtraCuricularGradeBO();
                objData.Grade = txtGrade.Text;
                objData.GradeValue = Convert.ToInt32(txtGradeValue.Text == "" ? "0" : txtGradeValue.Text);
                objData.IsActive = ddlstatus.SelectedValue == "0" ? true : false;
                objData.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objData.ActionType = EnumActionType.Update;
                    objData.GradeID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objexamBO.UpdateExtraCuricularGrade(objData);
                if (result == 1 || result == 2)
                {
                    clearall();
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
                bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvExtracuriGrade_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ExamGradeData objexam = new ExamGradeData();
                    ExtraCuricularGradeBO objexamBO = new ExtraCuricularGradeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvExtracuriGrade.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objexam.GradeID = Convert.ToInt32(ID.Text);


                    List<ExamGradeData> GetResult = objexamBO.GetExtraCuricularGradeList(objexam);
                    if (GetResult.Count > 0)
                    {
                        txtGrade.Text = GetResult[0].Grade;
                        txtGradeValue.Text = GetResult[0].GradeValue.ToString();
                        ddlstatus.SelectedValue = GetResult[0].IsActive.ToString();
                        ViewState["ID"] = GetResult[0].GradeID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ExamGradeData objgrade = new ExamGradeData();
                    ExtraCuricularGradeBO objexamBO = new ExtraCuricularGradeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvExtracuriGrade.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objgrade.GradeID = Convert.ToInt32(ID.Text);
                    objgrade.ActionType = EnumActionType.Delete;
                    int Result = objexamBO.DeleteExtraCuricularGradeByID(objgrade);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ExamGradeData> lstclass = GetGradeValues(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvExtracuriGrade.PageSize = pagesize;
                string record = lstclass.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvExtracuriGrade.VirtualItemCount = lstclass.Count;//total item is required for custom paging
                GvExtracuriGrade.PageIndex = index - 1;
                GvExtracuriGrade.DataSource = lstclass;
                GvExtracuriGrade.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvExtracuriGrade.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvExtracuriGrade.DataSource = null;
                GvExtracuriGrade.DataBind();
            }
        }
        public List<ExamGradeData> GetGradeValues(int curIndex, int pagesize)
        {
            ExamGradeData objData = new ExamGradeData();
            ExtraCuricularGradeBO objexamBO = new ExtraCuricularGradeBO();
            objData.SubjectGrade = txtGrade.Text == "" ? null : txtGrade.Text;
            objData.GradeValue = Convert.ToInt32(txtGradeValue.Text == "" ? "0" : txtGradeValue.Text);
            objData.IsActive = ddlstatus.SelectedValue == "0" ? true : false;
            return objexamBO.GetSubjectGradeList(objData);
        }
        private void clearall()
        {
            txtGrade.Text = "";
            txtGradeValue.Text = "";
            bindgrid(1);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;         
            clearall();
            GvExtracuriGrade.DataSource = null;
            GvExtracuriGrade.DataBind();
            lblresult.Text = "";
        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvExtracuriGrade.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvExtracuriGrade.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExtracuriGrade.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExtracuriGrade.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            // GvExtracuriGrade.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvExtracuriGrade.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvExtracuriGrade.UseAccessibleHeader = true;
            GvExtracuriGrade.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvExtracuriGrade_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvExtracuriGrade.DataSource = sortedView;
                    GvExtracuriGrade.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvExtracuriGrade.HeaderRow.Cells[ColumnIndex];
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