using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class AdmitCard : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlexam, mstlookup.GetLookupsList(LookupNames.ExamNames));
            ddlacademicseesions.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            //Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
            //ddlexam.SelectedIndex = 1;
        }
        
        //protected void btncancel_Click(object sender, EventArgs e)
        //{
        //    ddlclasses.SelectedIndex = 0;
        //    ddlexam.SelectedIndex = 0;
        //    lblmessage.Visible = false;
        //    GvExamdetails.DataSource = null;
        //    GvExamdetails.DataBind();
        //    GvExamdetails.Visible = false;
        //    btnupdate.Enabled = false;
        //    txtrollNo.Text = "";
        //    ddlsections.SelectedIndex = 0;
        //    ViewState["StudentID"] = null;
        //    ddlstatus.SelectedIndex = 1;
        //    txtworkingdays.Text = "";


        //}
    

    }
}