using PandaHR.Api.DAL.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Models.VacancyCVFlow
{
    public class VacancyCVFlowEditStatusServiceModel
    {
        public Guid VacancyId { get; set; }
        public Guid CVId { get; set; }
        public VacancyCVStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
