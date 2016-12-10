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

        public bool Insert(HANG phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.HANGs.Add(phong);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(HANG phong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HANGs
                            where (s.ID == phong.ID)
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.SLTon=phong.SLTon;
                        sv.Ten=phong.Ten;
                        sv.Requested = phong.Requested;
                        sv.DonVi = phong.DonVi;
                        sv.DonGiaBan = sv.DonGiaBan;
                        sv.DonGiaNhap = sv.DonGiaNhap;
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
