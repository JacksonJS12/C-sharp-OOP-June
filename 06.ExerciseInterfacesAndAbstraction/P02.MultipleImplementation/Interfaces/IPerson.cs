using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPerson
    {
        int Age { get; set; }
        string Name { get; set; }
    }
}
