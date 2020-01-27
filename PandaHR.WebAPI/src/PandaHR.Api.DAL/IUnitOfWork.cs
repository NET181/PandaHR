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
        ICompanyCityRepository CityCompanies { get; }

        IUserCompanyRepository CompanyUsers { get; }
    }
}
