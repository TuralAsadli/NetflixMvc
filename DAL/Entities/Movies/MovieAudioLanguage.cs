using DAL.Base;
using DAL.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Movies
{
    public class MovieAudioLanguage : BaseItem
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int AudioLanguageId { get; set; }
        public AudioLanguage AudioLanguage { get; set; }
    }
}
