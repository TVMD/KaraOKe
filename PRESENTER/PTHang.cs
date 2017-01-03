using System.Collections.Generic;
using System.Data;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public class PTHang
    {
        private readonly M_Hang_Tien model;
        private readonly ITHang view;

        public PTHang(ITHang x)
        {
            view = x;
            model = new M_Hang_Tien();
        }

        public DataTable List(string search)
        {
            var dt = model.List();
            if (dt == null)
            {
                view.Message = "Resource not found!. null";
            }

            var tb = new DataTable();
            tb.Columns.Add("ID");
            tb.Columns.Add("Ten");
            tb.Columns.Add("DonGiaNhap");
            tb.Columns.Add("DonGiaBan");
            tb.Columns.Add("SLTon");
            tb.Columns.Add("DonVi");
            tb.Columns.Add("Requested");
            foreach (var item in dt)
            {
                
                tb.Rows.Add(item.ID,
                    item.Ten,
                    item.DonGiaNhap,
                    item.DonGiaBan,
                    item.SLTon,
                    item.DonVi,
                    item.Requested);
            }
            return tb;
        }

        public bool Inseart()
        {
            var phong = new HANG()
            {
                
                Ten = view.Ten,
                DonGiaBan=view.DonGiaBan,
                DonGiaNhap=view.DonGiaNhap,
                SLTon=view.SLTon,
                DonVi=view.DonVi,
                Requested=view.Requested
            };
            return model.Insert(phong);
        }

       
  
    }
}
