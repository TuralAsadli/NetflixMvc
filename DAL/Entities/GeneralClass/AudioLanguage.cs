using DAL.Base;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GeneralClass
{
    public class AudioLanguage : BaseItem
    {
        public string AudioName { get; set; }

        public ICollection<MovieAudioLanguage> MovieAudioLanguages { get; set; }
    }
}
