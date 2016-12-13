<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_MCT_Phong.ascx.cs" Inherits="UC_UC_MCT_Phong" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Reference Page="~/Default2.aspx" %>


<div class="col-md-6 col-sm-12 col-xs-12">
    <div class="x_panel">
        <div class="x_title">
            <h2>Phòng</h2>
            <ul class="nav navbar-right panel_toolbox"></ul>
            <div class="clearfix"></div>
        </div>
        <div class="x_content">
            <br />
            <div class="form-horizontal form-label-left">

                <div class="form-group" >
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">Tên phòng</label>
                    <div class="col-md-9 col-sm-9 col-xs-9">
                        <input id="tenphong" type="text" class="form-control" runat="server" clientidmode="Static" />
                        <span id="star" class="fa fa-star form-control-feedback right" aria-hidden="true"></span>
                        <input id="loaiphong" type="hidden" runat="server" clientidmode="Static" />
                        <input id="status" type="hidden" runat="server" clientidmode="Static" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">Tên khách hàng</label>
                    <div class="col-md-9 col-sm-9 col-xs-9">
                        <input id="tenkh" type="text" class="form-control" runat="server" clientidmode="Static" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">Số điện thoại</label>
                    <div class="col-md-9 col-sm-9 col-xs-9">
                        <input id="sdt" type="text" class="form-control" data-inputmask="'mask' : '0999 9999 999'" runat="server" clientidmode="Static" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">CMND</label>
                    <div class="col-md-9 col-sm-9 col-xs-9">
                        <input id="cmnd" type="text" class="form-control" data-inputmask="'mask': '999 999 999'" runat="server" clientidmode="Static" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">TG bắt đầu</label>
                    <div class="col-sm-9 col-xs-9 col-md-9 ">
                        <asp:TextBox ID="tgbatdau" class="form-control" type="datetime" runat="server" ClientIDMode="Static" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">Số giờ</label>
                    <div class="col-md-9 col-sm-9 col-xs-9">
                        <input id="sogio" type="text" class="form-control" data-inputmask="'mask' : '99'" runat="server" clientidmode="Static" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">Tiền phòng</label>
                    <div class="col-md-9 col-sm-9 col-xs-9">
                        <input id="tienphong" type="text" class="form-control" data-inputmask="'mask' : '9999999999999999'" runat="server" clientidmode="Static" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="col-md-6 col-sm-12 col-xs-12">
    <div class="x_panel">
        <div class="x_title">
            <h2>Phòng</h2>
            <ul class="nav navbar-right panel_toolbox"></ul>
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
                <div class="form-group" id="divtongtienhang">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3">Tiền đồ uống</label>
                    <div class="col-md-9 col-sm-9 col-xs-9">
                        <input type="text" class="form-control" id="tongtienhang" runat="server" clientidmode="Static" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="col-md-12">
    <div class="x_panel">
        <div class="x_content">
            
            <div class="form-group" id="divtongtienthanhtoan">
                <label class="control-label col-md-3 col-sm-3 col-xs-3">Tổng tiền thanh toán</label>
                <div class="col-md-9 col-sm-9 col-xs-9">
                    <input id="tongtienthanhtoan" type="text" class="form-control" data-inputmask="'mask' : '9999999999999999'" runat="server" clientidmode="Static" />
                </div>
            </div>
            <div class="ln_solid">
                
            </div>

            <div class="form-group">
                <div class="col-md-9 col-md-offset-3">
                    <asp:Button ID="btnbatdau" runat="server" Text="Bắt đầu" OnClick="btnBatDauClick" CssClass="btn btn-round btn-success" />
                    <asp:Button ID="btntinhtien" CssClass=" btn btn-round btn-success" runat="server" Text="Tính tiền" OnClick="btnTinhTienClick"></asp:Button>
                    <input ID="btnback" type="button" class=" btn btn-primary btn-round" value="Quay lai" />
                </div>
            </div>
        </div>
    </div>
</div>

