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
            <div id="div" runat="server" style="background: red;" onclick="itemclick">
                <p id="p">haha</p>
            </div>
            <div id="newwindow"></div>
            <asp:Button ID="Button1" Text="asp" runat="server" OnClick="btn_OnClick" OnClientClick="nWin();" />
        </div>
    </form>

    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <script>
        $(document).ready(function () {
        });

       <%-- $("#div").on("click", function () {
            var x = document.getElementById("<%=Button1.ClientID %>");
           x.click();
        });--%>

        function nWin() {
            //window.open("Default2.aspx", "hihi",500,500);
            OpenPopupCenter("testpage.aspx", "title", 300, 500);
        }
        function OpenPopupCenter(pageURL, title, w, h) {
            var left = (screen.width - w) / 2;
            var top = (screen.height - h) / 4;  // for 25% - devide by 4  |  for 33% - devide by 3
            var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }
    </script>

</body>
</html>
