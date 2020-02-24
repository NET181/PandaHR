using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.VacancyCVFlow
{
    public class VacancyCVFlowCreationDTO
    {
        public Guid CVId { get; set; }
        public Guid VacancyId { get; set; }
        public string Notes { get; set; }
    }
}
