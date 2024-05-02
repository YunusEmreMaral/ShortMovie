using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHomeDirectors
{
	public class _MovieHomeDirectors : ViewComponent
	{
		private readonly IDirectorService _directorService;

		public _MovieHomeDirectors(IDirectorService movieService)
		{
			_directorService = movieService;
		}
		public IViewComponentResult Invoke()
		{
			var directors = _directorService.TGet10Director();
			return View(directors);
		}
	}
}