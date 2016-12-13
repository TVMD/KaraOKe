using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IVIEW;
using MODEL;
using PRESENTER;
using Telerik.Web.UI;

public partial class UC_UC_MCT_Phong : System.Web.UI.UserControl , IMPhong
{
    private static PHONG phong;
    protected void Page_Load(object sender, EventArgs e)
    {
        phong = new PMPhong(this).GetPhong(ID);
        tenphong.Value = Ten;
        loaiphong.Value = IdLoaiPhong.ToString();
        status.Value = StatusId.ToString();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "loadjs", "ctphong_ready();", true);
    }

    #region implement & variable

    public string Message { get; set; }

    public int ID
    {
        get
        {
            return Int32.Parse(Default2.idphong ?? "0");
        }
        set { }
    }

    public string Ten
    {
        get { return phong!=null?phong.Ten:""; }
        set { }
    }

    public int StatusId
    {
        get { return phong != null ? phong.StatusID.GetValueOrDefault() : 0; }
        set { }
    }
    public DateTime TGStart
    {
        get { return phong != null ? phong.TGStart.GetValueOrDefault() : new DateTime(); }
        set { }
    }
    public int IdLoaiPhong
    {
        get { return phong != null ? phong.IdLoaiPhong : -1; }
        set { }
    }
    public string TenLoaiPhong { get; set; }
    public float GiaNgay { get; set; }
    public float GiaDem { get; set; }
    #endregion

    protected void btnBatDauClick(object sender, EventArgs e)
    {
        tenkh.Value = "batdau";
    }
    protected void btnTinhTienClick(object sender, EventArgs e)
    {
        tenkh.Value = "tinhtien";
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = new object[] { };
    }
}