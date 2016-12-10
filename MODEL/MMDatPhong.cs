using System;
using System.Collections.Generic;
using System.Linq;

namespace MODEL
{
    public class MMDatPhong
    {
        public List<DATPHONG> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<DATPHONG> query = from s in db.DATPHONGs select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.NgayGioDat != null &&
                                              x.NgayGioDat.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.SDT != null &&
                                              x.SDT.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.Note != null &&
                                              x.Note.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(DATPHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.DATPHONGs.Add(item);
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
                    var x = from s in db.DATPHONGs
                        where s.ID == ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.DATPHONGs.Remove(sv);
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

        public bool Update(DATPHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.DATPHONGs
                        where s.ID == item.ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.NgayGioDat = item.NgayGioDat;
                        sv.SDT = item.SDT;
                        sv.Note = item.Note;
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