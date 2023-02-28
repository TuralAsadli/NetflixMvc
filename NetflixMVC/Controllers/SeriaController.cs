using Microsoft.AspNetCore.Mvc;

namespace NetflixMVC.Controllers
{
    public class SeriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
