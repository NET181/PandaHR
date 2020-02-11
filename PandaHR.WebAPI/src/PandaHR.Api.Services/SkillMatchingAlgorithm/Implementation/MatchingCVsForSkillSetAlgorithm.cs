using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.SkillMatchingAlgorithm.Contracts;


namespace PandaHR.Api.Services.SkillMatchingAlgorithm.Implementation
{
    public class MatchingCVsForSkillSetAlgorithm : IMatchingCVsForSkillSetAlgorithm
    { 
        public async Task<IEnumerable<CV>> GetMatchingBySkillsObjects(
           IEnumerable<CV> source,
           IEnumerable<Skill> properties,
           double threshold)
        {
            var query = Task.Run(() =>
            {
                ICollection<CV> cvs = new List<CV>();

                foreach (var cv in source)
                {
                    IEnumerable<string> skillNames = cv.SkillKnowledges.Select(sk => sk.Skill.Name);
                    double matches = skillNames.Intersect(properties.Select(skill => skill.Name)).Count();

                    if (matches / properties.Count() >= threshold)
                    {
                        cvs.Add(cv);  
                    }
                }
                return cvs;
            });

            return await query;
        }
    }
}
