using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Diploma.models;

namespace Diploma.repositories
{
    class SurveyRepository
    {
        public static long Save(Survey survey)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.QuerySingle<long>(@"insert into surveys (title) values (@Title); SELECT last_insert_rowid()", survey);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
