using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
	public class MovieDirectors : Controller
	{
		private readonly IDirectorService _directorService;
		public IActionResult Index()
		{
			return View();
		}
	}
}
