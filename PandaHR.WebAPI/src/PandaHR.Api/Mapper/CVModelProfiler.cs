using PandaHR.Api.Common;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Mapper
{
    public class CVModelProfiler : AutoMapperProfile
    {
        public CVModelProfiler()
        {
            CreateMap<CVCreationRequestModel, CVServiceModel>();

        }
    }
}
