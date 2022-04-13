<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="ManageAssignment.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.TeacherPortal.ELearning.ManageAssignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
            <div class="container-fluid" id="page_wrapper">
                <ol class="breadcrumb">
                    <li>E-Learning&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a1" href="~/TeacherPortal/Elearning/DailyTeacherLiveClassList.aspx">Online Class</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a class="active" runat="server" id="a5" href="~/TeacherPortal/Elearning/ManageAssignment.aspx">Assignment</a></li>
                </ol>
                <div id="divMain" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblAcademicSession" Text="Academic Session"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList runat="server" ID="ddlAcademicSessionID" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblTeacherName" Text="Teacher"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtTeacherName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:Label ID="lblhiddenID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenAcademicSessionID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenClassID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenSectionID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenSubjectID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenClassName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenSectionName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenSubjectName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenTitle" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenAddedDate" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenLastDate" runat="server" Visible="false"></asp:Label>
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
                                        <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size: 48px;"></i></asp:LinkButton>
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
                            <div id="TeacherAssignmentList" class="col-md-12 customRow">
                                <asp:GridView ID="GvTeacherAssignment" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvTeacherAssignment_PageIndexChanging"
                                    CssClass="footable table-striped" AllowSorting="true" OnSorting="GvTeacherAssignment_Sorting" OnRowCommand="GvTeacherAssignment_RowCommand" runat="server" AutoGenerateColumns="false"
                                    Style="width: 100%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl.No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                                <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                <asp:Label ID="lbl_SessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                <asp:Label ID="lbl_TeacherID" Visible="false" runat="server" Text='<%# Eval("TeacherID")%>'></asp:Label>
                                                <asp:Label ID="lbl_ClassID" runat="server" Visible="false" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                <asp:Label ID="lbl_SectionID" runat="server" Visible="false" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                <asp:Label ID="lbl_SubjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>

                                                <asp:Label ID="lbl_SessionName" Visible="false" runat="server" Text='<%# Eval("AcademicSessionName")%>'></asp:Label>
                                                <asp:Label ID="lbl_ClassDetail" runat="server" Visible="false" Text='<%# Eval("ClassDetail")%>'></asp:Label>
                                                <asp:Label ID="lbl_ClassName" runat="server" Visible="false" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                <asp:Label ID="lbl_SectionName" runat="server" Visible="false" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                <asp:Label ID="lbl_SubjectName" Visible="false" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="0.2%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ClassDetail" SortExpression="ClassDetail" HeaderText="Class" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" ItemStyle-Width="1%" Visible="false" />
                                        <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Subject" ItemStyle-Width="1%" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Assignment
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_Add" Text="Add" CssClass="btn btn-success cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Add" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="0.3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Total Assignment
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk_TotalAssignment" CssClass="small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="TotalAssignment" ValidationGroup="none" Text='<%# Eval("TotalAssignment")%>' Font-Bold="true" Font-Underline="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TotalStudent" SortExpression="TotalStudent" HeaderText="Total Student" ItemStyle-Width="1%" />
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                    <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <%--Add Assignment--%>
                <div id="divAddAssignment" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="row col-md-12">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="Label1" Text="Class"></asp:Label>
                                        <asp:TextBox ID="txt_divAddClass" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <asp:Label runat="server" ID="Label2" Text="Section"></asp:Label>
                                    <asp:TextBox ID="txt_divAddSection" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="Label3" Text="Subject"></asp:Label>
                                        <asp:TextBox ID="txt_divAddSubject" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3 customRow" style="margin-top: 2em">
                                    <div class="form-group">
                                        <asp:Label runat="server" Font-Bold="true" ID="lblErrorMsg" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row col-md-12">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblAssignmentTitle" Text="Title"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txtAssignmentTitle" runat="server" class="form-control" MaxLength="200"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <asp:Label runat="server" ID="lblLastDate" Text="Last Date of Submission"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtLastDate" type="text" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy" TargetControlID="txtLastDate" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtLastDate" />
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblAssignment" Text="Assignment"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="form-group" style="margin-top: 0.6em;">
                                                    <asp:FileUpload ID="FileUploader" runat="server" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="row col-md-12">
                                <div class="col-md-8 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblRemark" Text="Remark"></asp:Label>
                                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" Style="max-height: 140px; min-height: 35px" class="form-control" MaxLength="500"
                                            placeholder="(Optional)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.6em;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnSaveAsgmt" runat="server" class="btn btn-sm btn-success button" Text="Save" OnClick="btnSaveAsgmt_Click" />
                                                <asp:Button ID="btnCancelAsgmt" runat="server" class="btn btn-sm btn-danger button" Text="Cancel" OnClick="btnCancelAsgmt_Click" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnSaveAsgmt" />
                                                <asp:PostBackTrigger ControlID="btnCancelAsgmt" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--Assignment List--%>
                <div id="divAssignmentList" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="row col-md-12">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblClass" Text="Class"></asp:Label>
                                        <asp:DropDownList ID="ddlClassID" runat="server" class="form-control" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-1 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblSection" Text="Section"></asp:Label>
                                        <asp:DropDownList ID="ddlSectionID" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSectionID_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblSubject" Text="Subject"></asp:Label>
                                        <asp:DropDownList ID="ddlSubjectID" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblAsgmtListTitle" Text="Title"></asp:Label>
                                        <asp:TextBox ID="txtAsgmtListTitle" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetAutoTeachingStaffList" MinimumPrefixLength="1"
                                            CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtAsgmtListTitle" UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                        </asp:AutoCompleteExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="row col-md-12">
                                <div class="col-md-3 customRow">
                                    <asp:Label runat="server" ID="lblFrom" Text="From"></asp:Label>
                                    <asp:TextBox ID="txtFromDate" type="text" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy" TargetControlID="txtFromDate" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFromDate" />
                                </div>
                                <div class="col-md-3 customRow">
                                    <asp:Label runat="server" ID="lblTo" Text="To"></asp:Label>
                                    <asp:TextBox ID="txtToDate" type="text" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy" TargetControlID="txtToDate" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtToDate" />
                                </div>
                                <div class="col-md-5 customRow">
                                    <div class="form-group pull-left" style="margin-top: 1.8em;">
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-info button" Text="Search" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                                <div class="col-sm-1 customRow pull-right">
                                    <div class="form-group" style="margin-top: 1.8em;">
                                        <asp:LinkButton ID="lnkAsgmtListBack" OnClick="lnkAsgmtListBack_Click" runat="server" class="btn btn-sm btn-danger button">
                                            <i class="fa fa-arrow-left"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card_wrapper">
                        <div class="row pad15">
                            <div class="col-md-4 customRow" style="margin-top: 13px;">
                                <asp:Label ID="lblAsgmtListResult" runat="server"></asp:Label>
                                <asp:Label ID="lblAsgmtList_TotalRecords" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkbtn_AsgmtList_Export" OnClick="lnkbtn_AsgmtList_Export_Click" runat="server"><i class="ficon icon-export" style="font-size: 48px;"></i></asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="lnkbtn_AsgmtList_Export" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                <asp:Label ID="lblShow_AsgmtList" Text="Show" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-1 customRow">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlAsmtList_Show" AutoPostBack="true" OnSelectedIndexChanged="ddlAsmtList_Show_SelectedIndexChanged" runat="server" class="form-control">
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="20"> 20 </asp:ListItem>
                                        <asp:ListItem Value="50"> 50 </asp:ListItem>
                                        <asp:ListItem Value="100"> 100 </asp:ListItem>
                                        <asp:ListItem Value="10000"> all</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4 customRow">
                                <input type="text" class="searchAsgmtList form-control" placeholder="search..">
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloadingAsgmtList" runat="server" class="Pageloader">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div id="SubAsgmtList" class="col-md-12 customRow" style="margin-top: 1em">
                                <asp:GridView ID="GvAsgmtList" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="footable table-striped" runat="server"
                                    Style="width: 100%" GridLines="None" OnRowCommand="GvAsgmtList_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl.No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                                <asp:Label ID="lbl_AsgmtID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                <asp:Label ID="lbl_AsgmtClassName" runat="server" Visible="false" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                <asp:Label ID="lbl_AsgmtSectionName" runat="server" Visible="false" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                <asp:Label ID="lbl_AsgmtSubjectName" Visible="false" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                <asp:Label ID="lbl_AsgmtTitle" Visible="false" runat="server" Text='<%# Eval("Title")%>'></asp:Label>
                                                <asp:Label ID="lbl_AsgmtAddedDate" Visible="false" runat="server" Text='<%# Eval("AddedDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                <asp:Label ID="lbl_AsgmtLastDate" Visible="false" runat="server" Text='<%# Eval("LastDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ClassDetail" SortExpression="ClassDetail" HeaderText="Class" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" ItemStyle-Width="1%" Visible="false" />
                                        <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Subject" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="Title" SortExpression="Title" HeaderText="Title" ItemStyle-Width="2%" />
                                        <asp:BoundField DataField="Remark" SortExpression="Remark" HeaderText="Remark" ItemStyle-Width="2%" />
                                        <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Added On" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="LastDate" SortExpression="LastDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Last Date" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="TotalStudent" SortExpression="TotalStudent" HeaderText="Total Student" ItemStyle-Width="1%" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Total Submitted
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk_TotalSubmitted" CssClass="small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Submitted" ValidationGroup="none" Text='<%# Eval("TotalSubmitted")%>' Font-Bold="true" Font-Underline="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Total Pending
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk_TotalPending" CssClass="small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Pending" ValidationGroup="none" Text='<%# Eval("TotalPending")%>' Font-Bold="true" Font-Underline="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <%--Total Submitted--%>
                <div id="divTotalSubmitted" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="row col-md-12">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="Class"></asp:Label>
                                        <asp:TextBox ID="txtSubmittedClass" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Section"></asp:Label>
                                        <asp:TextBox ID="txtSubmittedSection" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" Text="Subject"></asp:Label>
                                        <asp:TextBox ID="txtSubmittedSubject" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label10" runat="server" Text="Assignment Title"></asp:Label>
                                        <asp:TextBox ID="txtSubmittedTitle" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label13" runat="server" Text="Last Date of Submission"></asp:Label>
                                        <asp:TextBox ID="txtSubmittedLastDate" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-1 customRow pull-right">
                                    <div class="form-group" style="margin-top: 1.8em;">
                                        <asp:LinkButton ID="btnTotalSubmitted_Back" OnClick="btnTotalSubmitted_Back_Click" runat="server" class="btn btn-sm btn-danger button">
                                            <i class="fa fa-arrow-left"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="col-md-12 customRow" style="margin-top: 1em">
                                <asp:GridView ID="GvTotalSubmittedStudents" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="footable table-striped" runat="server"
                                    Style="width: 100%" GridLines="None" OnRowCommand="GvTotalSubmittedStudents_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl.No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student ID
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_SubmittedStdID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student Name
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_SubmittedStdName" runat="server" Text='<%# Eval("StudentDetail")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Roll No
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_SubmittedRollNo" Text='<%# Eval("RollNo")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Action
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_SubmittedStatusID" Visible="false" runat="server" Text='<%# Eval("SubmissionStatusID")%>'></asp:Label>
                                                <asp:Button ID="btn_Action" Text="View" CssClass="btn btn-success cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="View" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField>
                                            <HeaderTemplate>
                                                Remark
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_SubmittedRemarks" Class="form-control" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Remark
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_SubmittedRemarks" Class="form-control" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <%--Total Pending--%>
                <div id="divTotalPending" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="row col-md-12">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label7" runat="server" Text="Class"></asp:Label>
                                        <asp:TextBox ID="txtPendingClass" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label8" runat="server" Text="Section"></asp:Label>
                                        <asp:TextBox ID="txtPendingSection" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" Text="Subject"></asp:Label>
                                        <asp:TextBox ID="txtPendingSubject" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" Text="Assignment Title"></asp:Label>
                                        <asp:TextBox ID="txtPendingTitle" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label12" runat="server" Text="Last Date of Submission"></asp:Label>
                                        <asp:TextBox ID="txtPendingLastDate" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-1 customRow pull-right">
                                    <div class="form-group" style="margin-top: 1.8em;">
                                        <asp:LinkButton ID="btnTotalPending_Back" OnClick="btnTotalPending_Back_Click" runat="server" class="btn btn-sm btn-danger button">
                                            <i class="fa fa-arrow-left"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="col-md-12 customRow" style="margin-top: 1em">
                                <asp:GridView ID="GvTotalPendingStudents" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="footable table-striped" runat="server"
                                    Style="width: 100%" GridLines="None" OnRowDataBound="GvTotalPendingStudents_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl.No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student ID
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_PendingStdID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student Name
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_PendingStdName" runat="server" Text='<%# Eval("StudentDetail")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Roll No
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_PendingRollNo" Text='<%# Eval("RollNo")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Status
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_PendingStatusID" Visible="false" runat="server" Text='<%# Eval("SubmissionStatusID")%>'></asp:Label>
                                                <asp:Label ID="lbl_PendingSubmissionStatus" runat="server" Text="Viewed" Font-Bold="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%"/>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#TeacherAssignmentList table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        <%--function Validate() {
            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlDayID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Day \n"
                document.getElementById("<%=ddlDayID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtDate.ClientID%>").value == "") {
                str = str + "\n Please select Date";
                document.getElementById("<%=txtDate.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtTeacherName.ClientID%>").value == "") {
                str = str + " Please check Teacher \n"
                document.getElementById("<%=txtTeacherName.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false;
            }
            else {
                return true;
            }
        }--%>

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
            $('[id*=GvTeacherAssignment]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvTeacherAssignment]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#TeacherAssignmentList table tbody tr').each(function () {
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
            $('.searchAsgmtList').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SubAsgmtList table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        $(function () {
            $('[id*=GvAsgmtList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvAsgmtList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SubAsgmtList table tbody tr').each(function () {
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

</asp:Content>
