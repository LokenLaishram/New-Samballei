using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class ClassXHSLCdetailentry : System.Web.UI.Page
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
            Commonfunction.PopulateDdl(ddlcategory, mstlookup.GetLookupsList(LookupNames.StudentCategory));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlsections.SelectedIndex = 0;
            txtrollNo.Text = "";
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }
    }
}