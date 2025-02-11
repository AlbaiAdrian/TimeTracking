using System.Linq.Expressions;

namespace Repository;

public interface IRepository<T> where T : class
{
    T GetById(int id);

    T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

    IEnumerable<T> GetAll();

    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    T Add(T entity);

    void Update(T entity);

    void Delete(int id);
}
