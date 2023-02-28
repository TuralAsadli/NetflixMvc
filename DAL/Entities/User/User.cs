using DAL.Base;
using DAL.Movies;
using DAL.TvShows;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.User
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int SubscribeId { get; set; }
        public Subscribe? Subscribe { get; set; }

        public DateTime SubscribeStartTime { get; set; }
        public DateTime SubscribeEndTime { get; set; }


        public ICollection<WachedMovies> WachedMovies { get; set; }
        public ICollection<WachedTvShows> WachedTvShows { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<TvShow> TvShows { get; set; }

        //public int MoviePlaylistId { get; set; }
        //public MoviePlaylist MoviePlaylist { get; set; }
        //public int TvShowPlaylistId { get; set; }
        //public TvShowPlaylist TvShowPlaylist { get; set; }

        //I modify this in future 
        //public ICollection<MoviePlaylist> MoviePlaylists { get; set; }
        //public ICollection<TvShowPlaylist> TvShowPlaylist { get; set; }

    }
}
