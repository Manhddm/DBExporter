using DbExportTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using CsvHelper;

namespace DBExporter.Infrastructure.DataExporter
{
    public class CsvDataExporter : IDataExporter
    {
        public void Export(IEnumerable<IDictionary<string, object>> data, Stream outputStream, string tableName)
        {
            using var writer = new StreamWriter(outputStream, Encoding.UTF8, leaveOpen: true);
            using var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
            bool isFirstRow = true;
            foreach (var row in data)   
            {
                if (isFirstRow)
                {
                    foreach (var header in row.Keys)
                    {
                        csv.WriteField(header);
                    }
                    csv.NextRecord();
                    isFirstRow = false;
                }
                foreach (var key in row.Keys)
                {
                    csv.WriteField(row[key]?.ToString());
                }
                csv.NextRecord();
            }
        }
    }
}
