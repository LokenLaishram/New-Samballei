<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddStudent.aspx.cs" Inherits="Mobimp.Edusoft.Web.AddStudent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="AddStudent.aspx">Add Student</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabStudent"><i class="icon nalika-edit" aria-hidden="true"></i>Student Details</a></li>
                <li><a href="#tabStudentList"><i class="icon nalika-picture" aria-hidden="true"></i>Student List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabStudent">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Student Informations</p>

                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbladmission" Text="Admission Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlamdission" AutoPostBack="true" OnSelectedIndexChanged="ddlamdission_SelectedIndexChanged"
                                                runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbladmissionNo" Text="Unique ID"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" MaxLength="10" ID="txtadmissionNo"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblAdmNo" Text="Admission No"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" ID="txtAdmNo"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                Enabled="True" TargetControlID="txtAdmNo" FilterType="Numbers,Custom" ValidChars="/">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladmissiondate" runat="server" Text="Admission Date"></asp:Label>
                                            <asp:TextBox ID="txtadmissioDate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtadmissioDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtadmissioDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblname" Text="Student's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtstudentname" MaxLength="200" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblDOB" runat="server" Text="Date of birth"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtDOB" type="text" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtDOB" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDOB" />

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblBirthRegNo" runat="server" Text="Birth Registration No."></asp:Label>
                                            <asp:TextBox ID="txtBirthRegNo" runat="server" MaxLength="30" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudenttype" runat="server" Text="Student Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstudenttype" runat="server" class="form-control ">
                                            </asp:DropDownList>
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
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblreleigion" runat="server" Text="Religion"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlreligion" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblMotherTongue" runat="server" Text="Mother Tongue"></asp:Label>
                                            <asp:TextBox ID="txtMotherTongue" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblBelongToBPL" runat="server" Text="Belong To BPL"></asp:Label>
                                            <asp:DropDownList ID="ddlBelongToBPL" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudentcategory" runat="server" Text="Category"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstudenycategory" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblhouse" runat="server" Text="House"></asp:Label>
                                            <asp:DropDownList ID="ddlhouse" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblIDmarks" Text="ID Marks"></asp:Label>
                                            <asp:TextBox ID="txtIDmarks" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Current Admission Class</p>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlclass" runat="server" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                class="form-control " AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlsection" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrollno" runat="server" Text="Roll No"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" ID="txtrollno"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_roll" runat="server"
                                                Enabled="True" TargetControlID="txtrollno" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblregdno" runat="server" Text="Registration Number"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" ID="txtregdno"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Basic Health Information</p>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblblood" runat="server" Text="Blood Group"></asp:Label>
                                            <asp:DropDownList ID="ddlbloodgroup" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblallergy" runat="server" Text="Allergic"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtallegry" MaxLength="100" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblHeight" runat="server" Text="Height"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtfisrtSessionheight" placeholder="Height(cm)" MaxLength="3"
                                                class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_height" runat="server"
                                                Enabled="True" TargetControlID="txtfisrtSessionheight" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblWeight" runat="server" Text="Weight"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="3" placeholder="Weight(kg)" ID="txtIstsessioninitialwt"
                                                class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filterweight" runat="server"
                                                Enabled="True" TargetControlID="txtIstsessioninitialwt" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Parents Information</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblfather" Text="Father's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtfathername" runat="server" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblmothername" Text="Mother's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtmothername" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfatherocupation" runat="server" Text="F-Occupation"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtfatheroccupation" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmotheroccupation" runat="server" Text="M-Occupation"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtmotheroccupation" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblincome" runat="server" Text="Parent's Income"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="7" ID="txtincome" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_fliter_income" runat="server"
                                                Enabled="True" TargetControlID="txtincome" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_gurdianName" runat="server" Text="Guradian's Name"></asp:Label>
                                            <asp:TextBox runat="server" ID="txt_GuardianName" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrelationship" runat="server" Text="Relationship with student"></asp:Label>
                                            <asp:DropDownList ID="ddlrelationship" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblgmobile" runat="server" Text="Mobile No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" ID="txtgmobile" MaxLength="10" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl" runat="server" Text="Alt.Mobile No"></asp:Label>
                                            <asp:TextBox runat="server" ID="txt_altmobileno" MaxLength="10" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Last School Information</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblschoolname" runat="server" Text="School Name"></asp:Label>
                                            <asp:TextBox ID="txtlastschoolName" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblLastClass" runat="server" Text="Last Class"></asp:Label>
                                            <asp:TextBox ID="txtlastclass" runat="server" placeholder="Class" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllastsection" runat="server" Text="Last Section"></asp:Label>
                                            <asp:TextBox ID="txtlastsection" placeholder="Section" runat="server"
                                                class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblLastRoll" runat="server" Text="Last Roll"></asp:Label>
                                            <asp:TextBox ID="txtlastroll" runat="server" placeholder="Roll" class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_lastroll" runat="server"
                                                Enabled="True" TargetControlID="txtlastroll" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllastMark" runat="server" Text="Last Mark"></asp:Label>
                                            <asp:TextBox ID="txtlatsmarks" MaxLength="11" placeholder="MARK" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblAttendance" runat="server" Text="Attendance"></asp:Label>
                                            <asp:TextBox ID="txtattendance" MaxLength="11" placeholder="Attendance" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Bank Information</p>
                                    </div>
                                </div>
                                <div class="row customRow">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbank" runat="server" Text="Bank Name"></asp:Label>
                                            <asp:TextBox ID="txtbankname" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="llblIfsc" runat="server" Text="IFSC"></asp:Label>
                                            <asp:TextBox ID="txtifsc" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblac" runat="server" Text="A/C No."></asp:Label>
                                            <asp:TextBox ID="txtaccountno" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblaadhar" runat="server" Text="Aadhaar No."></asp:Label>
                                            <asp:TextBox ID="txtaadhar" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Current Address Information</p>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtaddress" MaxLength="200" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblcountry" runat="server" Text="Country"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlcountry" runat="server"  OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"
                                                AutoPostBack="true" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblst" runat="server" Text="State"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>

                                            <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"
                                                class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbdistrict" runat="server" Text="District"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpin" runat="server" Text="Pin No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtpin" runat="server" MaxLength="6" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBox" runat="server" Enabled="True"
                                                TargetControlID="txtpin" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">
                                            Permanant Address Information    &nbsp;&nbsp;
                                            <asp:CheckBox ID="chksame" CssClass="Checkboxstyel" runat="server" AutoPostBack="True"
                                                OnCheckedChanged="chksame_CheckedChanged" />
                                            Same as current address.
                                        </p>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpaddressss" runat="server" Text="Address"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtpaddress" MaxLength="200" runat="server" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpcountry" runat="server" Text="Country"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlpcountry" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpstate" runat="server" Text="State"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlpstate" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpdistrict" runat="server" Text="District"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlpdistrict" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblppin" runat="server" Text="Pin No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtppin" runat="server" MaxLength="6" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group pull-right">
                                            <asp:Button ID="btnsave" class="btn btn-sm btn-green button " runat="server" OnClick="btnsave_Click"
                                                OnClientClick="return Validate();" Text="Add" />
                                            <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" OnClick="btncancel_Click" runat="server"
                                                Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="tabStudentList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesions" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                            <asp:Label runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladmisiontype" runat="server" Text="Admission Type"></asp:Label>
                                            <asp:DropDownList ID="ddladmissiontype" AutoPostBack="true" OnSelectedIndexChanged="ddladmissiontype_SelectedIndexChanged" class="form-control " runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblcategories" runat="server" Text="Student Category"></asp:Label>
                                            <asp:DropDownList ID="ddlcategorys" AutoPostBack="true" OnSelectedIndexChanged="ddlcategorys_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudenttypes" runat="server" Text="Student Type"></asp:Label>
                                            <asp:DropDownList ID="ddllstudentypes" AutoPostBack="true" OnSelectedIndexChanged="ddllstudentypes_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudentanme" runat="server" Text="Name"></asp:Label>
                                            <asp:TextBox runat="server" OnTextChanged="txtstudentanme_TextChanged" AutoPostBack="true"
                                                ID="txtstudentanme" class="form-control"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="Getautostudentlist" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtstudentanme"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                            <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" class="form-control "
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlsections" AutoPostBack="true" OnSelectedIndexChanged="ddlsections_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_roll" runat="server" Text="Roll No."></asp:Label>
                                            <asp:TextBox ID="txt_roll" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                Enabled="True" TargetControlID="txt_roll" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsexs" runat="server" Text="Gender"></asp:Label>
                                            <asp:DropDownList ID="ddlsexs" AutoPostBack="true" OnSelectedIndexChanged="ddlsexs_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblcastes" runat="server" Text="Caste"></asp:Label>
                                            <asp:DropDownList ID="ddlcastes" AutoPostBack="true" OnSelectedIndexChanged="ddlcastes_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblhusename" runat="server" Text="House"></asp:Label>
                                            <asp:DropDownList ID="ddlhouselist" AutoPostBack="true" OnSelectedIndexChanged="ddlhouselist_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <div class="row ">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Admission Status"></asp:Label>
                                            <asp:DropDownList ID="ddl_admissionstatus" AutoPostBack="true" OnSelectedIndexChanged="ddl_admissionstatus_SelectedIndexChanged" runat="server" class="form-control ">
                                                <asp:ListItem Value="5">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Done</asp:ListItem>
                                                <asp:ListItem Value="0">Not Done </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtfrom" runat="server" AutoPostBack="true" OnTextChanged="txtfrom_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtfrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                            <asp:TextBox ID="txtto" AutoPostBack="true" OnTextChanged="txtto_TextChanged" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbluser" runat="server" Text="Added By"></asp:Label>
                                            <asp:DropDownList ID="ddluser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddluser_SelectedIndexChanged" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button " Text="Search" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btnreset" Visible="false" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                            <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnprint_Click" />
                                            <asp:Button ID="btnprintprofile" Visible="false" class="btn btn-sm btn-success button " runat="server" Text="Print Profile List"
                                                OnClientClick="return PrintstudentProfile();" />
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
                                    <div id="Studentlist" style="min-height: 70vh; width: 100%; overflow-x: auto" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvstudentDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvstudentDetails_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnRowDataBound="GvstudentDetails_RowDataBound" OnRowCommand="GvstudentDetails_RowCommand" OnSorting="GvstudentDetails_Sorting" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:BoundField DataField="StudentID" SortExpression="StudentID" HeaderText="Student ID" />
                                                <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Name" />
                                                <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" />
                                                <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" />
                                                <asp:BoundField DataField="RollNo" SortExpression="RollNo" HeaderText="Roll No." />
                                                <asp:BoundField DataField="SexName" SortExpression="SexName" HeaderText="Gender" />
                                                <asp:BoundField DataField="pAddress" SortExpression="pAddress" HeaderText="Address" />
                                                <asp:BoundField DataField="GmobileNo" SortExpression="GmobileNo" HeaderText="Mobile No." />
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Adm.Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_status" Visible="false" runat="server" Text='<%# Eval("IsAdmissionDone")%>'></asp:Label>
                                                        <asp:Label ID="lbl_date" Width="70px" runat="server" Text='<%# Eval("AdmissionDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField >
                                                    <HeaderTemplate>
                                                        Remark
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtremarks" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remarks")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Edit
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                        <asp:Button ID="btn_edit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Edits" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <%--    <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Activate
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_activate" runat="server" class="cus-btn btn-sm btn-info button" Text="Activate" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="activate" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Profile
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_profileview" runat="server" Text="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="View" class="cus-btn btn-sm btn-success button" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>--%>
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
        function Validate() {

            var str = ""
            var i = 0
            var value = document.getElementById("<%=txtemail.ClientID %>").value;
            if (value != "") {
                var atposition = value.indexOf("@");
                var dotposition = value.lastIndexOf(".");
                if (atposition < 1 || dotposition < atposition + 2 || dotposition + 2 >= value.length) {
                    str = str + " Please enter a valid e-mail address.\n"
                    document.getElementById("<%=txtemail.ClientID %>").focus()
                    i++
                }
            }
            if (document.getElementById("<%=ddlamdission.ClientID%>").selectedIndex == "0") {
                str = str + " Please select admission type.\n"
                document.getElementById("<%=ddlamdission.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtadmissioDate.ClientID%>").value == "") {
                str = str + " Please enter admission date.\n"
                document.getElementById("<%=txtadmissioDate.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtstudentname.ClientID%>").value == "") {
                str = str + " Please enter student name.\n"
                document.getElementById("<%=txtstudentname.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlCast.ClientID%>").selectedIndex == "0") {
                str = str + " Please select caste.\n"
                document.getElementById("<%=ddlCast.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlsex.ClientID%>").selectedIndex == "0") {
                str = str + " Please select sex. \n"
                document.getElementById("<%=ddlsex.ClientID %>").focus()
                i++
            }
            <%--if (document.getElementById("<%=txtDOB.ClientID%>").value == "") {
                str = str + " Please enter DOB. \n"
                document.getElementById("<%=txtDOB.ClientID %>").focus()
                i++
            }--%>
            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + "Please select class. \n"
                document.getElementById("<%=ddlclass.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtfathername.ClientID%>").value == "") {
                str = str + " Please enter father's name. \n"
                document.getElementById("<%=txtfathername.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtmothername.ClientID%>").value == "") {
                str = str + " Please enter mother's name. \n"
                document.getElementById("<%=txtmothername.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtaddress.ClientID%>").value == "") {
                str = str + " Please enter current address. \n"
                document.getElementById("<%=txtaddress.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlcountry.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select current country."
                document.getElementById("<%=ddlcountry.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlstate.ClientID%>").selectedIndex == "0") {
                str = str + " Please select current state. \n"
                document.getElementById("<%=ddlstate.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlDistrict.ClientID%>").selectedIndex == "0") {
                str = str + " Please select current state. \n"
                document.getElementById("<%=ddlDistrict.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtgmobile.ClientID%>").value == "") {
                str = str + " Please enter mobile no. \n"
                document.getElementById("<%=txtgmobile.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtpin.ClientID%>").value == "") {
                str = str + " Please enter current pin no. \n"
                document.getElementById("<%=txtpin.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtpaddress.ClientID%>").value == "") {
                str = str + " Please enter permanent address. \n"
                document.getElementById("<%=txtpaddress.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlpcountry.ClientID%>").selectedIndex == "0") {
                str = str + " Please select permanent country. \n"
                document.getElementById("<%=ddlpcountry.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlpstate.ClientID%>").selectedIndex == "0") {
                str = str + " Please select permanant state. \n"
                document.getElementById("<%=ddlpstate.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlpdistrict.ClientID%>").selectedIndex == "0") {
                str = str + " Please select permanant state. \n"
                document.getElementById("<%=ddlpdistrict.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtppin.ClientID%>").value == "") {
                str = str + " Please enter permanent pin no. \n"
                document.getElementById("<%=txtppin.ClientID %>").focus()
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
                        __doPostBack('<%=GvstudentDetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }

        function Printstudentlist() {
            objClassID = document.getElementById("<%= ddlclasses.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objSection = document.getElementById("<%= ddlsections.ClientID %>")
            objStudentname = document.getElementById("<%= txtstudentanme.ClientID %>")
            objSex = document.getElementById("<%= ddlsexs.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")
            objStatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objCastes = document.getElementById("<%= ddlcastes.ClientID %>")
            ObjadmissionType = document.getElementById("<%= ddladmissiontype.ClientID %>")
            objCategory = document.getElementById("<%= ddlcategorys.ClientID %>")
            ObJuserID = document.getElementById("<%= ddluser.ClientID %>")
            ObHouseID = document.getElementById("<%= ddlhouselist.ClientID %>")
            ObStudentTypeID = document.getElementById("<%= ddllstudentypes.ClientID %>")
            objadmissionstatus = document.getElementById("<%= ddl_admissionstatus.ClientID %>")
            window.open("../EduStudent/Reports/ReportViewer.aspx?option=StudentList&SessionID=" + objacademicID.value + "&SexID=" + objSex.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Category=" + objCategory.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value + "&IsActive=" + objStatus.value + "&StudentName=" + objStudentname.value + "&Status=" + objStatus.value + "&IsNew=" + ObjadmissionType.value + "&CasteID=" + objCastes.value + "&UserID=" + ObJuserID.value + "&HouseID=" + ObHouseID.value + "&StudentTypeID=" + ObStudentTypeID.value + "&Admissionstatus=" + objadmissionstatus.value)
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

