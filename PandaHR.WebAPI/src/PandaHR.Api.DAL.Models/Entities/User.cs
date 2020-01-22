using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class User : BaseEntity
    {
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<CV> CVs { get; set; }
    }
}
