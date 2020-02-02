using PandaHR.Api.Common;
using PandaHR.Api.Models.Company;
using PandaHR.Api.Services.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Mapper
{
    public class CompanyModelProfiler : AutoMapperProfile
    {
        public CompanyModelProfiler()
        {
            CreateMap<CompanyBasicInfoResponse, CompanyBasicInfoServiceModel>();

            CreateMap<CompanyBasicInfoServiceModel, CompanyBasicInfoResponse>();
        }
    }
}
