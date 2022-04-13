<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="HostellerPurchaseRecord.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHostel.HostellerPurchaseRecord" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Hostel&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHostel/HostelRegistration.aspx">Hostel Purchase Record</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabpurchaseitem"><i class="icon nalika-edit" aria-hidden="true"></i>Purchase Item</a></li>
                <li><a href="#tabcollectionlist"><i class="icon nalika-picture" aria-hidden="true"></i>Purchase Item List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabpurchaseitem">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblacademicyear" Text="Academic Year">   </asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesion" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>                                    
                                    <div class="col-md-9 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                                            <%--<asp:Label runat="server" Class="form-control" ID="lblstudentname"></asp:Label>--%>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" OnTextChanged="txtstudentanme_TextChanged" AutoPostBack="true" ID="txtstudentanme" class="form-control">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txtContactsSearch_AutoCompleteExtender" runat="server"
                                                ServiceMethod="GetStudentNames" MinimumPrefixLength="1" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txtstudentanme" UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <asp:Label ID="lblblc" runat="server" Text="AC Balance"></asp:Label>
                                        <asp:Label runat="server" Class="form-control" ID="lblstdblc"></asp:Label>
                                    </div>
                                    <div class="col-md-9 customRow">
                                        <asp:Label ID="lblitemname" runat="server" Text="Item Name"></asp:Label>
                                        <asp:TextBox runat="server" AutoPostBack="True" Class="form-control"
                                            OnTextChanged="TxtChange_TextChanged" ID="txtitemname"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtitemname" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.->:()">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                    </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <asp:Label ID="lblrate" runat="server" Text="Item Rate"></asp:Label>
                                        <asp:TextBox runat="server" Class="form-control" ID="txtrate"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtrate" ID="FilteredTextBoxExtender5"
                                            runat="server" ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:HiddenField runat="server" ID="HiddenField1" />
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblquantity" runat="server" Text="Qty"></asp:Label>
                                            <asp:TextBox runat="server" Class="form-control" ID="txtquantity"
                                                OnTextChanged="TxtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtquantity" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:HiddenField runat="server" ID="txtitemrate" />
                                        </div>
                                    </div>
                                     <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label Visible="false" runat="server" ID="lblstudentID" Text="Student ID"></asp:Label>
                                            <asp:TextBox runat="server" Visible="false" AutoPostBack="True" Class="form-control" ID="txtstdID"
                                                OnTextChanged="txtstdID_TextChanged"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstdID" ID="FilteredTextBoxExtender3"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetStudentIDs"
                                                MinimumPrefixLength="2" CompletionListCssClass="Completion" CompletionListItemCssClass="listItem"
                                                CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                                CompletionSetCount="1" TargetControlID="txtstdID" UseContextKey="True" DelimiterCharacters=""
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
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="card_wrapper">
                                    <div style="height: 160px; width: 100%; overflow: auto; padding: 5px 0px 10px 0px;">
                                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloadinghostel" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgresshostel" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:GridView ID="Gvitemdetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" AllowSorting="true" OnRowCommand="Gvitemdetails_RowCommand" runat="server" HorizontalAlign="Center"
                                            Style="width: 100%" AutoGenerateColumns="false">
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
                                                        SlNo.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblslno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Item ID
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Item name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblitemname" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Rate
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblitemrate" runat="server" Text='<%# Eval("ItemRate", "{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Qty
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" class="form-control " ID="lblquantity" Text='<%# Eval("ItemQty")%>'
                                                            AutoPostBack="true"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltotalAmount" runat="server" Text='<%# Eval("TotalAmount", "{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Added By
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Year
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsessionID1" runat="server" Text='<%# Eval("AcademicSessionName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Deletes" ValidationGroup="none"> <i class="fa fa-trash" style="color:green;"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <asp:CheckBox runat="server" ID="checkajust" CssClass="Checkboxstyel"
                                            OnCheckedChanged="Txtbox_TextChanged" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-3 customRow">
                                        Ajusted Amount : RS.
                                          <asp:Label ID="lblajustedamt" Text="" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        Total Items Quantity :
                                          <asp:Label ID="lbltotalqty" Text="" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        Total Amount : RS.
                                            <asp:Label ID="lbltotalamount" Text="" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:HiddenField runat="server" ID="hdnreceiptno" />
                                            <asp:Button ID="btnsave" Class="btn btn-sm btn-green button" OnClick="btnsave_Click" runat="server" Text="Save"
                                                OnClientClick="javascript: return confirm('Have you check item name and quantity in the list ? Are you sure to save it ?');" />
                                            <asp:Button ID="btnreset" runat="server" Class="btn btn-sm btn-danger button" OnClick="btnreset_Click" Text="Reset" />
                                            <asp:Button ID="btnprint" Class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printtakingitemreciept()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane" id="tabcollectionlist">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmesagesdepositlist" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="lblresultss" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblacademicsession" Text="Academic Year">   </asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblstdentIDS" Text="Student ID"></asp:Label>
                                            <asp:TextBox runat="server" AutoPostBack="True" Class="form-control" ID="txtstudentIDs"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudentIDs" ID="FilteredTextBoxExtender4"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetStudentIDs"
                                                MinimumPrefixLength="2" CompletionListCssClass="completion" CompletionListItemCssClass="listItem"
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
                                        <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlsections" runat="server" Class="form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlsections" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrcno" runat="server" Text="Reciept No"></asp:Label>
                                            <asp:TextBox ID="txtrcno" runat="server" Class="form-control"></asp:TextBox>
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
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" runat="server" Class="form-control">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:HiddenField runat="server" ID="HiddenField21" />
                                            <asp:Button ID="btnsearchs" Class="btn btn-sm btn-info button" OnClick="btnsearchs_Click" runat="server" Text="Search" />
                                            <asp:Button ID="btnresetall" runat="server" Class="btn btn-sm btn-danger button" OnClick="btnresetall_Click" Text="Reset" />
                                            <asp:Button ID="btnprints" Class="btn btn-sm btn-indigo button" Visible="false" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresults" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div style="height: 160px; width: 100%; overflow: auto; padding: 5px 0px 10px 0px">
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:GridView ID="Gvtakingitemdetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvDepositfeedetails_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnRowCommand="GvTakingItem_RowCommand" OnRowDataBound="gv_Child_OnRowDataBound" runat="server" HorizontalAlign="Center"
                                            Style="width: 100%" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <a href="JavaScript:ItemChildGridview('div<%# Eval("ReceiptNo") %>');">
                                                            <img alt="Detail" id="imgdiv<%# Eval("ReceiptNo") %>" src="../EduImages/plus.gif" />
                                                        </a>
                                                        <div id="div<%# Eval("ReceiptNo") %>" style="display: none;">
                                                            <asp:GridView ID="GridChild" runat="server" AutoGenerateColumns="false" DataKeyNames="ReceiptNo"
                                                                CssClass="ChildGrid">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="63px" DataField="ReceiptNo" HeaderText="RC. No." />
                                                                    <asp:BoundField ItemStyle-Width="235px" DataField="ItemName" HeaderText="Item Name" />
                                                                    <asp:BoundField ItemStyle-Width="80px" DataField="ItemRate" HeaderText="Item Rate"
                                                                        DataFormatString="Rs.{0:###,###,###.00}" HtmlEncode="False" />
                                                                    <asp:BoundField ItemStyle-Width="72px" DataField="ItemQty" HeaderText="Item Qty" />
                                                                    <asp:BoundField ItemStyle-Width="100px" DataField="TotalAmount" HeaderText="Total Amount"
                                                                        DataFormatString="Rs.{0:###,###,###.00}" HtmlEncode="False" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        RC No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblrecipt" runat="server" Text='<%# Eval("ReceiptNo")%>'></asp:Label>
                                                        <asp:Label ID="lbldepositfeeID" Visible="false" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                        <asp:Label ID="lblsessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        ID
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclassid" Visible="false" runat="server" Text=''></asp:Label>
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
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Item Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldepositamount" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Qty
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsex" runat="server" Text='<%# Eval("TotalItemQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblpreblcamount" runat="server" Text='<%# Eval("NetAmount", "{0:0#.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Due Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblpamode" runat="server" Text='<%# Eval("AjustedAmt", "{0:0#.00}")%>'></asp:Label>
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
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
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
                                                        <asp:TextBox runat="server" class="form-control " ID="txtremarks" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Delete" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');"> <i class="fa fa-trash" style="color:green;"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Print
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href="javascript: void(null);" style="color: red" onclick="Printbills('<%# Eval("ReceiptNo")%>'); return false;">
                                                            <i class=" fa fa-print"></i></a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row mt10">
                                        <div class="col-md-3 customRow">
                                            Total Qty :
                                            <asp:Label ID="lblnetqty" Text="" ForeColor="#ff3300" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            Total Amount : RS.
                                            <asp:Label ID="lbltotalnetamount" Text="" ForeColor="#ff3300" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            Total Due Amount : RS.
                                            <asp:Label ID="lbltotalajustedamt" Text="" ForeColor="#ff3300" runat="server"></asp:Label>
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
        //TAP 2 PRINT
        function Printbills(ReceiptNo) {
            window.open("../EduHostel/Reports/ReportViewer.aspx?option=TakingItemDetails&ReceiptNo=" + ReceiptNo)
        }
        function Printtakingitemreciept() {
            var objReceiptNo = document.getElementById("<%= hdnreceiptno.ClientID %>")
            window.open("../EduHostel/Reports/ReportViewer.aspx?option=TakingItemDetails&ReceiptNo=RC" + objReceiptNo.value)
        }
    </script>


</asp:Content>
