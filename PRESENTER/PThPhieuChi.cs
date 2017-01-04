using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public class PThPhieuChi
    {
         private readonly  MThPhieuChi model;
        private readonly IThPhieuChi view;

        public PThPhieuChi(IThPhieuChi x)
        {
            view = x;
            model = new MThPhieuChi();
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
            tb.Columns.Add("NgayLap");
            tb.Columns.Add("NoiDung");
            tb.Columns.Add("TongTien");
            tb.Columns.Add("GhiChu");
          
            foreach (var item in dt)
            {
                tb.Rows.Add(item.ID,
                    String.Format("{0:dd/MM/yyyy}", item.NgayLap),
                  //  item.NgayLap,
                    item.NoiDung,
                    item.TongTien,
                    item.GhiChu
                   
                    );
            }
            return tb;
        }

        public bool Inseart()
        {
            var phieuchi = new PHIEUCHI()
            {
                ID = 0,
                NgayLap = view.NgayLap,
                NoiDung = view.NoiDung,
                TongTien = view.TongTien,
                GhiChu = view.GhiChu
            };
            return model.Insert(phieuchi);
        }

        public bool Delete()
        {
           return model.Delete(view.ID);
        }

        public bool Update()
        {
            var ct = new PHIEUCHI()
            {
                ID = view.ID,
                NgayLap = view.NgayLap,
                NoiDung = view.NoiDung,
                TongTien = view.TongTien,
                GhiChu = view.GhiChu,
              
            };
            return model.Update(ct);
        }

        public PHIEUCHI GetOne(int id)
        {
            return model.GetOne(id);
        }
    }
}
