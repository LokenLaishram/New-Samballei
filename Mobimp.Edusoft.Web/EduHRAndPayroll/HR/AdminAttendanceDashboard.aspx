<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdminAttendanceDashboard.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.HR.AdminAttendanceDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <link href="../../app-assets/dropdown/jquery.sweet-dropdown.min.css" rel="stylesheet" />
    <script src="../../app-assets/dropdown/jquery.sweet-dropdown.min.js"></script>

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>HR&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="AdminAttendanceDashboard.aspx">Attendance Dashboard</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSession" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlMonth" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
                                <asp:DropDownList ID="ddl_employee" AutoPostBack="true" OnSelectedIndexChanged="ddl_employee_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnSearch" class="btn btn-sm btn-info button" OnClick="btnSearch_Click" runat="server" Text="Search" OnClientClick="return Validate();" />
                                <asp:Button ID="btnPrint" Visible="false" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                <asp:Button ID="btnReset" Visible="false" class="btn btn-sm btn-danger button" OnClick="btnReset_Click" runat="server" Text="Reset" />
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
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_export"  OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                                <asp:DropDownList ID="ddl_show" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20"> 20 </asp:ListItem>
                                    <asp:ListItem Value="50"> 50 </asp:ListItem>
                                    <asp:ListItem Value="100"> 100 </asp:ListItem>
                                    <asp:ListItem Value="10000"> all</asp:ListItem>
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
                                    <div id="DIVloading" runat="server" class="Pageloader">
                                        <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                            AlternateText="Loading ..." ToolTip="Loading ..." />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>

                        <div id="AttendanceDashboard" class="col-md-12 customRow table-responsive" style="float: left; max-height: 51vh;overflow: auto">
                            <asp:GridView ID="GvAttendanceDashboard" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GvAttendanceDashboard_PageIndexChanging"
                                Style="width: 100%; " OnRowCommand="GvAttendanceDashboard_RowCommand" OnRowDataBound="GvAttendanceDashboard_RowDataBound" ShowFooter="true" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sl.No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Employee Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="Gv_EmployeeID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblEmployeeName" runat="server" Style="width: 200px; display: block;" Text='<%# Eval("EmployeeName")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblYearID" runat="server" Visible="false" Text='<%# Eval("YearID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblMonthID" runat="server" Visible="false" Text='<%# Eval("MonthID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total P
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalPresent" runat="server" Text='<%# Eval("TotalPresent")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total A
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalAbsent" runat="server" Text='<%# Eval("TotalAbsent")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total L
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalLeave" runat="server" Text='<%# Eval("TotalLeave")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total H
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_totalhalfday" runat="server" Text='<%# Eval("TotalHalfDay")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 1
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay1" Visible="false" runat="server" Text='<%# Eval("Day1")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus" runat="server" Text='<%# Eval("Day1Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus1" CommandName="ShowDropDown1" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day1Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status1" AutoPostBack="true" OnSelectedIndexChanged="ddl_status1_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 2
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay2" Visible="false" runat="server" Text='<%# Eval("Day2")%>'></asp:Label>
                                            <asp:Button ID="btnStatus2" data-dropdown="ddl_status2" CommandName="ShowDropDown2" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day2Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status2" AutoPostBack="true" OnSelectedIndexChanged="ddl_status2_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 3
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay3" Visible="false" runat="server" Text='<%# Eval("Day3")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus3" runat="server" Text='<%# Eval("Day3Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus3" CommandName="ShowDropDown3" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day3Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status3" AutoPostBack="true" OnSelectedIndexChanged="ddl_status3_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 4
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay4" Visible="false" runat="server" Text='<%# Eval("Day4")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus4" runat="server" Text='<%# Eval("Day4Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus4" CommandName="ShowDropDown4" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day4Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status4" AutoPostBack="true" OnSelectedIndexChanged="ddl_status4_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 5
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay5" Visible="false" runat="server" Text='<%# Eval("Day5")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus5" runat="server" Text='<%# Eval("Day5Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus5" CommandName="ShowDropDown5" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day5Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status5" AutoPostBack="true" OnSelectedIndexChanged="ddl_status5_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 6
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay6" Visible="false" runat="server" Text='<%# Eval("Day6")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus6" runat="server" Text='<%# Eval("Day6Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus6" CommandName="ShowDropDown6" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day6Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status6" AutoPostBack="true" OnSelectedIndexChanged="ddl_status6_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 7
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay7" Visible="false" runat="server" Text='<%# Eval("Day7")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus7" runat="server" Text='<%# Eval("Day7Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus7" CommandName="ShowDropDown7" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day7Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status7" AutoPostBack="true" OnSelectedIndexChanged="ddl_status7_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 8
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay8" Visible="false" runat="server" Text='<%# Eval("Day8")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus8" runat="server" Text='<%# Eval("Day8Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus8" CommandName="ShowDropDown8" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day8Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status8" AutoPostBack="true" OnSelectedIndexChanged="ddl_status8_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 9
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay9" Visible="false" runat="server" Text='<%# Eval("Day9")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus9" runat="server" Text='<%# Eval("Day9Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus9" CommandName="ShowDropDown9" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day9Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status9" AutoPostBack="true" OnSelectedIndexChanged="ddl_status9_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 10
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay10" Visible="false" runat="server" Text='<%# Eval("Day10")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus10" runat="server" Text='<%# Eval("Day10Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus10" CommandName="ShowDropDown10" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day10Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status10" AutoPostBack="true" OnSelectedIndexChanged="ddl_status10_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 11
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay11" Visible="false" runat="server" Text='<%# Eval("Day11")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus11" runat="server" Text='<%# Eval("Day11Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus11" CommandName="ShowDropDown11" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day11Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status11" AutoPostBack="true" OnSelectedIndexChanged="ddl_status11_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 12
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay12" Visible="false" runat="server" Text='<%# Eval("Day12")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus12" runat="server" Text='<%# Eval("Day12Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus12" CommandName="ShowDropDown12" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day12Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status12" AutoPostBack="true" OnSelectedIndexChanged="ddl_status12_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 13
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay13" Visible="false" runat="server" Text='<%# Eval("Day13")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus13" runat="server" Text='<%# Eval("Day13Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus13" CommandName="ShowDropDown13" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day13Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status13" AutoPostBack="true" OnSelectedIndexChanged="ddl_status13_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 14
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay14" Visible="false" runat="server" Text='<%# Eval("Day14")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus14" runat="server" Text='<%# Eval("Day14Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus14" CommandName="ShowDropDown14" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day14Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status14" AutoPostBack="true" OnSelectedIndexChanged="ddl_status14_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 15
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay15" Visible="false" runat="server" Text='<%# Eval("Day15")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus15" runat="server" Text='<%# Eval("Day15Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus15" CommandName="ShowDropDown15" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day15Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status15" AutoPostBack="true" OnSelectedIndexChanged="ddl_status15_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 16
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay16" Visible="false" runat="server" Text='<%# Eval("Day16")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus16" runat="server" Text='<%# Eval("Day16Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus16" CommandName="ShowDropDown16" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day16Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status16" AutoPostBack="true" OnSelectedIndexChanged="ddl_status16_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 17
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay17" Visible="false" runat="server" Text='<%# Eval("Day17")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus17" runat="server" Text='<%# Eval("Day17Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus17" CommandName="ShowDropDown17" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day17Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status17" AutoPostBack="true" OnSelectedIndexChanged="ddl_status17_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 18
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay18" Visible="false" runat="server" Text='<%# Eval("Day18")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus18" runat="server" Text='<%# Eval("Day18Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus18" CommandName="ShowDropDown18" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day18Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status18" AutoPostBack="true" OnSelectedIndexChanged="ddl_status18_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 19
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay19" Visible="false" runat="server" Text='<%# Eval("Day19")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus19" runat="server" Text='<%# Eval("Day19Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus19" CommandName="ShowDropDown19" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day19Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status19" AutoPostBack="true" OnSelectedIndexChanged="ddl_status19_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 20
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay20" Visible="false" runat="server" Text='<%# Eval("Day20")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus20" runat="server" Text='<%# Eval("Day20Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus20" CommandName="ShowDropDown20" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day20Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status20" AutoPostBack="true" OnSelectedIndexChanged="ddl_status20_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 21
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay21" Visible="false" runat="server" Text='<%# Eval("Day21")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus21" runat="server" Text='<%# Eval("Day21Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus21" CommandName="ShowDropDown21" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day21Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status21" AutoPostBack="true" OnSelectedIndexChanged="ddl_status21_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 22
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay22" Visible="false" runat="server" Text='<%# Eval("Day22")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus22" runat="server" Text='<%# Eval("Day22Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus22" CommandName="ShowDropDown22" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day22Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status22" AutoPostBack="true" OnSelectedIndexChanged="ddl_status22_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 23
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay23" Visible="false" runat="server" Text='<%# Eval("Day23")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus23" runat="server" Text='<%# Eval("Day23Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus23" CommandName="ShowDropDown23" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day23Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status23" AutoPostBack="true" OnSelectedIndexChanged="ddl_status23_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 24
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay24" Visible="false" runat="server" Text='<%# Eval("Day24")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus24" runat="server" Text='<%# Eval("Day24Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus24" CommandName="ShowDropDown24" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day24Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status24" AutoPostBack="true" OnSelectedIndexChanged="ddl_status24_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 25
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay25" Visible="false" runat="server" Text='<%# Eval("Day25")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus25" runat="server" Text='<%# Eval("Day25Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus25" CommandName="ShowDropDown25" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day25Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status25" AutoPostBack="true" OnSelectedIndexChanged="ddl_status25_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 26
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay26" Visible="false" runat="server" Text='<%# Eval("Day26")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus26" runat="server" Text='<%# Eval("Day26Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus26" CommandName="ShowDropDown26" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day26Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status26" AutoPostBack="true" OnSelectedIndexChanged="ddl_status26_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 27
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay27" Visible="false" runat="server" Text='<%# Eval("Day27")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus27" runat="server" Text='<%# Eval("Day27Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus27" CommandName="ShowDropDown27" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day27Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status27" AutoPostBack="true" OnSelectedIndexChanged="ddl_status27_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 28
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay28" Visible="false" runat="server" Text='<%# Eval("Day28")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus28" runat="server" Text='<%# Eval("Day28Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus28" CommandName="ShowDropDown28" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day28Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status28" AutoPostBack="true" OnSelectedIndexChanged="ddl_status28_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 29
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay29" Visible="false" runat="server" Text='<%# Eval("Day29")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus29" runat="server" Text='<%# Eval("Day29Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus29" CommandName="ShowDropDown29" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day29Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status29" AutoPostBack="true" OnSelectedIndexChanged="ddl_status29_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 30
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay30" Visible="false" runat="server" Text='<%# Eval("Day30")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus30" runat="server" Text='<%# Eval("Day30Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus30" CommandName="ShowDropDown30" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day30Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status30" AutoPostBack="true" OnSelectedIndexChanged="ddl_status30_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day 31
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay31" Visible="false" runat="server" Text='<%# Eval("Day31")%>'></asp:Label>
                                            <%--<asp:Label ID="Gv_lblAttendanceStatus31" runat="server" Text='<%# Eval("Day31Status")%>'></asp:Label>--%>
                                            <asp:Button ID="btnStatus31" CommandName="ShowDropDown31" CssClass="AttendanceDesign" runat="server" Text='<%# Eval("Day31Status")%>' CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" />
                                            <asp:DropDownList runat="server" ID="ddl_status31" AutoPostBack="true" OnSelectedIndexChanged="ddl_status31_SelectedIndexChanged" Visible="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">P</asp:ListItem>
                                                <asp:ListItem Value="2">A</asp:ListItem>
                                                <asp:ListItem Value="3">L</asp:ListItem>
                                                <asp:ListItem Value="4">H</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <script type="text/javascript">       
        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#AttendanceDashboard table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlMonth.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Month. \n"
                document.getElementById("<%=ddlMonth.ClientID %>").focus()
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


        $(function () {
            $('[id*=GvAttendanceDashboard]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvAttendanceDashboard]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#AttendanceDashboard table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

    </script>

    <style>
        .AttendanceDesign {
            cursor: pointer;
            /*background: #45d733;*/
            display: block;
            width: 28px;
            border-radius: 50%;
            color: white;
            /*text-decoration: underline;*/
            height: 28px;
        }
    </style>
</asp:Content>
