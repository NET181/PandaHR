using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
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
            CreateMap<Vacancy, VacancyServiceModel>();
        }
    }
}
