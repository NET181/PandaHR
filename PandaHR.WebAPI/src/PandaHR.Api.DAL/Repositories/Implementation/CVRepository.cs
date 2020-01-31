using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class CVRepository : EFRepositoryAsync<CV>, ICVRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CVRepository(IMapper mapper, ApplicationDbContext context) :
            base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddAsync(CVDTO cvDto)
        {
            var skillKnowledge = cvDto.SkillKnowledges.ElementAt(0);

            var skillId = skillKnowledge.SkillId;
            var experienceId = skillKnowledge.ExperienceId;
            var knowledgeLevelId = skillKnowledge.KnowledgeLevelId;
            //var technologyId = cvDto.TechnologyId;
            //var qualificationId = cvDto.QualificatonId;
            var technologyId = new Guid("f43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e");
            var qualificationId = new Guid("6015f293-a102-459b-9fa3-2ce7cc92c386");


            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == skillId);
            var experience = await _context.Experiences.FirstOrDefaultAsync(e => e.Id == experienceId);
            var knowledgeLevel = await _context.KnowledgeLevels.FirstOrDefaultAsync(k => k.Id == knowledgeLevelId);
            var technology = await _context.Technologies.FirstOrDefaultAsync(t => t.Id == technologyId);
            var qualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == qualificationId);
            var user = await _context.Users.FirstOrDefaultAsync(u => 
                u.Id == new Guid("5e0b7eed-1e24-4166-8f00-a563923d1fc5"));

            CV cv = _mapper.Map<CVDTO, CV>(cvDto);

            cv.Qualification = qualification;
            cv.Technology = technology;
            cv.User = user;
            cv.SkillKnowledges = new Collection<SkillKnowledge>();
            cv.SkillKnowledges
                .Add(new SkillKnowledge()
             {
                 Skill = skill,
                 Experience = experience,
                 KnowledgeLevel = knowledgeLevel,
                 IsDeleted = false,
             });

            await _context.CVs.AddAsync(cv);
            await _context.SaveChangesAsync();
        }

        public async Task<CV> GetById(Guid id)
        {
            var jobExperience = await _context.CVs.Where(j => j.Id == id).FirstAsync();
            return jobExperience;
        }
    }
}
