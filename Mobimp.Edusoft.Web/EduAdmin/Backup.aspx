<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="Backup.aspx.cs" Inherits="Mobimp.Campusoft.Web.Backup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row" style="height: 35vh">
                </div>
                <div class="row">
                    <div class="col-md-4 customRow">
                    </div>
                    <div class="col-md-4 customRow" style="text-align: center">
                        <asp:Button ID="btnBackup" runat="server" Text="BACKUP YOUR DATABASE" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" class="btn btn-sm btn-info button" OnClick="btnBackup_Click" />
                        </i>
                    </div>
                    <div class="col-md-4 customRow">
                    </div>
                </div>
                <div style=" text-align: center; font-size: x-large">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
