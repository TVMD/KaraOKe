using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVIEW;
using MODEL;
using System.Data;


namespace PRESENTER
{
    public class PPhong
    {
        private readonly MPhong model;
        private readonly MLoaiPhong modelLoaiPhong;
        private readonly IPhong view;

        public PPhong(IPhong x)
        {
            view = x;
            model = new MPhong();
            modelLoaiPhong = new MLoaiPhong();
        }

        public DataTable List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                view.Message = "Resource not found!. ds phong = null";
            }

            var tb = new DataTable();
            tb.Columns.Add("ID");
            tb.Columns.Add("Ten");
            tb.Columns.Add("GiaNgay");
            tb.Columns.Add("GiaDem");
            tb.Columns.Add("TinhTrang");

            foreach (var item in dt)
            {
                var tenkhoa = modelLoaiPhong.Get1LoaiPhong(item.IdLoaiPhong);
                string tamp;
                if(item.StatusID==1)
                    tamp="Using";
                else tamp="None";
                tb.Rows.Add(item.ID, item.Ten, tenkhoa.GiaDem, tenkhoa.GiaNgay, tamp);
            }

            return tb;
        }

        public bool Inseart()
        {
            var sv = new PHONG
            {
                
                Ten = view.Ten,
                IdLoaiPhong=view.IdLoaiPhong,
                StatusID=0};
            return model.Insert(sv);
        }

        public bool Delete()
        {
            return model.Delete(view.ID);
        }

        public bool Update()
        {
            var sv = new PHONG
            {
                ID = view.ID,
                Ten = view.Ten,
                StatusID = view.StatusID,
                IdLoaiPhong = view.IdLoaiPhong,
                TGStart = view.TGStart,
            };
            return model.Update(sv);
        }

        public List<LOAIPHONG> GetAllLoaiPhong()
        {
            
            var dt = modelLoaiPhong.List(null);
            if (dt == null)
            {
                view.Message = "Resource not found!. dtkhoa = null";
                return null;
            }
            return dt;
        }
    }
}
