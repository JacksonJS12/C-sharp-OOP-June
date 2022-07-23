using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    public interface IMessage
    {
        string LogTime { get; }
        string MessageText { get; }
        ReportLevel Level { get; }
    }
}
