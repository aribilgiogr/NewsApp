using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _set.AnyAsync() : await _set.AnyAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _set.CountAsync() : await _set.CountAsync(expression);
        }

        public async Task DeleteManyAsync(IEnumerable<T> entities)
        {
            // Task.Run: async olamayan fonksiyonların async olarak çalışmasını sağlar.
            await Task.Run(() => _set.RemoveRange(entities));
        }

        public async Task DeleteManyAsync(Expression<Func<T, bool>> expression = null)
        {
            var entities = await FindManyAsync(expression);
            _set.RemoveRange(entities);
        }

        public async Task DeleteOneAsync(object entityKey)
        {
            var entity = await FindByKeyAsync(entityKey);
            await DeleteOneAsync(entity);
        }

        public async Task DeleteOneAsync(T entity)
        {
            await Task.Run(() => _set.Remove(entity));
        }

        public async Task<T> FindByKeyAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _set.FirstOrDefaultAsync() : await _set.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _set.ToListAsync() : await _set.Where(expression).ToListAsync();
        }

        public async Task InsertManyAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => _set.AddRange(entities));
        }

        public async Task InsertOneAsync(T entity)
        {
            await Task.Run(() => _set.Add(entity));
        }

        public async Task UpdateManyAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => _context.Entry(entities).State = EntityState.Modified);
        }

        public async Task UpdateOneAsync(T entity)
        {
            await Task.Run(() => _context.Entry(entity).State = EntityState.Modified);
        }
    }
}
