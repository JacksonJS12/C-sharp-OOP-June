using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    public interface IAppender
    {
        int Count { get; }
        ILayout Layout { get; }
        void Append(IMessage message);
    }
}
