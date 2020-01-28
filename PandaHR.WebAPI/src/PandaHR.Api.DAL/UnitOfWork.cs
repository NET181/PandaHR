﻿using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly ICVRepository _cvRepository;
        private readonly IQualificationRepository _qualificationRepository;
        private readonly ISkillRequirementRepository _skillRequirementRepository;

        public UnitOfWork(IVacancyRepository vacancyRepository,
            ICVRepository cvRepository,
            ISkillRepository skillRepository,
            ICompanyRepository companyRepository,
            IUserRepository userRepository,
            IQualificationRepository qualificationRepository,
            ISkillRequirementRepository skillRequirementRepository)
        {
            _skillRepository = skillRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _vacancyRepository = vacancyRepository;
            _cvRepository = cvRepository;
            _qualificationRepository = qualificationRepository;
            _skillRequirementRepository = skillRequirementRepository;
        }

        public ISkillRepository Skills
        {
            get
            {
                return _skillRepository;
            }
        }

        public ICVRepository CVs
        {
            get
            {
                return _cvRepository;
            }
        }

        public IVacancyRepository Vacancies
        {
            get
            {
                return _vacancyRepository;
            }
        }

        public ICompanyRepository Companies => _companyRepository;

        public IUserRepository Users => _userRepository;

        public IQualificationRepository Qualifications
        {
            get
            {
                return _qualificationRepository;
            }
        }

        public ISkillRequirementRepository SkillRequirements
        {
            get
            {
                return _skillRequirementRepository;
            }
        }
    }
}
