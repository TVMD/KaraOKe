<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpage.aspx.cs" Inherits="testpage" EnableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title>Gentellela Alela! | </title>

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet" />
    <!-- bootstrap-daterangepicker -->
    <link href="vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" />
    <!-- Ion.RangeSlider -->
    <link href="vendors/normalize-css/normalize.css" rel="stylesheet" />
    <link href="vendors/ion.rangeSlider/css/ion.rangeSlider.css" rel="stylesheet" />
    <link href="vendors/ion.rangeSlider/css/ion.rangeSlider.skinFlat.css" rel="stylesheet" />
    <!-- Bootstrap Colorpicker -->
    <link href="vendors/mjolnic-bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css" rel="stylesheet" />

    <link href="vendors/cropper/dist/cropper.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <div class=" body">
            <div class="main_container">
                <!-- page content -->
                <div class="right_col" role="main">
                    <div class="">
                        <div class="page-title">
                            <div class="title_left">
                                <h3>Thông tin phòng</h3>
                            </div>
                        </div>

                        <div class="clearfix"></div>

                        <div class="row">
                            <!-- phong -->
                            <div class="col-md-6 col-sm-12 col-xs-12">
                                <div class="x_panel">
                                    <div class="x_title">
                                        <h2>Phòng</h2>
                                        <ul class="nav navbar-right panel_toolbox">
                                            <%-- <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                            </li>
                                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                                            </li>--%>
                                        </ul>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="x_content">
                                        <br />
                                        <div class="form-horizontal form-label-left">

                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">Tên phòng</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input id="tenphong" type="text" class="form-control" runat="server" />
                                                    <span id="star" class="fa fa-star form-control-feedback right" aria-hidden="true"></span>
                                                    <input id="loaiphong" type="hidden" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">Tên khách hàng</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input id="tenkh" type="text" class="form-control" runat="server" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">Số điện thoại</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input id="sdt" type="text" class="form-control" data-inputmask="'mask' : '0999 9999 999'" runat="server" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">CMND</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input id="cmnd" type="text" class="form-control" data-inputmask="'mask': '999 999 999'">
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">TG bắt đầu</label>
                                                <div class="col-sm-9 col-xs-9 col-md-9 ">
                                                    <!--    -->
                                                    <input id="ngaybatdau" class="form-control" type="date" />
                                                    <input id="giobatdau" class="form-control" t1ype="time" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">Số giờ</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input id="sogio" type="text" class="form-control" data-inputmask="'mask' : '99'" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">Tiền phòng</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input id="tienphong" type="text" class="form-control" data-inputmask="'mask' : '9999999999999999'" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">Credit Card Mask</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input type="text" class="form-control" data-inputmask="'mask' : '9999-9999-9999-9999'">
                                                    <span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
                                                </div>
                                            </div>
                                            <div class="ln_solid"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /phong -->

                            <!-- do uong -->
                            <div class="col-md-6 col-sm-12 col-xs-12">
                                <div class="x_panel">
                                    <div class="x_title">
                                        <h2>Thức Uống</h2>
                                        <ul class="nav navbar-right panel_toolbox">
                                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                            </li>
                                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                                            </li>
                                        </ul>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="x_content">
                                        <br />
                                        <div class="form-horizontal form-label-left">
                                            <telerik:RadGrid ID="RadGrid1" runat="server" ShowStatusBar="True" AutoGenerateColumns="False"
                                                OnNeedDataSource="RadGrid1_OnNeedDataSource">
                                                <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="Bottom">
                                                    <CommandItemSettings AddNewRecordText="Thêm nước"
                                                        RefreshText="Làm mới" />
                                                    <Columns>

                                                        <telerik:GridTemplateColumn HeaderText="STT">
                                                            <ItemTemplate>
                                                                <%# Container.DataSetIndex + 1 %>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn UniqueName="TenHang" HeaderText="Tên">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "ID_Hang") %>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadComboBox runat="server" ID="cbboxHang" Width="300px"
                                                                    EmptyMessage="--- Chọn nước ---">
                                                                </telerik:RadComboBox>
                                                                <asp:RequiredFieldValidator ID="kk" runat="server" ControlToValidate="cbboxHang">
                                                                </asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn UniqueName="SoLuong" DataField="SoLuong" HeaderText="Số lượng">
                                                            <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                                                <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                                                            </ColumnValidationSettings>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="DonGia" DataField="DonGia" HeaderText="Đơn giá">
                                                            <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                                                <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                                                            </ColumnValidationSettings>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="ThanhTien" DataField="ThanhTien" HeaderText="Thành tiền">
                                                            <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                                                <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                                                            </ColumnValidationSettings>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                                                        <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                                                            ConfirmText="Xóa dòng này ?" ConfirmDialogType="RadWindow">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn UniqueName="EditCommandColumn" CancelText="Hủy" UpdateText="Lưu thay đổi"
                                                            InsertText="Thêm">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                            <div class="ln_solid"></div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3 col-sm-3 col-xs-3">Tổng tiền đồ uống</label>
                                                <div class="col-md-9 col-sm-9 col-xs-9">
                                                    <input type="text" class="form-control" id="tongtienhang" runat="server" clientidmode="Static" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /phong -->

                            <!-- total -->
                            <div class="col-md-12">
                                <div class="x_panel">
                                    <div class="x_content">
                                        <div class="form-group">
                                            <div class="col-md-9 col-md-offset-3">
                                                <button type="submit" class="btn btn-primary">Bắt đầu</button>
                                                <button  type="submit" class="btn btn-success">Tính tiền</button>
                                                <asp:Button runat="server" Text="btnnek" OnClick="Btnnekonclick" CausesValidation="false"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /total -->
                        </div>

                    </div>
                </div>
                <!-- /page content -->
            </div>
        </div>
    </form>
    <!-- jQuery -->
    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="vendors/nprogress/nprogress.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="vendors/moment/min/moment.min.js"></script>
    <script src="vendors/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!-- Ion.RangeSlider -->
    <script src="vendors/ion.rangeSlider/js/ion.rangeSlider.min.js"></script>
    <!-- Bootstrap Colorpicker -->
    <script src="vendors/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
    <!-- jquery.inputmask -->
    <script src="vendors/jquery.inputmask/dist/min/jquery.inputmask.bundle.min.js"></script>
    <!-- jQuery Knob -->
    <script src="vendors/jquery-knob/dist/jquery.knob.min.js"></script>
    <!-- Cropper -->
    <script src="vendors/cropper/dist/cropper.min.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>


    <script src="Scripts/jquery-ui-1.12.1/jquery-ui.min.js"></script>

    <!-- jquery.inputmask -->
    <script>
        $(document).ready(function () {
            $(":input").inputmask();
            $("#tenkh").prop("disabled", true);
            //$("#star").remove(); // if not vip then remove
        });
        $("#btnbatdau").on("click", function () {
            $("#tenkh").val("100.");
        });
    </script>
    <!-- /jquery.inputmask -->

</body>
</html>
