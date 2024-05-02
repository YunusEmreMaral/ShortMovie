using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome2.Kısım
{
	public class _MovieHomeShort : ViewComponent
	{
		private readonly IMovieService _movieService;

		public _MovieHomeShort(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
		{
			var movies = _movieService.TGetMoviesShort();
			return View(movies);
		}

	}
}
