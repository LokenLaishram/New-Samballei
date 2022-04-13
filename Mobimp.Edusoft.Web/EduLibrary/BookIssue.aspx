<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="BookIssue.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.EduLibrary.BookIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Add Book&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a6" href="../EduLibrary/BookIssue.aspx">Book Issue </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabbookissue"><i class="icon nalika-edit" aria-hidden="true"></i>Book Issue</a></li>
                <li><a href="#tabbookissuelist"><i class="icon nalika-picture" aria-hidden="true"></i>Book Issue List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabbookissue">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbltype" Text="Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddltype" AutoPostBack="true" runat="server" class="form-control " OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Student</asp:ListItem>
                                                <asp:ListItem Value="2">Employee </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-5 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudent" runat="server" Text="Details"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" AutoPostBack="True" class="form-control"
                                                ID="txtstudent" OnTextChanged="studentdetail_OnTextChanged"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudent" ID="FilteredTextBoxExtender1"
                                                runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890|-: ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetStudentDetails"
                                                MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                                CompletionSetCount="1" TargetControlID="txtstudent" DelimiterCharacters="" UseContextKey="true">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-5 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbook" runat="server" Text="BooksDetails"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" AutoPostBack="True" class="form-control"
                                                OnTextChanged="bookdetail_OnTextChanged" ID="txtbook"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtbook" ID="FilteredTextBoxExtendertxtstddetail"
                                                runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890|-: ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetBooksDetails"
                                                MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                                CompletionSetCount="1" TargetControlID="txtbook" UseContextKey="True" DelimiterCharacters="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <asp:Label ID="lblqty" runat="server" Text="Qty"></asp:Label>
                                        <asp:TextBox ID="txtqty" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblissuedate" runat="server" Text="Issue Date"></asp:Label>
                                            <asp:TextBox ID="txtissuedate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtissuedate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtissuedate" />

                                            <asp:HiddenField runat="server" ID="hdnstudentid" />
                                            <asp:HiddenField runat="server" ID="hdnclassid" />
                                            <asp:HiddenField runat="server" ID="hdnbookid" />
                                            <asp:HiddenField runat="server" ID="hdngroupid" />
                                            <asp:HiddenField runat="server" ID="hdnsubgroupid" />
                                            <asp:HiddenField runat="server" ID="hdngroupname" />
                                            <asp:HiddenField runat="server" ID="hdnsubgroupname" />
                                            <asp:HiddenField runat="server" ID="hdnbookname" />
                                            <asp:HiddenField runat="server" ID="hdnhid" />
                                            <asp:HiddenField runat="server" ID="hdnissueno" />
                                            <asp:HiddenField runat="server" ID="hdnacademicid" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblreturndate" runat="server" Text="Return Date"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtreturndate" type="text" runat="server" class="form-control" OnTextChanged="txtreturndate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtreturndate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtreturndate" />
                                        </div>
                                    </div>
                                    <div class="col-md-5 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="height: 160px; width: 100%; overflow: auto; padding: 5px 0px 10px 0px;">
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
                                    <div id="Racklist" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvBookIssueDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" OnRowCommand="GvBookIssueDetails_RowCommand" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        SL No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblslno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Group">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgroup" runat="server" Text='<%# Eval("GroupName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SubGroup">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsubgroup" runat="server" Text='<%# Eval("SubGroupName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Books">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbHID" runat="server" Text='<%# Eval("HID")%>'></asp:Label>
                                                        <asp:Label ID="lblbookname" runat="server" Text='<%# Eval("Books")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Issue Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("IssueDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Return Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReturnDate" runat="server" Text='<%# Eval("ReturnDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblqty" runat="server" Text='<%# Eval("Qty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                            CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
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
                            <div id="bottomFeeCollection" runat="server">
                                <div class="col-md-3 customRow">
                                    Total Book Issue Qty :
                                          <asp:Label ID="lbltotalqty" Text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 customRow" style="text-align: right">
                                <div class="RtextAlign" style="padding: 0px 0px 0px 0px;">
                                    <asp:Button ID="btnsave" Class="btn btn-sm btn-green button" OnClick="btnsave_Click" runat="server" Text="Save"
                                        OnClientClick="javascript: return confirm('Are you sure to save it ?');" />
                                    <asp:Button ID="btnprint" Class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintBookIssueReciept()" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="product-tab-list tab-pane" id="tabbookissuelist">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage2" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbltype2" Text="Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddltype2" AutoPostBack="true" runat="server" class="form-control " OnSelectedIndexChanged="ddltype2_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Student</asp:ListItem>
                                                <asp:ListItem Value="2">Employee </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-5 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudent2" runat="server" Text="Details"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" AutoPostBack="True" class="form-control"
                                                ID="txtstudent2" OnTextChanged="studentdetail2_OnTextChanged"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudent2" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890|-: ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServiceMethod="GetStudentDetails2"
                                                MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                                CompletionSetCount="1" TargetControlID="txtstudent2" UseContextKey="True" DelimiterCharacters="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-5 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbook2" runat="server" Text="BooksDetails"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" AutoPostBack="True" class="form-control"
                                                OnTextChanged="bookdetail2_OnTextChanged" ID="txtbook2"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtbook2" ID="FilteredTextBoxExtender3"
                                                runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890|-: ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" ServiceMethod="GetBooksDetails2"
                                                MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                                CompletionSetCount="1" TargetControlID="txtbook2" UseContextKey="True" DelimiterCharacters="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblstatus" Text="Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstatus2" AutoPostBack="true" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldatefrom2" runat="server" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="txtdatefrom2" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtdatefrom2" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdatefrom2" />

                                            <asp:HiddenField runat="server" ID="hdnstudentid2" />
                                            <asp:HiddenField runat="server" ID="hdnclassid2" />
                                            <asp:HiddenField runat="server" ID="hdnissueno2" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lbldateto2" runat="server" Text="Date To"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtdateto2" type="text" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtdateto2" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdateto2" />
                                        </div>
                                    </div>
                                    <div class="col-md-5 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btncancel2" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel2_Click" />
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
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading1" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgress1" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="Bookissuelist2" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvBookissuelist" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvBookissuelist_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnSorting="GvBookissuelist_Sorting" OnRowCommand="GvBookissuelist_RowCommand" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%" OnRowDataBound="GvBookissuelist_OnRowDataBound" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <a href="JavaScript:ItemChildGridview('div<%# Eval("IssueNo") %>');">
                                                            <img alt="Detail" id="imgdiv<%# Eval("IssueNo") %>" src="../EduImages/plus.gif" />
                                                        </a>
                                                        <div id="div<%# Eval("IssueNo") %>" style="display: none;">
                                                            <asp:GridView ID="GridChild" runat="server" AutoGenerateColumns="false" DataKeyNames="IssueNo"
                                                                CssClass="ChildGrid">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="63px" DataField="IssueNo" HeaderText="Issue No." />
                                                                    <asp:BoundField ItemStyle-Width="235px" DataField="Books" HeaderText="Name" />
                                                                    <asp:BoundField ItemStyle-Width="72px" DataField="Qty" HeaderText="Qty" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Issue No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblissueno" runat="server" Text='<%# Eval("IssueNo")%>'></asp:Label>
                                                        <asp:Label ID="lblgenerateid" Visible="false" runat="server" Text='<%# Eval("GenerateID")%>'></asp:Label>
                                                        <asp:Label ID="lblsessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="StudentID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstudentid" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Class">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclassid" Visible="false" runat="server" Text=''></asp:Label>
                                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Section">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstudentname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltotalitemqty" runat="server" Text='<%# Eval("TotalItemQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Return Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblreturnqty" runat="server" Text='<%# Eval("ReturnQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Issue By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblissueBy" runat="server" Text='<%# Eval("AddedBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Issue Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblissuedate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Return Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblreturndate" runat="server" Text='<%# Eval("ReturnDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblreturnstatus" runat="server" Text='<%# Eval("ReturnStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" class="form-control " ID="txtremarks" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_deletes" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                            CommandName="Deletess" ValidationGroup="none" OnClientClick="functionConfirms(this); return false;" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Print
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href="javascript: void(null);" style="color: red" onclick="PrintReciepts('<%# Eval("GenerateID")%>','<%# Eval("TypeID")%>','<%# Eval("AcademicSessionID")%>'); return false;">
                                                            <i class=" fa fa-print"></i></a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
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
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ItemChildGridview(input) {

            var displayIcon = "img" + input;
            if ($("#" + displayIcon).attr("src") == "../EduImages/plus.gif") {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).attr("src", "../EduImages/minus.gif");
            } else {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "../EduImages/plus.gif");
            }
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Racklist table tbody tr').each(function () {
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
            var str = "";
            var i = 0;
            if (document.getElementById("<%=txtstudent.ClientID%>").value == "") {
                str = str + "\n Please enter Student details.";
                document.getElementById("<%=txtstudent.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtbook.ClientID%>").value == "") {
                str = str + "\n Please enter Books details.";
                document.getElementById("<%=txtbook.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtissuedate.ClientID%>").value == "") {
                str = str + "\n Please select Issue date.";
                document.getElementById("<%=txtissuedate.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtreturndate.ClientID%>").value == "") {
                str = str + "\n Please select Return date.";
                document.getElementById("<%=txtreturndate.ClientID %>").focus();
                i++;
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
                        __doPostBack('<%=GvBookIssueDetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvBookIssueDetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvBookIssueDetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Racklist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        function PrintBookIssueReciept() {
            objissueno = document.getElementById("<%= hdnissueno.ClientID%>")
            objTypeID = document.getElementById("<%= ddltype.ClientID %>")
            objacademicID = document.getElementById("<%= hdnacademicid.ClientID %>")
            window.open("../EduLibrary/Reports/ReportViewer.aspx?option=BookIssueReceipt&IssueNo=" + objissueno.value + "&typeID=" + objTypeID.value + "&AcademicSessionID=" + objacademicID.value)
        }
        function PrintReciepts(GenerateID, typeID, AcademicSessionID) {
            window.open("../EduLibrary/Reports/ReportViewer.aspx?option=BookIssueReceipt&IssueNo=" + GenerateID + "&typeID=" + typeID + "&AcademicSessionID=" + AcademicSessionID)
        }
    </script>
</asp:Content>
