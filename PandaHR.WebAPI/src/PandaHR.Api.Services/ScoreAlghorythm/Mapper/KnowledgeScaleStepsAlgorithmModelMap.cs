using PandaHR.Api.Common;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlghorythm.Mapper
{
    public class KnowledgeScaleStepsAlgorithmModelMap : AutoMapperProfile
    {
        public KnowledgeScaleStepsAlgorithmModelMap()
        {
            CreateMap<KnowledgeScaleStepsAlgorithmModel, KnowledgeScaleSteps>();

            CreateMap<KnowledgeScaleSteps, KnowledgeScaleStepsAlgorithmModel>();
        }
    }
}
