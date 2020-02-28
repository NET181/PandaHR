using PandaHR.Api.Common;
using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlghorythm.Mapper
{
    class CVAlghorythmModelMap : AutoMapperProfile
    {
        public CVAlghorythmModelMap()
        {
            CreateMap<DAL.Models.Entities.CV, CVAlghorythmModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id));
        }
    }
}
