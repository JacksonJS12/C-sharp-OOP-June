namespace SoftUniLogger
{
    using System.Collections.Generic;


    partial interface ILogger
    {
        void Info(string logTime, string message);
        void Warning(string logTime, string message);
        void Error(string logTime, string message);
        void Crirical(string logTime, string message);
        void Fatal(string logTime, string message);
    }
}
