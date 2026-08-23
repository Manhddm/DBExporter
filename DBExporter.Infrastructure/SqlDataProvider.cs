
using Dapper;
using DbExportTool.Core.Abstractions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBExporter.Infrastructure
{
    public class SqlDataProvider : IDataProvider
    {
        public (string tableName, IEnumerable<IDictionary<string, object>> data) GetData(string connectionString, string query, bool isTableName)
        {
            string finalSql;
            string tableName;
            if (isTableName)
            {
                tableName = query;
                finalSql = $"SELECT * FROM {query}";
            }
            else
            {
                tableName = ExtractTableNameFromSelect(query) ?? "ExportData";
                finalSql = query;
            }
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var rows = connection.Query(finalSql, buffered:  false);

            return (tableName, StreamRows(connection, rows));
        }

        private IEnumerable<IDictionary<string, object>> StreamRows(SqlConnection connection, IEnumerable<dynamic> rows)
        {
            using (connection)
            {
                foreach(IDictionary<string, object> row in rows)
                {
                    yield return row;
                }
            }
        }

        private string? ExtractTableNameFromSelect(string query)
        {
            var parts = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Equals("FROM", StringComparison.OrdinalIgnoreCase) && i + 1 < parts.Length)
                    return parts[i + 1].Trim(';', ',', '\n', '\r');
            }
            return null;
        }
    }
}
