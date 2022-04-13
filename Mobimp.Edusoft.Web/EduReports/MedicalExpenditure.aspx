<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="MedicalExpenditure.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduReports.MedicalExpenditure" %>

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

        function Validate() {

            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlacademicseesions.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=dllstudentcategory.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Student Category.";
                document.getElementById("<%=dllstudentcategory.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclass.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclass.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsection.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Section.";
                document.getElementById("<%=ddlsection.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtrollnos.ClientID %>").value == "") {
                str = str + "\n Please enter Roll No.";
                document.getElementById("<%=txtrollnos.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtexpenditure.ClientID %>").value == "") {
                str = str + "\n Please enter Expenditure Amount.";
                document.getElementById("<%=txtexpenditure.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtremark.ClientID %>").value == "") {
                str = str + "\n Please enter Remark.";
                document.getElementById("<%=txtremark.ClientID %>").focus();
                i++;
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }

        function PrintCertificate() {
            objcategory = document.getElementById("<%= dllstudentcategory.ClientID %>")
            objclass = document.getElementById("<%= ddlclass.ClientID %>")
            objsection = document.getElementById("<%= ddlsection.ClientID %>")
            objrollno = document.getElementById("<%= txtrollnos.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objrollno = document.getElementById("<%= txtrollnos.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")
            objStatus = document.getElementById("<%= ddlstatus.ClientID %>")


            window.open("../EduReports/Reports/ReportViewer.aspx?option=Expenditure&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&CategoryID=" + objcategory.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value + "&Status=" + objStatus.value)

        }
    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TabContainer ID="tabexpenditure" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tabcertificate" runat="server" HeaderText="Medical Expenditure Record">
                    <ContentTemplate>
                        <div>
                            <table width="100%" class="fontstyle">
                                <tr>
                                    <td colspan="10">
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlacademicseesions" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcategory" runat="server" Text="Student Category"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dllstudentcategory" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlclass" AutoPostBack="true" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                    runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlclass" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                  
                                </tr>
                                <tr>  <td>
                                        <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlsection" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlsection" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblrollnos" runat="server" Text="Roll No"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtrollnos" Width="80px" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtrollnos" ID="FilteredTextBoxExtender2"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblamount" runat="server" Text="Expenditure Amount"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtexpenditure" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtexpenditure" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="0123456789." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                 
                                </tr>
                                <tr>   <td>
                                        <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
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
                                    <td>
                                        <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cusDropDown">
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                            <asp:ListItem Value="0">InActive </asp:ListItem>
                                        </asp:DropDownList>
                                    </td></tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblremark" runat="server" Text="Remark"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtremark" Width="400px" TextMode="MultiLine" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div  style="text-align:right">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnsave" runat="server" CssClass="button" OnClientClick="return Validate();"
                                            Text="Save" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClick="btnsearch_Click" />
                                        <asp:Button ID="btncanceldeliv" runat="server" CssClass="button" Text="Reset" OnClick="btncanceldeliv_Click" />
                                        <asp:Button ID="btnprint" runat="server" CssClass="button" Text="Print" Enabled="False"
                                            OnClientClick="return PrintCertificate();" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="panel1" runat="server">
                            <div>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </div>
                            <div style="height: 250px; width: 100%; overflow: auto;">
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="loading ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="Gvexpenditure" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                    OnRowCommand="Gvexpenditure_RowCommand" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Expd.No</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblccID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                <asp:Label ID="lblccNo" runat="server" Text='<%# Eval("expNo")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Name</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstudentname" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Class</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Section</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsectionname" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Roll No</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblrollno" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Amount</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblexpenditure" runat="server" Text='<%# Eval("ExpenditureAmount", "{0:0#.##}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                          <asp:TemplateField>
                                            <HeaderTemplate>
                                                Remark</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblremark" runat="server" Text='<%# Eval("Remarks")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Added By</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Date</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldccdate" runat="server" Text='<%# Eval("AddedDate","{0:dd/MM/yyyy}")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Delete</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');"> <img src="../EduImages/delete.png" height="20px" alt="" title="Delete"  border="0" /></asp:LinkButton></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#D8EBF5" />
                                </asp:GridView>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblcasule"></asp:Label>
                                            :<asp:Label runat="server" ForeColor="Green" ID="lbltotalpaid" Text=" 0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
