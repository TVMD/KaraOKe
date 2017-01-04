using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MThHang
    {
        public List<HANG> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<HANG> query = from s in db.HANGs select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.Ten != null &&
                                              x.Ten.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.DonGiaNhap != null &&
                                              x.DonGiaNhap.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.DonGiaBan != null &&
                                              x.DonGiaBan.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.SLTon != null &&
                                              x.SLTon.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                            (x.DonVi != null &&
                                              x.DonVi.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                            (x.Requested != null &&
                                              x.Requested.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(HANG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.HANGs.Add(item);
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
                    var x = from s in db.HANGs
                            where s.ID == ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.HANGs.Remove(sv);
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

        public bool Update(HANG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HANGs
                            where s.ID == item.ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Ten = item.Ten;
                        sv.DonGiaNhap = item.DonGiaNhap;
                        sv.DonGiaBan = item.DonGiaBan;
                       // sv.SLTon = GetSLTon();
                        sv.DonVi = item.DonVi;
                        sv.Requested = item.Requested;
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

        public HANG GetOne(int id)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HANGs
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
        public List<int> GetSLTon()
        {
            var db = new QLPhongKaraokeEntities();            
                var x = from h in db.HANGs
                        join t in db.CT_BCTONKHO
                        on h.ID equals t.ID_Hang
                        select t.TonCuoi;
                return x.ToList();

        }

               
            
    }
}
