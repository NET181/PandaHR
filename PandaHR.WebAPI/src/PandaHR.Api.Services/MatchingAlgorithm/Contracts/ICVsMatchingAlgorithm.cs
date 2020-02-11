using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.MatchingAlgorithm.Models;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IСVsMatchingAlgorithm
    {
        Task<IEnumerable<CVWithRatingModel>> SearchByVacancy(
             IEnumerable<CVMatchingAlgorithmModel> cvs,
             VacancyMatchingAlgorithmModel vacancy,
             double threshold);
    }
}
