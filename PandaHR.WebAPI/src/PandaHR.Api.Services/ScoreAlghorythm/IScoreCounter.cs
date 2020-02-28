using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public interface IScoreCounter
    {
        Task<IEnumerable<AlghorythmResponseServiceModel>> GetCVsByVacancy(Guid vacancyId);
    }
}