using DbExportTool.Core.Abstractions;
using DbExportTool.Core.Models;
namespace DBExporter.Infrastructure.Utilities
{
    public class FileNameBuilder : IFileNameBuilder
    {
        public string Build(ExportOptions options, string defaultTableName)
        {
            string baseName = options.OutputFileName;
            if (string.IsNullOrWhiteSpace(baseName) || baseName == "export")
                baseName = defaultTableName ?? "export";
            if (options.AppendDateTime)
                baseName += DateTime.Now.ToString("_yyyyMMdd_HHmmss");
            string extension = options.Format == ExportFormat.Csv ? ".csv" : ".sql";
            return options.Compress ? baseName + ".zip" : baseName + extension;
        }
    }
}
