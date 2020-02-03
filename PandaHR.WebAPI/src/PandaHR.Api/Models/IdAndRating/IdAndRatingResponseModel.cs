using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Models.IdAndRating
{
    public class IdAndRatingResponseModel
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
    }
}
