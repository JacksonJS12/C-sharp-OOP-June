namespace ConsoleLogger
{
    using System;

    using SoftUniLogger;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IMessage message = new Message("3/26/2015 2:08:11 PM", "Error occurred!" ,ReportLevel.Error); //hard coded message

            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.Append(message);
        }
    }
}
