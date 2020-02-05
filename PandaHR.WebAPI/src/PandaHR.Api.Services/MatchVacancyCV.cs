using System.Linq;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services
{
    public class MatchVacancyCV
    {
        public static int Matches(Vacancy vacancy, CVforSearchDTO cv)
        {
            var reqSkills = from v in vacancy.SkillRequirements
                            select v.Skill.Name;

            var cvSkills = from v in cv.SkillKnowledges
                           select v.SkillName;

            var result = reqSkills.Count() == 0 ? cvSkills.Count() 
                : cvSkills.Intersect(reqSkills).Count();

            return result;
        }
    }
}
