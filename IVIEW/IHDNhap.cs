using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IHDNhap: IShare
    {
        int ID { get; set; }

        decimal TongTien { get; set; }
        DateTime NgayNhap { get; set; }
        int IDHang { get; set; }
        string TenHang { get; set; }
        int IDHoaDon { get; set; }

        int SoLuong { get; set; }
        decimal DonGiaNhap { get; set; }
        decimal ThanhTien { get; set; }
    }
}
