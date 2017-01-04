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
    }
}
