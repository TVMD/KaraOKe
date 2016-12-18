<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_MDSPhong.ascx.cs" Inherits="UC_UC_MDSPhong" %>
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
            <CommandItemSettings AddNewRecordText="Thêm phòng"
                RefreshText="Làm mới" />
            <Columns>

                <telerik:GridTemplateColumn HeaderText="STT">
                    <ItemTemplate>
                        <%# Container.DataSetIndex + 1 %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="IDPhong" HeaderText="Mã phòng"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "ID") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <telerik:RadTextBox runat="server" Enabled="False" ID ="txtidphong" EmptyMessage="Tự động thêm">
                           
                       </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn UniqueName="TenPhong" DataField="Ten" HeaderText="Tên phòng"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

               <telerik:GridTemplateColumn UniqueName="LoaiPhong" HeaderText="Loại phòng"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "TenLoaiPhong") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="cbboxloaiphong" Width="300px"
                            EmptyMessage="--- Chọn loại phòng ---">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="kk" runat="server" ControlToValidate="cbboxloaiphong"
                            ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
            </Columns>
            <EditFormSettings>
                <EditColumn UniqueName="EditCommandColumn" CancelText="Hủy" UpdateText="Lưu "
                    InsertText="Thêm ">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</div>


