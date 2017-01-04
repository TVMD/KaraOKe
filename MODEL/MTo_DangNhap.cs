using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MTo_DangNhap
    {
        public NGUOIDUNG KiemTraTaiKhoan(string user, string password)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = (from s in db.NGUOIDUNGs
                            where s.MaDangNhap == user && s.MatKhau == password
                            select s).FirstOrDefault();
                    return x;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public NHOMQUYEN LayNhomQuyen(NGUOIDUNG user)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = (from s in db.NHOMQUYENs
                             where s.MaNhomQuyen == user.MaNhomQuyen
                             select s).FirstOrDefault();
                    return x;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
