<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="DeleveryProgressReport.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduReports.DeleveryProgressReport" %>

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

            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlacademicseesions.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclasses.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsections.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Sedction.";
                document.getElementById("<%=ddlsections.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Exam.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
                i++;
            }


            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }


        function Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddldeliveryclass.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddldeliveryclass.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddldeliverysection.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Sedction.";
                document.getElementById("<%=ddldeliverysection.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddldeliveryexams.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Exam.";
                document.getElementById("<%=ddldeliveryexams.ClientID %>").focus();
                i++;
            }


            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }

        function PrintReport() {
            objclass = document.getElementById("<%= ddldeliveryclass.ClientID %>")
            objsection = document.getElementById("<%= ddldeliverysection.ClientID %>")
            objexam = document.getElementById("<%= ddldeliveryexams.ClientID %>")
            objroll = document.getElementById("<%= txtdeliveryrolls.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            if (objclass.value == "1" || objclass.value == "2") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=KG12Report&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamTypeID=" + objexam.value + "&RollNo=" + objroll.value + "&Session=" + objsession.value)
            }
            if (objclass.value == "3") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class1Report&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamTypeID=" + objexam.value + "&RollNo=" + objroll.value + "&Session=" + objsession.value)
            }
            if (objclass.value == "4") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class2Report&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamTypeID=" + objexam.value + "&RollNo=" + objroll.value + "&Session=" + objsession.value)
            }
            if (objclass.value == "5" || objclass.value == "6" || objclass.value == "7") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class345Report&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamTypeID=" + objexam.value + "&RollNo=" + objroll.value + "&Session=" + objsession.value)
            }
            if (objclass.value == "8" || objclass.value == "9" || objclass.value == "10") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class678Report&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamTypeID=" + objexam.value + "&RollNo=" + objroll.value + "&Session=" + objsession.value)
            }
            if (objclass.value == "11" || objclass.value == "12") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class910Report&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamTypeID=" + objexam.value + "&RollNo=" + objroll.value + "&Session=" + objsession.value)
            }
        }
        function PrintReportClasswise(Class,Section,Exam,Session,Roll) {

            if (Class =="1" || Class== "2") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=KG12Report&ClassID=" + Class + "&SectionID=" + Section + "&ExamTypeID=" + Exam + "&RollNo=" + Roll + "&Session=" + Session)
            }
            if (Class=="3") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class1Report&ClassID=" + Class + "&SectionID=" + Section + "&ExamTypeID=" + Exam + "&RollNo=" + Roll + "&Session=" + Session)
            }
            if (Class== "4") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class2Report&ClassID=" + Class + "&SectionID=" + Section + "&ExamTypeID=" + Exam + "&RollNo=" + Roll + "&Session=" + Session)
            }
            if (Class == "5" || Class =="6" || Class == "7") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class345Report&ClassID=" + Class + "&SectionID=" + Section + "&ExamTypeID=" + Exam + "&RollNo=" + Roll + "&Session=" + Session)
            }
            if (Class == "8" || Class == "9" || Class == "10") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class678Report&ClassID=" + Class + "&SectionID=" + Section + "&ExamTypeID=" + Exam + "&RollNo=" + Roll + "&Session=" + Session)
            }
            if (Class == "11" || Class == "12") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Class910Report&ClassID=" + Class + "&SectionID=" + Section + "&ExamTypeID=" + Exam + "&RollNo=" + Roll + "&Session=" + Session)
            }
        }


    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="Tabprogressreport" runat="server" HeaderText="Progress Report Maker">
                    <ContentTemplate>
                        <div class="css3gradient">
                            <div id="divmessage" runat="server">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                            <div>
                                <table width="100%" class="fontstyle">
                                    <tr>
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
                                            <asp:Label ID="lblrollNo" runat="server" Text="RollNo."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtrollNo" Width="80px" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="css4gradient">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Button ID="Btncreate" runat="server" CssClass="button" Text="Search" OnClientClick="return Validates();"
                                                OnClick="Btncreate_Click" />
                                            <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" OnClick="btncancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Panel ID="panelresult" runat="server" Height="400px" GroupingText="Result">
                                <div style="height: 350px; width: 940px; overflow: auto;">
                                    <asp:UpdateProgress ID="updateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIVloading" runat="server" class="loading ">
                                                <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="GvExamdetails" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                        AutoGenerateColumns="False" Width="940px" class="grid" Height="142px" OnRowDataBound="GvExamdetails_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    RollNo</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstudentID" runat="server" Visible="false" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                    <asp:Label ID="ID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                    <asp:Label ID="lbloptionalsubjectID" runat="server" Visible="false" Text='<%# Eval("OptionalsubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lblalternativeSubjectID" runat="server" Visible="false" Text='<%# Eval("AternativeSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Name</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Class</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                    <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Section</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                    <asp:Label ID="lblsectionname" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    ExamName</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexamID" Visible="false" runat="server" Text='<%# Eval("ExamID")%>'></asp:Label>
                                                    <asp:Label ID="lblexamname" runat="server" Text='<%# Eval("ExamName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/English">
                                                <ItemTemplate>
                                                    <asp:TextBox MaxLength="3" runat="server" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("English")%>'
                                                        Width="25px" ID="txtenglish"></asp:TextBox>
                                                    <asp:Label ID="lblisdEngpass" Visible="false" runat="server" Text='<%# Eval("IsEpass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Justify" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Add.English">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("AddEnglish")%>'
                                                        Width="25px" ID="txtaddenglish"></asp:TextBox>
                                                    <asp:Label ID="lblisAdEngpass" Visible="false" runat="server" Text='<%# Eval("ISAddEpass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/MeiteiMayek">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Enabled="false" MaxLength="3" CssClass="cusTextBox" Text='<%# Eval("MeiteiMayek")%>'
                                                        Width="25px" ID="txtmeiteimayek"></asp:TextBox>
                                                    <asp:Label ID="lblMpass" Visible="false" runat="server" Text='<%# Eval("IsMPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Hindi....">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Enabled="false" MaxLength="3" CssClass="cusTextBox" Text='<%# Eval("Hindi")%>'
                                                        Width="25px" ID="txtHindi"></asp:TextBox>
                                                    <asp:Label ID="lblhpass" Visible="false" runat="server" Text='<%# Eval("IsHpass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Mathematics">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Enabled="false" MaxLength="3" CssClass="cusTextBox" Text='<%# Eval("Maths")%>'
                                                        Width="25px" ID="txtmaths"></asp:TextBox>
                                                    <asp:Label ID="lblisMathsgpass" Visible="false" runat="server" Text='<%# Eval("IsMthsPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Physics">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" CssClass="cusTextBox" Enabled="false" Text='<%# Eval("Physics")%>'
                                                        Width="25px" ID="txtphysics"></asp:TextBox>
                                                    <asp:Label ID="lblisPhysicsgpass" Visible="false" runat="server" Text='<%# Eval("IsPhyPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Chemistry">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Chemistry")%>'
                                                        Width="300px" ID="txtchemistry"></asp:TextBox>
                                                    <asp:Label ID="lblischempass" Visible="false" runat="server" Text='<%# Eval("IsChemPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Biology">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Biology")%>'
                                                        Width="25px" ID="txtbiology"></asp:TextBox>
                                                    <asp:Label ID="lblisbiopass" Visible="false" runat="server" Text='<%# Eval("ISBioPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/History">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("History")%>'
                                                        Width="25px" ID="txthistory"></asp:TextBox>
                                                    <asp:Label ID="lblisHistorygpass" Visible="false" runat="server" Text='<%# Eval("IsHistryPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Geograhy">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Geography")%>'
                                                        Width="25px" ID="txtgeo"></asp:TextBox>
                                                    <asp:Label ID="lblisGeogpass" Visible="false" runat="server" Text='<%# Eval("IsGeoPas")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText=" Civics&Eco">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Civics")%>'
                                                        Width="25px" ID="txtcivics"></asp:TextBox>
                                                    <asp:Label ID="lbliscivicsgpass" Visible="false" runat="server" Text='<%# Eval("IscivPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/HigherMaths">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("HrMaths")%>'
                                                        Width="25px" ID="txtHmaths"></asp:TextBox>
                                                    <asp:Label ID="lblisHrmathspass" Visible="false" runat="server" Text='<%# Eval("IsHrMPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Commerce">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Commerce")%>'
                                                        Width="25px" ID="txtcommerce"></asp:TextBox>
                                                    <asp:Label ID="lblcommpass" Visible="false" runat="server" Text='<%# Eval("IsCommPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Computer">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Computer")%>'
                                                        Width="25px" ID="txtcomputer"></asp:TextBox>
                                                    <asp:Label ID="lbliscomppass" Visible="false" runat="server" Text='<%# Eval("IsCompPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/HomeScience">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("HomeScience")%>'
                                                        Width="25px" ID="txthomescience"></asp:TextBox>
                                                    <asp:Label ID="lblishomescgpass" Visible="false" runat="server" Text='<%# Eval("IsHscPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Rhyme">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Rhyme")%>'
                                                        Width="25px" ID="txtrhyme"></asp:TextBox>
                                                    <asp:Label ID="lblisrhympass" Visible="false" runat="server" Text='<%# Eval("IsRhymPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Cursive">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Cursive")%>'
                                                        Width="25px" ID="txtcursive"></asp:TextBox>
                                                    <asp:Label ID="lbliscursivepass" Visible="false" runat="server" Text='<%# Eval("IsCursivePass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Drawing">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Drawing")%>'
                                                        Width="25px" ID="txtdrawing"></asp:TextBox>
                                                    <asp:Label ID="lblisdrwagpass" Visible="false" runat="server" Text='<%# Eval("IsDrawPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Gen.Knowledge">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("GK")%>'
                                                        Width="25px" ID="txtGK"></asp:TextBox>
                                                    <asp:Label ID="lblisgkgpass" Visible="false" runat="server" Text='<%# Eval("IsGkPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Justify" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/Science">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Science")%>'
                                                        Width="25px" ID="txtScience"></asp:TextBox>
                                                    <asp:Label ID="lblisScpass" Visible="false" runat="server" Text='<%# Eval("IsScipass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/SocialScience">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("SocialScience")%>'
                                                        Width="25px" ID="txtsocialscience"></asp:TextBox>
                                                    <asp:Label ID="lblissocpass" Visible="false" runat="server" Text='<%# Eval("IsSocPasa")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="/MoralScience">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" CssClass="cusTextBox" Enabled="false" Text='<%# Eval("MoralScience")%>'
                                                        Width="25px" ID="txtmoralscience"></asp:TextBox>
                                                    <asp:Label ID="lblismoralscpass" Visible="false" runat="server" Text='<%# Eval("IsMorScPass")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TotalMarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("TotalMarkrs")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PassMarks">
                                                <ItemTemplate>
                                                    <asp:TextBox Enabled="false" runat="server" CssClass="cusTextBox" Text='<%# Eval("TotalPassMarks")%>'
                                                        Width="30px" ID="txtpassmarkss"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MarksObtain">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmarksobtain" runat="server" Text='<%# Eval("TotalMarksObtain")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rank">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrank" runat="server" Text='<%# Eval("Ranks")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("ResultStatus")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PC">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPC" runat="server" Text='<%# Eval("Pc")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attendance">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblattendance" runat="server" Text='<%# Eval("Attendance")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="AttPC">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblattenPC" runat="server" Text='<%# Eval("APc")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("Remarks")%>' Width="100px"
                                                        ID="txtremarks"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    CreatedBy</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("CretreatedBy")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    EntryDate</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("ProgressReportCreatedDate","{0:dd/MM/yyyy}")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="4%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#D8EBF5" />
                                    </asp:GridView>
                                </div>
                                <div class="css4gradient">
                                    <asp:Button ID="btnupdate" runat="server" Text="Create" Enabled="False" OnClick="btnupdate_Click"
                                        UseSubmitBehavior="False" CssClass="button" />
                                </div>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Progress Report Delivery">
                    <ContentTemplate>
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
                                        <asp:Label ID="lbldeleiveryclasses" runat="server" Text="Class"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddldeliveryclass" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddldeliveryclass_SelectedIndexChanged"
                                                    CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddldeliveryclass" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldeliverysections" runat="server" Text="Section"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddldeliverysection" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddldeliverysection" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldelivexams" runat="server" Text="Exam"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddldeliveryexams" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddldeliveryexams" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldeliveryRolls" runat="server" Text="RollNo."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdeliveryrolls" Width="80px" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="css4gradient">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Button ID="btndelivery" runat="server" CssClass="button" Text="Delivery" OnClientClick="return Validate();"
                                            OnClick="btndelivery_Click" />
                                        <asp:Button ID="btncanceldeliv" runat="server" CssClass="button" Text="Cancel" OnClick="btncanceldeliv_Click" />
                                        <asp:Button ID="btnprint" runat="server" CssClass="button" Text="Print" Enabled="False"
                                            OnClientClick="return PrintReport();" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="panel1" runat="server" Height="400px" GroupingText="Result">
                            <div style="height: 350px; width: 940px; overflow: auto;">
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="loading ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="GvdeliveryProgressReport" CssClass="gridViewHeader" runat="server"
                                    EmptyDataText="No record found..." AutoGenerateColumns="False" Width="940px"
                                    class="grid" Height="142px" OnRowDataBound="GvdeliveryProgressReport_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                RollNo</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstudentID" runat="server" Visible="false" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                <asp:Label ID="ID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                <asp:Label ID="lbloptionalsubjectID" runat="server" Visible="false" Text='<%# Eval("OptionalsubjectID")%>'></asp:Label>
                                                <asp:Label ID="lblalternativeSubjectID" runat="server" Visible="false" Text='<%# Eval("AternativeSubjectID")%>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Name</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Class</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Section</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                <asp:Label ID="lblsectionname" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                ExamName</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblexamID" Visible="false" runat="server" Text='<%# Eval("ExamID")%>'></asp:Label>
                                                <asp:Label ID="lblexamname" runat="server" Text='<%# Eval("ExamName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/English">
                                            <ItemTemplate>
                                                <asp:TextBox MaxLength="3" runat="server" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("English")%>'
                                                    Width="25px" ID="txtenglish"></asp:TextBox>
                                                <asp:Label ID="lblisdEngpass" Visible="false" runat="server" Text='<%# Eval("IsEpass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Justify" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Add.English">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("AddEnglish")%>'
                                                    Width="25px" ID="txtaddenglish"></asp:TextBox>
                                                <asp:Label ID="lblisAdEngpass" Visible="false" runat="server" Text='<%# Eval("ISAddEpass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/MeiteiMayek">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" Enabled="false" MaxLength="3" CssClass="cusTextBox" Text='<%# Eval("MeiteiMayek")%>'
                                                    Width="25px" ID="txtmeiteimayek"></asp:TextBox>
                                                <asp:Label ID="lblMpass" Visible="false" runat="server" Text='<%# Eval("IsMPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Hindi....">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" Enabled="false" MaxLength="3" CssClass="cusTextBox" Text='<%# Eval("Hindi")%>'
                                                    Width="25px" ID="txtHindi"></asp:TextBox>
                                                <asp:Label ID="lblhpass" Visible="false" runat="server" Text='<%# Eval("IsHpass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Mathematics">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" Enabled="false" MaxLength="3" CssClass="cusTextBox" Text='<%# Eval("Maths")%>'
                                                    Width="25px" ID="txtmaths"></asp:TextBox>
                                                <asp:Label ID="lblisMathsgpass" Visible="false" runat="server" Text='<%# Eval("IsMthsPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Physics">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" CssClass="cusTextBox" Enabled="false" Text='<%# Eval("Physics")%>'
                                                    Width="25px" ID="txtphysics"></asp:TextBox>
                                                <asp:Label ID="lblisPhysicsgpass" Visible="false" runat="server" Text='<%# Eval("IsPhyPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Chemistry">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Chemistry")%>'
                                                    Width="300px" ID="txtchemistry"></asp:TextBox>
                                                <asp:Label ID="lblischempass" Visible="false" runat="server" Text='<%# Eval("IsChemPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Biology">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Biology")%>'
                                                    Width="25px" ID="txtbiology"></asp:TextBox>
                                                <asp:Label ID="lblisbiopass" Visible="false" runat="server" Text='<%# Eval("ISBioPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/History">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("History")%>'
                                                    Width="25px" ID="txthistory"></asp:TextBox>
                                                <asp:Label ID="lblisHistorygpass" Visible="false" runat="server" Text='<%# Eval("IsHistryPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Geograhy">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Geography")%>'
                                                    Width="25px" ID="txtgeo"></asp:TextBox>
                                                <asp:Label ID="lblisGeogpass" Visible="false" runat="server" Text='<%# Eval("IsGeoPas")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText=" Civics&Eco">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Civics")%>'
                                                    Width="25px" ID="txtcivics"></asp:TextBox>
                                                <asp:Label ID="lbliscivicsgpass" Visible="false" runat="server" Text='<%# Eval("IscivPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/HigherMaths">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("HrMaths")%>'
                                                    Width="25px" ID="txtHmaths"></asp:TextBox>
                                                <asp:Label ID="lblisHrmathspass" Visible="false" runat="server" Text='<%# Eval("IsHrMPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Commerce">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Commerce")%>'
                                                    Width="25px" ID="txtcommerce"></asp:TextBox>
                                                <asp:Label ID="lblcommpass" Visible="false" runat="server" Text='<%# Eval("IsCommPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Computer">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Computer")%>'
                                                    Width="25px" ID="txtcomputer"></asp:TextBox>
                                                <asp:Label ID="lbliscomppass" Visible="false" runat="server" Text='<%# Eval("IsCompPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/HomeScience">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("HomeScience")%>'
                                                    Width="25px" ID="txthomescience"></asp:TextBox>
                                                <asp:Label ID="lblishomescgpass" Visible="false" runat="server" Text='<%# Eval("IsHscPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Rhyme">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Rhyme")%>'
                                                    Width="25px" ID="txtrhyme"></asp:TextBox>
                                                <asp:Label ID="lblisrhympass" Visible="false" runat="server" Text='<%# Eval("IsRhymPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Cursive">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Cursive")%>'
                                                    Width="25px" ID="txtcursive"></asp:TextBox>
                                                <asp:Label ID="lbliscursivepass" Visible="false" runat="server" Text='<%# Eval("IsCursivePass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Drawing">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Drawing")%>'
                                                    Width="25px" ID="txtdrawing"></asp:TextBox>
                                                <asp:Label ID="lblisdrwagpass" Visible="false" runat="server" Text='<%# Eval("IsDrawPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Gen.Knowledge">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("GK")%>'
                                                    Width="25px" ID="txtGK"></asp:TextBox>
                                                <asp:Label ID="lblisgkgpass" Visible="false" runat="server" Text='<%# Eval("IsGkPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Justify" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/Science">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("Science")%>'
                                                    Width="25px" ID="txtScience"></asp:TextBox>
                                                <asp:Label ID="lblisScpass" Visible="false" runat="server" Text='<%# Eval("IsScipass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/SocialScience">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" MaxLength="3" Enabled="false" CssClass="cusTextBox" Text='<%# Eval("SocialScience")%>'
                                                    Width="25px" ID="txtsocialscience"></asp:TextBox>
                                                <asp:Label ID="lblissocpass" Visible="false" runat="server" Text='<%# Eval("IsSocPasa")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="/MoralScience">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" CssClass="cusTextBox" Enabled="false" Text='<%# Eval("MoralScience")%>'
                                                    Width="25px" ID="txtmoralscience"></asp:TextBox>
                                                <asp:Label ID="lblismoralscpass" Visible="false" runat="server" Text='<%# Eval("IsMorScPass")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalMarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("TotalMarkrs")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pass Marks">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" CssClass="cusTextBox" Text='<%# Eval("TotalPassMarks")%>'
                                                    Width="30px" ID="txtpassmarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Marks Obtain">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmarksobtain" runat="server" Text='<%# Eval("TotalMarksObtain")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rank">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrank" runat="server" Text='<%# Eval("Ranks")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("ResultStatus")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPC" runat="server" Text='<%# Eval("Pc")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Attendance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblattendance" runat="server" Text='<%# Eval("Attendance")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AttPC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblattenPC" runat="server" Text='<%# Eval("APc")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="txtremarks" runat="server" Text='<%# Eval("Remarks")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Deliver By</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("DeliverBy")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Delivery Date</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("DeliverDate","{0:dd/MM/yyyy}")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Print</HeaderTemplate>
                                            <ItemTemplate>
                                                <a href="javascript: void(null);" style="color: red" onclick="PrintReportClasswise('<%# Eval("ClassID")%>','<%# Eval("SectionID")%>','<%# Eval("ExamID")%>','<%# Eval("AcademicSessionID")%>','<%# Eval("RollNo")%>'); return false;">
                                                    Print</a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
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
