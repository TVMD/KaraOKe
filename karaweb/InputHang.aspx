<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputHang.aspx.cs" Inherits="InputHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Tên hàng:&nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="txtTenHang" runat="server"></asp:TextBox>
    </div>
      <div style="margin-top:10px;margin-bottom=10px">
             Đơn vị:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      
    <asp:TextBox ID="txtDonVi" runat="server"></asp:TextBox>
    </div>  
    <div>
                 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
    <asp:Button ID="btnThem" OnClick="btnThem_Click" runat="server" Text="Thêm hàng"></asp:Button>
    </div> 
    </form>
</body>
</html>
