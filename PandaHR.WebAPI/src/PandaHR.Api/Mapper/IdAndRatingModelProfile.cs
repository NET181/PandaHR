using PandaHR.Api.Common;
using PandaHR.Api.Models.IdAndRating;
using PandaHR.Api.Services.ScoreAlghorythm.Models;

namespace PandaHR.Api.Mapper
{
    public class IdAndRatingModelProfile : AutoMapperProfile
    {
        public IdAndRatingModelProfile()
        {
            CreateMap<IdAndRating, IdAndRatingResponseModel>();
        }
    }
}
