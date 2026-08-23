namespace DbExportTool.Core.Abstractions
{
    public interface IDataExporter
    {
        void Export(IEnumerable<IDictionary<string, object>> data, Stream outputStream, string tableName);
    }
}
