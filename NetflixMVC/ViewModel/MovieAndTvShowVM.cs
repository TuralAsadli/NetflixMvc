using BusinesLogic.ViewModel.Category;
using DAL.Movies;
using DAL.Repository;
using DAL.TvShows;

namespace NetflixMVC.ViewModel
{
    public class MovieAndTvShowVM
    {
        public ICollection<Movie> Movies { get; set; }
        public ICollection<TvShow> TvShows { get; set; }

        public CategoryVM category { get; set; }
    }
}
