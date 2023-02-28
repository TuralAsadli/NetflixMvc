using DAL.DAL;
using DAL.GeneralClass;
using DAL.Movies;
using Interfaces.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        AppDbContext _appDbContext;
        protected DbSet<TEntity> _DbSet;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _DbSet = appDbContext.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _DbSet.AddAsync(item);
            Save();
        }

        public TEntity FindById(int id)
        {
            
            return _DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _DbSet.ToList();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return _DbSet.Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            _DbSet.Remove(item);
            Save();
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _appDbContext.Entry(item).State = EntityState.Modified;
            //_DbSet.Update(item);
            Save();
        }

        //public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    return Include(includeProperties);
        //}

        //public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
        //    params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    var query = Include(includeProperties);
        //    return query.Where(predicate).ToList();
        //}

        //public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    IQueryable<TEntity> query = _DbSet.AsNoTracking();
        //    return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //}

        //public IQueryable<TEntity> ThenInclude(Expression<Func<TEntity, object>> includeProperties, Expression<Func<TEntity, object>> ThenIncludeprop)
        //{
        //    IQueryable<TEntity> query = _DbSet.AsNoTracking();
        //    return query.Include(includeProperties);
        //}

        public virtual IEnumerable<TEntity> GetWithInclude(params string[] includeProperties)
        {
            return Include(_DbSet, includeProperties).ToList();
        }


        public IQueryable<TEntity> Include(IQueryable<TEntity> queryable, params string[] includeProperties)
        {
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable;
        }

        

    }
}
