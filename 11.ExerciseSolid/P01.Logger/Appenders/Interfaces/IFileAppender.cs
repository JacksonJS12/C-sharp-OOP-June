namespace SoftUniLogger
{
    public interface IFileAppender
    {
        ILogFile LogFile { get; }
        void SaveLogFile(string filename);
    }
}
