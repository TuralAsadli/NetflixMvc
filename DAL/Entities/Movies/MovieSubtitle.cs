using DAL.Base;
using DAL.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Movies
{
    public class MovieSubtitle : BaseItem
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }

    }
}
