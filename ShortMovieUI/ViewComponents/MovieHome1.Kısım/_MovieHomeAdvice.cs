using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome1.Kısım
{
    public class _MovieHomeAdvice : ViewComponent
    {
		private readonly IMovieService _movieService;

		public _MovieHomeAdvice(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public IViewComponentResult Invoke()
        {
            

            var advices = _movieService.TGetMoviesAdvices();
            return View(advices);
        }
    }
}
