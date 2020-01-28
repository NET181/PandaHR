using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Country : BaseEntity, ISoftDeletable
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
