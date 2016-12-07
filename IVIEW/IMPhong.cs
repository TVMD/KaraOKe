using System;

namespace IVIEW
{
    public interface IMPhong : IShare
    {
        int ID { get; set; }
        string Ten { get; set; }
        int StatusId { get; set; }
        DateTime TGStart { get; set; }
        int IdLoaiPhong { get; set; }

        //
        string TenLoaiPhong { get; set; }
        float GiaNgay { get; set; }
        float GiaDem { get; set; }

    }
}