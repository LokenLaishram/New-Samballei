using Mobimp.Campusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Web.AppCode;
using System;
using Mobimp.Edusoft.Common.Logging;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Common.ExceptionHandler;
using ClosedXML.Excel;
using System.IO;
using Mobimp.Campusoft.Data.EduFeeUtility;
using System.Reflection;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class FeeTypeMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                divsearch.Visible = false;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlPaymentType, mstlookup.GetLookupsList(LookupNames.PaymentType));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                FeesData objfees = new FeesData();
                FeesTypesBO objtypes = new FeesTypesBO();
                objfees.FeeCode = txtFeeCode.Text.Trim() == "" ? "0" : txtFeeCode.Text.Trim();
                objfees.FeeName = txtFeeName.Text == "" ? "0" : txtFeeName.Text;
                objfees.PaymentID = Convert.ToInt32(ddlPaymentType.SelectedValue == "" ? "0" : ddlPaymentType.SelectedValue);
                objfees.PaymentName = ddlPaymentType.Text == "" ? "NA" : ddlPaymentType.Text;
                objfees.AddedBy = LoginToken.LoginId;
                objfees.UserId = LoginToken.UserLoginId;
                objfees.CompanyID = LoginToken.CompanyID;
                objfees.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue); 
                objfees.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objfees.ActionType = EnumActionType.Update;
                    objfees.ID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objtypes.UpdateFeeTypes(objfees);
                if (result == 1 || result == 2)
                {
                    //  clearall();
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        public List<FeesData> GetFeeDetails(int curIndex,int pagesize)
        {
            FeesData objfees = new FeesData();
            FeesTypesBO objFeeBO = new FeesTypesBO();
            objfees.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objfees.FeeCode = txtFeeCode.Text.Trim() == "" ? "" : txtFeeCode.Text.Trim();
            objfees.FeeName = txtFeeName.Text == "" ? "" : txtFeeName.Text.Trim();
            objfees.PaymentID = Convert.ToInt32(ddlPaymentType.SelectedValue  == "" ? "0" : ddlPaymentType.SelectedValue);
            objfees.PaymentName = ddlPaymentType.SelectedItem.Text == "" ? "0" : ddlPaymentType.SelectedItem.Text;
            objfees.ActionType = EnumActionType.Select;
            objfees.PageSize = pagesize;
            objfees.CurrentIndex = curIndex;
            return objFeeBO.SearchFeesDetails(objfees);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<FeesData> FeeTypes = GetFeeDetails(index, pagesize);
            if (FeeTypes.Count > 0)
            {
                GvFeeTypes.PageSize = pagesize;
                string record = FeeTypes[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + FeeTypes[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = FeeTypes[0].MaximumRows.ToString();
                //lbltotalmark.Text = FeeTypes[0].FullMark.ToString();
                //lblpassmark.Text = FeeTypes[0].PassMark.ToString();
                lblresult.Visible = true;
                //divsearch.Visible = true;
                GvFeeTypes.VirtualItemCount = FeeTypes[0].MaximumRows;//total item is required for custom paging
                GvFeeTypes.PageIndex = index - 1;
                GvFeeTypes.DataSource = FeeTypes;
                GvFeeTypes.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(FeeTypes);
                divsearch.Visible = true;
            }
            else
            {
                GvFeeTypes.DataSource = null;
                GvFeeTypes.DataBind();
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvFeeTypes.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvFeeTypes.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvFeeTypes.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvFeeTypes.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvFeeTypes.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvFeeTypes.UseAccessibleHeader = true;
            GvFeeTypes.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "FeeTypeList");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= FeeType.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        protected DataTable GetDatafromDatabase()
        {
            int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<FeesData> FeeTypeDetail = GetFeeDetails(1,size);
            List<FeeTypetoExcel> feetypetoexcel = new List<FeeTypetoExcel>();
            int i = 0;
           foreach (FeesData row in FeeTypeDetail)
            {
                FeeTypetoExcel EcxeclStd = new FeeTypetoExcel();
               // EcxeclStd.FeeCode = FeeTypeDetail[i].FeeCode;
               // EcxeclStd.FeeName = FeeTypeDetail[i].FeeName;
                feetypetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(feetypetoexcel);
            return dt;
        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void GvFeeTypes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvFeeTypes.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvFeeTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    FeesData objfeetypes = new FeesData();
                    FeesTypesBO objfeetypeBO = new FeesTypesBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvFeeTypes.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objfeetypes.ID = Convert.ToInt32(ID.Text);
                    List<FeesData> GetResult = objfeetypeBO.GetFeesDetailsByID(objfeetypes);
                    if (GetResult.Count > 0)
                    {
                        txtFeeCode.Text = Convert.ToString(GetResult[0].FeeCode);
                        txtFeeName.Text =Convert.ToString(GetResult[0].FeeName);
                        ddlPaymentType.SelectedValue = Convert.ToString(GetResult[0].PaymentID);
                        ViewState["ID"] = GetResult[0].ID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    FeesData objfeetype = new FeesData();
                    FeesTypesBO objfeetypeBO = new FeesTypesBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvFeeTypes.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objfeetype.ID = Convert.ToInt32(ID.Text);
                    objfeetype.ActionType = EnumActionType.Delete;
                    int Result = objfeetypeBO.DeleteFeesDetailsByID(objfeetype);
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
            divsearch.Visible = true;
        }
        private void clearall()
        {
            txtFeeCode.Text = "";
            txtFeeName.Text = "";
            ddlacademicsession.SelectedIndex = 0;
            ddlPaymentType.SelectedIndex = 0;
            btnsave.Text = "Add";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            bindgrid(1);
            divsearch.Visible = false;
        }
    }
}