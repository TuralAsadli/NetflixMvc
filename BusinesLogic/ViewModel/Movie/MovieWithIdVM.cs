using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.Movie
{
    public class MovieWithIdVM : MovieVM
    {
        public int Id { get; set; }
        public string Duration { get; set; }
        public string Rating { get; set; }

        public int Views { get; set; }
    }
}
