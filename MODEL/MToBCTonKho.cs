using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MToBCTonKho
    {
        public List<BCTONKHO> GetListBaoCao()                       //getlist cho radgrid 1
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    IEnumerable<BCTONKHO> query = from s in db.BCTONKHOes select s;
                    return query.ToList();
                }
            }
            catch { return null; }
        }
        public List<GetListBCTonKho_Result> GetList(DateTime date)      //get list luc add bc
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    IEnumerable<GetListBCTonKho_Result> query = db.GetListBCTonKho(date);
                    return query.ToList();
                }
            }
            catch { return null; }
        }
        public DataTable GetListCT_BaoCao(int id_bc)                       //getlist cho radgrid 2
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var query = from s in db.CT_BCTONKHO join h in db.HANGs on s.ID_Hang equals h.ID where s.ID_BCTonKho==id_bc select new{
                        s.ID_Hang,s.SoLuongNhap,s.SuDung,s.TonCuoi,s.TonDau,h.Ten
                    };
                    var tb = new DataTable();
                    tb.Columns.Add("ID");
                    tb.Columns.Add("Ten");
                    tb.Columns.Add("tondau");
                    tb.Columns.Add("soluongnhap");
                    tb.Columns.Add("sudung");
                    tb.Columns.Add("toncuoi");
                    foreach (var item in query.ToList())
                    {
                        tb.Rows.Add(item.ID_Hang,
                            item.Ten,
                            item.TonDau,
                            item.SoLuongNhap,
                            item.SuDung,
                            item.TonCuoi                          
                            );
                    }
                    return tb;
                }
            }
            catch { return null; }
        }

        public bool Insert(BCTONKHO item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.BCTONKHOes.Add(item);
                    db.SaveChanges();
                    //lay id BC
                    int id =  (from s in db.BCTONKHOes where s.Thang == item.Thang select s.ID).FirstOrDefault() ;
                    
                    List<GetListBCTonKho_Result> _ctbc = GetList(item.Thang);
                    for(int i = 0; i<_ctbc.Count; i++)
                    {
                        CT_BCTONKHO ctbc = new CT_BCTONKHO();
                        ctbc.ID_BCTonKho = id;
                        ctbc.ID_Hang = _ctbc[i].ID;
                        ctbc.TonDau = _ctbc[i].tondau.GetValueOrDefault();
                        ctbc.SuDung = _ctbc[i].soluongban.GetValueOrDefault();
                        ctbc.SoLuongNhap = _ctbc[i].soluongnhap.GetValueOrDefault();
                        ctbc.TonCuoi = _ctbc[i].toncuoi.GetValueOrDefault();
                        db.CT_BCTONKHO.Add(ctbc);
                        db.SaveChanges();

                    }


                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool checkMonth(DateTime date)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                var id = (from s in db.BCTONKHOes where s.Thang.Year == date.Year && s.Thang.Month == date.Month select s);
                if (id.ToList().Count >0) //ton tai
                    return false;
                
            }
            return true;
        }
    }
}
