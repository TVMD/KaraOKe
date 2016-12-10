using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IVIEW;
using PRESENTER;

public partial class InputHang : System.Web.UI.Page,ITHang
{
    #region Variable

    private string _message = "";
    private int currentId = 2;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Ten = txtTenHang.Text;
        DonVi = txtDonVi.Text;
        var presenter = new PTHang(this);
        Message = presenter.Inseart() ? "Thêm thành công" : "Có lỗi xảy ra";
        if (Message == "Thêm thành công")
        {
        }
    }
    #region Implement View

    public int ID { get; set; }

    public decimal DonGiaNhap { get; set; }
    public decimal DonGiaBan { get; set; }
    public string Ten { get; set; }
    public int SLTon { get; set; }
    public string DonVi { get; set; }
    public int Requested { get; set; }
    public string Message { get; set; }
    #endregion
}