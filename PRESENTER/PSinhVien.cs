//using System.Collections.Generic;
//using System.Data;
//using IVIEW;
//using MODEL;

//namespace PRESENTER
//{
//    public class PSinhVien
//    {
//        private readonly MSinhVien model;
//        private readonly MKhoa modelkhoa;
//        private readonly ISinhVien view;

//        public PSinhVien(ISinhVien x)
//        {
//            view = x;
//            model = new MSinhVien();
//            modelkhoa = new MKhoa();
//        }

//        public DataTable List(string search)
//        {
//            var dt = model.List(search);
//            if (dt == null)
//            {
//                view.Message = "Resource not found!. dtsinhvien = null";
//            }

//            var tb = new DataTable();
//            tb.Columns.Add("ID");
//            tb.Columns.Add("Ten");
//            tb.Columns.Add("IDKhoa");
//            tb.Columns.Add("TenKhoa");

//            foreach (var item in dt)
//            {
//                var tenkhoa = modelkhoa.GetTen(item.IDKhoa.Value);
//                tb.Rows.Add(item.ID, item.Ten, item.IDKhoa, tenkhoa);
//            }

//            return tb;
//        }

//        public bool Inseart()
//        {
//            var sv = new SinhVien
//            {
//                ID = view.ID,
//                Ten = view.Ten,
//                IDKhoa = view.IDKhoa
//            };
//            return model.Insert(sv);
//        }

//        public bool Delete()
//        {
//            return model.Delete(view.ID);
//        }

//        public bool Update()
//        {
//            var sv = new SinhVien
//            {
//                ID = view.ID,
//                Ten = view.Ten,
//                IDKhoa = view.IDKhoa
//            };
//            return model.Update(sv);
//        }

//        public List<Khoa> GetAllKhoa()
//        {
//            var khoamodel = new MKhoa();
//            var dt = khoamodel.List(null);
//            if (dt == null)
//            {
//                view.Message = "Resource not found!. dtkhoa = null";
//                return null;
//            }
//            return dt;
//        }
//    }
//}