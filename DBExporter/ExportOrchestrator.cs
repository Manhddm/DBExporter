using DBExporter.Infrastructure.Factories;
using DbExportTool.Core.Abstractions;
using DbExportTool.Core.Models;

namespace DBExporter
{
    public class ExportOrchestrator
    {
        private readonly IDataProviderFactory _providerFactory;
        private readonly IDataExporterFactory _exporterFactory;
        private readonly IOutputWriterFactory _writerFactory;
        private readonly IFileNameBuilder _fileNameBuilder;
        public ExportOrchestrator(
        IDataProviderFactory providerFactory,
        IDataExporterFactory exporterFactory,
        IOutputWriterFactory writerFactory,
        IFileNameBuilder fileNameBuilder)
        {
            _providerFactory = providerFactory;
            _exporterFactory = exporterFactory;
            _writerFactory = writerFactory;
            _fileNameBuilder = fileNameBuilder;
        }
        public async Task ExecuteAsync(ExportOptions options)
        {
            // 1. Lấy Provider (Factory)
            var provider = _providerFactory.Create(options.ConnectionString);

            // 2. Lấy dữ liệu (Streaming)
            var (tableName, data) = provider.GetData(options.ConnectionString, options.Query, options.IsTableName);

            // 3. Tạo tên file cuối cùng
            string finalFile = _fileNameBuilder.Build(options, tableName);

            // 4. Xuất dữ liệu ra MemoryStream (để Writer có thể đọc lại nếu cần - như zip)
            using var memoryStream = new MemoryStream();

            // 5. Lấy Exporter (Factory) và export vào MemoryStream
            var exporter = _exporterFactory.Create(options.Format);
            exporter.Export(data, memoryStream, tableName);

            // 6. Lấy Writer (Factory) và ghi xuống đĩa (hoặc zip)
            var writer = _writerFactory.Create(options.Compress);
            writer.Write(memoryStream, finalFile);

            Console.WriteLine($"✅ Export completed: {finalFile}");
        }
    }
}
