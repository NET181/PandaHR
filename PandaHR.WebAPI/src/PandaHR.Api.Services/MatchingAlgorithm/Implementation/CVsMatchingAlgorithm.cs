using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Models;

namespace PandaHR.Api.Services.SkillMatchingAlgorithm.Implementation
{
    public class CVsMatchingAlgorithm : IСVsMatchingAlgorithm
    {
        public async Task<IEnumerable<CVWithRatingModel>> SearchByVacancy(
            IEnumerable<CVMatchingAlgorithmModel> cvs,
            VacancyMatchingAlgorithmModel vacancy,
            double threshold)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException(nameof(vacancy));
            }

            IEnumerable<SkillMatchingAlgorithmModel> requiredSkills = vacancy.SkillRequirements.Select(s => s.Skill);

            var result = Task.Run(() =>
            {
                return cvs
                .Select(cv => GetCVWithRating(cv, requiredSkills))
                .Where(v => v.Rating >= threshold)
                .OrderByDescending(v => v.Rating);
            });

            return await result;
        }

        private CVWithRatingModel GetCVWithRating(
            CVMatchingAlgorithmModel cv,
            IEnumerable<SkillMatchingAlgorithmModel> requiredSkills)
        {
            IEnumerable<Guid> vacancySkillIds = cv.SkillKnowledges.Select(s => s.Skill.Id);

            int matchesCount = requiredSkills
                .Select(s => s.Id)
                .Intersect(vacancySkillIds)
                .Count();
            int requiredSkillsCount = requiredSkills.Count();

            if (requiredSkillsCount == 0)
            {
                return new CVWithRatingModel
                {
                    Id = cv.Id,
                    Rating = double.PositiveInfinity
                };
            }

            return new CVWithRatingModel
            {
                Id = cv.Id,
                Rating = (double)matchesCount / requiredSkillsCount
            };
        }
    }
}

