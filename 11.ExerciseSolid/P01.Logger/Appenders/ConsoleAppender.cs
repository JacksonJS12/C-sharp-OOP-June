﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    public class ConsoleAppender : IAppender
    {
        private readonly IFormatter formatter;
        public ConsoleAppender()
        {
            this.Count = 0;

            this.formatter = new MessageFormatter(this.Layout);
        }

        public ConsoleAppender(ILayout layout, ReportLevel level)
            : this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public int Count { get; private set; }

    public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public void Append(IMessage message)
        {
            string formattedMessage = this.formatter.FormatMessage(message);

            Console.WriteLine(formattedMessage);
            this.Count++;
        }
        
    }
}
