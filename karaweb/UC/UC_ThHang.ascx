<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ThHang.ascx.cs" Inherits="UC_UC_ThHang" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Page="~/Default2.aspx" %>

<div>
    <div align="right">
        <telerik:RadTextBox ID="txtsearch" runat="server" Width="300px"
            OnTextChanged="txtsearch_OnTextChanged" AutoPostBack="True">
        </telerik:RadTextBox>
    </div>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="12" AutoGenerateColumns="False"
        OnNeedDataSource="RadGrid1_OnNeedDataSource"
        OnItemCreated="RadGrid1_OnItemCreated"
        OnItemDataBound="RadGrid1_OnItemDataBound"
        OnInsertCommand="RadGrid1_OnInsertCommand"
        OnUpdateCommand="RadGrid1_OnUpdateCommand"
        OnDeleteCommand="RadGrid1_OnDeleteCommand">
        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="TopAndBottom">
            <CommandItemSettings AddNewRecordText="Thêm hàng"
                RefreshText="Làm mới" />
            <Columns>

                <telerik:GridTemplateColumn HeaderText="STT">
                    <ItemTemplate>
                        <%# Container.DataSetIndex + 1 %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="IDHang" HeaderText="Mã hàng"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <asp:Label ID="LayoutTypeIDLabel" runat="server"
                        Text='<%#DataBinder.Eval(Container.DataItem, "ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox runat="server" Enabled="False" ID="txtidhang" EmptyMessage="Tự động thêm">
                        </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

               <%-- <telerik:GridDateTimeColumn DataField="NgayLap" DataType="System.DateTime" DataFormatString="{dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
                HeaderText="Ngày lập" SortExpression="ShippedDate"
                UniqueName="ShippedDate"> 
                <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                    <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                </ColumnValidationSettings>
            </telerik:GridDateTimeColumn>--%>

               
                <telerik:GridBoundColumn UniqueName="Ten" DataField="Ten" HeaderText="Tên hàng"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="DonGiaNhap" HeaderText="Đơn giá nhập">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "DonGiaNhap") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadNumericTextBox ID="txtdongianhap" runat="server" MinValue="0">
                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtdongianhap" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="DonGiaBan" HeaderText="Đơn giá bán">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "DonGiaBan") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadNumericTextBox ID="txtdongiaban" runat="server" MinValue="0">
                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtdongiaban" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn UniqueName="DonVi" DataField="DonVi" HeaderText="Đơn vị"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                
                
                <telerik:GridEditCommandColumn CancelText="Hủy"  EditText="Sửa" />

                <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                    ConfirmText="Xóa phiếu chi ?" ConfirmDialogType="Classic">
                </telerik:GridButtonColumn>

            </Columns>
            <EditFormSettings>
                <EditColumn UniqueName="EditCommandColumn" CancelText="Hủy" UpdateText="Lưu " 
                    InsertText="Thêm ">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</div>
