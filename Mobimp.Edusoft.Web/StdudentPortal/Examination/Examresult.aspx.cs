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

namespace Mobimp.Campusoft.Web.StdudentPortal.Examination
{
    public partial class Examresult : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                Getexamresltlist(0);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            txtstddetail.Attributes["disabled"] = "disabled";

        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_result.HeaderRow.Cells[0].Attributes["data-hide"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            Gv_result.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_result.UseAccessibleHeader = true;
            Gv_result.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = Gv_result.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }

        public void Getexamresltlist(int curIndex)
        {
            OnlineExamresultData objexam = new OnlineExamresultData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            objexam.StudentID = LoginToken.EmployeeID;// EmployeeID act as StudentID
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            List<OnlineExamresultData> result = objexamBO.GetgetexamresultbyStudentID(objexam);
            if (result.Count > 0)
            {
                txtstddetail.Text = result[0].StudentName.ToString();
                if (result[0].StudentID.ToString() == "0")
                {
                    Gv_result.DataSource = null;
                    Gv_result.DataBind();
                }
                else
                {
                    Gv_result.DataSource = result;
                    Gv_result.DataBind();

                }

            }
            else
            {
                Gv_result.DataSource = null;
                Gv_result.DataBind();
            }
        }

        protected void ddlacademicsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getexamresltlist(0);
        }
        protected void Gv_result_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label status = e.Row.FindControl("lbl_status") as Label;
                    Label result = e.Row.FindControl("lbl_result") as Label;
                    Label duestatus = e.Row.FindControl("lbl_duestatus") as Label;
                    Label excludestatus = e.Row.FindControl("lbl_excludestatus") as Label;
                    if (status.Text == "1")
                    {
                        result.Text = "Declared";
                        e.Row.Cells[2].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
            }

        }
        string option;
        string param;
        protected void Gv_result_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Print")
                {
                    int j = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_result.Rows[j];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Label Student = (Label)gr.Cells[0].FindControl("lbl_studentID");
                    Label examid = (Label)gr.Cells[0].FindControl("lbl_examid");
                    Label examname = (Label)gr.Cells[0].FindControl("lbl_examname");
                    Label classid = (Label)gr.Cells[0].FindControl("lbl_classid");
                    Label secid = (Label)gr.Cells[0].FindControl("lbl_sec");
                    Label roll = (Label)gr.Cells[0].FindControl("lbl_roll");

                    Label excludestatus = (Label)gr.Cells[0].FindControl("lbl_excludestatus");
                    Label duestatus = (Label)gr.Cells[0].FindControl("lbl_duestatus");

                    if(excludestatus.Text=="1" && duestatus.Text=="1")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please clear fee dues then you can view the result.") + "')", true);
                        return;
                    }
                    string baseurl = Request.Url.GetLeftPart(UriPartial.Authority);
                    string sessionid = ddlacademicsession.SelectedValue;
                                                                          
                    if (ddlacademicsession.SelectedValue == "6")
                    {
                        if (classid.Text == "4" || classid.Text == "5" || classid.Text == "6" || classid.Text == "7" || classid.Text == "8")
                        {
                            if (examname.Text == "1ST TERM")
                            {
                                param = "option=PrintMarksheet_Term_I&ClassID=" + classid.Text + "&SectionID=" + secid.Text + "&ExamID=" + examid.Text + "&Session=" + sessionid + "&RollNo=" + roll.Text;
                            }
                            if (examname.Text == "2ND TERM")
                            {
                                param = "option=PrintMarksheetOverall_I_V_Term_II&ClassID=" + classid.Text + "&SectionID=" + secid.Text + "&ExamID=" + examid.Text + "&Session=" + sessionid + "&RollNo=" + roll.Text;
                            }
                        }
                        if (classid.Text == "9" || classid.Text == "10" || classid.Text == "11")
                        {
                            if (examname.Text == "1ST TERM")
                            {
                                param = "option=PrintMarksheet_VI_VIII_Term_I&ClassID=" + classid.Text + "&SectionID=" + secid.Text + "&ExamID=" + examid.Text + "&Session=" + sessionid + "&RollNo=" + roll.Text;
                            }
                            if (examname.Text == "2ND TERM")
                            {
                                param = "option=PrintMarksheetOverall_VI_VIII_Term_II&ClassID=" + classid.Text + "&SectionID=" + secid.Text + "&ExamID=" + examid.Text + "&Session=" + sessionid + "&RollNo=" + roll.Text;
                            }
                        }
                        if (classid.Text == "12" || classid.Text == "13")
                        {
                            if (examname.Text == "1ST TERM")
                            {
                                param = "option=PrintMarksheet_IX_X_Term_I&ClassID=" + classid.Text + "&SectionID=" + secid.Text + "&ExamID=" + examid.Text + "&Session=" + sessionid + "&RollNo=" + roll.Text;
                            }
                            if (examname.Text == "2ND TERM")
                            {
                                param = "option=PrintMarkSheetOverall_IX_X_Term_II&ClassID=" + classid.Text + "&SectionID=" + secid.Text + "&ExamID=" + examid.Text + "&Session=" + sessionid + "&RollNo=" + roll.Text;
                            }
                        }
                        Commonfunction common = new Commonfunction();
                        string ecryptstring = common.Encrypt(param);
                        string url = baseurl + "/EduReports/Reports/2021/ReportViewer.aspx?ID=" + ecryptstring;
                        string fullURL = "window.open('" + url + "', '_blank');";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
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
    }
}