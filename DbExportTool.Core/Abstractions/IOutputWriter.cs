namespace DbExportTool.Core.Abstractions
{
    public interface IOutputWriter
    {
        void Write(Stream output, string destinationFilePath);
    }
}
