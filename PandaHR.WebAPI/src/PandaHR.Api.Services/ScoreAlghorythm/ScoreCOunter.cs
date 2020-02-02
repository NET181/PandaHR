using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<IdAndRaiting>> GetCVsByVacancy(VacancyAlghorythmModel vacancy)
        {
            VacancyAlghorythmModel vacancy2 = TestVacansy();


            var qualifications
                = new List<Qualification>(await _qualificationService.GetAllAsync());
            var cVs
                = new List<CVServiceModel>(await _cVService.GetAllAsync());
            var skillTypes
                = new List<SkillType>(await _skillTypeService.GetAllAsync());

            int hardSkillScaleStep = PERCENT_DIVIDER / skillTypes[0].SkillKnowledgeTypes.Count;
            int softSkillScaleStep = PERCENT_DIVIDER / skillTypes[1].SkillKnowledgeTypes.Count;
            int languageSkillScaleStep = PERCENT_DIVIDER / skillTypes[2].SkillKnowledgeTypes.Count;
            int qualificationScaleStep = PERCENT_DIVIDER / qualifications.Count;



            List<CVAlghorythmModel> algCVs = new List<CVAlghorythmModel>();

            List<SkillKnowledgeAlghorythmModel> knowledges = new List<SkillKnowledgeAlghorythmModel>();

            for (int i = 0; i < cVs.Count; i++)
            {

                algCVs.Add(new CVAlghorythmModel());

                algCVs.Last().Id = cVs[i].Id;
                algCVs.Last().Qualification = qualifications.FirstOrDefault(q => q.Id == cVs[i].QualificationId).Value;
                algCVs.Last().SkillKnowledges = new List<SkillKnowledgeAlghorythmModel>();
                //{
                //    Id = cVs[i].Id,
                //    Qualification = cVs[i].Qualification.Value
                //});
                foreach (var sk in cVs[i].SkillKnowledges)
                {
                    algCVs[i].SkillKnowledges.Add(new SkillKnowledgeAlghorythmModel()
                    {
                        KnowledgeLevel = 5,
                        Expiriense = 1,
                        Skill = new SkillAlghorythmModel()
                        {
                            Id = sk.SkillId,
                            //Name = sk.Skill.Name,
                            SupSkills = new List<SkillAlghorythmModel>()
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

        private static VacancyAlghorythmModel TestVacansy()
        {
            List<SkillRequestAlghorythmModel> skillRequests = new List<SkillRequestAlghorythmModel>();

            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Expiriense = 0,
                KnowledgeLevel = 5,
                Skill = new SkillAlghorythmModel()
                {
                    Id = new Guid("c7ea5c5d-4468-43c2-ba14-08d7a81161ba"),
                    Name = "C#",
                    SkillType = 1
                },
                Weight = 80
            });

            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Expiriense = 0,
                KnowledgeLevel = 5,
                Skill = new SkillAlghorythmModel()
                {
                    Id = new Guid("80d1d89b-618d-4cfc-ba15-08d7a81161ba"),
                    Name = "Asp.Net Core",
                    SkillType = 1
                },
                Weight = 40
            });

            VacancyAlghorythmModel vacancy2 = new VacancyAlghorythmModel()
            {
                Id = new Guid("8794dabf-2f91-423d-87c4-6317e2913be7"),
                Qualification = 5,
                SkillRequests = skillRequests
            };

            return vacancy2;
        }
    }
}
