using DAL.Movies;

namespace NetflixMVC.ViewModel
{
    public class MovieWithRecomendationVM
    {
        public Movie Movie { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
