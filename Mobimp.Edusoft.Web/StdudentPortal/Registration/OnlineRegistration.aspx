<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="OnlineRegistration.aspx.cs" Inherits="Mobimp.Campusoft.Web.StdudentPortal.Registration.OnlineRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="OnlineRegistration.aspx">Online Registration</a></li>
        </ol>
        <div class="review-tab-pro-inner">

            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabStudent">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card_wrapper">
                                <div class="row ">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblname" Text="Student's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtstudentname" MaxLength="200" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
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
                                            <asp:Label ID="lblsex" runat="server" Text="Gender"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlsex" runat="server" class="form-control ">
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
                                            <asp:Label ID="lblgmobile" runat="server" Text="Mobile No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" ID="txtgmobile" MaxLength="10" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblMotherTongue" runat="server" Text="Mother Tongue"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
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
                                            <asp:Label runat="server" ID="lblIDmarks" Text="ID Marks"></asp:Label>

                                            <asp:TextBox ID="txtIDmarks" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclass" runat="server" Text="Class to register"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlclass" runat="server"
                                                class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="card_wrapper">
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
                                            <asp:Label ID="lblfatherocupation" runat="server" Text="Father's-Occupation"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" ID="txtfatheroccupation" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmotheroccupation" runat="server" Text="Mother's-Occupation"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" ID="txtmotheroccupation" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblincome" runat="server" Text="Parent's Income"></asp:Label>
                                            <asp:TextBox runat="server" MaxLength="7" ID="txtincome" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_fliter_income" runat="server"
                                                Enabled="True" TargetControlID="txtincome" ValidChars="0123456789.">
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
                                </div>
                            </div>

                            <div class="card_wrapper">

                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblschoolname" runat="server" Text="Last School Name"></asp:Label>
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
                                            <asp:Label ID="lblLastRoll" runat="server" Text="Last Roll No."></asp:Label>
                                            <asp:TextBox ID="txtlastroll" runat="server" placeholder="Roll" class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_lastroll" runat="server"
                                                Enabled="True" TargetControlID="txtlastroll" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbllastMark" runat="server" Text="Last Mark Obtain"></asp:Label>
                                            <asp:TextBox ID="txtlatsmarks" MaxLength="11" placeholder="MARK" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblAttendance" runat="server" Text="Last Attendance"></asp:Label>
                                            <asp:TextBox ID="txtattendance" MaxLength="11" placeholder="Attendance" runat="server"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card_wrapper">

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
                                            <asp:DropDownList ID="ddlcountry" runat="server"
                                                class="form-control ">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblst" runat="server" Text="State"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>

                                            <asp:DropDownList ID="ddlstate" runat="server"
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
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group pull-right">
                                            <asp:Button ID="btnsave" class="btn btn-sm btn-green button " OnClientClick="return Validate();" OnClick="btnsave_Click" runat="server"
                                                Text="Add" />
                                            <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" OnClick="btncancel_Click"
                                                Text="Reset" />
                                        </div>
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
            if (document.getElementById("<%=txtstudentname.ClientID%>").value == "") {
                str = str + " Please enter student name.\n"
                document.getElementById("<%=txtstudentname.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtDOB.ClientID%>").value == "") {
                str = str + " Please enter D.O.B. \n"
                document.getElementById("<%=txtDOB.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlsex.ClientID%>").selectedIndex == "0") {
                str = str + " Please select gender. \n"
                document.getElementById("<%=ddlsex.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlCast.ClientID%>").selectedIndex == "0") {
                str = str + " Please select caste.\n"
                document.getElementById("<%=ddlCast.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlreligion.ClientID%>").selectedIndex == "0") {
                str = str + " Please select religion.\n"
                document.getElementById("<%=ddlreligion.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtgmobile.ClientID%>").value == "") {
                str = str + " Please enter mobile no. \n"
                document.getElementById("<%=txtgmobile.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtMotherTongue.ClientID%>").value == "") {
                str = str + " Please enter mother tongue language. \n"
                document.getElementById("<%=txtMotherTongue.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + "Please select class to register. \n"
                document.getElementById("<%=ddlclass.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtfathername.ClientID%>").value == "") {
                str = str + " Please enter father's name. \n"
                document.getElementById("<%=txtfathername.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtfatheroccupation.ClientID%>").value == "") {
                str = str + " Please enter father's ocuupation. \n"
                document.getElementById("<%=txtfatheroccupation.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtmothername.ClientID%>").value == "") {
                str = str + " Please enter mother's name. \n"
                document.getElementById("<%=txtmothername.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtmotheroccupation.ClientID%>").value == "") {
                str = str + " Please enter mother's ocuupation. \n"
                document.getElementById("<%=txtmotheroccupation.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtaddress.ClientID%>").value == "") {
                str = str + " Please enter address. \n"
                document.getElementById("<%=txtaddress.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlcountry.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select current country."
                document.getElementById("<%=ddlcountry.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlstate.ClientID%>").selectedIndex == "0") {
                str = str + " Please select state. \n"
                document.getElementById("<%=ddlstate.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlDistrict.ClientID%>").selectedIndex == "0") {
                str = str + " Please select district. \n"
                document.getElementById("<%=ddlDistrict.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtpin.ClientID%>").value == "") {
                str = str + " Please enter pin no. \n"
                document.getElementById("<%=txtpin.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,

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


    </script>
</asp:Content>
