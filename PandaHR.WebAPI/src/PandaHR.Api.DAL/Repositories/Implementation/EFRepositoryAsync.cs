using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class EFRepositoryAsync<T> : IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public EFRepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
