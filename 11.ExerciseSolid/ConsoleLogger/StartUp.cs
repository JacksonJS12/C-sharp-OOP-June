namespace ConsoleLogger
{
    using System;

    using SoftUniLogger;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new XmlLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout, ReportLevel.Info);

            IFileWriter fw = new FileWriter("../../../Logs/");
            ILogFile file = new LogFile(fw);
            IFileAppender fileAppender = new FileAppender(xmlLayout, file, ReportLevel.Error);

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
            logger.SaveLogs("log");
        }
    }
}
