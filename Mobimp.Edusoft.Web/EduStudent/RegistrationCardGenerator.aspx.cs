using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;

namespace Mobimp.Campusoft.Web.EduStudent
{
    public partial class RegistrationCardGenerator : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddls();
            }
        }
        protected void Ddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlsections, mstlookup.GetLookupsList(LookupNames.Sectionlist));
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            btnupdate.Enabled = false;
            Commonfunction.PopulateDdl(ddlcategorys, mstlookup.GetLookupsList(LookupNames.StudentCategory));
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetempNames(string prefixText, int count, string contextKey)
        {
            StudentData objemp = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objemp.StudentName = prefixText;
            getResult = objempBO.GetStudentNames(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentName.ToString());
            }
            return list;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Getfedetailist();
            lblmesagestudentlist.Visible = false;
        }
        protected void Getfedetailist()
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();

            objstd.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objstd.RollNo = Convert.ToInt32(txtrollno.Text == "" ? "0" : txtrollno.Text);
            objstd.StudentCategory = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);

            List<StudentData> result = objstdBO.GetStudentListRegd(objstd);
            if (result.Count > 0)
            {
                Gvstudenlist.DataSource = result;
                Gvstudenlist.DataBind();
                Gvstudenlist.Visible = true;
                btnupdate.Enabled = true;
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lblresult.CssClass = "MsgSuccess";
                lblresult.Visible = true;
            }
            else
            {
                Gvstudenlist.DataSource = null;
                Gvstudenlist.DataBind();
                Gvstudenlist.Visible = true;
                btnupdate.Enabled = false;
               ;
                lblresult.CssClass = "Message";
                lblresult.Visible = true;
            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        private void resetall()
        {
            ddlclasses.SelectedIndex = 0;
            ddlsections.SelectedIndex = 0;
            Gvstudenlist.DataSource = null;
            Gvstudenlist.DataBind();
            Gvstudenlist.Visible = false;
            lblresult.Visible = false;
            ddlcategorys.SelectedIndex = 0;
            // lbltotleave.Text = "0";
            lblmesagestudentlist.Visible = false;
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<StudentData> lstattendance = new List<StudentData>();
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in Gvstudenlist.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    Label StudentID = (Label)Gvstudenlist.Rows[index].Cells[1].FindControl("lblID");
                    Label rollno = (Label)Gvstudenlist.Rows[index].Cells[1].FindControl("lblrollno");
                    TextBox txtregdNo = (TextBox)Gvstudenlist.Rows[index].Cells[1].FindControl("txtregdNo");

                    StudentData ObjDetails = new StudentData();

                    ObjDetails.StudentID = Convert.ToInt64(StudentID.Text == "" ? "0" : StudentID.Text);
                    ObjDetails.RollNo = Convert.ToInt32(rollno.Text == "" ? "0" : rollno.Text);
                    ObjDetails.RegdNo = txtregdNo.Text == "" ? "0" : txtregdNo.Text;

                    lstattendance.Add(ObjDetails);
                    index++;

                }
                objstd.XmlStudentlist = XmlConvertor.RegdlisttoXML(lstattendance).ToString();
                objstd.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objstd.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
                objstd.StudentCategory = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
                objstd.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                int results = objstdBO.UpdateRegdDetails(objstd);
                if (results == 1 || results == 2)
                {
                    Getfedetailist();
                    btnupdate.Enabled = false;
                    Messagealert_.ShowMessage(lblmesagestudentlist, results == 1 ? "save" : "update", 1);

                }
                else
                {
                    btnupdate.Enabled = true;
                    Messagealert_.ShowMessage(lblmesagestudentlist, "Error", 0);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblresult.Text = ExceptionMessage.GetMessage(ex);
                lblresult.Visible = true;
                lblresult.CssClass = "Message";
            }
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(LoginToken.AcademicSessionID)));
        }
        protected void Gvstudenlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in Gvstudenlist.Rows)
            {
                try
                {
                    Label AttenedanceID = (Label)Gvstudenlist.Rows[row.RowIndex].Cells[0].FindControl("lblattendanceID");
                    DropDownList ddlattendance = (DropDownList)Gvstudenlist.Rows[row.RowIndex].Cells[6].FindControl("ddlattendance");
                    if (AttenedanceID.Text != "0")
                    {
                        ddlattendance.Items.FindByValue(AttenedanceID.Text).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            lblresult.Visible = false;
            btnupdate.Enabled = false;
        }

        protected void ddlcategorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlsections.SelectedIndex = 0;
        }
    }
}