using DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TvShows
{
    public class Series : BaseItem
    {

        public string SeriesName { get; set; }
        public string Duration { get; set; }
        public string HoverImgName { get; set; }
        public string VideoName { get; set; }

        public int Views { get; set; }

        public int SeasonId { get; set; }
        public Season Seasons { get; set; }
    }
}
