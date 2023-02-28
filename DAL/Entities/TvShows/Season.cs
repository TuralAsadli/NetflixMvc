using DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TvShows
{
    public class Season : BaseItem
    {
        public string SeasonName { get; set; }
        public DateTime ReliseTime { get; set; }
        public float Rating { get; set; }

        public string TrailerVideo { get; set; }
       
        public int TvShowId { get; set; }
        public TvShow TvShow { get; set; }
        public ICollection<Series> Series { get; set; }

    }
}
