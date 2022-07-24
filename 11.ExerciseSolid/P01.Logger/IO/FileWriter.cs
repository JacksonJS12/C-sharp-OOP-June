namespace SoftUniLogger
{
    using System.IO;
    using System.Text;

    public class FileWriter : IFileWriter
    {
        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }
        public string FilePath { get; set; }

        public void WriteContent(string content, string fileName)
        {
            string outputPath = Path.Combine(this.FilePath, fileName);
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            File.WriteAllText(outputPath, content, Encoding.UTF8);
        }
    }
}
