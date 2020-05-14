using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.models
{
    class Question
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long QuestionNum { get; set; }
        public long SurveyId { get; set; }
        public long QuestionTypeId { get; set; }
    }
}
