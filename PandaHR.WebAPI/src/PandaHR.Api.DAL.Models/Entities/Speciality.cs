using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Speciality : BaseEntity, ISoftDeletable
    {
        public Speciality()
        {
            Educations = new HashSet<Education>();
        }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Education> Educations;

    }
}
