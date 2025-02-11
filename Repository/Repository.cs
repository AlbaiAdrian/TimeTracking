using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public Repository(IDbContextFactory<AppDbContext> dbContextFactory) {
        _dbContextFactory = dbContextFactory;
    }

    public T GetById(int id)
    {
        using (var context = _dbContextFactory.CreateDbContext())

        {
            DbSet<T> dbSet = context.Set<T>();
            return dbSet.Find(id);
        }
    }

    // Get a single record using a Lambda expression
    public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            DbSet<T> dbSet = context.Set<T>();
            return dbSet.FirstOrDefault(predicate);
        }
    }

    public IEnumerable<T> GetAll()
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            DbSet<T> dbSet = context.Set<T>();
            return dbSet.ToList();
        }
    }

    public T Add(T entity)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            DbSet<T> dbSet = context.Set<T>();
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }
    }

    public void Update(T entity)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            DbSet<T> dbSet = context.Set<T>();
            dbSet.Update(entity);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            DbSet<T> dbSet = context.Set<T>();
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            IQueryable<T> query = context.Set<T>();
            // Apply includes dynamically
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(predicate).ToList();
        }
    }
}
