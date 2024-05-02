using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome1.Kısım
{
    public class _MovieHomeLikes : ViewComponent
    {
		private readonly IMovieService _movieService;

		public _MovieHomeLikes(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
        {
            var likes = _movieService.TGetMoviesLikes();
            return View(likes);
        }
    }
}
