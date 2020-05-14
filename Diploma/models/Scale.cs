using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.models
{
    public class Scale
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long SurveyId { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
