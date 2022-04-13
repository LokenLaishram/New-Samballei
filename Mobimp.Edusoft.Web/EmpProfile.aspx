<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="EmpProfile.aspx.cs" Inherits="Mobimp.Edusoft.Web.EmpProfile" %>

<%@ Register TagPrefix="asp" TagName="CustomPager" Src="~/UserControls/CustomPager.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="css3gradient">
                <div>
                    Employee Details</div>
                <div id="divmessage" runat="server">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                <div>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td width="80%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 210px">
                                            <asp:Label ID="lblemployeeName" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td style="width: 380px">
                                            :<asp:Label ID="txtemployeename" runat="server"></asp:Label>
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
                                            <asp:Label ID="lblage" runat="server" Text="Qualification"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtqualification" runat="server"></asp:Label>
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
                                            :<asp:Label ID="txtdatebirth" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Caste
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtCast" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            Dapartment
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtdepartment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <asp:Label ID="lblstate" runat="server" Text="EmployeeType"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtemployeetype" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblmarital" runat="server" Text="Marital Status"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                            <asp:Label ID="txtmarital" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr valign="top" style="height: 70;">
                                        <td>
                                            <asp:Label ID="lblemailID" runat="server" Text="Email ID"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtemailID" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblphone" runat="server" Text="Phone"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtphone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbldesignation" runat="server" Text="Designation"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtdesignation" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblmobile" runat="server" Text="MobileNo"></asp:Label>
                                        </td>
                                        <td>
                                            :<asp:Label ID="txtmobile" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr valign="top">
                                        <td>
                                            <div style="float: right; width: 95px; height: 150px; background: #fff url(../EduImages/EmpDummyPh.jpg) no-repeat top center;">
                                                <img id="imglogo" src="" title="" width="95" height="115" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="txtEmpno"></asp:Label>
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
                            <td style="width: 47%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 145px">
                                            <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td style="width: 270px">
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
                                </table>
                            </td>
                            <td style="width: 62%">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 210px">
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
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td>
                                <div class="css6gradient">
                                    Worklist&nbsp; Details
                                </div>
                                <div class="grid" style="float: left; width: 100%">
                                    <asp:GridView ID="GvAssign" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                        OnPageIndexChanging="GvAssign_PageIndexChanging" AutoGenerateColumns="False"
                                        Width="100%" class="grid" AllowPaging="false" PageSize="10" HorizontalAlign="Center">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    ID</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("AssignID")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Class</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Section</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Subject</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Teacher</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblteacher" runat="server" Text='<%# Eval("EmpName")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    AddedBy</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Added Date Time</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#d8ebf5" />
                                    </asp:GridView>
                                    <left>
                            <asp:CustomPager ID="ProfilePager" runat="server" />
                        </left>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
