//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MODEL
//{
//    public class MSinhVien
//    {
//        public List<SinhVien> List(string search)
//        {
//            using (var db = new demoEntities1())
//            {
//                IEnumerable<SinhVien> query = from s in db.SinhViens select s;

//                //Filter // neu de search=null thi kho search,
//                if (!string.IsNullOrEmpty(search))
//                {
//                    query = query.Where(x => (x.ID != null &&
//                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
//                                             (x.Ten != null &&
//                                              x.Ten.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
//                                             (x.IDKhoa != null &&
//                                              x.IDKhoa.Value.ToString()
//                                                  .IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
//                        );
//                }

//                return query.ToList();
//            }
//        }

//        public bool Insert(SinhVien sv)
//        {
//            try
//            {
//                using (var db = new demoEntities1())
//                {
//                    db.SinhViens.Add(sv);
//                    db.SaveChanges();
//                }
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public bool Delete(int ID)
//        {
//            try
//            {
//                using (var db = new demoEntities1())
//                {
//                    var x = from s in db.SinhViens
//                        where s.ID == ID
//                        select s;
//                    var sv = x.FirstOrDefault();
//                    if (sv != null)
//                    {
//                        db.SinhViens.Remove(sv);
//                        db.SaveChanges();
//                    }
//                }
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public bool Update(SinhVien sinhvien)
//        {
//            try
//            {
//                using (var db = new demoEntities1())
//                {
//                    var x = from s in db.SinhViens
//                        where s.ID == sinhvien.ID
//                        select s;
//                    var sv = x.FirstOrDefault();
//                    if (sv != null)
//                    {
//                        sv.Ten = sinhvien.Ten;
//                        sv.IDKhoa = sinhvien.IDKhoa;
//                        db.SaveChanges();
//                    }
//                }
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }
//    }
//}