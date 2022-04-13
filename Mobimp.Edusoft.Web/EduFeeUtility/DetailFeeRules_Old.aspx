<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="DetailFeeRules_Old.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduFeeUtility.DetailFeeRules_Old" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Fee Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" class="active" id="activepage" href="../EduFeeUtility/DetailFeeRules.aspx">Detail Fee Rule </a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
            <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="card_wrapper">
                        <div class="row">
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblsession" Text="Session"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlsessionID" AutoPostBack="true" OnSelectedIndexChanged="ddlsessionID_SelectedIndexChanged" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlclass" runat="server" class="form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblfeetypes" runat="server" Text="Fee Types"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlfeetypes" runat="server" class="form-control" OnSelectedIndexChanged="ddlfeetypes_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group pull-right" style="margin-top: 1.6em;">
                                    <asp:Button ID="btnadd" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                    <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="btncancel_Click" />
                                    <asp:Button ID="btn_onetime" runat="server" visible="false"/>
                                    <asp:Button ID="btn_extrarule" runat="server" visible="false" />
                                    <asp:Button ID="btn_monthlypayment" runat="server" visible="false" />
                                    <asp:Button ID="bnt_EMI" runat="server" visible="false" />
                                    <asp:Button ID="btn_Exemption" runat="server" visible="false" />
                                    <asp:Button ID="btn_InclusiveCategory" runat="server" visible="false" />
                                    <asp:Button ID="btn_InclusiveOneTime" runat="server" visible="false" />
                                    <asp:Button ID="btn_InclusiveOtherFeeTypes" runat="server" visible="false" />
                                    <asp:Button ID="btn_InclusiveMonth" runat="server" visible="false" />
                                    <asp:Label ID="lblhiddenID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddensession" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddencategory" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenfeetype" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenclass" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddensessionID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddencategoryID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenfeetypeID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenOtherfeetypeID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenclassID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenpaymentID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenEMIID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenNewFeeAmount" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenOldFeeAmount" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddennoemi" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card_wrapper">
                        <div class="row">
                            <div class="col-md-4 customRow" style="margin-top: 13px;">
                                <asp:Label ID="lblresult" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_export" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-1 customRow">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddl_show" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control">
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="20"> 20 </asp:ListItem>
                                        <asp:ListItem Value="50"> 50 </asp:ListItem>
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
                            <div id="Feedetailmain" class="col-md-12 customRow ">
                                <asp:GridView ID="GvDetailFee" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                    AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server" OnRowCommand="GvDetailFee_RowCommand"
                                    OnPageIndexChanging="GvDetailFee_PageIndexChanging" Style="width: 100%" GridLines="None" OnRowDataBound="GvDetailFee_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex+1)+(GvDetailFee.PageIndex)*GvDetailFee.PageSize %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Category
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                <asp:Label ID="lblsessionID" Visible="false" runat="server" Text='<%# Eval("SessionID")%>'></asp:Label>
                                                <asp:Label ID="lblsession" Visible="false" runat="server" Text='<%# Eval("SessionName")%>'></asp:Label>
                                                <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                <asp:Label ID="lblfeetypeID" Visible="false" runat="server" Text='<%# Eval("FeeTypeID")%>'></asp:Label>
                                                <asp:Label ID="lblcategoryID" Visible="false" runat="server" Text='<%# Eval("CategoryID")%>'></asp:Label>
                                                <asp:Label ID="lblcategorys" runat="server" Text='<%# Eval("CategoryName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Class
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblclasss" runat="server" Text='<%# Eval("Class")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fee Type
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblfeetypess" runat="server" Text='<%# Eval("FeeType")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fee  Payment Type 
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblpaymenttype" runat="server" Visible="false" Text='<%# Eval("PaymentTypeID")%>'></asp:Label>
                                                <asp:DropDownList ID="ddlpaymenttype" Width="100px" Class="form-control" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fee Structure *">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="upfeestructure" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblfeestructure" Visible="false" runat="server" Text='<%# Eval("FeeStructureStatus")%>'></asp:Label>
                                                        <asp:LinkButton ID="lnlfeestructure" CssClass=" small_btn cus_btn" Height="25px" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="FeeStructure" ValidationGroup="none" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fee Amount New Student
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_noemi" Visible="false" runat="server" Text='<%# Eval("NoEMI")%>'></asp:Label>
                                                <asp:TextBox ID="txtfeeamount_newstudent" Enabled="false" Width="50px" runat="server" Class="form-control" Text='<%# Eval("FeeNewStudent","{0:0#.##}")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fee Amount Old Student
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtfeeamount_oldstudent" Enabled="false" Width="50px" runat="server" Class="form-control" Text='<%# Eval("FeeOldStudent","{0:0#.##}")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                Apply Student Type?
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstudenttypeapply" Visible="false" runat="server" Text='<%# Eval("IsStudentTypeApply")%>'></asp:Label>
                                                <asp:CheckBox ID="chkstudenttypeapply" runat="server" Style="margin-left: 15px;" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fee Exemption Rule *">
                                            <ItemTemplate>
                                                <asp:Label ID="lblexemptionrule" Visible="false" runat="server" Text='<%# Eval("ExemptionRuleStatus")%>'></asp:Label>
                                                <asp:LinkButton ID="lnlexemptionrule" CssClass=" small_btn cus_btn" Height="25px" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="ExemptionRule" ValidationGroup="none" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fee Inclusive Rule (Opt.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinclusiverule" Visible="false" runat="server" Text='<%# Eval("InclusiveRuleStatus")%>'></asp:Label>
                                                <asp:LinkButton ID="lnlinclusiverule" CssClass=" small_btn cus_btn" Height="25px" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="InclusiveRule" ValidationGroup="none" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                Heirarchy
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtheirarchy" runat="server" Width="40px" class="form-control" Text='<%# Eval("FeeHeirarchy")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Activation
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblactivate" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                <asp:CheckBox ID="chkactivate" runat="server" OnCheckedChanged="chkactivate_CheckedChanged" AutoPostBack="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Action
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Deletes" ValidationGroup="none" />
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
                    <%-- ModalPopupExtender1--%>
                    <%-- Popup1=OneTimepayment--%>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup1"
                            TargetControlID="btn_onetime" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior1">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlPopup1" runat="server" CssClass="ModalPopUpPanel" Style="display: none">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbtnclosePopup1" runat="server" OnClick="lnbtnclosePopup1_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblsessionpop1" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop12" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclasspop1" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclasspop12" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblcategorypop1" runat="server" Text="Fee Category"></asp:Label>
                                        <asp:Label ID="lblcategorypop12" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfeetypespop1" runat="server" Text="Fee Types"></asp:Label>
                                        <asp:Label ID="lblfeetypespop12" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.6em;">
                                        <asp:Button ID="btnOneTimepayment" Visible="false" runat="server" class="btn btn-sm btn-yellow button" Text="Preview" OnClick="btnOneTimepayment_Click" />
                                    </div>
                                </div>
                                <div class="col-md-1 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.6em;">
                                        <asp:Button ID="btnaddrowpop1" runat="server" class="btn btn-sm btn-info button" Text="Add" OnClick="btnaddrowpop1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="text-align: center;">
                                <div class="col-md-12 customRow">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkOneTimeLabel" Checked="true" Enabled="false"></asp:CheckBox>
                                        <asp:Label ID="lvlOneTimeLabel" runat="server" Text="One Time">
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 100px; max-height: 200px; overflow-y: auto;">
                                    <asp:GridView ID="GvOneTimeFee" ShowFooter="true" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None" OnRowCommand="GvOneTimeFee_RowCommand" OnRowDataBound="GvOneTimeFee_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(GvOneTimeFee.PageIndex)*GvOneTimeFee.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Particulars
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblonetimeID" Visible="false" runat="server" Text='<%# Eval("OnetimeID")%>'></asp:Label>
                                                    <asp:TextBox ID="txtParticulars" runat="server" Height="20px" Width="250px" class="form-control" Text='<%# Eval("Particulars")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbl_total" runat="server" Text="Total" Style="margin-left: 220px;"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Amount New Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtnewfeeamount" runat="server" Height="20px" Width="100px" class="form-control" Text='<%# Eval("FeeAmount_New","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtnewfeeamount" ID="FilteredTextBoxExtendertxtnewfeeamount"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl_totalnew" Visible="false" Text='<%# Eval("TotalNewFeeAmount","{0:0#.##}")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbl_totalfee_new_fotter" runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Amount Old Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtoldfeeamount" FilterType="Numbers,Custom" ValidChars="." runat="server" Height="20px" Width="100px" class="form-control" Text='<%# Eval("FeeAmount_Old", "{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtoldfeeamount" ID="FilteredTextBoxExtendertxtoldfeeamount"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label ID="lbl_totalold" Visible="false" Text='<%# Eval("TotalOldFeeAmount","{0:0#.##}")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbl_totalfee_old_fotter" runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Activate
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblactivatepop1" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                    <asp:CheckBox ID="chkactivatepop1" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Action
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_deletepop1" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Deletespop1" ValidationGroup="none" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lbldiscountlimit" Text="Discount Limit"></asp:Label>
                                        <asp:TextBox ID="txtdiscountlimit" runat="server" class="form-control"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtdiscountlimit" ID="FilteredTextBoxExtendertxtdiscountlimit"
                                            runat="server" ValidChars="1234567890." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblduedatepop1" Text="Due Date"></asp:Label>
                                        <asp:TextBox ID="txtduedatepop1" runat="server" class="form-control"></asp:TextBox>
                                        <asp:CalendarExtender ID="ceduedatepop1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                            TargetControlID="txtduedatepop1" />
                                        <asp:MaskedEditExtender ID="meeduedatepop1" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtduedatepop1" />
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblfinepop1" Text="Fine"></asp:Label>
                                        <asp:TextBox ID="txtfinepop1" runat="server" class="form-control"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtfinepop1" ID="FilteredTextBoxExtendertxtfinepop1"
                                            runat="server" ValidChars="1234567890." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow" style="visibility: hidden">
                                    <div class="form-group" style="margin-top: 1.6em;">
                                        <asp:LinkButton ID="lnlextrarule" runat="server" Visible="false" Text="Extra Rule" OnClick="lnlextrarulepop1_Click" EnableTheming="True" Style="margin-left: 90px; color: red;"></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow" style="margin-top: 1.6em;">
                                    <div class="form-group">
                                        <asp:Button ID="btnsaveonetime" runat="server" Text="Save" class="btn btn-sm btn-success button" Style="float: right;" OnClick="btnsaveonetime_Click" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <%-- End of OneTime Payment --%>
                    <%-- ModalPopupExtender2--%>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlextrarule"
                            TargetControlID="btn_extrarule" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior2">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlextrarule" runat="server" CssClass="ModalPopUpPanelpop1" Style="display: none">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbtnclosedpop2" runat="server" OnClick="lnbtnclosedpop2_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsessionpop2" runat="server" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop22" runat="server" class="form-control"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop2" runat="server" Visible="false" class="form-control"></asp:Label>
                                        <asp:Label ID="lblfeetypesIDpop2" runat="server" Visible="false" class="form-control"></asp:Label>
                                        <asp:Label ID="lblcategoryIDpop2" runat="server" Visible="false" class="form-control"></asp:Label>
                                        <asp:Label ID="lblclassIDpop2" runat="server" Visible="false" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfeetypespop2" runat="server" Text="Fee Type"></asp:Label>

                                        <asp:Label ID="lblfeetypespop22" runat="server" class="form-control">

                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblcategorypop2" runat="server" Text="Fee Category"></asp:Label>

                                        <asp:Label ID="lblcategorypop22" runat="server" class="form-control">

                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.6em;">
                                        <asp:Button ID="btnaddrowpop2" runat="server" class="btn btn-sm btn-info button" Text="Add" OnClick="btnaddrowpop2_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1 customRow" style="margin-left: 150px">
                                    <div class="form-group">
                                        <asp:Label ID="lblIsOptionalpop2" Visible="false" runat="server"></asp:Label>
                                        <asp:CheckBox ID="chkIsOptionalpop2" runat="server" OnCheckedChanged="chkIsOptionalpop2_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblOptionalpop2" runat="server" Text="Optional Subject"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-1 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblIsMiscpop2" Visible="false" runat="server"></asp:Label>
                                        <asp:CheckBox ID="ChkIsMiscpop2" runat="server" OnCheckedChanged="ChkIsMiscpop2_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-1 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblMicpop2" runat="server" Text="Misc"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="text-align: center;">
                                <div class="col-md-12 customRow">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkExtraFeeRuleLabel" Checked="true" Enabled="false"></asp:CheckBox>
                                        <asp:Label ID="lblExtraFeeRuleLabel" runat="server" Text="Extra Fee Rule">
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper ">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 100px; max-height: 150px; overflow-y: auto;">
                                    <asp:GridView ID="GvExtraRule" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None" OnRowDataBound="GvExtraRule_RowDataBound" OnRowCommand="GvExtraRule_RowCommand">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(GvExtraRule.PageIndex)*GvExtraRule.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Subject
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpop2ID" runat="server" Class="form-control" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>

                                                    <asp:Label ID="lblsubjectpop2" runat="server" Class="form-control" Visible="false" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                    <asp:DropDownList ID="ddlSubjectpop2" Height="20px" Width="130px" runat="server">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Miscellaneous
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtMiscpop2" Height="20px" Width="130px" Class="form-control" runat="server" Text='<%# Eval("Miscellaneous")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <asp:TextBox ID="txtpop2Amount" Height="20px" Width="100px" runat="server" class="form-control" Text='<%# Eval("Amount","{0:0#.##}")%>'></asp:TextBox>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Activate
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblactivatepop2" Class="form-control" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                    <asp:CheckBox ID="chkactivatepop2" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_deletepop2" class="cus-btn btn-sm btn-danger button" Text="-" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Deletespop2" ValidationGroup="none" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 customRow">
                                    <div class="form-group">
                                        <asp:Button ID="btnsaveextra" runat="server" Text="Save" class="btn btn-sm btn-success button" Style="float: right; margin-right: 15px;" OnClick="btnsaveextra_Click" />
                                    </div>
                                </div>
                            </div>

                        </asp:Panel>
                    </div>
                    <%-- End of ExtraFeeRule --%>
                    <%-- ModalPopupExtender3--%>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="pnlmonthlypayment"
                            TargetControlID="btn_monthlypayment" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior3">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlmonthlypayment" runat="server" CssClass="ModalPopUpPanel" Style="display: none">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbtnclosedpop3" runat="server" OnClick="lnbtnclosedpop3_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsessionpop3" runat="server" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop3" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclasspop3" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclassIDpop3" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblcategorypop3" runat="server" Text="Category"></asp:Label>
                                        <asp:Label ID="lblcategoryIDpop3" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfeetypepop3" runat="server" Text="Fee Type"></asp:Label>
                                        <asp:Label ID="lblfeetypeIDpop3" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.6em;">
                                        <asp:Button ID="btnMonthlyPayment" runat="server" Visible="false" class="btn btn-sm btn-yellow button" Text="Preview" OnClick="btnMonthlyPayment_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="text-align: center;">
                                <div class="col-md-12 customRow">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkMonthlyPaymentLabel" Checked="true" Enabled="false"></asp:CheckBox>
                                        <asp:Label ID="lblMonthlyPaymentLabel" runat="server">
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 199px; max-height: 200px; overflow-y: auto;">
                                    <asp:GridView ID="GvMonthlyPayment" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None" OnRowDataBound="GvMonthlyPayment_RowDataBound" ShowFooter="true">

                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(GvMonthlyPayment.PageIndex)*GvMonthlyPayment.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Particulars
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonthlyIDpop3" Visible="false" runat="server" Text='<%# Eval("MonthlyID")%>'></asp:Label>
                                                    <asp:Label ID="txtParticularspop3" runat="server" Text='<%# Eval("Particulars")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Amount New Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtnewfeeamountpop3" autocomplete="off" onfocus="this.select();" runat="server" Height="20px" Width="70px" class="form-control" Text='<%# Eval("FeeAmount_New","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtnewfeeamountpop3" ID="FilteredTextBoxExtendertxtoldfeeamount23"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Amount Old Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtoldfeeamountpop3" autocomplete="off" onfocus="this.select();" runat="server" Height="20px" Width="70px" class="form-control" Text='<%# Eval("FeeAmount_Old","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtoldfeeamountpop3" ID="FilteredTextBoxExtendertxtoldfeeamount24"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Exemption
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtexemptionpop3" runat="server" autocomplete="off" onfocus="this.select();" Height="20px" Width="70px" class="form-control" Text='<%# Eval("Exemption","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtexemptionpop3" ID="FilteredTextBoxExtendertxtoldfeeamount25"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbl_totalpop3" runat="server" Text="Total"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Net Amount New Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblnewnetfeeamountpop3" runat="server" Height="20px" Width="70px" Text='<%# Eval("TotalFeeAmount_New","{0:0#.##}")%>'></asp:Label>
                                                    <asp:Label ID="lblamountnewfeepop3" Visible="false" Text='<%# Eval("NetFeeAmount_New","{0:0#.##}")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblamountnewfeepop31" runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Net Amount Old Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="txtoldnetfeeamountpop3" runat="server" Height="20px" Width="70px" Text='<%# Eval("TotalFeeAmount_Old","{0:0#.##}")%>'></asp:Label>
                                                    <asp:Label ID="lblamountoldfeepop3" Visible="false" Text='<%# Eval("NetFeeAmount_Old","{0:0#.##}")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblamountoldfeepop31" runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Computer Fee
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                 <asp:TextBox ID="txt_computerfee" runat="server" autocomplete="off" onfocus="this.select();" Height="20px" Width="70px" class="form-control" Text='<%# Eval("ComputerFee","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txt_computerfee" ID="FilteredTextBoxExtendertxtoldfeeamount68"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>     
                                                </ItemTemplate>
                                           
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    EMI
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_emi" autocomplete="off" onfocus="this.select();" runat="server" Height="20px" Width="50px" MaxLength="2" class="form-control" Text='<%# Eval("EMI")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txt_emi" ID="FilteredTextBoxExtendertxtoldfeeamount28"
                                                        runat="server" ValidChars="1234567890" Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Activate
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblactivatepop3" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                    <asp:CheckBox ID="chkactivatepop3" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblduedatepop3" Text="Due Date" Width="80px"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-1 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblprepaidpop3" Text="Prepaid"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chkPrePaidpop3" runat="server" OnCheckedChanged="chkPrePaidpop3_CheckedChanged" AutoPostBack="true" />
                                        <asp:Label ID="lblddlprepaidpop3" runat="server" Text="For every"></asp:Label>
                                        <asp:DropDownList ID="ddlprepaidpop3" Width="50px" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-1 customRow" style="visibility: hidden">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblpostpaidpop3" Text="PostPaid"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow" style="visibility: hidden">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chkPostPaidpop3" runat="server" OnCheckedChanged="chkPostPaidpop3_CheckedChanged" AutoPostBack="true" />
                                        <asp:Label ID="lblddlpostpaidpop3" runat="server" Text="For every"></asp:Label>
                                        <asp:DropDownList ID="ddlpostpaidpop3" Width="50px" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblfinepop3" Text="Fine"></asp:Label>
                                        <asp:TextBox ForeColor="Black" ID="txtfinepop3" Style="border: 1px solid #2e3192; color: #000000; height: 20px; width: 83px; padding: 5px; margin-left: 10px;" runat="server"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtfinepop3" ID="FilteredTextBoxExtendertxtoldfeeamount28"
                                            runat="server" ValidChars="1234567890." Enabled="True">
                                        </asp:FilteredTextBoxExtender>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow" style="visibility: hidden">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblonetimepaymentpop3" Text="One time payment given"></asp:Label>
                                        <asp:Label ID="lblIsonetimepaymentpop3" Visible="false" runat="server"></asp:Label>
                                        <asp:CheckBox ID="chkonetimepaymentpop3" runat="server" OnCheckedChanged="chkonetimepaymentpop3_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-4 customRow" style="visibility: hidden">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblavaildiscdatepop3" Text="Availabe Discount Date" Width="140px"></asp:Label>
                                        <asp:TextBox ID="txtavaildiscdatepop3" Enabled="false" runat="server" Style="border: 1px solid #2e3192; height: 20px; width: 83px; padding: 5px; margin-left: 10px;"></asp:TextBox>
                                        <asp:CalendarExtender ID="Cetxtavaildiscdatepop3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                            TargetControlID="txtavaildiscdatepop3" />
                                        <asp:MaskedEditExtender ID="Metxtavaildiscdatepop3" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtavaildiscdatepop3" />
                                    </div>
                                </div>
                                <div class="col-md-4 customRow" style="visibility: hidden">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lbldiscountlimitpop3" Text="Discount Limit" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtdiscountlimitpop3" Enabled="false" runat="server" Style="border: 1px solid #2e3192; height: 20px; width: 83px; padding: 5px; margin-left: 10px;"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtdiscountlimitpop3" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="1234567890." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:LinkButton ID="lblextrarulepop3" Visible="false" runat="server" Text="Extra Rule" OnClick="lnlextrarulepop3_Click" EnableTheming="True" Style="margin-left: 90px; color: red;"></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-md-9 customRow">
                                    <div class="form-group">
                                        <asp:Button ID="btnsavepop3" runat="server" Text="Save" class="btn btn-sm btn-success button" OnClick="btnsavepop3_Click" Style="float: right;" />
                                    </div>
                                </div>
                            </div>

                        </asp:Panel>
                    </div>
                    <%-- End of MonthlyPayment --%>
                    <%-- ModalPopupExtender4--%>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="pnlemipayment"
                            TargetControlID="bnt_EMI" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior4">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlemipayment" runat="server" CssClass="ModalPopUpPanel" Style="display: none">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbtnclosedpop4" runat="server" OnClick="lnbtnclosedpop4_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsessionpop4" runat="server" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop4" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclasspop4" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclassIDpop4" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblcategorypop4" runat="server" Text="Category"></asp:Label>
                                        <asp:Label ID="lblcategoryIDpop4" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfeetypepop4" runat="server" Text="Fee Type"></asp:Label>
                                        <asp:Label ID="lblfeetypeIDpop4" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblhiddencount" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblnoemipop4" runat="server" Text="No. EMI"></asp:Label>
                                        <asp:DropDownList ID="ddlnoemipop4" runat="server" class="form-control" OnSelectedIndexChanged="ddlnoemipop4_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Button ID="btnEmiPayment" runat="server" Visible="false" Text="Preview" class="btn btn-sm btn-yellow button" OnClick="btnEmiPayment_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblduedatepop4" runat="server" Text="Due Date"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblprepaidpop4" runat="server" Text="Prepaid"></asp:Label>
                                        <asp:CheckBox ID="chkprepaidpop4" runat="server" OnCheckedChanged="chkprepaidpop4_CheckedChanged" AutoPostBack="true" />
                                        <asp:Label ID="lblpostpaidpop4" runat="server" Text="Postpaid"></asp:Label>
                                        <asp:CheckBox ID="chkpostpaidpop4" runat="server" OnCheckedChanged="chkpostpaidpop4_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chklblemipop4" runat="server" Checked="true" Enabled="false" />
                                        <asp:Label ID="lblemi" runat="server" Text="EMI"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 199px; max-height: 200px; overflow-y: auto;">
                                    <asp:GridView ID="Gv_Emipayment" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None" OnRowDataBound="Gv_Emipayment_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(Gv_Emipayment.PageIndex)*Gv_Emipayment.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Particulars
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonthlyIDpop4" Visible="false" runat="server" Text='<%# Eval("MonthlyID")%>'></asp:Label>
                                                    <asp:Label ID="lblisLastIndex" Visible="false" runat="server" Text='<%# Eval("IsLastIndex")%>'></asp:Label>
                                                    <asp:Label ID="lblActivatedpop4" Visible="false" runat="server" Text='<%# Eval("Activated")%>'></asp:Label>
                                                    <asp:Label ID="lblParticularspop4" runat="server" Width="120px" Text='<%# Eval("Particulars")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    EMI
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstallmentOrderpop4" runat="server" Text='<%# Eval("InstallmentOrderID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Amt New Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtNewFeeAmountpop4" runat="server" Height="20px" Width="100px" class="form-control" Text='<%# Eval("FeeAmount_New","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtNewFeeAmountpop4" ID="FilteredTextBoxExtendertxtoldfeeamount29"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Amt Old Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOldFeeAmountpop4" runat="server" Height="20px" Width="100px" class="form-control" Text='<%# Eval("FeeAmount_Old","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtOldFeeAmountpop4" ID="FilteredTextBoxExtendertxtoldfeeamount30"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Exemption
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtexemptionpop4" runat="server" Height="20px" Width="70px" class="form-control" Text='<%# Eval("Exemption","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtexemptionpop4" ID="FilteredTextBoxExtendertxtoldfeeamount31"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <%-- <FooterTemplate>
                                                <asp:Label ID="lbl_totalpop4" runat="server" Text="Total"></asp:Label>
                                            </FooterTemplate>--%>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Net Amount New Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblnewnetfeeamountpop4" runat="server" Enabled="false" Height="20px" Width="70px" Text='<%# Eval("TotalFeeAmount_New","{0:0#.##}")%>'></asp:Label>
                                                    <%--<asp:Label ID="lblamountnewfeepop4" Visible="false" Text='<%# Eval("NetFeeAmount_New","{0:0#.##}")%>' runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                                <%--<FooterTemplate>
                                                <asp:Label ID="lblamountnewfeepop41" runat="server"></asp:Label>
                                            </FooterTemplate>--%>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Net Amount Old Student
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloldnetfeeamountpop4" runat="server" Enabled="false" Height="20px" Width="70px" Text='<%# Eval("TotalFeeAmount_Old","{0:0#.##}")%>'></asp:Label>
                                                    <%--<asp:Label ID="lblamountoldfeepop4" Visible="false" Text='<%# Eval("NetFeeAmount_Old","{0:0#.##}")%>' runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                                <%--<FooterTemplate>
                                                <asp:Label ID="lblamountoldfeepop41" runat="server"></asp:Label>
                                            </FooterTemplate>--%>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Due Date
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDueDatepop4" runat="server" Height="20px" Width="100px" class="form-control" Text='<%# Eval("DueDate")%>'></asp:TextBox>
                                                    <asp:CalendarExtender ID="CEtxtDueDatepop4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                        TargetControlID="txtDueDatepop4" />
                                                    <asp:MaskedEditExtender ID="MEtxtDueDatepop4" runat="server" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDueDatepop4" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Fine
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtFinepop4" runat="server" Height="20px" Width="100px" class="form-control" Text='<%# Eval("Fine","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtFinepop4" ID="FilteredTextBoxExtendertxtoldfeeamount32"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Activate
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActivatepop4" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                    <asp:CheckBox ID="chkactivatepop4" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chkonetimepaymentpop4" runat="server" AutoPostBack="true" OnCheckedChanged="chkonetimepaymentpop4_CheckedChanged" />
                                        <asp:Label ID="lblonetimepaymentpop4" runat="server" Text="OneTimePayment"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbldiscountlimitpop4" runat="server" Text="Discount Limit"></asp:Label>
                                        <asp:TextBox ID="txtdiscountlimitpop4" Enabled="false" runat="server" Height="20px" Width="80px" class="form-control"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtdiscountlimitpop4" ID="FilteredTextBoxExtendertxtoldfeeamount33"
                                            runat="server" ValidChars="1234567890." Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group" style="margin-top: 1.6em;">
                                        <asp:LinkButton ID="lnlemipop4" runat="server" Visible="false" Text="Extra Rule" OnClick="lnlemipop4_Click" EnableTheming="True" Style="margin-left: 90px; color: red;"></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow" style="margin-top: 1.6em;">
                                    <div class="form-group">
                                        <asp:Button ID="btnsavepop4" runat="server" Text="Save" class="btn btn-sm btn-success button" Style="float: right;" OnClick="btnsavepop4_Click" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <%-- End of FeeStructureEMI --%>
                    <%-- ModalPopupExtender5--%>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender5" runat="server" PopupControlID="pnlexemption"
                            TargetControlID="btn_Exemption" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior5">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlexemption" runat="server" CssClass="ModalPopUpPanel" Style="display: none">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbclosedpop5" runat="server" OnClick="lnbclosedpop5_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsessionpop5" runat="server" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop5" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclasspop5" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclassIDpop5" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblcategorypop5" runat="server" Text="Category"></asp:Label>
                                        <asp:Label ID="lblcategoryIDpop5" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfeetypepop5" runat="server" Text="Fee Type"></asp:Label>
                                        <asp:Label ID="lblfeetypeIDpop5" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">

                                        <div class="form-group pull-right" style="margin-top: 1.6em;">
                                            <asp:Button ID="btnExemptionRule" runat="server" Visible="false" Text="Preview" class="btn btn-sm btn-yellow button" OnClick="btnExemptionRule_Click"></asp:Button>
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 199px; max-height: 200px; overflow-y: auto;">
                                    <asp:GridView ID="Gv_Exemption" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None" OnRowDataBound="Gv_Exemption_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(Gv_Exemption.PageIndex)*Gv_Exemption.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Student Type
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExemptionpop5" Visible="false" runat="server" Text='<%# Eval("ExemptionID")%>'></asp:Label>
                                                    <asp:Label ID="lblStudentTypeIDpop5" Visible="false" runat="server" Text='<%# Eval("StudentTypeID")%>'></asp:Label>
                                                    <asp:Label ID="lblStudentTypepop5" runat="server" Font-Size="Small" Text='<%# Eval("StudentType")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    New Fee Amount 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeeAmountNewpop5" runat="server" Text='<%# Eval("FeeAmount_New","{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Old Fee Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeeAmountOldpop5" runat="server" Text='<%# Eval("FeeAmount_Old","{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    New Exempted Amount 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtExempAmountNewpop5" runat="server" Height="20px" Width="80px" class="form-control" Text='<%# Eval("ExemptedAmount_New","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtExempAmountNewpop5" ID="FilteredTextBoxExtendertxtoldfeeamount26"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Old Exempted Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtExempAmountOldpop5" runat="server" Height="20px" Width="80px" class="form-control" Text='<%# Eval("ExemptedAmount_Old","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender TargetControlID="txtExempAmountOldpop5" ID="FilteredTextBoxExtendertxtoldfeeamount27"
                                                        runat="server" ValidChars="1234567890." Enabled="True">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    New Net Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNetAmountNewpop5" Enabled="false" runat="server" Width="80px" Text='<%# Eval("NetAmount_New","{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Old Net Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNetAmountOldpop5" runat="server" Enabled="false" Width="80px" Text='<%# Eval("NetAmount_Old","{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Activation
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActivatepop5" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                    <asp:CheckBox ID="chkactivatepop5" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 customRow">
                                    <%--style="margin-top: 1.6em;"--%>
                                    <div class="form-group">
                                        <asp:Button ID="btnsavepop5" runat="server" Text="Save" class="btn btn-sm btn-success button" Style="float: right;" OnClick="btnsavepop5_Click" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender6" runat="server" PopupControlID="pnlInclusiveCategory"
                            TargetControlID="btn_InclusiveCategory" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior6">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlInclusivecategory" runat="server" CssClass="ModalPopUpPanel" Style="display: none; width: 450px">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbclosedpop6" runat="server" OnClick="lnbclosedpop6_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-4 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsessionpop6" runat="server" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop6" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclasspop6" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclassIDpop6" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblcategorypop6" runat="server" Text="Category"></asp:Label>
                                        <asp:DropDownList ID="ddlcategoryIDpop6" runat="server" class="form-control" OnSelectedIndexChanged="ddlcategoryIDpop6_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <%-- ModalPopupExtender62--%>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender62" runat="server" PopupControlID="pnlInclusiveOtherFeeTypes"
                            TargetControlID="btn_InclusiveOtherFeeTypes" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior62">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlInclusiveOtherFeeTypes" runat="server" CssClass="ModalPopUpPanel" Style="display: none; width: 650px">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbclosedpop62" runat="server" OnClick="lnbtnclosedpop62_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsessionpop62" runat="server" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionIDpop62" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclasspop62" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclassIDpop62" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblcategorypop62" runat="server" Text="Category"></asp:Label>
                                        <asp:Label ID="lblcategoryIDpop62" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfeetypepop62" runat="server" Text="Fee Type"></asp:Label>
                                        <asp:Label ID="lblfeetypeIDpop62" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="text-align: center;">
                                <div class="col-md-12 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblInclusiveOtherFeeTypes" runat="server" Text="Other Mothly Fee Types"></asp:Label>
                                        <asp:CheckBox ID="chkInclusiveOtherFeeTypes" runat="server" Checked="true" Enabled="false" />
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 199px; max-height: 200px; overflow-y: auto;">
                                    <asp:GridView ID="Gv_InclusiveOtherFeeTypes" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None" OnRowCommand="Gv_InclusiveOtherFeeTypes_RowCommand" OnRowDataBound="Gv_InclusiveOtherFeeTypes_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(Gv_InclusiveOtherFeeTypes.PageIndex)*Gv_InclusiveOtherFeeTypes.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Fee Types
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInclusiveID" runat="server" Visible="false" Text='<%# Eval("InclusiveID")%>'></asp:Label>
                                                    <asp:Label ID="lblOtherFeeTypesID" runat="server" Visible="false" Text='<%# Eval("OtherFeeTypeID")%>'></asp:Label>
                                                    <asp:Label ID="lblparticularsOtherFeeTypes" runat="server" Text='<%# Eval("Particulars")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Add
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:UpdatePanel ID="upInclusiveOtherFeeTypes" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnlInclusiveOtherFeeTypes" CssClass=" small_btn cus_btn" Height="25px" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                CommandName="InclusiveOtherFeeTypes" Text="+" ValidationGroup="none" Style="text-align: left !important;" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    IsActivate?
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActivateInclusiveOtherFeeTypes" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                    <asp:CheckBox ID="chkactivateInclusiveOtherFeeTypes" Enabled="false" runat="server" OnCheckedChanged="chkactivateInclusiveOtherFeeTypes_CheckedChanged" AutoPostBack="true" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <%-- ModalPopupExtender63--%>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender63" runat="server" PopupControlID="pnlInclusiveMonths"
                            TargetControlID="btn_InclusiveMonth" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior63">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlInclusiveMonths" runat="server" CssClass="ModalPopUpPanel" Style="display: none; width: 650px">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbclosedpop63" runat="server" OnClick="lnbclosedpop63_Click" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div style="text-align: right;">
                                    <asp:Button ID="btnInclusiveMonth" runat="server" Text="Save" Style="margin-right: 13px;" class="btn btn-sm btn-success button" OnClick="btnInclusiveMonth_Click"></asp:Button>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 199px; max-height: 200px; overflow-y: auto;">
                                    <asp:GridView ID="Gv_InclusiveMonths" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None" OnRowDataBound="Gv_InclusiveMonths_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(Gv_InclusiveMonths.PageIndex)*Gv_InclusiveMonths.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Months
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInclusiveMonthID" runat="server" Visible="false" Text='<%# Eval("MonthID")%>'></asp:Label>
                                                    <asp:Label ID="lblInclusiveMonthOtherFeeTypesID" runat="server" Visible="false" Text='<%# Eval("OtherFeeTypeID")%>'></asp:Label>
                                                    <asp:Label ID="lblInclusiveMonth" runat="server" Text='<%# Eval("Particulars")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    New FeeAmount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtInclusiveTotalAmounts" runat="server" class="form-control" Width="80px" Height="20px" Text='<%# Eval("TotalFeeAmount","{0:0#.##}")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    IsActivate?
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInclusiveIsActivate" Visible="false" runat="server" Text='<%# Eval("IsActivate")%>'></asp:Label>
                                                    <asp:CheckBox ID="chkInclusiveIsActivateMonth" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        function clickEnter(obj, event) {
            var keyCode;
            if (event.keyCode > 0) {
                keyCode = event.keyCode;
            }
            else if (event.which > 0) {
                keyCode = event.which;
            }
            else {
                keycode = event.charCode;
            }
            if (keyCode == 13) {
                document.getElementById(obj).focus();
                return false;
            }
            else {
                return true;
            }
        }
        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#FeeTypeList table tbody tr').each(function () {
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
            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlsessionID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Session.\n"
                document.getElementById("<%=ddlsessionID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Class.\n"
                document.getElementById("<%=ddlclass.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlfeetypes.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Fee Types.\n"
                document.getElementById("<%=ddlfeetypes.ClientID %>").focus()
                i++
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
                return true
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
        $(function () {
            $('[id*=GvFeeTypes]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvFeeTypes]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#FeeTypeList table tbody tr').each(function () {
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
