<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="TransportRegistration.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Campusoft.Web.EduTransport.TransportRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

<style>
 
</style>
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Transport&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduTransport/TransportRegistration.aspx">Registration Details</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabStudentT"><i class="icon nalika-edit" aria-hidden="true"></i>Registration</a></li>
                <li><a href="#tabStudentList"><i class="icon nalika-picture" aria-hidden="true"></i>Registration List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabStudentT">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblacademicyear" Text="Academic Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlacademicyear" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblstudentID" Text="Student Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtstdID" MaxLength="15" runat="server" class="form-control" OnTextChanged="txtstdID_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionListCssClass="custom"
                                                ServiceMethod="Getautostudentlist" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtstdID"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label1" Text="Gender"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtsex" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblclass" Text="Class"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtclass" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblsection" Text="Section"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtsection" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblrolno" Text="Roll No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtrollnos" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblstudenttypess" Text="Student Type">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlTransportstudentType" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="hdnacademicID" />
                                            <asp:HiddenField runat="server" ID="hdnAdmissionID" />
                                            <asp:HiddenField runat="server" ID="hdnAdmissionNo" />
                                            <asp:HiddenField runat="server" ID="hdnstudentID" />
                                            <asp:HiddenField runat="server" ID="hdnclassID" />
                                            <asp:HiddenField runat="server" ID="hdnsectionID" />
                                            <asp:HiddenField runat="server" ID="hdnstudenttype" />
                                            <asp:HiddenField runat="server" ID="hdnbillno" />
                                            <asp:HiddenField runat="server" ID="hdnstreamID" />
                                            <asp:HiddenField runat="server" ID="hdnfeesamnt" />
                                            <asp:HiddenField runat="server" ID="hdnfeetypeID" />
                                            <asp:HiddenField runat="server" ID="HiddenField2" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblrootno" Text="Route No">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlrootID" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlrootID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblVehicle" Text="Assign Vehicle">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlVehicleID" runat="server" class="form-control" OnSelectedIndexChanged="ddlVehicleID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl" Text="Destination">   </asp:Label>
                                            <asp:TextBox ID="txtDestination" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group test">
                                            <asp:Label ID="lblmonthID" runat="server" Text="Month"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:ListBox ID="monthlist" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstartdate" runat="server" Text="Entry Date"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtstartdate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtstartdate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtstartdate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" AutoPostBack="true" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active </asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-10 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                            <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                            <asp:TextBox ID="txttransportregistrationno" MaxLength="100" Visible="false" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txttransportregistrationno" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:HiddenField runat="server" ID="HiddenField1" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="tabStudentList">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltabmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbltabacademicyear" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddltabacademicyear" AutoPostBack="true" OnSelectedIndexChanged="ddltabacademicyear_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblrouteno" Text="Route No">   </asp:Label>
                                            <asp:DropDownList ID="TabddlrouteID" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="TabddlrootID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblsubrouteno" Text="Destination">   </asp:Label>
                                            <asp:DropDownList ID="TabddlsubrouteID"  AutoPostBack="true" OnSelectedIndexChanged="TabddlsubrouteID_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblname" Text="Name"></asp:Label>
                                            <asp:TextBox runat="server" OnTextChanged="txtstudentanme_TextChanged" AutoPostBack="true" ID="txtstudentanme" class="form-control">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="Getautostudentlist" MinimumPrefixLength="1" CompletionListCssClass="custom"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtstudentanme"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>

                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblvehicle" Text="Vehicle">   </asp:Label>
                                            <asp:DropDownList ID="Tabddlvehicle" AutoPostBack="true" OnSelectedIndexChanged="Tabddlvehicle_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblclass" Text="Class"></asp:Label>
                                            <asp:DropDownList ID="Tabddlclass" AutoPostBack="true"  runat="server" class="form-control"
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="TablblSection" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="Tabddlsection" OnSelectedIndexChanged="ddlsections_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Tablbldatefrom" runat="server" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="Tabtxtdatefrom" AutoPostBack="true" OnTextChanged="Tabtxtdatefrom_TextChanged" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="Tabtxtdatefrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="Tabtxtdatefrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Tablbldateto" runat="server" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="Tabtxtdateto" runat="server" AutoPostBack="true"  OnTextChanged="Tabtxtdateto_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="Tabtxtdateto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="Tabtxtdateto" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Tabstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="tabddlstatus" AutoPostBack="true" OnSelectedIndexChanged="tabddlstatus_SelectedIndexChanged" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active </asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-9 customRow">
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.0em;">
                                            <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="Tabbtncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="Tabbtncancel_Click" />
                                            <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" Visible="false" runat="server" Text="Print" OnClientClick="return Printstudentlist();" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper" runat="server" id="divsearch">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                                <div id="DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="ClassList" class="col-md-12 customRow ">
                                        <asp:GridView ID="GVtransportrehistration" AllowPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GVtransportrehistration_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnSorting="GVtransportrehistration_Sorting" OnRowCommand="GVtransportrehistration_RowCommand" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%"  GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        ID
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Visible="True" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Student Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstudent" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Class">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="0.5%" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Section">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_section" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="0.5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Destination
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_destionation" runat="server" Text='<%# Eval("Destination")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Entry Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblentrancedate" runat="server" Text='<%# Eval("StartDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Edit
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="lnkEdit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Edits" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="lnkDelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
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
                $('#ClassList table tbody tr').each(function () {
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
            if (document.getElementById("<%=txtstdID.ClientID%>").value == "") {
                str = str + "\n Please enter student name."
                document.getElementById("<%=txtstdID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlTransportstudentType.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select student type."
                document.getElementById("<%=ddlTransportstudentType.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlrootID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select route no."
                document.getElementById("<%=ddlrootID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlVehicleID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select destination."
                document.getElementById("<%=ddlVehicleID.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtstartdate.ClientID%>").value == "") {
                str = str + "\n Please enter entry date."
                document.getElementById("<%=txtstartdate.ClientID %>").focus()
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
        }
        function Printstudentlist() {
            objStudentID = document.getElementById("<%= txtstdID.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicyear.ClientID %>")
            objstatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objTransStudentype = document.getElementById("<%= ddlTransportstudentType.ClientID %>")
            objStartMonth = document.getElementById("<%= txtstartdate.ClientID %>")
            window.open("../EduTransport/Reports/ReportViewer.aspx?option=TransportRegistration&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&IsActive=" + objstatus.value + "&TransStudentype=" + objTransStudentype.value + "&Startmonth=" + objStartMonth.value)
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
                        __doPostBack('<%=GVtransportrehistration.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GVtransportrehistration]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GVtransportrehistration]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#ClassList table tbody tr').each(function () {
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
    <script type="text/javascript" src="<%= ResolveUrl("~/app-assets/multiselectlist/jquery.min.js")%>"></script>
    <link href="../app-assets/multiselectlist/bootstrap.min.css" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/app-assets/multiselectlist/bootstrap-multiselect.js")%>"></script>
    <link href="../app-assets/multiselectlist/bootstrap.min.css" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/app-assets/multiselectlist/bootstrap.min.js")%>"></script>
    <script src="<%= ResolveUrl("~/app-assets/multiselectlist/jquery.min.js")%>"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=monthlist]').multiselect({
                includeSelectAllOption: true
            });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(function () {
                $('[id*=monthlist]').multiselect({
                    includeSelectAllOption: true
                });
            });
        });

    </script>
</asp:Content>
