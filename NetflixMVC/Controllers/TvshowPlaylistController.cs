
using BusinesLogic.ViewModel.TvShow;
using DAL.Entities.User;
using DAL.Movies;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Controllers
{
    public class TvshowPlaylistController : Controller
    {
        IBaseRepository<User> _users;
        ITvShowService<TvShowVM> _tvshow;
        UserManager<User> _usermanager;

        public TvshowPlaylistController(IBaseRepository<User> users, ITvShowService<TvShowVM> tvshow, UserManager<User> usermanager)
        {
            _users = users;
            _tvshow = tvshow;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _usermanager.FindByNameAsync(User.Identity.Name);

            if (user == null) return NotFound();

            var trustetUser = _users.GetWithInclude("Movies").FirstOrDefault(n => n.UserName == user.UserName);

            return View(user);
        }

        public async Task<IActionResult> AddTvshows(int id)
        {
            var res = (TvShow)_tvshow.GetWithInclude(id);

            var user = await _usermanager.FindByNameAsync(User.Identity.Name);

            if (user == null) return NotFound();

            var trustetUser = _users.GetWithInclude("Movies").FirstOrDefault(n => n.UserName == user.UserName);
            if (trustetUser.TvShows.FirstOrDefault(x => x.Id == res.Id) == null)
            {
                if (trustetUser.TvShows == null)
                {
                    trustetUser.TvShows = new List<TvShow>();
                    trustetUser.TvShows.Add(res);
                    _users.Update(trustetUser);
                }
                else
                {
                    trustetUser.TvShows.Add(res);
                    _users.Update(trustetUser);
                }
            }



            return RedirectToAction("Index", "Home");
        }
    }
}
