<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="StdProfile.aspx.cs" Inherits="Mobimp.Edusoft.Web.StdProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="css3gradient">
                <div>
                    Student Details</div>
                <div id="divmessage" runat="server">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                <div>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td width="80%">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblstudentname" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtname" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblreleigion" runat="server" Text="Religion"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtreligion" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltype" runat="server" Text="Type"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtstdtype" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblsex" runat="server" Text="Sex"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtsex" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDOB" runat="server" Text="DOB"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtDOB" runat="server"></asp:Label>
                                            <asp:Label ID="txtage" Visible="false" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCast" runat="server" Text="Caste"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtCast" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblnationality" runat="server" Text="Nationality"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtnationality" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblbloodgroup" runat="server" Text="Blood Group"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtbloodgroup" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltranspott" runat="server" Text="Transport Type"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txttransport" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblvehicle" runat="server" Text="Vehicle No"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtvehicleno" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" class="css6gradient">
                                            <asp:Label ID="lblparentsdetails" runat="server" Text="Gurdian Details"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblfathername" runat="server" Text="Father Name"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtfathername" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblmathername" runat="server" Text="Mother Name"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtmothername" Width="200px" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblrelation" runat="server" Text="Relationship"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtrelation" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbloccupation" runat="server" Text="Father Occupation"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtoccupation" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtmobile" runat="server" Text="Mobile"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtgmobile" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblmotheroccupation" runat="server" Text="Mother Occupation"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtmotherocupation" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td valign="top">
                                            <img id="imgphoto" src="" title="" width="80" height="110" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtadmissionno" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td colspan="4">
                                <div class="css6gradient">
                                    <table width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblclassdetails" runat="server" Text="Class Details"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 44%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 130px">
                                            <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtclass" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtsection" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 62%">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblcsubjects" runat="server" Text="Compuslory Subjects :"></asp:Label>
                                        </td>
                                        <td style="width: 270px">
                                            <asp:Label ID="lblosubjects" runat="server" Text="Optional Subjects :"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">
                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvcompulsory" ShowHeader="false" CssClass="gridViewHeader" runat="server"
                                                        EmptyDataText="No record found..." AutoGenerateColumns="False" Width="120px">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1%>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Descriptions")%>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#D8EBF5" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvcompulsory" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 120px" valign="top">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="Gvoptionallist" CssClass="gridViewHeader" ShowHeader="false" runat="server"
                                                        EmptyDataText="No record found..." AutoGenerateColumns="False" Width="120px">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1%>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("OptSubjectName")%>'></asp:Label></ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvcompulsory" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td colspan="4">
                                <div class="css6gradient">
                                    <table width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblcurrentdetails" runat="server" Text="Current Address Details"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Label1" runat="server" Text="Permenant Address Details"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 44%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 130px">
                                            <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtcurraddress" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblcountry" runat="server" Text="Country"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtcurrcountry" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblcurstate" runat="server" Text="State"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtcurrstate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl" runat="server" Text="District"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtcurrdistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpin" runat="server" Text="Pin No"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtcurrpin" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbllandmarks" runat="server" Text="Land Mark"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtcurrlandmarks" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblcmobile" runat="server" Text="Mobile No"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtcmobile" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 62%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 220px">
                                            <asp:Label ID="lbladdress1" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtpermaddress" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblcountry1" runat="server" Text="Country"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtpermtcountry" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblstate1" runat="server" Text="State"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtpermstate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbldistrict1" runat="server" Text="District"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtpermdistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpin1" runat="server" Text="Pin No"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtperpin" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbllandmark1" runat="server" Text="Land Mark"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtperlandmark" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpmobile" runat="server" Text="Mobile No"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtpmobile" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
