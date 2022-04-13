using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class OnlineresultManager : BasePage
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
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddl_class, mstlookup.GetLookupsList(LookupNames.Class));

        }
        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindresults(0);
        }
        private void bindresults(int index)
        {
            if (ddlacademicsession.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("session") + "')", true);
                return;
            }
            if (ddl_class.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Class") + "')", true);
                return;
            }
            List<OnlineExamresultData> examlist = Getexamresltlist(index);
            if (examlist.Count > 0)
            {
                Gv_examlist.DataSource = examlist;
                Gv_examlist.DataBind();
                btn_update.Visible = true;
            }
            else
            {
                Gv_examlist.DataSource = null;
                Gv_examlist.DataBind();
                btn_update.Visible = false;
            }
        }
        public List<OnlineExamresultData> Getexamresltlist(int curIndex)
        {
            OnlineExamresultData objexam = new OnlineExamresultData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            return objexamBO.GetonlineexamResults(objexam);
        }
        protected void Gv_resultlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_excludestatus = (Label)e.Row.FindControl("lbl_exclude_status");
                Label lbl_publlishstatus = (Label)e.Row.FindControl("lbl_publish_status");
                Label lbl_publishon = (Label)e.Row.FindControl("lbl_publishedon");

                CheckBox chk_exclude = (CheckBox)e.Row.FindControl("chk_dafulter");
                CheckBox chk_published = (CheckBox)e.Row.FindControl("chk_publish");
                if (lbl_excludestatus.Text == "1")
                {
                    chk_exclude.Checked = true;
                }
                if (lbl_publlishstatus.Text == "1")
                {
                    chk_published.Checked = true;
                    lbl_publishon.Visible = true;
                }
                if (lbl_publlishstatus.Text == "0")
                {
                    lbl_publishon.Visible = false;
                }
            }
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            int index = 0;
            int publlishcount = 0;
            try
            {
                List<OnlineExamresultData> lstexamdata = new List<OnlineExamresultData>();
                OnlineExamresultData objexam = new OnlineExamresultData();
                ExamTypeBO objexamBO = new ExamTypeBO();
                // get all the record from the gridview
                foreach (GridViewRow row in Gv_examlist.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ID = (Label)Gv_examlist.Rows[index].Cells[0].FindControl("lblID");
                    Label Examid = (Label)Gv_examlist.Rows[index].Cells[0].FindControl("lbl_examID");
                    Label Classid = (Label)Gv_examlist.Rows[index].Cells[0].FindControl("lbl_classid");

                    CheckBox chk_publis = (CheckBox)Gv_examlist.Rows[index].Cells[0].FindControl("chk_publish");
                    CheckBox chk_exlude = (CheckBox)Gv_examlist.Rows[index].Cells[0].FindControl("chk_dafulter");

                    OnlineExamresultData objexamdata = new OnlineExamresultData();
                    objexamdata.ClassID = Convert.ToInt32(Classid.Text == "" ? "0" : Classid.Text);
                    objexamdata.ExamID = Convert.ToInt32(Examid.Text == "" ? "0" : Examid.Text);
                    objexamdata.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                    objexamdata.Ispublished = chk_publis.Checked ? 1 : 0;
                    objexamdata.Excludedefaulter = chk_exlude.Checked ? 1 : 0;
                    objexamdata.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                    if (chk_publis.Checked)
                    {
                        publlishcount = publlishcount + 1;
                    }

                    lstexamdata.Add(objexamdata);
                    index++;
                }
                objexam.XMLData = XmlConvertor.onlineresulttoXML(lstexamdata).ToString();
                objexam.EmployeeID = LoginToken.EmployeeID;

     
                int results = objexamBO.updateonlineexammanager(objexam);
                if (results == 1)
                {
                    bindresults(0);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
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

        protected void ddlacademicsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindresults(0);
        }
    }
}