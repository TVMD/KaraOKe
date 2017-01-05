<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ThPhieuChi.ascx.cs" Inherits="UC_UC_ThPhieuChi" %>
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
        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="TopAndBottom">
            <CommandItemSettings AddNewRecordText="Thêm phiếu chi"
                RefreshText="Làm mới" />
            <Columns>

                <telerik:GridTemplateColumn HeaderText="STT">
                    <ItemTemplate>
                        <%# Container.DataSetIndex + 1 %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="IDPhieuChi" HeaderText="Mã phiếu chi"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <asp:Label ID="LayoutTypeIDLabel" runat="server"
                        Text='<%#DataBinder.Eval(Container.DataItem, "ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox runat="server" Enabled="False" ID="txtidphieuchi" EmptyMessage="Tự động thêm">
                        </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>

              
                <%-- <telerik:GridTemplateColumn UniqueName="NgayLap" HeaderText="Ngày Lập"
                    HeaderStyle-Width="600px">
                    <ItemTemplate>
                        <asp:Label ID="LayoutTypeIDLabel" runat="server"
                        Text='<%#DataBinder.Eval(Container.DataItem, "NgayLap") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadDatePicker ID="txtngaylap" runat="server">
                        </telerik:RadDatePicker>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>--%>

               <telerik:GridDateTimeColumn  DataField="NgayLap" DataType="System.DateTime"
                DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"  
                HeaderText="Ngày lập" SortExpression="ShippedDate"
                UniqueName="ShippedDate" >
    
                <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                    <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                </ColumnValidationSettings>
            </telerik:GridDateTimeColumn>


                <telerik:GridBoundColumn UniqueName="NoiDung" DataField="NoiDung" HeaderText="Nội dung"
                    HeaderStyle-Width="600px">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="TongTien" HeaderText="Tổng tiền (VND)">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "TongTien") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadNumericTextBox ID="txttongtien" runat="server" MinValue="0">
                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txttongtien" ErrorMessage="(*)" ForeColor="Red" Width="4px">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn UniqueName="GhiChu" DataField="GhiChu" HeaderText="Ghi chú"
                    >
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
