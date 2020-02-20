using System.Collections.Generic;

namespace PandaHR.Api.Services.Exporter.Models.ExportModels
{
    public class TechnologyExportModel
    {
        public string Name { get; set; }
        public ICollection<SkillExportModel> Skills { get; set; }
    }
}
