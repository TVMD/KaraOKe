using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using IVIEW;
using MODEL;

namespace PRESENTER
{
    public class PThamSo 
    {
        private readonly MMThamSo model;
        private readonly IThamSo view;
        public PThamSo(IThamSo x)
        {
            view = x;
            model = new MMThamSo();
        }

        public DataTable List(string search)
        {
            var dt = model.List(search);
            if (dt == null)
            {
                view.Message = "Resource not found!. null";
                return null;
            }

            var tb = new DataTable();
            tb.Columns.Add("Name");
            tb.Columns.Add("Value");
            foreach (var item in dt)
            {
                tb.Rows.Add(item.Name,
                    item.Value
                    );
            }
            return tb;
        }

        public bool Inseart()
        {
            var hd = new THAMSO()
            {
                Name = view.Name,
                Value = view.Value
            };
            return model.Insert(hd);
        }

        public bool Update()
        {
            var ct = new THAMSO()
            {
                Name = view.Name,
                Value = view.Value
            };
            return model.Update(ct);
        }

        public THAMSO GetOne(string name)
        {
            return model.GetOne(name);
        }
    }
}
