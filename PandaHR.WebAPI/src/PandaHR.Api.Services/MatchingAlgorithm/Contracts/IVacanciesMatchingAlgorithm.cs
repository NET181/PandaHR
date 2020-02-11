using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.MatchingAlgorithm.Models;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IVacanciesMatchingAlgorithm
    {
        Task<IEnumerable<VacancyWithRatingModel>> SearchByCV(
               IEnumerable<VacancyMatchingAlgorithmModel> vacancies,
               CVMatchingAlgorithmModel cv,
               double threshold);
    }
}
