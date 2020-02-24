using System.Linq;
using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.MatchingAlgorithm.Models;
using PandaHR.Api.Services.Models.CV;

namespace PandaHR.Api.Services.Mapper
{
    public class CVServiceModelProfile : AutoMapperProfile
    {
        public CVServiceModelProfile()
        {
            CreateMap<CVServiceModel, CVCreationDTO>()
            .ForMember(x => x.Educations, o => o.MapFrom(c => c.Educations))
            .ForMember(x => x.IsActive, o => o.MapFrom(c => c.IsActive))
            .ForMember(x => x.JobExperiences, o => o.MapFrom(c => c.JobExperiences))
            .ForMember(x => x.QualificationId, o => o.MapFrom(c => c.QualificationId))
            .ForMember(x => x.SkillKnowledges, o => o.MapFrom(c => c.SkillKnowledges))
            .ForMember(x => x.Summary, o => o.MapFrom(c => c.Summary))
            .ForMember(x => x.TechnologyId, o => o.MapFrom(c => c.TechnologyId))
            .ForMember(x => x.User, o => o.MapFrom(c => c.User));

            CreateMap<CV, CVServiceModel>();
            CreateMap<CVCreationServiceModel, CVCreationDTO>();
            CreateMap<CVforSearchDTO, CVServiceModel>();
            CreateMap<CVServiceModel, CV>();
            CreateMap<CVServiceModel, CVCreationServiceModel>();
            CreateMap<CVDTO, CVServiceModel>()
                .ForMember(t => t.UserId, o => o.MapFrom(c => c.User.Id))
                .ForMember(t => t.JobExperiences, o => o.MapFrom(c => c.JobExperiences))
                .ForMember(t => t.SkillKnowledges, o => o.MapFrom(c => c.SkillKnowledges));

            CreateMap<CV, SkillSetModel>()
                .ForMember(x => x.Skills, o => o.MapFrom(
                    c => c.SkillKnowledges.Select(s => s.SkillId)));

        }
    }
}
