using Microsoft.EntityFrameworkCore;
using DotzInc.Application.Interfaces;
using DotzInc.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzInc.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DotzDbContext _dbContext;

        public GenericRepository(DotzDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetPagedReponse(int pageNumber, int maxResults)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * maxResults)
                .Take(maxResults)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
    }
}
