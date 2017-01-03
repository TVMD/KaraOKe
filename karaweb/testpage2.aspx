<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpage2.aspx.cs" Inherits="testpage2" %>

<%@ Reference Page="~/Default2.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="div" runat="server" style="background: red;">
                <p id="p">haha</p>
            </div>
            <div id="newwindow"></div>
            <asp:Button ID="Button1" Text="asp" runat="server" OnClick="btn_OnClick"  />
            <input id="text" type="hidden" runat="server"/>
        </div>
    </form>

    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <script src="Scripts/supersaiyan.js"></script>
    <script>
        $(document).ready(function () {
        });

       <%-- $("#div").on("click", function () {
            var x = document.getElementById("<%=Button1.ClientID %>");
           x.click();
        });--%>
        
        $("#div").on("click", function() {
            $("#text").val("hihi_clicked");
            var x = document.getElementById("<%=Button1.ClientID %>");
            x.click();
        });
        function nWin() {
            OpenPopupCenter("testpage.aspx", "title", 300, 500);
        }
      
    </script>

</body>
</html>
