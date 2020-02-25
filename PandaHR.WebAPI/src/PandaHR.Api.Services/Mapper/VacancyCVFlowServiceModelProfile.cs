using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.Models.Entities.Enums;
using PandaHR.Api.Services.Models.VacancyCVFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class VacancyCVFlowServiceModelProfile : AutoMapperProfile
    {
        public VacancyCVFlowServiceModelProfile()
        {
            CreateMap<VacancyCVFlowCreationServiceModel, VacancyCVFlowCreationDTO>();
            CreateMap<VacancyCVFlowCreationDTO, VacancyCVFlowCreationServiceModel>();

            CreateMap<VacancyCVFlowEditStatusServiceModel, VacancyCVFlowEditStatusDTO>();
            CreateMap<VacancyCVFlowDTO, VacancyCVFlowServiceModel>();
        }
    }
}
