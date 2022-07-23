using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    public class SimpleLayout : ILayout
    {
        public string Format
            => "{0} - {1} - {2}";
            // "<date-time> - <report level> - <message>";
    }
}
