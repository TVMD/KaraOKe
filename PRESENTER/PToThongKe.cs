using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using MODEL.DTO;

namespace PRESENTER
{
    public class PToThongKe
    {
        public List<DTO_DoanhThuChart> GetDoanhThuNgay()
        {
            MToThongKe mchart = new MToThongKe();
            List<DTO_DoanhThuChart> tt = mchart.GetDoanhThuNgay();
            List<DTO_DoanhThuChart> tc = new List<DTO_DoanhThuChart>();
            for (int i = 0; i < tt.Count; i++)
            {
                for (int j=0; j<tc.Count;j++)
                    if (tt[i].Ngay.Date == tc[j].Ngay.Date)
                    {
                        tc[j].DoanhThu += tt[i].DoanhThu;
                        break;
                    }
                tc.Add(new DTO_DoanhThuChart(){Ngay = tt[i].Ngay.Date,DoanhThu = tt[i].DoanhThu});
            }
                
            return tc ;
        }
        public List<DTO_HangHoaChart> GetHangHoa()
        {

            List<String> listMau = new List<string>() { "#ff8172", "#d38e20", "#e6ffef", "#0f5f14", "#debc97", "#3b5998", "#413d26", "#d9ffcb", "#ed6161", "#104f60", "#d9ffcb", "#7b3626", "#e6ffef", "#ffc0cb" };
            MToThongKe mchart = new MToThongKe();
            List<DTO_HangHoaChart> list = mchart.GetTiLeHangHoa();
            if (list.Count != 0)
            {
                int tong = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    tong = tong + list[i].soluong;
                }
                double tongthieu = 0;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    list[i].Y = Math.Round((double)list[i].soluong / tong * 100, 1);
                    tongthieu += list[i].Y;
                    list[i].BackgroundColor = listMau[i];
                    list[i].Exploded = false;
                }
                list[list.Count - 1].Y = 100 - tongthieu;
                list[list.Count - 1].BackgroundColor = listMau[list.Count - 1];
                list[list.Count - 1].Exploded = false;
                return list;
            }
            return null;
        }
    }
}
