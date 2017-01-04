using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IThHang :IShare
    {
        int ID { get; set; }
        string Ten { get; set; }
        decimal DonGiaNhap { get; set; }
        decimal DonGiaBan { get; set; }
        int SLTon { get; set; }
        string DonVi { get; set; }
       // int Requested { get; set; }

        // CT_BCTonKho

       // int ID_BCTonKho { get; set; }
      //  int ID_Hang { get; set; }
      //  int TonDau { get; set; }
     //   int SuDung { get; set; }
      //  int TonCuoi { get; set; }
    }
}
