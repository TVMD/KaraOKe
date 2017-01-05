using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using IVIEW;

namespace PRESENTER
{
    public class PToBaoCaoDoanhThu
    {
        private readonly IToBCDoanhThu iView;
        public PToBaoCaoDoanhThu(IToBCDoanhThu x){
            iView = x;
        }
        public List<GetListBCDoanhThu_Result> GetListBCDoanhThu()
        {
            MToBaoCaoDoanhThu svModel = new MToBaoCaoDoanhThu();
            return svModel.GetListHoaDon(iView.dateFrom, iView.dateTo);
        }
        public List<PHIEUCHI> GetListBCPhieuChi()
        {
            MToBaoCaoDoanhThu svModel = new MToBaoCaoDoanhThu();
            return svModel.GetListPhieuChi(iView.dateFrom, iView.dateTo);
        }

        public string getTongTien()
        {
            MToBaoCaoDoanhThu svModel = new MToBaoCaoDoanhThu();
            return svModel.getTongTien(iView.dateFrom, iView.dateTo);
        }
        public string getTongChi()
        {
            MToBaoCaoDoanhThu svModel = new MToBaoCaoDoanhThu();
            return svModel.getTongTienChi(iView.dateFrom, iView.dateTo);
        }
    }
}
