﻿<%@ Page Language="c#" MasterPageFile="~/nsurveyadmin/MsterPageTabs.master" AutoEventWireup="false"
    Inherits="Votations.NSurvey.WebAdmin.HelpFiles" CodeBehind="../default.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><div id="helpPanel"><div>
                <asp:ImageButton ID="btnBack" ImageUrl="~/Images/index-icon.png" runat="server" CssClass="buttonIndex"
                    PostBackUrl="~/NSurveyAdmin/Help/default.aspx#Reporting" Visible="True" ToolTip="Back to Helpfiles Index" />
            </div><div>
                <h2 style="color:#5720C6;">
                    Report Filter Creation</h2><hr style="color:#e2e2e2;" />
                <br />

Report filters are used to setup a set of rules based on the
survey's questions and answers. Once a filter is created and
rules are added to it, it can be assigned to a report or a chart. Once a filter as been applied all results
calculation will be done accordingly to the filter that has been set up.<br />
<br />
* <i>Filter Name</i> - is the name of the filter that will contain the rules.<br />
<br />
* <i>Conditional Rule Operator</i> - is the operator that Survey will use to
  evaluate the rules inside the filter. At this time only a single
  conditional operator (AND, OR) can be applied to a group of rules
  inside a filter.<hr style="color:#e2e2e2;" /> <br /><h3>More Information</h3>
                <br />
ED_Introduction.html<br />
Survey%20Mailing.html<br />
                <br />
            </div>
<div id="fillerDiv" class="fillerDiv">&nbsp;</div></div></asp:Content>

