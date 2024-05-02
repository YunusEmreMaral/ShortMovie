using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome
{
	public class _MovieHomeSlider : ViewComponent
	{
		private readonly IMovieService _movieService;

		public _MovieHomeSlider(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IViewComponentResult Invoke()
		{
			var movies= _movieService.TMovieWithCategoryAndDirector();
			return View(movies);
		}
	}
}
