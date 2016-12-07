using System;
using System.Collections.Generic;
using System.Linq;

namespace MODEL
{
    public class MMCT_HoaDonDV
    {
        public List<CT_HOADONDV> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<CT_HOADONDV> query = from s in db.CT_HOADONDV select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID_HoaDonDV != null &&
                                              x.ID_HoaDonDV.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.ID_Hang != null &&
                                              x.ID_Hang.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.SoLuong != null &&
                                              x.SoLuong.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.DonGia != null &&
                                              x.DonGia.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.ThanhTien != null &&
                                              x.ThanhTien.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(CT_HOADONDV item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.CT_HOADONDV.Add(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int idhaodon, int idhang)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HOADONDV
                        where s.ID_HoaDonDV == idhaodon && s.ID_Hang == idhang
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.CT_HOADONDV.Remove(sv);
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

        public bool Update(CT_HOADONDV item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HOADONDV
                        where s.ID_HoaDonDV == item.ID_HoaDonDV && s.ID_Hang == item.ID_Hang
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.SoLuong = item.SoLuong;
                        sv.DonGia = item.DonGia;
                        sv.ThanhTien = item.ThanhTien;
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
    }
}