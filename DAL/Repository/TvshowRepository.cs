using DAL.DAL;
using DAL.Movies;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TvshowRepository : BaseRepository<TvShow>, ITvShowRepository<TvShow>
    {
        public TvshowRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public TvShow GetWithIdInclude(int id, params string[] includeProperties)
        {
            return Include(_DbSet.Where(x => x.Id == id), includeProperties).FirstOrDefault();
        }

    }
}
