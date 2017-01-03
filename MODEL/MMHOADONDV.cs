using System;
using System.Collections.Generic;
using System.Linq;

namespace MODEL
{
    public class MMHOADONDV
    {
        public List<HOADONDV> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<HOADONDV> query = from s in db.HOADONDVs where s.Deleted == 0 select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID != null &&
                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.TenKH != null &&
                                              x.TenKH.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.ID_Phong != null &&
                                              x.ID_Phong.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.TongTien != null &&
                                              x.TongTien.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.NgayGioLap != null &&
                                              x.NgayGioLap.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(HOADONDV item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.HOADONDVs.Add(item);
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
                    var x = from s in db.HOADONDVs
                            where s.ID == ID && s.Deleted == 0
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Deleted = 1;
                        db.SaveChanges();

                        (new MMCT_HoaDonDV()).DeleteAllHoaDon(ID); // xoa hoa don thi xoa luon ct
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(HOADONDV item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONDVs
                            where s.ID == item.ID && s.Deleted == 0
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.TenKH = item.TenKH;
                        sv.ID_Phong = item.ID_Phong;
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

        public bool UpdateTongTien(int id,decimal tongtien)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONDVs
                            where s.ID == id && s.Deleted == 0
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.TongTien = tongtien;
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

        public HOADONDV GetOne(int id)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONDVs
                            where s.ID == id && s.Deleted == 0
                            select s;
                   return x.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HOADONDV GetLastByRom(int idrom) //lay cai cuoi cung cua phong mak chua dc tinh tien.
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONDVs
                            where s.ID_Phong == idrom && s.SoGio == 0 && s.Deleted == 0
                            orderby s.ID descending 
                            select s;
                    return x.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HOADONDV GetLastByRomChaged(int idrom) //lay cai cuoi cung cua phong mak chua dc tinh tien.
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.HOADONDVs
                            where s.ID_Phong == idrom && s.Deleted == 0
                            orderby s.ID descending
                            select s;
                    return x.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public bool InsertByRom(int idrom,string tenkh)
        //{
        //    try
        //    {
        //        using (var db = new QLPhongKaraokeEntities())
        //        {
        //            var phong = (from s in db.PHONGs
        //                        where s.ID == idrom
        //                        select s).FirstOrDefault();
        //            var item = new HOADONDV()
        //            {
        //                ID_Phong = phong.ID,
        //                NgayGioLap = phong.TGStart.GetValueOrDefault(),
        //                TenKH = tenkh??"",
        //                TongTien = 0
        //            };
        //            db.HOADONDVs.Add(item);
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        public decimal GetTongTienHang(int idhoadon)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = (from s in db.CT_HOADONDV
                             where s.ID_HoaDonDV == idhoadon && s.Deleted == 0
                            select s);
                    decimal tien = 0;
                    foreach (var item in x)
                    {
                        tien += item.ThanhTien;
                    }
                    return tien;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<PHONG> GetAllPhong()
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<PHONG> query = from s in db.PHONGs where s.Deleted == 0 select s;

                return query.ToList();
            }
        }
    }
}