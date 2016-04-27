<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Introduction.ascx.cs" Inherits="Training.layouts.Introduction" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="indentedSection content">
    <!-- HEADING -->
    <h1>
        <sc:Text runat="server" Field="heading" />
    </h1>
    <!-- MAIN IMAGE -->
    <sc:Image runat="server" Field="main image" CssClass="right" MaxWidth="120"/>
    <!-- MAIN CONTENT -->
    <sc:Text runat="server" Field="main content" />
</div>
