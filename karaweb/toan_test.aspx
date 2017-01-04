<%@ Page Language="C#" AutoEventWireup="true" CodeFile="toan_test.aspx.cs" Inherits="toan_test" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" OnLoad="CrystalReportViewer1_Init"  />

    </form>
</body>
</html>
