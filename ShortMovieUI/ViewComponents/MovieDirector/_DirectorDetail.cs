using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents
{
	public class _DirectorDetail : ViewComponent
	{
		private readonly IMovieService _movieService;

		public _DirectorDetail(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public IViewComponentResult Invoke(int directorid)
		{
			var movies = _movieService.TDirectorsMovies(directorid);
			return View(movies);
		}
	}
}
