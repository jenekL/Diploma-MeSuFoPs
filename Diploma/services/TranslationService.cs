using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.models;

namespace Diploma.services
{
    class TranslationService
    {
        public static string TranslateQuestionType(QuestionType.Typo questionType)
        {
            switch (questionType)
            {
                case QuestionType.Typo.WithFewAnswers:
                    return "Несколько ответов";
                case QuestionType.Typo.WithImageFewAnswers:
                    return "С изображением";
                case QuestionType.Typo.WithImageOpinion:
                    return "С мнением";
                case QuestionType.Typo.YesNo:
                    return "Да/Нет";
                default:
                    return "";
            }
        }
    }
}
