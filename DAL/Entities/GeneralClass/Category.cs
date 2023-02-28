using DAL.Base;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GeneralClass
{
    public class Category : BaseItem
    {
        public string CategoryName { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
