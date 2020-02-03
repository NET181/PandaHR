using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Qualification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class QualificationServiceModelProfile : AutoMapperProfile
    {
        public QualificationServiceModelProfile()
        {
            CreateMap<Qualification, QualificationServiceModel>();
        }
    }
}
