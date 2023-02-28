using BusinesLogic.ViewModel.TvShow;
using BusinesLogic.ViewModel.TvShow.Seria;
using DAL.Entities.User;
using DAL.Movies;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Controllers
{
    public class TvShowController : Controller
    {
        ITvShowService<TvShowVM> _db;
        IBaseRepository<User> _users;
        ISeriaService<SeriaVM> _series;

        public TvShowController(ITvShowService<TvShowVM> db, IBaseRepository<User> user, ISeriaService<SeriaVM> series)
        {
            _db = db;
            _users = user;
            _series = series;
        }

        // GET: TvShowController
        public ActionResult Index()
        {
            
            return View((List<TvShow>)_db.GetAllWithInclude());
        }

        public IActionResult TvShowDetail(int id)
        {
            
            var res = (TvShow)_db.GetWithInclude(id);
            if (res == null)
            {
                return BadRequest();
            }

            return View(res);
        }

        public IActionResult SeasonDetail(int id,int seasonId, int seriaId)
        {
            if (User.Identity.IsAuthenticated != null)
            {
                var users = _users.GetWithInclude("WachedTvShows");

                if (users.FirstOrDefault(x => x.UserName == User.Identity.Name).WachedTvShows != null)
                {
                    if (users.FirstOrDefault(x => x.UserName == User.Identity.Name).WachedTvShows.FirstOrDefault(m => m.TvShowId == id) == null)
                    {
                        _series.AddView(seriaId);
                        var user = users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                        if (user.WachedTvShows == null)
                        {
                            user.WachedTvShows = new List<WachedTvShows>();
                            user.WachedTvShows.Add(new WachedTvShows { TvShowId = id, User = user });
                            _users.Update(user);
                        }
                        else
                        {
                            user.WachedTvShows.Add(new WachedTvShows { TvShowId = id, User = user });
                            _users.Update(user);
                        }
                    }

                }
            }


            var res = (TvShow)_db.GetWithInclude(id);
            var series = res.Seasons.FirstOrDefault(x => x.Id == seasonId).Series.FirstOrDefault(x => x.Id == seriaId);
           
            return View(series);
        }

    }
}
