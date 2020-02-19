using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class VacancyCVFile : File
    {
        public Guid VacancyCVFlowId { get; set; }
        public VacancyCVFlow VacancyCVFlow { get; set; }
    }
}
