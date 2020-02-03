using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class VacancyServiceModelProfile : AutoMapperProfile
    {
        public VacancyServiceModelProfile()
        {
            CreateMap<VacancyServiceModel, VacancyDTO>();

            CreateMap<VacancyDTO, VacancyServiceModel>();
        }
    }
}
