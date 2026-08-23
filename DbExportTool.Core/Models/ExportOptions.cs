using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;
namespace DbExportTool.Core.Models
{
    public class ExportOptions
    {
        [Option('c', "connection", Required = true, HelpText = "Connection string")]
        public string ConnectionString { get; set; }
        [Option('f', "file", Required = true, HelpText = "Output file name (without extension)")]
        public string OutputFileName { get; set; }
        [Option('q', "query", Required = true, HelpText = "SELECT statement or table name")]
        public string Query { get; set; }
        [Option('t', "table", Required = false, Default = false, HelpText = "Is query a table name?")]
        public bool IsTableName { get; set; }
        [Option('m', "format", Required = false, Default = ExportFormat.Csv, HelpText = "Export format: csv or sql")]
        public ExportFormat Format { get; set; }
        [Option('z', "zip", Required = false, Default = false, HelpText = "Compress output as zip")]
        public bool Compress { get; set; }
        [Option('d', "appenddate", Required = false, Default = false, HelpText = "Append date time to file name")]
        public bool AppendDateTime { get; set; }
    }
}
