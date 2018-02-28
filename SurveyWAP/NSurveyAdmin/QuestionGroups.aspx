﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NSurveyAdmin/MsterPageTabs.master"
    AutoEventWireup="true" CodeBehind="QuestionGroups.aspx.cs" Inherits="Votations.NSurvey.WebAdmin.NSurveyAdmin.QuestionGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="Panel" class="Panel">

    <script type="text/javascript">
        function ConfirmGroupDelete() {
            return confirm('<%= GetPageResource("GroupListDeleteConfirm") %>');
        }
    </script>

            <div class="errorDiv">
 <asp:Label ID="MessageLabel" runat="server"  CssClass="errorMessage" Visible="False"></asp:Label>
                </div>
                                            <div class="helpDiv">
                                            <a onmouseover='this.style.cursor="help" ' onfocus='this.blur();' href="Help/New/QuestionGroups.aspx"
                                                title="Click for more Information">
                                                <img alt="help" border="0" src="<%= Page.ResolveUrl("~")%>Images/small_help.gif" />
                                            </a>
                                        </div>

                <fieldset>
        <legend class="titleFont titleLegend">
           <asp:Literal ID="QuestionGroupLegend" runat="server" EnableViewState="false">Question Groups</asp:Literal> 

        </legend><br />
                                <ol>
     <li>
               <div > <asp:Literal ID="QGroupsExplainLabel" runat="server" EnableViewState="False">Note: Question groups are used for rating questions.</asp:Literal></div>
          </li><li>    
                 <asp:Label AssociatedControlID="ddlLanguage" ID="Labellanguage" runat="server">Language: </asp:Label>

                <asp:DropDownList runat="server" ID="ddlLanguage" AutoPostBack="true" Width="220" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                </asp:DropDownList>
           
      </li><li>

                <asp:Label AssociatedControlID="lbAddNew" ID="Label2" runat="server">Groups: </asp:Label>
                <asp:LinkButton runat="server" ID="lbAddNew" OnClick="OnAddNewGroup" Text="Add new"></asp:LinkButton>
  </li><li>
      <div class="rounded_corners">
                <asp:GridView runat="server" ID="gvGroups" Width="100%" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#FFF6BB" ShowFooter="True"  FooterStyle-BackColor="#FFDF12" FooterStyle-BorderStyle="None" FooterStyle-BorderColor="#E2E2E2">
                    <Columns>
                        <asp:TemplateField HeaderText="Order" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Wrap="true" ItemStyle-Width="230px" HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <span>
                                    <asp:RadioButton runat="server" ID="rbButton" Checked="false" OnCheckedChanged="OnGroupSelectionChanged"
                                        GroupName="rbGroup" AutoPostBack="true" value='<%#string.Format("{0},{1}",Eval("ID"),Eval("GroupName"))%>' /></span>
                                <span>
                                    <asp:ImageButton runat="server" ImageUrl="~/Images/arrow-green-up.gif" Width="15" OnCommand="OnReorderGroup"
                                        CommandName="ReorderGroup" CommandArgument='<%#string.Format("Up,{0}", Eval("ID"))%>' /></span><span>
                                            <asp:ImageButton runat="server" ImageUrl="~/Images/arrow-red-down.gif" Width="15" OnCommand="OnReorderGroup"
                                                CommandName="ReorderGroup" CommandArgument='<%#string.Format("Down,{0}", Eval("ID"))%>' /></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Wrap="true" ItemStyle-Width="230px" HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("GroupName")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtGroupName"  Width="200" Text='<%#Eval("GroupName")%>'></asp:TextBox></EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox runat="server" ID="txtGroupName" Width="320" Text='<%#Eval("GroupName")%>'></asp:TextBox></FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Wrap="true" HeaderText="Edit" ItemStyle-Width="230px" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="<img src='../Images/edit.gif'>"
                                    OnCommand="OnGroupEdit" CommandName="GroupEdit" CommandArgument='<%#Eval("ID")%>'
                                    CssClass="hyperlink" /></ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" ID="lbEditGroupOK" Text='OK' OnCommand="OnGroupEditOK"
                                    CommandName="GroupEdit" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton></EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="lbEditGroupOK" Text='OK' OnCommand="OnGroupEditOK"
                                    CommandName="GroupInsert" CommandArgument=''>
                                </asp:LinkButton></FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Wrap="true" ItemStyle-Width="230px" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderText="Delete"  HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" Text="<img src='../Images/delete.gif'>"
                                    OnClientClick="return ConfirmGroupDelete();" OnCommand="OnGroupDelete" CommandName="GroupDelete"
                                    CommandArgument='<%#Eval("ID")%>' CssClass="hyperlink" /></ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" ID="lbEditGroupCancel" Text='Cancel' OnClick="OnGroupEditCancel"></asp:LinkButton></EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="lbEditGroupCancel" Text='Cancel' OnClick="OnGroupEditCancel"></asp:LinkButton></FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
      </div>

        </li><li>

                <asp:Label AssociatedControlID="lbAddNewSubGroup" ID="Label4" runat="server">Sub-Groups for: </asp:Label>
                <asp:Label Font-Bold="true" ID="lblGroupName" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp; - &nbsp;&nbsp;&nbsp;
                <asp:LinkButton runat="server" ID="lbAddNewSubGroup" OnClick="OnAddNewSubGroup" Text="Add new"></asp:LinkButton>
      </li><li>
          <div class="rounded_corners">
                <asp:GridView runat="server" ID="gvSubGroup" Width="100%" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AlternatingRowStyle-BackColor="#FFF6BB" ShowFooter="True"  FooterStyle-BackColor="#FFDF12" FooterStyle-BorderStyle="None" FooterStyle-BorderColor="#E2E2E2">
                    <Columns>
                        <asp:TemplateField HeaderText="Order" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Wrap="true" ItemStyle-Width="180px" HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <span>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/arrow-green-up.gif" Width="15"
                                        OnCommand="OnReorderSubGroup" CommandName="ReorderGroup" CommandArgument='<%#string.Format("Up,{0}", Eval("ID"))%>' /></span>
                                <span>
                                    <asp:ImageButton runat="server" ImageUrl="~/Images/arrow-red-down.gif" Width="15" OnCommand="OnReorderSubGroup"
                                        CommandName="ReorderGroup" CommandArgument='<%#string.Format("Down,{0}", Eval("ID"))%>' /></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Wrap="true" ItemStyle-Width="180px" HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("GroupName")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtSubGroupName" Text='<%#Eval("GroupName")%>'></asp:TextBox></EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox runat="server" ID="txtSubGroupName" Text='<%#Eval("GroupName")%>'></asp:TextBox></FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Wrap="true" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderText="Edit" HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="<img src='../Images/edit.gif'>"
                                    OnCommand="OnSubGroupEdit" CommandName="GroupEdit" CommandArgument='<%#Eval("ID")%>'
                                    CssClass="hyperlink" /></ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" ID="lbEditGroupOK" Text='OK' OnCommand="OnSubGroupEditOK"
                                    CommandName="GroupEdit" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton></EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="lbInsertSubGroupOK" Text='OK' OnCommand="OnSubGroupEditOK"
                                    CommandName="GroupInsert">
                                </asp:LinkButton></FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Wrap="true" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" HeaderText="Delete" HeaderStyle-BackColor="#e2e2e2" HeaderStyle-BorderColor="#e2e2e2" HeaderStyle-ForeColor="#5720C6"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#E2E2E2">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" Text="<img src='../Images/delete.gif'>"
                                    OnClientClick="return ConfirmGroupDelete();" OnCommand="OnSubGroupDelete" CommandName="GroupDelete"
                                    CommandArgument='<%#Eval("ID")%>' CssClass="hyperlink" /></ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" ID="lbEditGroupCancel" Text='Cancel' OnClick="OnSubGroupEditCancel"></asp:LinkButton></EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="lbEditGroupCancel" Text='Cancel' OnClick="OnSubGroupEditCancel"></asp:LinkButton></FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              </div>
              </li>
  </ol>
                    <br />
                    </fieldset>
            <div id="fillerDiv" class="fillerDiv">&nbsp;</div>
</div>

</asp:Content>
