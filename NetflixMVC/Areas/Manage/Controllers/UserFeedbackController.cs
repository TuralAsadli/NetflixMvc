using BusinesLogic.ViewModel.Category;
using BusinesLogic.ViewModel.Settings;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class UserFeedbackController : Controller
    {
        IUserFeedbackService<UserFeedBackVM> _db;

        public UserFeedbackController(IUserFeedbackService<UserFeedBackVM> db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetWithId());
        }
        public IActionResult Detail(int id)
        {
            return View(_db.FindById(id));
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

    }
}
