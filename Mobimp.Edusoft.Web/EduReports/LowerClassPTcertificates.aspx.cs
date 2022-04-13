using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Reflection;
using System.Data;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.Web.EduReports
{
    public partial class LowerClassPTcertificates : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                bindddl();
                bindgrid(1);
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
        }
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclass.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlsection, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue)));
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ProvisionalTransfer objPT = new ProvisionalTransfer();
                AddstudentBO objstdBO = new AddstudentBO();
                objPT.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                objPT.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objPT.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
                objPT.CertificateType = Convert.ToInt32(ddlcType.SelectedValue == "" ? "0" : ddlcType.SelectedValue);
                objPT.RollNo = Convert.ToInt32(txtrollnos.Text == "" ? "0" : txtrollnos.Text);
                objPT.Division = ddldiv.SelectedItem.Text.Trim();
                objPT.AddedBy = LoginToken.LoginId;
                objPT.CompanyID = LoginToken.CompanyID;
                objPT.ActionType = EnumActionType.Insert;
                //if (ViewState["ID"] != null)
                //{
                //    objPT.ActionType = EnumActionType.Update;
                //    objPT.ID = Convert.ToInt32(ViewState["ID"].ToString());
                //}
                int result = objstdBO.CreatePTcertficate(objPT);
                if (result == 1 || result == 2)
                {
                    clearall();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    //ViewState["ID"] = null;
                    //btnsave.Text = "Add";
                }
               else if (result == 4)
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ProvisionalTransfer> lstclass = GetPTCertificates(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvCertificateDetails.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvCertificateDetails.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                GvCertificateDetails.PageIndex = index - 1;
                GvCertificateDetails.DataSource = lstclass;
                GvCertificateDetails.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvCertificateDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvCertificateDetails.DataSource = null;
                GvCertificateDetails.DataBind();
            }
        }      
        public List<ProvisionalTransfer> GetPTCertificates(int curIndex, int pagesize)
        {
            ProvisionalTransfer objPT = new ProvisionalTransfer();
            AddstudentBO objstdBO = new AddstudentBO();
            objPT.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objPT.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objPT.SectionID = Convert.ToInt32(ddlsection.SelectedValue == "" ? "0" : ddlsection.SelectedValue);
            objPT.RollNo = Convert.ToInt32(txtrollnos.Text == "" ? "0" : txtrollnos.Text);
            objPT.CertificateType = Convert.ToInt32(ddlcType.SelectedValue == "" ? "0" : ddlcType.SelectedValue);
            return objstdBO.SearchPTcertificate(objPT);
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
        protected void btncanceldeliv_Click(object sender, EventArgs e)
        {
            Response.Redirect("LowerClassPTcertificates.aspx", false);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void clearall()
        {
            txtrollnos.Text = "";
            //txtdescription.Text = "";
        }       
        protected void Gvcertificate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletes")
            {
                ProvisionalTransfer objstd = new ProvisionalTransfer();
                AddstudentBO objstdBO = new AddstudentBO();
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvCertificateDetails.Rows[i];
                Label ID = (Label)gr.Cells[0].FindControl("lblccID");

                objstd.ID = Convert.ToInt32(ID.Text);
                objstd.AcademicSessionID = LoginToken.AcademicSessionID;
                objstd.AddedBy = LoginToken.LoginId;
                int Result = objstdBO.DeletePTCertificateByID(objstd);
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
    }
}
