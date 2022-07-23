using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger
{
    public interface IAppender
    {
        int Count { get; }
        ILayout Layout { get; }
        ReportLevel Level { get; }
        void Append(IMessage message);
    }
}
