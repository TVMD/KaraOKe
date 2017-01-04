<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RP_BCDoanhThu.aspx.cs" Inherits="Report_RP_BCDoanhThu" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">     
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />   
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
    </form>
</body>
</html>
