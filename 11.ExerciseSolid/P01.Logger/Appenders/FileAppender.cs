namespace SoftUniLogger
{
    public class FileAppender : IFileAppender
    {
        private readonly IFormatter formatter;
        private FileAppender()
        {
            this.Count = 0;
        }
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel level)
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.formatter = new MessageFormatter(this.Layout);
            this.Level = level;
        }
        public int Count { get; }

        public ILayout Layout { get; }
        public ILogFile LogFile { get; }

        public ReportLevel Level { get; }

        public void Append(IMessage message)
        {
            string formattedMessage = this.formatter.FormatMessage(message);
            this.LogFile.Write(formattedMessage);
        }

        public void SaveLogFile(string filename)
        {
            this.LogFile.SaveAs(filename);
        }
    }
}
