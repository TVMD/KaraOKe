using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using IVIEW;
using System.Data;

namespace PRESENTER
{
    public class PToBCTonKho
    {
        private readonly IToBCTonKho iView;
        public PToBCTonKho(IToBCTonKho x)
        {
            iView = x;
        }
        public List<BCTONKHO> GetListBaoCao()
        {
            MToBCTonKho svModel = new MToBCTonKho();
            return svModel.GetListBaoCao();
        }
        public List<GetListBCTonKho_Result> GetList(DateTime date)
        {
            MToBCTonKho svModel = new MToBCTonKho();
            return svModel.GetList(date);
        }
        public DataTable GetListCT_BaoCao(int id_bc)               
        {
            MToBCTonKho svModel = new MToBCTonKho();
            return svModel.GetListCT_BaoCao(id_bc);
        }
        public void Insert()
        {
            var bc = new BCTONKHO()
            {
                Thang = iView.date
            };
            var model = new MToBCTonKho();
            model.Insert(bc);
        }

    }
}
