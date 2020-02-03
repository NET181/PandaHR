using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.Services.Models.Company;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class CompanyServiceModelProfile : AutoMapperProfile
    {
        public CompanyServiceModelProfile()
        {
            CreateMap<CompanyBasicInfoServiceModel, CompanyBasicInfoDTO>();

            CreateMap<CompanyBasicInfoDTO, CompanyBasicInfoServiceModel>();

            CreateMap<CompanyNameDTO, CompanyNameServiceModel>();
        }
    }
}
