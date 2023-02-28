using BusinesLogic.ViewModel.Category;
using BusinesLogic.ViewModel.Movie;
using BusinesLogic.ViewModel.TvShow;
using DAL.Movies;
using DAL.TvShows;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using NetflixMVC.ViewModel;

namespace NetflixMVC.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService<CategoryVM> _db;
        ITvShowService<TvShowVM> _tvShows;
        IMovieService<MovieVM> _movies;

        public CategoryController(ICategoryService<CategoryVM> db, ITvShowService<TvShowVM> tvShows, IMovieService<MovieVM> movies)
        {
            _db = db;
            _tvShows = tvShows;
            _movies = movies;
        }

        public IActionResult Index(int id)
        {
            var category = _db.FindById(id);
            var tvshow = (List<TvShow>)_tvShows.GetAllWithInclude();
            var movies = (List<Movie>)_movies.GetAllWithInclude();
            MovieAndTvShowVM model = new MovieAndTvShowVM();

            model.Movies = movies.Where(x => x.MovieCategories.FirstOrDefault(c => c.CategoryId == id) != null).ToList();
            model.TvShows = tvshow.Where(x => x.Categories.FirstOrDefault(c => c.Id == id) != null).ToList();
            model.category = category;
            return View(model);
        }
    }
}
