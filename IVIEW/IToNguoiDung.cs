using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IToNguoiDung
    {
        int ID { get; set; }
        string MaDangNhap { get; set; }
        string MatKhau { get; set; }
        string HoTen { get; set; }
        string Email { get; set; }
        string SoDT { get; set; }
        int MaNhomQuyen { get; set; }
        string Message { get; set; }
    }
}
