<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BicycleOverview.ascx.cs" Inherits="Training.layouts.BicycleOverview" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="indentedSection">
	<table class="bikes">
		<tr>
			<th>Type</th>
			<td><sc:Text runat="server" Field="type" /></td>
		</tr>
		<tr>
			<th>Suitability</th>
			<td><sc:text runat="server" Field="suitability" /></td>
		</tr>					
	</table>	
</div> 
