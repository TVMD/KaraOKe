using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IMLoaiPhong : IShare
    {
         int ID { get; set; }
         string Ten { get; set; }
         decimal GiaNgay { get; set; }
         decimal GiaDem { get; set; }
    }
}
