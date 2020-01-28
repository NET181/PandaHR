using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IJobExperienceRepository: IAsyncRepository<JobExperience>
    {
        Task<JobExperience> GetById(Guid id);
    }
}
