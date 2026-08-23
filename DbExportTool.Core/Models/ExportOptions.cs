using System;
using System.Collections.Generic;
using System.Text;

namespace DbExportTool.Core.Models
{
    public class ExportOptions
    {
        public string ConnectionString { get; set; }
        public string OutputDirectory { get; set; }
        public string FileName { get; set; }
        public string Query { get; set; }
        public bool IsTableName { get; set; }
        public ExportFormat Format { get; set; }
        public bool Compress { get; set; }
        public bool AppendDateTime { get; set; }
    }
}
