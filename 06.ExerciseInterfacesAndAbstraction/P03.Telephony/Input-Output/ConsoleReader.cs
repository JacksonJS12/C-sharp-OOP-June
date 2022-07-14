using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Input_Output.Interfaces;

namespace Telephony.Input_Output
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
