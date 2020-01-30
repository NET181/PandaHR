using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Models.Experience
{
    public class ExperienceResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
