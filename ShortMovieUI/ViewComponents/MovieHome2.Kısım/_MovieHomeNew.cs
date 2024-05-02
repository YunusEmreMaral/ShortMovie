using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome2.Kısım
{
	public class _MovieHomeNew : ViewComponent
	{
		private readonly IMovieService _movieService;

		public _MovieHomeNew(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
		{
			var movies = _movieService.TGetMoviesNew();
			return View(movies);
		}

	}
}