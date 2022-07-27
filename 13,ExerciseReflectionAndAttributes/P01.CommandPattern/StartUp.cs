using CommandPattern.Core.Contracts;
using P01.CommandPattern.Core;
using P01.CommandPattern.IO;
using P01.CommandPattern.IO.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command, writer, reader);
            engine.Run();
        }
    }
}
