﻿using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class KnowledgeLevelServiceModel : AutoMapperProfile
    {
        public KnowledgeLevelServiceModel()
        {
            CreateMap<KnowledgeLevelServiceModel, KnowledgeLevel>();
        }
    }
}
