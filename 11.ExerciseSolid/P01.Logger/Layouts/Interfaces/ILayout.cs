using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    public interface ILayout
    {
        string Format { get; }
    }
}
