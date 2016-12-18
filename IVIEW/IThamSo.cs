using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVIEW
{
    public interface IThamSo : IShare
    {
        string Name { get; set; }
        string Value { get; set; }
    }
}
