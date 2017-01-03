using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IPhong:IShare
    {
        int ID { get; set; }
        string Ten { get; set; }

        int IdLoaiPhong { get; set; }
        System.TimeSpan TGStart { get; set; }

        int StatusID { get; set; }

    }
}
