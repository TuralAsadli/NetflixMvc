using BusinesLogic.ViewModel.Movie;
using DAL.DAL;
using DAL.Entities.User;
using DAL.Movies;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NetflixMVC.Controllers
{
    
    public class MoviePlaylistController : Controller
    {
        IBaseRepository<User> _users;
        IMovieService<MovieVM> _movies;
        UserManager<User> _usermanager;

        public MoviePlaylistController(IBaseRepository<User> users, IMovieService<MovieVM> movies, UserManager<User> usermanager)
        {
            _users = users;
            _movies = movies;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
            
            if (user == null) return NotFound();

            var trustetUser = _users.GetWithInclude("Movies").FirstOrDefault(n => n.UserName == user.UserName);

            return View(user);
        }

        public async Task<IActionResult> AddMovie(int id)
        {
            var res = (Movie)_movies.GetWithInclude(id);

            var user = await _usermanager.FindByNameAsync(User.Identity.Name);

            if (user == null) return NotFound();

            var trustetUser = _users.GetWithInclude("Movies").FirstOrDefault(n => n.UserName == user.UserName);
            if (trustetUser.Movies.FirstOrDefault(x => x.Id == res.Id) == null)
            {
                if(trustetUser.Movies == null)
                {
                    trustetUser.Movies = new List<Movie>();
                    trustetUser.Movies.Add(res);
                    _users.Update(trustetUser);
                }
                else
                {
                    trustetUser.Movies.Add(res);
                    _users.Update(trustetUser);
                }
            }

            
            
            return RedirectToAction("Index", "Home");
        }
    }
}
