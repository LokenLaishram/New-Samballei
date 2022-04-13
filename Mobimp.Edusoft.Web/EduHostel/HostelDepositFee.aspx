<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="HostelDepositFee.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHostel.HostelDepositFee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Hostel&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHostel/HostelDepositFee.aspx">Hostel Deposit</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabdeposit"><i class="icon nalika-edit" aria-hidden="true"></i>Deposit Fee</a></li>
                <li><a href="#tabdepositList"><i class="icon nalika-picture" aria-hidden="true"></i>Deposit List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabdeposit">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card_wrapper">

                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblacademicyear" Text="Academic Year">   </asp:Label>
                                            <asp:DropDownList ID="ddlacademicyaer" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblstudentID" Text="Student ID"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" OnTextChanged="txtstdID_TextChanged" AutoPostBack="true" ID="txtstdID"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstdID" ID="FilteredTextBoxExtender3"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetStudentIDs"
                                                MinimumPrefixLength="2" CompletionListCssClass="Completion" CompletionListItemCssClass="listItem"
                                                CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                                CompletionSetCount="1" TargetControlID="txtstdID" UseContextKey="True" DelimiterCharacters=""
                                                Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="hdnBillGroup" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                                            <asp:Label runat="server" CssClass="form-control" ID="txtname"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                            <asp:Label runat="server" CssClass="form-control" ID="txtclass"></asp:Label>
                                            <asp:HiddenField runat="server" ID="hdnclassID" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblatudenttype" runat="server" Text="Admission Type"></asp:Label>
                                            <asp:DropDownList ID="ddlstudentype" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtsection"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudentcategory" runat="server" Text="Student Category"></asp:Label>
                                            <asp:Label ID="lblstream" Visible="false" runat="server" Text="Stream"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtstudentcategory"></asp:Label>
                                            <asp:Label runat="server" Visible="false" Class="form-control" ID="txtstreams"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudenttypess" runat="server" Text="Student Type"></asp:Label>
                                            <asp:HiddenField runat="server" ID="hdnstreamID" />
                                            <asp:HiddenField runat="server" ID="hdnAdmissionID" />
                                            <asp:HiddenField runat="server" ID="hdnacademicID" />
                                            <asp:HiddenField runat="server" ID="hdnstudentID" />
                                            <asp:HiddenField runat="server" ID="hdnstudenttype" />
                                            <asp:HiddenField runat="server" ID="hdnAdmissionNo" />
                                            <asp:HiddenField runat="server" ID="hdnstudenttypeID" />
                                            <asp:HiddenField runat="server" ID="hdnIshosteregister" />
                                            <asp:HiddenField runat="server" ID="hdnpaymentypes" />
                                            <asp:HiddenField runat="server" ID="hdndepositamount" />
                                            <asp:HiddenField runat="server" ID="hdnStudentcategoryID" />
                                            <asp:HiddenField runat="server" ID="hdnpaidamount" />
                                            <asp:HiddenField runat="server" ID="hdnrcno" />
                                            <asp:Label runat="server" Width="265px" CssClass="form-control" ID="txtstudenttype"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblrolno" runat="server" Text="Roll No"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtrollnos"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtsex"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblamount" runat="server" Text="Deposit Amount"></asp:Label>
                                            <asp:TextBox runat="server" Style="width: 265px" ID="txtdepositamount" CssClass="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender runat="server" ID="FILTER1" TargetControlID="txtdepositamount"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldate" runat="server" Text="Deposit Date"></asp:Label>
                                            <asp:TextBox ID="txtdate" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy" TargetControlID="txtdate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdate" />

                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpaymentmode" runat="server" Text="Payment Mode"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlpaymentmode" runat="server" Class="form-control"
                                                AutoPostBack="True" OnTextChanged="ddlpaymentmode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbankName" runat="server" Text="Bank Name"></asp:Label>
                                            <span id="ManBank" runat="server" visible="False" style="color: #ff0000">*</span>
                                            <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtbankName" Visible="False" runat="server" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblchalan" runat="server" Text="Challan No"></asp:Label>
                                            <span id="Manchalan" runat="server" visible="False" style="color: #ff0000">*</span>
                                            <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtchalan" runat="server" Visible="False" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsave" runat="server" Class="btn btn-sm btn-green button" Text="Save" OnClientClick="return Validate()" OnClick="btnsave_Click" />
                                            <asp:Button ID="btncancel" Class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                            <asp:Button ID="btnprint" Class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printdepositreciept()" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="tabdepositList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmesagesdepositlist" runat="server"></asp:Label>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                            <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstdentIDS" runat="server" Text="Student ID"></asp:Label>
                                            <asp:TextBox ID="txtstudentIDs" AutoPostBack="true" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudentIDs" ID="FilteredTextBoxExtender4"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetStudentIDs"
                                                MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                                CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                                CompletionSetCount="1" TargetControlID="txtstudentIDs" UseContextKey="True" DelimiterCharacters=""
                                                Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                            <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server"
                                                        Class="form-control" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlclasses" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                            <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlsections" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlsections" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsexs" runat="server" Text="Gender"></asp:Label>
                                            <asp:DropDownList ID="ddlsexs" AutoPostBack="true" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpaymentmodes" runat="server" Text="Payment Mode"></asp:Label>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList runat="server" ID="ddlpaymentmodes" Class="form-control">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlpaymentmodes" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtfrom" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtfrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                            <asp:TextBox ID="txtto" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                        </div>
                                    </div>

                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrcno" runat="server" Text="Receipt No."></asp:Label>
                                            <asp:TextBox ID="txtrecno" Width="200px" runat="server" Class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" Width="200px" runat="server" Class="form-control">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch" runat="server" Class="btn btn-sm btn-info button" Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btnreset" Class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                            <asp:Button ID="Button1" Class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printservicefeedepositlist();" />
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
                                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_export" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <%-- <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddl_show" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="20"> 20 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> all</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="col-md-4 customRow">
                                        <input type="text" class="searchs form-control" placeholder="search..">
                                    </div>
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
                                <div id="Depositlist" class="col-md-12 customRow ">
                                    <asp:GridView ID="Gvfeedetails" AllowPaging="true" AllowCustomPaging="true" AutoGenerateColumns="false" EmptyDataText="No record found..." OnPageIndexChanging="GvDepositfeedetails_PageIndexChanging"
                                        CssClass="footable table-striped" AllowSorting="true" OnRowDataCommand="GvDepositfeedetails_RowCommand" runat="server"
                                        Style="width: 100%">
                                        <Columns>
                                            <asp:BoundField DataField="ReceiptNo" SortExpression="ReceiptNo" HeaderText="RC No" />
                                            <asp:BoundField DataField="AdmissioNo" SortExpression="AdmissioNo" HeaderText="ID" />
                                            <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" />
                                            <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Sec" />
                                            <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Student Name" />
                                            <asp:BoundField DataField="SexName" SortExpression="SexName" HeaderText="Sex" />
                                            <asp:BoundField DataField="PayMode" SortExpression="PayMode" HeaderText="Pay Mode" />
                                            <asp:BoundField DataField="PreBalanceAmount" SortExpression="PreBalanceAmount" HeaderText="Pre Balc Amount" />
                                            <asp:BoundField DataField="DepositAmount" SortExpression="DepositAmount" HeaderText="Deposit Amount" />
                                            <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="Added By" />
                                            <asp:BoundField DataField="DepositDate" SortExpression="DepositDate" HeaderText="Deposit Date" />
                                            <asp:BoundField DataField="AcademicSessionName" SortExpression="AcademicSessionName" HeaderText="Year" />
                                            <asp:BoundField DataField="Remarks" SortExpression="Remarks" HeaderText="Remarks" />


                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="lnkDelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Left" Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Print
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="javascript: void(null);" style="color: red" onclick="Printbills('<%# Eval("ID")%>'); return false;">
                                                        <i class="fa fa-print"></i></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            Total Deposit Amount : RS.
                                            <asp:Label ID="lbltotaldepositamount" Text="" runat="server"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            Total Available Amount : RS.
                                          <asp:Label ID="lbltotalbalanceamount" Text="" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            Total Due Amount : RS.
                                         <asp:Label ID="lbltotalcurrentajustesamount" Text="" runat="server"></asp:Label>
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

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Studentlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

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

            function Validate1() {

                var str = "";
                var i = 0;

                if (document.getElementById("<%=txtstdID.ClientID%>").value == "") {
                    str = str + "\n Please enter student ID.";
                    document.getElementById("<%=txtstdID.ClientID %>").focus();
                    i++;

                }
                if (document.getElementById("<%=txtdepositamount.ClientID%>").value == "") {
                    str = str + "\n Please enter deposit amount.";
                    document.getElementById("<%=txtdepositamount.ClientID %>").focus();
                    i++;

                }
                if (document.getElementById("<%=txtdate.ClientID%>").value == "") {
                    str = str + "\n Please enter deposit date.";
                    document.getElementById("<%=txtdate.ClientID %>").focus();
                    i++;

                }
                if (document.getElementById("<%=ddlpaymentmode.ClientID%>").selectedIndex == "2") {

                    if (document.getElementById("<%=txtbankName.ClientID%>").value == "") {
                    str = str + "\n Please enter Bank Name."
                    document.getElementById("<%=txtbankName.ClientID %>").focus()
                    i++
                }
                if (document.getElementById("<%=txtchalan.ClientID%>").value == "") {
                    str = str + "\n Please enter Chalan No                                                                               ."
                    document.getElementById("<%=txtchalan.ClientID %>").focus()
                        i++
                    }

                }


                if (str.length > 0) {
                    alert("Check Following Required Fields : " + str);
                    return false;
                }
                else {
                    return true;
                }
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
                        __doPostBack('<%=Gvfeedetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        //print all deposit list
        function Printservicefeedepositlist() {
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objStudentID = document.getElementById("<%= txtstudentIDs.ClientID %>")
            objClassID = document.getElementById("<%= ddlclasses.ClientID %>")
            objSection = document.getElementById("<%= ddlsections.ClientID %>")
            objSex = document.getElementById("<%= ddlsexs.ClientID %>")
            objpaymode = document.getElementById("<%= ddlpaymentmodes.ClientID %>")
            objdatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objdateto = document.getElementById("<%= txtto.ClientID %>")
            objrecno = document.getElementById("<%= txtrecno.ClientID %>")
            objStatus = document.getElementById("<%= ddlstatus.ClientID %>")
            window.open("../EduHostel/Reports/ReportViewer.aspx?option=HostellerFeeDepositlist&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&SexID=" + objSex.value + "&PaymodeID=" + objpaymode.value + "&DateFrom=" + objdatefrom.value + "&DateTo=" + objdateto.value + "&ReceiptNo=" + objrecno.value + "&Status=" + objStatus.value)
        }

        function Printdepositreciept() {
            objdepositID = document.getElementById("<%= hdnrcno.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicyaer.ClientID %>")
            window.open("../EduHostel/Reports/ReportViewer.aspx?option=HostellerFeeDeposit&DepositID=" + objdepositID.value + "&SessionID=" + objacademicID.value)

        }

        function Printbills(ID) {
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            window.open("../EduHostel/Reports/ReportViewer.aspx?option=HostellerFeeDeposit&DepositID=" + ID + "&SessionID=" + objacademicID.value)

        }
    </script>
</asp:Content>
