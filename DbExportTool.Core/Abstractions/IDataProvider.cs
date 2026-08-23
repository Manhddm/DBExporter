
namespace DbExportTool.Core.Abstractions
{
    public interface IDataProvider
    {
        (string tableName, IEnumerable<IDictionary<string, object>> data) GetData(string connectionString, string query, bool isTableName);
    }
}
