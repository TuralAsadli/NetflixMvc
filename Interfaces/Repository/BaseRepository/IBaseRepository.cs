using System.Linq.Expressions;

namespace Interfaces.Repository.BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T item);
        T FindById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
        void Save();

        IQueryable<T> Include(IQueryable<T> queryable, params string[] includeProperties);
        IEnumerable<T> GetWithInclude(params string[] includeProperties);
    }
}
