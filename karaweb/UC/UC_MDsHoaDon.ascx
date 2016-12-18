<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_MDsHoaDon.ascx.cs" Inherits="UC_UC_MDsHoaDon" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Page="~/Default2.aspx" %>

<div>
    <div align="right">
        <telerik:RadTextBox ID="txtsearch" runat="server" Width="300px"
            OnTextChanged="txtsearch_OnTextChanged" AutoPostBack="True">
        </telerik:RadTextBox>
    </div>
    <br />
    <div class="col-md-6 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>Hóa đơn dịch vụ</h2>
                <ul class="nav navbar-right panel_toolbox"></ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <br />
                <div class="form-horizontal form-label-left">
                    <telerik:RadGrid ID="RadGrid1" runat="server" ShowStatusBar="True" AutoGenerateColumns="False"
                        OnNeedDataSource="RadGrid1_OnNeedDataSource"
                        OnItemCreated="RadGrid1_OnItemCreated"
                        OnItemDataBound="RadGrid1_OnItemDataBound"
                        OnInsertCommand="RadGrid1_OnInsertCommand"
                        OnUpdateCommand="RadGrid1_OnUpdateCommand"
                        OnDeleteCommand="RadGrid1_OnDeleteCommand">
                        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="None">
                            <CommandItemSettings AddNewRecordText="Thêm nước"
                                RefreshText="Làm mới" />
                            <Columns>

                                <telerik:GridTemplateColumn HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataSetIndex + 1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="ID_HoaDon" HeaderText="Mã hóa đơn"
                                    >
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "ID") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadTextBox runat="server" Enabled="False" ID="txtidhoadon" EmptyMessage="Tự động thêm">
                                        </telerik:RadTextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn  UniqueName="ID_Phong" HeaderText="Phòng">
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "TenPhong") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadComboBox runat="server" ID="cbboxphong" Width="300px" 
                                            EmptyMessage="--- Chọn phòng ---">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="cbboxphong" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                                        </asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                
                                <telerik:GridBoundColumn UniqueName="TenKH" DataField="TenKH" HeaderText="Tên khách" >
                                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn UniqueName="TongTien" DataField="TongTien" HeaderText="Tổng tiền" ReadOnly="True">
                                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>

                                <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                                <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                                    ConfirmText="Xóa dòng này?" ConfirmDialogType="RadWindow">
                                </telerik:GridButtonColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn UniqueName="EditCommandColumn" CancelText="Hủy" UpdateText="Lưu "
                                    InsertText="Thêm">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                    </telerik:RadGrid>
                    </div>
                </div>
            </div>
    </div>

    <div class="col-md-6 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>Chi tiết hóa đơn</h2>
                <ul class="nav navbar-right panel_toolbox"></ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <br />
                <div class="form-horizontal form-label-left">
                    <telerik:RadGrid ID="RadGrid2" runat="server" ShowStatusBar="True" AutoGenerateColumns="False"
                        OnNeedDataSource="RadGrid2_OnNeedDataSource"
                        OnItemCreated="RadGrid2_OnItemCreated"
                        OnItemDataBound="RadGrid2_OnItemDataBound"
                        OnInsertCommand="RadGrid2_OnInsertCommand"
                        OnUpdateCommand="RadGrid2_OnUpdateCommand"
                        OnDeleteCommand="RadGrid2_OnDeleteCommand">
                        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="None">
                            <CommandItemSettings AddNewRecordText="Thêm nước"
                                RefreshText="Làm mới" />
                            <Columns>

                                <telerik:GridTemplateColumn HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataSetIndex + 1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn ColumnEditorID="hihi" UniqueName="TenHang" HeaderText="Tên">
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "TenHang") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadComboBox runat="server" ID="cbboxHang" Width="300px" ClientIDMode="Static"
                                            EmptyMessage="--- Chọn nước ---">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="cbboxHang" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                                        </asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="SoLuong" HeaderText="Số lượng">
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "SoLuong") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadNumericTextBox ID="txtsoluong" runat="server" MinValue="1">
                                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtsoluong" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                                        </asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridBoundColumn UniqueName="DonGia" DataField="DonGia" HeaderText="Đơn giá" ReadOnly="true">
                                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="ThanhTien" DataField="ThanhTien" HeaderText="Thành tiền" ReadOnly="True">
                                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>

                                <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                                <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                                    ConfirmText="Xóa dòng này?" ConfirmDialogType="RadWindow">
                                </telerik:GridButtonColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn UniqueName="EditCommandColumn" CancelText="Hủy" UpdateText="Lưu thay đổi"
                                    InsertText="Thêm">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
    </div>
</div>
