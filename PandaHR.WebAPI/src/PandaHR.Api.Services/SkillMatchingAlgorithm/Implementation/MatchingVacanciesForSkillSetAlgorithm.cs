using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.SkillMatchingAlgorithm.Contracts;


namespace PandaHR.Api.Services.SkillMatchingAlgorithm.Implementation
{
    public class MatchingVacanciesForSkillSetAlgorithm : IMatchingVacanciesForSkillSetAlgorithm
    {
        public async Task<IEnumerable<Vacancy>> GetMatchingBySkillsObjects(
            IEnumerable<Vacancy> source,
            IEnumerable<Skill> properties, 
            double threshold)
        {
            var query = Task.Run(() =>
            {
                ICollection<Vacancy> vacancies = new List<Vacancy>();

                foreach (var cv in source)
                {
                    IEnumerable<string> skillNames = cv.SkillRequirements.Select(sk => sk.Skill.Name);
                    double matches = skillNames.Intersect(properties.Select(skill => skill.Name)).Count();

                    if (matches / properties.Count() >= threshold)
                    {
                        vacancies.Add(cv);
                    }
                }
                return vacancies;
            });

            return await query;
        }
    }
}
