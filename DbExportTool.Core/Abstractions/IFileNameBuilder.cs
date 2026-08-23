using DbExportTool.Core.Models;

namespace DbExportTool.Core.Abstractions
{
    public interface IFileNameBuilder
    {
        string Build(ExportOptions options, string defaultTableName);
    }
}
