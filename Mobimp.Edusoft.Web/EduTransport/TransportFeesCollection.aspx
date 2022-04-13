<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="TransportFeesCollection.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduFees.SchoolFeesCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Fees&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="SchoolFeesCollection.aspx">Fee Counter</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tapfeecollection"><i class="icon nalika-edit" aria-hidden="true"></i>Fee Collections </a></li>
                <li><a href="#tabcollectionlist"><i class="icon nalika-picture" aria-hidden="true"></i>Fee Collection Detail List List</a></li>
            </ul>
            <div id="myTabContents" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tapfeecollection" style="margin-top: -28px;"> 
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper" style="height: 150px;">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsession" runat="server" Text="Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlacademicsession" AutoPostBack="true" class="form-control "
                                                runat="server" OnSelectedIndexChanged="ddlsession_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudentanme" runat="server" Text="Name"></asp:Label>
                                            <asp:TextBox runat="server" OnTextChanged="stddetail_OnTextChanged" AutoPostBack="true"
                                                ID="txtstddetail" class="form-control"></asp:TextBox>
                                             <asp:FilteredTextBoxExtender TargetControlID="txtstddetail" ID="FilteredTextBoxExtendertxtstddetail"
                                                runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890|-: ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="Getautostudentlistfee" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtstddetail"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                        </div>
                                    
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudenttype" runat="server" Text="Student Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" class="form-control " ID="txtstudenttype"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfather" runat="server" Text="C/O"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control " ID="txtcareof"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBox" runat="server" Enabled="True"
                                                TargetControlID="txtcareof" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstdtype" runat="server" Text="Admission Type"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control " ID="txtadmissiontype"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbillno" runat="server" Text="Bill No."></asp:Label>
                                            <asp:TextBox runat="server" class="form-control " ID="txtbillno"></asp:TextBox>
                                            <asp:HiddenField runat="server" ID="hdstudentid" />
                                            <asp:HiddenField runat="server" ID="hdstutypid" />
                                            <asp:HiddenField runat="server" ID="hdclassid" />
                                            <asp:HiddenField runat="server" ID="hdrollno" />
                                            <asp:HiddenField runat="server" ID="txtisadmissiondone" />
                                            <asp:HiddenField runat="server" ID="hdadmissiontypeID" />
                                            <asp:HiddenField runat="server" ID="hdnistakingtransport" />
                                            <asp:HiddenField runat="server" ID="hdnisboardingstudent" />
                                            <asp:HiddenField runat="server" ID="hdnBoardingStudentTypeID" />
                                            <asp:HiddenField runat="server" ID="hdnBoardingStudentTypeName" />
                                            <asp:HiddenField runat="server" ID="hdnTransportStudentTypeID" />
                                            <asp:HiddenField runat="server" ID="hdnTransportStudentTypeName" />
                                            <asp:HiddenField runat="server" ID="hdnIsBoardingAdmissionDone" />
                                            <asp:HiddenField runat="server" ID="hdnfeetypeID" />
                                            <asp:HiddenField runat="server" ID="hdnbillno" />
                                            <asp:HiddenField runat="server" ID="hdnstreamID" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfeetype" runat="server" Text="Fee Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlfeetype" AutoPostBack="true" class="form-control "
                                                runat="server" OnSelectedIndexChanged="ddlfeetype_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbortranstdtype" Visible="false" runat="server" Text="Bor/Trans Type"></asp:Label>
                                            <asp:Label ID="lblparticular" Visible="false" runat="server" Text="Particular"></asp:Label>
                                            <asp:TextBox runat="server" Visible="false" ID="txttransportstdtype"
                                                class="form-control"></asp:TextBox>
                                            <asp:TextBox runat="server" Visible="false" ID="txtbordingstdtype"
                                                class="form-control"></asp:TextBox>
                                            <asp:TextBox runat="server" Visible="false" ID="txtparticular"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblparticularamt" Visible="false" runat="server" Text="Amount"></asp:Label>
                                            <asp:TextBox runat="server" Visible="false" Width="15pc" ID="txtparticularamt"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Button ID="btnadd" Visible="false" runat="server" class="btn btn-sm btn-info button " Text="Add" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card_wrapper">
                                <div style="height: 160px; width: 100%; overflow: auto; padding: 5px 0px 10px 0px;">
                                    <asp:UpdateProgress ID="updateProgress6" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIVloading6" runat="server" class="Pageloader ">
                                                <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="GvFeedetails" CssClass="footable table-striped" runat="server" EmptyDataText="No record found..."
                                        AutoGenerateColumns="False" Width="100%" class="grid" AllowPaging="false"
                                        OnRowDataBound="GvFeedetails_RowDataBound" HorizontalAlign="Center" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    SL No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Particular
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                    <asp:Label ID="lblmonthID" Visible="false" runat="server" Text='<%# Eval("MonthID") %>'></asp:Label>
                                                    <asp:Label ID="lblfeetypeID" Visible="false" runat="server" Text='<%# Eval("FeeTypeID") %>'></asp:Label>
                                                    <asp:Label ID="sessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID") %>'></asp:Label>
                                                    <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID") %>'></asp:Label>
                                                    <asp:Label ID="lbladmissiontype" Visible="false" runat="server" Text='<%# Eval("AdmissionType") %>'></asp:Label>
                                                    <asp:Label ID="lblstudentypeID" Visible="false" runat="server" Text='<%# Eval("StudentTypeID") %>'></asp:Label>
                                                    <asp:Label ID="lblparticularfeetype" runat="server" Width="200px" Text='<%# Eval("FeeType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Fee Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfeeamount" runat="server" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Exempted Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexemptamount" runat="server" Text='<%# Eval("ExemptedAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Fine Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfineamount" runat="server" Text='<%# Eval("FineAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Total Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltotalamount" runat="server" Text='<%# Eval("TotalFeeAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Status
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkfeestatus" AutoPostBack="true" runat="server" OnCheckedChanged="checkboxes_SelectedIndexChanged" />
                                                    <asp:Label ID="lblFeeStatus" Visible="false" runat="server" Text='<%# Eval("FeeStatus")%>'></asp:Label>
                                                    <asp:Label ID="lblfeepaid" Visible="false" runat="server" Text='Paid'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <FooterTemplate>
                                                    <itemtemplate>dsfs</itemtemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div id="bottomFeeCollection" runat="server">

                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Amount : Rs.
                                                 <asp:Label ID="hdnfeeamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="hdnexemptedamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="hdnfineamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="hdntotalfeeamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="hdntotalsumfeeamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="lblgrandtotalfeeamount" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="lbltotalexemptamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="lbltotalfineamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                        <asp:Label ID="lbltotalnetamount" Visible="false" runat="server" Text="" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Discount Amount : Rs.
                                                <asp:TextBox ID="txttotaldiscount" MaxLength="6" AutoPostBack="true"
                                                    runat="server" OnTextChanged="discount_OnTextChanged" class="form-control "></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txttotaldiscount" ID="FilteredTextBoxExtendertxttotaldiscount"
                                            runat="server" ValidChars="1234567890,." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Payable Amount : Rs.
                                                <asp:Label ID="lbltotalpayableamt" runat="server" Text="" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Paid Amount : Rs.
                                                <asp:TextBox ID="txttotalpaidamt" MaxLength="11" AutoPostBack="true"
                                                    runat="server" OnTextChanged="paid_OnTextChanged" class="form-control "></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txttotalpaidamt" ID="FilteredTextBoxExtendertxttotalpaidamt"
                                            runat="server" ValidChars="1234567890,." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Due Amount : Rs.
                                                <asp:Label ID="lbltotaldueamt" runat="server" Text="" class="form-control "></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9 customRow" style="text-align: left">
                                <div class="RtextAlign">
                                    Remark : 
                                                <asp:TextBox ID="txtremarks" Width="500px" runat="server" class="form-control "></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12 customRow" style="text-align: right">
                                <div class="RtextAlign" style="padding: 0px 0px 0px 0px;">
                                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClientClick="javascript: return confirm('Are you sure to update?');"
                                        class="btn btn-sm btn-green button " OnClick="btnsave_Click" />
                                    <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button " runat="server" Text="Print" OnClientClick="return Printfeereciept();" />
                                    <asp:Button ID="btnclear" runat="server" Text="Reset" class="btn btn-sm btn-danger button" OnClick="btnclearall_Click" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="tabcollectionlist" style="margin-top: -28px;">
                    <asp:UpdatePanel ID="upFeeTab2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmesagestudentlist" Visible="false" runat="server"></asp:Label>
                                            <asp:DropDownList ID="ddlsearch" Width="110px" runat="server" class="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlsearch_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Search By:</asp:ListItem>
                                                <asp:ListItem Value="1">Name </asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox runat="server" ID="txtstudentanme" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudentanme" ID="FilteredTextBoxExtendertxtstudentanme"
                                                runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtenderstudentanme" runat="server" ServiceMethod="GetStudentName"
                                                MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                                CompletionSetCount="1" TargetControlID="txtstudentanme" UseContextKey="True" DelimiterCharacters="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstdentIDS" runat="server" Text="Student ID"></asp:Label>
                                            <asp:TextBox ID="txtstudentIDs" AutoPostBack="true" runat="server" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtstudentIDs" ID="FilteredTextBoxExtendertxtstudentIDs"
                                                runat="server" ValidChars="0123456789">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtendertxtstudentIDs" runat="server" ServiceMethod="GetStudentIDs"
                                                MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                                CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                                CompletionSetCount="1" TargetControlID="txtstudentIDs" UseContextKey="True" DelimiterCharacters=""
                                                ServicePath="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsexs" runat="server" Text="Gender"></asp:Label>
                                            <asp:DropDownList ID="ddlsexs" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">

                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                            <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" class="form-control "
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlsections" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblcategories" runat="server" Text="Student Category"></asp:Label>
                                            <asp:DropDownList ID="ddlcategorys" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblpaymentmodes" Text="Payment Mode"></asp:Label>
                                            <asp:DropDownList runat="server" ID="ddlpaymentmodes" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfeetypess" runat="server" Text="Fee Type"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:DropDownList runat="server" class="form-control " ID="ddlfeetypess" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlfeetypess_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtfrom" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                TargetControlID="txtfrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                            <asp:TextBox ID="txtto" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                TargetControlID="txtto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrouteno" Visible="false" runat="server" Text="Route No"></asp:Label>
                                            <asp:DropDownList ID="ddlrouteno" Visible="false" Width="209px" runat="server" class="form-control "
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlrouteno_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblvihicle" Visible="false" runat="server" Text="Vihicle Details"></asp:Label>
                                            <asp:DropDownList ID="ddlvihicle" Visible="false" Width="209px" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbluser" runat="server" Text="Collected By" Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddluser" Width="209px" runat="server" class="form-control " Visible="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="col-md-12 customRow" style="text-align: right">
                                        <div class="form-group">
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-blue button " OnClientClick="return Validates();"
                                                OnClick="btnsearch_Click" Text="Search" />
                                            <asp:Button ID="btnreset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                            <asp:Button ID="Button2" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printfeecollectionlist();" />
                                            <asp:Button ID="btnsend" class="btn btn-sm btn-info button " Visible="false" runat="server" Text="Send SMS" />
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
                                    <asp:UpdateProgress ID="updateProgress2" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIVloading7" runat="server" class="Pageloader ">
                                                <asp:Image ID="imgUpdateProgress1" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="Gvfeedetailslist" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="Gvfeedetailslist_PageIndexChanging"
                                        CssClass="footable table-striped" AllowSorting="true" OnSorting="Gvfeedetailslist_Sorting" runat="server" AutoGenerateColumns="false"
                                        Style="width: 100%" GridLines="None" OnRowDataBound="gv_Child_OnRowDataBound" OnRowCommand="Gvfeedetailslist_RowCommand">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="150px">
                                                <ItemTemplate>
                                                    <a href="JavaScript:ItemChildGridview('div<%# Eval("BillNo") %>');">
                                                        <img alt="Detail" id="imgdiv<%# Eval("BillNo") %>" src="../EduImages/plus.gif" />
                                                    </a>
                                                    <div id="div<%# Eval("BillNo") %>" style="display: none;">
                                                        <asp:GridView ID="GridChild" runat="server" AutoGenerateColumns="false" DataKeyNames="BillNo"
                                                            CssClass="ChildGrid">
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="63px" DataField="BillNo" HeaderText="Bill No." />
                                                                <asp:BoundField ItemStyle-Width="130px" DataField="FeeType" HeaderText="Particular" />
                                                                <asp:BoundField ItemStyle-Width="130px" DataField="FeeAmount" HeaderText="Fee Amount"
                                                                    DataFormatString="Rs.{0:###,###,###.00}" HtmlEncode="False" />
                                                                <asp:BoundField ItemStyle-Width="130px" DataField="ExemptedAmount" HeaderText="Exempted Amount"
                                                                    DataFormatString="Rs.{0:###,###,###.00}" HtmlEncode="False" />
                                                                <asp:BoundField ItemStyle-Width="130px" DataField="FineAmount" HeaderText="Fine Amount"
                                                                    DataFormatString="Rs.{0:###,###,###.00}" HtmlEncode="False" />
                                                                <asp:BoundField ItemStyle-Width="130px" DataField="TotalAmount" HeaderText="Total Amount"
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
                                                    <asp:Label ID="lblbillno" Visible="false" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                                    <asp:Label ID="lblfeeID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                    <asp:Label ID="lblacademic" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    ID
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladmisiionNo" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                    <asp:Label ID="lblStudentID" runat="server" Visible="false" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Class
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblclassid" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
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
                                                    Fee Type
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfeetype" runat="server" Text='<%# Eval("FeeType")%>'></asp:Label>
                                                    <asp:Label ID="lblfeeTypeID" Visible="false" runat="server" Text='<%# Eval("FeeTypeID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Total Fee
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeeSum" runat="server" Text='<%# Eval("TotalSumFeeAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Exempted
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexempted" runat="server" Text='<%# Eval("TotalexemptAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Fine
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfine" runat="server" Text='<%# Eval("TotalFineAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Total Bill
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltotalbill" runat="server" Text='<%# Eval("GrandTotalFeeAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="true">
                                                <HeaderTemplate>
                                                    Discount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("TotalDiscountAmount", "{0:0#.##}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Payable
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Eval("TotalPayableAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Paid
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpaidamount" runat="server" Text='<%# Eval("PaidAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Due
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldueamount" runat="server" Text='<%# Eval("TotalDueAmount", "{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Added By
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Added Date
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    Year
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" Visible="false" runat="server" Text='<%# Eval("IsactiveAll")%>'></asp:Label>
                                                    <asp:Label ID="lblacdademicID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                    <asp:Label ID="lblisactive" runat="server" Visible="false" Text='<%# Eval("IsActive")%>'></asp:Label>
                                                    <asp:Label ID="lblsession" runat="server" Text='<%# Eval("AcademicSessionName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Remarks
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtremarks" Class="form-control" Text='<%# Eval("Remarks")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Deletes" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Print
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="javascript: void(null);" onclick="Printbills('<%# Eval("BillNo")%>','<%# Eval("FeeTypeID")%>','<%# Eval("AcademicSessionID")%>'); return false;" class="cus-btn btn-sm btn-info button">Print</a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>

                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </div>

                            </div>
                            <div id="FeeCollectionDetailsListButtom" runat="server">
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Fee Amount: Rs.
                                        <asp:Label ID="lblSumtotalsumfeeamount" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Exempted: Rs.
                                         <asp:Label ID="lblexemptedamount" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Fine: Rs.
                                          <asp:Label ID="lbltotfine" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Bill: Rs.
                                          <asp:Label ID="lbltotalbillamount" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Discount: Rs.
                                        <asp:Label ID="lbltotaldiscount" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Payable: Rs. 
                                        <asp:Label ID="lbltotalpayable" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Paid: Rs
                                        <asp:Label ID="lbltotalpaidamount" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="RtextAlign">
                                        Total Due: Rs
                                        <asp:Label ID="lblTotalDueamount" ForeColor="#ff3300" runat="server" class="form-control "></asp:Label>
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
        function Validates() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlfeetypess.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select fee types."
                document.getElementById("<%=ddlfeetypess.ClientID %>").focus()
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

        function Printfeereciept() {
            objbillno = document.getElementById("<%= txtbillno.ClientID %>")
            objFeeTypeID = document.getElementById("<%= hdnfeetypeID.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicsession.ClientID %>")
            window.open("../EduFees/Reports/ReportViewer.aspx?option=FeeReciept&BillNo=" + objbillno.value + "&FeetypeID=" + objFeeTypeID.value + "&AcademicSessionID=" + objacademicID.value)
        }
        function Printbills(Bill, Feetype, AcademicSessionID) {
            window.open("../EduFees/Reports/ReportViewer.aspx?option=FeeReciept&FeetypeID=" + Feetype + "&BillNo=" + Bill + "&AcademicSessionID=" + AcademicSessionID)
        }
        function Printfeecollectionlist() {
            objStudentID = document.getElementById("<%= txtstudentIDs.ClientID %>")
            objStudentname = document.getElementById("<%= txtstudentanme.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objClassID = document.getElementById("<%= ddlclasses.ClientID %>")
            objSection = document.getElementById("<%= ddlsections.ClientID %>")
            objSex = document.getElementById("<%= ddlsexs.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")
            objStatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objfeetypes = document.getElementById("<%= ddlfeetypess.ClientID %>")
            if (document.getElementById("<%= ddlfeetypess.ClientID %>").selectedIndex == "0") {
                alert("please select fee types");
                return false;
            }
            else {
                window.open("../EduFees/Reports/ReportViewer.aspx?option=FeeCollectionlist&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&SexID=" + objSex.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value + "&Status=" + objStatus.value + "&StudentName=" + objStudentname.value + "&FeeTypeID=" + objfeetypes.value)
            }
        }


        $(function () {

            $('[id*=GvstudentDetails]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvstudentDetails]').footable();

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
    </script>

</asp:Content>
