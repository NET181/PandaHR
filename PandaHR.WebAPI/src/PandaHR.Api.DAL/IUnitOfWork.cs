using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL
{
    public interface IUnitOfWork
    {
        ISkillRepository Skills { get; }
        ICompanyRepository Companies { get; }
    }
}
