using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities.Enums;

namespace PandaHR.Api.Models.VacancyCVFlow
{
    public class VacancyCVFlowResponceModel
    {
        public Guid CVId { get; set; }
        public Guid VacancyId { get; set; }
        public VacancyCVStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
