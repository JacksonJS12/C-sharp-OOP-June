namespace SoftUniLogger
{
    using System.IO;
    using System.Text;

    partial class FileWriter : IFileWriter
    {
        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }
        public string FilePath { get; set; }

        public void WriteContent(string content, string fileName)
        {
            string outputPath = Path.Combine(this.FilePath, fileName);

            File.WriteAllText(outputPath, content, Encoding.UTF8);
        }
    }
}
