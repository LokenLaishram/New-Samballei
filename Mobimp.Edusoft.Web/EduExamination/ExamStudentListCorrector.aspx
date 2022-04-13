<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="ExamStudentListCorrector.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.StudentListCorrector" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">

        function Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsections.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select section.";
                document.getElementById("<%=ddlsections.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam Type.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsubject.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select subject.";
                document.getElementById("<%=ddlsubject.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }
        function Validate1() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsections.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select section.";
                document.getElementById("<%=ddlsections.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam Type.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsubject.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select subject.";
                document.getElementById("<%=ddlsubject.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtstudentID.ClientID%>").value == "") {
                str = str + "\n Please enter Student ID."
                document.getElementById("<%=txtstudentID.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }            
    </script>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tapdemolyeelist" runat="server" HeaderText="Student List Corrector">
                    <ContentTemplate>
                        <div id="divmessage" runat="server">
                            <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                        <div>
                            <table width="100%" class="fontstyle">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlacademicseesions" runat="server" CssClass="cusDropDown">
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
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlexam" OnSelectedIndexChanged="ddlexam_SelectedIndexChanged"
                                                    AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlexam" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlsubject" OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged"
                                                    AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlsubject" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblstudentID" runat="server" Text="StudentID"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtstudentID" AutoPostBack="True" runat="server" CssClass="cusTextBox"
                                            OnTextChanged="txtstudentID_TextChanged"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtstudentID" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClick="btnsearch_Click"
                                                    OnClientClick="return Validate();" Width="87px" />
                                                <asp:Button ID="btnadd" runat="server" CssClass="button" OnClientClick="return Validate1();"
                                                    Text="Add" Width="87px" OnClick="btnadd_Click" />
                                                <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnsearch" />
                                                <asp:AsyncPostBackTrigger ControlID="btnadd" />
                                                <asp:AsyncPostBackTrigger ControlID="btncancel" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table class="fontstyle">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblpwfullmark" runat="server" Text="PW full Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpwfullmark" Width="50px" CssClass="cusTextBox" Enabled="False"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpwpassmark" runat="server" Text="PW Pass Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpwpassmark" Width="50px" CssClass="cusTextBox" Enabled="False"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblutfullmark" runat="server" Text=" UT/H/F Full Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtutfullmarks" Width="50px" CssClass="cusTextBox" Enabled="False"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblutpassmark" runat="server" Text=" UT/H/F Pass Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtutpassmark" Width="50px" CssClass="cusTextBox" Enabled="False"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblhafullmark" runat="server" Text="HA full Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthafullmark" Width="50px" CssClass="cusTextBox" Enabled="False"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblhapassmark" runat="server" Text="PW Pass Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthapassmark" Width="50px" CssClass="cusTextBox" Enabled="False"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFullMark" runat="server" Text="Full Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFullMark" Width="50px" CssClass="cusTextBox" Enabled="False"
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPassMrk" runat="server" Text="Pass Mark"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtpassmark" Width="50px" CssClass="cuslabel" runat="server"></asp:Label>
                                        <asp:Label ID="txttotalmark" Width="50px" Visible="False" CssClass="cuslabel" runat="server"></asp:Label>
                                        <asp:Label ID="txttotalpassmark" Width="50px" Visible="False" CssClass="cuslabel"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="panelresult" runat="server" Height="300px">
                            <div style="height: 290px; overflow: auto;">
                                <asp:UpdateProgress ID="updateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="loading ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="GvExamdetails" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="100%" class="grid" OnRowCommand="GvExamdetails_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                SL No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student ID</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="7%" />
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
                                                Added By</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
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
                                    <HeaderStyle BackColor="#D8EBF5" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
