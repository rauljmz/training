<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TripPromotion.ascx.cs" Inherits="Training.layouts.TripPromotion" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="indentedSection widget fill <%=CssClass %>">
	<div class="indentedSectionInner">
		<h2><sc:Text runat="server" Field="heading" /></h2> <!-- Heading field -->
		<sc:Image runat="server" Field="main image" />
        <sc:Text runat="server" Field="main content" />
	</div>
</div>