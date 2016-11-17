<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_SinhVien.ascx.cs" Inherits="UC_UC_SinhVien" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div>
    <div align="right">
        <telerik:RadTextBox ID="txtsearch" runat="server" Width="300px"
            OnTextChanged="txtsearch_OnTextChanged" AutoPostBack="True">
        </telerik:RadTextBox>
    </div>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="4" AutoGenerateColumns="False"
        OnNeedDataSource="RadGrid1_OnNeedDataSource"
        OnItemCreated="RadGrid1_OnItemCreated"
        OnItemDataBound="RadGrid1_OnItemDataBound"
        OnInsertCommand="RadGrid1_OnInsertCommand"
        OnUpdateCommand="RadGrid1_OnUpdateCommand"
        OnDeleteCommand="RadGrid1_OnDeleteCommand">
        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="TopAndBottom">
            <CommandItemSettings AddNewRecordText="Thêm sinh viên"
                RefreshText="Làm mới" />
            <Columns>

                <telerik:GridTemplateColumn HeaderText="STT">
                    <ItemTemplate>
                        <%# Container.DataSetIndex + 1 %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn UniqueName="MaSV" DataField="ID" HeaderText="Mã sinh viên"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="HoTenSV" DataField="Ten" HeaderText="Họ tên"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

                <%--<telerik:GridDateTimeColumn DataField="NgaySinh" DataType="System.DateTime"
                                            DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
                                            HeaderText="Ngày Sinh" SortExpression="ShippedDate">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                        <ModelErrorMessage BackColor="Red"/>
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>--%>

                <telerik:GridTemplateColumn UniqueName="Khoa" HeaderText="Khoa"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "TenKhoa") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadComboBox runat="server" ID="k" Width="300px"
                            EmptyMessage="--- Lựa chọn Khoa---">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="kk" runat="server" ControlToValidate="k"
                            ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridEditCommandColumn CancelText="Hủy" EditText="Sửa" />
                <telerik:GridButtonColumn CommandName="Delete" Text="Xóa" UniqueName="DeleteColumn"
                    ConfirmText="Xóa sinh viên này?" ConfirmDialogType="RadWindow">
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
