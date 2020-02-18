using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlgorithm
{
    public interface IScoreAlghorythmBuilder
    {
        ScoreAlghorythm GetScoreAlghorythm(SkillTypeValues skillTypeValues,
            KnowledgeScaleSteps knowledgeScaleSteps);
    }
}