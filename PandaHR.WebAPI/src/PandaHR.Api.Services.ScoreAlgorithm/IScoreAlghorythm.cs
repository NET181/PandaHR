using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlgorithm
{
    public interface IScoreAlghorythm
    {
        List<IdAndRating> GetCVsRating(VacancyAlghorythmModel vacancy, IEnumerable<CVAlghorythmModel> cVs);
        int GetRating(VacancyAlghorythmModel vacancy, CVAlghorythmModel cV);
        List<IdAndRating> GetVacancysRaiting(IEnumerable<VacancyAlghorythmModel> vacancys, CVAlghorythmModel cV);
    }
}