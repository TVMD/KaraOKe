using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class M_Hang_Tien
    {

        public HANG Get1Hang(long id)
        {
            if (id == 0)
                return null;
            using (var db = new QLPhongKaraokeEntities())
            {
                var query = (from k in db.HANGs select k).Where(x => x.ID == id).FirstOrDefault();
                return query;
            }
        }
        public List<HANG> List()
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<HANG> query = from s in db.HANGs select s;

                //Filter // neu de search=null thi kho search,
               

                return query.ToList();
            }

        }
    }
}
