<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Đăng nhập - Karaoke iSing</title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">

  </head>

  <body class="login">
    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
              <form id="form1" runat="server">
              <h1>Đăng nhập</h1>
              <div>
                <asp:TextBox id="txtUser" type="text" class="form-control" placeholder="Tên đăng nhập" required="" runat="server" 
                    onkeydown = "if (event.keyCode == 13) document.getElementById('LoginButton').click()"/>
              </div>
              <div>
                <asp:TextBox id="txtPassword" type="password" class="form-control" placeholder="Mật khẩu" required="" runat="server" 
                    onkeydown = "if (event.keyCode == 13) document.getElementById('LoginButton').click()"/>
              </div>
              <div>
                <asp:LinkButton ID="LoginButton" class="btn btn-default submit" runat="server" OnClick="onClickLogin">Đăng nhập</asp:LinkButton>
              </div>

               <div class="clearfix"></div>
                
              <div class="clearfix">
                  <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
                  </div>

              <div class="separator">
                

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="fa fa-paw"></i> Karaoke iSing </h1>
                  <p>©2016 A shool project of team 3TM - University of Information Technology</p>
                </div>
              </div>
              </form>
          </section>
        </div>        
      </div>
    </div>
      <script src="Scripts/toandeptrai.js"></script>
  </body>
</html>

