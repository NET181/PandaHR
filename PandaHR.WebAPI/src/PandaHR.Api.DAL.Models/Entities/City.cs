using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class City : BaseEntity
    {
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
