using Microsoft.EntityFrameworkCore;
using OrderProject.Data.DbContexs;
using OrdersProject.Data.IRepository;
using OrdersProject.Domain.Commons;
using System.Linq.Expressions;

namespace OrdersProject.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private readonly OrdersProjectDbContex _dbContex;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(OrdersProjectDbContex dbContex)
        {
            _dbContex = dbContex;
            _dbSet = dbContex.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).Entity;

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await GetAsync(x => x.Id == id);
            if (deleted is null)
                return false;

            _dbSet.Remove(deleted);
            return true;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            var getAll = expression is null ? _dbSet : _dbSet.Where(expression);

            if (!isTracking)
                _dbSet.AsNoTracking();

            if (includes != null)
                foreach (var include in includes)
                    if (!string.IsNullOrEmpty(include))
                        getAll = getAll.Include(include);

            return getAll;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
            => await GetAll(expression, includes, isTracking).FirstOrDefaultAsync();

        public T Update(T entity)
             => _dbSet.Update(entity).Entity;

        public async Task SaveChangesAsync()
            => await _dbContex.SaveChangesAsync();

    }
}
