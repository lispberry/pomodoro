using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collective_Development
{
    static class Constants
    {
        public static readonly string ConnectionString = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = Database.Default.Name,
            Username = Database.Default.Username,
            Password = Database.Default.Password,
            MaxAutoPrepare = 10,
            AutoPrepareMinUsages = 2
        }.ConnectionString;
    }
}
