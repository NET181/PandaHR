using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities.Enums;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class VacancyCVFlow : BaseEntity
    {
        public VacancyCVFlow()
        {
            Files = new HashSet<VacancyCVFile>();
        }

        public Guid CVId { get; set; }
        public CV CV { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Guid? FileId { get; set; }
        public VacancyCVStatus Status { get; set; }
        public VacancyCVCancelReason CancelReason { get; set; }
        public string Notes { get; set; }

        public ICollection<VacancyCVFile> Files { get; set; }
    }
}
