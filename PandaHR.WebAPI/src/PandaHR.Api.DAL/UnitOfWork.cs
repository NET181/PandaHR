using PandaHR.Api.DAL.Repositories.Contracts;
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
        private readonly IJobExperienceRepository _jobExperienceRepository;
        private readonly IKnowledgeLevelRepository _knowledgeLevelRepository;

        private readonly IDegreeRepository _degreeRepository;
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IKnowledgeLevelRepository _knowledgeLevelRepository;
        
        public UnitOfWork(IVacancyRepository vacancyRepository, 
            ICVRepository cvRepository, 
            ISkillRepository skillRepository, 
            ICompanyRepository companyRepository, 
            IUserRepository userRepository,
            IJobExperienceRepository jobExperienceRepository)
            IUserRepository userRepository
            ,IKnowledgeLevelRepository knowledgeLevelRepository)
            IDegreeRepository degreeRepository,
            ISpecialityRepository specialityRepository,
            IEducationRepository educationRepository,
            IUserRepository userRepository,
            IKnowledgeLevelRepository knowledgeLevelRepository)
        {
            _skillRepository = skillRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _vacancyRepository = vacancyRepository;
            _cvRepository = cvRepository;
            _jobExperienceRepository = jobExperienceRepository;
            _degreeRepository = degreeRepository;
            _specialityRepository = specialityRepository;
            _educationRepository = educationRepository;
            _knowledgeLevelRepository = knowledgeLevelRepository;
        }

        public IKnowledgeLevelRepository KnowledgeLevels
        {
            get
            {
                return _knowledgeLevelRepository;
            }
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
        public IJobExperienceRepository JobExperiences => _jobExperienceRepository;

        public IEducationRepository Educations => _educationRepository;

        public IDegreeRepository Degrees => _degreeRepository;

        public ISpecialityRepository Specialities => _specialityRepository;
    }
}
