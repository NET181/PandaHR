using PandaHR.Api.DAL.Models.Entities.Enums;
using System;

namespace PandaHR.Api.DAL.DTOs.VacancyCVFlow
{
    public class VacancyCVFlowDTO
    {
        public Guid CVId { get; set; }
        public Guid VacancyId { get; set; }
        public VacancyCVStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
