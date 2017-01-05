<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ToBaoCaoDoanhThu.ascx.cs" Inherits="UC_ToBaoCaoDoanhThu" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Page="~/Default2.aspx" %>

<div>
    <label for="RadDatePickerFrom">Từ ngày : </label>
    <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" OnSelectedDateChanged="RadDatePickerFrom_SelectedDateChanged"></telerik:RadDatePicker>
    <label for="RadDatePickerTo">Đến ngày : </label>
    <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" OnSelectedDateChanged="RadDatePickerTo_SelectedDateChanged"></telerik:RadDatePicker>
    <asp:Button ID="Button1" runat="server" Text="Lập" OnClick="OnClick_Baocao"/>
    <textarea ID="TextArea2" runat="server" BorderStyle="None" readonly="true" Visible="false"></textarea>
    <br/>
    <br/>
    <b >Danh sách hóa đơn dịch vụ</b>
    <telerik:RadGrid ID="RadGrid1" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
        OnNeedDataSource="RadGrid1_OnNeedDataSource"
        OnItemCreated="RadGrid1_OnItemCreated"
        OnItemDataBound="RadGrid1_OnItemDataBound"
        OnInsertCommand="RadGrid1_OnInsertCommand"
        OnUpdateCommand="RadGrid1_OnUpdateCommand"
        OnDeleteCommand="RadGrid1_OnDeleteCommand">
        <MasterTableView EditMode="EditForms" ShowFooter="false" CommandItemDisplay="None">
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
                <telerik:GridDateTimeColumn DataField="NgayGioLap" DataType="System.DateTime"
                    DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
                    HeaderText="Ngày lập" SortExpression="ShippedDate"
                    UniqueName="Ngaylap">
                    
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn UniqueName="TenKhachHang" DataField="TenKH" HeaderText="Tên khách hàng"
                    HeaderStyle-Width="600px">                    
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="TenPhong" DataField="Ten" HeaderText="Tên phòng"
                    HeaderStyle-Width="600px">                    
                </telerik:GridBoundColumn>                
                <telerik:GridBoundColumn UniqueName="Thoigianhat" DataField="SoGio" HeaderText="Thời gian hát"
                    HeaderStyle-Width="600px">                    
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="TienPhong" DataField="TongTien" HeaderText="Tổng tiền"
                    HeaderStyle-Width="600px">                    
                </telerik:GridBoundColumn>

            </Columns>
            
        </MasterTableView>
    </telerik:RadGrid>
    <br/>
    <center><label>Tổng doanh thu : </label> <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server" CssClass="AlgRgh">0</asp:TextBox><label> đồng</label></center>
    <br/>
    <b >Danh sách phiếu chi</b>
        <telerik:RadGrid ID="RadGrid2" runat="server" ShowStatusBar="True" AllowPaging="True" PageSize="10" 
            AutoGenerateColumns="False"
            OnNeedDataSource="RadGrid2_OnNeedDataSource"
            OnItemDataBound="RadGrid2_OnItemDataBound">
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
                    <telerik:GridDateTimeColumn DataField="NgayLap" DataType="System.DateTime"
                        DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
                        HeaderText="Ngày lập" SortExpression="ShippedDate"
                        UniqueName="Ngaylap">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridBoundColumn UniqueName="NoiDung" DataField="NoiDung" HeaderText="Nội dung" ReadOnly="true">
                            </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="TongTien" DataField="TongTien" HeaderText="Tổng tiền" ReadOnly="true">
                            </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GhiChu" DataField="GhiChu" HeaderText="Ghi chú" ReadOnly="true">
                            </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            
        </telerik:RadGrid>
    <br/>
    <center><label>Tổng tiền chi : </label> <asp:TextBox ID="TextBox2" ReadOnly="true" runat="server" CssClass="AlgRgh">0</asp:TextBox><label> đồng</label></center>
    <br/>
</div>


