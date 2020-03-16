using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.Skill;
using PandaHR.Api.Services.Models.SkillRequirement;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using PandaHR.Api.Services.ScoreAlgorithm;
using PandaHR.Api.Services.ScoreAlgorithm.Models;

namespace PandaHR.Api.Services.ScoreAlghorythm
{
    public class ScoreCounter : IScoreCounter
    {
        private const int PERCENT_DIVIDER = 100;

        private readonly IScoreAlghorythmBuilder _alghorythmBuilder;
        private readonly ICVService _cVService;
        private readonly IVacancyService _vacancyService;
        private readonly ISkillTypeService _skillTypeService;
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;
        private IScoreAlghorythm _alghorythm;

        public ScoreCounter(IScoreAlghorythmBuilder alghorythmBuilder, ICVService cVService
            , IVacancyService vacancyService, ISkillTypeService skillTypeService
            , IQualificationService qualificationService, IMapper mapper)
        {
            _mapper = mapper;
            _alghorythmBuilder = alghorythmBuilder;
            _cVService = cVService;
            _vacancyService = vacancyService;
            _skillTypeService = skillTypeService;
            _qualificationService = qualificationService;
        }

        public async Task<IEnumerable<AlghorythmResponseServiceModel>> GetCVsByVacancy(Guid vacancyId)
        {

            int a = 5;

            var vacansy = await GetVacancyFromDBAsync(vacancyId);

            var qualifications = new List<Qualification>(await _qualificationService.GetAllAsync());
            var cVs = new List<CVServiceModel>(await _cVService.GetAllAsync());
            var skillTypes = new List<SkillType>(await _skillTypeService.GetAllAsync());

            List<CVAlghorythmModel> algCVs = new List<CVAlghorythmModel>();

            var knowledgeScaleSteps = new KnowledgeScaleStepsAlgorithmModel()
            {
                HardKnowledgeScaleStep = PERCENT_DIVIDER / skillTypes[0].SkillKnowledgeTypes.Count,
                SoftKnowledgeScaleStep = PERCENT_DIVIDER / skillTypes[1].SkillKnowledgeTypes.Count,
                LanguageKnowledgeScaleStep = PERCENT_DIVIDER / skillTypes[2].SkillKnowledgeTypes.Count,
                QualificationScaleStep = PERCENT_DIVIDER / qualifications.Count
            };
            var skillTypeValues = new SkillTypeValuesAlgorithmModel()
            {
                SoftSkillsValue = skillTypes[1].Value,
                HardSkillsValue = skillTypes[0].Value,
                LanguageSkillsValue = skillTypes[2].Value

            };

            _alghorythm = _alghorythmBuilder.GetScoreAlghorythm(
                _mapper.Map<SkillTypeValuesAlgorithmModel, SkillTypeValues>(skillTypeValues),
                _mapper.Map<KnowledgeScaleStepsAlgorithmModel, KnowledgeScaleSteps>(knowledgeScaleSteps));

            for (int i = 0; i < cVs.Count; i++)
            {

                algCVs.Add(new CVAlghorythmModel());

                algCVs.Last().Id = cVs[i].Id;
                algCVs.Last().Qualification = qualifications
                    .FirstOrDefault(q => q.Id == cVs[i].QualificationId).Value;
                algCVs.Last().SkillKnowledges = new List<SkillKnowledgeAlghorythmModel>();

                foreach (var sk in cVs[i].SkillKnowledges)
                {
                    algCVs[i].SkillKnowledges.Add(new SkillKnowledgeAlghorythmModel()
                    {
                        KnowledgeLevel = sk.KnowledgeLevel
                        .SkillKnowledgeTypes
                        .Where(i => i.KnowledgeLevelId == sk.KnowledgeLevelId)
                        .FirstOrDefault().Value,
                        Expirience = sk.Experience.Value,
                        Skill = new SkillAlghorythmModel()
                        {
                            Id = sk.SkillId,
                            SubSkills = MapSubSkills(sk.Skill)
                        }
                    });
                }
            }

            var alghResponse = new List<AlghorythmResponseServiceModel>(_mapper.Map<IEnumerable<IdAndRating>
                , IEnumerable<AlghorythmResponseServiceModel>>(_alghorythm.GetCVsRating(vacansy, algCVs)));

            return FindCVTitle(cVs, alghResponse);
        }

        public IEnumerable<AlghorythmResponseServiceModel> FindCVTitle(IEnumerable<CVServiceModel> cVs,
            IEnumerable<AlghorythmResponseServiceModel> alghorythmResponses)
        {
            foreach (var algResponse in alghorythmResponses)
            {
                foreach (var cV in cVs)
                {
                    if (algResponse.Id == cV.Id)
                    {
                        algResponse.Title = cV.Summary;
                        break;
                    }
                }
            }

            return alghorythmResponses;
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
                    Expirience = sr.Experience.Value,
                    KnowledgeLevel = sr.KnowledgeLevel
                        .SkillKnowledgeTypes
                        .Where(i => i.KnowledgeLevelId == sr.KnowledgeLevelId)
                        .FirstOrDefault().Value,
                    Weight = (int)sr.Weight,
                    Skill = new SkillAlghorythmModel()
                    {
                        Id = sr.SkillId,
                        SkillType = sr.Skill.SkillType.Value,
                        SubSkills = MapSubSkills(sr.Skill)
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
                    SubSkills = MapSubSkills(subSkill)
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
                    SubSkills = MapSubSkills(subSkill)
                });
            }

            return result;
        }
    }
}
