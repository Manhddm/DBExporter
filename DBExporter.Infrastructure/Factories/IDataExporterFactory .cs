using DbExportTool.Core.Abstractions;
using DbExportTool.Core.Models;

namespace DBExporter.Infrastructure.Factories
{
    public interface IDataExporterFactory
    {
        IDataExporter Create(ExportFormat format);
    }
}
