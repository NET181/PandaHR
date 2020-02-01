using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public class ScoreCounter : IScoreCounter
    {
        private const int PERCENT_DIVIDER = 100;

        private readonly IScoreAlghorythm _alghorythm;
        private readonly ICVService _cVService;
        private readonly IVacancyService _vacancyService;
        private readonly ISkillTypeService _skillTypeService;
        private readonly IQualificationService _qualificationService;

        public ScoreCounter(IScoreAlghorythm alghorythm, ICVService cVService
            , IVacancyService vacancyService, ISkillTypeService skillTypeService
            , IQualificationService qualificationService)
        {
            _alghorythm = alghorythm;
            _cVService = cVService;
            _vacancyService = vacancyService;
            _skillTypeService = skillTypeService;
            _qualificationService = qualificationService;
        }

        public async Task<List<IdAndRaiting>> GetCVsByVacancy(Vacancy vacancy)
        {
            List<SkillRequest> skillRequests = new List<SkillRequest>();

            skillRequests.Add(new SkillRequest()
            {
                Expiriense = 0,
                KnowledgeLevel = 5,
                Skill = new Skill()
                {
                    Name = "C#",
                    SkillType = 2
                },
                Weight = 80
            });

            skillRequests.Add(new SkillRequest()
            {
                Expiriense = 0,
                KnowledgeLevel = 5,
                Skill = new Skill()
                {
                    Name = "Asp.Net Core",
                    SkillType = 2
                },
                Weight = 40
            });

            Vacancy vacancy2 = new Vacancy()
            {
                Id = new Guid("8794dabf-2f91-423d-87c4-6317e2913be7"),
                Qualification = 5,
                SkillRequests = skillRequests
            };
            List<IdAndRaiting> cVsByRaiting = new List<IdAndRaiting>();
            var qualifications
                = new List<DAL.Models.Entities.Qualification>(await _qualificationService.GetAllAsync());
            var cVs
                = new List<DAL.Models.Entities.CV>(await _cVService.GetAllAsync());
            var skillTypes
                = new List<DAL.Models.Entities.SkillType>(await _skillTypeService.GetAllAsync());

            int hardSkillScaleStep = PERCENT_DIVIDER / skillTypes[0].SkillKnowledgeTypes.Count;
            int softSkillScaleStep = PERCENT_DIVIDER / skillTypes[1].SkillKnowledgeTypes.Count;
            int languageSkillScaleStep = PERCENT_DIVIDER / skillTypes[2].SkillKnowledgeTypes.Count;
            int qualificationScaleStep = PERCENT_DIVIDER / qualifications.Count;

            List<CV> algCVs = new List<CV>();
            List<SkillKnowledge> knowledges = new List<SkillKnowledge>();

            for (int i = 0; i < cVs.Count; i++)
            {

                algCVs.Add(new CV()
                {
                    Id = cVs[i].Id,
                    Qualification = cVs[i].Qualification.Value
                });
                foreach (var sk in cVs[i].SkillKnowledges)
                {
                    algCVs[i].SkillKnowledges.Add(new SkillKnowledge()
                    {
                        KnowledgeLevel = 5,
                        Expiriense = 1,
                        Skill = new Skill()
                        {
                            Name = sk.Skill.Name,
                            SupSkills = new List<Skill>()
                        }
                    });
                }
            }

            var some = _alghorythm.GetCVsRaiting(vacancy2, algCVs
                , languageSkillScaleStep, hardSkillScaleStep
                , softSkillScaleStep, qualificationScaleStep);

            return _alghorythm.GetCVsRaiting(vacancy2, algCVs
                , languageSkillScaleStep, hardSkillScaleStep
                , softSkillScaleStep, qualificationScaleStep);
        }
    }
}
