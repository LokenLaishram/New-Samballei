using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Data;
using System.Reflection;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class RankCorrector : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
            lblmessage.Visible = false;
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<Examdata> lstclass = getStudentdetails(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvExamdetails.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass.Count.ToString(); ;
                lblresult.Visible = true;
                GvExamdetails.VirtualItemCount = lstclass.Count;//total item is required for custom paging
                GvExamdetails.PageIndex = index - 1;
                GvExamdetails.DataSource = lstclass;
                GvExamdetails.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvExamdetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                txtworkingdays.Text = lstclass[0].TotalWorkingDay.ToString();
                btnupdate.Visible = true;
            }
            else
            {
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
                txtworkingdays.Text = "";
                btnupdate.Visible = false;
            }
        }
        
        public List<Examdata> getStudentdetails(int curIndex, int pagesize)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexam.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objexam.Status = Convert.ToInt32(ddlstatus.SelectedValue == "" ? "0" : ddlstatus.SelectedValue);
            objexam.Ranks = Convert.ToInt32(txtrank.Text == "" ? "0" : txtrank.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.PageSize = pagesize;
            objexam.CurrentIndex = curIndex;
            return objexamBO.GetstudentRankDetails(objexam);
        }
        protected void GvExamdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            foreach (GridViewRow row in GvExamdetails.Rows)
            {
                try
                {
                    Label Status = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblstatus");
                    TextBox Rank = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("txtrank");
                    Rank.Attributes["disabled"] = "disabled";
                    if (Status.Text == "P")
                    {
                        Status.CssClass = "indicator";
                        //Rank.Enabled = true;
                    }
                    else
                    {
                        Status.CssClass = "indicator2";
                        // Rank.Enabled = false;
                    }
                }

                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlexam.SelectedIndex = 0;
            lblmessage.Visible = false;
            GvExamdetails.DataSource = null;
            GvExamdetails.DataBind();
            GvExamdetails.Visible = false;
            btnupdate.Visible = false;
            txtrollNo.Text = "";
            ddlsections.SelectedIndex = 0;
            ddlstatus.SelectedIndex = 1;
            txtworkingdays.Text = " ";
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<Examdata> lstexamdata = new List<Examdata>();
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            int index = 0;

            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvExamdetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label ID = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblID");
                    Label SudentID = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblstudentID");
                    Label Roll = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblroll");
                    TextBox Rank = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txtrank");
                    TextBox Attendance = (TextBox)GvExamdetails.Rows[index].Cells[0].FindControl("txtattendance");


                    Examdata ObjDetails = new Examdata();
                    ObjDetails.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    ObjDetails.StudentID = Convert.ToInt32(SudentID.Text == "" ? "0" : SudentID.Text);
                    ObjDetails.Ranks = Convert.ToInt32(Rank.Text == "" ? "0" : Rank.Text);
                    ObjDetails.Attendance = Convert.ToInt32(Attendance.Text == "" ? "0" : Attendance.Text);
                    ObjDetails.TotalWorkingDay = Convert.ToInt32(txtworkingdays.Text == "" ? "0" : txtworkingdays.Text);
                    ObjDetails.RollNo = Convert.ToInt32(Roll.Text == "" ? "0" : Roll.Text);


                    lstexamdata.Add(ObjDetails);
                    index++;

                }
                objexam.XMLranklist = XmlConvertor.ClasswiseRanktoXML(lstexamdata).ToString();
                objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                //objexam.StudentID = Convert.ToInt64(ViewState["StudentID"].ToString() == "" ? "0" : ViewState["StudentID"].ToString());
                objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
                objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
                objexam.CompanyID = LoginToken.CompanyID;
                objexam.AcademicSessionID = LoginToken.AcademicSessionID;
                int results = objexamBO.UpdateCorrectRanklist(objexam);
                if (results == 1)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
                else
                {
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

        protected void bindresponsive()
        {
            //Responsive 
            GvExamdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvExamdetails.UseAccessibleHeader = true;
            GvExamdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvExamdetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvExamdetails.DataSource = sortedView;
                    GvExamdetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvExamdetails.HeaderRow.Cells[ColumnIndex];
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

        protected void GvExamdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvExamdetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}