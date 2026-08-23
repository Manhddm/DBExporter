using DbExportTool.Core.Abstractions;

namespace DBExporter.Infrastructure.Factories
{
    public class SqlDataProviderFactory : IDataProviderFactory
    {
        public IDataProvider Create(string connectionString) => new SqlDataProvider();
    }
}
