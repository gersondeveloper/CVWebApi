using System.Linq.Expressions;

namespace CVWebApi.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(Guid id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>> orderBy = null, string includeProperties = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void Remove (Guid id);
        void RemoveRange(IEnumerable<T> entities);
    }
}