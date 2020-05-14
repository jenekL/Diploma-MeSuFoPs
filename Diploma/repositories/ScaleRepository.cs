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
    class ScaleRepository
    {
        public static List<Scale> GetAll(long surveyId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<Scale>("select * from scales where survey_id = @SurveyId", new {SurveyId = surveyId}).ToList();
            }
        }

        public static long Save(Scale scale)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.QuerySingle<long>("insert into scales (title, survey_id) values (@Title, @SurveyId); SELECT last_insert_rowid()", scale);
            }
        }

        public static Scale GetBySurveyIdAndTitle(Scale scale)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.QuerySingleOrDefault<Scale>("select * from scales where title = @Title and survey_id = @SurveyId", scale);
            }
        }

        public static void Delete(long id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from scales where id = @Id", new {Id = id});
            }
        }

        public static void Delete(long surveyId, string title)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from scales where survey_id = @SurveyId and title = @Title", new { SurveyId = surveyId, Title = title });
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
