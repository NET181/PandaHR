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
        // мокать всёж
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
                SkillType = 1, //HardSkill
            };
            dotNetSubs.Add(ASPNetCore);

            EntityFramework = new SkillAlghorythmModel()
            {
                Id = new Guid("13aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = 1, //HardSkill
            };
            dotNetSubs.Add(EntityFramework);

            DotNet = new SkillAlghorythmModel()
            {
                Id = new Guid("52aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = 1, //HardSkill
                SubSkills = dotNetSubs
            };

            English = new SkillAlghorythmModel()
            {
                Id = new Guid("22aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = 2, //LangSkill
            };

            Friendliness = new SkillAlghorythmModel()
            {
                Id = new Guid("32aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = 3, //SoftSkill
            };

            Oratory = new SkillAlghorythmModel()
            {
                Id = new Guid("44aab402-50c0-424a-aae0-4cf59a3d577b"),
                SkillType = 3, //SoftSkill
            };

        }

        private void ConfigRequests()
        {
            var skillRequests = new List<SkillRequestAlghorythmModel>();

            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = DotNet
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = Oratory
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = Friendliness
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = English
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = EntityFramework
            });
            skillRequests.Add(new SkillRequestAlghorythmModel()
            {
                Skill = ASPNetCore
            });

            SkillRequests = skillRequests;
        }
    }
}
