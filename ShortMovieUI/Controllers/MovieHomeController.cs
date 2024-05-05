using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
    public class MovieHomeController : Controller
    {
        private readonly IAboutService _aboutService;

		public MovieHomeController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public IActionResult Index()
        {
            return View();
        }
		public IActionResult About()
		{
			var about = _aboutService.TGetList().FirstOrDefault();
			return View(about);
		}
	}
}
