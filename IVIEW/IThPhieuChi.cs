using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IThPhieuChi : IShare
    {
        int ID {get; set ;}
        DateTime NgayLap { get; set; }
        string NoiDung { get; set; }
        decimal TongTien { get; set; }
        string GhiChu { get; set; }
      //  byte Deleted { get; set; }

    }
}
