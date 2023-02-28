using DAL.DAL;
using DAL.Movies;
using Interfaces.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository<Movie>
    {
        public MovieRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public Movie GetWithIdInclude(int id,params string[] includeProperties)
        {
            return Include(_DbSet.Where(x => x.Id == id), includeProperties).FirstOrDefault();
        }

        //public IEnumerable<Movie> GetWithITheniclude(Expression<Func<Movie, object>>[] includeProperties, Expression<Func<Movie, object>>[] ThenincludeProperties)
        //{
        //    return _DbSet.Include(x => x.MovieCategories).ThenInclude(x => x.Category);
        //}

        //public IQueryable<Movie> Include(IQueryable<Movie> queryable,Expression<Func<Movie, object>>[] includeProperties, Expression<Func<object, object>>[] ThenincludeProperties)
        //{
        //    for (int i = 0; i < includeProperties.Length; i++)
        //    {
        //        queryable = queryable.Include(includeProperties[i]).ThenInclude(ThenincludeProperties[i]);
        //    }
        //    return queryable;
        //}
    }
}
