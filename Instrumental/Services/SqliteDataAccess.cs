using Dapper;
using Instrumental.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Instrumental.Services
{
    public class SqliteDataAccess : ISqliteDataAccess
    {
        public IEnumerable<InstrumentEntity> LoadInstruments()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InstrumentEntity>("select * from Instrument", new DynamicParameters());

                return output;
            }
        }

        private string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
