using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome2.Kısım
{
	public class _MovieHomeLast : ViewComponent
	{
		private readonly IMovieService _movieService;

		public _MovieHomeLast(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
		{
			var movies = _movieService.TGetMoviesLast();
			return View(movies);
		}

	}
}
