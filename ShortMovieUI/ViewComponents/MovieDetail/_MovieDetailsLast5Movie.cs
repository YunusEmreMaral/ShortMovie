using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieDetail
{
	public class _MovieDetailsLast5Movie:ViewComponent
	{
		private readonly IMovieService _movieService;

		public _MovieDetailsLast5Movie(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public IViewComponentResult Invoke()
		{
			var movies = _movieService.TGetLast5Movie();
			return View(movies);
		}
	}
}
