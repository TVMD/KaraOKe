using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
     public class MThPhieuChi
    {
        public List<PHIEUCHI> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<PHIEUCHI> query = from s in db.PHIEUCHIs where s.Deleted == 0 select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                              (x.NgayLap != null &&
                                              x.NgayLap.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.NoiDung != null &&
                                              x.NoiDung.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.TongTien != null &&
                                              x.TongTien.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                               (x.GhiChu != null &&
                                              x.GhiChu.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(PHIEUCHI item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.PHIEUCHIs.Add(item);
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
                    var x = from s in db.PHIEUCHIs
                            where s.ID == ID && s.Deleted == 0
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

        public bool Update(PHIEUCHI item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHIEUCHIs
                            where s.ID == item.ID && s.Deleted == 0
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.NgayLap = item.NgayLap;
                        sv.NoiDung = item.NoiDung;
                        sv.TongTien = item.TongTien;
                        sv.GhiChu = item.GhiChu;
                      
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

        public PHIEUCHI GetOne(int id)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHIEUCHIs
                            where s.ID == id && s.Deleted == 0
                            select s;
                    return x.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
