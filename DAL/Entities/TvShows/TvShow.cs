using DAL.Base;
using DAL.Entities.User;
using DAL.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TvShows
{
    public class TvShow : BaseItem
    {
        public string TvShowName { get; set; }
        public string Desc { get; set; }

        public DateTime ReliseTime { get; set; }
        public string rating { get; set; }


        public string HoverImgName { get; set; }

        public ICollection<Language> Languages { get; set; }
        public ICollection<Subtitle> Subtitle { get; set; }
        public ICollection<AudioLanguage> AudioLanguages { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Actor> Actors { get; set; }

        public ICollection<Season> Seasons { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
