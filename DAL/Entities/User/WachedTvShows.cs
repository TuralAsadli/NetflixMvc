using DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.User
{
    public class WachedTvShows :BaseItem
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TvShowId { get; set; }

    }
}
