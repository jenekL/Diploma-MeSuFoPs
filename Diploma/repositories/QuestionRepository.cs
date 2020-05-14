using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Diploma.models;

namespace Diploma.repositories
{
    class QuestionRepository
    {
        public static long Save(Question question)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
               return cnn.QuerySingle<long>("insert into questions (title, question_num, survey_id, question_type_id) values (@Title, @QuestionNum, @SurveyId, @QuestionTypeId); SELECT last_insert_rowid()", question);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
