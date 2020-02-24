using PandaHR.Api.DAL.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Models.VacancyCVFlow
{
    public class VacancyCVFlowEditStatusRequestModel
    {
        public Guid VacancyId { get; set; }
        public Guid CVId { get; set; }
        public VacancyCVStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
