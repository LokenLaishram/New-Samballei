<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="SchoolDetailMST.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.EduUtility.SchoolDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Common Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduUtility/SchoolDetailMST.aspx">Add School</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblcode" Text="Code"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtcode" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    Enabled="True" TargetControlID="txtschoolname" FilterType="LowercaseLetters,UppercaseLetters,Custom,Numbers" ValidChars="-/' ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblschoolname" Text="School Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtschoolname" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBox" runat="server"
                                    Enabled="True" TargetControlID="txtschoolname" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars="-/' ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>

                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrecognition" Text="Recognition No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtRecognitionNo" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    Enabled="True" TargetControlID="txtRecognitionNo" FilterType="LowercaseLetters,UppercaseLetters,Custom,Numbers" ValidChars="-/() ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblwebsite" Text="Website"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtwebsite" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    Enabled="True" TargetControlID="txtwebsite" FilterType="LowercaseLetters,UppercaseLetters,Custom,Numbers" ValidChars=" .">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblemailID" Text="Email ID"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtemailID" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                                    TargetControlID="txtemailID" FilterType="LowercaseLetters,UppercaseLetters,Custom,Numbers" ValidChars=" .@">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-6 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbladdress" Text="Address"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtaddress" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True"
                                    TargetControlID="txtaddress" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=",. ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblcountry" runat="server" Text="Country"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"
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
                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control ">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblpin" runat="server" Text="Pin No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtpin" runat="server" MaxLength="6" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" Enabled="True"
                                    TargetControlID="txtphoneNo" FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblphone" runat="server" Text="Contact No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" ID="txtphoneNo" MaxLength="10" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True"
                                    TargetControlID="txtphoneNo" FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblgmobile" runat="server" Text="Alt. No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" ID="txtmobile" MaxLength="10" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True"
                                    TargetControlID="txtphoneNo" FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Upload Logo"></asp:Label>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="form-group" style="margin-top: 0.6em;">
                                            <asp:FileUpload class="btn1" ID="FileUploader" runat="server" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <img id="imglogo" src="self.png" runat="server" alt="School Logo" visible="false" background-color="Gray"
                                    height="70" width="80" title="School Logo" />
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-green button " Text="Add" OnClick="btnsave_Click" OnClientClick="return Validate();" />
                                        <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" Text="Search" OnClick="btnsearch_Click" />
                                        <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" Text="Reset" OnClick="btncancel_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnsave" />
                                        <asp:PostBackTrigger ControlID="btnsearch" />
                                        <asp:PostBackTrigger ControlID="btncancel" />
                                    </Triggers>
                                </asp:UpdatePanel>
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
                                        <asp:LinkButton ID="btn_export" Visible="false" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_export" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-3 customRow" style="text-align: right; margin-top: 1em;">
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
                            <div id="SchoolDetails" class="col-md-12 customRow ">
                                <asp:GridView ID="GvSchoolDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvSchoolDetails_PageIndexChanging"
                                    CssClass="footable table-striped" AllowSorting="true" OnSorting="GvSchoolDetails_Sorting" OnRowCommand="GvSchoolDetails_RowCommand" runat="server" AutoGenerateColumns="false"
                                    Style="width: 100%">
                                    <Columns>
                                        <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="code" SortExpression="code" HeaderText="Code" />
                                        <asp:BoundField DataField="SchoolName" SortExpression="SchoolName" HeaderText="School Name" />
                                        <asp:BoundField DataField="AddedBy" SortExpression="Added By" HeaderText="AddedBy" />
                                        <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" HeaderText="Added Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Edit
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
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
                                                <asp:Button ID="lnkDelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
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


    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SchoolDetails table tbody tr').each(function () {
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
            if (document.getElementById("<%=txtcode.ClientID%>").value == "") {
                str = str + "\n Please enter Code.";
                document.getElementById("<%=txtcode.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtschoolname.ClientID%>").value == "") {
                str = str + "\n Please enter School Name.";
                document.getElementById("<%=txtschoolname.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtRecognitionNo.ClientID%>").value == "") {
                str = str + "\n Please enter Recognition No.";
                document.getElementById("<%=txtRecognitionNo.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtwebsite.ClientID%>").value == "") {
                str = str + "\n Please enter Website.";
                document.getElementById("<%=txtwebsite.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtaddress.ClientID%>").value == "") {
                str = str + "\n Please enter Address.";
                document.getElementById("<%=txtaddress.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlcountry.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Country.";
                document.getElementById("<%=ddlcountry.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlstate.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select State.";
                document.getElementById("<%=ddlstate.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddldistrict.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select District.";
                document.getElementById("<%=ddldistrict.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtemailID.ClientID%>").value == "") {
                str = str + "\n Please enter Email ID.";
                document.getElementById("<%=txtemailID.ClientID %>").focus();
                i++;

            }
            else {
                var x = document.getElementById("<%=txtemailID.ClientID%>").value;
                var atpos = x.indexOf("@");
                var dotpos = x.lastIndexOf(".");
                if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                    alert("Not a valid e-mail address");
                    return false;
                }
            }
            if (document.getElementById("<%=txtphoneNo.ClientID%>").value == "") {
                str = str + "\n Please enter  Contact No.";
                document.getElementById("<%=txtphoneNo.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtmobile.ClientID%>").value == "") {
                str = str + "\n Please enter Alt. No.";
                document.getElementById("<%=txtmobile.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtpin.ClientID%>").value == "") {
                str = str + "\n Please enter Pin No.";
                document.getElementById("<%=txtpin.ClientID %>").focus();
                i++;
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
                return true;
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
                        __doPostBack('<%=GvSchoolDetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvSchoolDetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvSchoolDetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SchoolDetails table tbody tr').each(function () {
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

</asp:Content>
