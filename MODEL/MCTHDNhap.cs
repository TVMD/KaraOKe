using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MCTHDNhap
    {
        public List<CT_HDNHAP> List(string search,int id)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<CT_HDNHAP> query = null;
                if (id != 0) {
                    query = from s in db.CT_HDNHAP
                            where (s.IDHoaDon == id && s.Deleted == 0)
                                                   select s;
                }
                else
                {
                    query = from s in db.CT_HDNHAP select s;
                }
                

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search)&& id==0)
                {
                    query = query.Where(x => (x.IDHang != null &&
                                              x.IDHang.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.IDHoaDon != null &&
                                              x.IDHoaDon.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.SoLuong != null &&
                                              x.SoLuong.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.ThanhTien != null &&
                                              x.ThanhTien.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) 
                        );
                }

                return query.ToList();
            }

        }
        public bool Insert(CT_HDNHAP phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.CT_HDNHAP.Add(phong);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int IDHoaDon, int IDHang)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HDNHAP
                            where( s.IDHoaDon == IDHoaDon && s.IDHang==IDHang)
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Deleted = 1;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CT_HDNHAP phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HDNHAP
                            where (s.IDHoaDon == phong.IDHoaDon && s.IDHang == phong.IDHang)
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.SoLuong = phong.SoLuong;
                        sv.ThanhTien = phong.ThanhTien;
                        sv.DonGiaNhap = phong.DonGiaNhap;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public CT_HDNHAP Get1Item(int IDHoaDon, int IDHang)
        {
            if (IDHoaDon == 0 || IDHang==0)
                return null;
            using (var db = new QLPhongKaraokeEntities())
            {
                var query = (from k in db.CT_HDNHAP select k).Where(x =>( x.IDHang == IDHang && x.IDHoaDon==IDHoaDon)).FirstOrDefault();
                return query;
            }
        }
        public List<CT_HDNHAP> getCTByIDHD(int IDHD)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<CT_HDNHAP> query = from s in db.CT_HDNHAP where (s.IDHoaDon==IDHD&&s.Deleted==0)
                                               select s;

                //Filter // neu de search=null thi kho search,
               

                return query.ToList();
            }

        }
    }
}
