using BusinesLogic.ViewModel.Movie;
using BusinesLogic.ViewModel.TvShow;
using DAL.Movies;
using DAL.TvShows;

namespace NetflixMVC.ViewModel
{
    public class SearchVM
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<TvShow> TvShows { get; set; }
    }
}
