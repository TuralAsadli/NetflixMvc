using DAL.Base;
using DAL.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GeneralClass
{
    public class Actor : BaseItem
    {
        public string ActorName { get; set; }
        public string ActorSurname { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
