using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    internal interface IFormatter 
    {
        ILayout Layout { get; }
        string FormatMessage(IMessage message);
    }
}
