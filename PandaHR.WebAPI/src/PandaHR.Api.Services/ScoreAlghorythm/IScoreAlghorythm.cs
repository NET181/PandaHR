using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public interface IScoreAlghorythm
    {
        List<IdAndRaiting> GetCVsRaiting(Vacancy vacancy, IEnumerable<CV> cVs, int languageKnowledgeScaleStep, int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep);
        int GetRating(Vacancy vacancy, CV cv, int languageKnowledgeScaleStep, int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep);
        List<IdAndRaiting> GetVacancysRaiting(IEnumerable<Vacancy> vacancys, CV cV, int languageKnowledgeScaleStep, int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep);
    }
}