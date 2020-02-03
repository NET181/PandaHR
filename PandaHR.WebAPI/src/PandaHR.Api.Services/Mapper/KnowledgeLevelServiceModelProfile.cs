using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.KnowledgeLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class KnowledgeLevelServiceModelProfile : AutoMapperProfile
    {
        public KnowledgeLevelServiceModelProfile()
        {
            CreateMap< KnowledgeLevel, KnowledgeLevelServiceModel>();
        }
    }
}
