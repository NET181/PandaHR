﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class CV
    {
        public ICollection<SkillKnowledge> SkillKnowledges { get; set; }
    }
}
