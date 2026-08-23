using DbExportTool.Core.Abstractions;
using DbExportTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBExporter.Infrastructure.Factories
{
    public interface IDataExporterFactory
    {
        IDataExporter Create(ExportFormat format);
    }
}
