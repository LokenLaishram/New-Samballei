<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="Defaulterlist.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduReports.Defaulterlist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">

        var Page;
        function pageLoad() {

            Page = Sys.WebForms.PageRequestManager.getInstance();

            Page.add_initializeRequest(OnInitializeRequest);

        }

        function OnInitializeRequest(sender, args) {

            var postBackElement = args.get_postBackElement();

            if (Page.get_isInAsyncPostBack()) {
                alert('One request is already in progress....');
                args.set_cancel(true);
            }

        }
        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        row.style.backgroundColor = "white";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            row.style.backgroundColor = "white";

                        }

                        else {

                            row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }

        function Check_Click(objRef) {

            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "white";
            }
            else {

                //If not checked change back to original color

                if (row.rowIndex % 2 == 0) {

                    //Alternating Row Color

                    row.style.backgroundColor = "white";

                }

                else {

                    row.style.backgroundColor = "white";

                }

            }

            //Get the reference of GridView

            var GridView = row.parentNode;
            //Get all input elements in Gridview

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //The First element is the Header Checkbox

                var headerCheckBox = inputList[0];
                //Based on all or none checkboxes

                //are checked check/uncheck Header Checkbox

                var checked = true;

                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                    if (!inputList[i].checked) {

                        checked = false;

                        break;

                    }

                }

            }

            headerCheckBox.checked = checked;

        }

        function Validates() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
                document.getElementById("<%=ddlclasses.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlsections.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select section."
                document.getElementById("<%=ddlsections.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlfeetypess.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select fee types."
                document.getElementById("<%=ddlfeetypess.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlmonths.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select fee month."
                document.getElementById("<%=ddlmonths.ClientID %>").focus()
                i++
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }




        function Validates1() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
                document.getElementById("<%=ddlclasses.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=ddlfeetypess.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select fee types."
                document.getElementById("<%=ddlfeetypess.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtfrom.ClientID%>").value == "") {
                str = str + "\n Please select Date from."
                document.getElementById("<%=txtfrom.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtto.ClientID%>").value == "") {
                str = str + "\n Please select Date to."
                document.getElementById("<%=txtto.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }

        function PrintDefaulterList() {
            objStudentID = document.getElementById("<%= txtstudentIDs.ClientID %>")
            objStreamID = document.getElementById("<%= ddlstreams.ClientID %>")
            objClassID = document.getElementById("<%= ddlclasses.ClientID %>")
            objMonthID = document.getElementById("<%= ddlmonths.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objsearchtype = document.getElementById("<%= ddlsearch.ClientID %>")
            objSection = document.getElementById("<%= ddlsections.ClientID %>")
            objStudentname = document.getElementById("<%= txtstudentanme.ClientID %>")
            objSex = document.getElementById("<%= ddlsexs.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")
            objStatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objfeetypes = document.getElementById("<%= ddlfeetypess.ClientID %>")

            if (document.getElementById("<%= ddlclasses.ClientID %>").selectedIndex == "0") {
                alert("please select Class.");
                return false;
            }

            if (document.getElementById("<%= ddlfeetypess.ClientID %>").selectedIndex == "0") {
                alert("please select fee types");
                return false;
            }
            if (document.getElementById("<%= txtfrom.ClientID %>").value == "") {
                alert("please select Datefrom.");
                return false;
            }
            if (document.getElementById("<%= txtto.ClientID %>").value == "") {
                alert("please select Dateto.");
                return false;
            }
            else {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=DefaulterList&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&SexID=" + objSex.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value + "&Status=" + objStatus.value + "&Searchtype=" + objsearchtype.value + "&SearchBy=" + objStudentname.value + "&FeeTypeID=" + objfeetypes.value + "&MonthID=" + objMonthID.value)
            }
        }


    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="css3gradient">
                <asp:Panel ID="panstdlist" runat="server">
                    <did>Defaulter List</did>
                    <table style="width: 100%" class="fontstyle">
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlsearch" Enabled="false" Width="110px" runat="server" CssClass="cusDropDown">
                                    <asp:ListItem Value="0">Search By:</asp:ListItem>
                                    <asp:ListItem Value="1">Student Name </asp:ListItem>
                                    <asp:ListItem Value="2">Middle Name</asp:ListItem>
                                    <asp:ListItem Value="3">Last Name </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" ID="txtstudentanme" CssClass="cusTextBox"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtstudentanme" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlacademicseesions" runat="server" CssClass="cusDropDown">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblsexs" runat="server" Text="Sex"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlsexs" runat="server" CssClass="cusDropDown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblstdentIDS" runat="server" Text="StudentID:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtstudentIDs" Width="80px" runat="server" CssClass="cusTextBox"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span id="Span3" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                            OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlclasses" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                <%-- <span id="Span4" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">--%>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlsections" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlsections" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblstreams" runat="server" Text="Stream"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlstreams" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlstreams" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="lblfeetypess" runat="server" Text="Fee Types"></asp:Label>
                                <span id="Span1" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                </span>
                                <td>
                                    <asp:DropDownList runat="server" CssClass="cusDropDown" ID="ddlfeetypess">
                                    </asp:DropDownList>
                                </td>
                            </td>
                            <td>
                                <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cusDropDown">
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                            <asp:ListItem Value="0">InActive </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlstatus" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblfrom" runat="server" Text="Month"></asp:Label>
                                <%-- <span id="Span2" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">--%>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlmonths" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlmonths" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Date from"></asp:Label>
                                <%--<span id="Span5" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">--%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfrom" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                    TargetControlID="txtfrom" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                            </td>
                            <td>
                                <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                <%-- <span id="Span6" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">--%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtto" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                    TargetControlID="txtto" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div class="css4gradient">
                                    <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btncreate" runat="server" CssClass="button" OnClientClick="return Validates();"
                                                Text="Create" OnClick="btncreate_Click" />
                                            <asp:Button ID="btnsearch" runat="server" CssClass="button" OnClientClick="return Validates1();"
                                                Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btnreset" CssClass="button" runat="server" Text="Cancel" OnClick="btnreset_Click" />
                                            <asp:Button ID="btnprint" CssClass="button" runat="server" Text="Print" OnClientClick="return PrintDefaulterList();" />
                                            <asp:Button ID="btnsend" CssClass="button" runat="server" Text="SendSMS" Enabled="false"
                                                OnClick="btnsend_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btncreate" />
                                            <asp:PostBackTrigger ControlID="btnsearch" />
                                            <asp:PostBackTrigger ControlID="btnreset" />
                                            <asp:PostBackTrigger ControlID="btnsend" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panelresult" runat="server" Height="400px">
                    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div>
                                Result:
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </div>
                            <div style="height: 350px; width: 100%; overflow: auto;">
                                <asp:UpdateProgress ID="updateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="loading ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="GvDefaulterlist" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chekboxall" runat="server" onclick="checkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chekboxselect" runat="server" onclick="Check_Click(this);" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                ID</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldefaulterID" runat="server" Text='<%# Eval("ID")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                AdmissionNo</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstudentID" runat="server" Visible="false" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                <asp:Label ID="lbladmisiionNo" runat="server" Text='<%# Eval("AdmissionNo")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Class</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Section</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student Name</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="190px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                ParentCellNo</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblcellno" runat="server" Text='<%# Eval("MobileNo")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sex</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsex" runat="server" Text='<%# Eval("SexName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Feetype</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblfeeTypeID" runat="server" Text='<%# Eval("FeeType")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Month</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("MonthNames")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                FeeAmount</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblfee" runat="server" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                LateFine</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblfine" runat="server" Text='<%# Eval("FineAmount", "{0:0#.##}")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Status</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("DStatus")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                AddedBy</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                AddedDate</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Year</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsession" runat="server" Text='<%# Eval("SessionName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#D8EBF5" />
                                </asp:GridView>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            Total Fee Amount: Rs.
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltotalamount" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            Total Fine Amount: Rs.
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltotfine" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
