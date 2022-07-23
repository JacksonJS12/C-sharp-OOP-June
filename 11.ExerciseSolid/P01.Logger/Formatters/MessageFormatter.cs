using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger
{
    internal class MessageFormatter : IFormatter
    {
        public MessageFormatter(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public string FormatMessage(IMessage message)
          => string.Format(
                this.Layout.Format,
                message.LogTime,
                message.Level.ToString(),
                message.MessageText
                );
    }
}
