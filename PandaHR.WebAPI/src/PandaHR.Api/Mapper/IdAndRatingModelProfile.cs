using PandaHR.Api.Common;
using PandaHR.Api.Models.IdAndRating;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
