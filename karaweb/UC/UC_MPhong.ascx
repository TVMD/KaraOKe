<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_MPhong.ascx.cs" Inherits="UC_UC_MPhong" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Reference Page="~/Default2.aspx" %>

<div id="superDiv" class="" runat="server">
    <telerik:RadButton runat="server" ID="btn" Text="click" Width="200px" OnClick="btn_OnClick"></telerik:RadButton>
</div>


<script>
    $(document).ready(function () {
    });
</script>
