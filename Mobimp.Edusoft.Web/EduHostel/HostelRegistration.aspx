<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="HostelRegistration.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHostel.HostelRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Hostel&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHostel/HostelRegistration.aspx">Hostel Registration</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabdeposit"><i class="icon nalika-edit" aria-hidden="true"></i>Hostel Registration Details</a></li>
                <li><a href="#tabStudentList"><i class="icon nalika-picture" aria-hidden="true"></i>Hostel Student List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabdeposit">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Always">
                        <contentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblacademicyear" Text="Academic Year">   </asp:Label>
                                            <asp:DropDownList ID="ddlacademicyear" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblstudentID" Text="Student ID"></asp:Label>
                                            <asp:TextBox runat="server" AutoPostBack="True" Class="form-control" ID="txtstdID"
                                                OnTextChanged="txtstdID_TextChanged"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstdID" ID="FilteredTextBoxExtender3"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetStudentIDs"
                                                MinimumPrefixLength="2" CompletionListItemCssClass="listItem" CompletionListCssClass="Completion"
                                                CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="1"
                                                TargetControlID="txtstdID" UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="hdnBillGroup" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtname"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtclass" ></asp:Label>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="row">  
                                    
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtsection"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblrolno" runat="server" Text="Roll No"></asp:Label>
                                            <asp:Label runat="server" Class="form-control" ID="txtrollnos"></asp:Label>
                                        </div>
                                    </div>
                                   <%-- <div class="col-md-3 customRow">
                                        <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
                                        <asp:Label runat="server" Class="form-control" ID="txtsex"></asp:Label>
                                    </div>--%>
                                    <div class="col-md-3 customRow">
                                        <asp:Label ID="lblstudenttypess" runat="server" Text="Student Type"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList runat="server" Class="form-control" ID="ddlstudentType">
                                        </asp:DropDownList>
                                        <asp:HiddenField runat="server" ID="hdnstreamID" />
                                        <asp:HiddenField runat="server" ID="hdnfeesamnt" />
                                        <asp:HiddenField runat="server" ID="hdnAdmissionID" />
                                        <asp:HiddenField runat="server" ID="hdnacademicID" />
                                        <asp:HiddenField runat="server" ID="hdnstudentID" />
                                        <asp:HiddenField runat="server" ID="hdnfeetypeID" />
                                        <asp:HiddenField runat="server" ID="hdnbillno" />
                                        <asp:HiddenField runat="server" ID="hdnsectionID" />
                                        <asp:HiddenField runat="server" ID="hdnclassID" />
                                        <asp:HiddenField runat="server" ID="HiddenField2" />
                                        <asp:HiddenField runat="server" ID="hdnstudenttype" />
                                        <asp:HiddenField runat="server" ID="hdnAdmissionNo" />
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblblock" runat="server" Text="Campus"></asp:Label>
                                            <asp:DropDownList runat="server" ID="ddlblock" Class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblwardenname" runat="server" Text="Warden"></asp:Label>
                                            <asp:DropDownList runat="server" ID="ddlwardenname" Class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldomitry" runat="server" Text="Wing"></asp:Label>
                                            <asp:DropDownList runat="server" ID="ddldry" Class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbledate" runat="server" Text="Entrance Date"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtentdate" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtentdate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtentdate" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" runat="server" Class="form-control">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="2">Inactive</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-3 customRow">
                                        <asp:Label ID="lblregistration" Visible="false" runat="server" Text="Regd No"></asp:Label>
                                        <asp:TextBox runat="server" Visible="false" Class="form-control" ID="txtregistrationno"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtregistrationno" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="1234567890">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:HiddenField runat="server" ID="HiddenField1" />
                                    </div>
                                    <%--<div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmonth" runat="server" Text="Month"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList runat="server" ID="ddlmonth" Class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsave" runat="server" Class="btn btn-sm btn-success button" OnClientClick="return Validate();"
                                                OnClick="btnsave_Click" Text="Save" />
                                            <%--<asp:Button ID="btnsearch" Class="btn btn-sm btn-info button" OnClick="btnsearch_Click" runat="server" Text="Search" />--%>
                                            <asp:Button ID="btncancel" Class="btn btn-sm btn-danger button" OnClick="btncancel_Click" runat="server" Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                                </div>
                        </contentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="product-tab-list tab-pane fade" id="tabStudentList">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltabmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbltabacademicyear" Text="Academic Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddltabacademicyear" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
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
                                            <asp:Label runat="server" ID="Tablblcampusno" Text="Campus">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="TabddlcampusID" AutoPostBack="true" runat="server" class="form-control" >
                                            </asp:DropDownList>
                                           <%-- OnSelectedIndexChanged="TabddlcampusID_SelectedIndexChanged"--%>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblwing" Text="Wing">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="TabddlwingID" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <asp:Label runat="server" ID="Tablblwarden" Text="Warden">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="Tabddlwarden" runat="server" class="form-control">
                                                </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Tablblclass" Text="Class"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="Tabddlclass" runat="server" class="form-control"
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="TablblSection" Text="Section"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="Tabddlsection"  runat="server" class="form-control"></asp:DropDownList>
                                            <%--OnSelectedIndexChanged="ddlsections_SelectedIndexChanged"--%>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Tabstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="tabddlstatus" AutoPostBack="true" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active </asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Tablbldatefrom" runat="server" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="Tabtxtdatefrom" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="Tabtxtdatefrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="Tabtxtdatefrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Tablbldateto" runat="server" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="Tabtxtdateto" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="Tabtxtdateto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="Tabtxtdateto" />
                                        </div>
                                    </div>

                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <%--<asp:Button ID="Button1" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />--%>
                                            <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="Tabbtncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="Tabbtncancel_Click" />
                                             <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintHostellist();" />
                                               
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
                                            <asp:DropDownList ID="ddl_show" AutoPostBack="true" runat="server" class="form-control">
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
                                    <asp:UpdateProgress ID="updateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIVloading" runat="server" class="Pageloader">
                                                <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <div id="HostelRegistrationlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="GVhostelrehistration" AllowPaging="true" AutoGenerateColumns="false" EmptyDataText="No record found..." OnPageIndexChanging="GVhostelrehistration_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnSorting="GVhostelrehistration_Sorting" OnRowCommand="GVhostelrehistration_RowCommand1" runat="server" HorizontalAlign="Center"
                                            OnRowDataBound="GvHostelstudentDetails_RowDataBound" Style="width: 100%"  GridLines="None" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        ID
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Visible="True" runat="server" Text='<%# Eval("IDS")%>'></asp:Label>
                                                        <%--<asp:Label ID="lblstudentID" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Regd No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblregistration" runat="server" Text='<%# Eval("RegistrationNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Student Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstudent" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Campus
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblblock" runat="server" Text='<%# Eval("BlockName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Warden
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblwarden" runat="server" Text='<%# Eval("EmpName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Wing
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldry" runat="server" Text='<%# Eval("Dry")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Month
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("MonthNames")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Entry Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblentrancedate" runat="server" Text='<%# Eval("EntranceDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Withdrawal date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtwdate" Width="90px" runat="server" Text='<%# Eval("WithdrawlDate","{0:dd-MM-yyyy}") %>'
                                                            class="form-control"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                            TargetControlID="txtwdate" />
                                                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtwdate" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Edit
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDS" Visible="false" runat="server" Text='<%# Eval("IDS")%>'></asp:Label>
                                                        <asp:Button ID="lnkEdit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Editss"/>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Remarks
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblremarkID" Visible="false" runat="server" Text='<%# Eval("RemarkID")%>'></asp:Label>
                                                        <asp:DropDownList ID="ddlremarks" class="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
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
                                </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

         function PrintHostellist() {
             objacademicID = document.getElementById("<%= ddltabacademicyear.ClientID %>")
             objname= document.getElementById("<%= txtstudentanme.ClientID %>")
             objcampus = document.getElementById("<%= TabddlcampusID.ClientID %>")
             objwing = document.getElementById("<%= TabddlwingID.ClientID %>")
             objwarden = document.getElementById("<%= Tabddlwarden.ClientID %>")
             objclass = document.getElementById("<%= Tabddlclass.ClientID %>")
             objsection = document.getElementById("<%= Tabddlsection.ClientID %>")
             objisactive = document.getElementById("<%= tabddlstatus.ClientID %>")
             objdatefrom = document.getElementById("<%= Tabtxtdatefrom.ClientID %>")
             objdateto = document.getElementById("<%= Tabtxtdateto.ClientID %>")

            window.open("../EduHostel/Reports/ReportViewer.aspx?option=HostelRegistration&SessionID=" + objacademicID.value + "&Name=" + objname.value + "&Campus=" + objcampus.value + "&Wing=" + objwing.value + "&WardenID=" + objwarden.value + "&Class=" + objclass.value + "&Section=" + objsection.value + "&Isactive=" + objisactive.value + "&Datefrom=" + objdatefrom.value + "&Dateto=" + objdateto.value )
        }
        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#HostelRegistrationlist table tbody tr').each(function () {
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
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=GVhostelrehistration.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }
        $(function () {

            $('[id*=GVhostelrehistration]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GVhostelrehistration]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#HostelRegistrationlist table tbody tr').each(function () {
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

        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=txtstdID.ClientID%>").value == "") {
                str = str + "\n Please enter Student ID."
                document.getElementById("<%=txtstdID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlstudentType.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Student Type."
                document.getElementById("<%=ddlstudentType.ClientID %>").focus()
                i++
            }

            
            if (document.getElementById("<%=txtentdate.ClientID%>").value == "") {
                str = str + "\n Please enter Entrance Date."
                document.getElementById("<%=txtentdate.ClientID %>").focus()
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

       

        
</script>
</asp:Content>

