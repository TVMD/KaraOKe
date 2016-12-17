using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MMHang
    {
        public List<HANG> List(string search) //chi lay nhung cai co slton > 0
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
                                             (x.DonGiaBan != null &&
                                              x.DonGiaBan.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.DonGiaNhap != null &&
                                              x.DonGiaNhap.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.SLTon > 0 &&
                                              x.SLTon.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
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

    }
}
