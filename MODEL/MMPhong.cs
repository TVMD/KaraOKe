using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MODEL
{
    public class MMPhong
    {
        private string GetNameLoaiPhong(int idloaiphong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.LOAIPHONGs
                            where s.ID == idloaiphong
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        return sv.Ten;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
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
                                             (x.IdLoaiPhong != null &&
                                              x.IdLoaiPhong.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (GetNameLoaiPhong(x.IdLoaiPhong) != null &&
                                              GetNameLoaiPhong(x.IdLoaiPhong)
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)

                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(PHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.PHONGs.Add(item);
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

        public bool Update(PHONG item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHONGs
                        where s.ID == item.ID
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Ten = item.Ten;
                        sv.IdLoaiPhong = item.IdLoaiPhong;
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

        public PHONG GetOne(int Id)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHONGs
                            where s.ID == Id
                            select s;
                    return  x.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Begin(int id, DateTime tgbatdau,string tenkh)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHONGs
                            where s.ID == id
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        if(sv.StatusID!=1) return false;
                        sv.StatusID = 3; //busy
                        sv.TGStart = tgbatdau;
                        db.SaveChanges();

                        //bat dau thi tao hoa don dv
                        var item = new HOADONDV()
                        {
                            ID_Phong = id,
                            NgayGioLap = tgbatdau,
                            SoGio = 0 ,
                            TenKH = tenkh ?? "",
                            TongTien = 0
                        };
                        db.HOADONDVs.Add(item);
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

        public bool End(int idphong)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.PHONGs
                            where s.ID == idphong
                            select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        if (sv.StatusID != 3) return false;

                        decimal tienphong = 0;
                         //Ket thuc thi tinh tien hoa don.
                        var hoadon = (from s in db.HOADONDVs where s.ID_Phong == idphong orderby s.ID descending select s ).FirstOrDefault();
                        var loaiphong = (from s in db.LOAIPHONGs where s.ID == sv.IdLoaiPhong select s).FirstOrDefault();
                        var giongaydem = DateTime.Parse("2012/12/12 " + (from s in db.THAMSOes where s.Name == "GioNgayDem" select s).FirstOrDefault().Value);
                        hoadon.SoGio = (DateTime.Now-sv.TGStart.GetValueOrDefault()).TotalHours;

                        //tinh tong tien +=  tien phog. tien nuoc uong lien tuc duoc cap nha roi
                        DateTime t2 = DateTime.Parse("2012/12/12 "+sv.TGStart.GetValueOrDefault().ToString("HH:mm:ss"));
                        if (giongaydem < t2 || t2 < DateTime.Parse("2012/12/12 06:00:00"))
                        {
                           
                            tienphong = Convert.ToDecimal(hoadon.SoGio.GetValueOrDefault() * (double)loaiphong.GiaDem.GetValueOrDefault());
                            hoadon.TongTien += tienphong;

                        }
                        else
                        {
                            tienphong = Convert.ToDecimal(hoadon.SoGio.GetValueOrDefault() * (double)loaiphong.GiaNgay.GetValueOrDefault());
                            hoadon.TongTien += tienphong;
                        }

                        //sau do cap nhat tinh trnag phong, lam tron so
                        hoadon.TongTien = Math.Round(hoadon.TongTien, 0);
                        hoadon.TienPhong = Math.Round(tienphong, 0);
                        sv.StatusID = 1; //free
                        sv.TGStart = null;
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