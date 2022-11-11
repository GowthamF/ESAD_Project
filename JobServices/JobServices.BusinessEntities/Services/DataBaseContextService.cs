using JobServices.BusinessEntities.Interfaces;
using JobServices.BusinessEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace JobServices.BusinessEntities.Services
{
    public class DataBaseContextService<T> : IDataBaseContext<T> where T : EntityBase
    {
        private readonly DataBaseContext _dbContext;

        public DataBaseContextService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> List()
        {
            var db = _dbContext.Set<T>();


            return await db.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                   .Where(predicate)
                   .ToListAsync();
        }

        public async Task<T> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

    }
}
