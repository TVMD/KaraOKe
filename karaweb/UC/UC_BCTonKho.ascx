<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_BCTonKho.ascx.cs" Inherits="UC_UC_BCTonKho" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Page="../Default2.aspx" %>


<div>

    <div style="float:left;margin-left:0px;text-align:center;margin-top:10px">
        <b >Danh sách báo cáo</b>
        <telerik:RadGrid ID="RadGrid1" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="10" AutoGenerateColumns="False" Width="300"
            OnNeedDataSource="RadGrid1_OnNeedDataSource"
            OnItemCreated="RadGrid1_OnItemCreated"
            OnItemDataBound="RadGrid1_OnItemDataBound"
            OnInsertCommand="RadGrid1_OnInsertCommand"
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
                    <telerik:GridBoundColumn UniqueName="ID" DataField="ID" HeaderText="ID" ReadOnly="true">                        
                    </telerik:GridBoundColumn>
                    <telerik:GridDateTimeColumn UniqueName="Thang" DataField="Thang" DataType="System.DateTime" ColumnEditorID="dtNgayNhap" 
                                            DataFormatString="{0:MM/yyyy}" EditDataFormatString="MM/yyyy"
                                            HeaderText="Tháng" SortExpression="ShippedDate">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="*"></RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>

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
       <b >Chi tiết báo cáo</b>
        <telerik:RadGrid ID="RadGrid2" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="10" 
            AutoGenerateColumns="False" Width="700px" 
            
            OnNeedDataSource="RadGrid2_OnNeedDataSource"
            OnItemCreated="RadGrid2_OnItemCreated"
            OnItemDataBound="RadGrid2_OnItemDataBound"
            OnSelectedIndexChanged="RadGrid2_SelectedIndexChanged"
            OnPreRender="RadGrid2_PreRender">
            <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="None" Width="100%" 
                ItemStyle-HorizontalAlign="Left" AlternatingItemStyle-HorizontalAlign="Left" CommandItemStyle-HorizontalAlign="Left">
                <Columns>

                    <telerik:GridTemplateColumn HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataSetIndex + 1 %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="ID" DataField="ID" HeaderText="ID" Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="TenHang" DataField="Ten" HeaderText="Tên hàng" ReadOnly="true">
                            </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="TonDau" DataField="tondau" HeaderText="Tồn đầu" ReadOnly="true">
                            </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="SoLuongNhap" DataField="soluongnhap" HeaderText="Số lượng nhập" ReadOnly="true">
                            </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="SoLuongBan" DataField="SuDung" HeaderText="Số lượng bán" ReadOnly="true">
                            </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="TonCuoi" DataField="toncuoi" HeaderText="Tồn cuối" ReadOnly="true">
                            </telerik:GridBoundColumn>
                                        
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