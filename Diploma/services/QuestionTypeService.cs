using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.models;
using Diploma.repositories;

namespace Diploma.services
{
    class QuestionTypeService
    {
        public List<QuestionType> GetAll()
        {
            var questionTypes = QuestionTypeRepository.GetAll();
            questionTypes.ForEach(type => type.Title = TranslationService.TranslateQuestionType(type.Type));
            return questionTypes;
        }
    }
}
