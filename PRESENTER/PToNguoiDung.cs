using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using IVIEW;

namespace PRESENTER
{
    public class PToNguoiDung
    {
        private readonly MToNguoiDung model;
        private readonly IToNguoiDung view;

        public PToNguoiDung(IToNguoiDung x)
        {
            view = x;
            model = new MToNguoiDung();
        }

        public List<GetListNguoiDung_Result> List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                //view.Message = "Resource not found!. null";
            }            
            return dt;
        }

        public bool Insert()
        {
            var user = new NGUOIDUNG()
            {
                MaDangNhap = view.MaDangNhap,
                MatKhau = view.MatKhau,
                HoTen = view.HoTen,
                Email = view.Email,
                SoDT = view.SoDT,
                MaNhomQuyen = view.MaNhomQuyen
            };
            return model.Insert(user);
        }

        public bool Delete()
        {
            return model.Delete(view.ID);
        }

        public bool Update()
        {
            var user = new NGUOIDUNG()
            {
                ID = view.ID,
                MaDangNhap = view.MaDangNhap,
                MatKhau = view.MatKhau,
                HoTen = view.HoTen,
                Email = view.Email,
                SoDT = view.SoDT,
                MaNhomQuyen = view.MaNhomQuyen,
            };
            return model.Update(user);
        }

        public List<NHOMQUYEN> ListNhomQuyen()
        {
            var dt = model.ListNhomQuyen();
            if (dt == null)
            {
                //view.Message = "Resource not found!";
                return null;
            }
            return dt;
        }        
    }
}
