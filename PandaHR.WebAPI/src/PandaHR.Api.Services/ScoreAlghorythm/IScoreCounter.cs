using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public interface IScoreCounter
    {
        Task<List<IdAndRaiting>> GetCVsByVacancy(Guid vacancyId);
    }
}