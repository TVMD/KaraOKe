﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IMHang : IShare
    {
         int ID { get; set; }
         string Ten { get; set; }
         decimal DonGiaNhap { get; set; }
         decimal DonGiaBan { get; set; }
         int SLTon { get; set; }
         string DonVi { get; set; }
         int Requested { get; set; }
    }
}
