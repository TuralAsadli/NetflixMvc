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
    public class MovieAudioService : IBaseManyToManyService<MovieAudioLanguage>
    {
        IBaseRepository<MovieAudioLanguage> _db;

        public MovieAudioService(IBaseRepository<MovieAudioLanguage> db)
        {
            _db = db;
        }

        public void Create(MovieAudioLanguage entity)
        {
            _db.Create(entity);
        }

        public IEnumerable<MovieAudioLanguage> GetByMovie(int id)
        {
            return _db.GetAll().Where(x => x.MovieId == id);
        }

        public void Remove(MovieAudioLanguage entity)
        {
            _db.Remove(entity);
        }
    }
}
