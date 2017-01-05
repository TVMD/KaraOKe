<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ToNguoiDung.ascx.cs" Inherits="UC_UC_ToNguoiDung" %>
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
        OnDeleteCommand="RadGrid1_OnDeleteCommand"
        OnPreRender="RadGrid1_PreRender">
        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="TopAndBottom">
            <CommandItemSettings AddNewRecordText="Thêm người dùng"
                RefreshText="Làm mới" />
            <Columns>

                <telerik:GridTemplateColumn HeaderText="STT">
                    <ItemTemplate>
                        <%# Container.DataSetIndex + 1 %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>                

                <telerik:GridTemplateColumn UniqueName="ID" DataField="ID"
                    HeaderStyle-Width="600px">   
                    <ItemTemplate>
                        <asp:Label runat="server" id="id_nguoidung_item" Text='<%#DataBinder.Eval(Container.DataItem, "ID") %>'></asp:Label>          
                    </ItemTemplate>   
                    <EditItemTemplate>
                       <telerik:RadTextBox runat="server" Visible="false" ID ="id_nguoidung">                           
                       </telerik:RadTextBox>
                    </EditItemTemplate>              
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn UniqueName="MaDangNhap" DataField="MaDangNhap" HeaderText="Tên đăng nhập"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="MatKhau" HeaderText="Mật khẩu"
                    HeaderStyle-Width="600px">
                    <EditItemTemplate>
                       <telerik:RadTextBox runat="server" ID ="txtmatkhau">                           
                       </telerik:RadTextBox>
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtmatkhau"></asp:RequiredFieldValidator>
                    </ColumnValidationSettings>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

              <%--  <telerik:GridBoundColumn UniqueName="Hoten" DataField="HoTen" HeaderText="Họ Tên"
                    HeaderStyle-Width="600px">                    
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn UniqueName="Email" DataField="Email" HeaderText="Email"
                    HeaderStyle-Width="600px">                    
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn UniqueName="SoDT" DataField="SoDT" HeaderText="Số điện thoại"
                    HeaderStyle-Width="600px">                    
                </telerik:GridBoundColumn>--%>

               <telerik:GridTemplateColumn UniqueName="MaNhomQuyen" HeaderText="Tên quyền"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "TenNhomQuyen") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="cbboxnhomquyen" Width="300px"
                            EmptyMessage="--- Chọn quyền ---">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="kk" runat="server" ControlToValidate="cbboxnhomquyen"
                            ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                    ConfirmText="Xóa Người dùng này?" ConfirmDialogType="RadWindow">
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


