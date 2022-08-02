using P01.CommandPattern.IO.Contracts;
using System;

namespace P01.CommandPattern.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
