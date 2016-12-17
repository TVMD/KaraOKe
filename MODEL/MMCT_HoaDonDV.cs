using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace MODEL
{
    public class MMCT_HoaDonDV
    {
        public List<CT_HOADONDV> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<CT_HOADONDV> query = from s in db.CT_HOADONDV select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.ID_HoaDonDV != null &&
                                              x.ID_HoaDonDV.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.ID_Hang != null &&
                                              x.ID_Hang.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.SoLuong != null &&
                                              x.SoLuong.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.DonGia != null &&
                                              x.DonGia.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.ThanhTien != null &&
                                              x.ThanhTien.ToString()
                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public List<CT_HOADONDV> List_HD(int idhoadon)
        {
            if (idhoadon < 1)
                return null;
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<CT_HOADONDV> query = from s in db.CT_HOADONDV where s.ID_HoaDonDV==idhoadon select s;
                return query.ToList();
            }
        }
        public bool Insert(CT_HOADONDV item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HOADONDV
                            where s.ID_HoaDonDV == item.ID_HoaDonDV && s.ID_Hang == item.ID_Hang
                            select s;
                    var sv = x.FirstOrDefault();
                    var hang = (from s in db.HANGs where s.ID == item.ID_Hang select s).FirstOrDefault();

                    if (sv != null) //da co thi cap nhat sl chu khong co them
                    {
                        sv.SoLuong += item.SoLuong;
                        sv.ThanhTien += item.ThanhTien;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.CT_HOADONDV.Add(item);
                        db.SaveChanges();
                    }
                    //cap nhat so luong ton
                    hang.SLTon -= item.SoLuong;
                    db.SaveChanges();
                    //cap nhat tong tien hoadon
                    var hd = new MMHOADONDV();
                    hd.UpdateTongTien(item.ID_HoaDonDV, hd.GetOne(item.ID_HoaDonDV).TongTien + item.ThanhTien);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int idhaodon, int idhang)
        {
            decimal thanhtiencu = 0;
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HOADONDV
                        where s.ID_HoaDonDV == idhaodon && s.ID_Hang == idhang
                        select s;
                    var sv = x.FirstOrDefault();
                    var hang = (from s in db.HANGs where s.ID == idhang select s).FirstOrDefault();

                    if (sv != null)
                    {
                        thanhtiencu = sv.ThanhTien;
                        db.CT_HOADONDV.Remove(sv);
                        db.SaveChanges();

                        // cap nhat so luong ton
                        hang.SLTon += sv.SoLuong;
                        db.SaveChanges();
                        //cap nhat tong tien hoa don
                        var hd = new MMHOADONDV();
                        hd.UpdateTongTien(sv.ID_HoaDonDV,hd.GetOne(sv.ID_HoaDonDV).TongTien - thanhtiencu);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAllHoaDon(int idhaodon)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HOADONDV
                            where s.ID_HoaDonDV == idhaodon
                            select s;
                    foreach (var sv in x)
                    {
                        if (sv != null)
                        {
                            //cap nhat so luong ton
                            var hang = (from s in db.HANGs where s.ID == sv.ID_Hang select s).FirstOrDefault();
                            hang.SLTon += sv.SoLuong;

                            db.CT_HOADONDV.Remove(sv);
                            db.SaveChanges();
                        }
                    }
                    var y = (from s in db.HOADONDVs
                            where s.ID == idhaodon
                            select s).FirstOrDefault();
                    if (y != null)
                    {
                        (new MMHOADONDV()).Delete(y.ID);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CT_HOADONDV item)
        {
            decimal thanhtiencu = 0 ;
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.CT_HOADONDV
                        where s.ID_HoaDonDV == item.ID_HoaDonDV && s.ID_Hang == item.ID_Hang
                        select s;
                    var sv = x.FirstOrDefault();
                    var hang = (from s in db.HANGs where s.ID == sv.ID_Hang select s).FirstOrDefault();

                    if (sv != null)
                    {
                        thanhtiencu = sv.ThanhTien;
                        var soluongcu = sv.SoLuong;

                        sv.SoLuong = item.SoLuong;
                        sv.DonGia = item.DonGia;
                        sv.ThanhTien = item.ThanhTien;
                        db.SaveChanges();

                        //cap nhat soluong
                        hang.SLTon = hang.SLTon + soluongcu - sv.SoLuong;
                        db.SaveChanges();

                        var hd = new MMHOADONDV(); //khi cap nhat thi cap nhat lai tong tien
                        var tongtien = hd.GetOne(sv.ID_HoaDonDV).TongTien - thanhtiencu + item.ThanhTien;
                        hd.UpdateTongTien(sv.ID_HoaDonDV,tongtien);
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