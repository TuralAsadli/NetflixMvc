using DAL.Base;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GeneralClass
{
    public class Subtitle : BaseItem
    {
        public string SubtitleName { get; set; }

        public ICollection<MovieSubtitle> MovieSubtitles { get; set; }
    }
}
