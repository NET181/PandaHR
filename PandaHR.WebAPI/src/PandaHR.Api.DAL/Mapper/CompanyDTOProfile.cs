using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Mapper
{
    public class CompanyDTOProfile : AutoMapperProfile
    {
        public CompanyDTOProfile()
        {
            CreateMap<CompanyBasicInfoDTO, Company>();

            CreateMap<Company, CompanyBasicInfoDTO>();
        }
    }
}
