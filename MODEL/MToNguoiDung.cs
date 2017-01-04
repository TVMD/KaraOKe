using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MToNguoiDung
    {
        public List<GetListNguoiDung_Result> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<GetListNguoiDung_Result> query = db.GetListNguoiDung();

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.MaDangNhap != null &&
                                              x.MaDangNhap.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.HoTen != null &&
                                              x.HoTen.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                              (x.Email != null &&
                                              x.Email.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                              (x.SoDT != null &&
                                              x.SoDT.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)

                        );
                }

                return query.ToList();
            }
        }
        public List<NHOMQUYEN> ListNhomQuyen()
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<NHOMQUYEN> query = from s in db.NHOMQUYENs select s;            

                return query.ToList();
            }
        }

        public bool Insert(NGUOIDUNG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.NGUOIDUNGs
                            where s.MaDangNhap == item.MaDangNhap
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv == null)
                    {
                        db.NGUOIDUNGs.Add(item);
                        db.SaveChanges();
                        return true;
                    }
                    return false;//trung username
                    
                }
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
                    var x = from s in db.NGUOIDUNGs
                            where s.ID == ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.NGUOIDUNGs.Remove(sv);
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

        public bool Update(NGUOIDUNG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.NGUOIDUNGs
                            where s.ID == item.ID
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        if (sv.MaDangNhap.CompareTo(item.MaDangNhap) != 0)
                        {
                            var y = from s in db.NGUOIDUNGs
                                    where s.MaDangNhap == item.MaDangNhap
                                    select s;
                            var svy = x.FirstOrDefault();
                            if (svy != null)
                            {
                                return false;
                            }                            
                        }
                        sv.MaDangNhap = item.MaDangNhap;
                        sv.MatKhau = item.MatKhau;
                        sv.HoTen = item.HoTen;
                        sv.Email = item.Email;
                        sv.SoDT = item.SoDT;
                        sv.MaNhomQuyen = item.MaNhomQuyen;
                        db.SaveChanges();
                        return true;                       
                        
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
