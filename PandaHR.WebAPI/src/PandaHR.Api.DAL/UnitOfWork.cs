using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISkillRepository _skillRepository;
        private readonly ICompanyRepository _companyRepository;

        public UnitOfWork(ISkillRepository skillRepository, ICompanyRepository companyRepository)
        {
            _skillRepository = skillRepository;
            _companyRepository = companyRepository;
        }

        public ISkillRepository Skills => _skillRepository;

        public ICompanyRepository Companies => _companyRepository;
    }
}
