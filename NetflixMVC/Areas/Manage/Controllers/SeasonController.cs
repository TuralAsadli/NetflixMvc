using BusinesLogic.ViewModel.TvShow.Season;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SeasonController : Controller
    {
        ISeasonService<SeasonVM> _db;
        public SeasonController(ISeasonService<SeasonVM> db)
        {
            _db = db;
        }

        public IActionResult AddSeason(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSeason(int id,SeasonVM season)
        {
            season.TvshowId = id;
            _db.Create(season);
            return RedirectToAction(nameof(Index),"TvShow");
        }

        public IActionResult DeleteSeason(int id)
        {
            _db.Remove(id);
            return RedirectToAction("Index", "TvShow");
        }

        public IActionResult ShowSeasons(int id)
        {
            var res = (List<SeasonWithIdVM>)_db.GetWithId();
            res = res.Where(x =>x.TvshowId == id).ToList();
            return View(res.ToList());
        }
    }
}
