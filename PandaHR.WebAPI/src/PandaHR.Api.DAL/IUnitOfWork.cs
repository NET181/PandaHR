using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL
{
    public interface IUnitOfWork
    {
        ISkillRepository Skills { get; }
        IVacancyRepository Vacancies{ get; }
        ICVRepository CVs { get; }
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        IEducationRepository Educations { get; }
        IDegreeRepository Degrees { get; }
        ISpecialityRepository Specialities { get; }
    }
}
