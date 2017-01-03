<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_MPhong.ascx.cs" Inherits="UC_UC_MPhong" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Reference Page="~/Default2.aspx" %>

<div id="superDiv" class="" runat="server">
    <telerik:RadButton runat="server" ID="m_btn" Text="click" Width="200px" OnClick="btn_OnClick" ClientIDMode="Static" CssClass="hidden"></telerik:RadButton>
    <input id ="idphong" runat="server" type="hidden" clientidmode="Static"/>
</div>
