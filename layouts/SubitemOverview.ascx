<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubitemOverview.ascx.cs" Inherits="Training.layouts.SubitemOverview" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="Sitecore.Links" %>
<asp:Repeater runat="server" ItemType="Sitecore.Data.Items.Item" SelectMethod="GetData">
    <HeaderTemplate>
        <div class="indentedSection">
            <ul class="bikes">
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="<%#: LinkManager.GetItemUrl(Item) %>"><%#:Item.Name %></a></li>

    </ItemTemplate>
    <FooterTemplate>
        </ul>
</div>
    </FooterTemplate>
</asp:Repeater>

