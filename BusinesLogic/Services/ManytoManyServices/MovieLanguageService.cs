using DAL.Movies;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services.ManyToManyServices;

namespace BusinesLogic.Services.ManytoManyServices
{
    
    public class MovieLanguageService : IBaseManyToManyService<MovieLanguage>
    {
        IBaseRepository<MovieLanguage> _db;

        public MovieLanguageService(IBaseRepository<MovieLanguage> db)
        {
            _db = db;
        }

        public void Create(MovieLanguage item)
        {
            _db.Create(item);
        }

        public IEnumerable<MovieLanguage> GetByMovie(int id)
        {
            return _db.GetAll().Where(x => x.MovieId == id);
        }

        public void Remove(MovieLanguage entity)
        {
            _db.Remove(entity);
        }
    }
}
