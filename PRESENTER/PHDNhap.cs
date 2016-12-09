using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVIEW;
using MODEL;
using System.Data;

namespace PRESENTER
{
    public class PHDNhap
    {
        private readonly MHDNhap model;
        private readonly MCTHDNhap modelCT;
        private readonly M_Hang_Tien modelHang;
        private readonly IHDNhap view;


        public PHDNhap(IHDNhap x)
        {
            view = x;
            model = new MHDNhap();
            modelCT = new MCTHDNhap();
            modelHang = new M_Hang_Tien();
        }

        public DataTable List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                view.Message = "Resource not found!. ds phong = null";
            }

            var tb = new DataTable();
            tb.Columns.Add("ID");
            tb.Columns.Add("NgayNhap");
            tb.Columns.Add("TongTien");

            foreach (var item in dt)
            {

                tb.Rows.Add(item.ID, item.NgayNhap.ToShortDateString(), item.TongTien);
            }

            return tb;
        }

        public DataTable ListCT(string search,int id)
        {
            var dt = modelCT.List(search,id);
            if (dt == null)
            {
                view.Message = "Resource not found!. ds phong = null";
            }

            var tb = new DataTable();
            tb.Columns.Add("IDHang");
            tb.Columns.Add("TenHang");
            tb.Columns.Add("SoLuong");
            tb.Columns.Add("DonGiaNhap");
            tb.Columns.Add("ThanhTien");
            

            foreach (var item in dt)
            {
                var hang = modelHang.Get1Hang(item.IDHang);
                tb.Rows.Add(item.IDHang,hang.Ten, item.SoLuong, item.DonGiaNhap, item.ThanhTien);
            }

            return tb;
        }

        public bool Inseart()
        {
            var sv = new HOADONNHAP
            {
                
                
                NgayNhap=view.NgayNhap
            };
            return model.Insert(sv);
        }
        public bool InseartCT(int idHoaDon)
        {
            var sv = new CT_HDNHAP
            {

                IDHang = view.IDHang,
                IDHoaDon = idHoaDon,
                SoLuong = view.SoLuong,
                DonGiaNhap = view.DonGiaNhap,
                ThanhTien = view.SoLuong * view.DonGiaNhap
            };
            var hd = model.Get1Item(idHoaDon);
            hd.TongTien += sv.ThanhTien;
            model.Update(hd);
            return modelCT.Insert(sv);
        }
        public bool Delete()
        {
            List<CT_HDNHAP> tamp = modelCT.getCTByIDHD(view.ID);
            foreach (CT_HDNHAP tam in tamp)
            {
                modelCT.Delete(tam.IDHoaDon,tam.IDHang);
            }
            return model.Delete(view.ID);
        }
        public bool DeleteCT(int IDHoaDon)
        {
            var hd = model.Get1Item(IDHoaDon);
            var ct = modelCT.Get1Item(IDHoaDon, view.IDHang);
            hd.TongTien -= ct.ThanhTien;
            model.Update(hd);
            return modelCT.Delete(IDHoaDon,view.IDHang);
        }

        public bool Update()
        {
            var sv = new HOADONNHAP
            {

                ID = view.ID,
                NgayNhap = view.NgayNhap,
                TongTien = view.TongTien
            };
            return model.Update(sv);
        }

        public bool UpdateCT(int IDHoaDon)
        {
            var sv = new CT_HDNHAP
            {

                IDHang = view.IDHang,
                IDHoaDon = IDHoaDon,
                SoLuong = view.SoLuong,
                DonGiaNhap = view.DonGiaNhap,
                ThanhTien = view.SoLuong * view.DonGiaNhap
            };
            var hd = model.Get1Item(IDHoaDon);
            var ct = modelCT.Get1Item(IDHoaDon, view.IDHang);
            hd.TongTien += sv.ThanhTien - ct.ThanhTien;
            model.Update(hd);
            return modelCT.Update(sv);
        }

        public List<HANG> GetAllLoaiPhong()
        {

            var dt = modelHang.List();
            if (dt == null)
            {
                view.Message = "Resource not found!. dtHang = null";
                return null;
            }
            return dt;
        }
    }
}
