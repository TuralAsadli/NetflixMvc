using DAL.Base;
using DAL.Movies;
using DAL.TvShows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.User
{
    public class TvShowPlaylist :BaseItem
    {
        public string PlaylistName { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<TvShow> TvShows { get; set; }
    }
}
