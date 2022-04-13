<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="MultiplePhotoUploader.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduStudent.MultiplePhotoUploader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">
        function Validate() {

            var str = ""
            var i = 0
            if (document.getElementById("<%=ddlcategorys.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Category."
                document.getElementById("<%=ddlcategorys.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
                document.getElementById("<%=ddlclasses.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlsections.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Section."
                document.getElementById("<%=ddlsections.ClientID %>").focus()
                i++
            }


            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }
        function Printstudentlist() {
            objStudentID = document.getElementById("<%= txtstudentIDs.ClientID %>")
            objClassID = document.getElementById("<%= ddlclasses.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objsearchtype = document.getElementById("<%= ddlsearch.ClientID %>")
            objSection = document.getElementById("<%= ddlsections.ClientID %>")
            objStudentname = document.getElementById("<%= txtstudentanme.ClientID %>")
            objSex = document.getElementById("<%= ddlsexs.ClientID %>")
            objroll = document.getElementById("<%= txtrollno.ClientID %>")
            objcategory = document.getElementById("<%= ddlcategorys.ClientID %>")

            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                alert("Please select class.");
                return false;
            }
            if (document.getElementById("<%=ddlsections.ClientID%>").selectedIndex == "0") {
                alert("Please select section.");
                return false;
            }
            if (document.getElementById("<%=ddlcategorys.ClientID%>").selectedIndex == "0") {
                alert("Please select Student Category.");
                return false;
            }
            else {
                window.open("../EduStudent/Reports/ReportViewer.aspx?option=SectionStudentList&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&SexID=" + objSex.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Searchtype=" + objsearchtype.value + "&SearchBy=" + objStudentname.value + "&RollNo=" + objroll.value + "&Category=" + objcategory.value)
                return true;
            }
        }
    
    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="taproll" runat="server" HeaderText="Photo Uploader">
                    <ContentTemplate>
                        <asp:Panel ID="panstdlist" runat="server">
                            <table style="width: 100%" class="fontstyle">
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="lblmesagestudentlist" runat="server"></asp:Label>
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
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlcategorys" runat="server" AutoPostBack="true" CssClass="cusDropDown"
                                                    OnSelectedIndexChanged="ddlcategorys_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcategorys" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
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
                                   
                                </tr>
                                <tr>
                                 <td>
                                        <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
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
                                    <td>
                                        <asp:Label ID="lblrollno" runat="server" Text="Roll No"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtrollno" Width="80px" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtrollno" ID="FilteredTextBoxExtender3"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cusDropDown">
                                            <asp:ListItem Value="1">Uploaded</asp:ListItem>
                                            <asp:ListItem Value="2">Not Uploaded</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <div  style="text-align:right">
                                            <asp:Button ID="btnsearch" runat="server" CssClass="button" OnClientClick="return Validate();"
                                                Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btnreset" CssClass="button" runat="server" OnClick="btnreset_Click"
                                                Text="Reset" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="panelresult" runat="server" Height="480px">
                            <div>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </div>
                            <div style="height: 470px; width: 100%; overflow: auto;">
                                <asp:UpdateProgress ID="updateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="loading ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="Gvstudenlist" CssClass="gridViewHeader" OnRowCommand="Gvstudenlist_RowCommand"
                                            runat="server" EmptyDataText="No record found..." AutoGenerateColumns="False"
                                            Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Admission No</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclassIDs" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sec</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                        <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Roll No</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblrollno" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Student Name</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Browse</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:FileUpload ID="studentphotouploader" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Uploader</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnupdate" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    Text="Upload" CssClass="button" CommandName="Upload" OnClientClick="javascript: return confirm('Do you confirm to update?');" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="btnupdate" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Photo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstudentbyte" runat="server" Visible="false" Text='<%# Eval("StudentImage")%>'></asp:Label>
                                                        <asp:Image ID="Image1" Height="75px" Width="75px" runat="server" ImageUrl='<%# Bind("StudentPhoto") %>' /></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#D8EBF5" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="Gvstudenlist" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
