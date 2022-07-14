using System;
using Telephony.Core;
using Telephony.Input_Output;
using Telephony.Input_Output.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWritter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
