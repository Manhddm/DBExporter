using DbExportTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBExporter.Infrastructure.Factories
{
    public class SqlDataProviderFactory : IDataProviderFactory
    {
        public IDataProvider Create(string connectionString) => new SqlDataProvider();
    }
}
