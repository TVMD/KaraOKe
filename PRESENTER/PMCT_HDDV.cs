using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public class PMCT_HDDV
    {
        private readonly MMCT_HoaDonDV model;
        private readonly IMHoaDonDV view;
        private readonly MMHang modelhang;

        public PMCT_HDDV(IMHoaDonDV x)
        {
            view = x;
            model = new MMCT_HoaDonDV();
            modelhang = new MMHang();
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
            tb.Columns.Add("ID_HoaDonDV");
            tb.Columns.Add("ID_Hang");
            tb.Columns.Add("SoLuongTon");
            tb.Columns.Add("TenHang");
            tb.Columns.Add("SoLuong");
            tb.Columns.Add("DonGia");
            tb.Columns.Add("ThanhTien");
            foreach (var item in dt)
            {
                var hang = modelhang.GetOne(item.ID_Hang);
                tb.Rows.Add(item.ID_HoaDonDV,
                    item.ID_Hang,
                    hang.Ten,
                    hang.SLTon,
                    item.SoLuong,
                    item.DonGia,
                    item.ThanhTien);
            }
            return tb;
        }

        public bool Inseart()
        {
            var hang = (new MMHang()).GetOne(view.ID_Hang);
            var ctiet = new CT_HOADONDV
            {
                ID_HoaDonDV = view.ID_HoaDon,
                ID_Hang = view.ID_Hang,
                SoLuong = view.SoLuong > hang.SLTon?hang.SLTon:view.SoLuong,
                DonGia = hang.DonGiaBan,
                ThanhTien = (view.SoLuong > hang.SLTon ? hang.SLTon : view.SoLuong) * hang.DonGiaBan
            };
            return model.Insert(ctiet);
        }

        public bool Delete()
        {
            return model.Delete(view.ID_HoaDon, view.ID_Hang);
        }

        public bool Update()
        {
            var hang = (new MMHang()).GetOne(view.ID_Hang);
            var ct = new CT_HOADONDV
            {
                ID_HoaDonDV = view.ID_HoaDon,
                ID_Hang = view.ID_Hang,
                SoLuong = view.SoLuong > hang.SLTon ? hang.SLTon : view.SoLuong,
                DonGia = hang.DonGiaBan,
                ThanhTien = (view.SoLuong > hang.SLTon ? hang.SLTon : view.SoLuong) * hang.DonGiaBan
            };
            return model.Update(ct);
        }

        public List<HANG> GetAllHang()
        {
            var dt = modelhang.List(null);
            if (dt == null)
            {
                view.Message = "Resource not found!";
                return null;
            }
            return dt;
        }

        public DataTable List_HD(int idhoadon)
        {
            var dt = model.List_HD(idhoadon);
            if (dt == null)
            {
                view.Message = "Resource not found!. null";
                return null;
            }

            var tb = new DataTable();
            tb.Columns.Add("ID_HoaDonDV");
            tb.Columns.Add("ID_Hang");
            tb.Columns.Add("TenHang");
            tb.Columns.Add("SoLuongTon");
            tb.Columns.Add("SoLuong");
            tb.Columns.Add("DonGia");
            tb.Columns.Add("ThanhTien");
            foreach (var item in dt)
            {
                var hang = modelhang.GetOne(item.ID_Hang);
                tb.Rows.Add(item.ID_HoaDonDV,
                    item.ID_Hang,
                    hang.Ten,
                    hang.SLTon,
                    item.SoLuong,
                    item.DonGia,
                    item.ThanhTien);
            }
            return tb;
        }

        public DataTable List_HD(int idhoadon,string search)
        {
            var dt = model.List_HD(idhoadon,search);
            if (dt == null)
            {
                view.Message = "Resource not found!. null";
                return null;
            }

            var tb = new DataTable();
            tb.Columns.Add("ID_HoaDonDV");
            tb.Columns.Add("ID_Hang");
            tb.Columns.Add("TenHang");
            tb.Columns.Add("SoLuongTon");
            tb.Columns.Add("SoLuong");
            tb.Columns.Add("DonGia");
            tb.Columns.Add("ThanhTien");
            foreach (var item in dt)
            {
                var hang = modelhang.GetOne(item.ID_Hang);
                tb.Rows.Add(item.ID_HoaDonDV,
                    item.ID_Hang,
                    hang.Ten,
                    hang.SLTon,
                    item.SoLuong,
                    item.DonGia,
                    item.ThanhTien);
            }
            return tb;
        }

        public int GetSLTon(int idhang)
        {
            return model.GetSLTon(idhang);
        }
    }
}
