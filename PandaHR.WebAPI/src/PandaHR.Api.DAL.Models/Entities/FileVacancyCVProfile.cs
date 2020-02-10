using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class FileVacancyCVProfile : File
    {
        public Guid VacancyCVStatusId { get; set; }
        public VacancyCVStatus VacancyCVStatus { get; set; }
    }
}
