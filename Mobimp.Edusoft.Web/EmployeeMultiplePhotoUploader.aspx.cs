using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System.IO;

namespace Mobimp.EduUtility.Web
{
    public partial class EmployeeMultiplePhotoUploader : System.Web.UI.Page
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

            Commonfunction.PopulateDdl(ddlstfftypes, mstlookup.GetLookupsList(LookupNames.StaffType));
            Commonfunction.PopulateDdl(ddlempcategories, mstlookup.GetLookupsList(LookupNames.StaffCategory));

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<EmployeeData> lstclass = GetEmployeedetails(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvemployeeList.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvemployeeList.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                GvemployeeList.PageIndex = index - 1;
                GvemployeeList.DataSource = lstclass;
                GvemployeeList.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvemployeeList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                lblresult.Visible = false;
                GvemployeeList.DataSource = null;
                GvemployeeList.DataBind();
            }
        }      
        public List<EmployeeData> GetEmployeedetails(int curIndex, int pagesize)
        {
            EmployeeData objemp = new EmployeeData();
            EmployeeBO objempBO = new EmployeeBO();
            objemp.EmployeeNo = txtemployeedID.Text == "" ? null : txtemployeedID.Text;
            objemp.StaffTypeID = Convert.ToInt32(ddlstfftypes.SelectedValue == "" ? "0" : ddlstfftypes.SelectedValue);
            objemp.EmployeeCatgeroyID = Convert.ToInt32(ddlempcategories.SelectedValue == "" ? "0" : ddlempcategories.SelectedValue);
            objemp.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            objemp.ActionType = EnumActionType.Select;
            return objempBO.SearchEmployeePhoto(objemp);
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
            GvemployeeList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvemployeeList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvemployeeList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvemployeeList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvemployeeList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvemployeeList.UseAccessibleHeader = true;
            GvemployeeList.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;            
            Response.Redirect("EmployeeMultiplePhotoUploader.aspx");
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }     
        protected void GvemployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {          

            try
            {
                EmployeeData objemp = new EmployeeData();
                EmployeeBO objempBO = new EmployeeBO();
                if (e.CommandName == "Upload")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvemployeeList.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");

                    FileUpload Emplphotouploader = (FileUpload)gr.Cells[2].FindControl("EmpPhotoUploader");
                    FileUpload signaouploader = (FileUpload)gr.Cells[3].FindControl("signaouploader");

                    string fileName = signaouploader.FileName.ToString();
                    string fileName1 = Emplphotouploader.FileName.ToString();
                    if (fileName != "" || fileName1 != "")
                    {

                        if (Directory.Exists(Request.PhysicalApplicationPath + @"EduDigiSign/") == false)
                            Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduDigiSign/");

                        if (File.Exists(Request.PhysicalApplicationPath + @"EduDigiSign/" + fileName))
                        {
                            File.Delete(Request.PhysicalApplicationPath + @"EduDigiSign/" + fileName);
                            // return "exist";
                        }

                        signaouploader.SaveAs(Request.PhysicalApplicationPath + @"EduDigiSign/" + fileName);
                        string path = @"EduDigiSign/" + fileName;

                        objemp.DigitalSignatureLocation = path;
                        //imageuploader as bit image
                        int length = signaouploader.PostedFile.ContentLength;
                        //create a byte array to store the binary image data
                        byte[] imgbyte = new byte[length];
                        //store the currently selected file in memeory
                        HttpPostedFile img = signaouploader.PostedFile;
                        //set the binary data
                        img.InputStream.Read(imgbyte, 0, length);
                        objemp.DigitalSignatureImage = imgbyte;


                        if (Directory.Exists(Request.PhysicalApplicationPath + @"EduEmpPhoto/") == false)
                            Directory.CreateDirectory(Request.PhysicalApplicationPath + @"EduEmpPhoto/");

                        if (File.Exists(Request.PhysicalApplicationPath + @"EduEmpPhoto/" + fileName1))
                        {
                            File.Delete(Request.PhysicalApplicationPath + @"EduEmpPhoto/" + fileName1);
                            // return "exist";
                        }
                        Emplphotouploader.SaveAs(Request.PhysicalApplicationPath + @"EduEmpPhoto/" + fileName1);
                        string path1 = @"EduEmpPhoto/" + fileName1;

                        objemp.EmployeePhotoLocation = path1;


                        //imageuploader as bit image
                        int length1 = Emplphotouploader.PostedFile.ContentLength;
                        //create a byte array to store the binary image data
                        byte[] imgbyte1 = new byte[length1];
                        //store the currently selected file in memeory
                        HttpPostedFile img1 = Emplphotouploader.PostedFile;
                        //set the binary data
                        img1.InputStream.Read(imgbyte1, 0, length1);
                        objemp.EmployeePhotoImage = imgbyte1;

                        objemp.EmployeeID = Convert.ToInt64(ID.Text);
                        int results = objempBO.UpLoadEmployeePhoto(objemp);
                        if (results == 1)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                            bindgrid(1);

                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Error") + "')", true);
                        }


                    }

                    //else
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Select Photo") + "')", true);
                    //}
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);

            }

        }
        protected void GvemployeeDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvemployeeList.DataSource = sortedView;
                    GvemployeeList.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvemployeeList.HeaderRow.Cells[ColumnIndex];
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

        protected void ddlempcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void ddlstfftypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}