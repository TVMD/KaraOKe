using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public  class PMLoaiPhong
    {
        private readonly MMLoaiPhong model;
        private readonly IMLoaiPhong view;

        public PMLoaiPhong(IMLoaiPhong x)
        {
            view = x;
            model = new MMLoaiPhong();
        }

        public DataTable List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                view.Message = "Resource not found!. null";
                return null;
            }

            var tb = new DataTable();
            tb.Columns.Add("ID");
            tb.Columns.Add("Ten");
            tb.Columns.Add("GiaNgay");
            tb.Columns.Add("GiaDem");
            foreach (var item in dt)
            {
                tb.Rows.Add(item.ID,
                    item.Ten,
                    item.GiaNgay,
                    item.GiaDem
                    );
            }
            return tb;
        }

        public bool Inseart()
        {
            var loaiphong = new LOAIPHONG()
            {
                ID = 0,
                Ten = view.Ten,
                GiaNgay = view.GiaNgay,
                GiaDem = view.GiaDem
            };
            return model.Insert(loaiphong);
        }

        public bool Delete()
        {
            return model.Delete(view.ID);
        }

        public bool Update()
        {
            var ct = new LOAIPHONG()
            {
                ID = view.ID,
                Ten = view.Ten,
                GiaNgay = view.GiaNgay,
                GiaDem = view.GiaDem
            };
            return model.Update(ct);
        }

        public LOAIPHONG GetOne(int id)
        {
            return model.GetOne(id);
        }
    }
}
