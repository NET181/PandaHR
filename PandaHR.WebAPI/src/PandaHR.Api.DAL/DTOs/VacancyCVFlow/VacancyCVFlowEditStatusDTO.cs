using PandaHR.Api.DAL.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.VacancyCVFlow
{
    public class VacancyCVFlowEditStatusDTO
    {
        public Guid VacancyId { get; set; }
        public Guid CVId { get; set; }
        public VacancyCVStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
