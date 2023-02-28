using BusinesLogic.ViewModel.Settings;
using DAL.Entities.Settings;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingsController : Controller
    {
        ISettingsService<SettingVM> _db;

        public SettingsController(ISettingsService<SettingVM> db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            
            return View(_db.GetAll().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SettingVM setting)
        {
            if (!ModelState.IsValid)
            {
                return View(setting);
            }
            _db.Create(setting);
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
        public IActionResult Update(int id, SettingVM settingVM)
        {
            if (!ModelState.IsValid)
            {
                return View(settingVM);
            }
            _db.Update(id, settingVM);

            return RedirectToAction(nameof(Index));
        }
    }
}
