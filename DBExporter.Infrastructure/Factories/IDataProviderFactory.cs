using DbExportTool.Core.Abstractions;

namespace DBExporter.Infrastructure.Factories
{
    public interface IDataProviderFactory
    {
        IDataProvider Create(string connectionString);
    }
}
