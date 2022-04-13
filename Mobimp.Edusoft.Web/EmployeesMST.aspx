<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeesMST.aspx.cs" Inherits="Mobimp.Edusoft.Web.EmployeesMST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Employee &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="EmployeesMST.aspx">Empolyee Details</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabEmployee"><i class="icon nalika-edit" aria-hidden="true"></i>Employee Details</a></li>
                <li><a href="#tabEmployeeList"><i class="icon nalika-picture" aria-hidden="true"></i>Employee List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabEmployee">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Employee Information</p>

                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="lblempNo" runat="server" Text="Emp No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtempno" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtempno" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblsalutation" Text="Salutation">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlsalutation" runat="server" AutoPostBack="true" class="form-control "
                                                OnSelectedIndexChanged="ddlsalutation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblempname" Text="Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtempname" MaxLength="60" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtempname" ID="FilteredTextBoxExtender5"
                                                runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblCast" runat="server" Text="Caste"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlCast" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsex" runat="server" Text="Gender"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlsex" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblDOJ" runat="server" Text="Date Of Joining"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtdateofjoining" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtdateofjoining" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdateofjoining" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblDOB" runat="server" Text="DOB"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtDOB" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="calextndrBillingFrom" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtDOB" />
                                            <asp:MaskedEditExtender ID="MEERefundToDate" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDOB" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstate" runat="server" Text="Employee Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlemplyee" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldesignation" runat="server" Text="Designation"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddldesignation" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblempcategory" runat="server" Text="Employee Category"></asp:Label>
                                            <asp:DropDownList ID="ddlempcategory" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblreleigion" runat="server" Text="Religion"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlreligion" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <div class="row ">

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmarital" runat="server" Text="Marital Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlmarital" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Blood Group"></asp:Label>
                                            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlbloodgroup" runat="server" class="form-control ">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlbloodgroup" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblStaffType" runat="server" Text="Staff Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlStaffTypeID" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblemailID" runat="server" Text="Email ID"></asp:Label>
                                            <asp:TextBox ID="txtemailid" MaxLength="100" runat="server" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtemailid" ID="FilteredTextBoxExtender6"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=" @.-_"
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <td>
                                                <asp:Label ID="lblmobile" runat="server" Text="MobileNo"></asp:Label>
                                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                                <asp:TextBox ID="txtmobile" runat="server" class="form-control " MaxLength="10"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender TargetControlID="txtmobile" ID="FilteredTextBoxExtender1"
                                                    runat="server" ValidChars="1234567890" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblexperience" runat="server" Text="Experience"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtexperience" MaxLength="50" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtexperience" ID="FilteredTextBoxExtender10"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblprofesqualification" runat="server" Text="Profes. Qualification"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="50" ID="txtprofessioanlqualification" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtprofessioanlqualification" ID="FilteredTextBoxExtender11"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblIDmarks" Text="ID Marks"></asp:Label>
                                            <asp:TextBox ID="txtIDmarks" MaxLength="100" runat="server" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtIDmarks" ID="FilteredTextBoxExtender9"
                                                runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbluniversity" runat="server" Text="University"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtuniversity" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtuniversity" ID="FilteredTextBoxExtender12"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblepf" runat="server" Text="EPF No."></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="20" ID="txtepfno" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtepfno" ID="FilteredTextBoxExtender13"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblifsc" runat="server" Text="IFSC"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="30" ID="txtifsc" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtifsc" ID="FilteredTextBoxExtender14"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbank" runat="server" Text="Bank Name"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="50" ID="txtbank" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtbank" ID="FilteredTextBoxExtender15"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblaccountno" runat="server" Text="A/C no."></asp:Label>
                                            <asp:TextBox runat="server" ID="txtaccountno" MaxLength="20" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtaccountno" ID="FilteredTextBoxExtender16"
                                                runat="server" FilterType="Numbers"
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <%--  <div class="col-md-2 customRow" style="visibility: hidden">
                                        <div class="form-group">
                                            <asp:Label ID="lblDigitalSignature" runat="server" Text="Digital signature"></asp:Label>
                                            <asp:FileUpload ID="digiupload" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow" style="visibility: hidden">
                                        <div class="form-group">
                                            <asp:Label ID="lblphoto" runat="server" Text="Upload Photo"></asp:Label>
                                            <asp:FileUpload ID="FileUploader" runat="server" />
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Current Address Details</p>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtaddress" MaxLength="100" runat="server" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtaddress" ID="FilteredTextBoxExtender17"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblcountry" runat="server" Text="Country"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlcountry" runat="server" AutoPostBack="true" class="form-control "
                                                OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblst" runat="server" Text="State"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" class="form-control "
                                                OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl" runat="server" Text="District"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpin" runat="server" Text="Pin No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtpin" MaxLength="6" runat="server" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtpin" ID="FilteredTextBoxExtender3"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllandmarks" runat="server" Text="Land Mark"></asp:Label>
                                            <asp:TextBox ID="txtlandmark" runat="server" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtlandmark" ID="FilteredTextBoxExtender18"
                                                runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=" "
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">
                                            Permanent Address Details &emsp;
                                        <asp:CheckBox ID="chksame" CssClass="Checkboxstyel" Style="vertical-align: middle;" runat="server" AutoPostBack="True"
                                            OnCheckedChanged="chksame_CheckedChanged" />
                                            Is Same?
                                        </p>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladdress1" runat="server" Text="Address"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtaddress1" runat="server" AutoPostBack="true" class="form-control "></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblcountry1" runat="server" Text="Country"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlcountry1" runat="server" AutoPostBack="true" class="form-control "
                                                OnSelectedIndexChanged="ddlcountry1_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstate1" runat="server" Text="State"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstate1" runat="server" AutoPostBack="true" class="form-control "
                                                OnSelectedIndexChanged="ddlstate1_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldistrict1" runat="server" Text="District"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddldistrict1" runat="server" class="form-control " AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpin1" runat="server" Text="Pin No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtpin1" MaxLength="6" runat="server" class="form-control " AutoPostBack="true"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtpin1" ID="FilteredTextBoxExtender4"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllandmark1" runat="server" Text="Land Mark"></asp:Label>
                                            <asp:TextBox ID="txtlandmark1" runat="server" class="form-control "></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" class="btn btn-sm btn-green button "
                                                OnClientClick="return Validate() " Text="Add" />
                                            <asp:Button ID="btnreset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="tabEmployeeList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblempnames" runat="server" Text="Employee Name"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtempnames" class="form-control "></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetautoEmployeelist" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtempnames"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblacademicsession" runat="server" Text="Academic Session"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsexs" runat="server" Text="Gender"></asp:Label>
                                            <asp:DropDownList ID="ddlsexs" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblemployeeNo" runat="server" Text="Employee No"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="20" ID="txtemployeedID" class="form-control "></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtemployeedID" ID="txtentenderEID"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblempcaategorys" runat="server" Text="Employee Category"></asp:Label>
                                            <asp:DropDownList ID="ddlempcategories" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>

                                <div class="row ">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblStaffTypeTab2" runat="server" Text="Staff Type"></asp:Label>
                                            <asp:DropDownList ID="ddlStaffTypeTab2" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-8 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-success button" Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btnCancel" Visible="false" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnCancel_Click" />
                                            <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" OnClientClick="return Printemplist();" Text="Print" />
                                            <asp:Button ID="btnprintprofile" Visible="false" class="btn btn-sm btn-indigo button " runat="server" OnClientClick="return PrintempProfile();" Text="Print Profile" />
                                            <%--  <asp:Button ID="btnexport" runat="server" CssClass="button" Text="Export To Excel" OnClick="btnexport_Click" />--%>
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
                                            <asp:DropDownList ID="ddl_show" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged">

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

                                    <div id="Studentlist" class="col-md-12 customRow ">
                                        <asp:UpdatePanel ID="UPGvemployeeDetails" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GvemployeeDetails" CssClass="footable table-striped" runat="server" EmptyDataText="No record found..."
                                                    OnRowCommand="GvemployeeDetails_RowCommand" OnSorting="GvEmployeeDetails_Sorting" AutoGenerateColumns="False" Width="100%" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Sl.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Photo">
                                                            <ItemTemplate>
                                                                <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%# Bind("EmployeePhotoLocation") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1.5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Emp No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
                                                                <%-- <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Emp Code
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempcode" runat="server" Text='<%# Eval("EmployeeCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Emp Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcode" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Gender
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsex" runat="server" Text='<%# Eval("SexName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                                Added By
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                                Added Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Remarks
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" class="form-control " Text='<%# Eval("Remarks")%>'
                                                                    ID="txtremarks"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Edit
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                    <ContentTemplate>--%>
                                                                <asp:Button ID="btn_edit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Edits" />
                                                                <%--</ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btn_edit" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Delete
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                    <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                                </asp:GridView>
                                            </ContentTemplate>

                                        </asp:UpdatePanel>
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
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=GvemployeeDetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }
        function Printemplist() {
            objempnames = document.getElementById("<%= txtempnames.ClientID %>")
            objacademicsessionID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objSexID = document.getElementById("<%= ddlsexs.ClientID %>")
            objEmpID = document.getElementById("<%= txtemployeedID.ClientID %>")
            objstatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objEmpCategory = document.getElementById("<%= ddlempcategories.ClientID %>")
           
            window.open("../EduEmployee/Reports/ReportViewer.aspx?option=Emplist&EmpName=" + objempnames.value + "&SessionID=" + objacademicsessionID.value + "&SexID=" + objSexID.value + "&EmpNo=" + objEmpID.value + "&Status=" + objstatus.value + "&EmpCategory=" + objEmpCategory.value )

        }
        function PrintempProfile() {
            objempnames = document.getElementById("<%= txtempnames.ClientID %>")
            objacademicsessionID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objSexID = document.getElementById("<%= ddlsexs.ClientID %>")
            objEmpID = document.getElementById("<%= txtemployeedID.ClientID %>")
            objstatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objEmpCategory = document.getElementById("<%= ddlempcategories.ClientID %>")


            window.open("../EduEmployee/Reports/ReportViewer.aspx?option=EmpProfile&EmpName=" + objempnames.value + "&SessionID=" + objacademicsessionID.value + "&SexID=" + objSexID.value + "&EmpNo=" + objEmpID.value + "&Status=" + objstatus.value + "&EmpCategory=" + objEmpCategory.value )

        }
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=txtempno.ClientID%>").value == "") {
                str = str + "\n Please enter Employee No."
                document.getElementById("<%=txtempno.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtempname.ClientID%>").value == "") {
                str = str + "\n Please enter Employee Name."
                document.getElementById("<%=txtempname.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlsalutation.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select salutation."
                document.getElementById("<%=ddlsalutation.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlCast.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Cast."
                document.getElementById("<%=ddlCast.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlreligion.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Religion."
                document.getElementById("<%=ddlreligion.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlsex.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Gender."
                document.getElementById("<%=ddlsex.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtdateofjoining.ClientID%>").value == "") {
                str = str + "\n Please enter Date Of joining."
                document.getElementById("<%=txtdateofjoining.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtDOB.ClientID%>").value == "") {
                str = str + "\n Please enter DOB."
                document.getElementById("<%=txtDOB.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddldesignation.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select designation."
                document.getElementById("<%=ddldesignation.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtmobile.ClientID%>").value == "") {
                str = str + "\n Please enter moibile no."
                document.getElementById("<%=txtmobile.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlemplyee.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select employee type."
                document.getElementById("<%=ddlemplyee.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlStaffTypeID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Staff Type."
                document.getElementById("<%=ddlStaffTypeID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtemailid.ClientID%>").value != "") {
                var x = document.getElementById("<%=txtemailid.ClientID%>").value;
                var atpos = x.indexOf("@");
                var dotpos = x.lastIndexOf(".");
                if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                    alert("Not a valid e-mail address");
                    return false;
                }
            }
            if (document.getElementById("<%=ddlmarital.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select marital status."
                document.getElementById("<%=ddlmarital.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtaddress.ClientID%>").value == "") {
                str = str + "\n Please enter current address."
                document.getElementById("<%=txtaddress.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlcountry.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select current country."
                document.getElementById("<%=ddlcountry.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlstate.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select current state."
                document.getElementById("<%=ddlstate.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlDistrict.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select current state."
                document.getElementById("<%=ddlDistrict.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtpin.ClientID%>").value == "") {
                str = str + "\n Please enter current pin no."
                document.getElementById("<%=txtpin.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtaddress1.ClientID%>").value == "") {
                str = str + "\n Please enter permanent address."
                document.getElementById("<%=txtaddress1.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlcountry1.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select permanent country."
                document.getElementById("<%=ddlcountry1.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=ddlstate1.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select permanant state."
                document.getElementById("<%=ddlstate1.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddldistrict1.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select permanant state."
                document.getElementById("<%=ddldistrict1.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtpin1.ClientID%>").value == "") {
                str = str + "\n Please enter permanant pin no."
                document.getElementById("<%=txtpin.ClientID %>").focus()
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
        $(function () {

            $('[id*=GvemployeeDetails]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvemployeeDetails]').footable();

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

















