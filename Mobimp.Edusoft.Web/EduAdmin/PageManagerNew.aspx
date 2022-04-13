<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="PageRightsManager.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduAdmin.PageManagerNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Admin &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduAdmin/PageManagerNew.aspx">Page Manager</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_roles" Text="Role Names"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="drpRole" AutoPostBack="true" OnSelectedIndexChanged="drpRole_SelectedIndexChanged"
                                    runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_menuheader" Text="Parent Menu"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_menuheader" AutoPostBack="true" OnSelectedIndexChanged="ddl_menuheader_SelectedIndexChanged"
                                    runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                </div>
                <div id="divrapper" runat="server" class="card_wrapper">
                    <div class="row">
                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading" runat="server" class="Pageloader">
                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <div id="ClassList" class="row" >
                        <div class="col-md-6 customRow" style="max-height:50vh;overflow:auto" >
                            <asp:GridView ID="Gvpagemanager" EmptyDataText="No record found..."
                                CssClass="footable table-striped" OnRowDataBound="Gvpagemanager_RowDataBound" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sl.No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Page Description
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sitemapID" Visible="false" Style="text-align: left !important;" runat="server"
                                                Text='<%# Eval("PageID") %>'></asp:Label>
                                            <asp:Label ID="lbl_menustatus" Visible="false" Style="text-align: left !important;" runat="server"
                                                Text='<%# Eval("IsView") %>'></asp:Label>
                                            <asp:Label ID="lbl_menuHeader" Visible="false" Style="text-align: left !important;" runat="server"
                                                Text='<%# Eval("IsMenuheader") %>'></asp:Label>
                                            <asp:Label ID="lbl_page" Style="text-align: left !important;" runat="server"
                                                Text='<%# Eval("PageName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkselect" runat="server" onclick="Check_Click(this);" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="divupdate" class="row">
                        <div class="col-md-7 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-info button" Text="Save" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'"  OnClick="btnupdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <script type="text/javascript">

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

                //else {
                //    //If not checked change back to original color
                //    if (row.rowIndex % 2 == 0) {
                //        //Alternating Row Color
                //        row.style.backgroundColor = "white";
                //    }
                //    else {
                //        row.style.backgroundColor = "white";
                //    }

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
    </div>
</asp:Content>
