using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Vacancy
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
