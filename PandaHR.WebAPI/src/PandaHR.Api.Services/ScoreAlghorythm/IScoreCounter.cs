using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.ScoreAlghorythm.Models;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public interface IScoreCounter
    {
        Task<List<IdAndRating>> GetCVsByVacancy(Guid vacancyId);
    }
}