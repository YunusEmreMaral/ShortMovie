using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
    public class MovieHomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IPersonalService _personalService;

		public MovieHomeController(IAboutService aboutService,IPersonalService personalService)
		{
			_aboutService = aboutService;
			_personalService = personalService;

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
		[HttpGet]
		public IActionResult AboutPersonal(string name)
		{
			ViewBag.name = name;
			return View();
		}
		[HttpPost]
		public IActionResult AboutPersonal(Personal personal)
		{
			_personalService.TAdd(personal);
            return RedirectToAction("Index","MovieHome");
		}

		public IActionResult ErrorPage404() => View();
		
	}
}
