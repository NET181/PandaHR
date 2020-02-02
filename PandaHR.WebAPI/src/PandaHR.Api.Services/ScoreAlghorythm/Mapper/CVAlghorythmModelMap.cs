using PandaHR.Api.Common;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Mapper
{
    class CVAlghorythmModelMap : AutoMapperProfile
    {
        public CVAlghorythmModelMap()
        {
            CreateMap<DAL.Models.Entities.CV, CVAlghorythmModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id));
                //.ForMember(x => x.Qualification)


                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))

        }
        //public Guid Id { get; set; }
        //public List<SkillKnowledge> SkillKnowledges { get; set; }
        //public int Qualification { get; set; }
    }
}
