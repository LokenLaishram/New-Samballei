using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduReports
{
    public partial class CertificateMaker : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                divSearch.Visible = false;
                //bindgrid(1);
                //lblmessage.Visible = true;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.Insertzeroitemindex(ddlsections);
            ddlacademicseesions.SelectedIndex = 1;
            txt_printdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        }
        protected void ddlCertificateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
            //lblmessage.Visible = false;
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecord.Text : ddl_show.SelectedValue);
            List<Examdata> lstclass = getStudentdetails(index, pagesize);
            if (lstclass.Count > 0)
            {
                divSearch.Visible = true;
                GvCertificateDetails.PageSize = pagesize;
                string record = lstclass.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass.Count.ToString() + " " + record;
                lbl_totalrecord.Text = lstclass.Count.ToString(); ;
                lblresult.Visible = true;
                GvCertificateDetails.VirtualItemCount = lstclass.Count;//total item is required for custom paging
                GvCertificateDetails.PageIndex = index - 1;
                GvCertificateDetails.DataSource = lstclass;
                GvCertificateDetails.DataBind();
                GvCertificateDetails.Visible = true;
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvCertificateDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                //bindresponsive();
                btnupdate.Visible = true;
            }
            else
            {
                lblresult.Visible = false;
                GvCertificateDetails.DataSource = null;
                GvCertificateDetails.DataBind();
                divSearch.Visible = true;
            }
        }
        public List<Examdata> getStudentdetails(int curIndex, int pagesize)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexam.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objexam.CertificateType = Convert.ToInt32(ddlCertificateType.SelectedValue == "" ? "0" : ddlCertificateType.SelectedValue);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.PageSize = pagesize;
            objexam.CurrentIndex = curIndex;
            return objexamBO.GetCTPCertifcateDetails(objexam);
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
            GvCertificateDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvCertificateDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvCertificateDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvCertificateDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvCertificateDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvCertificateDetails.UseAccessibleHeader = true;
            GvCertificateDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void chekboxall_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)GvCertificateDetails.HeaderRow.FindControl("chekboxall");
            foreach (GridViewRow row in GvCertificateDetails.Rows)
            {
                CheckBox checkrow = (CheckBox)row.FindControl("chekboxIsCreate");
                if (chckheader.Checked == true)
                {
                    checkrow.Checked = true;
                }
                else
                {
                    // checkrow.Checked = false;
                    bindgrid(1);
                }
            }
        }
        protected void GvCertificateDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvCertificateDetails.Rows)
            {
                try
                {
                    Label IsCreate = (Label)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("lblCreate");
                    CheckBox chekboxIsCreate = (CheckBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("chekboxIsCreate");
                    DropDownList Division = (DropDownList)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlBDiv");
                    Label lblDivision = (Label)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("lblBDiv");
                    //DropDownList ddlAttendance = (DropDownList)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlAttendance");
                    //Label lblAttendance = (Label)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("lblAttendance");
                    TextBox BRollNo = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("txtBrollno");
                    TextBox txtDateLeft = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("txtdateleft");
                    TextBox txtSubDivisions = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[5].FindControl("txtSubDivision");
                    DropDownList ddlYearPass = (DropDownList)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlYearP");
                    Label lblYearPass = (Label)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("lblYearP");
                    TextBox txtRegistrationNos = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("txtregistrationno");
                    //if (txtRegistrationNos.Text != "")
                    //{
                    //    txtRegistrationNos.Enabled = false;
                    //}
                    //else
                    //{
                    //    txtRegistrationNos.Enabled = true;
                    //}
                    MasterLookupBO mstlookup = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlYearPass, mstlookup.GetLookupsList(LookupNames.Academicsession));
                    ddlYearPass.SelectedIndex = 1;
                    if (lblYearPass.Text != "")
                    {
                        ddlYearPass.Visible = false;
                        lblYearPass.Visible = true;
                        ddlYearPass.Items.FindByText(lblYearPass.Text).Selected = true;
                    }
                    else
                    {
                        ddlYearPass.Visible = true;
                        lblYearPass.Visible = false;
                    }
                    if (lblDivision.Text == "First" || lblDivision.Text == "Second" || lblDivision.Text == "Third")
                    {
                        Division.Visible = false;
                        lblDivision.Visible = true;
                    }
                    else
                    {
                        Division.Visible = true;
                        lblDivision.Visible = false;
                    }
                    if (lblDivision.Text != "")
                    {
                        Division.Items.FindByText(lblDivision.Text).Selected = true;
                    }
                    //if (BRollNo.Text != "0")
                    //{
                    //    BRollNo.Enabled = false;
                    //}
                    //else
                    //{
                    //    BRollNo.Enabled = true;
                    //}
                    if (txtDateLeft.Text == "01/01/0001 12:00:00 AM" || txtDateLeft.Text == "01/01/0001" || txtDateLeft.Text == "01/01/1753")
                    {
                        txtDateLeft.Text = "";
                    }

                    if (ddlCertificateType.SelectedValue == "1")
                    {
                        GvCertificateDetails.Columns[6].Visible = false;
                        GvCertificateDetails.Columns[7].Visible = false;
                        GvCertificateDetails.Columns[8].Visible = false;
                    }
                    else if (ddlCertificateType.SelectedValue == "2")
                    {
                        GvCertificateDetails.Columns[6].Visible = false;
                        GvCertificateDetails.Columns[7].Visible = true;
                        GvCertificateDetails.Columns[8].Visible = false;
                    }
                    else if (ddlCertificateType.SelectedValue == "3")
                    {
                        GvCertificateDetails.Columns[6].Visible = true;
                        GvCertificateDetails.Columns[7].Visible = false;
                        GvCertificateDetails.Columns[8].Visible = true;
                    }
                    //if (ddlCertificateType.SelectedValue == "2" || ddlCertificateType.SelectedValue == "1")
                    //{
                    //    GvCertificateDetails.Columns[5].Visible = true;
                    //    GvCertificateDetails.Columns[9].Visible = false;
                    //}
                    //else
                    //{
                    //    GvCertificateDetails.Columns[5].Visible = false;
                    //    GvCertificateDetails.Columns[9].Visible = true;
                    //}

                    if (IsCreate.Text == "1")
                    {
                        chekboxIsCreate.Checked = true;
                        chekboxIsCreate.Enabled = false;
                    }
                    else
                    {
                        chekboxIsCreate.Checked = false;
                        chekboxIsCreate.Enabled = true;
                    }

                }

                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }

        }
        protected void GvCertificateDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCertificateDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvCertificateDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvCertificateDetails.DataSource = sortedView;
                    GvCertificateDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvCertificateDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            ddlclasses.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddlsections);
            ddlCertificateType.SelectedIndex = 0;
            txtrollNo.Text = "";
            txt_printdate.Text = Convert.ToString(System.DateTime.Today.ToString("dd-MM-yyyy"));
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<Examdata> lstexamdata = new List<Examdata>();
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();
            int index = 0;
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            try
            {
                // get all the record from the gridview
                int count = 0;
                foreach (GridViewRow row in GvCertificateDetails.Rows)
                {
                    CheckBox ChkIsCreate = (CheckBox)GvCertificateDetails.Rows[index].Cells[0].FindControl("chekboxIsCreate");
                    if (ChkIsCreate.Checked == true)
                    {
                        IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                        Label StudentID = (Label)GvCertificateDetails.Rows[index].Cells[0].FindControl("lblstudentID");
                        DropDownList ddlBDiv = (DropDownList)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlBDiv");
                        //DropDownList ddlAttendance = (DropDownList)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlAttendance");
                        TextBox BRollNo = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("txtBrollno");
                        TextBox txtDateLeft = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("txtdateleft");
                        TextBox txtSubDivisions = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("txtSubDivision");
                        DropDownList ddlYearPass = (DropDownList)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("ddlYearP");
                        TextBox txtRegistrationNos = (TextBox)GvCertificateDetails.Rows[row.RowIndex].Cells[0].FindControl("txtregistrationno");
                        Examdata ObjDetails = new Examdata();
                        count = count + 1;
                        ObjDetails.StudentID = Convert.ToInt32(StudentID.Text == "" ? "0" : StudentID.Text);
                        ObjDetails.IsPass = 1;
                        ObjDetails.BRollNo = Convert.ToInt32(BRollNo.Text == "" ? "0" : BRollNo.Text);
                        ObjDetails.BAttendance = "0";// Convert.ToString(ddlAttendance.Text == "" ? "0" : ddlAttendance.SelectedItem.Text);
                        ObjDetails.BDivision = Convert.ToString(ddlBDiv.Text == "" ? "0" : ddlBDiv.SelectedItem.Text);
                        // DateTime DateLefts = txtDateLeft.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDateLeft.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault); 
                        ObjDetails.DateLeft = txtDateLeft.Text.Trim();
                        ObjDetails.SubDivisions = (txtSubDivisions.Text == "null" ? "" : txtSubDivisions.Text.ToString());
                        ObjDetails.YearPass = Convert.ToString(ddlYearPass.Text == "" ? "0" : ddlYearPass.SelectedItem.Text);
                        ObjDetails.RegistrationNo = (txtRegistrationNos.Text == "null" ? "" : txtRegistrationNos.Text.ToString());
                        //ObjDetails.COHSEMDivisionID = Convert.ToInt32(ddlBDiv.SelectedValue == "" ? "0" : ddlBDiv.SelectedValue);
                        //ObjDetails.COHSEMDivision = ddlBDiv.SelectedItem.Text == "" ? "" : ddlBDiv.SelectedItem.Text;
                        lstexamdata.Add(ObjDetails);
                        index++;
                    }

                    //else
                    //{
                    //    objexam.IsPass = 0;
                    //    lstexamdata.Add(objexam);
                    //    index++;

                    //}

                }
                objexam.xmlCTPCertificatelist = XmlConvertor.CTPCertificatelistXML(lstexamdata).ToString();

                objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
                objexam.CertificateType = Convert.ToInt32(ddlCertificateType.SelectedValue == "" ? "0" : ddlCertificateType.SelectedValue);
                objexam.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
                objexam.CompanyID = LoginToken.CompanyID;
                objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                if (count == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select atleast one student.')", true);
                    return;
                }
                int results = objexamBO.CreateCTPCertificate(objexam);
                if (results == 1)
                {
                    bindgrid(1);
                    ViewState["StudentID"] = null;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

    }
}
