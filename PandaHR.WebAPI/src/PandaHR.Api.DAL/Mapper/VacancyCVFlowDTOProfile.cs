using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Mapper
{
    public class VacancyCVFlowDTOProfile: AutoMapperProfile
    {
        public VacancyCVFlowDTOProfile()
        {
            CreateMap<VacancyCVFlow, VacancyCVFlowDTOProfile>();
            CreateMap<VacancyCVFlowCreationDTO, VacancyCVFlow>();
        }
    }
}
