using System;

namespace PandaHR.Api.DAL.DTOs.CV
{
    public class CVSummaryDTO
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public string QualificationName { get; set; }
        public string TechnologyName { get; set; }
    }
}
