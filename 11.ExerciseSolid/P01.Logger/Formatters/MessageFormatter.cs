﻿using System;
using System.Collections.Generic;
namespace SoftUniLogger
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal class MessageFormatter : IFormatter
    {
        public MessageFormatter(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public string FormatMessage(IMessage message)
            => String.Format(this.Layout.Format,
                message.LogTime, message.Level.ToString(), message.MessageText);
    }
}
