using System.Linq.Expressions;

namespace CVWebApi.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task Add(T entity);
        void Remove(T entity);
        void Remove (Guid id);
        void RemoveRange(IEnumerable<T> entities);
    }
}