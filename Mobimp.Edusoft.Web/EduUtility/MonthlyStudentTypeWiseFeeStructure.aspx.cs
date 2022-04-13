using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduUtility
{

    public partial class MonthlyStudentTypeWiseFeeStructure : BasePage
    {
        IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindddls();
            }
        }
        protected void Bindddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlfeetype, mstlookup.GetLookupsList(LookupNames.MonthlyFeeTypes));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddladmissiontype, mstlookup.GetLookupsList(LookupNames.Admissiontype));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<FeesData> lstPay = GetFeeDetails(index, pagesize);
            if (lstPay.Count > 0)
            {
                GvFeedetails.PageSize = pagesize;
                string record = lstPay.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstPay.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstPay.Count.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                btnupdate.Visible = true;
                GvFeedetails.VirtualItemCount = lstPay.Count;//total item is required for custom paging
                GvFeedetails.PageIndex = index - 1;
                GvFeedetails.DataSource = lstPay;
                GvFeedetails.DataBind();
                ds = ConvertToDataSet(lstPay);
                TableCell tableCell = GvFeedetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                divsearch.Visible = true;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvFeedetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvFeedetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvFeedetails.UseAccessibleHeader = true;
            GvFeedetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        public List<FeesData> GetFeeDetails(int curIndex, int pagesize)
        {
            FeesData objfees = new FeesData();
            FeeDetailBO objFeeBO = new FeeDetailBO();
            objfees.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objfees.FeeTypeID = Convert.ToInt32(ddlfeetype.SelectedValue == "" ? "0" : ddlfeetype.SelectedValue);
            objfees.AdmissionTypeID = Convert.ToInt32(ddladmissiontype.SelectedValue == "" ? "0" : ddladmissiontype.SelectedValue);
            objfees.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objfees.ActionType = EnumActionType.Select;
            objfees.PageSize = GvFeedetails.PageSize;
            objfees.CurrentIndex = curIndex;
            return objFeeBO.SearchMonthlyFeesDetails(objfees);
           
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlacademicsession.SelectedIndex = 1;
            ddladmissiontype.SelectedIndex = 0;
            ddlclass.SelectedIndex = 0;
            ddlfeetype.SelectedIndex = 0;
            btnupdate.Visible = false;
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            lblresult.Text = "";
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Fee details");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Class.xlsx");
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
            List<FeesData> FeeTypeDetail = GetFeeDetails(1, size);
            List<FeeTypeDatatoExcel> feetypetoexcel = new List<FeeTypeDatatoExcel>();
            int i = 0;
            foreach (FeesData row in FeeTypeDetail)
            {
                FeeTypeDatatoExcel EcxeclStd = new FeeTypeDatatoExcel();
                EcxeclStd.AdmissionType = FeeTypeDetail[i].AdmissionType;
                EcxeclStd.StudentType = FeeTypeDetail[i].StudentType;
                EcxeclStd.FeeType = FeeTypeDetail[i].FeeType;
                EcxeclStd.ExemptedAmount = FeeTypeDetail[i].ExemptedAmount;
                EcxeclStd.TotalFeeAmount = FeeTypeDetail[i].TotalFeeAmount;
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void GvFeedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvFeedetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvFeedetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //foreach (GridViewRow row in GvFeedetails.Rows)
            //{
            //    try
            //    {
            //        DropDownList ddladmissiontype = (DropDownList)GvFeedetails.Rows[row.RowIndex].Cells[3].FindControl("ddladmissiontype");
            //        MasterLookupBO objmstlookupBO = new MasterLookupBO();
            //        Commonfunction.PopulateDdl(ddladmissiontype, objmstlookupBO.GetLookupsList(LookupNames.Admissiontype));
            //        Label admissiontypeID = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lbladmissiontype");
            //        TextBox txtnetamount = (TextBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("txtnetamount");
            //        CheckBox ChkDue = (CheckBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("chkdueallowedstatus");
            //        TextBox DueAmt = (TextBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("txtdueamount");
            //        txtnetamount.Attributes["disabled"] = "disabled";
            //        if (admissiontypeID.Text != "0")
            //        {
            //            ddladmissiontype.Items.FindByValue(admissiontypeID.Text).Selected = true;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
            //    }
            //}
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<FeesData> ListfeeData = new List<FeesData>();
            FeesData objfeeData = new FeesData();
            FeeDetailBO objFeeBO = new FeeDetailBO();
            int index = 0;

            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvFeedetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label ID = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblID");
                    Label ClassID = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblclassID");
                    Label AdmissionTypeID = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lbladmissiontype");
                    Label FeetypeID = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblfeetypeID");
                    Label SessionID = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("sessionID");
                    Label StudentTypeID = (Label)GvFeedetails.Rows[index].Cells[0].FindControl("lblstudentypeID");
                    TextBox FeeAmount = (TextBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("txtfeeamount");
                    TextBox ExemptedAmount = (TextBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("txtbreakupamnt");
                    TextBox FineAmount = (TextBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("txtlatefine");
                    TextBox DueAmount = (TextBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("txtdueamount");
                    TextBox Finedate = (TextBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("txtfinedate");
                    CheckBox chkbox = (CheckBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("chkdueallowedstatus");
                    Label DueStatus = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lbldueallowed");
                    DateTime FineDate = Finedate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(Finedate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    FeesData Objfee = new FeesData();

                    Objfee.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    Objfee.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    Objfee.AdmissionTypeID = Convert.ToInt32(AdmissionTypeID.Text == "" ? "0" : AdmissionTypeID.Text);
                    Objfee.StudentTypeID = Convert.ToInt32(StudentTypeID.Text == "" ? "0" : StudentTypeID.Text);
                    Objfee.FeeAmount = Convert.ToDecimal(FeeAmount.Text == "" ? "0.0" : FeeAmount.Text);
                    Objfee.ExemptedAmount = Convert.ToDecimal(ExemptedAmount.Text == "" ? "0.0" : ExemptedAmount.Text);
                    Objfee.LateFine= Convert.ToDecimal(FineAmount.Text == "" ? "0.0" : FineAmount.Text);
                    if (chkbox.Checked==true)
                    {
                        Objfee.DueAllowed = true;
                    }
                    else
                    {
                        Objfee.DueAllowed = false;
                    }
                    Objfee.DueAmount = Convert.ToDecimal(DueAmount.Text == "" ? "0.0" : DueAmount.Text);
                    Objfee.FineDate = FineDate;
                    Objfee.AcademicSessionID = Convert.ToInt32(SessionID.Text == "" ? "0" : SessionID.Text);
                    Objfee.FeeTypeID = Convert.ToInt32(FeetypeID.Text == "" ? "0" : FeetypeID.Text);
                    ListfeeData.Add(Objfee);
                    index++;
                }

                objfeeData.xmlfeelist = XmlConvertor.FeeAmountListtoXML(ListfeeData).ToString();
                objfeeData.AddedBy = LoginToken.LoginId;
                objfeeData.CompanyID = LoginToken.CompanyID;

                int results = objFeeBO.UpdateBreakupFeesDetails(objfeeData);
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
    }
}