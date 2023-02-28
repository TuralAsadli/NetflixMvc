using DAL.Base;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.User.ManyToMany
{
    public class MovieUserPlaylist : BaseItem
    {
        public int MoviePlaylistId { get; set; }
        public MoviePlaylist MoviePlaylist { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
