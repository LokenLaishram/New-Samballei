using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.Common;
using System.Data;
using System.Reflection;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.Web.EduAdmin
{
    public partial class Usertracker : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        public List<Logintrackdata> GetTrackdetails(int curIndex, int pagesize)
        {
            Logintrackdata objemp = new Logintrackdata();
            EmployeeBO objempBO = new EmployeeBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtdatefrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdatefrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtdateto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtdateto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objemp.EmployeeID = Convert.ToInt32(txtempID.Text == "" ? "0" : txtempID.Text);
            objemp.EmpName = txtempname.Text.Trim();
            objemp.IsActive = true;
            objemp.DateFrom = from;
            objemp.DateTo = To;
          return objempBO.TrackLogin(objemp);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<Logintrackdata> result = GetTrackdetails(index, pagesize);
            if (result.Count > 0)
            {
                Gvlogintracklist.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gvlogintracklist.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                Gvlogintracklist.PageIndex = index - 1;
                Gvlogintracklist.DataSource = result;
                Gvlogintracklist.DataBind();
                ds = ConvertToDataSet(result);
                TableCell tableCell = Gvlogintracklist.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gvlogintracklist.DataSource = null;
                Gvlogintracklist.DataBind();
                Gvlogintracklist.Visible = true;
            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtempID.Text = "";
            txtempname.Text = "";
            txtdatefrom.Text = "";
            txtdateto.Text = "";
            Gvlogintracklist.DataSource = null;
            Gvlogintracklist.DataBind();
            Gvlogintracklist.Visible = false;
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gvlogintracklist.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gvlogintracklist.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gvlogintracklist.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gvlogintracklist.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gvlogintracklist.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //Gvlogintracklist.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gvlogintracklist.UseAccessibleHeader = true;
            Gvlogintracklist.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void Gvlogintracklist_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gvlogintracklist.DataSource = sortedView;
                    Gvlogintracklist.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gvlogintracklist.HeaderRow.Cells[ColumnIndex];
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