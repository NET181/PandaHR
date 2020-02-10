using System.Collections.Generic;

namespace PandaHR.Api.Services.Exporter.Models.ExportModels
{
    public class CVExportModel
    {
        public string FullName { get; set; }
        public string Qualification { get; set; }
        public string Summary { get; set; }
        public ICollection<TechnologyExportModel> Technologies { get; set; }
        public ICollection<JobExperienceExportModel> JobExperiences { get; set; }
        public ICollection<EducationExportModel> Educations { get; set; }
    }
}
