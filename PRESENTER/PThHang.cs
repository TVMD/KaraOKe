using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using IVIEW;
using System.Data;

namespace PRESENTER
{
    public class PThHang
    {
         private readonly MThHang model;
        private readonly IThHang view;

        public PThHang(IThHang x)
        {
            view = x;
            model = new MThHang();
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
            tb.Columns.Add("DonGIaNhap");
            tb.Columns.Add("DonGiaBan");
            tb.Columns.Add("SLTon");
            tb.Columns.Add("DonVi");
        //    tb.Columns.Add("Requested");
            
            foreach (var item in dt)
            {
                tb.Rows.Add(item.ID,
                    item.Ten,
                    item.DonGiaNhap,
                    item.DonGiaBan,
                    item.SLTon,
                    item.DonVi
                    );
            }
            return tb;
        }

        public bool Inseart()
        {
            var hang = new HANG()
            {
                ID = 0,
                Ten = view.Ten,
                DonGiaNhap = view.DonGiaNhap,
                DonGiaBan = view.DonGiaBan,
                SLTon = view.SLTon,
                DonVi = view.DonVi,
              //  Requested = view.Requested
            };
            return model.Insert(hang);
        }

        public bool Delete()
        {
            return model.Delete(view.ID);
        }

        public bool Update()
        {
            var ct = new HANG()
            {
                ID = view.ID,
                Ten = view.Ten,
                DonGiaNhap = view.DonGiaNhap,
                DonGiaBan = view.DonGiaBan,
                SLTon = view.SLTon,
                DonVi = view.DonVi,
             //   Requested = view.Requested
            };
            return model.Update(ct);
        }

        public HANG GetOne(int id)
        {
            return model.GetOne(id);
        }
    }
}
