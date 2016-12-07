//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MODEL
//{
//    public class MKhoa
//    {
//        public List<Khoa> List(string search)
//        {
//            using (var db = new demoEntities1())
//            {
//                var query = from s in db.Khoas select s;

//                //Filter // neu de search=null thi kho search,
//                if (!string.IsNullOrEmpty(search))
//                {
//                    query = query.Where(x => (x.ID != null &&
//                                              x.ID.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
//                                             (x.TenKhoa != null &&
//                                              x.TenKhoa.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >=
//                                              0)
//                        );
//                }

//                return query.ToList();
//            }
//        }

//        public string GetTen(long idkhoa)
//        {
//            if (idkhoa == 0)
//                return "";
//            using (var db = new demoEntities1())
//            {
//                var query = (from k in db.Khoas select k).Where(x => x.ID == idkhoa).FirstOrDefault().TenKhoa;
//                return query;
//            }
//        }
//    }
//}