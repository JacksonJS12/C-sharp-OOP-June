using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger
{
    public class InvalidDataTimeFormatException : Exception
    {
        private const string DefaultMessage = "Provided DtaTime was not in correct format!";
        public InvalidDataTimeFormatException()
            : base(DefaultMessage)
        {

        }
    }
}
