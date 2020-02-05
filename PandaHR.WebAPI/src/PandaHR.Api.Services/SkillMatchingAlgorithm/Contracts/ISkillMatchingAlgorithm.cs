using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;


namespace PandaHR.Api.Services.SkillMatchingAlgorithm.Contracts
{
    public interface ISkillMatchingAlgorithm<T>
    {
        Task<IEnumerable<T>> GetMatchingBySkillsObjects(IEnumerable<T> source, IEnumerable<Skill> properties, double threshold);
    }
}
