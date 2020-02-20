using PandaHR.Api.Common;
using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlghorythm.Mapper
{
    public class IdAndRatingModelMap : AutoMapperProfile
    {
        public IdAndRatingModelMap()
        {
            CreateMap<IdAndRating, IdAndRatingServiceModel>();

            CreateMap<IdAndRatingServiceModel, IdAndRating>();
        }
    }
}
