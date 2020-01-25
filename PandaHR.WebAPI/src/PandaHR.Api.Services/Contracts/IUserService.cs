using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        //IEnumerable<Education> GetEducations();
        //IEnumerable<SkillKnowledge> GetSkills();

        //User GetFullInformation();
    }
}
