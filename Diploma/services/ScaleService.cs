using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.models;
using Diploma.repositories;

namespace Diploma.services
{
    class ScaleService
    {
        public List<Scale> GetAll(long surveyId)
        {
            return ScaleRepository.GetAll(surveyId);
        }

    }
}
