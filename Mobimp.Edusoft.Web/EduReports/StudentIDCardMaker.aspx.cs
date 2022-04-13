using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduStudent;

namespace Mobimp.Campusoft.Web.EduReports
{
    public partial class StudentIDCardMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddl();
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(ddlSectionID);
        }
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClassID.SelectedIndex > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue)));
            }
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue)));
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlClassID.SelectedIndex = 0;
            ddlSectionID.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddlSectionID);
            txtRollNo.Text = "";
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            StudentData objSTD = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
        }

        protected void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = 0;
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            List<StudentData> stdetails = objstdBO.GetstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                //txtStudentID.Text = Convert.ToString(stdetails[0].StudentID);
                ddlClassID.SelectedValue = Convert.ToString(stdetails[0].ClassID);
            }
            else
            {
                //txtStudentID.Text = "";
                ddlClassID.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is not found.") + "')", true);
                //Messagealert_.ShowMessage(lblMessage, "This Student is not found.", 0);
                return;
            }
        }
    }
}