using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISkillRepository _skillRepository;

        public UnitOfWork(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public ISkillRepository Skills
        {
            get
            {
                return _skillRepository;
            }
        }
    }
}
