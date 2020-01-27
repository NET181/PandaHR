using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICRUDService<T>
    {
         Task<IEnumerable<T>> GetAllAsync();
         Task<T> GetById(Guid Id);
         Task Remove(T dto);
         Task Update(T dto);
         Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    }
}