using DbExportTool.Core.Abstractions;

namespace DBExporter.Infrastructure.Writers
{
    public class FileOutputWriter : IOutputWriter
    {
        public void Write(Stream output, string destinationFilePath)
        {
            output.Position = 0;
            using var fileStream = File.Create(destinationFilePath);
            output.CopyTo(fileStream);
        }
    }
}
