using System;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class VacancyCity : ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
