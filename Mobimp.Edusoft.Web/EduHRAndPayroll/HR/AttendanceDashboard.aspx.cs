using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.HR
{
    public partial class AttendanceDashboard : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
                bindgrid(1);
            }
        }

        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            Commonfunction.PopulateDdl(ddlMonth, mstlookup.GetLookupsList(LookupNames.Months));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ManualAttendanceData> lstAttendance = GetAttendanceDashboard(index, pagesize);
            if (lstAttendance.Count > 0)
            {
                GvAttendanceDashboard.PageSize = pagesize;
                string record = lstAttendance[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstAttendance[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstAttendance[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvAttendanceDashboard.VirtualItemCount = lstAttendance[0].MaximumRows;//total item is required for custom paging
                GvAttendanceDashboard.PageIndex = index - 1;
                GvAttendanceDashboard.DataSource = lstAttendance;
                GvAttendanceDashboard.DataBind();
                ds = ConvertToDataSet(lstAttendance);
                TableCell tableCell = GvAttendanceDashboard.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvAttendanceDashboard.DataSource = null;
                GvAttendanceDashboard.DataBind();
            }
        }

        public List<ManualAttendanceData> GetAttendanceDashboard(int curIndex, int pagesize)
        {
            ManualAttendanceData objdata = new ManualAttendanceData();
            ManualAttendanceBO objBO = new ManualAttendanceBO();
            objdata.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            objdata.Year = ddlSession.SelectedItem.Text == null ? "" : ddlSession.SelectedItem.Text;
            objdata.MonthID = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "0" : ddlMonth.SelectedValue);
            objdata.Month = ddlMonth.SelectedItem.Text == null ? "" : ddlMonth.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.AcademicSessionID = LoginToken.AcademicSessionID;
            objdata.PageSize = GvAttendanceDashboard.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetAttendanceDashboard(objdata);
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
            //Responsive 
            GvAttendanceDashboard.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvAttendanceDashboard.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvAttendanceDashboard.UseAccessibleHeader = true;
            GvAttendanceDashboard.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void GvAttendanceDashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAttendanceDashboard.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }


    }
}