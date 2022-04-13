<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="DataSync.aspx.cs" Inherits="Mobimp.Campusoft.Web.WebPortal.DataSync" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../WebPortal/DataSync.aspx">Subject Manager</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="SubjectManager">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="lblmsg" Visible="true" runat="server"></asp:Label>
                                            <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicseesions" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" class="form-control "
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlsections" AutoPostBack="true" runat="server" class="form-control "
                                                OnSelectedIndexChanged="ddlsections_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Exam"></asp:Label>
                                            <asp:DropDownList ID="ddlexam" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblrollno" Text="Roll No"></asp:Label>
                                            <asp:TextBox ID="txtrollno" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtrollno" ID="FilteredTextBoxExtender1"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="fileid" Text="Browse"></asp:Label>
                                            <asp:FileUpload ID="FileUpload1" accept=".jpeg,.jpg" AllowMultiple="true" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-success button" Visible="false" Text="Search" OnClick="btnsearch_Click1" />
                                            <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Reset" Visible="false" />

                                            <asp:Button ID="btnSinc" runat="server" Visible="true" class="btn btn-sm btn-indigo button" Text="Sync" OnClientClick="return sync();" />
                                            <asp:Button ID="btnsendingzip" runat="server" Visible="false" class="btn btn-sm btn-indigo button" Text="ZIP Sending" OnClientClick="return Zipsending();" />
                                            <asp:Button ID="btnPhotoUpload" runat="server" Visible="true" class="btn btn-sm btn-indigo button" Text="Upload Photo" OnClientClick="return StudentPhotoUpload();" />
                                            <asp:Button ID="btnExport" runat="server" Visible="false" class="btn btn-sm btn-indigo button" Text="Export PDF" OnClick="btnExport_Click" />
                                            <asp:Button ID="btnZip" runat="server" Visible="false" class="btn btn-sm btn-indigo button" Text="Zip" OnClick="btnZip_Click" />
                                            <asp:Button ID="btnDelete" runat="server" Visible="false" class="btn btn-sm btn-indigo button" Text="Delete PDF" OnClick="btnDelete_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <div class="progress">
                                                <div id="progress" class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%">
                                                    <span id="statusText"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtjson" runat="server" class="form-control" Style="width: 600px; margin-left: 535px" TextMode="MultiLine"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtrollno" ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvDataSinc" runat="server" AutoGenerateColumns="false"
                                                CssClass="gridViewHeader" Width="100%" class="grid" EmptyDataText="No record found...">
                                                <Columns>
                                                    <asp:BoundField DataField="Sfirstname" HeaderText="Name">
                                                        <ItemStyle Font-Size="Medium" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No">
                                                        <ItemStyle Font-Size="Medium" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ClassName" HeaderText="Class">
                                                        <ItemStyle Font-Size="Medium" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SectionName" HeaderText="Section">
                                                        <ItemStyle Font-Size="Medium" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>--%>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <script type="text/javascript">
        function sync() {
            var json = document.getElementById("<%= txtjson.ClientID %>");
            //alert(json.value);
            $.ajax({
                type: "post",
                url: "https://cors-anywhere.herokuapp.com/https://api.campusoft.in/api/v1/sync",
                data: JSON.stringify(json.value),
                processData: false,
                ContentType: 'application/json',
                dataType: 'json',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("apikey", "58810e851b77413f533a36241fa3fde451bdbb1d")
                },

                ////////Progress Bar/////
                xhr: function () {
                    var xhr = new window.XMLHttpRequest();
                    xhr.upload.addEventListener("progress", function (evt) {
                        if (evt.lengthComputable) {
                            var percentComplete = evt.loaded / evt.total;
                            $('#progress').attr('aria-valuenow', (Math.round(percentComplete * 100))).css({ "width": (Math.round(percentComplete * 100)) + '%' });
                            $('#statusText').html('<b> Uploading ' + (Math.round(percentComplete * 100)) + '% </b>' + SizeToText(evt.loaded) + '|' + SizeToText(evt.total));
                        }
                    }, false);
                    return xhr;
                },
                complete: function () {
                    $('#progress').attr('aria-valuenow', 0).css({ "width": '0%' });
                    $('#status').html('<b></b>');
                },
                //////////XXXXXXXXXX///////

                //headers: { "apikey": 'jijoijoffsqqoi987f987sad7f97as9f' },
                success: function (response) {
                    try {
                        if (response.success) {
                            alert(response.message)
                        }
                        else {
                            alert(response.message)
                        }

                    }
                    catch (e) {
                        alert(e)
                    }

                },
                error: function () {
                    alert('Error while request..', 'Warning')
                }
            });



        }

        function StudentPhotoUpload() {
            var form_data = new FormData();
            var totalfiles = document.getElementById('CampusoftPlaceholder_FileUpload1').files.length;

            if (totalfiles == 0) {
                alert('Atleast select one file to upload !')
                return false
            }

            for (var index = 0; index < totalfiles; index++) {
                form_data.append("files[]", document.getElementById('CampusoftPlaceholder_FileUpload1').files[index]);
            }

            var SubFolderName = 'StudentProfile';
            //  var AcademicSessionID = 1;
            form_data.append("SubFolderName", SubFolderName);
            //  form_data.append("AcademicSessionID", AcademicSessionID);

            $.ajax({
                url: 'https://cors-anywhere.herokuapp.com/https://api.campusoft.in/api/v1/aws/s3_controller/uploadFile', // your route to process the file

                type: 'POST', //
                data: form_data,
                processData: false, // important
                contentType: false, // important
                dataType: 'json',
                beforeSend: function (xhr) {
                    //  cchfg676676
                    //  e932dd1a323ea8610d50e65bcf680ad260c7e9b3
                    xhr.setRequestHeader("apikey", "")
                },
                xhr: function () {
                    var xhr = new window.XMLHttpRequest();
                    xhr.upload.addEventListener("progress", function (evt) {
                        if (evt.lengthComputable) {
                            var percentComplete = evt.loaded / evt.total;
                            $('#progress').attr('aria-valuenow', (Math.round(percentComplete * 100))).css({ "width": (Math.round(percentComplete * 100)) + '%' });
                            $('#statusText').html('<b> Uploading ' + (Math.round(percentComplete * 100)) + '% </b>' + SizeToText(evt.loaded) + '|' + SizeToText(evt.total));
                        }
                    }, false);
                    return xhr;
                },
                complete: function () {
                    $('#progress').attr('aria-valuenow', 0).css({ "width": '0%' });
                    $('#status').html('<b style="color:black; text-align:center">Completed</b>');
                },
                success: function (response) {
                    try {
                        if (response.success) {
                            alert(response.message + ' Uploaded ' + response.count + ' file(s).')
                            //$('#status').html('<b>' + response.message + ' Uploaded ' + response.count + ' file(s).</b>');
                        }
                        else {
                            alert(response.message + ' Uploaded ' + response.count + ' file(s).')
                            //$('#status').html('<b>' + response.message + ' Uploaded ' + response.count + ' file(s).</b>');
                        }

                    }
                    catch (e) {
                        alert(e)
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert(xhr)
                }
            });
        }

        function SizeToText(size) {
            var sizeContext = ["B", "KB", "MB", "GB", "TB"],
                atCont = 0;

            while (size / 1024 > 1) {
                size /= 1024;
                ++atCont;
            }

            return Math.round(size * 100) / 100 + sizeContext[atCont];
        }



        function PrintReport() {
            // alert("Test");
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsection = document.getElementById("<%= ddlsections.ClientID %>")
            objroll = document.getElementById("<%= txtrollno.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objexam = document.getElementById("<%= ddlexam.ClientID %>")
            //alert("Test");
            // if (objclass.value >= "1" && objclass.value <= "10") {
            window.open("../EduReports/Reports/ReportViewer.aspx?option=ExportMarkSheet&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamID=" + objexam.value + "&Session=" + objsession.value + "&RollNo=" + objroll.value);
            //  }

        }

    </script>
</asp:Content>
