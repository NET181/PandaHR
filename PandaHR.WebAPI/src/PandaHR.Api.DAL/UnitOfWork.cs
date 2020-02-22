using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IVacancyCityRepository _vacancyCityRepository;
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
        private readonly ISkillTypeRepository _skillTypeRepository;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IVacancyCVFlowRepository _vacancyCVFlowRepository;

        public UnitOfWork(
            IVacancyRepository vacancyRepository,
            IVacancyCityRepository vacancyCityRepository,
            ICVRepository cvRepository,
            ISkillRepository skillRepository,
            ICompanyRepository companyRepository,
            ICompanyCityRepository companyCityRepository,
            IJobExperienceRepository jobExperienceRepository,
            IKnowledgeLevelRepository knowledgeLevelRepository,
            IDegreeRepository degreeRepository,
            ISpecialityRepository specialityRepository,
            IEducationRepository educationRepository,
            IUserRepository userRepository,
            IQualificationRepository qualificationRepository,
            ISkillRequirementRepository skillRequirementRepository,
            ISkillTypeRepository skillTypeRepository,
            IUserCompanyRepository userCompanyRepository,
            IExperienceRepository experienceRepository,
            ICityRepository cityRepository,
            ICountryRepository countryRepository,
            ITechnologyRepository technologyRepository,
            IVacancyCVFlowRepository vacancyCVFlowRepository)
        {
            _skillTypeRepository = skillTypeRepository;
            _skillRepository = skillRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _vacancyRepository = vacancyRepository;
            _vacancyCityRepository = vacancyCityRepository;
            _cvRepository = cvRepository;
            _companyCityRepository = companyCityRepository;
            _qualificationRepository = qualificationRepository;
            _skillRequirementRepository = skillRequirementRepository;
            _jobExperienceRepository = jobExperienceRepository;
            _degreeRepository = degreeRepository;
            _specialityRepository = specialityRepository;
            _educationRepository = educationRepository;
            _knowledgeLevelRepository = knowledgeLevelRepository;
            _userCompanyRepository = userCompanyRepository;
            _experienceRepository = experienceRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _technologyRepository = technologyRepository;
            _vacancyCVFlowRepository = vacancyCVFlowRepository;
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

        public ICompanyRepository Companies
        {
            get
            {
                return _companyRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                return _userRepository;
            }
        }

        public ICompanyCityRepository CompanyCities
        {
            get
            {
                return _companyCityRepository;
            }
        }

        public IUserCompanyRepository UserCompanies
        {
            get
            {
                return _userCompanyRepository;
            }
        }

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
        public IJobExperienceRepository JobExperiences
        {
            get
            {
                return _jobExperienceRepository;
            }
        }

        public IEducationRepository Educations
        {
            get
            {
                return _educationRepository;
            }
        }

        public IDegreeRepository Degrees
        {
            get
            {
                return _degreeRepository;
            }
        }

        public ISpecialityRepository Specialities
        {
            get
            {
                return _specialityRepository;
            }
        }

        public ISkillTypeRepository SkillTypes
        {
            get
            {
                return _skillTypeRepository;
            }
        }

        public IExperienceRepository Experiences
        {
            get
            {
                return _experienceRepository;
            }
        }

       
        public ICityRepository Cities
        {
            get
            {
                return _cityRepository;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                return _countryRepository;
            }
        }

        public ITechnologyRepository Technologies
        {
            get
            {
                return _technologyRepository;
            }
        }

        public IVacancyCityRepository VacancyCities
        {
            get
            {
                return _vacancyCityRepository;
            }
        }

        public IVacancyCVFlowRepository VacancyCVFlows
        {
            get
            {
                return _vacancyCVFlowRepository;
            }
        }
    }
}
