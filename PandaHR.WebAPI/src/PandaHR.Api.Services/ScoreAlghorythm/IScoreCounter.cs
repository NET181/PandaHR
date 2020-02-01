using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public interface IScoreCounter
    {
        Task<List<IdAndRaiting>> GetCVsByVacancy(Vacancy vacancy);
    }
}