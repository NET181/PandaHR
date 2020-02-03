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
            var skillKnowledges = cvDto.SkillKnowledges;
            var skillsId = skillKnowledges.Select(s => s.SkillId);
            var experiencesId = skillKnowledges.Select(s => s.ExperienceId);
            var knowledgesLevelsId = skillKnowledges.Select(s => s.KnowledgeLevelId);
            var technologyId = cvDto.TechnologyId;
            var qualificationId = cvDto.QualificationId;

            var skills = await _context.Skills
                .Where(s => skillsId.Contains(s.Id)).ToListAsync();

            var experiences = await _context.Experiences
                .Where(e => experiencesId.Contains(e.Id)).ToListAsync();

            var knowledgeLevels = await _context.KnowledgeLevels
                .Where(k => knowledgesLevelsId.Contains(k.Id)).ToListAsync();

            var technology = await _context.Technologies.FirstOrDefaultAsync(t => t.Id == technologyId);
            var qualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == qualificationId);

            CV cv = _mapper.Map<CVDTO, CV>(cvDto);

            cv.Qualification = qualification;
            cv.Technology = technology;
            cv.SkillKnowledges = new Collection<SkillKnowledge>();
            
            for(int i = 0; i < skillKnowledges.Count; i++)
            {
                cv.SkillKnowledges.Add(new SkillKnowledge()
                {
                    
                });
            }

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
