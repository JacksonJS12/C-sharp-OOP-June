using System;

namespace SoftUniLogger
{
    internal class Engine : IEngine
    {
        private readonly ILogger logger;
        public Engine()
        {
            this.logger = new Logger();
        }
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] appenderarags = Console.ReadLine()
                    .Split();
            }
        }
    }
}
