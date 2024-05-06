using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
	public class MovieDirectors : Controller
	{
		private readonly IDirectorService _directorService;

		public MovieDirectors(IDirectorService directorService)
		{
			_directorService = directorService;
		}

		public IActionResult Index()
		{
			var directors=_directorService.TGetList();
			return View(directors);
		}

		public IActionResult Director(int id)
		{
			ViewBag.directorid = id;
			var director = _directorService.TGetByID(id);
			return View(director);
		}

	}
}
