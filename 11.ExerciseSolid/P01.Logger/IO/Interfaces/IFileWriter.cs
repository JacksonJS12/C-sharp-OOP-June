namespace SoftUniLogger
{
    public interface IFileWriter
    {
        string FilePath { get; set; }
        void WriteContent(string content, string fileName);

    }
}
