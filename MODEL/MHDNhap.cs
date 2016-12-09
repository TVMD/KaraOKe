using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MHDNhap
    {
        public List<HOADONNHAP> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<HOADONNHAP> query = from s in db.HOADONNHAPs select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.NgayNhap != null &&
                                              x.NgayNhap.ToShortDateString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.TongTien != null &&
                                              x.TongTien.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) 
                        );
                }

                return query.ToList();
            }

        }
        public bool Insert(HOADONNHAP phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.HOADONNHAPs.Add(phong);
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
                    var x = from s in db.HOADONNHAPs
                            where s.ID == ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.HOADONNHAPs.Remove(sv);
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

        public bool Update(HOADONNHAP phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONNHAPs
                            where s.ID == phong.ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.NgayNhap = phong.NgayNhap;
                        sv.TongTien = phong.TongTien;

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
        public HOADONNHAP Get1Item(long id)
        {
            if (id == 0)
                return null;
            using (var db = new QLPhongKaraokeEntities())
            {
                var query = (from k in db.HOADONNHAPs select k).Where(x => x.ID == id).FirstOrDefault();
                return query;
            }
        }
    }
}
