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

        public async Task<List<IdAndRaiting>> GetCVsByVacancy(Guid vacancyId)
        {
            VacancyAlghorythmModel vacancy2 = TestVacansy();

      //      var vacancy3 = await _vacancyService.GetByIdAsync(vacancyId);
             var aaa = await GetVacancyFromDBAsync(vacancyId);

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

                foreach (var sk in cVs[i].SkillKnowledges)
                {
                    algCVs[i].SkillKnowledges.Add(new SkillKnowledgeAlghorythmModel()
                    {
                        KnowledgeLevel = 5,
                        Expiriense = 1,
                        Skill = new SkillAlghorythmModel()
                        {
                            Id = sk.SkillId,
                            SupSkills = new List<SkillAlghorythmModel>()
                        }
                    });
                }
            }

            var aaaaaa = _alghorythm.GetCVsRaiting(aaa, algCVs
                , languageSkillScaleStep, hardSkillScaleStep
                , softSkillScaleStep, qualificationScaleStep);

            return _alghorythm.GetCVsRaiting(aaa, algCVs
                , languageSkillScaleStep, hardSkillScaleStep
                , softSkillScaleStep, qualificationScaleStep);
        }

        private async Task<VacancyAlghorythmModel> GetVacancyFromDBAsync(Guid id)
        {
            VacancyAlghorythmModel vacancy = new VacancyAlghorythmModel();

            Vacancy vacancy2 = await _vacancyService.GetByIdAsync(id);

             vacancy.Id = vacancy2.Id;
            vacancy.Qualification = vacancy2.Qualification.Value;

            foreach (var sr in vacancy2.SkillRequirements)
            {
                vacancy.SkillRequests.Add(new SkillRequestAlghorythmModel()
                {
                    Expiriense = 5,
                    KnowledgeLevel = 3,
                    Weight = (int)sr.Weight,
                    Skill = new SkillAlghorythmModel()
                    {
                        Id = sr.SkillId,
                        SkillType = 1
                        
                    }
                }); 
            }
            //var s = new SkillAlghorythmModel()
            //{
            //    //Id = sr.Skill.Id,
            //    Id = new Guid(),
            //    SkillType = 1
            //    //    SupSkills = new List<SkillAlghorythmModel>()
            //};
            return vacancy;
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
                    Id = new Guid("b072e561-9258-4512-8b40-c545b121cb0c"),
                    SkillType = 1
                },
                Weight = 40
            });

            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Expiriense = 0,
                KnowledgeLevel = 5,
                Skill = new SkillAlghorythmModel()
                {
                    Id = new Guid("b072e511-9258-4502-8b40-c545b121cb0c"),
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
