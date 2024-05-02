using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome1.Kısım
{
    public class _MovieHomePrizes : ViewComponent
    {
		private readonly IMovieService _movieService;

		public _MovieHomePrizes(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
        {
            var prizes = _movieService.TGetMoviesPrizes();
            return View(prizes);
        }
    }
}
