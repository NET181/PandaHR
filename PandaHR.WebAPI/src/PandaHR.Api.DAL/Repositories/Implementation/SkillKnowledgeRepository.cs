using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EFCore = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class SkillKnowledgeRepository : EFRepositoryAsync<SkillKnowledge>, ISkillKnowledgeRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillKnowledgeRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }
    }
}
