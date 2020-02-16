using PandaHR.Api.Services.ScoreAlgorithm;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.UnitTests.AlghorythmTests.UnitTests
{
    public class AlghorythmTestSeed
    {
        private const int HARD_SKILLS_SKILL_TYPE = 1;
        private const int LANGUAGE_SKILLS_SKILL_TYPE = 2;
        private const int SOFT_SKILLS_SKILL_TYPE = 3;

        public IReadOnlyList<SkillRequestAlghorythmModel> SkillRequests { get; private set; }
        public SkillAlghorythmModel DotNet { get; private set; }
        public SkillAlghorythmModel ASPNetCore { get; private set; }
        public SkillAlghorythmModel EntityFramework { get; private set; }
        public SkillAlghorythmModel English { get; private set; }
        public SkillAlghorythmModel Friendliness { get; private set; }
        public SkillAlghorythmModel Oratory { get; private set; }
        internal SkillSplitter SkillSplitter { get; private set; }
        

        public AlghorythmTestSeed()
        {
            ConfigSkills();
            ConfigRequests();
            ConfigSkillSplitter();

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

        private void ConfigRequests()
        {
            var skillRequests = new List<SkillRequestAlghorythmModel>();

            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = DotNet,
                Weight = 80
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = Oratory,
                Weight = 35
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = Friendliness,
                Weight = 15
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = English,
                Weight = 80
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = EntityFramework,
                Weight = 75
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = ASPNetCore,
                Weight = 45
            });

            SkillRequests = skillRequests;
        }
    }
}
