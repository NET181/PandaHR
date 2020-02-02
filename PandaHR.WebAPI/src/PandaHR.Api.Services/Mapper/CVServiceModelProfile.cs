using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class CVServiceModelProfile : AutoMapperProfile
    {
        public CVServiceModelProfile()
        {
            CreateMap<CVServiceModel, CVDTO>()
            .ForMember(x => x.Educations, o => o.MapFrom(c => c.Educations))
            .ForMember(x => x.IsActive, o => o.MapFrom(c => c.IsActive))
            .ForMember(x => x.JobExperiences, o => o.MapFrom(c => c.JobExperiences))
            .ForMember(x => x.QualificationId, o => o.MapFrom(c => c.QualificationId))
            .ForMember(x => x.SkillKnowledges, o => o.MapFrom(c => c.SkillKnowledges))
            .ForMember(x => x.Summary, o => o.MapFrom(c => c.Summary))
            .ForMember(x => x.TechnologyId, o => o.MapFrom(c => c.TechnologyId))
            .ForMember(x => x.User, o => o.MapFrom(c => c.User));

            CreateMap<CV, CVServiceModel>();
        }
    }
}
