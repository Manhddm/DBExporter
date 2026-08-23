using CommandLine;
using DBExporter.Infrastructure.Factories;
using DBExporter.Infrastructure.Utilities;
using DbExportTool.Core.Models;

namespace DBExporter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var parser = new Parser(with =>
            {
                with.CaseInsensitiveEnumValues = true;
                with.HelpWriter = Console.Error;
            });
            var parserResult = parser.ParseArguments<ExportOptions>(args);
            await parserResult.WithParsedAsync(async options =>
                {
                    try
                    {
                        // Khởi tạo các Factory (có thể dùng DI Container nếu thích)
                        var orchestrator = new ExportOrchestrator(
                            new SqlDataProviderFactory(),
                            new DataExporterFactory(),
                            new OutputWriterFactory(),
                            new FileNameBuilder()
                        );

                        await orchestrator.ExecuteAsync(options);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error: {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                });
                parserResult.WithNotParsed(errors =>
                {
                    Console.WriteLine("Invalid arguments. Use --help for usage.");
                });

        }
    }
}
