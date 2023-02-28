using BusinesLogic.ViewModel.Movie;
using DAL.Entities.User;
using DAL.GeneralClass;
using DAL.Movies;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetflixMVC.ViewModel;

namespace NetflixMVC.Controllers
{
    
    public class MovieController : Controller
    {
        UserManager<User> userManager;
        IMovieService<MovieVM> _db;
        IBaseRepository<User> _users;

        public MovieController(IMovieService<MovieVM> db, UserManager<User> userManager, IBaseRepository<User> users)
        {
            _db = db;
            this.userManager = userManager;
            _users = users;
        }

        public IActionResult Index()
        {
            return View((List<Movie>)_db.GetAllWithInclude());
        }

        public IActionResult MovieDetail(int id)
        {
            if (User.Identity.IsAuthenticated != null)
            {
                var users = _users.GetWithInclude("WachedMovies");
                
                if (users.FirstOrDefault(x => x.UserName == User.Identity.Name).WachedMovies != null)
                {
                    if (users.FirstOrDefault(x => x.UserName == User.Identity.Name).WachedMovies.FirstOrDefault(m => m.MovieId == id) == null)
                    {
                        _db.AddView(id);
                        var user = users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                        if (user.WachedMovies == null)
                        {
                            user.WachedMovies = new List<WachedMovies>();
                            user.WachedMovies.Add(new WachedMovies { MovieId = id, User = user });
                            _users.Update(user);
                        }
                        else
                        {
                            user.WachedMovies.Add(new WachedMovies { MovieId = id, User = user });
                            _users.Update(user);
                        }
                    }
                    
                }
            }
            MovieWithRecomendationVM recomendationVM = new MovieWithRecomendationVM();

            var movies = (List<Movie>)_db.GetAllWithInclude();
            var res = movies.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                return BadRequest();
            }
            recomendationVM.Movie = res;
            List<Movie> categories = new List<Movie>();
            recomendationVM.Movies = movies.Where(x => x.MovieCategories.Select(c => c.CategoryId) == res.MovieCategories.Select(r => r.CategoryId));

            return View(recomendationVM);
        }

        
    }
}
