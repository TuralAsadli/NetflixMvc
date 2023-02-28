using DAL.Base;
using DAL.Entities.User.ManyToMany;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.User
{
    public class MoviePlaylist : BaseItem
    {
        public string PlaylistName { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
