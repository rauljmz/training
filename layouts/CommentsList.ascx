<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsList.ascx.cs" Inherits="Training.layouts.CommentsList" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rpComments" ItemType="Training.code.model.Comment" runat="server" SelectMethod="rpComments_GetData">
    <HeaderTemplate>
        <div class="indentedSection">
	        <h3>Comments</h3>
    </HeaderTemplate>
    <ItemTemplate>
		<p><strong><%#:Item.Author.Render %></strong></p>
		<p><%#Item.CommentText.Render %></p>
		<p><%#Item.Link.Render %></p>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>

