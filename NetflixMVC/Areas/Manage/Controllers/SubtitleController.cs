using BusinesLogic.Services;
using BusinesLogic.ViewModel.Language;
using BusinesLogic.ViewModel.Subtitle;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SubtitleController : Controller
    {
        ISubtitleService<SubtitleVM> _db;

        public SubtitleController(ISubtitleService<SubtitleVM> db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetWithId());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubtitleVM subtitle)
        {
            if (!ModelState.IsValid)
            {
                return View(subtitle);
            }

            _db.Create(subtitle);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _db.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return BadRequest();
            }

            return View(res);
        }

        [HttpPost]
        public IActionResult Update(int id, SubtitleVM subtitleVM)
        {
            if (!ModelState.IsValid)
            {
                return View(subtitleVM);
            }

            _db.Update(id, subtitleVM);

            return RedirectToAction(nameof(Index));
        }
    }
}
