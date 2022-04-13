<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="ExamTimeTable.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduExamination.ExamTimeTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
           function OnInitializeRequest(sender, args) {

            var postBackElement = args.get_postBackElement()

            if (Page.get_isInAsyncPostBack()) {
                alert('One request is already in progress....')
                args.set_cancel(true)
            }

        }

        function Validates() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
                document.getElementById("<%=ddlclasses.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlsubjects.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select subject."
                document.getElementById("<%=ddlsubjects.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select exam."
                document.getElementById("<%=ddlexam.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtfrom.ClientID%>").value == "") {
                str = str + "\n Please enter date."
                document.getElementById("<%=txtfrom.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtstarttime.ClientID%>").value == "") {
                str = str + "\n Please enter start time."
                document.getElementById("<%=txtstarttime.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtendtime.ClientID%>").value == "") {
                str = str + "\n Please enter endtime."
                document.getElementById("<%=txtendtime.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }


        function Validatesearch() {

            var str = ""
            var i = 0



            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
                document.getElementById("<%=ddlclasses.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select exam."
                document.getElementById("<%=ddlexam.ClientID %>").focus()
                i++
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }

        function PrintExamSchedule() {
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsubject = document.getElementById("<%= ddlsubjects.ClientID %>")
            objexam = document.getElementById("<%= ddlexam.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicsession.ClientID %>")
            objstatus = document.getElementById("<%= ddlstatus.ClientID %>")

            if (objclass.value == "0") {
                alert("Please select class");
                return false;
            }
            if (objexam.value == "0") {
                alert("Please select exam");
                return false;
            }
            else {

                window.open("../EduExamination/Reports/ReportViewer.aspx?option=ExamSchedule&ClassID=" + objclass.value + "&SubjectID=" + objsubject.value + "&ExamID=" + objexam.value + "&AcademicSessionID=" + objsession.value + "&Status=" + objstatus.value)
            }
        }

 
    </script>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="css3gradient">
                <div style="text-align: center">
                    Exam Scheduler</div>
                <div id="divmessage" runat="server">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                <div>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td>
                                <asp:Label ID="lblsession" runat="server" Text="Academic Year"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlacademicsession" runat="server" CssClass="cusDropDown">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged"
                                            CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlclasses" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="lblsubject" runat="server" Text="Subject"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlsubjects" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlsubjects" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlexam" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlexam" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblDate" Text="Exam Date"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfrom" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="MM/dd/yyyy"
                                    TargetControlID="txtfrom" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                            </td>
                            <td>
                                <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cusDropDown">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblstarttime" Text="Start Time"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtstarttime"  Width="200px" MaxLength="5" CssClass="cusTextBox"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtstarttime" ID="FilteredTextBoxExtender1"
                                    runat="server" ValidChars="0123456789." Enabled="True">
                                </asp:FilteredTextBoxExtender>
                                <asp:DropDownList ID="ddlstartime" Width="60px" runat="server" CssClass="cusDropDown">
                                    <asp:ListItem Value="1">AM</asp:ListItem>
                                    <asp:ListItem Value="2">PM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblendtime" Text="End Time"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtendtime" Width="200px" MaxLength="5" CssClass="cusTextBox"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtendtime" ID="FilteredTextBoxExtender2"
                                    runat="server" ValidChars="0123456789." Enabled="True">
                                </asp:FilteredTextBoxExtender>
                                <asp:DropDownList ID="ddlendtime" Width="60px" runat="server" CssClass="cusDropDown">
                                    <asp:ListItem Value="1">PM</asp:ListItem>
                                    <asp:ListItem Value="2">AM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="text-align: right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClientClick="return Validates();"
                                            OnClick="btnsave_Click" />
                                        <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClientClick="return Validatesearch();"
                                            OnClick="btnsearch_Click" />
                                        <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                        <asp:Button ID="btnprint" runat="server" CssClass="button" Text="Print" OnClientClick="return  PrintExamSchedule();" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnsave" />
                                        <asp:PostBackTrigger ControlID="btnsearch" />
                                        <asp:PostBackTrigger ControlID="btncancel" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Panel ID="panelresult" runat="server" Height="250px">
                    <div style="height: 240px; width: 100%; overflow: auto;">
                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading" runat="server" class="loading ">
                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:GridView ID="GvExamScheduledetails" CssClass="gridViewHeader" runat="server"
                            EmptyDataText="No record found..." AutoGenerateColumns="False" Width="100%" class="grid"
                            OnRowCommand="GvExamScheduledetails_RowCommand" AllowPaging="false" OnRowDataBound="GvExamScheduledetails_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        ID
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblstartaffix" Visible="false" runat="server" Text='<%# Eval("StartimeAffix")%>'></asp:Label>
                                        <asp:Label ID="lblendaffix" Visible="false" runat="server" Text='<%# Eval("EndtimeAffix")%>'></asp:Label>
                                        <asp:Label ID="lblscheduleID" runat="server" Text='<%# Eval("ScheduleID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Exam
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblexam" runat="server" Text='<%# Eval("ExamName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Class</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Subject</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Date</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("StartDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Start Time</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblstarttime" runat="server" Text='<%# Eval("AStarttime")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        End Time</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblendtime" runat="server" Text='<%# Eval("AEndtime")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Year</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblsession" runat="server" Text='<%# Eval("AcademicSessionName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Edit</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                            CommandName="Edits" ForeColor="Blue"> <img src="../EduImages/edit.png" height="20px" alt="" title="Edit" /></asp:LinkButton></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Delete</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                            CommandName="Deletes" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');"> <img src="../EduImages/delete.png" height="20px" alt="" title="Delete"  border="0" /></asp:LinkButton></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#d8ebf5" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
