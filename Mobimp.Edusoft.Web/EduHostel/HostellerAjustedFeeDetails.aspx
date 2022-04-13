<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="HostellerAjustedFeeDetails.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHostel.HostellerAjustedFeeDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Hostel&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHostel/HostelRegistration.aspx">Hostel Due Details</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabhostelduelist"><i class="icon nalika-edit" aria-hidden="true"></i>Due List</a></li>
                <li><a href="#tabDueCollection"><i class="icon nalika-picture" aria-hidden="true"></i>Due Collection</a></li>
                <li><a href="#tabcollectionlist"><i class="icon nalika-picture" aria-hidden="true"></i>Due Collection List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabhostelduelist">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="form-group ">
                                    <div class="row mt10">
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                                <asp:Label runat="server" ID="lblacademicsyear" Text="Academic Year">   </asp:Label>
                                                <asp:DropDownList ID="ddlacademicsession" runat="server" class="form-control ">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblstdID" Text="Student ID"></asp:Label>
                                                <asp:TextBox runat="server" AutoPostBack="True" Class="form-control" ID="txtstdId"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender TargetControlID="txtstdId" ID="FilteredTextBoxExtender1"
                                                    runat="server" ValidChars="1234567890" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetStudentID"
                                                    MinimumPrefixLength="2" CompletionListCssClass="Completion" CompletionListItemCssClass="listItem"
                                                    CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                                    CompletionSetCount="1" TargetControlID="txtstdId" UseContextKey="True" DelimiterCharacters=""
                                                    Enabled="True" ServicePath="">
                                                </asp:AutoCompleteExtender>

                                            </div>
                                        </div>--%>
                                        <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblname" Text="Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" OnTextChanged="txtstudentanme_TextChanged" AutoPostBack="true" ID="txtstudentanme" class="form-control">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txtContactsSearch_AutoCompleteExtender" runat="server"
                                                ServiceMethod="GetStudentNames" MinimumPrefixLength="1" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txtstudentanme" UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>

                                        </div>
                                    </div>
                                        <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldateform" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtdatefrom" runat="server" Class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtdatefrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdatefrom" />
                                        </div>
                                    </div>
                                        <%--<div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlclass" AutoPostBack="true" runat="server"
                                                            OnTextChanged="ddlclass_SelectedIndexChanged" Class="form-control">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlclass" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group ">
                                                <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlsection" runat="server" Class="form-control">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlsection" />
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>--%>
                                    </div>
                                    <div class="row mt10">
                                        <%--<div class="col-md-3 customRow">
                                            <div class="form-group ">
                                                <asp:Label ID="lblrolno" runat="server" Text="Roll No"></asp:Label>
                                                <asp:TextBox ID="txtrollno" runat="server" Class="form-control"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender runat="server" ID="FILTER1" TargetControlID="txtrollno" FilterType="Numbers">
                                                </asp:FilteredTextBoxExtender>
                                            </div>
                                        </div>--%>
                                        
                                        <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldateto" runat="server" Text="Date to"></asp:Label>
                                            <asp:TextBox ID="txttoo" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txttoo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdatefrom" />
                                        </div>
                                    </div>
                                        <div class="col-md-3 customRow">
                                            <asp:Label ID="lblduestatus" runat="server" Text="Due Status"></asp:Label>
                                            <asp:DropDownList ID="ddlduestatus" runat="server" Class="form-control">
                                                <asp:ListItem Value="1">Paid</asp:ListItem>
                                                <asp:ListItem Value="0">Unpaid </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <asp:Label ID="lblstutus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" runat="server" Class="form-control">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                                <asp:Button ID="btnsearch" Class="btn btn-sm btn-info button" OnClick="btnsearch_Click" runat="server" Text="Search" />
                                                <asp:Button ID="btncancel" Class="btn btn-sm btn-danger button" OnClick="btncancel_Click" runat="server" Text="Reset" />
                                                <asp:Button ID="btnprints" Class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printstdajustedlist();" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper" id="divsearch" runat="server" visible="false">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresults" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
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
                            </div>
                            <div class="card_wrapper">
                                <div style="height: 220px; width: 100%; overflow: auto; padding: 5px 0px 10px 0px;">
                                    <asp:UpdateProgress ID="updateProgress3" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIVloading" runat="server" class="Pageloader">
                                                <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <div id="HostelRegistrationlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvAjustedDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            Class="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
                                            Style="width: 100%">
                                            <Columns>
                                                <%--<asp:BoundField DataField="StudentID" SortExpression="StudentID" HeaderText="Student ID" />
                                                <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Name" />
                                                <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" />
                                                <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" />
                                                <asp:BoundField DataField="RollNo" SortExpression="RollNo" HeaderText="Roll No." />
                                                <asp:BoundField DataField="SexName" SortExpression="SexName" HeaderText="Sex" />
                                                <asp:BoundField DataField="pAddress" SortExpression="pAddress" HeaderText="Address" />--%>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        SlNo
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblrecipt" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        <asp:Label ID="lbldepositfeeID" Visible="false" runat="server" Text='<%# Eval("AID")%>'></asp:Label>
                                                        <asp:Label ID="lblsessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Tablblname" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Bill
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclassid" Visible="false" runat="server" Text=''></asp:Label>
                                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Discount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Payable
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Paid
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblrollno" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Due
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblajustamt" runat="server" Text='<%# Eval("AjustedAmount", "{0:0#.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField >
                                                    <HeaderTemplate>
                                                        Remarks
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" CssClass="cusTextBox" ID="txtremarks" Text=''></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                         Print
                                                    </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="javascript: void(null);" style="color: yellow" onclick="Printstdajustedlist('<%# Eval("ID")%>'); return false;">Print</a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField >
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Deletes" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');"> <i class="fa fa-trash" style="color:green;"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        Total Due Amount : RS.
                                         <asp:Label ID="lbltotalajustedamount" Text="" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="product-tab-list tab-pane fade" id="tabDueCollection">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="form-group ">
                                    <div class="row mt10">
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lblmessages" runat="server"></asp:Label>
                                                <asp:Label runat="server" ID="lblsstudentID" Text="Student ID"></asp:Label>
                                                <asp:TextBox ID="txtstudID" AutoPostBack="true" OnTextChanged="txtstudID_TextChanged"
                                                    runat="server" Class="form-control"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender TargetControlID="txtstudID" ID="FilteredTextBoxExtender2"
                                                    runat="server" ValidChars="0123456789" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetStudentIDs"
                                                    MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                                    CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                                    CompletionSetCount="1" TargetControlID="txtstudID" UseContextKey="True" DelimiterCharacters=""
                                                    Enabled="True" ServicePath="">
                                                </asp:AutoCompleteExtender>
                                                <asp:HiddenField runat="server" ID="hdnacademicID" />
                                                <asp:HiddenField runat="server" ID="hdnstudentID" />
                                                <asp:HiddenField runat="server" ID="hdnAdmissionID" />
                                                <asp:HiddenField runat="server" ID="hdnAdmissionNo" />
                                                <asp:HiddenField runat="server" ID="hdnclassID" />
                                                <asp:HiddenField runat="server" ID="hdnsectionID" />
                                                <asp:HiddenField runat="server" ID="hdnrollno" />
                                                <asp:HiddenField runat="server" ID="hdnstudenttype" />
                                                <asp:HiddenField runat="server" ID="hdnstudenttypeID" />
                                                <asp:HiddenField runat="server" ID="hdndepositbalance" />
                                                <asp:HiddenField runat="server" ID="hdnrcid" />

                                            </div>
                                        </div>
                                        <div class="col-md-6 customRow">
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblname" Text="Name"></asp:Label>
                                                <asp:Label runat="server" Class="form-control" ID="txtname"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lblblc" runat="server" Text="Due Balance"></asp:Label>
                                                <asp:Label runat="server" Class="form-control" ID="lblajustblc"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lblAmt" runat="server" Text="Amount"></asp:Label>
                                                <asp:TextBox ID="txtpaidamount" MaxLength="8" runat="server" Class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group ">
                                                <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>
                                                <asp:TextBox ID="txtdate" runat="server" Class="form-control"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                    TargetControlID="txtdate" />
                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdate" />
                                            </div>
                                        </div>
                                        <div class="col-md-6 customRow">
                                            <div class="form-group ">
                                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                                    <asp:Button ID="btnsave" Class="btn btn-sm btn-green button" OnClick="btnsave_Click" runat="server" Text="Save" />
                                                    <asp:Button ID="btnresetall" Class="btn btn-sm btn-danger button" OnClick="btnreset_Click" runat="server" Text="Reset" />
                                                    <asp:Button ID="btnprintss" Class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printajustedfeereciept()" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="product-tab-list tab-pane fade" id="tabcollectionlist">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmesagess" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblacademicsessions" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicsessions" runat="server" Class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstdentIDs" runat="server" Text="Student ID"></asp:Label>
                                            <asp:TextBox ID="txtstudentIDs" AutoPostBack="true" runat="server"
                                                Class="form-control" MaxLength="15"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudentIDs" ID="FilteredTextBoxExtender3"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServiceMethod="GetStudentID"
                                                MinimumPrefixLength="2" CompletionListCssClass="Completion" CompletionListItemCssClass="listItem"
                                                CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                                CompletionSetCount="1" TargetControlID="txtstudentIDs" UseContextKey="True" DelimiterCharacters=""
                                                Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblclassess" runat="server" Text="Class"></asp:Label>
                                            <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server"
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged" Class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblsectionss" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlsectionss" runat="server" Class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblrcno" runat="server" Text="Reciept No"></asp:Label>
                                            <asp:TextBox ID="txtrcno" AutoPostBack="true" runat="server" Class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatuss" runat="server" Class="form-control">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtfrom" runat="server" Class="form-control "></asp:TextBox>
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
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearchs" Class="btn btn-sm btn-info button" OnClick="btnsearchs_Click" runat="server" Text="Search" />
                                            <asp:Button ID="btnresetss" Class="btn btn-sm btn-danger button" OnClick="btnreset_Click" runat="server" Text="Reset" />
                                            <asp:Button ID="btnprintsss" Class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printcollectajustedlist();" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card_wrapper" id="divsearchs" runat="server" visible="false">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresultses" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecordss" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <%--<div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_exports" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_export" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>--%>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl_shows" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control">
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
                            </div>

                            <div class="card_wrapper">
                                <div style="height: 160px; width: 100%; overflow: auto; padding: 5px 0px 10px 0px;">
                                    <asp:UpdateProgress ID="updateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIVloadings" runat="server" class="Pageloader">
                                                <asp:Image ID="imgUpdateProgresss" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="Gvfeecollectiondetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                        OnRowCommand="GvAjustedfeedetails_RowCommand" Class="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="False" 
                                        HorizontalAlign="Center" Style="width: 100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    RC No
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrecipt" runat="server" Text='<%# Eval("PaidRecieptNo")%>'></asp:Label>
                                                    <asp:Label ID="lblACID" Visible="false" runat="server" Text='<%# Eval("ACID")%>'></asp:Label>
                                                    <asp:Label ID="lblsessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    ID
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstudentID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Class
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblclassid" Visible="false" runat="server" Text='<%# Eval("ClassID") %>'></asp:Label>
                                                    <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sec
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Name
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="220px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Roll No
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldepositamount" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Pre Due Blc
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpreblcamount" runat="server" Text='<%# Eval("PreAjustedBlc", "{0:0#.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Due Paid Amt
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsex" runat="server" Text='<%# Eval("PaidAmount", "{0:0#.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Due Balance
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpamode" runat="server" Text='<%# Eval("AjustedBalance", "{0:0#.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Added By
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Date
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldepositdate" runat="server" Text='<%# Eval("AddedDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Remarks
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" CssClass="cusTextBox" ID="txtremarkss" Text=''></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField >
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                         CommandName="Deletess" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" /> 
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Print
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="javascript: void(null);" style="color: red" onclick="Printbills('<%# Eval("ACID")%>'); return false;">
                                                        <i class="fa fa-print"></i></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        Total Collected Amountt : RS.
                                         <asp:Label ID="lblcollectedamount" Text="" runat="server"></asp:Label>
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
                        __doPostBack('<%=Gvfeecollectiondetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }
        function Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=txtstudentIDs.ClientID%>").value == "") {
                str = str + "\n  Student ID cannot be blank! Please enter it..";
                document.getElementById("<%=txtstudentIDs.ClientID %>").focus();
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
        function Printstdajustedlist() {
            objacademicID = document.getElementById("<%= ddlacademicsession.ClientID %>")
            
            objStatus = document.getElementById("<%= ddlstatus.ClientID %>")

            window.open("../EduHostel/Reports/ReportViewer.aspx?option=Stdfeeajustedlist&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Status=" + objStatus.value + "&RollNo=" + objRollNo.value)
        }
        <%--objStudentID = document.getElementById("<%= txtstdId.ClientID %>")
            objClassID = document.getElementById("<%= ddlclass.ClientID %>")
            objSection = document.getElementById("<%= ddlsection.ClientID %>")
            objRollNo = document.getElementById("<%= txtrollno.ClientID %>")--%>

        function Printajustedfeereciept() {
            objACID = document.getElementById("<%= hdnrcid.ClientID %>")
            window.open("../EduHostel/Reports/ReportViewer.aspx?option=AjustedFeeDeposit&ACID=" + objACID.value)

        }

        function Printbills(ACID) {
            window.open("../EduHostel/Reports/ReportViewer.aspx?option=AjustedFeeDeposit&ACID=" + ACID)

        }
        <%--function Printcollectajustedlist() {
            objacademicID = document.getElementById("<%= ddlacademicsessions.ClientID %>")
            
            objReceiptNo = document.getElementById("<%= txtrcno.ClientID %>")
            objStatus = document.getElementById("<%= ddlstatuss.ClientID %>")
            objDateFrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateTo = document.getElementById("<%= txtto.ClientID %>")

            window.open("../EduHostel/Reports/ReportViewer.aspx?option=Collectionajustedlist&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&ReceiptNo=" + objReceiptNo.value + "&Datefrom=" + objDateFrom.value + "&Dateto=" + objDateTo.value + "&Status=" + objStatus.value)
        }--%>
        <%--objStudentID = document.getElementById("<%= txtstudentIDs.ClientID %>")--%>
    </script>

</asp:Content>
