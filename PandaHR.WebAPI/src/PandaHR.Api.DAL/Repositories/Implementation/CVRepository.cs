using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System.Collections.ObjectModel;
using PandaHR.Api.DAL.DTOs.JobExperience;

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
                    Skill = skills[i],
                    Experience = experiences[i],
                    KnowledgeLevel = knowledgeLevels[i]
                });
            }

            await _context.CVs.AddAsync(cv);
            await _context.SaveChangesAsync();
        }

        public async Task<CV> GetById(Guid id)
        {
            var CV = await _context.CVs.Where(j => j.Id == id).FirstAsync();
            return CV;
        }

        public async Task<IEnumerable<CVSummaryDTO>> GetUserCVSummaryAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            IEnumerable<CV> query = await _context.CVs.Where(cv => cv.UserId == userId)
                .Include(c => c.Qualification)
                .Include(c => c.Technology)
                .ToListAsync();

            if (pageSize != null && page != null)
            {
                query = query.Skip((int)pageSize * ((int)page - 1)).Take((int)pageSize);
            }

            return _mapper.Map<IEnumerable<CV>, IEnumerable<CVSummaryDTO>>(query);
        }

        public async Task<IEnumerable<CVforSearchDTO>> GetCVsAsync(Expression<Func<CV, bool>> predicate,/*Guid userId,*/ int? pageSize = 10, int? page = 1)
        {
            IEnumerable<CV> query = await _context.CVs.Where(predicate)
                .Include(c => c.Qualification)
                .Include(c => c.Technology)
                .Include(cc => cc.SkillKnowledges)
                    .ThenInclude(c => c.KnowledgeLevel)
                        .ThenInclude(k=>k.SkillKnowledgeTypes)
                        //.Where(t=>t.UserId ==userId)
                .Include(cc => cc.SkillKnowledges)
                    .ThenInclude(c => c.Skill)
                        .ThenInclude(s => s.SkillType)
                            .ThenInclude(t => t.SkillKnowledgeTypes)
                .ToListAsync();

            IEnumerable<CVforSearchDTO> query1 =
                from t in query
                select new CVforSearchDTO()
                {
                    Id = t.Id,
                    IsActive = t.IsActive,
                    TechnologyName = t.Technology.Name,
                    QualificationName = t.Qualification.Name,
                    QualificationValue = t.Qualification.Value,
                    Summary = t.Summary,
                    UserId = t.UserId,
                    SkillKnowledges = (from s in t.SkillKnowledges
                                    select new SkillForSearchDTO()
                                    {
                                        SkillName = s.Skill.Name,
                                        KnowledgeLevelName = s.KnowledgeLevel.Name,
                                        KnowledgeValueValue = s.KnowledgeLevel.SkillKnowledgeTypes.FirstOrDefault().Value
                                    }).ToHashSet()
                };

            if (pageSize != null && page != null)
            {
                query1 = query1.Skip((int)pageSize * ((int)page-1)).Take((int)pageSize);
            }
            
            return query1;
        }

        public async Task AddSkillKnowledgeIntoCVAsync(SkillKnowledgeDTO model, Guid CVId)
        {
            var cv = await _context.CVs.FindAsync(CVId);

            var skillKnowledgeEntity = _mapper.Map<SkillKnowledgeDTO, SkillKnowledge>(model);
            cv.SkillKnowledges.Add(skillKnowledgeEntity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkillKnowledgeFromCVAsync(Guid skillId, Guid CVId)
        {
            var skillKnowledge =  await _context.SkillKnowledges
                .Where(s => s.SkillId == skillId && s.CVId == CVId)
                .FirstOrDefaultAsync();
            _context.SkillKnowledges.Remove(skillKnowledge);

            await _context.SaveChangesAsync();
        }

        public async Task AddJobExperienceIntoCVAsync(JobExperienceDTO model, Guid CVId)
        {
            var cv = await _context.CVs.FindAsync(CVId);

            var jobExperience = _mapper.Map<JobExperienceDTO, JobExperience>(model);
            cv.JobExperiences.Add(jobExperience);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobExperienceFromCVAsync(Guid JobExperienceId, Guid CVId)
        {
            var jobExperience = await _context.JobExperiences
                .Where(j => j.Id == JobExperienceId && j.CVId == CVId)
                .FirstOrDefaultAsync();
            _context.JobExperiences.Remove(jobExperience);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CVDTO cv)
        {
            var entity = _mapper.Map<CVDTO, CV>(cv);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
