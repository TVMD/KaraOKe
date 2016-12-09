
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MLoaiPhong
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
        public bool Insert(LOAIPHONG phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.LOAIPHONGs.Add(phong);
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

        public bool Update(LOAIPHONG phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.LOAIPHONGs
                            where s.ID == phong.ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Ten = phong.Ten;
                        sv.GiaDem = phong.GiaDem;
                        sv.GiaNgay = phong.GiaNgay;
                        sv.SoLuong = phong.SoLuong;
                        
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
        public LOAIPHONG Get1LoaiPhong(long id)
        {
            if (id == 0)
                return null;
            using (var db = new QLPhongKaraokeEntities())
            {
                var query = (from k in db.LOAIPHONGs select k).Where(x => x.ID == id).FirstOrDefault();
                return query;
            }
        }
    }
}
