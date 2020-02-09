using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.DTOs.City;

namespace PandaHR.Api.DAL.DTOs.Vacancy
{
    public class VacancySummaryDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string QualificationName { get; set; }
        public string TechnologyName { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<CityNameDTO> CityNames {get;set;}
    }
}
