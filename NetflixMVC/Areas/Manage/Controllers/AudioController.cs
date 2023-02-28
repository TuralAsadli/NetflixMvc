using BusinesLogic.ViewModel.Actor;
using BusinesLogic.ViewModel.AudioLanguage;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
 
    public class AudioController : Controller
    {
        IAudioLanguageService<AudioLanguageVM> _db;

        public AudioController(IAudioLanguageService<AudioLanguageVM> db)
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
        public IActionResult Create(AudioLanguageVM AudioVM)
        {
            if (!ModelState.IsValid)
            {
                return View(AudioVM);
            }

            _db.Create(AudioVM);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return BadRequest();
            }

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
        public IActionResult Update(int Id, AudioLanguageVM AudioVM)
        {
            if (!ModelState.IsValid)
            {
                return View(AudioVM);
            }

            _db.Update(Id, AudioVM);

            return RedirectToAction(nameof(Index));
        }
    }
}
