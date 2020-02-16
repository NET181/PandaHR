using PandaHR.Api.Services.ScoreAlgorithm;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.UnitTests.AlghorythmTests.Tests
{
    public class AlghorythmTestSeed
    {
        private const int HARD_SKILLS_SCALE_STEP = 6;
        private const int LANG_SKILLS_SCALE_STEP = 6;
        private const int SOFT_SKILLS_SCALE_STEP = 6;
        private const int QUALIFICATION_SCALE_STEP = 20;
        private const int HARD_SKILLS_SKILL_TYPE = 1;
        private const int LANGUAGE_SKILLS_SKILL_TYPE = 2;
        private const int SOFT_SKILLS_SKILL_TYPE = 3;
        private const int INTERMEDIATE_QUALIFICATION_VALUE = 3;
        private const int INTERMEDIATE_KNOWLEDGE_VALUE = 6;

        private KnowledgeScaleSteps _knowledgeScaleSteps;

        public List<SkillRequestAlghorythmModel> SkillRequests { get; private set; }
        public List<SkillKnowledgeAlghorythmModel> SkillKnowledge { get; private set; }

        public SplitedSkillsAlghorythmModel SplitedSkills { get; set; }

        public SkillAlghorythmModel DotNet { get; private set; }
        public SkillAlghorythmModel ASPNetCore { get; private set; }
        public SkillAlghorythmModel EntityFramework { get; private set; }
        public SkillAlghorythmModel English { get; private set; }
        public SkillAlghorythmModel Friendliness { get; private set; }
        public SkillAlghorythmModel Oratory { get; private set; }

        internal SkillsMatcher SkillsMatcher { get; private set; }
        internal SkillSplitter SkillSplitter { get; private set; }
        internal RatingCounter RatingCounter { get; private set; }
        internal ScoreAlghorythmBuilder AlghorythmBuilder { get; private set; }
        internal ScoreAlghorythm Alghorythm { get; private set; }

        public VacancyAlghorythmModel Vacancy { get; set; }
        public CVAlghorythmModel CV { get; set; }

        public AlghorythmTestSeed()
        {
            ConfigSkills();
            ConfigRequests();
            ConfigSkillSplitter();
            ConfigSplitedSkills();
            ConfigSkillMathcer();
            ConfigVacancy();
            ConfigSkillKnowledge();
            ConfigCV();
            ConfigKnowledgeScaleStep();
            ConfigRatingCounter();
            ConfigAlghorythmBuilder();
            ConfigScoreAlghorythm();
        }

        private void ConfigScoreAlghorythm()
        {
            SkillTypeValuesw skillTypeValues = new SkillTypeValuesw()
            {
                HardSkillsValue = HARD_SKILLS_SKILL_TYPE,
                LanguageSkillsValue = LANGUAGE_SKILLS_SKILL_TYPE,
                SoftSkillsValue = SOFT_SKILLS_SKILL_TYPE
            };
            KnowledgeScaleSteps knowledgeScaleSteps = new KnowledgeScaleSteps()
            {
                HardKnowledgeScaleStep = HARD_SKILLS_SCALE_STEP,
                LanguageKnowledgeScaleStep = LANG_SKILLS_SCALE_STEP,
                QualificationScaleStep = QUALIFICATION_SCALE_STEP,
                SoftKnowledgeScaleStep = SOFT_SKILLS_SCALE_STEP
            };

            Alghorythm = AlghorythmBuilder.GetScoreAlghorythm(skillTypeValues, knowledgeScaleSteps);
        }

        private void ConfigAlghorythmBuilder()
        {
            AlghorythmBuilder = new ScoreAlghorythmBuilder();
        }

        private void ConfigKnowledgeScaleStep()
        {
            _knowledgeScaleSteps = new KnowledgeScaleSteps()
            {
                HardKnowledgeScaleStep = HARD_SKILLS_SCALE_STEP,
                LanguageKnowledgeScaleStep = LANG_SKILLS_SCALE_STEP,
                QualificationScaleStep = QUALIFICATION_SCALE_STEP,
                SoftKnowledgeScaleStep = SOFT_SKILLS_SCALE_STEP
            };
        }

        private void ConfigRatingCounter()
        {
            RatingCounter = new RatingCounter(_knowledgeScaleSteps);
        }

        private void ConfigCV()
        {
            CV = new CVAlghorythmModel()
            {
                Id = new Guid("12aab432-50c0-424a-aae0-4cf89a3d577b"),
                Qualification = INTERMEDIATE_QUALIFICATION_VALUE,
                SkillKnowledges = SkillKnowledge
            };
        }

        private void ConfigSkillKnowledge()
        {
            var skillKnowledge = new List<SkillKnowledgeAlghorythmModel>();

            skillKnowledge.Add(new SkillKnowledgeAlghorythmModel()
            {
                Skill = DotNet,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillKnowledge.Add(new SkillKnowledgeAlghorythmModel()
            {
                Skill = Oratory,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillKnowledge.Add(new SkillKnowledgeAlghorythmModel()
            {
                Skill = Friendliness,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillKnowledge.Add(new SkillKnowledgeAlghorythmModel()
            {
                Skill = English,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillKnowledge.Add(new SkillKnowledgeAlghorythmModel()
            {
                Skill = EntityFramework,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillKnowledge.Add(new SkillKnowledgeAlghorythmModel()
            {
                Skill = ASPNetCore,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });

            SkillKnowledge = skillKnowledge;
        }

        private void ConfigVacancy()
        {
            Vacancy = new VacancyAlghorythmModel()
            {
                Id = new Guid("12aab402-50c0-424a-aae0-4cf89a3d577b"),
                Qualification = INTERMEDIATE_QUALIFICATION_VALUE,
                SkillRequests = SkillRequests
            };
        }

        private void ConfigSkillMathcer()
        {
            SkillsMatcher = new SkillsMatcher();
        }

        private void ConfigSkillSplitter()
        {
            var skillTypeValue = new SkillTypeValuesw()
            {
                SoftSkillsValue = SOFT_SKILLS_SKILL_TYPE,
                HardSkillsValue = HARD_SKILLS_SKILL_TYPE,
                LanguageSkillsValue = LANGUAGE_SKILLS_SKILL_TYPE,
            };

            SkillSplitter = new SkillSplitter(skillTypeValue);
        }

        private void ConfigSkills()
        {
            var dotNetSubs = new List<SkillAlghorythmModel>();

            ASPNetCore = new SkillAlghorythmModel()
            {
                Id = new Guid("12aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = HARD_SKILLS_SKILL_TYPE,
            };
            dotNetSubs.Add(ASPNetCore);

            EntityFramework = new SkillAlghorythmModel()
            {
                Id = new Guid("13aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = HARD_SKILLS_SKILL_TYPE, 
            };
            dotNetSubs.Add(EntityFramework);

            DotNet = new SkillAlghorythmModel()
            {
                Id = new Guid("52aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = HARD_SKILLS_SKILL_TYPE, 
                SubSkills = dotNetSubs
            };

            English = new SkillAlghorythmModel()
            {
                Id = new Guid("22aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = LANGUAGE_SKILLS_SKILL_TYPE, 
            };

            Friendliness = new SkillAlghorythmModel()
            {
                Id = new Guid("32aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = SOFT_SKILLS_SKILL_TYPE, 
            };

            Oratory = new SkillAlghorythmModel()
            {
                Id = new Guid("44aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = SOFT_SKILLS_SKILL_TYPE,
            };
        }

        private void ConfigSplitedSkills()
        {
            var hardSkills = new List<SkillRequestSkillKnowledge>();
            var langSkills = new List<SkillRequestSkillKnowledge>();
            var mainSkills = new List<SkillRequestSkillKnowledge>();
            var softSkills = new List<SkillRequestSkillKnowledge>();

            mainSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = DotNet,
                    Weight = 80
                }
            });
            mainSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = EntityFramework,
                    Weight = 75
                }
            });

            hardSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = ASPNetCore,
                    Weight = 45
                }
            });

            langSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = English,
                    Weight = 80
                }
            });

            softSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = Oratory,
                    Weight = 35
                }
            });
            softSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = Friendliness,
                    Weight = 15
                }
            });

            SplitedSkills = new SplitedSkillsAlghorythmModel()
            {
                HardSkills = hardSkills,
                LangSkills = langSkills,
                MainSkills = mainSkills,
                SoftSkills = softSkills
            };
        }

        private void ConfigRequests()
        {
            var skillRequests = new List<SkillRequestAlghorythmModel>();

            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = DotNet,
                Weight = 80,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = Oratory,
                Weight = 35,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = Friendliness,
                Weight = 15,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = English,
                Weight = 80,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = EntityFramework,
                Weight = 75,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = ASPNetCore,
                Weight = 45,
                KnowledgeLevel = INTERMEDIATE_KNOWLEDGE_VALUE
            });

            SkillRequests = skillRequests;
        }
    }
}
