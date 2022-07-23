namespace SoftUniLogger
{
    public interface IFileAppender : IAppender
    {
        ILogFile LogFile { get; }
        void SaveLogFile(string filename);
    }
}
