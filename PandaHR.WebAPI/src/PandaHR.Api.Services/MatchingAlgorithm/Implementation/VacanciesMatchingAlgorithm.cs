using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Models;

namespace PandaHR.Api.Services.SkillMatchingAlgorithm.Implementation
{
    public class VacanciesMatchingAlgorithm : IVacanciesMatchingAlgorithm
    {
        public async Task<IEnumerable<VacancyWithRatingModel>> SearchByCV(
               IEnumerable<VacancyMatchingAlgorithmModel> vacancies,
               CVMatchingAlgorithmModel cv,
               double threshold)
        {
            IEnumerable<SkillMatchingAlgorithmModel> requiredSkills = cv.
                SkillKnowledges.Select(s => s.Skill);

            var result = Task.Run(() =>
            {
                return vacancies
                .Select(v => GetVacancyWithRating(v, requiredSkills))
                .Where(v => v.Rating >= threshold)
                .OrderByDescending(v => v.Rating);
            });

            return await result;
        }

        private VacancyWithRatingModel GetVacancyWithRating(
           VacancyMatchingAlgorithmModel vacancy,
           IEnumerable<SkillMatchingAlgorithmModel> cvSkills)
        {
            var vacancySkills = vacancy.SkillRequirements.Select(s => s.Skill);

            int matchesCount = cvSkills
                .Select(s => s.Id)
                .Intersect(vacancySkills
                    .Select(s => s.Id)).Count();

            int vacancySkillsCount = vacancySkills.Count();

            if (vacancySkillsCount == 0)
            {
                return new VacancyWithRatingModel
                {
                    Id = vacancy.Id,
                    Rating = double.PositiveInfinity
                };
            }

            return new VacancyWithRatingModel
            {
                Id = vacancy.Id,
                Rating = (double)matchesCount / vacancySkillsCount
            };
        }
    }
}
