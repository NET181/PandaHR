using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL
{
    public interface IUnitOfWork
    {
        ISkillRepository Skills { get; }
        IVacancyRepository Vacancies { get; }
        IVacancyCityRepository VacancyCities { get; }
        ICVRepository CVs { get; }
        ICompanyRepository Companies { get; }
        IJobExperienceRepository JobExperiences { get; }
        IUserRepository Users { get; }
        ICountryRepository Countries { get; }
        ICityRepository Cities { get; }
        ICompanyCityRepository CompanyCities { get; }
        IUserCompanyRepository UserCompanies { get; }
        IQualificationRepository Qualifications { get; }
        ISkillRequirementRepository SkillRequirements { get; }
        IEducationRepository Educations { get; }
        IDegreeRepository Degrees { get; }
        ISpecialityRepository Specialities { get; }
        IKnowledgeLevelRepository KnowledgeLevels { get; }
        ISkillTypeRepository SkillTypes { get; }
        IExperienceRepository Experiences { get; }
        ITechnologyRepository Technologies { get; }
        IVacancyCVFlowRepository VacancyCVFlows { get; }
    }
}
