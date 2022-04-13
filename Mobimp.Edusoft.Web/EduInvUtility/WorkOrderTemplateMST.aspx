<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="WorkOrderTemplateMST.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInvUtility.WorkOrderTemplateMST" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <link href="../app-assets/bootstrap-wysihtml5/bootstrap3-wysihtml5.css" rel="stylesheet" />

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a3" href="../EduInvUtility/WorkOrderTemplateMST.aspx">Work Order Template</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label1" Text="Order Type"></asp:Label>
                                <asp:DropDownList ID="ddlOrderTypeID" runat="server" class="form-control custextbox"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlOrderTypeID_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_description" Text="Template Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlOrderTemplateID" runat="server" class="form-control custextbox"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlOrderTemplateID_OnSelectedIndexChanged">
                                    <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                                    <asp:ListItem Value="1">Template-1</asp:ListItem>
                                    <asp:ListItem Value="2">Template-2 </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_status" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddl_status"
                                    runat="server" class="form-control custextbox">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">

                                <asp:Button ID="btnsearch" Visible="true" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btnreset_onclick" />
                            </div>
                        </div>
                    </div>
                    <div class="row mt10" runat="server" id="Norecord" visible="false">
                        <div class="col-md-12" style="text-align: center;">
                            <asp:Label runat="server" ID="Label2" Text="No record found"></asp:Label>
                        </div>
                    </div>
                    <div class="row mt10" runat="server" id="HideShow" visible="false">
                        <div class="col-md-12">
                            <h6 style="color: #2e3192;">TEMPLATE HEADER PART</h6>
                        </div>
                        <div class="col-md-12">
                            <CKEditor:CKEditorControl ID="CKEditorHeader" runat="server" BasePath="../app-assets/ckeditorq/"
                              Toolbar="Basic" ToolbarBasic="|Bold|Italic|Underline|Strike|Superscript|-|NumberedList|BulletedList|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|FontSize|TextColor|BGColor">
                            </CKEditor:CKEditorControl>
                        </div>
                        <div class="col-md-12">
                            <h6 style="color: #2e3192;">TEMPLATE FOOTER PART</h6>
                        </div>
                        <div class="col-md-12">
                            <CKEditor:CKEditorControl ID="CKEditorFooter" runat="server" BasePath="../app-assets/ckeditorq/"
                               Toolbar="Basic" ToolbarBasic="|Bold|Italic|Underline|Strike|Superscript|-|NumberedList|BulletedList|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|FontSize|TextColor|BGColor">
                            </CKEditor:CKEditorControl>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" Text="Update" OnClick="btnsave_onclick" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
