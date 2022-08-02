using CommandPattern.Core.Contracts;
using P01.CommandPattern.IO.Contracts;
using System;

namespace P01.CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
        {
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string result = this.commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
