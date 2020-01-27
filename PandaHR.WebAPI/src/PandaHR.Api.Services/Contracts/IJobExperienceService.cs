using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IJobExperienceService
    {
        void Add(JobExperience jobExperience);
        void Remove(JobExperience jobExperience);
        void Update(JobExperience jobExperience);
        Task<JobExperience> GetById(Guid id);
    }
}
