<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ToThongKe.ascx.cs" Inherits="UC_UC_ToThongKe" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Page="../Default2.aspx" %>


<telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Transitions="true">
    <ChartTitle Text="THỐNG KÊ DOANH THU NGÀY">
        <Appearance Align="Center" Position="Top">
        </Appearance>
    </ChartTitle>
    <PlotArea>
        <Series>
            <telerik:ColumnSeries DataFieldY="DoanhThu" Name="Doanh Thu (Nghìn đồng)">
                <TooltipsAppearance Visible="false"></TooltipsAppearance>
            </telerik:ColumnSeries>
        </Series>
        <XAxis DataLabelsField="Ngay">
            <TitleAppearance Text="Ngày"></TitleAppearance>
            <MajorGridLines Visible="false"></MajorGridLines>
        </XAxis>
        <YAxis>
            <TitleAppearance Text="Doanh thu (Nghìn đồng)"></TitleAppearance>
            <MinorGridLines Visible="false"></MinorGridLines>
        </YAxis>
    </PlotArea>
    <Legend>
        <Appearance Visible="true"></Appearance>
    </Legend>
    <%--<ChartTitle Text="SỐ LƯỢNG SINH VIÊN THEO KHOA">
    </ChartTitle>--%>
</telerik:RadHtmlChart>
<br/>

<center>
<telerik:RadHtmlChart runat="server" ID="DonutChart1" Width="520" Height="500" Transitions="true">
    <ChartTitle Text="TỈ LỆ SẢN PHẨM ĐƯỢC GỌI THEO HÓA ĐƠN DV TRONG NGÀY">
        <Appearance Align="Center" Position="Top">
        </Appearance>
    </ChartTitle>
    <Legend>
        <Appearance Position="Right" Visible="true">
        </Appearance>
    </Legend>
    <PlotArea>
        <Series>
            <telerik:DonutSeries StartAngle="90" HoleSize="65" NameField="Name" DataFieldY="Y" ExplodeField="Exploded" ColorField="BackgroundColor" DataVisibleInLegendField="Y">
                <LabelsAppearance Position="Center" DataFormatString="{0} %" Visible="true"></LabelsAppearance>
                <TooltipsAppearance Color="White" DataFormatString="{0}%"></TooltipsAppearance>
                
            </telerik:DonutSeries>
            
        </Series>
        <XAxis ></XAxis>
    </PlotArea>
</telerik:RadHtmlChart>
    </center>
