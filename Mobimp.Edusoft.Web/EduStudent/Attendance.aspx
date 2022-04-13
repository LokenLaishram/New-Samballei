<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="Attendance.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduStudent.Attendance" %>

<%@ Register Src="~/UserControls/MultiselectDropDown.ascx" TagName="MultiselectDropDown"
    TagPrefix="thp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="ContentAttendance" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduStudent/Attendance.aspx">Attendance</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabStudentAttendance"><i class="icon nalika-edit" aria-hidden="true"></i>Student List</a></li>
                <li><a href="#tabAttendanceList"><i class="icon nalika-picture" aria-hidden="true"></i>Attendance List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabStudentAttendance">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlAcademicSessionID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Class"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlClass" AutoPostBack="true" runat="server" class="form-control " OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Section"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlSectionID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Roll No"></asp:Label>
                                            <asp:TextBox ID="txtRollNo" runat="server" class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                Enabled="True" TargetControlID="txtRollNo" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="Attendance For"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtAttendanceDay" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtAttendanceDay" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtAttendanceDay" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.6em;">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-info button " Text="Search" OnClick="btnSearch_Click" OnClientClick="return Validate()" />
                                            <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                            <asp:Button ID="btnprint" Visible="false" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printstudentlist();" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper" id="divsearch" runat="server">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_export" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlshow" AutoPostBack="true" OnSelectedIndexChanged="ddlshow_SelectedIndexChanged" runat="server" class="form-control">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="20"> 20 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> All</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <input type="text" class="searchs form-control" placeholder="search..">
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="AttendanceList" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvAttendance" EmptyDataText="No record found..." OnPageIndexChanging="GvAttendance_PageIndexChanging"
                                           CssClass="footable table-striped" AllowSorting="true" OnRowDataBound="GvAttendance_RowDataBound" OnSorting="GvAttendance_Sorting" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:BoundField DataField="StudentID" SortExpression="StudentID" HeaderText="Student ID" ItemStyle-Width="1%" />
                                                <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Name" ItemStyle-Width="1%"/>
                                                <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" ItemStyle-Width="1%" />
                                                <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" ItemStyle-Width="1%" />
                                                <asp:BoundField DataField="RollNo" SortExpression="RollNo" HeaderText="RollNo" ItemStyle-Width="1%" />
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>Class</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>Sec</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>Category</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategoryID" Visible="false" runat="server" Text='<%# Eval("StudentCategory")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblattendanceID" Visible="false" runat="server" Text='<%# Eval("AttendanceID")%>'></asp:Label>
                                                        <asp:DropDownList ID="ddlattendance" Class="form-control" runat="server">
                                                            <asp:ListItem Value="1">Present</asp:ListItem>
                                                            <asp:ListItem Value="2">Absent</asp:ListItem>
                                                            <asp:ListItem Value="3">Leave</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarks" Class="form-control" runat="server" Text='<%# Eval("Remarks")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-12 customRow">
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-left" style="margin-top: 1em;">
                                                <asp:Label ID="Label23" runat="server" Text="Total Present : "></asp:Label>
                                                <asp:Label ID="lblPresent" runat="server" class="form-control " />
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-left" style="margin-top: 1em;">
                                                <asp:Label ID="Label25" runat="server" Text="Total Absent : "></asp:Label>
                                                <asp:Label ID="lblAbsent" runat="server" class="form-control " />
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-left" style="margin-top: 1em;">
                                                <asp:Label ID="Label26" runat="server" Text="Total On Leave : "></asp:Label>
                                                <asp:Label ID="lblLeave" runat="server" class="form-control " />
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-right" style="margin-top: 2em;">
                                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-sm btn-info button " Text="Update" OnClick="btnUpdate_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="tabAttendanceList">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessageTab2" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label12" runat="server" Text="Academic Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlAcademicSessionTab2" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label15" runat="server" Text="Class"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlClassTab2" AutoPostBack="true" runat="server" class="form-control " OnSelectedIndexChanged="ddlClassTab2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label16" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlSectionTab2" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label17" runat="server" Text="Roll No"></asp:Label>
                                            <asp:TextBox ID="txtRollNoTab2" runat="server" class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                Enabled="True" TargetControlID="txtRollNoTab2" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label11" runat="server" Text="Date From"></asp:Label>
                                            <%--<span class="mandatory_field">*</span><span style="color: #ff0000"></span>--%>
                                            <asp:TextBox ID="txtFrom" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label22" runat="server" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="txtTo" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTo" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-9 customRow">
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.6em;">
                                            <asp:Button ID="btnSearchTab2" runat="server" class="btn btn-sm btn-info button " Text="Search" OnClick="btnSearchTab2_Click" OnClientClick="return ValidateTab2()" />
                                            <asp:Button ID="btnResetTab2" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnResetTab2_Click" />
                                            <asp:Button ID="btnPrintTab2" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintstudentAttendancelist();" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper" id="divsearchTab2" runat="server">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresultTab2" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecordsTab2" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btnexportTab2" OnClick="btnexportTab2_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnexportTab2" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="Label24" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlShowTab2" AutoPostBack="true" OnSelectedIndexChanged="ddlShowTab2_SelectedIndexChanged" runat="server" class="form-control">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="20"> 20 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> All</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <input type="text" class="searchs form-control" placeholder="search..">
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloadingTab2" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgressTab2" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="AttendanceListTab2" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvAttendanceTab2" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvAttendanceTab2_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnSorting="GvAttendanceTab2_Sorting" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:BoundField DataField="StudentID" ItemStyle-Width="1%" SortExpression="StudentID" HeaderText="Student ID" />
                                                <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Name" />
                                                <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" />
                                                <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" />
                                                <asp:BoundField DataField="RollNo" SortExpression="RollNo" HeaderText="RollNo" />
                                                <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" HeaderText="Date" />
                                                <asp:BoundField DataField="Attendance" SortExpression="RollNo" HeaderText="Attendance" />
                                                <asp:BoundField DataField="DaysName" SortExpression="DaysName" HeaderText="Day" />
                                                <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="Added By" />
                                                <%--<asp:TemplateField Visible="false">
                                                    <HeaderTemplate>Class</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>Sec</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtattendance" runat="server" Class="form-control" Text='<%# Eval("Attendance")%>' />
                                                        <%--<asp:FilteredTextBoxExtender TargetControlID="txtatend" ID="FilteredTextBoxExtender1"
                                                            runat="server" ValidChars="0123456789" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-12 customRow">
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-left" style="margin-top: 1.6em;">
                                                <asp:Label ID="Label33" runat="server" Text="Total Working Days"></asp:Label>
                                                <asp:Label ID="lblTotalWD" runat="server" class="form-control " />
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-left" style="margin-top: 1.6em;">
                                                <asp:Label ID="Label27" runat="server" Text="Total Present"></asp:Label>
                                                <asp:Label ID="lblTotalPre" runat="server" class="form-control " />
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-left" style="margin-top: 1.6em;">
                                                <asp:Label ID="Label29" runat="server" Text="Total Absent"></asp:Label>
                                                <asp:Label ID="lblTotalAb" runat="server" class="form-control " />
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-left" style="margin-top: 1.6em;">
                                                <asp:Label ID="Label31" runat="server" Text="Total On Leave"></asp:Label>
                                                <asp:Label ID="lblTotalLeave" runat="server" class="form-control " />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        function successalert(str) {
            swal({
                title: "",
                text: str,
                icon: "success",
            });
        }
        function failalert(str) {
            swal({
                title: "",
                text: str,
                icon: "warning",
            });
        }
        function functionConfirm(event) {
            var row = event.parentNode.parentNode;
            var paramID = row.rowIndex - 1;
            swal({
                title: "Are you sure?",
                text: "Once deleted, you will not be able to recover this imaginary file!",

                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=GvAttendance.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlAcademicSessionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Academic Session."
                document.getElementById("<%=ddlAcademicSessionID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlClass.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Class."
                document.getElementById("<%=ddlClass.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlSectionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Section."
                document.getElementById("<%=ddlSectionID.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false
            }
            else {
                return true
            }
        }

        function ValidateTab2() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlAcademicSessionTab2.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Academic Session."
                document.getElementById("<%=ddlAcademicSessionTab2.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlClassTab2.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Class."
                document.getElementById("<%=ddlClassTab2.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false
            }
            else {
                return true
            }
        }

        $(function () {

            $('[id*=GvAttendance]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvAttendance]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#AttendanceList table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        $(document).ready(function () {

            $(window).scroll(function () {
                if ($(this).scrollTop() > 50) {
                    $('#back-to-top').fadeIn();
                } else {
                    $('#back-to-top').fadeOut();
                }
            });
            // scroll body to 0px on click
            $('#back-to-top').click(function () {
                $('#back-to-top').tooltip('hide');
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });

            $('#back-to-top').tooltip('show');

        });

        function PrintstudentAttendancelist() {
            var str = ""
            var i = 0
            objacademicID = document.getElementById("<%= ddlAcademicSessionTab2.ClientID %>")
            objClassID = document.getElementById("<%= ddlClassTab2.ClientID %>")
            objSection = document.getElementById("<%= ddlSectionTab2.ClientID %>")
            objrollnos = document.getElementById("<%= txtRollNoTab2.ClientID %>")
            objDatefrom = document.getElementById("<%= txtFrom.ClientID %>")
            objDateto = document.getElementById("<%= txtTo.ClientID %>")

            if (document.getElementById("<%=ddlClassTab2.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Class."
                document.getElementById("<%=ddlClassTab2.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false
            }

            else {
                window.open("../EduStudent/Reports/ReportViewer.aspx?option=AttendanceList&SessionID=" + objacademicID.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&RollNo=" + objrollnos.value  + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value)
                return true;
            }
        }

    </script>

</asp:Content>
