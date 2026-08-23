using DBExporter.Infrastructure.DataExporter;
using DBExporter.Infrastructure.Writers;
using DbExportTool.Core.Abstractions;
using DbExportTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBExporter.Infrastructure.Factories
{
    public class DataExporterFactory : IDataExporterFactory
    {
        public IDataExporter Create(ExportFormat format)
        {
            switch (format)
            {
                default:
                    return new CsvDataExporter();
            }
        }
    }
    public interface IOutputWriterFactory { IOutputWriter Create(bool compress); }
    public class OutputWriterFactory : IOutputWriterFactory
    {
        public IOutputWriter Create(bool compress) => new FileOutputWriter();
    }
}
