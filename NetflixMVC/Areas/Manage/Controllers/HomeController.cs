using BusinesLogic.ViewModel.Actor;
using DAL.GeneralClass;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        IActorService<ActorVM> _actorVMService;

        public HomeController(IActorService<ActorVM> actorVMService)
        {
            
            _actorVMService = actorVMService;
        }

        public IActionResult Index()
        {
            
            return View(_actorVMService.GetWithId());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ActorVM actor)
        {
            _actorVMService.Create(actor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _actorVMService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var res = _actorVMService.FindById(id);
            if (res == null)
            {
                return BadRequest();
            }
            return View(res);
        }

        [HttpPost]
        public IActionResult Update(int id,ActorVM actorVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _actorVMService.Update(id,actorVM);

            return RedirectToAction(nameof(Index));
        }
    }
}
