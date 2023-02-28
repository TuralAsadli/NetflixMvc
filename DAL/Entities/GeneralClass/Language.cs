using DAL.Base;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GeneralClass
{
    public class Language : BaseItem
    {
        public string LanguageName { get; set; }
        public ICollection<MovieLanguage> MovieLanguages { get; set; }
    }
}
