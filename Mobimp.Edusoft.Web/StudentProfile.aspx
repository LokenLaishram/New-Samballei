<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="StudentProfile.aspx.cs" Inherits="Mobimp.Edusoft.Web.StudentProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a href="AddStudent.aspx">Add Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a class="active" runat="server" id="activepage" href="AddStudent.aspx">Student Profile View</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabStudent"><i class="icon nalika-edit" aria-hidden="true"></i>StudentProfile</a></li>
                <%--<li><a href="#tabStudentList"><i class="icon nalika-picture" aria-hidden="true"></i>Student List</a></li>--%>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabStudent" style="width:70%;float: left;">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Student Informations                                            
                                        <asp:Button ID="btnminimizetap1"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap1_Click" />
                                        <asp:Button ID="btnmaximizetap1"  runat="server" style="float: right;font-size:larger" Text="+"  OnClick="btnmaximizetap1_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap1" runat="server">
                                <div class="row mt10">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbladmission" Text="Admission Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlamdission" AutoPostBack="true" OnSelectedIndexChanged="ddlamdission_SelectedIndexChanged"
                                                runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="col-md-2 customRow" >
                                        <div class="form-group" >
                                            <asp:Label runat="server" ID="lbladmissionNo"  Text="Unique ID"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" MaxLength="10"  ID="txtadmissionNo"></asp:TextBox>

                                        </div>
                                    </div>--%>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblname" Text="Student's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtstudentname"  MaxLength="200" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblAdmNo" Text="Admission No"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" ID="txtAdmNo"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                Enabled="True" TargetControlID="txtAdmNo" FilterType="Numbers,Custom" ValidChars="/">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                 </div>
                                <div class="row ">
                                    <div class="col-md-4 customRow">
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
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblBirthRegNo" runat="server" Text="Birth Registration No."></asp:Label>
                                            <asp:TextBox ID="txtBirthRegNo" runat="server" MaxLength="30" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudenttype" runat="server" Text="Student Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstudenttype" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    </div>
                                <div class="row ">
                                     <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblCast" runat="server" Text="Caste"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlCast" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsex" runat="server" Text="Gender"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlsex" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblreleigion" runat="server" Text="Religion"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlreligion" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    </div>
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblMotherTongue" runat="server" Text="Mother Tongue"></asp:Label>
                                            <asp:TextBox ID="txtMotherTongue" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblBelongToBPL" runat="server" Text="Belong To BPL"></asp:Label>
                                            <asp:DropDownList ID="ddlBelongToBPL" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudentcategory" runat="server" Text="Category"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstudenycategory" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblhouse" runat="server" Text="House"></asp:Label>
                                            <asp:DropDownList ID="ddlhouse" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblIDmarks" Text="ID Marks"></asp:Label>
                                            <asp:TextBox ID="txtIDmarks" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblphoto" runat="server" Visible="false" Text="Upload Photo"></asp:Label>
                                            <asp:FileUpload class="btn1" ID="studentphotouploader" Visible="false" runat="server" />

                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap1edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap1edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap1save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap1save_Click" Text="Save" />
                                            <asp:Button ID="btntap1cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap1cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Current Admission Class
                                        <asp:Button ID="btnminimizetap2"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap2_Click" />
                                        <asp:Button ID="btnmaximizetap2"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap2_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap2" runat="server">
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlclass" runat="server" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                class="form-control " >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlsection" runat="server" class="form-control " AutoPostBack="true">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrollno" runat="server" Text="Roll No"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" ID="txtrollno"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_roll" runat="server"
                                                Enabled="True" TargetControlID="txtrollno" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblregdno" runat="server" Text="Registration Number"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" ID="txtregdno"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap2edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap2edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap2save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap2save_Click" Text="Save" />
                                            <asp:Button ID="btntap2cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap2cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Basic Health Information
                                        <asp:Button ID="btnminimizetap3"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap3_Click" />
                                        <asp:Button ID="btnmaximizetap3"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap3_Click" />
                                        </p>

                                    </div>
                                </div>
                                <div id="Tap3" runat="server">
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblblood" runat="server" Text="Blood Group"></asp:Label>
                                            <asp:DropDownList ID="ddlbloodgroup" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblallergy" runat="server" Text="Allergic"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtallegry" MaxLength="100" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblHeight" runat="server" Text="Height"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtfisrtSessionheight" placeholder="Height(cm)" MaxLength="3"
                                                class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_height" runat="server"
                                                Enabled="True" TargetControlID="txtfisrtSessionheight" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblWeight" runat="server" Text="Weight"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="3" placeholder="Weight(kg)" ID="txtIstsessioninitialwt"
                                                class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filterweight" runat="server"
                                                Enabled="True" TargetControlID="txtIstsessioninitialwt" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap3edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap3edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap3save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap3save_Click" Text="Save" />
                                            <asp:Button ID="btntap3cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap3cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                </div>
                                    </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Guardian Information
                                        <asp:Button ID="btnminimizetap4"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap4_Click" />
                                        <asp:Button ID="btnmaximizetap4"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap4_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap4" runat="server">
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblfather" Text="Father's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtfathername" runat="server" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblmothername" Text="Mother's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtmothername" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrelationship" runat="server" Text="Relationship"></asp:Label>
                                            <asp:DropDownList ID="ddlrelationship" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfatherocupation" runat="server" Text="F-Occupation"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtfatheroccupation" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmotheroccupation" runat="server" Text="M-Occupation"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtmotheroccupation" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblincome" runat="server" Text="Parent's Income"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="7" ID="txtincome" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_fliter_income" runat="server"
                                                Enabled="True" TargetControlID="txtincome" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    </div>
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblgmobile" runat="server" Text="Mobile No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" ID="txtgmobile" MaxLength="10" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap4edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap4edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap4save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap4save_Click" Text="Save" />
                                            <asp:Button ID="btntap4cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap4cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                </div>
                                </div>

                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Last School Information
                                        <asp:Button ID="btnminimizetap5"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap5_Click" />
                                        <asp:Button ID="btnmaximizetap5"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap5_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap5" runat="server">
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblschoolname" runat="server" Text="School Name"></asp:Label>
                                            <asp:TextBox ID="txtlastschoolName" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblLastClass" runat="server" Text="Last Class"></asp:Label>
                                            <asp:TextBox ID="txtlastclass" runat="server" placeholder="Class" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllastsection" runat="server" Text="Last Section"></asp:Label>
                                            <asp:TextBox ID="txtlastsection" placeholder="Section" runat="server"
                                                class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblLastRoll" runat="server" Text="Last Roll"></asp:Label>
                                            <asp:TextBox ID="txtlastroll" runat="server" placeholder="Roll" class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_lastroll" runat="server"
                                                Enabled="True" TargetControlID="txtlastroll" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>                                    
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllastMark" runat="server" Text="Last Mark Obtain"></asp:Label>
                                            <asp:TextBox ID="txtlatsmarks" MaxLength="11" placeholder="MARK" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblAttendance" runat="server" Text="Attendance"></asp:Label>
                                            <asp:TextBox ID="txtattendance" MaxLength="11" placeholder="Attendance" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap5edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap5edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap5save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap5save_Click" Text="Save" />
                                            <asp:Button ID="btntap5cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap5cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                </div>
                                    </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Bank Information
                                        <asp:Button ID="btnminimizetap6"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap6_Click" />
                                        <asp:Button ID="btnmaximizetap6"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap6_Click" />
                                        </p>

                                    </div>
                                </div>
                                <div id="Tap6" runat="server">
                                <div class="row customRow">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbank" runat="server" Text="Bank Name"></asp:Label>
                                            <asp:TextBox ID="txtbankname" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="llblIfsc" runat="server" Text="IFSC"></asp:Label>
                                            <asp:TextBox ID="txtifsc" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblac" runat="server" Text="A/C No."></asp:Label>
                                            <asp:TextBox ID="txtaccountno" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblaadhar" runat="server" Text="Aadhaar No."></asp:Label>
                                            <asp:TextBox ID="txtaadhar" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap6edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap6edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap6save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap6save_Click" Text="Save" />
                                            <asp:Button ID="btntap6cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap6cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                </div>
                                    </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Current Address Information
                                        <asp:Button ID="btnminimizetap7"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap7_Click" />
                                        <asp:Button ID="btnmaximizetap7"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap7_Click" />
                                        </p>

                                    </div>
                                </div>
                                <div id="Tap7" runat="server">
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                                            <asp:TextBox ID="txtaddress" MaxLength="200" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap7edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap7edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap7save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap7save_Click" Text="Save" />
                                            <asp:Button ID="btntap7cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap7cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                    </div>
                                    <%--<div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblcountry" runat="server" Text="Country"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"
                                                AutoPostBack="true" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblst" runat="server" Text="State"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>

                                            <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"
                                                class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbdistrict" runat="server" Text="District"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpin" runat="server" Text="Pin No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtpin" runat="server" MaxLength="6" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBox" runat="server" Enabled="True"
                                                TargetControlID="txtpin" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllandmarks" runat="server" Text="Land Mark"></asp:Label>
                                            <asp:TextBox ID="txtlandmark" MaxLength="100" runat="server" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Permanant Address Information
                                        <asp:Button ID="btnminimizetap8"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap8_Click" />
                                        <asp:Button ID="btnmaximizetap8"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap8_Click" />
                                        </p>

                                    </div>
                                </div>
                                <div id="Tap8" runat="server">
                                <div class="row ">
                                   <%-- <div class="col-md-12">
                                        <p class="">
                                            <asp:CheckBox ID="chksame" CssClass="Checkboxstyel" runat="server" AutoPostBack="True"
                                                OnCheckedChanged="chksame_CheckedChanged" />
                                            Same as current address.
                                        </p>
                                    </div>--%>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpaddressss" runat="server" Text="Address"></asp:Label>
                                            <asp:TextBox ID="txtpaddress" MaxLength="200" runat="server" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap8edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap8edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap8save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap8save_Click" Text="Save" />
                                            <asp:Button ID="btntap8cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap8cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                    </div>
                                    </div>
                            </div>
                                   <%-- <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpcountry" runat="server" Text="Country"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlpcountry" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpstate" runat="server" Text="State"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlpstate" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblpdistrict" runat="server" Text="District"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlpdistrict" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblppin" runat="server" Text="Pin No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtppin" runat="server" MaxLength="6" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblplandmarks" runat="server" Text="Land Mark"></asp:Label>
                                            <asp:TextBox ID="txtplandmarks" MaxLength="100" runat="server" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>--%>
                                    
                                        
                                    
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Subject Information
                                        <asp:Button ID="btnminimizetap9"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnminimizetap9_Click" />
                                        <asp:Button ID="btnmaximizetap9"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnmaximizetap9_Click" />
                                        </p>

                                    </div>
                                </div>
                                <div id="Tap9" runat="server">
                                <div class="row">
                                <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesions" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsubjectlist" runat="server" Text="Subject List"></asp:Label>
                                            <asp:TextBox ID="txtsubjectlist" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group pull-right" style="margin-top: 3%; ">
                                        <asp:Button ID="btntap9edit" class="btn btn-sm btn-blue button " runat="server" OnClick="btntap9edit_Click" Text="Edit" />
                                            <asp:Button ID="btntap9save" class="btn btn-sm btn-green button " runat="server" Visible ="false" OnClick="btntap9save_Click" Text="Save" />
                                            <asp:Button ID="btntap9cancel" class="btn btn-sm btn-danger button" Visible="false" OnClick="btntap9cancel_Click" runat="server"
                                                Text="Cancel" />
                                    </div>
                                    <asp:Button ID="btnsave" class="btn btn-sm btn-green button " Visible="false" runat="server" OnClick="btnsave_Click"
                                                OnClientClick="return Validate();" Text="Add" />
                                            <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" visible="false" OnClick="btncancel_Click" runat="server"
                                                Text="Reset" />
                                </div>
                                </div>
                                </div>

                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </div>
                    <div class="product-tab-list tab-pane fade active in"  style="width:29%;float: right;">
                    <asp:UpdatePanel ID="RightPanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Fee Status
                                        <asp:Button ID="btnTap2minimize1"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnTap2minimize1_Click" />
                                        <asp:Button ID="btnTap2maximize1"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnTap2maximize1_Click" />
                                        </p>                                        
                                    </div>
                                </div>
                                <div id="Tap21" runat="server">
                                <div class="row ">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblacademicsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" style="width:50%">
                                            </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                   <div class="card_wrapper">
                                        <div class="row pad15">
                                            <asp:GridView ID="Gv_Feestatusdetails" HeaderStyle-BorderColor="White" EmptyDataText="No record found..." AutoGenerateColumns="false"
                                                CssClass="footable table-striped" HeaderStyle-HorizontalAlign="Center"  runat="server"
                                                Style="width: 100%;" GridLines="None">
                                                <Columns>
                                                    <%--<asp:TemplateField>
                                                        <HeaderTemplate>
                                                            SL No.
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Fee Type
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_details" Height="25px" Text='<%# Eval("FeeType")%>' ForeColor="Green" Font-Underline="true" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                CommandName="FeePayment" ValidationGroup="none" />
                                                            <asp:Label ID="hdsession" Visible="false" Text='<%# Eval("Session")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdstudent" Visible="false" Text='<%# Eval("Student")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdaddress" Visible="false" Text='<%# Eval("Address")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdstudenttype" Visible="false" Text='<%# Eval("StudentType")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdstudenttypeid" Visible="false" Text='<%# Eval("StudentTypeID")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdadmissiontype" Visible="false" Text='<%# Eval("AdmissionType")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdfeetype" Visible="false" Text='<%# Eval("FeeType")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdfeetypeid" Visible="false" Text='<%# Eval("FeeTypeID")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="hdpaymenttypeid" Visible="false" Text='<%# Eval("PaymentTypeID")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="lblclassid" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>

                                                             
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lbltotalpayable_foo" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" ForeColor="Green" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Collectable
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpayable" runat="server" Text='<%# Eval("Payable", "{0:0#.##}")%>'></asp:Label>
                                                            <asp:Label ID="lbltotalpayable" Visible="false" runat="server" Text='<%# Eval("TotalPayable", "{0:0#.##}")%>'></asp:Label>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lbltotalpayable_foo" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Paid
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpaid" runat="server" Text='<%# Eval("Paid", "{0:0#.##}")%>'></asp:Label>
                                                            <asp:Label ID="lbltotalpaid" Visible="false" runat="server" Text='<%# Eval("TotalPaid", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lbltotalpaid_foo" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="True">
                                                        <HeaderTemplate>
                                                            Discount
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("Discount", "{0:0#.##}")%>'></asp:Label>
                                                            <asp:Label ID="lbltotaldiscount" Visible="false" runat="server" Text='<%# Eval("TotalDiscount", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lbltotaldiscount_foo" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="True">
                                                        <HeaderTemplate>
                                                            Due
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldue" runat="server" Text='<%# Eval("Due", "{0:0#.##}")%>'></asp:Label>
                                                            <asp:Label ID="lbltotaldue" Visible="false" runat="server" Text='<%# Eval("TotalDue", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lbltotaldue_foo" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" ForeColor="Red" />
                                                    </asp:TemplateField>


                                                </Columns>
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                            </asp:GridView>
                                        </div>

                                    </div>

                                </div>

                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12"">
                                        <p class="form_group_sub_heading">Exam
                                        <asp:Button ID="btnTap2minimize2"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnTap2minimize2_Click" />
                                        <asp:Button ID="btnTap2maximize2"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnTap2maximize2_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap22" runat="server">
                                <div class="row ">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblEsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlEsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" style="width:50%">
                                            </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                   <div class="card_wrapper">
                                        <div class="row pad15">
                                            <asp:GridView ID="GvExamDetails" HeaderStyle-BorderColor="White" EmptyDataText="No record found..." AutoGenerateColumns="false"
                                                CssClass="footable table-striped" HeaderStyle-HorizontalAlign="Center"  runat="server"
                                                Style="width: 100%;" GridLines="None">
                                                <Columns>
                                                    
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Exam
                                                        </HeaderTemplate>
                                                            <ItemTemplate>
                                                            <asp:Label ID="lblmarkobtain" runat="server" Text='<%# Eval("ExamName", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>                                                   
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" ForeColor="Green" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Mark Obtain
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmarkobtain" runat="server" Text='<%# Eval("MarkObtain", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Div
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldiv" runat="server" Text='<%# Eval("Div", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="True">
                                                        <HeaderTemplate>
                                                            Rank
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrank" runat="server" Text='<%# Eval("Ranks", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="True">
                                                        <HeaderTemplate>
                                                            Print
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblprint" runat="server" Text="Print"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" ForeColor="Red" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                            </asp:GridView>
                                        </div>
                                        </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Exam Subject Analysis
                                        <asp:Button ID="btnTap2minimize7"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnTap2minimize7_Click" />
                                        <asp:Button ID="btnTap2maximize7"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnTap2maximize7_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap23" runat="server">
                                <div class="row ">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblESsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlESsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" style="width:50%" >
                                            </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                <div class="card_wrapper">
                                        <div class="row pad15">
                                            <asp:GridView ID="GvExamSubjectAnalysis" HeaderStyle-BorderColor="White" EmptyDataText="No record found..." AutoGenerateColumns="false"
                                                CssClass="footable table-striped" HeaderStyle-HorizontalAlign="Center"  runat="server"
                                                Style="width: 100%;" GridLines="None">
                                                <Columns>                                                    
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Exam
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblexamname" runat="server" Text='<%# Eval("ExamName", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>                                                        
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" ForeColor="Green" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Mark Obtain
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmarkobtain" runat="server" Text='<%# Eval("Markobtain", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Div
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldiv" runat="server" Text='<%# Eval("Div", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="True">
                                                        <HeaderTemplate>
                                                            Rank
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrank" runat="server" Text='<%# Eval("Ranks", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="True">
                                                        <HeaderTemplate>
                                                            Print
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblprint" runat="server" Text='<%# Eval("Print", "{0:0#.##}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" ForeColor="Red" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                            </asp:GridView>
                                        </div>
                                        </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Year Wise Exam Analysis
                                        <asp:Button ID="btnTap2minimize3"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnTap2minimize3_Click" />
                                        <asp:Button ID="btnTap2maximize3"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnTap2maximize3_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap24" runat="server">
                                <div class="row ">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblYWsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlYWsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" style="width:50%">
                                            </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Hostel Details
                                        <asp:Button ID="btnTap2minimize4"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnTap2minimize4_Click" />
                                        <asp:Button ID="btnTap2maximize4"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnTap2maximize4_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap25" runat="server">
                                <div class="row ">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblHDsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlHDsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" style="width:50%">
                                            </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                   <div class="row">
                                        <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblblock" runat="server" Text="Block"></asp:Label>
                                            <asp:Textbox runat="server" ID="Txtblock" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                       <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbldomitry" runat="server" Text="Wing"></asp:Label>
                                            <asp:Textbox runat="server" ID="txtwing" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                       <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblwardenname" runat="server" Text="Warden"></asp:Label>
                                            <asp:Textbox runat="server" ID="txtwardenname" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                    
                                       </div>
                                    <div class="row">
                                        <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbed" runat="server" Text="Bed"></asp:Label>
                                            <asp:Textbox runat="server" ID="txtbed" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                        </div>

                            </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Transport
                                        <asp:Button ID="btnTap2minimize5"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnTap2minimize5_Click" />
                                        <asp:Button ID="btnTap2maximize5"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnTap2maximize5_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap26" runat="server">
                                <div class="row ">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblTsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlTsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" style="width:50%">
                                            </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblrouteno" runat="server" Text="Route No"></asp:Label>
                                            <asp:Textbox runat="server" ID="txtRouteno" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                        <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblroute" runat="server" Text="Route"></asp:Label>
                                            <asp:Textbox runat="server" ID="txtroute" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                        <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblDriver" runat="server" Text="Driver"></asp:Label>
                                            <asp:Textbox runat="server" ID="Txtdriver" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                       
                                       </div>
                                    <div class="row">
                                        <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbusno" runat="server" Text="Bus No"></asp:Label>
                                            <asp:Textbox runat="server" ID="txtbusno" Enabled="false" Class="form-control">
                                            </asp:Textbox>
                                        </div>
                                    </div>
                                        </div>
                                    </div>
                                </div>
                            
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Print Certificate
                                        <asp:Button ID="btnTap2minimize6"  runat="server"  style="float: right;font-size:larger" Text="-"  OnClick="btnTap2minimize6_Click" />
                                        <asp:Button ID="btnTap2maximize6"  runat="server" style="float: right;font-size:larger" Visible="false" Text="+"  OnClick="btnTap2maximize6_Click" />
                                        </p>
                                    </div>
                                </div>
                                <div id="Tap27" runat="server">
                                <div class="row ">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblPrintsession" runat="server" Text="Session"></asp:Label>
                                            <asp:DropDownList ID="ddlPrintAcademicSession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" style="width:50%">
                                            </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card_wrapper">
                                        <div class="row pad15">
                                       <asp:GridView ID="GvCertificateDetails" HeaderStyle-BorderColor="White" EmptyDataText="No record found..." AutoGenerateColumns="false"
                                        CssClass="footable table-striped" HeaderStyle-HorizontalAlign="Center"  runat="server" Style="width: 100%;" GridLines="None">
                                       <Columns>
                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                            Type
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Eval("CType", "{0:0#.##}")%>'></asp:Label>
                                            <%--<asp:Label ID="lblTypeID" runat="server" Text='<%# Eval("CTypeID", "{0:0#.##}")%>'></asp:Label>--%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                         <HeaderTemplate>
                                            Print
                                        </HeaderTemplate>
                                       <%-- <ItemTemplate>
                                            <asp:LinkButton ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintCertificate();" />
                                        </ItemTemplate>--%>
                                             <ItemTemplate>
                                                    <a href="javascript: void(null);" onclick="PrintCertificate('<%# Eval("CTypeID")%>','<%# Eval("StudentID")%>'),'<%# Eval("AcademicSessionID")%>'); return false;" class="cus-btn btn-sm btn-info button">Print</a>
                                             </ItemTemplate>
                                    </asp:TemplateField>
                                    </Columns>
                                           <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                </asp:GridView>
                                        </div>
                                    </div>
                                    
                            </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                </div>
                
            <%--</div>--%>
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
            <%--var value = document.getElementById("<%=txtemail.ClientID %>").value;
            if (value != "") {
                var atposition = value.indexOf("@");
                var dotposition = value.lastIndexOf(".");
                if (atposition < 1 || dotposition < atposition + 2 || dotposition + 2 >= value.length) {
                    str = str + " Please enter a valid e-mail address.\n"
                    document.getElementById("<%=txtemail.ClientID %>").focus()
                    i++
                }
            }--%>
            if (document.getElementById("<%=ddlamdission.ClientID%>").selectedIndex == "0") {
                str = str + " Please select admission type.\n"
                document.getElementById("<%=ddlamdission.ClientID %>").focus()
                i++
            }
            <%--if (document.getElementById("<%=txtadmissioDate.ClientID%>").value == "") {
                str = str + " Please enter admission date.\n"
                document.getElementById("<%=txtadmissioDate.ClientID %>").focus()
                i++
            }--%>
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
            <%--if (document.getElementById("<%=ddlcountry.ClientID%>").selectedIndex == "0") {
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
            }--%>
            if (document.getElementById("<%=txtgmobile.ClientID%>").value == "") {
                str = str + " Please enter mobile no. \n"
                document.getElementById("<%=txtgmobile.ClientID %>").focus()
                i++
            }
            <%--if (document.getElementById("<%=txtpin.ClientID%>").value == "") {
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
            }--%>
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
               <%-- .then((willDelete) => {
                    if (willDelete) {
                       __doPostBack('<%=GvstudentDetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });--%>

        }
         function PrintCertificate(CTypeID,StudentID, AcademicSessionID) {
            window.open("../EduFees/Reports/ReportViewer.aspx?option=Certificate&CTypeID=" + CTypeID  + "&StudentID=" + StudentID  + "&AcademicSessionID=" + AcademicSessionID)
        }

       <%-- function PrintCertificate() {
            objclass = document.getElementById("<%= ddlclass.ClientID %>")
            objsection = document.getElementById("<%= ddlsection.ClientID %>")
            objrollno = document.getElementById("<%= txtrollno.ClientID %>")
            objsession = document.getElementById("<%= ddlPrintAcademicSession.ClientID %>")--%>
            <%--objCtype = document.getElementById("<%= ddlCertificateType.ClientID %>")--%>
        //    if (objCtype.value == "1") {
        //        window.open("../EduReports/Reports/ReportViewer.aspx?option=LowerReading&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value)
        //    }
        //    else if (objCtype.value == "2") {
        //        window.open("../EduReports/Reports/ReportViewer.aspx?option=Transfer&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value)
        //    }
        //    else if (objCtype.value == "3") {
        //        window.open("../EduReports/Reports/ReportViewer.aspx?option=Provisional&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value)
        //    }
        //}

        <%--function Printstudentlist() {
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
        function PrintstudentProfile() {
            objClassID = document.getElementById("<%= ddlclasses.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objStudentname = document.getElementById("<%= txtstudentanme.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")
            objStatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objCastes = document.getElementById("<%= ddlcastes.ClientID %>")
            ObjadmissionType = document.getElementById("<%= ddladmissiontype.ClientID %>")
            objCategory = document.getElementById("<%= ddlcategorys.ClientID %>")
            ObJuserID = document.getElementById("<%= ddluser.ClientID %>")
            objadmissionstatus = document.getElementById("<%= ddl_admissionstatus.ClientID %>")

            window.open("../EduStudent/Reports/ReportViewer.aspx?option=StudentProfile&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&SexID=" + objSex.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Category=" + objCategory.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value + "&IsActive=" + objStatus.value + "&Searchtype=" + objsearchtype.value + "&SearchBy=" + objStudentname.value + "&Status=" + objStatus.value + "&IsNew=" + ObjadmissionType.value + "&CasteID=" + objCastes.value + "&UserID=" + ObJuserID.value + "&Admissionstatus=" + objadmissionstatus.value)
        }--%>

        //$(function () {

        //    $('[id*=GvstudentDetails]').footable();
        //});

        //var prm = Sys.WebForms.PageRequestManager.getInstance();
        //prm.add_endRequest(function () {

        //    $('[id*=GvstudentDetails]').footable();

        //    $('.searchs').on('keyup', function () {
        //        var searchTerm = $(this).val().toLowerCase();
        //        $('#Studentlist table tbody tr').each(function () {
        //            var lineStr = $(this).text().toLowerCase();
        //            if (lineStr.indexOf(searchTerm) === -1) {
        //                $(this).hide();
        //            } else {
        //                $(this).show();
        //            }
        //        });
        //    });
        //});

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

