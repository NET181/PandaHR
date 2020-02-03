using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class VacancyDTOProfile : AutoMapperProfile
    {
        public VacancyDTOProfile()
        {
            CreateMap<VacancyDTO, Vacancy>();
        }
    }
}
