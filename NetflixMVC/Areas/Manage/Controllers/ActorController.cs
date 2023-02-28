using BusinesLogic.ViewModel.Actor;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
   
    public class ActorController : Controller
    {
        IActorService<ActorVM> _db;

        public ActorController(IActorService<ActorVM> db)
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
        public IActionResult Create(ActorVM actorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(actorVM);
            }

            _db.Create(actorVM);
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
        public IActionResult Update(int Id, ActorVM actorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(actorVM);
            }

            _db.Update(Id, actorVM);

            return RedirectToAction(nameof(Index));
        }
    }
}
