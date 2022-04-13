<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="EduSMSmanager.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduSMS.EduMSMmanager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>SMS&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a5" href="../EduSMS/SMSTemplateManager.aspx">Template</a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a6" href="../EduSMS/EduSMSmanager.aspx">SMS Manager </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a3" href="../EduSMS/SmsHistory.aspx">History</a></li>
            <li class="pull-right " style="font-weight: bold;">
                <asp:Label ID="Label2" runat="server" Text="SMS Balance" ForeColor="MenuText" Font-Size="Medium"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text=" : " ForeColor="MenuText"></asp:Label>
                <asp:Label ID="lblchkbln" runat="server" ForeColor="Orange" Font-Bold="true" Font-Size="Medium"></asp:Label>
                <asp:Label ID="lblchkblnVisi" runat="server" Text="Balance Low !" ForeColor="Red" Visible="False"></asp:Label>
            </li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_sendercode" Text="Sender ID"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtsenderid" MaxLength="6" runat="server" class="form-control" value="SCHOOL"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblSendTo" runat="server" Text="Send To"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSendTo" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSendTo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblSMSMode" runat="server" Text="Category"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSMSMode" runat="server" class="form-control " AutoPostBack="True" OnSelectedIndexChanged="ddlSMSMode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow" runat="server" id="divClass">
                            <div class="form-group">
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <asp:DropDownList ID="ddlclassess" runat="server" AutoPostBack="true" class="form-control " OnSelectedIndexChanged="ddlclassess_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow" runat="server" id="divSection">
                            <div class="form-group">
                                <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                <asp:DropDownList ID="ddlsections" runat="server" AutoPostBack="true" class="form-control " OnSelectedIndexChanged="ddlsections_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow" id="divRollNo" runat="server">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrollNo" Text="Roll No" MaxLength="3"></asp:Label>
                                <asp:TextBox ID="txtrollNo" MaxLength="3" AutoPostBack="true" OnTextChanged="txtrollNo_TextChanged" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender4"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-4 customRow" id="divStdName" runat="server">
                            <div class="form-group">
                                <asp:Label ID="lblstudentName" runat="server" Text="Student Name"></asp:Label>
                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtStudentName" class="form-control"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                    ServiceMethod="Getautostudentlist" MinimumPrefixLength="1"
                                    CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtStudentName"
                                    UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                </asp:AutoCompleteExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow" id="divExam" runat="server">
                            <div class="form-group">
                                <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                <asp:DropDownList ID="ddlexam" runat="server" AutoPostBack="true" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2 customRow" style="margin-top: 19px;">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="form-group" style="margin-top: 0.6em;">
                                        <asp:FileUpload Visible="false" ID="fileUploadBtn" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-3 customRow" id="divButton" runat="server">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validates();" Text="Search" OnClick="btnsearch_Click" />
                                        <asp:Button ID="btnimport" runat="server" class="btn btn-sm btn-info button" Text="Import" OnClick="btnImport_Click" />
                                        <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-red button" Text="Reset" OnClick="btncancel_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnimport" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div runat="server" style="min-height: 53vh;" class="col-md-6 customRow card_wrapper">
                    <div id="divsearch" runat="server">
                        <div class="col-md-6 customRow" style="margin-top: 13px;">
                            <asp:Label ID="lblresult" Font-Bold="true" runat="server"></asp:Label>
                            <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                            <asp:Label ID="lbl_show" Text="Show" runat="server" Visible="false"></asp:Label>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlshow" AutoPostBack="true" OnSelectedIndexChanged="ddlshow_SelectedIndexChanged" Visible="false" runat="server" class="form-control">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20"> 20 </asp:ListItem>
                                    <asp:ListItem Value="50"> 50 </asp:ListItem>
                                    <asp:ListItem Value="100"> 100 </asp:ListItem>
                                    <asp:ListItem Value="10000"> all</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <input type="text" class="searchs form-control" placeholder="Search...">
                        </div>
                    </div>
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
                    <div id="SmsList" class="col-md-12 customRow " style="max-height: 43vh; overflow: auto">
                        <!--Grid view Student Data-->
                        <asp:GridView ID="GvStudentSms" EmptyDataText="No record found..."
                            CssClass="footable table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" Style="width: 100%; margin-top: 15px;" HeaderStyle-Height="30px" HeaderStyle-Font-Bold="true">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>Sl No</HeaderTemplate>
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Name
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_studentID" Visible="false" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                        <asp:Label ID="lblstudents" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="25%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Mobile
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblcellNos" runat="server" Text='<%# Eval("MobileNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkboxselect" runat="server" onclick="Check_Click(this);" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-6 customRow card_wrapper">
                    <div class="row pad15">
                        <div class="col-sm-12 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server">Use the followings for dynamic data binding</asp:Label>
                                <div class="row" style="margin-top: .5em;">
                                    <div class="col-md-12">
                                        <a href="javascript:insertText('#name#');" runat="server"><mark style="color: red" runat="server">#name#</mark></a>
                                        &emsp;
                                <a href="javascript:insertText('#class#');" runat="server"><mark style="color: red" runat="server">#class#</mark></a>
                                        &emsp;
                                <a href="javascript:insertText('#section#');" runat="server"><mark style="color: red" runat="server">#section#</mark></a>
                                        &emsp;
                                <a href="javascript:insertText('#rollno#');" runat="server"><mark style="color: red" runat="server">#rollno#</mark></a>
                                        &emsp;
                                <a href="javascript:insertText('#father#');" runat="server"><mark style="color: red" runat="server">#father#</mark></a>
                                        &emsp;
                                <a href="javascript:insertText('#mother#');" runat="server"><mark style="color: red" runat="server">#mother#</mark></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row pad15">
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblTemplate" runat="server" Text="Choose sms template"></asp:Label>
                                <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbltxtmessage" Text="Text Message"></asp:Label>
                                <span style="color: #ff0000">*</span>
                                <asp:TextBox ID="txtmessage" TextMode="MultiLine" runat="server" onkeyup="countChar(this)" Style="max-height: 140px; min-height: 140px"
                                    class="form-control" placeholder="Please enter the message you would like to send or select the message from the template"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <asp:Label runat="server" ID="lbl_charcount" class="numbersofChart"></asp:Label>
                        </div>

                    </div>
                    <div class="row pad15">
                        <div class="col-md-8 customRow">
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsend"  runat="server" class="btn btn-sm btn-success button" Text="Send" OnClick="btnsend_Click" OnClientClick="return ValidateSendSMS();" />

                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        function insertText(val) {
            var tempTxt = document.getElementById("<%= txtmessage.ClientID %>");
            tempTxt.value = tempTxt.value + val + " ";
            document.getElementById("<%= txtmessage.ClientID %>").focus();
        }
    </script>

    <script src="../app-assets/js/couter.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SmsList table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });


        function Validates() {
            var str = "";
            var i = 0;


            if (document.getElementById("<%=ddlSendTo.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select send to.";
                document.getElementById("<%=ddlSendTo.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlSMSMode.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select sms category.";
                document.getElementById("<%=ddlSMSMode.ClientID %>").focus();
                i++;
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

        function ValidateSendSMS() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=txtmessage.ClientID %>").value == "") {
                str = str + "\n Please enter the Message.";
                document.getElementById("<%=txtmessage.ClientID %>").focus();
                i++;
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
        <%--function add(txtcontain) {
            document.getElementById("<%= txtmessage.ClientID %>").innerHTML += " " + txtcontain.value;
             return true;
        }--%>

        $(function () {
            $('[id*=Gvsms]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gvsms]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SmsList table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        row.style.backgroundColor = "white";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            row.style.backgroundColor = "white";

                        }

                        else {

                            row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }
        function Check_Click(objRef) {

            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "white";
            }
            else {

                //If not checked change back to original color

                if (row.rowIndex % 2 == 0) {

                    //Alternating Row Color

                    row.style.backgroundColor = "white";

                }

                else {

                    row.style.backgroundColor = "white";

                }

            }

            //Get the reference of GridView

            var GridView = row.parentNode;
            //Get all input elements in Gridview

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //The First element is the Header Checkbox

                var headerCheckBox = inputList[0];
                //Based on all or none checkboxes

                //are checked check/uncheck Header Checkbox

                var checked = true;

                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                    if (!inputList[i].checked) {

                        checked = false;

                        break;

                    }

                }

            }
            headerCheckBox.checked = checked;
        }
        function iframe(obj) {
            obj.style.height = 0;
            obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px';
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
        function countChar(val) {
            var len = val.value.length;
            $('.numbersofChart').text(len);
        };
    </script>


</asp:Content>
