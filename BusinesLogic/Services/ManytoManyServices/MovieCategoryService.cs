using DAL.GeneralClass;
using DAL.Movies;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services.ManyToManyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services.ManytoManyServices
{
    
    public class MovieCategoryService : IBaseManyToManyService<MovieCategory>
    {
        IBaseRepository<MovieCategory> _db;

        public MovieCategoryService(IBaseRepository<MovieCategory> db)
        {
            _db = db;
        }

        public void Create(MovieCategory item)
        {
            _db.Create(item);
        }

        public IEnumerable<MovieCategory> GetByMovie(int id)
        {
            return _db.GetAll().Where(x => x.MovieId == id);
        }

        public void Remove(MovieCategory entity)
        {
            _db.Remove(entity);
        }
    }
}
