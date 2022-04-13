<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="Encrypter.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduUtility.Encrypter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <div >
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="btnEncrypt" runat="server" CssClass="button" Text="Encrypter" OnClick="btnEncrypt_Click" />
                    <asp:Button ID="btnDecrypt" runat="server" CssClass="button" Text="Decrypter" OnClick="btnDecrypt_Click" />
                </td>
            </tr>
        </table>
</asp:Content>
