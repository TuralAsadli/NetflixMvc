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
    public class MovieActorService : IBaseManyToManyService<MovieActor>
    {
        IBaseRepository<MovieActor> _db;

        public MovieActorService(IBaseRepository<MovieActor> db)
        {
            _db = db;
        }

        public void Create(MovieActor entity)
        {
            _db.Create(entity);
        }

        public IEnumerable<MovieActor> GetByMovie(int id)
        {
            return _db.GetAll().Where(x => x.MovieId == id);
        }

        

        public void Remove(MovieActor entity)
        {
            _db.Remove(entity);
        }
    }
}
