using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System.Data;
using System.Reflection;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class ExamName : BasePage
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
                Examdata objexamdata = new Examdata();
                ExamTypeBO objexamBO = new ExamTypeBO();

                objexamdata.Code = txtcode.Text;
                objexamdata.ExamName = txtdescription.Text;
                objexamdata.IsActive = ddlstatus.SelectedValue == "0" ? true : false;
                objexamdata.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objexamdata.ActionType = EnumActionType.Update;
                    objexamdata.ExamID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objexamBO.UpdateExamName(objexamdata);
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
        protected void GvExamDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    Examdata objexam = new Examdata();
                    ExamTypeBO objexamBO = new ExamTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvExamDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objexam.ExamID = Convert.ToInt32(ID.Text);
                    objexam.ActionType = EnumActionType.Select;

                    List<Examdata> GetResult = objexamBO.GetExamNameByID(objexam);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].ExamName;
                        ddlstatus.SelectedValue = GetResult[0].IsActive.ToString();
                        ViewState["ID"] = GetResult[0].ExamID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    Examdata objexam = new Examdata();
                    ExamTypeBO objexamBO = new ExamTypeBO();
                    objexam.ExamID = Convert.ToInt32(e.CommandArgument.ToString());
                    objexam.ActionType = EnumActionType.Delete;
                    int Result = objexamBO.DeleteExamByID(objexam);
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
            List<Examdata> lstclass = GetExamnames(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvExamDetails.PageSize = pagesize;
                string record = lstclass.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvExamDetails.VirtualItemCount = lstclass.Count;//total item is required for custom paging
                GvExamDetails.PageIndex = index - 1;
                GvExamDetails.DataSource = lstclass;
                GvExamDetails.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvExamDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvExamDetails.DataSource = null;
                GvExamDetails.DataBind();
            }
        }
        public List<Examdata> GetExamnames(int curIndex, int pagesize)
        {
            Examdata objexamdata = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexamdata.Code = txtcode.Text == "" ? null : txtcode.Text;
            objexamdata.ExamName = txtdescription.Text == "" ? null : txtdescription.Text;
            objexamdata.IsActive = ddlstatus.SelectedValue == "0" ? true : false;
            return objexamBO.GetExamList(objexamdata);
        }
        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
            bindgrid(1);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            Response.Redirect("ExamName.aspx");
            clearall();
        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvExamDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvExamDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExamDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExamDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
           // GvExamDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvExamDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvExamDetails.UseAccessibleHeader = true;
            GvExamDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvExamDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvExamDetails.DataSource = sortedView;
                    GvExamDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvExamDetails.HeaderRow.Cells[ColumnIndex];
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