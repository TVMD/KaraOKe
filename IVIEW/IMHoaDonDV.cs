using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IMHoaDonDV : IShare
    {

         int ID_HoaDon { get; set; }
         int ID_Phong { get; set; }
         System.DateTime NgayGioLap { get; set; }
         string TenKH { get; set; }
         decimal TongTien { get; set; }
        
        //chitiet
        int ID_HoaDonDV { get; set; }
        int ID_Hang { get; set; }
        int SoLuong { get; set; }
        decimal DonGia { get; set; }
        decimal ThanhTien { get; set; }
    }
}
