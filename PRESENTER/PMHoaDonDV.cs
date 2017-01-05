using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public class PMHoaDonDV
    {
        private readonly MMHOADONDV model;
        private readonly IMHoaDonDV view;
        private readonly MMPhong modelphong;

        public PMHoaDonDV(IMHoaDonDV x)
        {
            view = x;
            model = new MMHOADONDV();
            modelphong = new MMPhong();
        }

        public DataTable List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                view.Message = "Resource not found!. null";
                return null;
            }

            var tb = new DataTable();
            tb.Columns.Add("ID");
            tb.Columns.Add("ID_phong");
            tb.Columns.Add("TenPhong");
            tb.Columns.Add("NgayGioLap");
            tb.Columns.Add("TenKH");
            tb.Columns.Add("TongTien");
            foreach (var item in dt)
            {
                var phong = modelphong.GetOne(item.ID_Phong);
                if(phong!=null)
                tb.Rows.Add(item.ID,
                    item.ID_Phong,
                    phong.Ten,
                    item.NgayGioLap,
                    item.TenKH,
                    item.TongTien);
            }
            return tb;
        }

        public bool Inseart()
        {
            var hd = new HOADONDV()
            {
                ID = view.ID_HoaDon,
                ID_Phong = view.ID_Phong,
                TenKH = view.TenKH,
                NgayGioLap = view.NgayGioLap,
                TongTien = view.TongTien
            };
            return model.Insert(hd);
        }

        public bool Delete()
        {
            return model.Delete(view.ID_HoaDon);
        }

        public bool Update()
        {
            var ct = new HOADONDV()
            {
                ID = view.ID_HoaDon,
                ID_Phong = view.ID_Phong,
                TenKH = view.TenKH
            };
            return model.Update(ct);
        }

        public HOADONDV GetLastByRom(int idrom)
        {
            return model.GetLastByRom(idrom);
        }

        public HOADONDV GetLastByRomChaged(int idrom)
        {
            return model.GetLastByRomChaged(idrom);
        }
        public decimal GetTongTienHang()
        {
            return model.GetTongTienHang(model.GetLastByRomChaged(view.ID_Phong).ID);
        }

        public HOADONDV GetOne(int id)
        {
            return model.GetOne(id);
        }

        public List<PHONG> GetAllPhong()
        {
            return model.GetAllPhong();
        }
    }
}
