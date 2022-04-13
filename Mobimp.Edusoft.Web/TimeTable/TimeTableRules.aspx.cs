using ClosedXML.Excel;
using Mobimp.Campusoft.BussinessProcess.TimeTable;
using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
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

namespace Mobimp.Campusoft.Web.TimeTable
{
    public partial class TimeTableRules : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddropdownlist();
                BindGrid(1);
                // bindresponsive();
                createlist(10);
                // creategriddatalist(10);
                gv_slots.DataSource = null;
                gv_slots.DataBind();
            }
        }
        protected void binddropdownlist()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddl_class, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.TimeTableGroup));
            Commonfunction.PopulateDdl(ddl_starttime, mstlookup.GetLookupsList(LookupNames.Timer));
            txt_totalweeklyperod.Attributes["disabled"] = "disabled";

        }
        protected void createlist(int val)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= val; i++)
            {
                list.Add(i);
            }
            listperiod.DataSource = list;
            listperiod.DataBind();
        }
        protected void creategriddatalist(int val)
        {
            List<TimetableslotData> Slotlist = new List<TimetableslotData>();
            for (int i = 1; i <= val; i++)
            {
                TimetableslotData data = new TimetableslotData();
                data.SlotID = i;
                Slotlist.Add(data);
            }
            gv_slots.DataSource = Slotlist;
            gv_slots.DataBind();
            bindgridfoucs();
        }
        protected void bindgridfoucs()
        {
            for (int i = 0; i < gv_slots.Rows.Count - 1; i++)
            {
                TextBox curTexbox = gv_slots.Rows[i].Cells[1].FindControl("txt_duration") as TextBox;
                TextBox nexTextbox = gv_slots.Rows[i + 1].Cells[1].FindControl("txt_duration") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = gv_slots.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btn_close.ClientID + "', event)");
                }
            }

        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_tablerule.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_tablerule.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_tablerule.UseAccessibleHeader = true;
            Gv_tablerule.HeaderRow.TableSection = TableRowSection.TableHeader;
            TableCell tableCell = Gv_tablerule.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        string selectedItem = "";
        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlAcademicSessionID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("session") + "')", true);
                    return;
                }
                if (ddl_class.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("class") + "')", true);
                    return;
                }
                if (ddl_starttime.SelectedItem.Text == "-- Select --")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select period start time") + "')", true);
                    ddl_starttime.Focus();
                    return;
                }
                if (txt_noperiodperday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Period") + "')", true);
                    txt_noperiodperday.Focus();
                    return;
                }
                if (txt_recessperday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Recess") + "')", true);
                    txt_recessperday.Focus();
                    return;
                }

                int selectedcount = 0;
                //if (listperiod.Items.Count > 0)
                //{
                //    for (int i = 0; i < listperiod.Items.Count; i++)
                //    {
                //        if (listperiod.Items[i].Selected)
                //        {
                //            selectedItem = selectedItem + "," + listperiod.Items[i].Value;
                //            selectedcount = selectedcount + 1;
                //        }
                //    }
                //}
                string fisrtitem;
                string lasttitem;
                //fisrtitem = listperiod.Items[0].Value;
                //lasttitem = listperiod.Items[listperiod.Items.Count - 1].Value;

                //if (selectedItem == "")
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Please select recess period.')", true);
                //    return;
                //}
                //if (selectedItem.Contains(fisrtitem))
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Recess period could not be in first period.')", true);
                //    return;
                //}
                //if (selectedItem.Contains(lasttitem))
                //{
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('Recess period could not be in last period.')", true);
                //    return;
                //}

                List<TimetableslotData> Slotlist = new List<TimetableslotData>();
                foreach (GridViewRow row in gv_slots.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label SlotID = (Label)gv_slots.Rows[row.RowIndex].Cells[0].FindControl("SlotID");
                    TextBox duration = (TextBox)gv_slots.Rows[row.RowIndex].Cells[0].FindControl("txt_duration");
                    CheckBox Chk_slot = (CheckBox)gv_slots.Rows[row.RowIndex].Cells[0].FindControl("chk_slot");

                    TimetableslotData data = new TimetableslotData();
                    data.SlotID = Convert.ToInt32(SlotID.Text == "" ? "0" : SlotID.Text);
                    data.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
                    data.Duration = Convert.ToInt32(duration.Text == "" ? "0" : duration.Text);
                    if (Convert.ToInt32(duration.Text == "" ? "0" : duration.Text) == 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter duration.") + "')", true);
                        duration.Focus();
                        return;
                    }

                    data.GroupdID = Convert.ToInt32(ddl_group.Text == "" ? "0" : ddl_group.Text);
                    data.Session = Convert.ToInt32(ddlAcademicSessionID.Text == "" ? "0" : ddlAcademicSessionID.Text);
                    data.SlotType = Chk_slot.Checked ? 2 : 1;
                    if (Chk_slot.Checked)
                    {
                        selectedcount = selectedcount + 1;
                        selectedItem = selectedItem + "," + SlotID.Text;
                    }
                    Slotlist.Add(data);
                }

                fisrtitem = Slotlist[0].SlotType.ToString();
                lasttitem = Slotlist[Slotlist.Count - 1].SlotType.ToString();

                if (fisrtitem == "2" || lasttitem == "2")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Recess period could not be in first and last period.") + "')", true);
                    ddl_group.Focus();
                    return;
                }

                if (ddl_group.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Group") + "')", true);
                    ddl_group.Focus();
                    return;
                }
                if (selectedcount != Convert.ToInt32(txt_recessperday.Text.Trim() == "" ? "0" : txt_recessperday.Text.Trim()))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Number of recess period is not equal to selected recess period.") + "')", true);
                    txt_recessperday.Focus();
                    return;
                }
                if (txt_sunday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter no. of periods in sunday.") + "')", true);
                    txt_sunday.Focus();
                    return;
                }
                if (txt_monday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter no. of periods in monday.") + "')", true);
                    txt_monday.Focus();
                    return;
                }
                if (txt_tuesday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter no. of periods in tuesday.") + "')", true);
                    txt_tuesday.Focus();
                    return;
                }
                if (txt_wednesday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter no. of periods in wednesday.") + "')", true);
                    txt_wednesday.Focus();
                    return;
                }
                if (txt_thursday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter no. of periods in thursday.") + "')", true);
                    txt_thursday.Focus();
                    return;
                }
                if (txt_friday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter no. of periods in friday.") + "')", true);
                    txt_friday.Focus();
                    return;
                }
                if (txt_saturday.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter no. of periods in saturday.") + "')", true);
                    txt_saturday.Focus();
                    return;
                }
                TimetableruleData ObjData = new TimetableruleData();
                ClassallocationBO ObjBO = new ClassallocationBO();
                ObjData.EmployeeID = LoginToken.EmployeeID;
                ObjData.CompanyID = LoginToken.CompanyID;
                ObjData.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
                ObjData.Startfrom = ddl_starttime.SelectedItem.Text;
                //  ObjData.Startto = txt_to.Text.Trim();
                ObjData.Noperiods = Convert.ToInt32(txt_noperiodperday.Text.Trim() == "" ? "0" : txt_noperiodperday.Text.Trim());
                //ObjData.PeriodDuration = txt_periodduration.Text.Trim();
                ObjData.Norecess = Convert.ToInt32(txt_recessperday.Text.Trim() == "" ? "0" : txt_recessperday.Text.Trim());
                //ObjData.RecessDuration = txt_recessduration.Text.Trim();
                ObjData.Recessperiod = selectedItem.Substring(1);
                ObjData.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                ObjData.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
                ObjData.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
                ObjData.Sunday = Convert.ToInt32(txt_sunday.Text == "" ? "0" : txt_sunday.Text);
                ObjData.Monday = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                ObjData.Tuesday = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                ObjData.Wednesday = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                ObjData.Thursday = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                ObjData.Friday = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                ObjData.Saturday = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                ObjData.TotalWeeklyperiod = Convert.ToInt32(txt_totalweeklyperod.Text == "" ? "0" : txt_totalweeklyperod.Text);

                ObjData.XMLData = XmlConvertor.timetableslottoxml(Slotlist).ToString();

                if (Convert.ToInt32(lbl_ID.Text.Trim() == "" ? "0" : lbl_ID.Text.Trim()) > 0)
                {
                    ObjData.ID = Convert.ToInt32(lbl_ID.Text.Trim() == "" ? "0" : lbl_ID.Text.Trim());
                    ObjData.ActionType = EnumActionType.Update;
                }
                else
                {
                    ObjData.ActionType = EnumActionType.Insert;
                }

                int result = ObjBO.Updatetimetablerules(ObjData);
                if (result == 1 || result == 2)
                {
                    BindGrid(1);
                    clearall();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    btn_save.Text = "Add";
                }
                if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Timetableruleexist") + "')", true);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        private void BindGrid(int index)
        {
            TimetableruleData objdata = new TimetableruleData();
            ClassallocationBO objBO = new ClassallocationBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            Gv_tablerule.PageSize = pagesize;
            List<TimetableruleData> result = GetclassList(index, pagesize);
            if (result.Count > 0)
            {
                Gv_tablerule.Visible = true;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                Gv_tablerule.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                Gv_tablerule.PageIndex = index - 1;
                Gv_tablerule.DataSource = result;
                Gv_tablerule.DataBind();
                //bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                Gv_tablerule.DataSource = null;
                Gv_tablerule.DataBind();
                Gv_tablerule.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
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
        protected void Gv_tablerule_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                BindGrid(1);
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
                    Gv_tablerule.DataSource = sortedView;
                    Gv_tablerule.DataBind();
                    bindresponsive();
                    TableCell tableCell = Gv_tablerule.HeaderRow.Cells[ColumnIndex];
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
        protected void Gv_tablerule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_tablerule.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
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

        public List<TimetableruleData> GetclassList(int curIndex, int pagesize)
        {
            TimetableruleData objdata = new TimetableruleData();
            ClassallocationBO objstdBO = new ClassallocationBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            objdata.PageSize = pagesize;
            objdata.CurrentIndex = curIndex;
            return objstdBO.GettimetableClasslist(objdata);
        }
        protected void Gv_tablerule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_tablerule.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lbl_ID");
                    Label classID = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label SessionID = (Label)gr.Cells[0].FindControl("lbl_sessionID");
                    Label from = (Label)gr.Cells[0].FindControl("lbl_from");
                    Label to = (Label)gr.Cells[0].FindControl("lbl_to");
                    Label pduration = (Label)gr.Cells[0].FindControl("lbl_pduration");
                    Label norecess = (Label)gr.Cells[0].FindControl("lbl_nrecess");
                    Label rduation = (Label)gr.Cells[0].FindControl("lbl_rduration");
                    Label status = (Label)gr.Cells[0].FindControl("lbl_status");
                    Label Group = (Label)gr.Cells[0].FindControl("lbl_groupid");

                    TimetableruleData objdata = new TimetableruleData();
                    ClassallocationBO objstdBO = new ClassallocationBO();
                    objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                    objdata.ClassID = Convert.ToInt32(classID.Text == "" ? "0" : classID.Text);
                    objdata.GroupID = Convert.ToInt32(Group.Text == "" ? "0" : Group.Text);

                    List<TimetableruleData> result = objstdBO.GettimetablebyclassID(objdata);
                    if (result.Count > 0)
                    {
                        ddlAcademicSessionID.SelectedValue = result[0].AcademicSessionID.ToString();
                        ddl_class.SelectedValue = result[0].ClassID.ToString();
                        txt_noperiodperday.Text = result[0].Noperiods.ToString();
                        //txt_periodduration.Text = result[0].PeriodDuration.ToString();
                        txt_recessperday.Text = result[0].Norecess.ToString();
                        //txt_recessduration.Text = result[0].RecessDuration.ToString();
                        ddl_starttime.SelectedItem.Text = result[0].Startfrom.ToString();
                        txt_sunday.Text = result[0].Sunday.ToString();
                        txt_monday.Text = result[0].Monday.ToString();
                        txt_tuesday.Text = result[0].Tuesday.ToString();
                        txt_wednesday.Text = result[0].Wednesday.ToString();
                        txt_thursday.Text = result[0].Thursday.ToString();
                        txt_friday.Text = result[0].Friday.ToString();
                        txt_saturday.Text = result[0].Saturday.ToString();
                        txt_totalweeklyperod.Text = result[0].TotalWeeklyperiod.ToString();
                        ddlstatus.SelectedValue = (result[0].IsActive == true ? 1 : 0).ToString();
                        ddl_group.SelectedValue = result[0].GroupID.ToString();
                        int ClID = Convert.ToInt32(result[0].ClassID.ToString());
                        int sessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                        getnosubjects(ClID, sessionID);
                        lbl_ID.Text = result[0].ID.ToString();
                        btn_save.Text = "Update";
                        TimetableslotData data = new TimetableslotData();
                        data.Session = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                        data.ClassID = Convert.ToInt32(result[0].ClassID.ToString());
                        data.GroupdID = Convert.ToInt32(result[0].GroupID.ToString());
                        List<TimetableslotData> slots = objstdBO.GettimetableSlots(data);
                        if (slots.Count > 0)
                        {
                            gv_slots.DataSource = slots;
                            gv_slots.DataBind();
                            bindgridfoucs();
                        }
                        else
                        {
                            int totalperiod = Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text);
                            int totalecrperiod = Convert.ToInt32(txt_recessperday.Text == "" ? "0" : txt_recessperday.Text);
                            int period = totalperiod + totalecrperiod;
                            creategriddatalist(period);
                        }

                        //createlist(result[0].Noperiods + result[0].Norecess);
                        //if (listperiod.Items.Count > 0)
                        //{
                        //    for (int j = 0; j < listperiod.Items.Count; j++)
                        //    {
                        //        if (result[0].Recessperiod.Contains(listperiod.Items[j].Value.ToString()))
                        //        {
                        //            listperiod.Items[j].Selected = true;
                        //        }
                        //    }
                        //}

                    }
                }
            }
            catch (Exception ex) //Exception in agent layer itself 
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
        }
        protected void gv_slots_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label slottype = (Label)e.Row.FindControl("lbl_chkslot");
                CheckBox chk_slot = (CheckBox)e.Row.FindControl("chk_slot");

                if (slottype.Text == "2")
                {
                    chk_slot.Checked = true;
                }
                else
                {
                    chk_slot.Checked = false;
                }

            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            clearall();
            BindGrid(1);
        }
        protected void clearall()
        {
            ddl_class.SelectedIndex = 0;
            txt_noperiodperday.Text = "";
            // txt_recessduration.Text = "";
            txt_recessperday.Text = "";
            //  txt_periodduration.Text = "";
            txt_sunday.Text = "";
            txt_monday.Text = "";
            txt_tuesday.Text = "";
            txt_wednesday.Text = "";
            txt_thursday.Text = "";
            txt_friday.Text = "";
            txt_saturday.Text = "";
            txt_totalweeklyperod.Text = "";
            ddlAcademicSessionID.SelectedIndex = 1;
            lbl_ID.Text = "";
            //txt_recessperiods.Text = "";
            btn_save.Text = "Add";
            ddl_group.SelectedIndex = 0;
            txt_nosubject.Text = "";
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_starttime, mstlookup.GetLookupsList(LookupNames.Timer));
            gv_slots.DataSource = null;
            gv_slots.DataBind();
            //createlist(10);
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Rule List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Rules.xlsx");
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
            List<TimetableruleData> ClassDetail = GetclassList(1, size);
            List<TimetableruleDatatoExcel> classtoexcel = new List<TimetableruleDatatoExcel>();
            int i = 0;
            foreach (TimetableruleData row in ClassDetail)
            {
                TimetableruleDatatoExcel EcxeclStd = new TimetableruleDatatoExcel();
                EcxeclStd.ClassName = ClassDetail[i].ClassName;
                EcxeclStd.Startfrom = ClassDetail[i].Startfrom;
                EcxeclStd.Startto = ClassDetail[i].Startto;
                EcxeclStd.Noperiods = ClassDetail[i].Noperiods;
                EcxeclStd.PeriodDuration = ClassDetail[i].PeriodDuration;
                EcxeclStd.Norecess = ClassDetail[i].Norecess;
                EcxeclStd.RecessDuration = ClassDetail[i].RecessDuration;
                classtoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(classtoexcel);
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

        protected void ddlAcademicSessionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {

            int classID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            int sessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            getnosubjects(classID, sessionID);
            BindGrid(1);
        }
        private void getnosubjects(int classID, int sessionID)
        {
            TimetableruleData objdata = new TimetableruleData();
            ClassallocationBO objBO = new ClassallocationBO();
            List<TimetableruleData> result = objBO.GetNosubjectbyclassID(classID, sessionID);
            if (result.Count > 0)
            {
                txt_nosubject.Text = result[0].NoSubjects.ToString();
            }
            else
            {
                txt_nosubject.Text = "";
            }
        }
        protected void Gv_tablerule_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void txt_recessperday_TextChanged(object sender, EventArgs e)
        {
            int totalperiod = Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text);
            int totalecrperiod = Convert.ToInt32(txt_recessperday.Text == "" ? "0" : txt_recessperday.Text);
            int period = totalperiod + totalecrperiod;
            //createlist(period);
            creategriddatalist(period);
        }
        protected void txt_noperiodperday_TextChanged(object sender, EventArgs e)
        {
            int totalperiod = Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text);
            int totalecrperiod = Convert.ToInt32(txt_recessperday.Text == "" ? "0" : txt_recessperday.Text);
            int period = totalperiod + totalecrperiod;
            //createlist(period);
            creategriddatalist(period);
        }
        protected void calctotalwp()
        {
            txt_totalweeklyperod.Text = (Convert.ToInt32(txt_sunday.Text == "" ? "0" : txt_sunday.Text)
                + Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text)
                + Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text)
                + Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text)
                + Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text)
                + Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text)
                + Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text)
               ).ToString();
        }
        protected void txt_sunday_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_sunday.Text == "" ? "0" : txt_sunday.Text) > Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text))
            {
                txt_sunday.Text = "";
                txt_sunday.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum number of period per day.") + "')", true);
                return;
            }
            calctotalwp();
            txt_monday.Focus();
        }
        protected void txt_monday_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text) > Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text))
            {
                txt_monday.Text = "";
                txt_monday.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum number of period per day.") + "')", true);
                return;
            }
            calctotalwp();
            txt_tuesday.Focus();
        }
        protected void txt_tuesday_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text) > Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text))
            {
                txt_tuesday.Text = "";
                txt_tuesday.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum number of period per day.") + "')", true);
                return;
            }
            calctotalwp();
            txt_wednesday.Focus();
        }
        protected void txt_wednesday_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text) > Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text))
            {
                txt_wednesday.Text = "";
                txt_wednesday.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum number of period per day.") + "')", true);
                return;
            }
            calctotalwp();
            txt_thursday.Focus();
        }
        protected void txt_thursday_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text) > Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text))
            {
                txt_thursday.Text = "";
                txt_thursday.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum number of period per day.") + "')", true);
                return;
            }
            calctotalwp();
            txt_friday.Focus();
        }
        protected void txt_friday_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text) > Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text))
            {
                txt_friday.Text = "";
                txt_friday.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum number of period per day.") + "')", true);
                return;
            }
            calctotalwp();
            txt_saturday.Focus();
        }
        protected void txt_saturday_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text) > Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text))
            {
                txt_saturday.Text = "";
                txt_saturday.Focus();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum number of period per day.") + "')", true);
                return;
            }
            calctotalwp();
            txt_saturday.Focus();
        }

        protected void btnopen2_Click(object sender, EventArgs e)
        {
            int totalperiod = Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text);
            int totalecrperiod = Convert.ToInt32(txt_recessperday.Text == "" ? "0" : txt_recessperday.Text);
            int period = totalperiod + totalecrperiod;
            //createlist(period);
            creategriddatalist(period);
        }

        protected void btn_setslot_Click(object sender, EventArgs e)
        {
            if (txt_noperiodperday.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Period") + "')", true);
                txt_noperiodperday.Focus();
                return;
            }
            if (txt_recessperday.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Recess") + "')", true);
                txt_recessperday.Focus();
                return;
            }
            int totalperiod = Convert.ToInt32(txt_noperiodperday.Text == "" ? "0" : txt_noperiodperday.Text);
            int totalecrperiod = Convert.ToInt32(txt_recessperday.Text == "" ? "0" : txt_recessperday.Text);
            int period = totalperiod + totalecrperiod;
            creategriddatalist(period);
            ModalPopupExtender2.Show();
        }
    }
}