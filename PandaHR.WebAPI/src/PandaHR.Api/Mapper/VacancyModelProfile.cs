using AutoMapper;
using PandaHR.Api.Models.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Mapper
{
    public class VacancyModelProfile: Profile
    {
        public VacancyModelProfile()
        {
            CreateMap<VacancyCreationRequestModel, VacancyServiceModel>();
            CreateMap<VacancyServiceModel, VacancyCreationRequestModel>();
        }
    }
}
