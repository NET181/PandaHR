using PandaHR.Api.Services.ScoreAlgorithm.Models;
using PandaHR.Api.Services.ScoreAlgorithm.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaHR.Api.Services.ScoreAlgorithm
{
    public class ScoreAlghorythm
    {
        private readonly RatingCounter _ratingCounter;
        private readonly SkillsMatcher _skillsMatcher;
        private readonly SkillSplitter _skillSplitter;

        internal ScoreAlghorythm(SkillSplitter skillSplitter, RatingCounter ratingCounter, SkillsMatcher skillsMatcher)
        {
            _skillSplitter = skillSplitter;
            _ratingCounter = ratingCounter;
            _skillsMatcher = skillsMatcher;
        }

        public int GetRating(VacancyAlghorythmModel vacancy, CVAlghorythmModel cV)
        {
            int middleWeight = FindMiddleWeight(vacancy.SkillRequests);
            var splitedSkills = _skillSplitter.SplitSkills(vacancy.SkillRequests, middleWeight);

            splitedSkills = _skillsMatcher.MatchSkills(cV.SkillKnowledges, splitedSkills);

            return _ratingCounter.CountRating(splitedSkills, cV, vacancy, middleWeight);
        }

        public List<IdAndRating> GetCVsRating(VacancyAlghorythmModel vacancy, IEnumerable<CVAlghorythmModel> cVs)
        {
            List<IdAndRating> cvsByRaiting = new List<IdAndRating>();
            int middleWeight = FindMiddleWeight(vacancy.SkillRequests);
            var splitedSkills = _skillSplitter.SplitSkills(vacancy.SkillRequests, middleWeight);
            int rating;

            foreach (CVAlghorythmModel cV in cVs)
            {
                splitedSkills = _skillsMatcher.MatchSkills(cV.SkillKnowledges, splitedSkills);

                rating = _ratingCounter.CountRating(splitedSkills, cV, vacancy, middleWeight);
                cvsByRaiting.Add(new IdAndRating()
                {
                    Id = cV.Id,
                    Rating = rating
                });

                splitedSkills.ClearCV();
            }
            cvsByRaiting = cvsByRaiting.OrderByDescending(x => x.Rating).ToList();

            return cvsByRaiting;
        }

        public List<IdAndRating> GetVacancysRaiting(IEnumerable<VacancyAlghorythmModel> vacancys, CVAlghorythmModel cV)
        {


            List<IdAndRating> vacancysByRating = new List<IdAndRating>();
            int middleWeight;
            SplitedSkillsAlghorythmModel splitedSkills;
            int raiting;

            foreach (VacancyAlghorythmModel vacancy in vacancys)
            {
                middleWeight = FindMiddleWeight(vacancy.SkillRequests);
                splitedSkills = _skillSplitter.SplitSkills(vacancy.SkillRequests, middleWeight);

                splitedSkills = _skillsMatcher.MatchSkills(cV.SkillKnowledges, splitedSkills);

                raiting = _ratingCounter.CountRating(splitedSkills, cV, vacancy, middleWeight);
                vacancysByRating.Add(new IdAndRating()
                {
                    Rating = raiting,
                    Id = vacancy.Id
                });

                splitedSkills = new SplitedSkillsAlghorythmModel();
            }
            vacancysByRating = vacancysByRating.OrderByDescending(x => x.Rating).ToList();

            return vacancysByRating;
        }

        private int FindMiddleWeight(List<SkillRequestAlghorythmModel> sr)
        {
            int result = 0;

            sr = sr.OrderByDescending(w => w.Weight).ToList();
            result = (sr.First().Weight - sr.Last().Weight) / sr.Count();

            return result;
        }
    }
}
