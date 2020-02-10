using System;
using PandaHR.Api.DAL.Models.Entities.Enums;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class VacancyCVStatus : BaseEntity
    {
        public Guid ProfileId { get; set; }
        public CV Profile { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Guid? FileId { get; set; }
        public FileVacancyCVProfile File { get; set; }
        public VacancyProfileStatus Status { get; set; }
        public VacancyProfileCancelReason CancelReason { get; set; }
        public string Notes { get; set; }
    }
}
