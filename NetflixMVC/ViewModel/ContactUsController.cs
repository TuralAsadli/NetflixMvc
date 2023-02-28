using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.ViewModel
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
