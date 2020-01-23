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
        private readonly IUserRepository _userRepository;

        public UnitOfWork(ISkillRepository skillRepository, ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _skillRepository = skillRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public ISkillRepository Skills => _skillRepository;

        public ICompanyRepository Companies => _companyRepository;

        public IUserRepository Users => _userRepository;
    }
}
