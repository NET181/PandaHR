using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.DTOs.Technology;
using PandaHR.Api.DAL.Models.Entities;
using System.Linq;

namespace PandaHR.Api.DAL.Mapper
{
    public class CVDTOProfile : AutoMapperProfile
    {
        public CVDTOProfile()
        {
            CreateMap<CVDTO, CV>();

            CreateMap<CV, CVExportDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.SecondName}"))
                .ForMember(dest => dest.Qualification, opt => opt.MapFrom(src => src.Qualification.Name))
                .ForMember(dest => dest.Educations, opt => opt.MapFrom(src => src.User.Educations))
                .ForMember(dest => dest.JobExperiences, opt => opt.MapFrom(src => src.JobExperiences))
                .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.SkillKnowledges
                    .GroupBy(sk => sk.Skill.SkillType)
                        .Select(sk => new TechnologyExportDTO
                        {
                            Name = sk.Key.Name,
                            Skills = sk.Select(skillKnowledge =>
                                           new SkillExportDTO
                                           {
                                               Name = skillKnowledge.Skill.Name,
                                               KnowledgeLevel = skillKnowledge.KnowledgeLevel.Name
                                           }).ToList()
                        })));
            CreateMap<CV, CVSummaryDTO>()
                .ForMember(dest => dest.QualificationName, opt => opt.MapFrom(src => src.Qualification.Name))
                .ForMember(dest => dest.TechnologyName, opt => opt.MapFrom(src => src.Technology.Name))
                .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary));
        }
    }
}
