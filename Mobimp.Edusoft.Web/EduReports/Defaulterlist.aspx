<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="Defaulterlist.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduReports.Defaulterlist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">

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

            //            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
            //                str = str + "\n Please select class."
            //                document.getElementById("<%=ddlclasses.ClientID %>").focus()
            //                i++
            //            }

            if (document.getElementById("<%=ddlfeetypess.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select fee type."
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
            objcategory = document.getElementById("<%= ddlcategorys.ClientID %>")



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
                window.open("../EduReports/Reports/ReportViewer.aspx?option=DefaulterList&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&SexID=" + objSex.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value + "&Status=" + objStatus.value + "&Searchtype=" + objsearchtype.value + "&SearchBy=" + objStudentname.value + "&FeeTypeID=" + objfeetypes.value + "&MonthID=" + objMonthID.value + "&CategoryID=" + objcategory.value)
            }
        }


    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="css3gradient">
                <asp:Panel ID="panstdlist" runat="server">
                    <div style="text-align: center">
                        Defaulter List</did>
                        <table style="width: 100%" class="fontstyle">
                            <tr>
                                <td colspan="6">
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px">
                                    <asp:DropDownList ID="ddlsearch" Width="110px" runat="server" CssClass="cusDropDown">
                                        <asp:ListItem Value="0">Search By:</asp:ListItem>
                                        <asp:ListItem Value="1">Name </asp:ListItem>
                                        <%--<asp:ListItem Value="2">Middle Name</asp:ListItem>
                                    <asp:ListItem Value="3">Last Name </asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox runat="server" AutoPostBack="true" ID="txtstudentanme" CssClass="cusTextBox"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txtContactsSearch_AutoCompleteExtender" runat="server"
                                                ServiceMethod="GetempNames" MinimumPrefixLength="2" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txtstudentanme" UseContextKey="True"
                                                DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudentanme" ID="FilteredTextBoxExtender1"
                                                runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
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
                                    <asp:Label ID="lblsexs" runat="server" Text="Gender"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlsexs" runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblstdentIDS" runat="server" Text="Admission No"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtstudentIDs" AutoPostBack="true" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtstudentIDs" ID="FilteredTextBoxExtender2"
                                        runat="server" ValidChars="0123456789" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetStudentIDs"
                                        MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                        CompletionSetCount="1" TargetControlID="txtstudentIDs" UseContextKey="True" DelimiterCharacters=""
                                        Enabled="True" ServicePath="">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
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
                                <%-- <td>
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
                            </td>--%>
                                <td>
                                    <asp:Label ID="lblcategories" runat="server" Text="Student Category"></asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlcategorys" runat="server" CssClass="cusDropDown">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlcategorys" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:Label ID="lblfeetypess" runat="server" Text="Fee Type"></asp:Label>
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
                                    <span id="Span5" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
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
                                    <span id="Span6" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
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
                                    <div  style="text-align: right">
                                        <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btncreate" runat="server" Visible="false" CssClass="button" OnClientClick="return Validates();"
                                                    Text="Create" OnClick="btncreate_Click" />
                                                <asp:Button ID="btnsearch" runat="server" CssClass="button" OnClientClick="return Validates1();"
                                                    Text="Search" OnClick="btnsearch_Click" />
                                                <asp:Button ID="btnreset" CssClass="button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                                <asp:Button ID="btnprint" CssClass="button" runat="server" Text="Print" OnClientClick="return PrintDefaulterList();" />
                                                <asp:Button ID="btnsend" CssClass="button" runat="server" Text="Send SMS" Enabled="false"
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
                <asp:Panel ID="panelresult" runat="server" Height="250px">
                    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </div>
                            <div style="height: 240px; width: 100%; overflow: auto;">
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
                                                StudentID</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldefaulterID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
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
                                                Name</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblcellno" Visible="false" runat="server" Text='<%# Eval("MobileNo")%>'></asp:Label>
                                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="190px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Gender</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsex" runat="server" Text='<%# Eval("SexName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Feet ype</HeaderTemplate>
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
                                                Fee Amount</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblfee" runat="server" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Late Fine</HeaderTemplate>
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
                                                Generated By</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Generated Date</HeaderTemplate>
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
