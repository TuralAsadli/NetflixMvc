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
    public class MovieSubtitleService : IBaseManyToManyService<MovieSubtitle>
    {
        IBaseRepository<MovieSubtitle> _db;

        public MovieSubtitleService(IBaseRepository<MovieSubtitle> db)
        {
            _db = db;
        }

        public void Create(MovieSubtitle item)
        {
            _db.Create(item);
        }

        public IEnumerable<MovieSubtitle> GetByMovie(int id)
        {
            return _db.GetAll().Where(x => x.MovieId == id);
        }

        public void Remove(MovieSubtitle entity)
        {
            _db.Remove(entity);
        }
    }
}
