﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_NhapHang.ascx.cs" Inherits="UC_UC_NhapHang" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Page="../Default2.aspx" %>


<div>
    <div align="right">
         <label>Tìm kiếm</label>
        <telerik:RadTextBox ID="txtsearch" runat="server" Width="300px"
            OnTextChanged="txtsearch_OnTextChanged" AutoPostBack="True">
        </telerik:RadTextBox>
    </div>
    <br />
<%--    <div style="float:left;margin-left:50px">
        <b>Danh sách phiếu nhập</b>
    </div>
    <div style="float:right;margin-left:300px">
        <b>Chi tiết phiếu nhập</b>
    </div>--%>

    <div style="float:left;margin-left:0px;text-align:center;margin-top:10px">
        <b >Danh sách phiếu nhập</b>
        <telerik:RadGrid ID="RadGrid1" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="10" AutoGenerateColumns="False" Width="300"
            OnNeedDataSource="RadGrid1_OnNeedDataSource"
            OnItemCreated="RadGrid1_OnItemCreated"
            OnItemDataBound="RadGrid1_OnItemDataBound"
            OnInsertCommand="RadGrid1_OnInsertCommand"
            OnUpdateCommand="RadGrid1_OnUpdateCommand"
            OnDeleteCommand="RadGrid1_OnDeleteCommand"
            OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged1">
            <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="Top" ItemStyle-HorizontalAlign="Left">
                <CommandItemSettings AddNewRecordText="Thêm phiếu nhập"
                    RefreshText="Làm mới" />
                <Columns>

                    <telerik:GridTemplateColumn HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataSetIndex + 1 %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="ID" DataField="ID" HeaderText="ID" ReadOnly="true"
                        HeaderStyle-Width="50px">
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                            <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridDateTimeColumn DataField="NgayNhap" DataType="System.DateTime" ColumnEditorID="dtNgayNhap" 
                                            DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy" 
                                            HeaderText="Ngày Nhập" SortExpression="ShippedDate" HeaderStyle-Width="120px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>

                    <telerik:GridBoundColumn UniqueName="TongTien" DataField="TongTien" HeaderText="Tổng tiền" ReadOnly="true"
                        HeaderStyle-Width="100px">
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                            <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>

                    <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                    <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                        ConfirmText="Phiếu nhập này có thể đã có chi tiết kèm theo, bạn có muốn xóa?" ConfirmDialogType="RadWindow">
                    </telerik:GridButtonColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn UniqueName="EditCommandColumn" CancelText="Hủy" UpdateText="Lưu thay đổi"
                        InsertText="Thêm">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true">
</ClientSettings>
        </telerik:RadGrid>
    </div>

   <div style="float:left;margin-left:20px;text-align:center;margin-top:10px" >
       <b >Chi tiết phiếu nhập</b>
        <telerik:RadGrid ID="RadGrid2" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="10" 
            AutoGenerateColumns="False" Width="700px" 
            
            OnNeedDataSource="RadGrid2_OnNeedDataSource"
            OnItemCreated="RadGrid2_OnItemCreated"
            OnItemDataBound="RadGrid2_OnItemDataBound"
            OnInsertCommand="RadGrid2_OnInsertCommand"
            OnUpdateCommand="RadGrid2_OnUpdateCommand"
            OnDeleteCommand="RadGrid2_OnDeleteCommand"
            OnSelectedIndexChanged="RadGrid2_SelectedIndexChanged"
            OnPreRender="RadGrid2_PreRender">
            <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="Top" Width="100%" DataKeyNames="IDHang"
                ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left" CommandItemStyle-HorizontalAlign="Left">
                <CommandItemSettings AddNewRecordText="Thêm chi tiết phiếu nhập"
                    RefreshText="Làm mới" />
                <Columns>

                    <telerik:GridTemplateColumn HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataSetIndex + 1 %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="IDHang" DataField="IDHang" HeaderText="IDHang" ReadOnly="true"
                        HeaderStyle-Width="70px" >
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                            <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="Hang" HeaderText="Loại Hàng"  HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "TenHang") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="cbHang" Width="150px" 
                            EmptyMessage="--- Lựa chọn loại hàng---" >
                        </telerik:RadComboBox>
                        <asp:Button Text="Thêm mới hàng" OnClick="Unnamed_Click" ID="btnThemHang" runat="server" />
                        <asp:RequiredFieldValidator ID="cbHangk" runat="server" ControlToValidate="cbHang"
                            ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                    
                    <telerik:GridNumericColumn UniqueName="SoLuong" DataField="SoLuong" HeaderText="Số Lượng"
                        HeaderStyle-Width="120px">
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                            <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                        </ColumnValidationSettings>
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn UniqueName="DonGiaNhap" DataField="DonGiaNhap" HeaderText="Đơn Giá Nhập"
                        HeaderStyle-Width="120px">
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                            <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                        </ColumnValidationSettings>
                    </telerik:GridNumericColumn>
                    <telerik:GridBoundColumn UniqueName="ThanhTien" DataField="ThanhTien" HeaderText="Thành Tiền" ReadOnly="true"
                        HeaderStyle-Width="120px">
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                            <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                        </ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    

                    <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                    <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                        ConfirmText="Xóa chi tiết phiếu nhập này?" ConfirmDialogType="RadWindow">
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
