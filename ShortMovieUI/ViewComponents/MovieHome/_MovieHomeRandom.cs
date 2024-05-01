using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome
{
	public class _MovieHomeRandom : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			MovieManager mm = new MovieManager(new EfMovieRepository());
			var random = mm.TGetMoviesRandom();
			return View(random);
		}
	}
}
