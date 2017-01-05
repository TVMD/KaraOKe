using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MToBaoCaoDoanhThu
    {
        public List<GetListBCDoanhThu_Result> GetListHoaDon(DateTime dateFrom, DateTime dateTo)
        {
            try{
                using (var db = new QLPhongKaraokeEntities())
                    {
                        IEnumerable<GetListBCDoanhThu_Result> query = db.GetListBCDoanhThu(dateFrom, dateTo);
                        return query.ToList();
                    }                    
                }       
                catch{   return null;        }
        }
        public List<PHIEUCHI> GetListPhieuChi(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    IEnumerable<PHIEUCHI> query = from s in db.PHIEUCHIs
                                                    where s.NgayLap >= dateFrom && s.NgayLap <= dateTo
                                                    select s;
                    return query.ToList();
                }
            }
            catch { return null; }
        }

        public string getTongTien(DateTime dateFrom, DateTime dateTo)
        {
            var kq = GetListHoaDon(dateFrom, dateTo);
            Decimal tong = 0;
            for (int i = 0; i < kq.Count; i++)
            {
                tong += kq[i].TongTien;
            }
            return tong.ToString();
        }
        public string getTongTienChi(DateTime dateFrom, DateTime dateTo)
        {
            var kq = GetListPhieuChi(dateFrom, dateTo);
            Decimal tong = 0;
            for (int i = 0; i < kq.Count; i++)
            {
                tong += kq[i].TongTien;
            }
            return tong.ToString();
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
                    return x.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Begin(int id, DateTime tgbatdau, string tenkh)
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
                        if (sv.StatusID != 1) return false;
                        sv.StatusID = 3; //busy
                        sv.TGStart = tgbatdau;
                        db.SaveChanges();

                        //bat dau thi tao hoa don dv
                        var item = new HOADONDV()
                        {
                            ID_Phong = id,
                            NgayGioLap = tgbatdau,
                            SoGio = 0,
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


                        //Ket thuc thi tinh tien hoa don.
                        var hoadon = (from s in db.HOADONDVs where s.ID_Phong == idphong orderby s.ID descending select s).FirstOrDefault();
                        var loaiphong = (from s in db.LOAIPHONGs where s.ID == sv.IdLoaiPhong select s).FirstOrDefault();
                        var giongaydem = DateTime.Parse("2012/12/12 " + (from s in db.THAMSOes where s.Name == "GioNgayDem" select s).FirstOrDefault().Value);
                        hoadon.SoGio = (DateTime.Now - sv.TGStart.GetValueOrDefault()).TotalHours;

                        //tinh tong tien +=  tien phog. tien nuoc uong lien tuc duoc cap nha roi
                        DateTime t2 = DateTime.Parse("2012/12/12 " + sv.TGStart.GetValueOrDefault().ToString("HH:mm:ss"));
                        if (giongaydem < t2 || t2 < DateTime.Parse("2012/12/12 06:00:00"))
                            hoadon.TongTien += Convert.ToDecimal(hoadon.SoGio.GetValueOrDefault() * (double)loaiphong.GiaDem.GetValueOrDefault());
                        else
                        {
                            hoadon.TongTien += Convert.ToDecimal(hoadon.SoGio.GetValueOrDefault() * (double)loaiphong.GiaNgay.GetValueOrDefault());
                        }

                        //sau do cap nhat tinh trnag phong, lam tron so
                        hoadon.TongTien = Math.Round(hoadon.TongTien, 0);
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
