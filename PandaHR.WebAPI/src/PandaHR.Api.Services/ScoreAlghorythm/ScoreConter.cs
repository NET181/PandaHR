using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.Skill;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.Services.ScoreAlghorythm.Models;


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

        public async Task<List<IdAndRating>> GetCVsByVacancy(Guid vacancyId)
        {
            var vacansy = await GetVacancyFromDBAsync(vacancyId);

            var qualifications 
                = new List<Qualification>(await _qualificationService.GetAllAsync());
            var cVs = new List<CVServiceModel>(await _cVService.GetAllAsync());
            var skillTypes = new List<SkillType>(await _skillTypeService.GetAllAsync());

            int hardSkillScaleStep = PERCENT_DIVIDER / skillTypes[0].SkillKnowledgeTypes.Count;
            int softSkillScaleStep = PERCENT_DIVIDER / skillTypes[1].SkillKnowledgeTypes.Count;
            int languageSkillScaleStep = PERCENT_DIVIDER / skillTypes[2].SkillKnowledgeTypes.Count;
            int qualificationScaleStep = PERCENT_DIVIDER / qualifications.Count;

            List<CVAlghorythmModel> algCVs = new List<CVAlghorythmModel>();

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
                        KnowledgeLevel = sk.KnowledgeLevel
                        .SkillKnowledgeTypes
                        .Where(i => i.KnowledgeLevelId == sk.KnowledgeLevelId)
                        .FirstOrDefault().Value,
                        Expiriense = sk.Experience.Value,
                        Skill = new SkillAlghorythmModel()
                        {
                            Id = sk.SkillId,
                            SupSkills = MapSubSkills(sk.Skill)
                        }
                    });
                }
            }

            return _alghorythm.GetCVsRating(vacansy, algCVs
                , languageSkillScaleStep, hardSkillScaleStep
                , softSkillScaleStep, qualificationScaleStep);
        }

        private async Task<VacancyAlghorythmModel> GetVacancyFromDBAsync(Guid id)
        {
            VacancyAlghorythmModel vacancy = new VacancyAlghorythmModel();

            VacancyServiceModel vacancy2 = await _vacancyService.GetByIdWithSkillAsync(id);

            vacancy.Id = vacancy2.Id;
            vacancy.Qualification = vacancy2.Qualification.Value;

            foreach (var sr in vacancy2.SkillRequirements)
            {
                vacancy.SkillRequests.Add(new SkillRequestAlghorythmModel()
                {
                    Expiriense = sr.Experience.Value,
                    KnowledgeLevel = sr.KnowledgeLevel
                        .SkillKnowledgeTypes
                        .Where(i => i.KnowledgeLevelId == sr.KnowledgeLevelId)
                        .FirstOrDefault().Value,
                    Weight = (int)sr.Weight,
                    Skill = new SkillAlghorythmModel()
                    {
                        Id = sr.SkillId,
                        SkillType = sr.Skill.SkillType.Value,
                        SupSkills = MapSubSkills(sr.Skill)
                    }
                });
            }
            
            return vacancy;
        }

        private List<SkillAlghorythmModel> MapSubSkills(Skill skill)
        {
            if (skill.SubSkills == null)
            {
                return null;
            }

            var result = new List<SkillAlghorythmModel>(skill.SubSkills.Count);

            foreach (var subSkill in skill.SubSkills)
            {
                result.Add(new SkillAlghorythmModel()
                {
                    Id = subSkill.Id,
                    SkillType = subSkill.SkillType.Value,
                    SupSkills = MapSubSkills(subSkill)
                });
            }

            return result;
        }
        private List<SkillAlghorythmModel> MapSubSkills(SkillServiceModel skill)
        {
            if (skill.SubSkills == null)
            {
                return null;
            }

            var result = new List<SkillAlghorythmModel>(skill.SubSkills.Count);

            foreach (var subSkill in skill.SubSkills)
            {
                result.Add(new SkillAlghorythmModel()
                {
                    Id = subSkill.Id,
                    SkillType = subSkill.SkillType.Value,
                    SupSkills = MapSubSkills(subSkill)
                });
            }

            return result;
        }
    }
}
