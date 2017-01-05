<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_MLoaiPhong.ascx.cs" Inherits="UC_UC_MLoaiPhong" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Page="~/Default2.aspx" %>

<div>
    <div align="right">
         <label>Tìm kiếm</label>
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
        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="TopAndBottom" DataKeyNames="ID">
            <CommandItemSettings AddNewRecordText="Thêm phòng"
                RefreshText="Làm mới" />
            <Columns>
                
                <telerik:GridBoundColumn UniqueName="ID" DataField="ID" Visible="False" ReadOnly="true" >
                            </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn HeaderText="STT">
                    <ItemTemplate>
                        <%# Container.DataSetIndex + 1 %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="IDLoaiPhong" HeaderText="Mã loại phòng"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "ID") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox runat="server" Enabled="False" ID="txtidphong" EmptyMessage="Tự động thêm">
                        </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn UniqueName="TenLoaiPhong" DataField="Ten" HeaderText="Tên loại phòng"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="GiaNgay" HeaderText="Giá ngày">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "GiaNgay") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadNumericTextBox ID="txtgiangay" runat="server" MinValue="1">
                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtgiangay" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn UniqueName="GiaDem" HeaderText="Giá đêm ">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "GiaDem") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadNumericTextBox ID="txtgiadem" runat="server" MinValue="1">
                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtgiadem" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                                    ConfirmText="Xóa dòng này?" ConfirmDialogType="RadWindow">
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
