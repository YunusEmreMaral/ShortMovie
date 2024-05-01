using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
    public class MovieHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
