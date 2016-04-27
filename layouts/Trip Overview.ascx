<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Trip_Overview.ascx.cs" Inherits="Training.layouts.Trip_Overview" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- THIS IS THE TRIP OVERVIEW SECTION -->
<div class="indentedSection">
	<table>
		<tr>
			<th>Date</th>
			<td><sc:Date runat="server" Field="start date" Format="dd MMM yyyy"/></td>
		</tr>
		<tr>
			<th>Price per  person</th>
			<td>&pound;<sc:text runat="server" Field="price per person" /> per person</td>
		</tr>					
	</table>
</div>			
<!-- END -->
