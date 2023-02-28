using BusinesLogic.ViewModel.TvShow.Season;
using BusinesLogic.ViewModel.TvShow.Seria;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SeriaController : Controller
    {
        ISeriaService<SeriaVM> _db;

        public SeriaController(ISeriaService<SeriaVM> db)
        {
            _db = db;
        }

        public IActionResult AddSeria(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSeria(int id, SeriaVM seria)
        {
            seria.SeasonId = id;
            _db.Create(seria);
            return RedirectToAction("Index", "TvShow");
        }

        public IActionResult DeleteSeria(int id)
        {
            _db.Remove(id);
            return RedirectToAction("Index", "TvShow");
        }

        public IActionResult ShowSeries(int id)
        {
            var res = (List<SeriaWithIdVM>)_db.GetWithId();
            res = res.Where(x => x.SeasonId == id).ToList();
            return View(res.ToList());
        }
    }
}
