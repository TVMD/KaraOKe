using System;
using System.Collections.Generic;
using System.Data;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public class PMPhong
    {
        private readonly MMPhong model;
        private readonly MMLoaiPhong modelLoaiPhong;
        private readonly IMPhong view;

        public PMPhong(IMPhong x)
        {
            view = x;
            model = new MMPhong();
            modelLoaiPhong = new MMLoaiPhong();
        }

        public DataTable List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                view.Message = "Resource not found!. null";
            }

            var tb = new DataTable();
            tb.Columns.Add("ID");
            tb.Columns.Add("Ten");
            tb.Columns.Add("StatusId");
            tb.Columns.Add("TGStart");
            tb.Columns.Add("IdLoaiPhong");
            tb.Columns.Add("TenLoaiPhong");
            tb.Columns.Add("GiaNgay");
            tb.Columns.Add("GiaDem");
            foreach (var item in dt)
            {
                var loaiphong = modelLoaiPhong.GetOne(item.IdLoaiPhong);
                tb.Rows.Add(item.ID,
                    item.Ten,
                    item.StatusID,
                    item.TGStart,
                    item.IdLoaiPhong,
                    loaiphong.Ten,
                    loaiphong.GiaNgay,
                    loaiphong.GiaDem);
            }
            return tb;
        }

        public bool Inseart()
        {
            var phong = new PHONG()
            {
                ID = 0,
                Ten = view.Ten,
                StatusID = 1,
                TGStart = null,
                IdLoaiPhong = view.IdLoaiPhong
            };
            return model.Insert(phong);
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }

        public bool Update()
        {
            var phong = new PHONG()
            {
                ID = view.ID,
                Ten = view.Ten,
                IdLoaiPhong = view.IdLoaiPhong
            };
            return model.Update(phong);
        }

        public List<LOAIPHONG> GetAllLoaiPhong()
        {
            var dt = modelLoaiPhong.List(null);
            if (dt == null)
            {
                view.Message = "Resource not found!";
                return null;
            }
            return dt;
        }

        public PHONG GetOne(int ID)
        {
            return model.GetOne(ID);
        }

        public bool Begin(string tenkh)
        {
            return model.Begin(view.ID,view.TGStart, tenkh);
        }

        public bool End()
        {
            return model.End(view.ID);
        }
    }
}