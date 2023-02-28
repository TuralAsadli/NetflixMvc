using BusinesLogic.Services;
using BusinesLogic.ViewModel.Subscribe;
using BusinesLogic.ViewModel.Subtitle;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SubscribeController : Controller
    {
        ISubscribeService<SubscribeVM> _db;

        public SubscribeController(ISubscribeService<SubscribeVM> db)
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
        public IActionResult Create(SubscribeVM sub)
        {
            if (!ModelState.IsValid)
            {
                return View(sub);
            }

            _db.Create(sub);
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
        public IActionResult Update(int id, SubscribeVM sub)
        {
            if (!ModelState.IsValid)
            {
                return View(sub);
            }

            _db.Update(id, sub);

            return RedirectToAction(nameof(Index));
        }
    }
}
