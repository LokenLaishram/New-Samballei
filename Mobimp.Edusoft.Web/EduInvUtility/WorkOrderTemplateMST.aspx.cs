using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Data.EduInvUtility;
using Mobimp.Edusoft.BussinessProcess.EduInvUtility;

namespace Mobimp.Edusoft.Web.EduInvUtility
{
    public partial class WorkOrderTemplateMST : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlOrderTypeID, mstlookup.GetLookupsList(LookupNames.OrderType));
        }
        protected void ddlOrderTypeID_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlOrderTemplateID_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {

            if (ddlOrderTypeID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select order type.") + "')", true);
                return;
            }
            if (ddlOrderTemplateID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Template Name") + "')", true);
                return;
            }
            OrderTypeData objdata = new OrderTypeData();
            OrderTypeBO objOrderTypeBO = new OrderTypeBO();
            objdata.OrderTypeID = Convert.ToInt32(ddlOrderTypeID.Text == "" ? "0" : ddlOrderTypeID.Text);
            objdata.OrderTemplateID = Convert.ToInt32(ddlOrderTemplateID.Text == "" ? "0" : ddlOrderTemplateID.Text);
            objdata.IsActive = ddl_status.SelectedValue == "1" ? true : false;
            List<OrderTypeData> Result = objOrderTypeBO.SearchOrderTemplate(objdata);
            if (Result.Count > 0)
            {
                CKEditorHeader.Text = "";
                CKEditorFooter.Text = "";
                HideShow.Visible = true;
                Norecord.Visible = false;
                CKEditorHeader.Text = Result[0].TemplateHeader;
                CKEditorFooter.Text = Result[0].TemplateFooter;
            }
            else
            {
                HideShow.Visible = false;
                Norecord.Visible = false;
            }
        }
        protected void btnsave_onclick(object sender, EventArgs e)
        {
            try
            {
                //if (LoginToken.SaveEnable == 0)
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("saveenable") + "')", true);
                //    return;
                //}
                if (ddlOrderTypeID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select order type.") + "')", true);
                    return;
                }
                if (ddlOrderTemplateID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Template Name") + "')", true);
                    return;
                }
                OrderTypeData objdata = new OrderTypeData();
                OrderTypeBO objBO = new OrderTypeBO();
                objdata.OrderTypeID = Convert.ToInt32(ddlOrderTypeID.SelectedValue == "" ? "0" : ddlOrderTypeID.SelectedValue);
                objdata.OrderTemplateID = Convert.ToInt32(ddlOrderTemplateID.SelectedValue == "" ? "0" : ddlOrderTemplateID.SelectedValue);
                objdata.TemplateHeader = CKEditorHeader.Text == "" ? "" : CKEditorHeader.Text;             
                objdata.TemplateFooter = CKEditorFooter.Text == "" ? "" : CKEditorFooter.Text;
                string tempHeader = Server.HtmlDecode(CKEditorHeader.Text == "" ? "" : CKEditorHeader.Text);                
                string tempFooter = Server.HtmlDecode(CKEditorFooter.Text == "" ? "" : CKEditorFooter.Text);
                objdata.DecodeTemplateHeader = tempHeader;
                objdata.DecodeTemplateFooter = tempFooter;

                objdata.EmployeeID = LoginToken.EmployeeID;
                objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                int result = objBO.SaveOrderTemplate(objdata);
                if (result == 1)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);

                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnreset_onclick(object sender, EventArgs e)
        {
            ddlOrderTypeID.SelectedIndex = 0;
            ddlOrderTemplateID.SelectedIndex = 0;
            CKEditorHeader.Text = "";
            HideShow.Visible = false;
            Norecord.Visible = false;
        }
    }
}