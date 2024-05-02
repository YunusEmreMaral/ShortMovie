using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome2.Kısım
{
	public class _MovieHomeLong : ViewComponent
	{
		private readonly IMovieService _movieService;

		public _MovieHomeLong(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
		{
			var movies = _movieService.TGetMoviesLong();
			return View(movies);
		}
	
	}
}
