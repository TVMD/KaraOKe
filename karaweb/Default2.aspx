<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>KARAOKE MANAGEMENT</title>

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">

    <!-- dialog -->
    <link href="Scripts/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />

</head>

<body class="nav-md">
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <div class="container body">
            <div class="main_container">
                <div class="col-md-3 left_col">
                    <div class="left_col scroll-view">
                        <div class="navbar nav_title" style="border: 0;">
                            <a href="Default2.aspx" class="site_title"><i class="fa fa-glass"></i><span>KaraOke</span></a>
                        </div>

                        <div class="clearfix"></div>

                        <!-- menu profile quick info -->
                        <div class="profile">
                            <div class="profile_pic">
                                <img src="Image/thegirl.jpg" alt="..." class="img-circle profile_img">
                            </div>
                            <div class="profile_info">
                                <span>Xin chào</span>
                                <asp:placeholder runat="server"><h2><%= user.MaDangNhap %></h2></asp:placeholder>
                                
                            </div>
                        </div>
                        <!-- /menu profile quick info -->

                        <br />

                        <!-- sidebar menu -->
                        <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
                            <div class="menu_section">
                                <h3>_</h3>
                                <ul class="nav side-menu">
                                    <li><a href="Default2.aspx"><i class="fa fa-home"></i>Trang chủ </a>
                                    </li>
                                    <li class="mbeauty"><a><i class="fa fa-edit"></i>Quản lý phòng <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                            <li><a id="phong" class="uc">Đặt phòng cho khách </a></li>
                                            <li class="menuadmin" ><a id="dsphong" class="uc">Danh sách phòng </a></li>
                                            <li class="menuadmin"><a id="loaiphong" class="uc">Danh sách loại phòng </a></li>
                                        </ul>
                                    </li>
                                    <li class="mbeauty"><a><i class="fa fa-table "></i>Hóa đơn <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                            <li><a id="hoadondv" class="uc">Hóa đơn dịch vụ</a></li>
                                            <li><a id="_nhaphang" class="uc">Nhập hàng</a></li>
                                            <li><a id="_phieuchi" class="uc">Phiếu chi</a></li>
                                        </ul>
                                    </li>

                                    <li class="mbeauty"><a><i class="fa fa-bar-chart-o "></i>Báo cáo <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                            <li><a id="_bttonkho" class="uc">Báo cáo tồn kho</a></li>
                                            <li><a id="_bcdoanhthu" class="uc">Báo cáo doanh thu</a></li>
                                        </ul>
                                    </li>
                                    <li class="mbeauty"><a><i class="fa fa-cog "></i>Cài đặt <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                            <li class="menuadmin"><a id="thamso" class="uc">Tham số</a></li>
                                            <li class="menuadmin"><a id="_user" class="uc">Nguời dùng</a></li>
                                            <li class="menuadmin"><a id="_hang" class="uc">Danh sách hàng</a></li>
                                        </ul>
                                    </li>
                                </ul>
                            </div>

                        </div>
                        <!-- /sidebar menu -->

                        <!-- /menu footer buttons -->
                        <div class="sidebar-footer hidden-small">
                            <a data-toggle="tooltip" data-placement="top">
                                <span class="glyphicon " aria-hidden="true"></span>
                            </a>
                            <a data-toggle="tooltip" data-placement="top">
                                <span class="glyphicon " aria-hidden="true"></span>
                            </a>
                            <a  data-toggle="tooltip" data-placement="top" title="Toàn màn hình">
                                <span id = "fullscreen" class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
                            </a>
                            <asp:LinkButton runat="server" OnClick="onClickLogout" data-toggle="tooltip" data-placement="top" title="Đăng xuất" class="uc dangxuat">
                                <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
                            </asp:LinkButton>
                        </div>
                        <!-- /menu footer buttons -->
                    </div>
                </div>

                <!-- top navigation -->
                <div class="top_nav">
                    <div class="nav_menu">
                        <nav>
                            <div class="nav toggle">
                                <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                            </div>

                            <ul class="nav navbar-nav navbar-right">
                                <li class="">
                                    <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                        <img src="Image/thegirl.jpg" alt=""><asp:placeholder runat="server"><%= user.MaDangNhap %></asp:placeholder> <span class=" fa fa-angle-down"></span>
                                    </a>
                                    <ul class="dropdown-menu dropdown-usermenu pull-right">
                                        <li><asp:LinkButton runat="server" OnClick="onClickLogout" class="uc dangxuat"><i class="fa fa-sign-out pull-right"></i>Đăng xuất</asp:LinkButton></li>
                                    </ul>
                                </li>

                                <li role="presentation" class="dropdown">
                                    <a href="javascript:;" class="dropdown-toggle info-number" data-toggle="dropdown" aria-expanded="false">
                                        <i class="fa fa-envelope-o"></i>
                                        <span id="countwarning" class="badge bg-green"></span>
                                    </a>
                                    <ul id="menuwarning" class="dropdown-menu list-unstyled msg_list" role="menu">
                                         <!-- warning in heree-->
                                    </ul>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
                <!-- /top navigation -->

                <!-- page content -->
                <div class="right_col" role="main">
                    <div class="">
                        <div class="clearfix"></div>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="x_panel">
                                    <div class="x_title">
                                        <h2 runat="server" id="UC_Title">User Control title</h2>
                                        <ul class="nav navbar-right panel_toolbox">
                                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                            </li>
                                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                                            </li>
                                        </ul>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="x_content">
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                            <input type="text" name="sapname" id="sapname" style="display: none" />
                                            <input type="submit" value="Submit" id="sapbutton" style="display: none" />
                                            
                                            <div style="margin-top: 4%">
                                                <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                                            </div>
                                        </telerik:RadAjaxPanel>

                                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30" MinDisplayTime="0">
                                        </telerik:RadAjaxLoadingPanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /page content -->

                <!-- footer content -->
                <footer>
                    <div class="pull-right">
                        #TM
                    </div>
                    <div class="clearfix"></div>
                </footer>
                <!-- /footer content -->
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
            </div>
        </div>
        <!-- jQuery -->
        <script src="vendors/jquery/dist/jquery.js"></script>
        <script src="vendors/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap -->
        <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
        <!-- FastClick -->
        <script src="vendors/fastclick/lib/fastclick.js"></script>
        <!-- NProgress -->
        <script src="vendors/nprogress/nprogress.js"></script>

        <!-- Custom Theme Scripts -->
        <script src="build/js/custom.min.js"></script>

        <!-- Scripts cua tao-->
        <script src="Scripts/jquery-ui-1.12.1/jquery-ui.js"></script>
        <script src="Scripts/moment.js"></script>
        <script src="vendors/jquery.inputmask/dist/min/jquery.inputmask.bundle.min.js"></script>
        <script src="Scripts/supersaiyan.js?v=33"></script>
        <!-- Scripts cua imVutoan-->
        <script src="Scripts/toandeptrai.js"></script>

    </form>
</body>
</html>
