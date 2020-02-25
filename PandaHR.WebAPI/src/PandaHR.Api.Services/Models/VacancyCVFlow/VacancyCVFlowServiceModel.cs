using System;
using PandaHR.Api.DAL.Models.Entities.Enums;

namespace PandaHR.Api.Services.Models.VacancyCVFlow
{
    public class VacancyCVFlowServiceModel
    {
        public Guid CVId { get; set; }
        public Guid VacancyId { get; set; }
        public VacancyCVStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
