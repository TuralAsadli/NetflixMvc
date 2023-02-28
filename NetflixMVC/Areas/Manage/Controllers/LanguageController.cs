using BusinesLogic.ViewModel.Language;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class LanguageController : Controller
    {
        ILanguageService<LanguageVM> _db;

        public LanguageController(ILanguageService<LanguageVM> db)
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
        public IActionResult Create(LanguageVM languageVM)
        {
            if (!ModelState.IsValid)
            {
                return View(languageVM);
            }

            _db.Create(languageVM);


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
            return View(_db.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(int id,LanguageVM languageVM)
        {
            if (!ModelState.IsValid)
            {
                return View(languageVM);
            }

            _db.Update(id, languageVM);

            return RedirectToAction(nameof(Index));
        }
    }
}
