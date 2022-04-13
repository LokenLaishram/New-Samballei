using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class SchoolDetail : BasePage
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
            Commonfunction.PopulateDdl(ddlcountry, mstlookup.GetLookupsList(LookupNames.Country));
            Commonfunction.PopulateDdl(ddlstate, mstlookup.GetLookupsList(LookupNames.State));
            Commonfunction.PopulateDdl(ddldistrict, mstlookup.GetLookupsList(LookupNames.District));

        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlstate, objmstlookupBO.GetStatelistByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)));

        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            int stateID = Convert.ToInt32(ddlstate.SelectedValue);
            int CountryID = Convert.ToInt32(ddlcountry.SelectedValue);
            Commonfunction.PopulateDdl(ddldistrict, objmstlookupBO.GetDistrictlistByID(stateID, CountryID));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SchoolDetailData objschool = new SchoolDetailData();
                SchoolDetailBO objschoolBO = new SchoolDetailBO();
                string fileName = FileUploader.FileName.ToString();

                if (fileName == "")
                {
                    objschool.LogoLocation = null;
                    objschool.LogoLocationimage = null;
                }
                //if (!FileUploader.HasFile)
                //{
                //    Messagealert_.ShowMessage(lblmessage, "system", 0);
                //    return;
                //}
                else
                {
                    string path = getPath(fileName);
                    objschool.LogoLocation = path;

                    //imageuploader as bit image
                    int length = FileUploader.PostedFile.ContentLength;
                    //create a byte array to store the binary image data
                    byte[] imgbyte = new byte[length];
                    //store the currently selected file in memeory
                    HttpPostedFile img = FileUploader.PostedFile;
                    //set the binary data
                    img.InputStream.Read(imgbyte, 0, length);
                    objschool.LogoLocationimage = imgbyte;

                    if (path == "fail")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                        return;
                    }
                }
                //if (path == "exist")
                //{
                //    Messagealert_.ShowMessage(lblmessage, "system", 0);
                //    return;
                //}
                objschool.Code = txtcode.Text;
                objschool.SchoolName = txtschoolname.Text;
                objschool.SchoolAddress = txtaddress.Text;
                objschool.RecognitionNo = txtRecognitionNo.Text;
                objschool.Website = txtwebsite.Text;
                objschool.EmailID = txtemailID.Text;
                objschool.CountryID = Convert.ToInt32(ddlcountry.SelectedValue);
                objschool.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                objschool.DistrictID = Convert.ToInt32(ddldistrict.SelectedValue);
                objschool.PinNo = Convert.ToInt32(txtpin.Text);
                objschool.PhoneNo = txtphoneNo.Text;
                objschool.MobileNo = txtmobile.Text;
                objschool.AddedBy = LoginToken.LoginId;
                objschool.UserId = LoginToken.UserLoginId; ;
                objschool.CompanyID = LoginToken.CompanyID;
                objschool.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objschool.ActionType = EnumActionType.Update;
                    objschool.ID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objschoolBO.UpdateSchoolDetails(objschool);
                if (result == 1 || result == 2)
                {
                    clearall();
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    clearall();
                    GvSchoolDetails.DataSource = getSchooldetails(1, 10);
                    GvSchoolDetails.DataBind();
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

        protected void GvSchoolDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    SchoolDetailData objschool = new SchoolDetailData();
                    SchoolDetailBO objSchoolDetailBO = new SchoolDetailBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSchoolDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objschool.ID = Convert.ToInt32(ID.Text);
                    objschool.ActionType = EnumActionType.Select;
                    List<SchoolDetailData> GetResult = objSchoolDetailBO.GetSchoolDetailsByID(objschool);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtschoolname.Text = GetResult[0].SchoolName;
                        txtaddress.Text = GetResult[0].SchoolAddress;
                        txtRecognitionNo.Text = GetResult[0].RecognitionNo;
                        txtwebsite.Text = GetResult[0].Website;
                        txtemailID.Text = GetResult[0].EmailID;
                        txtmobile.Text = GetResult[0].MobileNo;
                        txtphoneNo.Text = GetResult[0].PhoneNo;
                        MasterLookupBO objmstlookupBO = new MasterLookupBO();
                        Commonfunction.PopulateDdl(ddlcountry, objmstlookupBO.GetLookupsList(LookupNames.Country));
                        ddlcountry.SelectedValue = GetResult[0].CountryID.ToString();
                        Commonfunction.PopulateDdl(ddlstate, objmstlookupBO.GetStatelistByCountryID(Convert.ToInt32(ddlcountry.SelectedValue)));
                        ddlstate.SelectedValue = GetResult[0].StateID.ToString();
                        int stateID = Convert.ToInt32(ddlstate.SelectedValue);
                        int CountryID = Convert.ToInt32(ddlcountry.SelectedValue);
                        Commonfunction.PopulateDdl(ddldistrict, objmstlookupBO.GetDistrictlistByID(stateID, CountryID));
                        ddldistrict.SelectedValue = GetResult[0].DistrictID.ToString();

                        txtpin.Text = GetResult[0].PinNo.ToString();
                        txtphoneNo.Text = GetResult[0].PhoneNo;
                        ViewState["ID"] = GetResult[0].ID;
                        imglogo.Src = GetResult[0].LogoLocation;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    SchoolDetailData objschool = new SchoolDetailData();
                    SchoolDetailBO objSchoolDetailBO = new SchoolDetailBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSchoolDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objschool.ID = Convert.ToInt16(ID.Text);
                    objschool.ActionType = EnumActionType.Delete;
                    int Result = objSchoolDetailBO.DeleteSchoolDetailsByID(objschool);
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SchoolDetailData> lstschool = getSchooldetails(index, pagesize);
            if (lstschool.Count > 0)
            {
                GvSchoolDetails.PageSize = pagesize;
                string record = lstschool[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstschool[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstschool[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvSchoolDetails.VirtualItemCount = lstschool[0].MaximumRows;//total item is required for custom paging
                GvSchoolDetails.PageIndex = index - 1;
                GvSchoolDetails.DataSource = lstschool;
                GvSchoolDetails.DataBind();
                ds = ConvertToDataSet(lstschool);
                TableCell tableCell = GvSchoolDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvSchoolDetails.DataSource = null;
                GvSchoolDetails.DataBind();
                divsearch.Visible = true;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvSchoolDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvSchoolDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSchoolDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvSchoolDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSchoolDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvSchoolDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";

            //GvSchoolDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvSchoolDetails.UseAccessibleHeader = true;
            GvSchoolDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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

        public List<SchoolDetailData> getSchooldetails(int curIndex, int pagesize)
        {
            SchoolDetailData objschool = new SchoolDetailData();
            SchoolDetailBO objSchoolDetailBO = new SchoolDetailBO();
            objschool.Code = txtcode.Text == "" ? null : txtcode.Text;
            objschool.SchoolName = txtschoolname.Text;
            objschool.ActionType = EnumActionType.Select;
            objschool.PageSize = pagesize;
            objschool.CurrentIndex = curIndex;
            return objSchoolDetailBO.SearchSchoolDetails(objschool);

        }
        private void clearall()
        {
            txtcode.Text = "";
            txtschoolname.Text = "";
            txtaddress.Text = "";
            txtemailID.Text = "";
            txtmobile.Text = "";
            txtphoneNo.Text = "";
            txtpin.Text = "";
            txtRecognitionNo.Text = "";
            txtwebsite.Text = "";
            Commonfunction.Insertzeroitemindex(ddlcountry);
            Commonfunction.Insertzeroitemindex(ddlstate);
            Commonfunction.Insertzeroitemindex(ddldistrict);
            GvSchoolDetails.DataSource = null;
            GvSchoolDetails.DataBind();
            divsearch.Visible = false;

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            btnsave.Text = "Add";
            bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "School details");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= SchoolDetails.xlsx");
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
            List<SchoolDetailData> SchoolDetail = getSchooldetails(1, size);
            List<SchoolDatatoExcel> schooltoexcel = new List<SchoolDatatoExcel>();
            int i = 0;
            foreach (SchoolDetailData row in SchoolDetail)
            {

                SchoolDatatoExcel EcxeclStd = new SchoolDatatoExcel();
                EcxeclStd.ID = SchoolDetail[i].ID;
                EcxeclStd.Code = SchoolDetail[i].Code;
                EcxeclStd.SchoolName = SchoolDetail[i].SchoolName;
                schooltoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(schooltoexcel);
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
        protected void GvSchoolDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvSchoolDetails.DataSource = sortedView;
                    GvSchoolDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvSchoolDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void GvSchoolDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GvSchoolDetails.DataSource = getSchooldetails(e.NewPageIndex);
            //GvSchoolDetails.DataBind();
            //bindresponsive();
            GvSchoolDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }


        //public DataSet ConvertToDataSet<T>(IList<T> list)
        //{
        //    DataSet dsFromDtStru = new DataSet();
        //    DataTable table = new DataTable();
        //    PropertyInfo[] properties = typeof(T).GetProperties();
        //    foreach (PropertyInfo prop in properties)
        //    {
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //    }
        //    foreach (T item in list)
        //    {
        //        DataRow row = table.NewRow();
        //        foreach (PropertyInfo prop in properties)
        //        {
        //            row[prop.Name] = prop.GetValue(item);
        //        }
        //        table.Rows.Add(row);
        //    }
        //    dsFromDtStru.Tables.Add(table);
        //    return dsFromDtStru;
        //}
        //public SortDirection dir
        //{
        //    get
        //    {
        //        if (ViewState["dirState"] == null)
        //        {
        //            ViewState["dirState"] = SortDirection.Ascending;
        //        }
        //        return (SortDirection)ViewState["dirState"];
        //    }
        //    set
        //    {
        //        ViewState["dirState"] = value;
        //    }
        //}
        #region Save document in dictory and get back it path
        protected string getPath(string fileName)
        {
            string path = "";
            fileName = txtcode.Text.Trim() + "_" + fileName;
            try
            {
                if (Directory.Exists(Request.PhysicalApplicationPath + @"EduLogo/") == false)
                    Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduLogo/");

                //if (File.Exists(Request.PhysicalApplicationPath + @"EduLogo/" + fileName))
                //    return "exist";

                FileUploader.SaveAs(Request.PhysicalApplicationPath + @"EduLogo/" + fileName);
                path = @"EduLogo/" + fileName;
            }
            catch
            {
                return "fail";
            }

            return path;
        }
        #endregion
        #region Delete Uploaded document in dictory if the save if failed
        void DeleteUploadedFile(string fileName)
        {
            try
            {
                if (File.Exists(Request.PhysicalApplicationPath + fileName))
                    File.Delete(Request.PhysicalApplicationPath + fileName);
            }
            catch
            {

            }
        }
        #endregion

    }
}