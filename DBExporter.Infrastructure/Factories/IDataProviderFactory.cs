using DbExportTool.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBExporter.Infrastructure.Factories
{
    public interface IDataProviderFactory
    {
        IDataProvider Create(string connectionString);
    }
}
