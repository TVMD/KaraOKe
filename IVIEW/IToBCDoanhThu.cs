using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IToBCDoanhThu :IShare
    {
        DateTime dateFrom { get; set; }
        DateTime dateTo { get; set; }
    }
}
