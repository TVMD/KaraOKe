using System;
using System.Collections.Generic;
using System.Linq;

namespace MODEL
{
    public class MMHOADONDV
    {
        public List<HOADONDV> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<HOADONDV> query = from s in db.HOADONDVs select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.TenKH != null &&
                                              x.TenKH.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.ID_Phong != null &&
                                              x.ID_Phong.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.TongTien != null &&
                                              x.TongTien.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.NgayGioLap != null &&
                                              x.NgayGioLap.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(HOADONDV item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.HOADONDVs.Add(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONDVs
                        where s.ID == ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.HOADONDVs.Remove(sv);
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

        public bool Update(HOADONDV item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONDVs
                        where s.ID == item.ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.TenKH = item.TenKH;
                        sv.ID_Phong = item.ID_Phong;
                        sv.TongTien = item.TongTien;
                        sv.NgayGioLap = item.NgayGioLap;
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