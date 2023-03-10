using System.Linq.Expressions;
using CVWebApi.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CVWebApi.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CVDbContext _context;
    internal DbSet<T> _dbSet;

    public Repository(CVDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<T> Get(Guid id)
    {
        return await _dbSet.FindAsync(id);
    } 

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return await query.ToListAsync();
    }

    public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        return await query.FirstOrDefaultAsync();
    }

    public void Remove(int id)
    {
        T entity = _dbSet.Find(id);

        Remove(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Remove(Guid id)
    {
        T entity = _dbSet.Find(id);
        Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}