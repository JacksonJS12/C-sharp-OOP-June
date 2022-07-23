using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger
{
    public interface IMessage
    {
        string LogTime { get; }
        string MessageText { get; }
        ReportLevel Level { get; }
    }
}
