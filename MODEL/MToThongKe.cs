using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Text;
using MODEL.DTO;

namespace MODEL
{
    public class MToThongKe
    {
        public List<DTO_DoanhThuChart> GetDoanhThuNgay()
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                DateTime dt = DateTime.Today.AddDays(-7);
                var results = (from sv in db.HOADONDVs
                               where sv.Deleted == 0 && sv.NgayGioLap>= dt
                               group sv by sv.NgayGioLap into g
                               select new DTO_DoanhThuChart
                               {
                                   Ngay = g.Key,
                                   DoanhThu = g.Sum(_ => _.TongTien)
                               });

                return results.ToList();
            }

        }
        public List<DTO_HangHoaChart> GetTiLeHangHoa()
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                DateTime dt = DateTime.Today;
                List<GetListHangHoaChart_Result> rd = db.GetListHangHoaChart(dt).ToList();
                List<DTO_HangHoaChart> dto = new List<DTO_HangHoaChart>();
                for (int i = 0; i < rd.Count; i++)
                {
                    dto.Add(new DTO_HangHoaChart(){Name = rd[i].Ten, soluong = rd[i].soluong.GetValueOrDefault()});
                }

                return dto;
            }

        }
    }
}
