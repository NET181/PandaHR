using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTO.Experience
{
    public class ExperienceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
