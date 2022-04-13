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
using System.Reflection;
using ClosedXML.Excel;

namespace Mobimp.Campusoft.Web.EduTransport
{
    public partial class VehicleManager : BasePage
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
            Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetRoutesByAcademicID(Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
            //Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetLookupsList(LookupNames.Route));
            Commonfunction.PopulateDdl(ddltranporttype, mstlookup.GetLookupsList(LookupNames.TransportVehicleType));
        }
        protected void ddlacademicsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlacademicsession.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlrouteno, mstlookup.GetRoutesByAcademicID(Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue)));
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlrouteno);
            }
            bindgrid(1);            
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        protected string getDigitalPath(string fileName)
        {
            string path = "";
            // fileName = txtempname.Text.Trim() + "_" + fileName;
            try
            {
                if (Directory.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/") == false)
                    Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduStudentPhoto/");

                if (File.Exists(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName))
                {
                    File.Delete(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                    // return "exist";
                }
               // driverphotouploader.SaveAs(Request.PhysicalApplicationPath + @"EduStudentPhoto/" + fileName);
                path = @"EduStudentPhoto/" + fileName;
            }
            catch
            {
                return "fail";
            }
            return path;
        }
        protected void GvTransport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvTransport.Rows)
            {
                try
                {
                    Label DriverID = (Label)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    Label uploadstatus = (Label)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("lbluploadstatus");
                    CheckBox chkstatus = (CheckBox)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("chkstatus");
                    CheckBox chkupload = (CheckBox)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("chkuploadstatus");

                    string fileName = DriverID.Text.ToString().Trim() + ".jpg";
                    string path = GlobalConstant.DriverPhoto;

                    if (File.Exists(Path.Combine(path, fileName)) == true)
                    {
                        chkstatus.Checked = true;
                    }
                    else
                    {
                        chkstatus.Checked = false;
                    }

                    if (uploadstatus.Text == "True")
                    {
                        chkupload.Checked = true;
                    }
                    else
                    {
                        chkupload.Checked = false;
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
            VehicleData objtransport = new VehicleData();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvTransport.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label DriverID = (Label)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    CheckBox chkstatus = (CheckBox)GvTransport.Rows[row.RowIndex].Cells[0].FindControl("chkstatus");
                    VehicleData ObjDetails = new VehicleData();
                    VehicleBO objtransportBO = new VehicleBO();

                    string fileName = DriverID.Text.ToString().Trim() + ".jpg";
                    if (chkstatus.Checked)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(GlobalConstant.DriverPhoto + "/" + fileName);
                        Byte[] image = imageToByteArray(img);
                        ObjDetails.Driverphoto = image;
                        ObjDetails.IsPhotoUploaded = true;
                    }
                    else
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/EduImages/EmpDummyPh.png"));
                        Byte[] image = imageToByteArray(img);
                        ObjDetails.Driverphoto = image;
                        ObjDetails.IsPhotoUploaded = false;
                    }
                    ObjDetails.ID = Convert.ToInt32(DriverID.Text);
                    ObjDetails.AddedBy = LoginToken.LoginId;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;

                    int results = objtransportBO.UpLoadDriverPhoto(ObjDetails);
                    if (results == 1)
                    {
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(results == 1 ? "save" : "update") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            VehicleData objtransport = new VehicleData();
            VehicleBO objtransportBO = new VehicleBO();
            try
            {
                objtransport.RouteID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
                objtransport.TransportType = Convert.ToInt32(ddltranporttype.SelectedValue == "" ? "0" : ddltranporttype.SelectedValue);
                objtransport.VehicleNo = txtvehicleno.Text.Trim();
                objtransport.DriverName = txtdriverName.Text.Trim();
                objtransport.ContactNo = txtcontactno.Text;
                objtransport.CareOf = txtCareOf.Text;
                objtransport.Address = txtAddress.Text.Trim();
                objtransport.Licence = txtlicence.Text.Trim();
                //objtransport.Photo = txtlicence.Text.Trim();
                objtransport.ActionType = EnumActionType.Insert;
                objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);

                if (ViewState["ID"] != null)
                {
                    objtransport.ActionType = EnumActionType.Update;
                    objtransport.ID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objtransportBO.UpdateVehicleDetails(objtransport);

                if (result == 1 || result == 2)
                {
                    //clearall();
                    bindgrid(1);
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

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvTransport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    VehicleData objfees = new VehicleData();
                    VehicleBO objpayementBO = new VehicleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvTransport.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objfees.ID = Convert.ToInt32(ID.Text);

                    List<VehicleData> GetResult = objpayementBO.GetVehicleDetailsByID(objfees);
                    if (GetResult.Count > 0)
                    {
                        ddlacademicsession.SelectedValue = GetResult[0].AcademicSessionID.ToString();
                        ddlrouteno.SelectedValue = GetResult[0].RouteID.ToString();
                        ddltranporttype.SelectedValue = GetResult[0].TransportType.ToString();
                        txtvehicleno.Text = GetResult[0].VehicleNo.ToString();
                        txtdriverName.Text = GetResult[0].DriverName.ToString();
                        txtcontactno.Text = GetResult[0].ContactNo.ToString();
                        txtCareOf.Text = GetResult[0].CareOf.ToString();
                        txtAddress.Text = GetResult[0].Address.ToString();
                        txtlicence.Text = GetResult[0].Licence.ToString();
                        ViewState["ID"] = GetResult[0].ID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                    else
                    {
                        ddlrouteno.SelectedIndex = 0;
                        txtvehicleno.Text = "";
                        txtdriverName.Text = "";
                        txtcontactno.Text = "";
                        ddltranporttype.SelectedIndex = 0;
                        ViewState["ID"] = null;
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    VehicleData objfees = new VehicleData();
                    VehicleBO objpayementBO = new VehicleBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvTransport.Rows[i];
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
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);

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
            GvTransport.PageSize = pagesize;
            List<VehicleData> lstvehi = GetTransportfeedetails(index, pagesize);
            if (lstvehi.Count > 0)
            {
                string record = lstvehi[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstvehi[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstvehi[0].MaximumRows.ToString();
                lblresult.Visible = true;
                btnupdate.Visible = false;
                GvTransport.VirtualItemCount = lstvehi[0].MaximumRows;//total item is required for custom paging
                GvTransport.PageIndex = index - 1;
                GvTransport.DataSource = lstvehi;
                GvTransport.DataBind();
                ds = ConvertToDataSet(lstvehi);
                TableCell tableCell = GvTransport.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                btnsave.Text = "Add";
            }
            else
            {
                lblresult.Visible = false;
                GvTransport.DataSource = null;
                GvTransport.DataBind();
            }
        }
        public List<VehicleData> GetTransportfeedetails(int curIndex, int pagesize)
        {
            VehicleData objtransport = new VehicleData();
            VehicleBO objtransportBO = new VehicleBO();
            objtransport.RouteID = Convert.ToInt32(ddlrouteno.SelectedValue == "" ? "0" : ddlrouteno.SelectedValue);
            objtransport.TransportType = Convert.ToInt32(ddltranporttype.SelectedValue == "" ? "0" : ddltranporttype.SelectedValue);
            objtransport.VehicleNo = txtvehicleno.Text.Trim();
            objtransport.DriverName = txtdriverName.Text.Trim();
            objtransport.ContactNo = txtcontactno.Text.Trim();
            objtransport.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objtransport.IsActive = Convert.ToBoolean(ddlstatus.SelectedValue == "1" ? true : false);
            objtransport.PageSize = pagesize;
            objtransport.CurrentIndex = curIndex;
            return objtransportBO.GetVehicledetails(objtransport);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlrouteno.SelectedIndex = 0;
            ViewState["ID"] = null;
            txtcontactno.Text = "";
            txtdriverName.Text = "";
            txtvehicleno.Text = "";
            txtCareOf.Text = "";
            txtAddress.Text = "";
            txtlicence.Text = "";
            ddltranporttype.SelectedIndex = 0;
            lblmessage.Visible = false;
            bindgrid(1);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvTransport.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvTransport.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvTransport.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvTransport.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvTransport.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvTransport.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvTransport.UseAccessibleHeader = true;
            GvTransport.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvTransport_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvTransport.DataSource = sortedView;
                    GvTransport.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvTransport.HeaderRow.Cells[ColumnIndex];
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


        protected void GvTransport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTransport.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Vehicle List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Vehicle.xlsx");
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
            List<VehicleData> ClassDetail = GetTransportfeedetails(1, size);
            List<VehicleDatatoExcel> classtoexcel = new List<VehicleDatatoExcel>();
            int i = 0;
            foreach (VehicleData row in ClassDetail)
            {
                VehicleDatatoExcel EcxeclStd = new VehicleDatatoExcel();
                EcxeclStd.DriverName = ClassDetail[i].DriverName;
                EcxeclStd.Address = ClassDetail[i].Address;
                EcxeclStd.ContactNo = ClassDetail[i].ContactNo;
                EcxeclStd.TransportName = ClassDetail[i].TransportName;
                EcxeclStd.VehicleNo = ClassDetail[i].VehicleNo;
                EcxeclStd.Licence = ClassDetail[i].Licence;
                classtoexcel.Add(EcxeclStd);
                i++;
            }
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
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}