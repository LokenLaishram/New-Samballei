<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="AttendanceDashboard.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.HR.AttendanceDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
       <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>HR&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHRAndPayroll/HR/AttendanceDashboard.aspx">Attendance Dashboard</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                                <asp:DropDownList ID="ddlSession" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnSearch" class="btn btn-sm btn-info button" OnClick="btnSearch_Click" runat="server" Text="Search" />
                                <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card_wrapper">
                    <div class="row pad15">
                        <div class="col-md-4 customRow" style="margin-top: 13px;">
                            <asp:Label ID="lblresult" runat="server"></asp:Label>
                            <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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

                        <div id="AttendanceDashboard" class="col-md-12 customRow ">
                            <asp:GridView ID="GvAttendanceDashboard" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%" OnPageIndexChanging="GvAttendanceDashboard_PageIndexChanging">
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
                                            Year
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblYearID" Visible="false" runat="server" Text='<%# Eval("YearID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblYear" runat="server" Text='<%# Eval("Year")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Month
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblMonthID" Visible="false" runat="server" Text='<%# Eval("MonthID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblMonth" runat="server" Text='<%# Eval("Month")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Date
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDate" runat="server" Text='<%# Eval("Date","{0:dd-MM-yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Day
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDay" runat="server" Text='<%# Eval("Day")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            In Time
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblInTime" runat="server" Text='<%# Eval("InTime","{0:dd-MM-yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Out Time
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblOutTime" runat="server" Text='<%# Eval("OutTime","{0:dd-MM-yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Working Hour
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblWorkingHour" runat="server" Text='<%# Eval("WorkingHour","{0:dd-MM-yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            In/Out Remark
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblInOutRemark" runat="server" Text='<%# Eval("InOutRemark")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Status
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblAttendanceStatus" runat="server" Text='<%# Eval("AttendanceStatus")%>'></asp:Label>
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

</asp:Content>
