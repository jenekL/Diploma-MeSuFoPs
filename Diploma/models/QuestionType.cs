using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.models
{
    public class QuestionType
    {
        public enum Typo
        {
            YesNo,
            WithImageOpinion,
            WithFewAnswers,
            WithImageFewAnswers
        }
        public long Id { get; set; }
        public Typo Type { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }

}
