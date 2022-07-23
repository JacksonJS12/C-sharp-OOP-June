﻿namespace SoftUniLogger
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message : IMessage
    {
        private const string EmptyLogTimeMessage = "Argument cannot be null or empty string!";

        private string logTime;
        private string messageText;

        private readonly IValidator dateTimeValidator;

        public Message()
        {
            this.dateTimeValidator = new DateTimeValidator();
        }

        public Message(string logTime, string messageText, ReportLevel level)
            : this()
        {
            this.LogTime = logTime;
            this.MessageText = messageText;
            this.Level = level;
        }

        public string LogTime
        {
            get
            {
                return this.logTime;
            }
            private set
            {
                if (!this.dateTimeValidator.IsValid(value))
                {
                    throw new InvalidDataTimeFormatException();
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(LogTime), EmptyLogTimeMessage);
                }
                this.logTime = value;
            }
        }
        public string MessageText
        {
            get
            {
                return this.messageText;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.LogTime), EmptyLogTimeMessage);
                }
                this.messageText = value;
            }
        }
        public ReportLevel Level { get; }
    }
}