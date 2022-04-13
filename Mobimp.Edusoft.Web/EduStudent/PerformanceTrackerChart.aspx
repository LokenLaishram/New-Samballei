<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="PerformanceTrackerChart.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduStudent.PerformanceChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">


        function Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlacademicseesions.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam Type.";
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
        //---------------tap2 validation---------------------------

        function Tap2Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlacademicseesionstap2.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesionstap2.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlclasstap2.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclasstap2.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsectionstap2.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select section.";
                document.getElementById("<%=ddlsectionstap2.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }

        //---------------tap3 validation---------------------------

        function Tap3Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlacademicseesionstap3.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesionstap3.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlclasstap3.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclasstap3.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtrollNo.ClientID%>").value == "") {
                str = str + "\n Please enter Roll no.";
                document.getElementById("<%=txtrollNo.ClientID %>").focus();
                i++;
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }
        //---------------tap4 validation---------------------------
        function Tap4Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlacademicseesionstap4.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesionstap4.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlclasstap4.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclasstap4.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexamtap4.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select type of exam.";
                document.getElementById("<%=ddlexamtap4.ClientID %>").focus();
                i++;
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }

        //---------------tap5 validation---------------------------
        function Tap5Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlacademicseesionstap5.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesionstap5.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlclasstap5.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclasstap5.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexamtap5.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select type of exam.";
                document.getElementById("<%=ddlexamtap5.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtrollNotap5.ClientID%>").value == "") {
                str = str + "\n Please enter Roll no.";
                document.getElementById("<%=txtrollNotap5.ClientID %>").focus();
                i++;
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
            <div class="container-fluid">
                <asp:TabContainer ID="examperformance" runat="server" CssClass="Tab" ActiveTabIndex="0">
                    <div class="col-lg-12">
                        <asp:TabPanel ID="tapclasswise" runat="server" HeaderText="Classwise Performance">
                            <ContentTemplate>
                                <div class="css3gradient">
                                    <div id="divmessage" style="height: 20px" runat="server">
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                                    <div class="col-lg-11" style="padding-left: 110px">
                                        <table class="table text-center">
                                            <tr>
                                                <td style="width: 50px">
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                                    <asp:DropDownList ID="ddlacademicseesions" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlexam" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                        OnSelectedIndexChanged="ddlexamtap1_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="text-align: right">
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClientClick="return Validate();"
                                                                Width="87px" OnClick="btnsearch_Click" />
                                                            <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnsearch" />
                                                            <asp:AsyncPostBackTrigger ControlID="btncancel" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="chartdiv" class="col-md-5 text-center" style="padding-left: 140px;">
                                        <asp:Chart ID="ExamChart" runat="server" Height="341px" Width=" 800px" BorderWidth="2"
                                            BackGradientStyle="Center">
                                            <Titles>
                                                <asp:Title Font="Arial, 15pt, style=Bold" Text="Classwise Exam Performance Analysis"
                                                    BackHatchStyle="LargeCheckerBoard" ForeColor="red" ShadowOffset="1" TextStyle="Default"
                                                    PostBackValue="25">
                                                </asp:Title>
                                            </Titles>
                                            <Series>
                                                <asp:Series Name="Series1" ChartArea="ExamAnalysisChart" IsValueShownAsLabel="True"
                                                    LabelBackColor="192, 192, 0" LabelBorderColor="Maroon">
                                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ExamAnalysisChart" BackColor="#D0E2E7" BackGradientStyle="TopBottom"
                                                    BackHatchStyle="Cross">
                                                    <AxisX Title="Class" LabelAutoFitMaxFontSize="8" Interval="Auto" IntervalAutoMode="VariableCount"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 15pt">
                                                    </AxisX>
                                                    <AxisY Title="Pass Percentage" MaximumAutoSize="55" LineColor="red" LabelAutoFitMaxFontSize="8"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 15pt" LabelAutoFitMinFontSize="8"
                                                        LabelAutoFitStyle="IncreaseFont">
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                        <div style="width: 75%" class="RtextAlign">
                                            <asp:Button ID="btnprint" runat="server" CssClass="button" Text="Print" OnClick="btnprint_Click" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </div>
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Examwise Performance">
                        <ContentTemplate>
                            <div class="css3gradient">
                                <div class="container">
                                    <div class="h5 text-center success">
                                        Examwise Performance</div>
                                    <div class="col-lg-12">
                                        <table class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblacademicsessiontap2" runat="server" Text="Academic Year"></asp:Label>
                                                    <asp:DropDownList ID="ddlacademicseesionstap2" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblclasstap2" runat="server" Text="Class"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlclasstap2" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                        OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblsectiontap2" runat="server" Text="Section"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlsectionstap2" AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="tap2btnsearch" runat="server" CssClass="button" Text="Search" OnClientClick="return Tap2Validate();"
                                                        Width="87px" OnClick="tap2btnsearch_Click" />
                                                    <asp:Button ID="tap2btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-lg-12" style="padding-left: 140px;">
                                        <asp:Chart ID="ClasswiseChart" runat="server" Width="800px" Height="341px" BorderWidth="2"
                                            BackGradientStyle="Center">
                                            <Titles>
                                                <asp:Title Font="Arial, 15pt, style=Bold" Text="Examwise Performance Analysis" BackHatchStyle="LargeCheckerBoard"
                                                    ForeColor="red" ShadowOffset="1" TextStyle="Default" PostBackValue="25">
                                                </asp:Title>
                                            </Titles>
                                            <Series>
                                                <asp:Series Name="Series1" ChartArea="ClasswiseAnalysisChart" IsValueShownAsLabel="True"
                                                    LabelBackColor="192, 192, 0" LabelBorderColor="Maroon">
                                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ClasswiseAnalysisChart" BackColor="#D0E2E7" BackGradientStyle="TopBottom"
                                                    BackHatchStyle="Cross">
                                                    <AxisX Title="Type of Exam" LabelAutoFitMaxFontSize="8" Interval="Auto" IntervalAutoMode="VariableCount"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 15pt">
                                                    </AxisX>
                                                    <AxisY Title="Pass Percentage" MaximumAutoSize="55" LineColor="red" LabelAutoFitMaxFontSize="8"
                                                        LabelAutoFitMinFontSize="8" TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 15pt"
                                                        LabelAutoFitStyle="IncreaseFont">
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                        <asp:Button ID="tap2btnprint" runat="server" CssClass="button" Text="Print" OnClick="tap2btnprint_Click" />
                                    </div>
                                </div>
                            </div>
                            /
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="Tab3student" runat="server" HeaderText="Studentwise Performance">
                        <ContentTemplate>
                            <div class="css3gradient">
                                <div class="container">
                                    <div class="h5 text-center success">
                                        Studentwise Performance</div>
                                    <div class="col-lg-12">
                                        <table class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblacademicseesionstap3" runat="server" Text="Academic Year"></asp:Label>
                                                    <asp:DropDownList ID="ddlacademicseesionstap3" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblclasstap3" runat="server" Text="Class"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlclasstap3" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                        OnSelectedIndexChanged="ddlclassestap3_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblsectiontap3" runat="server" Text="Section"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlsectiontap3" AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrollNo" runat="server" Text="Roll No"></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrollNo" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender1"
                                                        runat="server" ValidChars="0123456789" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="Search" OnClientClick="return Tap3Validate();"
                                                        Width="87px" OnClick="tap3btnsearch_Click" />
                                                    <asp:Button ID="Button2" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-lg-12" style="padding-left: 140px;">
                                        <asp:Chart ID="StudentwiseChart" runat="server" Width="800px" Height="341px" BorderWidth="2"
                                            BackGradientStyle="Center">
                                            <Titles>
                                                <asp:Title Font="Arial, 15pt, style=Bold" Text="Examwise Performance Analysis" BackHatchStyle="LargeCheckerBoard"
                                                    ForeColor="red" ShadowOffset="1" TextStyle="Default" PostBackValue="25">
                                                </asp:Title>
                                            </Titles>
                                            <Series>
                                                <asp:Series Name="Series1" ChartArea="ClasswiseAnalysisChart" IsValueShownAsLabel="True"
                                                    LabelBackColor="192, 192, 0" LabelBorderColor="Maroon">
                                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ClasswiseAnalysisChart" BackColor="#D0E2E7" BackGradientStyle="TopBottom"
                                                    BackHatchStyle="Cross">
                                                    <AxisX Title="Type of Exam" LabelAutoFitMaxFontSize="8" Interval="Auto" IntervalAutoMode="VariableCount"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 15pt">
                                                    </AxisX>
                                                    <AxisY Title="Pass Percentage" MaximumAutoSize="55" LineColor="red" LabelAutoFitMaxFontSize="8"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 15pt" LabelAutoFitMinFontSize="8"
                                                        LabelAutoFitStyle="IncreaseFont">
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                        <asp:Literal ID="ltEmbed" runat="server" />
                                        <asp:Button ID="Button3" runat="server" CssClass="button" Text="Print" OnClick="tap3btnprint_Click" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="Tab4subjectwise" runat="server" HeaderText="Subjectwise Performance">
                        <ContentTemplate>
                            <div class="css3gradient">
                                <div class="container">
                                    <div class="h5 text-center success">
                                        Subjectwise Performance</div>
                                    <div class="col-lg-12">
                                        <table class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblacademicseesionstap4" runat="server" Text="Academic Year"></asp:Label>
                                                    <asp:DropDownList ID="ddlacademicseesionstap4" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblclasstap4" runat="server" Text="Class"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlclasstap4" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                        OnSelectedIndexChanged="ddlclassestap4_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbltap4" runat="server" Text="Section"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlsectiontap4" AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblexamtap4" runat="server" Text="Exam"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlexamtap4" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                        OnSelectedIndexChanged="ddlexamtap4_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="tap4btnsearch" runat="server" CssClass="button" Text="Search" OnClientClick="return Tap4Validate();"
                                                        Width="87px" OnClick="tap4btnsearch_Click" />
                                                    <asp:Button ID="Button6" runat="server" CssClass="button" Text="Print" OnClick="tap4btnprint_Click" />
                                                    <asp:Button ID="tap4btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-lg-12" style="padding-left: 140px;">
                                        <asp:Chart ID="SubjectChart" runat="server" Width="800px" Height="341px" BorderWidth="2"
                                            BackGradientStyle="Center">
                                            <Titles>
                                                <asp:Title Font="Arial, 15pt, style=Bold" Text="Subjectwise Performance Analysis"
                                                    BackHatchStyle="LargeCheckerBoard" ForeColor="red" ShadowOffset="1" TextStyle="Default"
                                                    PostBackValue="25">
                                                </asp:Title>
                                            </Titles>
                                            <Series>
                                                <asp:Series Name="Series1" ChartArea="ClasswiseAnalysisChart" IsValueShownAsLabel="True"
                                                    LabelBackColor="192, 192, 0" LabelBorderColor="Maroon">
                                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ClasswiseAnalysisChart" BackColor="#D0E2E7" BackGradientStyle="TopBottom"
                                                    BackHatchStyle="Cross">
                                                    <AxisX Title="Subject Name" LabelAutoFitMaxFontSize="8" Interval="Auto" IntervalAutoMode="VariableCount"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 12pt">
                                                    </AxisX>
                                                    <AxisY Title="Pass Percentage" MaximumAutoSize="55" LineColor="red" LabelAutoFitMaxFontSize="8"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 12pt" LabelAutoFitMinFontSize="8"
                                                        LabelAutoFitStyle="IncreaseFont">
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Student Subjectwise Performance">
                        <ContentTemplate>
                            <div class="css3gradient">
                                <div class="container">
                                    <div class="h5 text-center success">
                                        Student Subjectwise Performance</div>
                                    <div class="col-lg-12">
                                        <table class="table">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblacademicseesionstap5" runat="server" Text="Academic Year"></asp:Label>
                                                    <asp:DropDownList ID="ddlacademicseesionstap5" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblclasstap5" runat="server" Text="Class"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlclasstap5" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                        OnSelectedIndexChanged="ddlclassestap5_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblsectiontap5" runat="server" Text="Section"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlsectiontap5" AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblexamtap5" runat="server" Text="Exam"></asp:Label><span style="color: #ff0000">*</span>
                                                    <asp:DropDownList ID="ddlexamtap5" AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrollnotap5" runat="server" Text="Roll No"></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                    <asp:TextBox ID="txtrollNotap5" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtrollNotap5" ID="FilteredTextBoxExtender2"
                                                        runat="server" ValidChars="0123456789" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btn5search" runat="server" CssClass="button" Text="Search" OnClientClick="return Tap5Validate();"
                                                        Width="87px" OnClick="tap5btnsearch_Click" />
                                                    <asp:Button ID="btn5cancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                                    <asp:Button ID="btn5print" runat="server" CssClass="button" Text="Print" OnClientClick="return Tap5Validate();"
                                                        OnClick="tap5btnprint_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-lg-12" style="padding-left: 140px;">
                                        <asp:Chart ID="studentsubject" runat="server" Width="800px" Height="341px" BorderWidth="2"
                                            BackGradientStyle="Center">
                                            <Titles>
                                                <asp:Title Font="Arial, 12pt, style=Bold" Text="Student Subjectwise Performance Analysis"
                                                    BackHatchStyle="LargeCheckerBoard" ForeColor="red" ShadowOffset="1" TextStyle="Default"
                                                    PostBackValue="25">
                                                </asp:Title>
                                            </Titles>
                                            <Series>
                                                <asp:Series Name="Series1" ChartArea="ClasswiseAnalysisChart" IsValueShownAsLabel="True"
                                                    LabelBackColor="192, 192, 0" LabelBorderColor="Maroon">
                                                    <SmartLabelStyle AllowOutsidePlotArea="Yes" />
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ClasswiseAnalysisChart" BackColor="#D0E2E7" BackGradientStyle="TopBottom"
                                                    BackHatchStyle="Cross">
                                                    <AxisX Title="Subject Name" LabelAutoFitMaxFontSize="8" Interval="Auto" IntervalAutoMode="VariableCount"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 12pt">
                                                    </AxisX>
                                                    <AxisY Title="Score Mark" MaximumAutoSize="55" LineColor="red" LabelAutoFitMaxFontSize="8"
                                                        TitleForeColor="Maroon" TitleFont="Microsoft Sans Serif, 12pt" LabelAutoFitMinFontSize="8"
                                                        LabelAutoFitStyle="IncreaseFont">
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
