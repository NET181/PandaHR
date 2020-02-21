using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.DAL.DTOs.Technology;
using System.Collections.Generic;

namespace PandaHR.Api.DAL.DTOs.CV
{
    public class CVExportDTO
    {

        public string FullName { get; set; }
        public string Qualification { get; set; }
        public string Summary { get; set; }
        public ICollection<TechnologyExportDTO> Technologies { get; set; }
        public ICollection<JobExperienceExportDTO> JobExperiences { get; set; }
        public ICollection<EducationExportDTO> Educations { get; set; }
    }
}
