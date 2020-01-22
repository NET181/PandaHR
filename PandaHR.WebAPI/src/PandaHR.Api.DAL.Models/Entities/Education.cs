using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Education : BaseEntity, ISoftDeletable
    {
        public string PlaceName { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public Guid DegreeId { get; set; }
        public Degree Degree { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public bool IsDeleted { get; set; }
    }
}
