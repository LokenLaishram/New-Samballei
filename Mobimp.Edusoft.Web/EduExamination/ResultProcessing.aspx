<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ResultProcessing.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.ClassWiseMarkEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Examination&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" href="../EduUtility/ExamDetail.aspx">Mark Detail&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a runat="server" href="../EduExamination/SubjectWiseMarkEntry.aspx">Mark Entry&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a class="active" id="activepage" runat="server" href="../EduExamination/ResultProcessing.aspx">Result Processing&nbsp;&nbsp;</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclasses" runat="server" AutoPostBack="true" class="form-control " OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                <asp:DropDownList ID="ddlexam" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlexam_SelectedIndexChanged" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <div class="form-group" style="margin-top: 1.6em;">
                                    <asp:Button ID="btn_reset" runat="server" class="btn btn-sm btn-danger button" OnClick="btn_reset_Click" Text="Reset" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="divresultlist" runat="server" visible="false" class="card_wrapper">
                    <div class="row">
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
                        </div>
                        <div id="ResultList" class="col-md-12 customRow ">
                            <asp:GridView ID="Gv_resultlist" EmptyDataText="No record found..."
                                runat="server" CssClass="table-striped table-hover" OnRowDataBound="Gv_resultlist_RowDataBound" OnRowCommand="Gv_resultlist_RowCommand" AutoGenerateColumns="false"
                                Style="width: 100%" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText=" Sl">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex+1)+(Gv_resultlist.PageIndex)*Gv_resultlist.PageSize %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("CLassID")%>'></asp:Label>
                                            <asp:Label ID="lblClass" runat="server" Text='<%# Eval("Class")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_examid" Visible="false" runat="server" Text='<%# Eval("ExamID")%>'></asp:Label>
                                            <asp:Label ID="lbl_exam" runat="server" Text='<%# Eval("ExamName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mark Entry">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_pendingcount" Visible="false" runat="server" Text='<%# Eval("PendingCount")%>'></asp:Label>
                                            <asp:Label ID="lbl_markentrystatus" Visible="false" runat="server" Text='<%# Eval("MarkEntryStatus")%>'></asp:Label>
                                            <asp:LinkButton ID="btn_entry" CssClass=" small_btn cus_btn" Height="25px" Text="Publish" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="mark" ValidationGroup="none" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Result">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_publishedsatus" Visible="false" runat="server" Text='<%# Eval("PublishedStatus")%>'></asp:Label>
                                            <asp:LinkButton ID="btn_published" CssClass=" small_btn cus_btn" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" Height="25px" runat="server"
                                                CommandName="publish" ValidationGroup="none" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Section">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_section" Width="100px" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Roll No.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_roll" autocomplete="off" Width="50PX" CssClass="custextbox" Style="text-align: center; border: 1px solid;"
                                                MaxLength="5" runat="server"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                Enabled="True" TargetControlID="txt_roll" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_rankshow" Width="100px" runat="server">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Show Rank</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Fee Status">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_feestatus" Width="100px" runat="server">
                                                <asp:ListItem Value="1">Both</asp:ListItem>
                                                <asp:ListItem Value="2">Paid</asp:ListItem>
                                                <asp:ListItem Value="3">UnPaid</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Print">
                                        <ItemTemplate>
                                            <asp:Button ID="lnkPrint" class="btn btn-sm btn-indigo small_btn button cus_btn" Height="25px" Text="Broad Sheet" runat="server"
                                                CommandName="BS" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Print">
                                        <ItemTemplate>
                                            <asp:Button ID="btn_marksheet" class="btn btn-sm btn-indigo small_btn button cus_btn" Height="25px" Text="Mark Sheet" runat="server"
                                                CommandName="MS" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Print">
                                        <ItemTemplate>
                                            <asp:Button ID="btn_result" class="btn btn-sm btn-indigo small_btn button cus_btn" Height="25px" Text="Result" runat="server"
                                                CommandName="RS" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false" HeaderText="PC for Overall">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_overall" autocomplete="off" Width="50PX" CssClass="custextbox" Style="text-align: center; border: 1px solid;"
                                                MaxLength="5" runat="server"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                Enabled="True" TargetControlID="txt_overall" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Declared On">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_declaredon" runat="server" Text='<%# Eval("DeclaredOn","{0:dd-MM-yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pass PC">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_pc" runat="server" Text='<%# Eval("PassPC")%>'></asp:Label>
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
                <div class="card_wrapper" id="divoverall" runat="server">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <div class="form-group" style="margin-top: 0.3em;">
                                    <asp:Button ID="btn_publishoverall" runat="server" class="btn btn-sm btn-info button" OnClick="btn_publishoverall_Click" Text="Publish Overall" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_sections" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:TextBox ID="txt_roll" placeholder="Roll No" class="form-control"
                                    MaxLength="5" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txt_roll" ID="FilteredTextBoxExtendertxtoldfeeamount26"
                                    runat="server" ValidChars="1234567890" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_types" runat="server" class="form-control">
                                    <asp:ListItem Value="0">Without Rank</asp:ListItem>
                                    <asp:ListItem Value="1">With Rank</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <div class="form-group pull-right" style="margin-top: 0.3em;">
                                    <asp:Button ID="btn_printbroadsheet" runat="server" class="btn btn-sm btn-indigo button" Text="Broad Sheet" OnClick="btn_printbroadsheet_Click" />
                                    <asp:Button ID="btn_overallresult" Visible="false" runat="server" class="btn btn-sm btn-indigo button" Text="Result" />
                                    <asp:Button ID="btn_overallmarksheet" runat="server" class="btn btn-sm btn-indigo button" Text="Mark Sheet"  OnClick="btn_overallmarksheet_Click" />

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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
        function Validate1() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam Type.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
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


    </script>
</asp:Content>
