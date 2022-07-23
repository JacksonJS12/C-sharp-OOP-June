namespace SoftUniLogger
{
    using System.Collections.Generic;


    partial interface ILogger
    {
        void Info(string logTime, string message, ReportLevel level);
        void Warning(string logTime, string message, ReportLevel level);
        void Error(string logTime, string message, ReportLevel level);
        void Crirical(string logTime, string message, ReportLevel level);
        void Fatal(string logTime, string message, ReportLevel level);
    }
}
