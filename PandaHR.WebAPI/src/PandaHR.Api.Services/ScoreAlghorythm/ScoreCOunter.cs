using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    class ScoreCounter
    {
        private readonly ScoreAlghorythm _alghorythm;
        private readonly ICVService _cVService;
        private readonly IVacancyService _vacancyService;

        public ScoreCounter(ScoreAlghorythm alghorythm, ICVService cVService, IVacancyService vacancyService)
        {
            _alghorythm = alghorythm;
            _cVService = cVService;
            _vacancyService = vacancyService;
        }

        public List<KeyValuePair<int,CV>> GetCVsByVacancy()
        {
            List<KeyValuePair<int, CV>> cVs = new List<KeyValuePair<int, CV>>();



            return cVs;
        }



        private double CountScaleStep(Type enumType)
        {
            double result = 0;

            //var some = Enum.GetValues(enumType);

            //result = some.Cast<int>().Max() + 1;
            //result = PERCENT_DIVIDER / result;

            return result;
        }
    }
}
