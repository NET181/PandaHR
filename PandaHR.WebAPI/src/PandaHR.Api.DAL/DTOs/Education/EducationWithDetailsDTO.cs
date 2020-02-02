using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.Education
{
    public class EducationWithDetailsDTO
    {
        public string PlaceName { get; set; }
        public Guid DegreeId { get; set; }
        public string Speciality { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
