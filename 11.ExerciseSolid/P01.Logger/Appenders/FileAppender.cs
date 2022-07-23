namespace SoftUniLogger.Appenders
{
    public class FileAppender : IAppender, IFileAppender
    {
        private readonly IFormatter formatter;
        private FileAppender()
        {
            this.Count = 0;
        }
        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.formatter = new MessageFormatter(this.Layout);
        }
        public int Count { get; }

        public ILayout Layout { get; }
        public ILogFile LogFile { get; }
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
