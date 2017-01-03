using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public class PMHang // se co phang cua thang tien lam, cai nay t tu xai nen k can view
    {
        private readonly MMHang model;

        public PMHang()
        {
            model = new MMHang();
        }

        public DataTable List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                return null;
            }

            var tb = new DataTable();
            tb.Columns.Add("ID");
            tb.Columns.Add("Ten");
            tb.Columns.Add("DonGiaNhap");
            tb.Columns.Add("DonGiaBan");
            tb.Columns.Add("SLTon");
            foreach (var item in dt)
            {
                tb.Rows.Add(item.ID,
                    item.Ten,
                    item.DonGiaNhap,
                    item.DonGiaBan,
                    item.SLTon);
            }
            return tb;
        }

        public HANG GetOne(int idhang)
        {
            return model.GetOne(idhang);
        }
    }
}
