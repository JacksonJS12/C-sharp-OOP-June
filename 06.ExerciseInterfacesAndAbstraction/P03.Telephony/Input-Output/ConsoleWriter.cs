using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Input_Output.Interfaces;

namespace Telephony.Input_Output
{
    public class ConsoleWritter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
