using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UoWDemo.Entities;
using UoWDemo.Persistence;

namespace UoWDemo.Repositories
{
    public class Repository : IRepository
    {
        private readonly IMainDbContext _dbContext;

        public Repository(IMainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetById<T>(int id) where T : IEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> FindQueryable<T>(Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : IEntity
        {
            var query = _dbContext.Set<T>().Where(expression);
            return orderBy != null ? orderBy(query) : query;
        }

        public async Task<IEnumerable<T>> FindEnumerableAsync<T>(CancellationToken cancellationToken,
            Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
            where T : IEntity
        {
            var query = expression != null ? _dbContext.Set<T>().Where(expression) : _dbContext.Set<T>();
            return orderBy != null
                ? await orderBy(query).ToListAsync(cancellationToken)
                : await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAllAsync<T>(CancellationToken cancellationToken) where T : IEntity
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : IEntity
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public T Add<T>(T entity) where T : IEntity
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public void Update<T>(T entity) where T : IEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : IEntity
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public void Delete<T>(T entity) where T : IEntity
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
