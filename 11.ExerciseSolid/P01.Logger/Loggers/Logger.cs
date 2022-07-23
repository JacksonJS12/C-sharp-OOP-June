namespace SoftUniLogger
{
    using System.Collections.Generic;


    public class Logger : IAppenderCollection, ILogger
    {
        private readonly ICollection<IAppender> appenders;
        private Logger()
        {
            this.appenders = new HashSet<IAppender>();
        }
        public Logger(params IAppender[] appenders)
            : this()
        {
            this.appenders.AddRange(appenders);
        }
        public IReadOnlyCollection<IAppender> Appenders
            => this.appenders.AsReadOnly();

        public void AddAppender(IAppender appender)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void Crirical(string logTime, string message, ReportLevel level)
        {
            throw new System.NotImplementedException();
        }

        public void Error(string logTime, string message, ReportLevel level)
        {
            throw new System.NotImplementedException();
        }

        public void Fatal(string logTime, string message, ReportLevel level)
        {
            throw new System.NotImplementedException();
        }

        public void Info(string logTime, string message, ReportLevel level)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveAppender(IAppender appender)
        {
            throw new System.NotImplementedException();
        }

        public void Warning(string logTime, string message, ReportLevel level)
        {
            throw new System.NotImplementedException();
        }
    }
}
