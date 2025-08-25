using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public interface IRepository<T> where T : class
    {
        //Task tek başına void metodunun yerine geçer.
        Task InsertOneAsync(T entity);
        Task InsertManyAsync(IEnumerable<T> entities);

        Task<T> FindByKeyAsync(object entityKey);
        // Expression(ifade): Filtreleme için kullanılır. (örn: x=>!x.Draft && x.PublishDate >= DateTime.Now.AddDays(-5))
        Task<T> FindFirstAsync(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression = null);

        Task UpdateOneAsync(T entity);
        Task UpdateManyAsync(IEnumerable<T> entities);

        Task DeleteOneAsync(object entityKey);
        Task DeleteOneAsync(T entity);
        Task DeleteManyAsync(IEnumerable<T> entities);
        Task DeleteManyAsync(Expression<Func<T, bool>> expression = null);

        Task<int> CountAsync(Expression<Func<T, bool>> expression = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null);
    }
}
