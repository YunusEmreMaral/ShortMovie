using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome1.Kısım
{
    public class _MovieHomeRandom : ViewComponent
    {
		private readonly IMovieService _movieService;

		public _MovieHomeRandom(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
        {
            var random = _movieService.TGetMoviesRandom();
            return View(random);
        }
    }
}
