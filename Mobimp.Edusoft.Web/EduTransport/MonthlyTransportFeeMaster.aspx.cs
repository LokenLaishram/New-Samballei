using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.IO;
using Mobimp.Edusoft.Data.EduTransport;
using Mobimp.Edusoft.BussinessProcess.EduTransport;
using Mobimp.Edusoft.Common;
using System.Data;
using Mobimp.Campusoft.Data.EduTransport;
using System.Reflection;
using ClosedXML.Excel;
using Mobimp.Campusoft.BussinessProcess.EduTransport;

namespace Mobimp.Campusoft.Web.EduTransport
{
    public partial class MonthlyTransportFeeMaster : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetLookupsList(LookupNames.Route));
            Commonfunction.PopulateDdl(ddltransportstdtype, mstlookup.GetLookupsList(LookupNames.StudentTransportType));
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        protected void GvMonthlyTransportFee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvMonthlyTransportFee.Rows)
            {
                try
                {
                    CheckBox chkactivate = (CheckBox)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("chkactivate");
                    Label lblActivate = (Label)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("lblActivate");
                    if (lblActivate.Text == "1")
                    {
                        chkactivate.Checked = true;
                    }
                    else
                    {
                        chkactivate.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<TransportData> lstdata = new List<TransportData>();
            TransportData ObjData = new TransportData();
            TransportRegistrationBO objtransportBO = new TransportRegistrationBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvMonthlyTransportFee.Rows)
                {
                    TransportData ObjDetails = new TransportData();
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label lblStudentID = (Label)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("lblStudentID");
                    TextBox txtexemption = (TextBox)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("txtexemption");
                    Label lblnetamount = (Label)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("lblnetamount");
                    Label lblfeeamount = (Label)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("lblfeeamount");
                    CheckBox chkactivate = (CheckBox)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("chkactivate");
                    if (chkactivate.Checked == true)
                    {
                        ObjDetails.Activate = 1;
                    }
                    else
                    {
                        ObjDetails.Activate = 0;
                    }
                    ObjDetails.StudentID = Convert.ToInt32(lblStudentID.Text);
                    ObjDetails.NetAmount = Convert.ToInt32(lblnetamount.Text);
                    ObjDetails.Exemption = Convert.ToInt32(txtexemption.Text);
                    ObjDetails.FeeAmount = Convert.ToInt32(lblfeeamount.Text);
                    lstdata.Add(ObjDetails);
                    index++;
                }
                ObjData.XMLData = XmlConvertor.MonthlyTransportFeeMastertoXML(lstdata).ToString();
                ObjData.EmployeeID = LoginToken.EmployeeID;
                ObjData.AcademicSessionID = LoginToken.AcademicSessionID;

                int results = objtransportBO.UpdateMonthlyTransportFee(ObjData);
                if (results == 1)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(results == 1 ? "save" : "update") + "')", true);
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
        //protected void btnsave_Click(object sender, EventArgs e)
        //{
        //    VehicleData objtransport = new VehicleData();
        //    VehicleBO objtransportBO = new VehicleBO();
        //    try
        //    {
        //        objtransport.RouteID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
        //        objtransport.Descriptions = Convert.ToString(ddlrouteno.SelectedValue);
        //        objtransport.TransportType = Convert.ToInt32(ddltranporttype.SelectedValue == "" ? "0" : ddltranporttype.SelectedValue);
        //        objtransport.VehicleNo = txtvehicleno.Text.Trim();
        //        objtransport.DriverName = txtdriverName.Text.Trim();
        //        objtransport.ContactNo = txtcontactno.Text;
        //        objtransport.CareOf = txtCareOf.Text;
        //        objtransport.Address = txtAddress.Text.Trim();
        //        objtransport.Licence = txtlicence.Text.Trim();
        //        //objtransport.Photo = txtlicence.Text.Trim();
        //        objtransport.ActionType = EnumActionType.Insert;
        //        objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);

        //        if (ViewState["ID"] != null)
        //        {
        //            objtransport.ActionType = EnumActionType.Update;
        //            objtransport.ID = Convert.ToInt32(ViewState["ID"].ToString());

        //        }
        //        int result = objtransportBO.UpdateVehicleDetails(objtransport);

        //        if (result == 1 || result == 2)
        //        {
        //            clearall();

        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
        //            ViewState["ID"] = null;
        //            btnsave.Text = "Add";
        //        }
        //        if (result == 5)
        //        {
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
        //        }
        //        else
        //        {
        //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
        //        }
        //        bindgrid(1);
        //    }
        //    catch (Exception ex) //Exception in agent layer itself
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
        //    }
        //}
        protected void GvMonthlyTransportFee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    VehicleData objfees = new VehicleData();
                    VehicleBO objpayementBO = new VehicleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvMonthlyTransportFee.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objfees.ID = Convert.ToInt32(ID.Text);

                    List<VehicleData> GetResult = objpayementBO.GetVehicleDetailsByID(objfees);
                    if (GetResult.Count > 0)
                    {
                        ddlrouteno.SelectedItem.Text = GetResult[0].RouteID.ToString();
                        //ddltranporttype.SelectedValue = GetResult[0].TransportType.ToString();
                        //txtvehicleno.Text = GetResult[0].VehicleNo.ToString();
                        //txtdriverName.Text = GetResult[0].DriverName.ToString();
                        //txtcontactno.Text = GetResult[0].ContactNo.ToString();
                        //txtCareOf.Text = GetResult[0].CareOf.ToString();
                        //txtAddress.Text = GetResult[0].Address.ToString();
                        //txtlicence.Text = GetResult[0].Licence.ToString();
                        //ViewState["ID"] = GetResult[0].ID;
                        //btnsave.Text = "Update";
                        bindresponsive();
                    }
                    else
                    {
                        //txtvehicleno.Text = "";
                        //txtdriverName.Text = "";
                        //txtcontactno.Text = "";
                        //ddltranporttype.SelectedIndex = 0;
                        ViewState["ID"] = null;
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    VehicleData objfees = new VehicleData();
                    VehicleBO objpayementBO = new VehicleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvMonthlyTransportFee.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objfees.Remarks = txtremarks.Text;
                    }
                    objfees.ID = Convert.ToInt32(ID.Text);
                    objfees.ActionType = EnumActionType.Delete;
                    int Result = objpayementBO.DeleteVehicleDetailsByID(objfees);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else if (Result == 4)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Vihicle cannot be delete untill student are assign in this vihicle.") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                }
                if (e.CommandName == "ActivateDate")
                {
                    this.modalpopup_activatedate.Show();
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
            List<TransportData> lstMonthlyTransport = GetTransportfeedetails(index, pagesize);
            if (lstMonthlyTransport.Count > 0)
            {
                GvMonthlyTransportFee.PageSize = pagesize;
                string record = lstMonthlyTransport.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstMonthlyTransport.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstMonthlyTransport.Count.ToString();
                lblresult.Visible = true;
                //  btnupdate.Visible = false;
                GvMonthlyTransportFee.VirtualItemCount = lstMonthlyTransport[0].MaximumRows;//total item is required for custom paging
                GvMonthlyTransportFee.PageIndex = index - 1;
                GvMonthlyTransportFee.DataSource = lstMonthlyTransport;
                GvMonthlyTransportFee.DataBind();
                ds = ConvertToDataSet(lstMonthlyTransport);
                TableCell tableCell = GvMonthlyTransportFee.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvMonthlyTransportFee.DataSource = null;
                GvMonthlyTransportFee.DataBind();
            }
        }
        public List<TransportData> GetTransportfeedetails(int curIndex, int pagesize)
        {
            TransportData objtransport = new TransportData();
            TransportRegistrationBO objtransportBO = new TransportRegistrationBO();
            objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objtransport.TransportStudentTypeID = Convert.ToInt32(ddltransportstdtype.SelectedValue == "" ? "0" : ddltransportstdtype.SelectedValue);
            objtransport.RootID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
            objtransport.SubRootID = Convert.ToInt32(ddlsubroute.SelectedValue == "" ? "0" : ddlsubroute.SelectedValue);
            objtransport.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objtransport.PageSize = pagesize;
            objtransport.CurrentIndex = curIndex;
            return objtransportBO.SearchMonthlyTransportFee(objtransport);
        }

        //private void clearall()
        //{
        //    txtcontactno.Text = "";
        //    txtdriverName.Text = "";
        //    txtvehicleno.Text = "";
        //    ddlrouteno.SelectedIndex = 0;
        //    ddltranporttype.SelectedIndex = 0;
        //    GvMonthlyTransportFee.DataSource = null;
        //    GvMonthlyTransportFee.DataBind();
        //    GvMonthlyTransportFee.Visible = false;
        //    lblmessage.Visible = false;
        //}
        //protected void btncancel_Click(object sender, EventArgs e)
        //{
        //    ViewState["ID"] = null;
        //    clearall();
        //    GvMonthlyTransportFee.DataSource = null;
        //    GvMonthlyTransportFee.DataBind();
        //    GvMonthlyTransportFee.Visible = false;
        //    lblmessage.Visible = false;
        //    lblresult.Visible = false;  btnupdate.Visible = false;
        //    ddlrouteno.SelectedIndex = 0;
        //    ddltranporttype.SelectedIndex = 0;
        //    txtAddress.Text = "";   txtlicence.Text = ""; txtCareOf.Text = "";
        //}

        protected void bindresponsive()
        {
            //Responsive 
            GvMonthlyTransportFee.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvMonthlyTransportFee.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvMonthlyTransportFee.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvMonthlyTransportFee.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvMonthlyTransportFee.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvMonthlyTransportFee.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvMonthlyTransportFee.UseAccessibleHeader = true;
            GvMonthlyTransportFee.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvMonthlyTransportFee_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvMonthlyTransportFee.DataSource = sortedView;
                    GvMonthlyTransportFee.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvMonthlyTransportFee.HeaderRow.Cells[ColumnIndex];
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
        protected void GvMonthlyTransportFee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvMonthlyTransportFee.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
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
                wb.Worksheets.Add(dt, "Class List");
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
            List<TransportData> ClassDetail = GetTransportfeedetails(1, size);
            List<TransportData> classtoexcel = new List<TransportData>();
            int i = 0;
            //foreach (TransDataExcel row in ClassDetail)
            //{
            //    TransDataExcel EcxeclStd = new TransDataExcel();
            //    EcxeclStd.DriverName = ClassDetail[i].DriverName;
            //    EcxeclStd.Address = ClassDetail[i].Address;
            //    EcxeclStd.ContactNo = ClassDetail[i].ContactNo;
            //    EcxeclStd.TransportName = ClassDetail[i].TransportName;
            //    EcxeclStd.VehicleNo = ClassDetail[i].VehicleNo;
            //    EcxeclStd.Licence = ClassDetail[i].Licence;
            //    classtoexcel.Add(EcxeclStd);
            //    i++;
            //}
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(classtoexcel);
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

        protected void ddlrouteno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlrouteno.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlsubroute, objmstlookupBO.GetSubRootByRootID(Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue), Convert.ToInt32(ddltransportstdtype.SelectedValue == "" ? "0" : ddltransportstdtype.SelectedValue), Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
                bindgrid(1);
            }

        }
        protected void ddltransportstdtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlsubroute_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txtexemption_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            GridViewRow row = txt.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            Label lblfeeamount = (Label)GvMonthlyTransportFee.Rows[rowIndex].Cells[0].FindControl("lblfeeamount");
            Decimal feeamount = Convert.ToDecimal(lblfeeamount.Text);

            TextBox txtexemption = (TextBox)GvMonthlyTransportFee.Rows[rowIndex].Cells[0].FindControl("txtexemption");
            Decimal exemption = Convert.ToDecimal(txtexemption.Text);

            Label lblnetamount = (Label)GvMonthlyTransportFee.Rows[rowIndex].Cells[0].FindControl("lblnetamount");
            Decimal total = feeamount - exemption;

            lblnetamount.Text = total.ToString();
            //foreach (GridViewRow row in GvMonthlyTransportFee.Rows)
            //{
            //    try
            //    {

            //        Label lblfeeamount = (Label)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("lblfeeamount");
            //        TextBox txtexemption = (TextBox)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("txtexemption");
            //        Label lblnetamount = (Label)GvMonthlyTransportFee.Rows[row.RowIndex].Cells[0].FindControl("lblnetamount");
            //        string a = lblnetamount.Text;
            //        string b = txtexemption.Text;
            //        string c = lblnetamount.Text;
            //       // int netamount= Convert.ToInt32(lblfeeamount.Text) - Convert.ToInt32(txtexemption.Text);
            //       // lblnetamount.Text = netamount.ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
            //        lblresult.Text = ExceptionMessage.GetMessage(ex);
            //    }
            //}
        }
        protected void chkactivate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox txt = sender as CheckBox;
            GridViewRow row = txt.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            Label lblStudentID = (Label)GvMonthlyTransportFee.Rows[rowIndex].Cells[0].FindControl("lblStudentID");
            CheckBox chkactivate = (CheckBox)GvMonthlyTransportFee.Rows[rowIndex].Cells[0].FindControl("chkactivate");
            hdStudentID.Value = lblStudentID.Text;
            if (chkactivate.Checked == true)
            {
                hdActivation.Value = "1";
                btnsave.Text = "Activate";
                btnsave.CssClass = "btn btn-success cus_btn";
            }
            else
            {
                hdActivation.Value = "0";
                btnsave.Text = "Deactivate";
                btnsave.CssClass = "btn btn-danger cus_btn";
            }
            this.modalpopup_activatedate.Show();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            TransportData objData = new TransportData();
            TransportRegistrationBO objBO = new TransportRegistrationBO();
            objData.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objData.StudentID = Convert.ToInt32(hdStudentID.Value);
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime ActivateDate = txtactivatedate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtactivatedate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objData.ActivateDate = ActivateDate;
            objData.Activate = Convert.ToInt32(hdActivation.Value);
            int result = objBO.SaveActivationDate(objData);
            if (result == 1)
            {
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(Convert.ToInt32(hdActivation.Value) == 1 ? "activate" : "deactivate") + "')", true);
                }
            }
        }
    }
}