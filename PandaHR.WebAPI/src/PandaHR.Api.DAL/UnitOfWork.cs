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
        private readonly IUserCompanyRepository _userCompanyRepository;
        private readonly ICompanyCityRepository _companyCityRepository;
        private readonly IQualificationRepository _qualificationRepository;
        private readonly ISkillRequirementRepository _skillRequirementRepository;
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
            IUserCompanyRepository userCompanyRepository,
            ICompanyCityRepository companyCityRepository,
            IJobExperienceRepository jobExperienceRepository,
            IKnowledgeLevelRepository knowledgeLevelRepository,
            IDegreeRepository degreeRepository,
            ISpecialityRepository specialityRepository,
            IEducationRepository educationRepository,
            IUserRepository userRepository,
            IQualificationRepository qualificationRepository,
            ISkillRequirementRepository skillRequirementRepository)
        {
            _skillRepository = skillRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _vacancyRepository = vacancyRepository;
            _cvRepository = cvRepository;
            _companyCityRepository = companyCityRepository;
            _qualificationRepository = qualificationRepository;
            _skillRequirementRepository = skillRequirementRepository;
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
        public ICompanyCityRepository CityCompanies => _companyCityRepository;

        public IUserCompanyRepository CompanyUsers => _userCompanyRepository;
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
        public IJobExperienceRepository JobExperiences => _jobExperienceRepository;

        public IEducationRepository Educations => _educationRepository;

        public IDegreeRepository Degrees => _degreeRepository;

        public ISpecialityRepository Specialities => _specialityRepository;
    }
}
