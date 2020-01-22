using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Company
    {
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
