﻿
<%@ Page language="c#" MasterPageFile="MsterPageTabs.master"   ValidateRequest="false"	AutoEventWireup="false" Inherits="Votations.NSurvey.WebAdmin.ConditionalEndMessage" Codebehind="ConditionalEndMessage.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div id="Panel" class="Panel">

            <div class="errorDiv">
                <asp:Label ID="MessageLabel" runat="server" CssClass="errorMessage" Visible="False"></asp:Label>
            </div>
            <br />
    <fieldset>
        <legend class="titleFont titleLegend">
                    <asp:Literal ID="AddNewConditionTitle" runat="server" EnableViewState="False"></asp:Literal></legend>
        <br />
<ol>
     <li>
                        <asp:Label ID="MessageConditionLabel"
                            runat="server" AssociatedControlID="MessageConditionDropdownlist"></asp:Label>
                        <asp:DropDownList ID="MessageConditionDropdownlist" runat="server" AutoPostBack="True"></asp:DropDownList>
 </li><li>
                        <asp:Label ID="QuestionLabel"
                            runat="server" AssociatedControlID="QuestionFilterDropdownlist">Question :</asp:Label>
                        <asp:DropDownList ID="QuestionFilterDropdownlist" runat="server" AutoPostBack="True"></asp:DropDownList>
 </li><li>
                        <asp:Label ID="ConditionalLabel" AssociatedControlID="LogicDropDownList" runat="server">Conditional operator :</asp:Label>
                        <asp:DropDownList ID="LogicDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
 </li><li>
                        <asp:Label ID="AnswerLabel" AssociatedControlID="AnswerFilterDropdownlist" runat="server">Answer :</asp:Label>
                        <asp:DropDownList ID="AnswerFilterDropdownlist" runat="server" AutoPostBack="True"></asp:DropDownList>
 </li><li>
                        <asp:Label ID="TextEvaluationConditionLabel" AssociatedControlID="ExpressionLogicDropdownlist" runat="server">Text evaluation condition :</asp:Label>
                        <asp:DropDownList ID="ExpressionLogicDropdownlist" runat="server"></asp:DropDownList>
 </li><li>
                        <asp:Label ID="FilterTextLabel" AssociatedControlID="TextFilterTextbox" runat="server">Text :</asp:Label>
                         <asp:TextBox ID="TextFilterTextbox" runat="server"></asp:TextBox>

 </li><li>
                        <asp:Label ID="ScoreLabel" AssociatedControlID="ScoreTextbox" runat="server">Score :&nbsp;</asp:Label>

                        <asp:TextBox ID="ScoreTextbox" runat="server" Columns="2"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ScoreTextbox"
                            ErrorMessage="No Valid Number" ValidationExpression="^-{0,1}\d+$"></asp:RegularExpressionValidator><br />
 </li><li>
                        <asp:Label ID="ScoreRangeLabel" AssociatedControlID="ScoreMaxTextbox" runat="server">and</asp:Label>&nbsp;
                   <asp:TextBox ID="ScoreMaxTextbox" runat="server" Columns="2"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ScoreMaxTextbox"
                            ErrorMessage="No Valid Number" ValidationExpression="^-{0,1}\d+$"></asp:RegularExpressionValidator>

    </li><li> 
                        <asp:Label ID="ConditionalMessageLabel" AssociatedControlID="" runat="server">Message shown on submit :</asp:Label>
   </li><li> 
                        <CKEditor:CKEditorControl ID="ConditionCKeditor" BasePath="~/Scripts/ckeditor" runat="server">
                        </CKEditor:CKEditorControl>
 </li><li>
                        <br />
                        <asp:Label ID="ScoreTagLabel" runat="server">Score total can be shown using the ::score:: tag inside your message</asp:Label>


  </li><li>
               
               <asp:button id="AddMessageConditionButton" CssClass="btn btn-primary btn-xs bw" runat="server" Text="Add new message condition" Enabled="False"></asp:button>
               <asp:button id="UpdateMessageConditionButton" CssClass="btn btn-primary btn-xs bw" runat="server" Text="Update message condition"></asp:button>
               <asp:Button id="ConditionCancelButton"  CssClass="btn btn-primary btn-xs bw" runat="server" Text="Cancel / Back"></asp:Button>

       <br />
                          </li>
  </ol>
                    <br />
                    </fieldset>
                                                 <div id="fillerDiv" class="fillerDiv">&nbsp;</div>
 </div></asp:Content>
