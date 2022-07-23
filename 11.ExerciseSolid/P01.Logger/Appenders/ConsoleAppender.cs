using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender()
        {
            this.Count = 0;
        }

        public ConsoleAppender(ILayout layout)
            : this()
        {
            this.Layout = layout;
        }

        public int Count { get; private set; }

    public ILayout Layout { get; }

        public void Append(IMessage message)
        {
            string formattedMessage = this.FormatMessage(message);
            Console.WriteLine(formattedMessage);
        }
        private string FormatMessage(IMessage message) 
            => string.Format(
                this.Layout.Format, 
                message.LogTime, 
                message.Level.ToString(),
                message.MessageText
                );
        
    }
}
