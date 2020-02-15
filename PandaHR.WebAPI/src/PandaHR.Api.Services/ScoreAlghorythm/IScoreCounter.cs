using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public interface IScoreCounter
    {
        Task<List<IdAndRatingServiceModel>> GetCVsByVacancy(Guid vacancyId);
    }
}