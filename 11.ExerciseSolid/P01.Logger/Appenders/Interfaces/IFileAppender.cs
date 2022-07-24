namespace SoftUniLogger
{
    public interface IFileAppender : IAppender
    {
        ILogFile LogFile { get; }
        ReportLevel Level { get; }
        void SaveLogFile(string filename);
    }
}
