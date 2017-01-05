using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRESENTER;

public partial class UC_UC_ToThongKe : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("THỐNG KÊ TRONG NGÀY");
        PToThongKe pchart = new PToThongKe();
        RadHtmlChart1.DataSource = pchart.GetDoanhThuNgay();
        RadHtmlChart1.DataBind();
        //
        DonutChart1.DataSource = pchart.GetHangHoa();
        DonutChart1.DataBind();

    }



}