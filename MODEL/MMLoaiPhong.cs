using System;
using System.Collections.Generic;
using System.Linq;

namespace MODEL
{
    public class MMLoaiPhong
    {
        public List<LOAIPHONG> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<LOAIPHONG> query = from s in db.LOAIPHONGs select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.Ten != null &&
                                              x.Ten.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.GiaDem != null &&
                                              x.GiaDem.Value.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.GiaNgay != null &&
                                              x.GiaNgay.Value.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.SoLuong != null &&
                                              x.SoLuong.Value.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(LOAIPHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.LOAIPHONGs.Add(item);
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
                    var x = from s in db.LOAIPHONGs
                        where s.ID == ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.LOAIPHONGs.Remove(sv);
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

        public bool Update(LOAIPHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.LOAIPHONGs
                        where s.ID == item.ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Ten = item.Ten;
                        sv.GiaDem = item.GiaDem;
                        sv.GiaNgay = item.GiaNgay;
                        sv.SoLuong = item.SoLuong;
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

        public LOAIPHONG GetOne(int id)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.LOAIPHONGs
                            where s.ID == id
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