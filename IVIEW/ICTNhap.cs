using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface ICTNhap
    {
        int IDHang { get; set; }
        int IDHoaDon { get; set; }

        int SoLuong { get; set; }
        decimal DonGiaNhap { get; set; }
        decimal ThanhTien { get; set; }
    }
}
