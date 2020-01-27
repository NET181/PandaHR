using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IQualificationService
    {
        Task<IEnumerable<Qualification>> GetAllAsync();
        Task<Qualification> GetByIdAsync(Guid id);
        Task AddAsync(Qualification qualification);
        Task UpdateAsync(Qualification qualification);
        Task RemoveAsync(Guid id);
    }
}
