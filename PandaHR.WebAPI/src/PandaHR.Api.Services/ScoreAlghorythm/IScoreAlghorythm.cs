using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public interface IScoreAlghorythm
    {
        List<IdAndRating> GetCVsRating(VacancyAlghorythmModel vacancy, IEnumerable<CVAlghorythmModel> cVs, int languageKnowledgeScaleStep, int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep);
        int GetRating(VacancyAlghorythmModel vacancy, CVAlghorythmModel cv, int languageKnowledgeScaleStep, int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep);
        List<IdAndRating> GetVacancysRaiting(IEnumerable<VacancyAlghorythmModel> vacancys, CVAlghorythmModel cV, int languageKnowledgeScaleStep, int hardKnowledgeScaleStep, int softKnowledgeScaleStep, int qualificationScaleStep);
    }
}