using PandaHR.Api.Common;
using PandaHR.Api.Models.IdAndRating;
using PandaHR.Api.Services.ScoreAlghorythm;

namespace PandaHR.Api.Mapper
{
    public class IdAndRatingModelProfile : AutoMapperProfile
    {
        public IdAndRatingModelProfile()
        {
            CreateMap<AlghorythmResponseServiceModel, AlghorythmResponseModel>();
        }
    }
}
