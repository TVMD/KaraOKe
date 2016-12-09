using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MPhong
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
                                             (x.TGStart != null &&
                                              x.TGStart.Value.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }

        }
        public bool Insert(PHONG phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.PHONGs.Add(phong);
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

        public bool Update(PHONG phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHONGs
                            where s.ID == phong.ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Ten = phong.Ten;
                        sv.StatusID = phong.StatusID;
                        sv.IdLoaiPhong = phong.IdLoaiPhong;
                        sv.TGStart = phong.TGStart;
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
