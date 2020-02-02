using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services
{
    public class MatchVacancyCV
    {
        public static bool Matches(Vacancy vacancy, CVforSearchDTO cv)
        {
            return true;
        }
    }
}
