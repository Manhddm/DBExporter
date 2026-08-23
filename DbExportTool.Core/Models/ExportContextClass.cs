
namespace DbExportTool.Core.Models
{
    public class ExportContextClass
    {
        public string TableName { get; set; }
        public string FilePath { get; set; }
        public ExportFormat Format { get; set; }
    }
}
