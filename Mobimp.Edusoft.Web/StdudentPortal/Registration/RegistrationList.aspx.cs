using ClosedXML.Excel;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.StdudentPortal.Registration
{
    public partial class RegistrationList : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bindddl();
                bindgrid(1);
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsexs, mstlookup.GetLookupsList(LookupNames.Sex));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlcastes, mstlookup.GetLookupsList(LookupNames.Cast));
            Commonfunction.PopulateDdl(ddluser, mstlookup.GetLookupsList(LookupNames.TeachingStaff));

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StudentData> studentdetails = Getstudentdetails(index, pagesize);
            if (studentdetails.Count > 0)
            {

                GvstudentDetails.Visible = true;
                GvstudentDetails.PageSize = pagesize;
                string record = studentdetails[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + studentdetails[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = studentdetails[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvstudentDetails.VirtualItemCount = studentdetails[0].MaximumRows;//total item is required for custom paging
                GvstudentDetails.PageIndex = index - 1;
                GvstudentDetails.DataSource = studentdetails;
                GvstudentDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(studentdetails);
                divsearch.Visible = true;


            }
            else
            {
                GvstudentDetails.DataSource = null;
                GvstudentDetails.DataBind();
                GvstudentDetails.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;

            }
        }
        public List<StudentData> Getstudentdetails(int curIndex, int pagesize)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objstd.StudentID = Commonfunction.SemicolonSeparation_String_64(txtstudentanme.Text);
            objstd.Sfirstname = Convert.ToString(txtstudentanme.Text == "" ? "0" : txtstudentanme.Text);
            objstd.Datefrom = from;
            objstd.Dateto = To;
            objstd.IsAdmissionDone = Convert.ToInt32(ddl_admissionstatus.SelectedValue == "" ? "5" : ddl_admissionstatus.SelectedValue);
            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objstd.SexID = Convert.ToInt32(ddlsexs.SelectedValue == "" ? "0" : ddlsexs.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objstd.CastID = Convert.ToInt32(ddlcastes.SelectedValue == "" ? "0" : ddlcastes.SelectedValue);
            objstd.UserId = Convert.ToInt32(ddluser.SelectedValue == "" ? "0" : ddluser.SelectedValue);
            objstd.IsActiveALL = ddlstatus.SelectedValue;
            objstd.ActionType = EnumActionType.Select;
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.GetOnlineregistrationlist(objstd);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvstudentDetails.HeaderRow.Cells[0].Attributes["data-hide"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";

            //  Adds THEAD and TBODY to GridView.
            GvstudentDetails.UseAccessibleHeader = true;
            GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvstudentDetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
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
        protected void GvstudentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvstudentDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));

        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Student List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Class :" + (ddlclasses.SelectedIndex == 0 ? "All" : ddlclasses.SelectedItem.Text) + ".xlsx");
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
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StudentData> studentdetails = Getstudentdetails(1, pagesize);

            List<onlineregistrationtoExcel> listecelstd = new List<onlineregistrationtoExcel>();
            int i = 0;
            foreach (StudentData row in studentdetails)
            {
                onlineregistrationtoExcel EcxeclStd = new onlineregistrationtoExcel();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.ClassName = studentdetails[i].ClassName;
                EcxeclStd.FatherName = studentdetails[i].Gfirstname;
                EcxeclStd.FatherOcupation = studentdetails[i].Goccupation;
                EcxeclStd.RelationshipWithGuardian = studentdetails[i].Grelationship;
                EcxeclStd.Mothername = studentdetails[i].Mothername;
                EcxeclStd.MothersOccupation = studentdetails[i].MotherOccupation;
                EcxeclStd.ParentsIncome = studentdetails[i].Income;
                EcxeclStd.DOB = studentdetails[i].DOB.ToString("dd/MM/yyyy");
                EcxeclStd.Gender = studentdetails[i].SexName;
                EcxeclStd.Religion = studentdetails[i].Religion;
                EcxeclStd.Caste = studentdetails[i].CastName;
                EcxeclStd.MotherTongue = studentdetails[i].MotherTongue;
                EcxeclStd.BelongToBPL = studentdetails[i].BelongToBPLoptionName;
                EcxeclStd.Address = studentdetails[i].cAddress;
                EcxeclStd.PIN = studentdetails[i].cPIN;
                EcxeclStd.ContactNo = studentdetails[i].GmobileNo;
                EcxeclStd.BloodGroup = studentdetails[i].BloodGroup;
                listecelstd.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(listecelstd);
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
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        private void resetall()
        {
            txtstudentanme.Text = "";
            ddlacademicseesions.SelectedIndex = 0;
            ddlclasses.SelectedIndex = 0;
            GvstudentDetails.DataSource = null;
            GvstudentDetails.DataBind();
            GvstudentDetails.Visible = false;
            lblresult.Visible = false;
            ddlacademicseesions.SelectedIndex = 1;
            txtfrom.Text = "";
            txtto.Text = "";
            divsearch.Visible = false;

        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void GvstudentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvstudentDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Int64 StudentID = Convert.ToInt64(ID.Text);
                    Session["ID"] = StudentID;
                    Response.Redirect("~/StdudentPortal/Registration/OnlineRegistration.aspx", false);

                }
                if (e.CommandName == "Deletes")
                {
                    StudentData objstd = new StudentData();
                    AddstudentBO objstdBO = new AddstudentBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvstudentDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objstd.StudentID = Convert.ToInt64(ID.Text);
                    objstd.AcademicSessionID = LoginToken.AcademicSessionID;
                    objstd.ActionType = EnumActionType.Delete;
                    objstd.UserId = LoginToken.UserLoginId;
                    int Result = objstdBO.DeleteRegistrationDetailsByID(objstd);
                    if (Result == 1)
                    {
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                    bindresponsive();
                }

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                return;
            }

        }
        protected void txtstudentanme_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);

        }
        protected void ddlsexs_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlcastes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddl_admissionstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txtfrom_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddluser_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlacademicseesions_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            string burl = Request.Url.GetLeftPart(UriPartial.Authority);
            int StudentID = Commonfunction.SemicolonSeparation_String_32(txtstudentanme.Text);
            int SessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue);
            int Status = Convert.ToInt32(ddlstatus.SelectedValue);
            int SexID = Convert.ToInt32(ddlsexs.SelectedValue);
            int ClassID = Convert.ToInt32(ddlclasses.SelectedValue);
            string Datefrom = txtfrom.Text;
            string Dateto = txtto.Text;
            int CastID = Convert.ToInt32(ddlcastes.SelectedValue);
            int UserID = Convert.ToInt32(ddluser.SelectedValue);
            int AdmissionStatus = Convert.ToInt32(ddl_admissionstatus.SelectedValue);

            string param = "option=StudentList&StudentID=" + StudentID + "&SessionID=" + SessionID
                + "&Status=" + Status + "&SexID=" + SexID + "&ClassID=" + ClassID
                + "&Datefrom=" + Datefrom + "&Dateto=" + Dateto
                + "&CastID=" + CastID + "&UserID=" + UserID
                + "&AdmissionStatus=" + AdmissionStatus;

            Commonfunction common = new Commonfunction();
            string ecryptstring = common.Encrypt(param);
            string baseurl = burl+"/StdudentPortal/EnReports/ReportViewer.aspx?ID=" + ecryptstring;

            string fullURL = "window.open('" + baseurl + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}