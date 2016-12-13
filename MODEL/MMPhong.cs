using System;
using System.Collections.Generic;
using System.Linq;

namespace MODEL
{
    public class MMPhong
    {
        public List<PHONG> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<PHONG> query = from s in db.PHONGs select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.Ten != null &&
                                              x.Ten.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.StatusID != null &&
                                              x.StatusID.Value.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.IdLoaiPhong != null &&
                                              x.IdLoaiPhong.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(PHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.PHONGs.Add(item);
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
                    var x = from s in db.PHONGs
                        where s.ID == ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.PHONGs.Remove(sv);
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

        public bool Update(PHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHONGs
                        where s.ID == item.ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Ten = item.Ten;
                        sv.StatusID = item.StatusID;
                        sv.TGStart = item.TGStart;
                        sv.IdLoaiPhong = item.IdLoaiPhong;
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

        public PHONG GetPhong(int Id)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHONGs
                            where s.ID == Id
                            select s;
                    return  x.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}