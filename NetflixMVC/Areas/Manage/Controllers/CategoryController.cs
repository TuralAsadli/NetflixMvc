using BusinesLogic.Services;
using BusinesLogic.ViewModel.Category;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
   
    public class CategoryController : Controller
    {
        ICategoryService<CategoryVM> _db;

        public CategoryController(ICategoryService<CategoryVM> db)
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
        public IActionResult Create(CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _db.Create(category);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            var res = _db.FindById(Id);
            if (res == null)
            {
                return BadRequest();
            }

            _db.Remove(Id);

            return RedirectToAction();
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
        public IActionResult Update(int id, CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(category);
            }

            _db.Update(id,category);

            return RedirectToAction(nameof(Index));
        }
    }
}
