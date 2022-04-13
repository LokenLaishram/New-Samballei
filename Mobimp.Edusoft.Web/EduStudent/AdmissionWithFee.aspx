<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AdmissionWithFee.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduStudent.AdmissionWithFee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="ContentAdmissionWithFee" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduStudent/AdmissionWithFee.aspx">New Admission</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="AdmissionWithFee">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Student Information</p>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbladmission" Text="Admission Type">   </asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlamdission" AutoPostBack="true" OnSelectedIndexChanged="ddlamdission_SelectedIndexChanged"
                                                runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbladmissionNo" Text="Student ID"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" MaxLength="10" ID="txtStudentID"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                Enabled="True" TargetControlID="txtStudentID" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblname" Text="Student's Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtstudentname"  MaxLength="200" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladmissiondate" runat="server" Text="Admission Date"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtadmissioDate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtadmissioDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtadmissioDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group ">
                                            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
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
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlclass" runat="server" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                class="form-control " AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlsection" runat="server" class="form-control ">
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
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudenttype" runat="server" Text="Student Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlstudenttype" runat="server" class="form-control" OnSelectedIndexChanged="ddlstudenttype_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsex" runat="server" Text="Gender"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlsex" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtaddress" MaxLength="200" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblgmobile" runat="server" Text="Mobile No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" ID="txtgmobile" MaxLength="10" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                Enabled="True" TargetControlID="txtgmobile" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row customRow">
                                    <div class="col-md-12">
                                        <p class="form_group_sub_heading">Admission Fee Details</p>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfeeamount" runat="server" Text="Fee Amount"></asp:Label>
                                            <asp:TextBox ID="txtfeeamount" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                Enabled="True" TargetControlID="txtfeeamount" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblexemp" runat="server" Text="Exempted Amount"></asp:Label>
                                            <asp:TextBox ID="txtexempted" runat="server" class="form-control" OnTextChanged="txtexempted_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                Enabled="True" TargetControlID="txtexempted" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltotalamount" runat="server" Text="Total Amount"></asp:Label>
                                            <asp:TextBox ID="txttotalamount" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                Enabled="True" TargetControlID="txttotalamount" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblDiscount" runat="server" Text="Discount"></asp:Label>
                                            <asp:TextBox ID="txtDiscount" runat="server" class="form-control" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter_Discount" runat="server"
                                                Enabled="True" TargetControlID="txtDiscount" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfineamount" runat="server" Text="Fine Amount"></asp:Label>
                                            <asp:TextBox ID="txtFineAmount" runat="server" OnTextChanged="txtfine_TextChanged" class="form-control" AutoPostBack="true"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                Enabled="True" TargetControlID="txtFineAmount" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblPayable" runat="server" Text="Payable Amount"></asp:Label>
                                            <asp:HiddenField runat="server" ID="hdPayableAmount" />
                                            <asp:TextBox runat="server" ID="txtPayableAmount" AutoPostBack="true" OnTextChanged="txtPayableAmount_TextChanged" Class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                Enabled="True" TargetControlID="txtPayableAmount" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfees" runat="server" Text="Paid Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:HiddenField runat="server" ID="hdnPaidAmount" />
                                            <asp:TextBox runat="server" ID="txtpaidamount" AutoPostBack="true" OnTextChanged="txtpaidamount_TextChanged" Class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                Enabled="True" TargetControlID="txtpaidamount" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblDue" runat="server" Text="Due"></asp:Label>
                                            <asp:TextBox ID="txtDue" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                Enabled="True" TargetControlID="txtDue" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblremarks" runat="server" Text="Remark"></asp:Label>
                                            <asp:TextBox ID="txtremarks" MaxLength="100" placeholder="Remark" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblbillno" runat="server" Visible="false" Text="Bill Number"></asp:Label>
                                            <asp:TextBox ID="txtbillno" Visible="false" runat="server" class="form-control"></asp:TextBox>
                                            <asp:HiddenField runat="server" ID="hdnfeetypeID" />
                                            <asp:HiddenField runat="server" ID="hdnbillno" />
                                            <asp:HiddenField runat="server" ID="hdnacademicID" />
                                        </div>
                                    </div>
                                    <div class="col-md-9 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1em;">
                                            <asp:Button ID="btnsave" class="btn btn-sm btn-green button " runat="server" OnClick="btnsave_Click"
                                                OnClientClick="return Validate();" Text="Save" />
                                            <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" OnClick="btncancel_Click" runat="server"
                                                Text="Reset" />
                                            <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print Receipt" OnClientClick="return Printfeereciept();" />
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
        function Validate() {

            var str = ""
            var i = 0;
            if (document.getElementById("<%=ddlamdission.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Admission Type."
                document.getElementById("<%=ddlamdission.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtstudentname.ClientID%>").value == "") {
                str = str + "\n Please enter Student Name."
                document.getElementById("<%=txtstudentname.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtadmissioDate.ClientID%>").value == "") {
                str = str + "\n Please select Admission Date."
                document.getElementById("<%=txtadmissioDate.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtDOB.ClientID%>").value == "") {
                str = str + "\n Please enter DOB."
                document.getElementById("<%=txtDOB.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class."
                document.getElementById("<%=ddlclass.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=ddlstudenttype.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Student Type."
                document.getElementById("<%=ddlstudenttype.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=ddlsex.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Gender."
                document.getElementById("<%=ddlsex.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtaddress.ClientID%>").value == "") {
                str = str + "\n Please enter Address."
                document.getElementById("<%=txtaddress.ClientID %>").focus()
                i++
            }

            if (document.getElementById("<%=txtgmobile.ClientID%>").value == "") {
                str = str + "\n Please enter Mobile Number."
                document.getElementById("<%=txtgmobile.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtpaidamount.ClientID%>").value == "") {
                str = str + "\n Please enter paid amount."
                document.getElementById("<%=txtpaidamount.ClientID %>").focus()
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
        function Printfeereciept() {
            objbillno = document.getElementById("<%= hdnbillno.ClientID %>")
            objFeeTypeID = document.getElementById("<%= hdnfeetypeID.ClientID %>")
            objacademicID = document.getElementById("<%= hdnacademicID.ClientID %>")
            window.open("../EduFees/Reports/ReportViewer.aspx?option=FeeReciept&BillNo=" + objbillno.value + "&FeetypeID=" + objFeeTypeID.value + "&AcademicSessionID=" + objacademicID.value)
        }
    </script>



    
</asp:Content>
