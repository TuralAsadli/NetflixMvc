using DAL.Base;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.User
{
    public class WachedMovies : BaseItem
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int MovieId { get; set; }
        
    }
}
