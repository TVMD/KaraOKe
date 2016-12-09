<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý quán karaoke</title>
    <link href="Contents/UC_regular.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <div>
            <div class="Title">chứa tiêu đề đồ</div>
            <div id="Menu" class="Menu">
                <div>day la mennu</div>
                <button>lueleu</button>
            </div>
            <div class="Content">
                <%--<asp:Panel ID="Panel1" runat="server" BorderWidth="2px"></asp:Panel>--%>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <div style="margin-top: 4%">
                        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    </div>
                </telerik:RadAjaxPanel>

                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30" MinDisplayTime="0">
                </telerik:RadAjaxLoadingPanel>
                
            </div>
        </div>
        <script src="Scripts/jquery-3.1.1.min.js"></script>
        <script src="Contents/main.js"></script>
    </form>
</body>
</html>
