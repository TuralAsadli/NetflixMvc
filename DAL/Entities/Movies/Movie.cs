using DAL.Base;
using DAL.Entities.User;
using DAL.Entities.User.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Movies
{
    public class Movie : BaseItem
    {
        public string MovieName { get; set; }
        public string Duration { get; set; }
        public string Desc { get; set; }

        public DateTime ReliseDate { get; set; }
        public int Views { get; set; }
        public string Rating { get; set; }


        public string MovieImgName { get; set; }

        public string MovieVideoName { get; set; }

        public string MovieTrailerName { get; set; }

        public ICollection<MovieLanguage> MovieLanguages { get; set; }

        public ICollection<MovieSubtitle> MovieSubtitles { get; set; }

        public ICollection<MovieAudioLanguage> MovieAudioLanguages { get; set; }

        public IEnumerable<MovieCategory> MovieCategories { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
